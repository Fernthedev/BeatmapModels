// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using BeatmapParserRefactor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using var stream = File.OpenRead("test_maps/FoolishOfMeEPlusLawless.dat");
using var streamReader = new StreamReader(stream, new UTF8Encoding());
using var jsonReader = new JsonTextReader(streamReader);

var options = new JsonSerializerSettings
{
    NullValueHandling = NullValueHandling.Ignore,
    MaxDepth = null,
    Culture = CultureInfo.InvariantCulture
};

var serializer = JsonSerializer.CreateDefault(options);


IBeatmap? beatmap = serializer.Deserialize<V2Beatmap>(jsonReader);
Debug.Assert(beatmap != null, nameof(beatmap) + " != null");

Console.WriteLine("Parsed beatmap");

Tests.CheckMutability(beatmap, streamReader, serializer);

beatmap.Events = beatmap.Events.OrderBy(e => e).ToList();
beatmap.Notes = beatmap.Notes.OrderBy(e => e).ToList();
beatmap.Obstacles = beatmap.Obstacles.OrderBy(e => e).ToList();
beatmap.Sliders = beatmap.Sliders?.OrderBy(e => e).ToList();
beatmap.Waypoints = beatmap.Waypoints.OrderBy(e => e).ToList();

if (beatmap.BeatmapCustomData != null)
{
    beatmap.BeatmapCustomData.CustomEvents = beatmap.BeatmapCustomData.CustomEvents?.OrderBy(e => e).ToList();
}

Debug.Assert(beatmap.Events.Any(e => e.CustomData?.Color != null));