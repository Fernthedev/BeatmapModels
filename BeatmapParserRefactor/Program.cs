// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;

using var stream = File.OpenRead("test_maps/FoolishOfMeEPlusLawless.dat");
using var streamReader = new StreamReader(stream, new UTF8Encoding());
using var jsonReader = new JsonTextReader(streamReader);

var serializer = JsonSerializer.CreateDefault();


IBeatmap? beatmap = serializer.Deserialize<V2Beatmap>(jsonReader);
Debug.Assert(beatmap != null, nameof(beatmap) + " != null");

Console.WriteLine("Parsed beatmap");


Debug.Assert(beatmap.Events.Any(e => e.CustomData?.Color != null));