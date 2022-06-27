using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2Beatmap : IBeatmap
{
    [JsonConstructor]
    public V2Beatmap(IDictionary<string, JToken>? unserializedData, V2BeatmapCustomData? beatmapCustomData,
        IList<INote> notes, IList<IEvent> events, IList<IObstacle> obstacles)
    {
        UnserializedData = unserializedData ?? new Dictionary<string, JToken>();
        BeatmapCustomData = beatmapCustomData;
        Notes = notes;
        Events = events;
        Obstacles = obstacles;
    }

    public bool isV3 => false;

    public IBeatmapJSON Clone()
    {
        return new V2Beatmap(new Dictionary<string, JToken>(UnserializedData),
            UntypedCustomData?.Clone() as V2BeatmapCustomData, new List<INote>(Notes), new List<IEvent>(Events),
            new List<IObstacle>(Obstacles));
    }

    [JsonExtensionData]
    public IDictionary<string, JToken> UnserializedData { get; }

    [JsonIgnore]
    public ICustomData? UntypedCustomData
    {
        get => BeatmapCustomData;
        set => BeatmapCustomData = value is null
            ? null
            : value as V2BeatmapCustomData ?? new V2BeatmapCustomData(value.UnserializedData);
    }

    [JsonProperty("_notes")]
    [JsonConverter(typeof(V2NoteListConverter))]
    public IList<INote> Notes { get; }

    [JsonProperty("_events")]
    [JsonConverter(typeof(V2EventListConverter))]
    public IList<IEvent> Events { get; }

    [JsonConverter(typeof(V2ObstacleListConverter))]
    [JsonProperty("_obstacles")]
    public IList<IObstacle> Obstacles { get; }

    [JsonConverter(typeof(V2WaypointListConverter))]
    [JsonProperty("_waypoints")]
    public IList<IWaypoint> Waypoints { get; }

    [JsonConverter(typeof(V2SliderListConverter))]
    [JsonProperty("_sliders")]
    public IList<ISlider> Sliders { get; }

    [JsonProperty("_customData")]
    [TypeConverter(typeof(V2BeatmapCustomData))]
    [JsonConverter(typeof(ConcreteConverter<V2BeatmapCustomData>))]
    public IBeatmapCustomData? BeatmapCustomData { get; set; }
}