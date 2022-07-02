using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeatmapParserRefactor;

public static class Tests
{
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

    private static bool CheckObject(JToken jToken1, JToken jToken2)
    {
        if (jToken1.Type != jToken2.Type) return false;

        if (jToken1.Type == JTokenType.Array)
        {
            var array1 = jToken1 as JArray ?? jToken1.ToObject<JArray>()!;
            var array2 = jToken2 as JArray ?? jToken2.ToObject<JArray>()!;

            if (array1.Count != array2.Count) return false;

            var set1 = array1.ToImmutableHashSet();
            var set2 = array2.ToImmutableHashSet();

            return set1.Count == set2.Count;
            // Since ordering doesn't work, we don't extensively check arrays ugh
            // &&
            // // This is SLOW
            // set1.All(i => set2.Any(j => CheckObject(i, j)));
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


            if (!CheckObject(prop1.Value, prop2.Value)) return false;
        }

        return true;
    }
}