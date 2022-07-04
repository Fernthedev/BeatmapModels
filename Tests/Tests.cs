using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class BeatmapTests
{
    public static StreamReader V2StreamReader()
    {
        var stream = File.OpenRead("test_maps/FoolishOfMeEPlusLawless.dat");
        return new StreamReader(stream, new UTF8Encoding());  
    }
    
    public static StreamReader V3StreamReader()
    {
        var stream = File.OpenRead("test_maps/IMY.dat");
        return new StreamReader(stream, new UTF8Encoding());  
    }
    
    public static V2Beatmap GetTestV2Beatmap(JsonSerializer serializer)
    {
        using var streamReader = V2StreamReader();
        using var jsonReader = new JsonTextReader(streamReader);
        
        return serializer.Deserialize<V2Beatmap>(jsonReader)!;
    }

    public static void TestRepeatedV2Deserialization(JsonSerializer serializer)
    {
        Stopwatch stopwatch = new Stopwatch();

        using var streamReader = V2StreamReader();
        using var jsonReader = new JsonTextReader(streamReader);

        Console.WriteLine("Repeated runs for JIT warmup: v2");
        streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
        var json = streamReader.ReadToEnd();

        for (var i = 0; i < 10; i++)
        {
            using var jsonReader2 = new JsonTextReader(new StringReader(json));

            stopwatch.Restart();
            serializer.Deserialize<V2Beatmap>(jsonReader2);
            stopwatch.Stop();

            Console.WriteLine($"Run {i} took: {stopwatch.ElapsedMilliseconds}ms");
        }

    }
    
    public static void TestRepeatedV3Deserialization(JsonSerializer serializer)
    {
        Stopwatch stopwatch = new Stopwatch();

        using var streamReader = V3StreamReader();
        using var jsonReader = new JsonTextReader(streamReader);

        Console.WriteLine("Repeated runs for JIT warmup: v3");
        streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
        var json = streamReader.ReadToEnd();

        for (var i = 0; i < 10; i++)
        {
            using var jsonReader2 = new JsonTextReader(new StringReader(json));

            stopwatch.Restart();
            serializer.Deserialize<V3Beatmap>(jsonReader2);
            stopwatch.Stop();

            Console.WriteLine($"Run {i} took: {stopwatch.ElapsedMilliseconds}ms");
        }

    }

    public static V3Beatmap GetTestV3Beatmap(JsonSerializer serializer)
    {
        using var stream = File.OpenRead("test_maps/IMY.dat");
        using var streamReader = new StreamReader(stream, new UTF8Encoding());
        using var jsonReader = new JsonTextReader(streamReader);
        
        return serializer.Deserialize<V3Beatmap>(jsonReader)!;
    }

    public static void StressTestBeatmap(IBeatmap beatmap, StreamReader streamReader, JsonSerializer serializer)
    {
        CheckMutability(beatmap, streamReader, serializer);

        beatmap.BasicEvents = beatmap.BasicEvents.OrderBy(e => e).ToList();
        beatmap.Notes = beatmap.Notes.OrderBy(e => e).ToList();
        beatmap.Obstacles = beatmap.Obstacles.OrderBy(e => e).ToList();
        beatmap.Waypoints = beatmap.Waypoints.OrderBy(e => e).ToList();

        if (beatmap.BeatmapCustomData != null)
        {
            beatmap.BeatmapCustomData.CustomEvents = beatmap.BeatmapCustomData.CustomEvents?.OrderBy(e => e).ToList();
        }

        Debug.Assert(beatmap.BasicEvents.Any(e => e.CustomData?.Color != null));

        Console.WriteLine("Note clone");
        CheckClone(beatmap.Notes.First());
        Console.WriteLine("Obstacle clone");
        CheckClone(beatmap.Obstacles.First());

        Console.WriteLine("Event clone");
        CheckClone(beatmap.BasicEvents.First());
    }
    
    public static void CheckClone<T>(T item) where T: IBeatmapItem
    {
        var clone = item.Clone();
        
        if (item.GetType() != clone.GetType()) throw new InvalidOperationException($"Types are not equal {item.GetType()}");

        var tClone = (T) clone;
        
        if (Math.Abs(item.Time - tClone.Time) > 0.0001) throw new InvalidOperationException($"Times are not equal {item.GetType()}");

        if (JsonConvert.SerializeObject(item) != JsonConvert.SerializeObject(tClone))
            throw new InvalidOperationException($"Generated json is not identical {item.GetType()}");
        
    }
    
    public static void CheckMutability(IBeatmap beatmap, StreamReader originalStream, JsonSerializer serializer)
    {
        using var jTokenWriter = new JTokenWriter();
        jTokenWriter.Culture = CultureInfo.InvariantCulture;
        jTokenWriter.Formatting = Formatting.None;

        serializer.Serialize(jTokenWriter, beatmap);

        originalStream.BaseStream.Seek(0, SeekOrigin.Begin);

        using var jsonReader2 = new JsonTextReader(originalStream);

        var parsed = jTokenWriter.Token!.ToObject<JObject>(serializer)!;
        var original = serializer.Deserialize<JObject>(jsonReader2)!;

        var stopwatch = Stopwatch.StartNew();
        if (!CheckObject(original, parsed))
        {
            throw new InvalidOperationException("Beatmap was mutated");
        }

        Console.WriteLine(
            $"Deserialized beatmap and serialized beatmap are identical 🎉. Took {stopwatch.ElapsedMilliseconds}ms");
    }

    private static bool IsNumber(JToken token) => token.Type is JTokenType.Float or JTokenType.Integer;

    private static bool CheckObject(JToken jToken1, JToken jToken2)
    {
        if (jToken1.Type != jToken2.Type && IsNumber(jToken1) != IsNumber(jToken2)) return false;

        if (jToken1.Type == JTokenType.Array)
        {
            var array1 = jToken1 as JArray ?? jToken1.ToObject<JArray>()!;
            var array2 = jToken2 as JArray ?? jToken2.ToObject<JArray>()!;

            if (array1.Count != array2.Count) return false;

            for (var i = 0; i < array1.Count; i++)
            {
                var e1 = array1[i];
                var e2 = array2[i];
            
                if (!CheckObject(e1, e2)) return false;
            }

            return true;

        }

        // Float subtlety 
        if (jToken1.Type == JTokenType.Float || jToken2.Type == JTokenType.Float)
        {
            var d1 = jToken1.ToObject<decimal>();
            var d2 = jToken2.ToObject<decimal>();
            
            
            return d1.Equals(d2) || Math.Abs(d1 - d2) < (decimal)0.0001;
        }

        if (jToken1.Type != JTokenType.Object)
        {
            return jToken1.Equals(jToken2);
        }

        var jObject1 = jToken1 as JObject ?? jToken1.ToObject<JObject>()!;
        var jObject2 = jToken2 as JObject ?? jToken2.ToObject<JObject>()!;

        var properties1 = jObject1.Properties().ToImmutableDictionary(p => p.Name, p => p);
        var properties2 = jObject2.Properties().ToImmutableDictionary(p => p.Name, p => p);

        if (properties1.Count != properties2.Count) return false;

        var keys = properties1.Keys.ToList();
        keys.AddRange(properties2.Keys);
        keys = keys.Distinct().ToList();

        if (properties1.Count != keys.Count || properties2.Count != keys.Count) return false;

        foreach (var key in keys)
        {
            if (!properties1.ContainsKey(key) || !properties2.ContainsKey(key)) return false;

            var prop1 = properties1[key];
            var prop2 = properties2[key];

            // Color alpha is omitted
            if (prop1.Name is "_color" or "color") continue;

            if (!CheckObject(prop1.Value, prop2.Value)) return false;
        }

        return true;
    }
}