// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;

const bool v2 = true;
const bool v3 = true;


var options = new JsonSerializerSettings
{
    NullValueHandling = NullValueHandling.Ignore,
    MaxDepth = null,
    Culture = CultureInfo.InvariantCulture
};

var serializer = JsonSerializer.CreateDefault(options);

var stopwatch = Stopwatch.StartNew();

if (v2)
{
    IBeatmap? v2Beatmap = BeatmapTests.GetTestV2Beatmap(serializer);
    Debug.Assert(v2Beatmap != null, nameof(v2Beatmap) + " != null");

    Console.WriteLine($"Parsed v2 beatmap in {stopwatch.ElapsedMilliseconds}ms");
    BeatmapTests.TestRepeatedV2Deserialization(serializer);
    BeatmapTests.StressTestBeatmap(v2Beatmap, BeatmapTests.V2StreamReader(), serializer);
    Console.WriteLine("Passed all v2 tests!");
}

if (v3)
{
    stopwatch.Restart();
    IBeatmap v3Beatmap = BeatmapTests.GetTestV3Beatmap(serializer);
    Debug.Assert(v3Beatmap != null, nameof(v3Beatmap) + " != null");

    Console.WriteLine($"Parsed v3 beatmap in {stopwatch.ElapsedMilliseconds}ms");
    BeatmapTests.TestRepeatedV3Deserialization(serializer);
    BeatmapTests.StressTestBeatmap(v3Beatmap, BeatmapTests.V3StreamReader(), serializer);
    Console.WriteLine("Passed all v3 tests!");
}