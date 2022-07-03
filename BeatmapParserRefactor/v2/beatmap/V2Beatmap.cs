using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2Beatmap : IBeatmap
{
    [JsonConstructor]
    public V2Beatmap(IDictionary<string, JToken>? unserializedData, IList<INote> notes, IList<IEvent> events,
        IList<IObstacle> obstacles, IList<IWaypoint> waypoints, IList<ISlider>? sliders,
        IBeatmapCustomData? beatmapCustomData)
    {
        UnserializedData = unserializedData ?? new Dictionary<string, JToken>();
        Notes = notes;
        Events = events;
        Obstacles = obstacles;
        Waypoints = waypoints;
        Sliders = sliders;
        BeatmapCustomData = beatmapCustomData;
    }

    public bool isV3 => false;

    public IBeatmapJSON Clone()
    {
        return new V2Beatmap(new Dictionary<string, JToken>(UnserializedData), new List<INote>(Notes),
            new List<IEvent>(Events),
            new List<IObstacle>(Obstacles), new List<IWaypoint>(Waypoints), new List<ISlider>(Sliders),
            UntypedCustomData?.Clone() as V2BeatmapCustomData);
    }

    [JsonExtensionData]
    public IDictionary<string, JToken> UnserializedData { get; }

    [JsonIgnore]
    public ICustomData? UntypedCustomData
    {
        get => BeatmapCustomData;
        set => BeatmapCustomData = value is null
            ? null
            : value as V2BeatmapCustomData ?? throw new InvalidCastException($"Expected type {typeof(V2BeatmapCustomData)}, got type {value.GetType()}");
    }

    [JsonProperty("_notes")]
    [JsonConverter(typeof(V2NoteListConverter))]
    public IList<INote> Notes { get; set; }

    [JsonProperty("_events")]
    [JsonConverter(typeof(V2EventListConverter))]
    public IList<IEvent> Events { get; set; }

    [JsonConverter(typeof(V2ObstacleListConverter))]
    [JsonProperty("_obstacles")]
    public IList<IObstacle> Obstacles { get; set; }

    [JsonConverter(typeof(V2WaypointListConverter))]
    [JsonProperty("_waypoints")]
    public IList<IWaypoint> Waypoints { get; set; }

    [JsonConverter(typeof(V2SliderListConverter))]
    [JsonProperty("_sliders")]
    public IList<ISlider>? Sliders { get; set; }

    [JsonProperty("_customData")]
    [TypeConverter(typeof(V2BeatmapCustomData))]
    [JsonConverter(typeof(ConcreteConverter<V2BeatmapCustomData>))]
    public IBeatmapCustomData? BeatmapCustomData { get; set; }
}