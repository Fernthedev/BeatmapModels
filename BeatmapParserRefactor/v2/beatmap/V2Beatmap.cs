using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2Beatmap : IBeatmap
{
    [JsonConstructor]
    public V2Beatmap(IDictionary<string, JToken>? unserializedData, string? version, IList<INote> notes, IList<IBasicEvent> events, IList<IObstacle> obstacles, IList<IWaypoint> waypoints, IList<ISlider>? sliders, IBeatmapCustomData? beatmapCustomData)
    {
        UnserializedData = unserializedData ?? new Dictionary<string, JToken>();
        Version = version;
        Notes = notes;
        BasicEvents = events;
        Obstacles = obstacles;
        Waypoints = waypoints;
        Sliders = sliders;
        BeatmapCustomData = beatmapCustomData;
    }

    public bool isV3 => false;

    public IBeatmapJSON Clone()
    {
        return new V2Beatmap(new Dictionary<string, JToken>(UnserializedData), Version, new List<INote>(Notes),
            new List<IBasicEvent>(BasicEvents),
            new List<IObstacle>(Obstacles), new List<IWaypoint>(Waypoints), Sliders?.ToList(),
            UntypedCustomData?.Clone() as V2BeatmapCustomData);
    }

    [JsonExtensionData] public IDictionary<string, JToken> UnserializedData { get; }

    [JsonIgnore]
    public ICustomData? UntypedCustomData
    {
        get => BeatmapCustomData;
        set => BeatmapCustomData = value is null
            ? null
            : value as V2BeatmapCustomData ??
              throw new InvalidCastException(
                  $"Expected type {typeof(V2BeatmapCustomData)}, got type {value.GetType()}");
    }
    
    [JsonProperty("_version")]
    public string? Version { get; set; }

    // TODO: make set not work
    [JsonIgnore]
    public bool UseNormalEventsAsCompatibleEvents { get; set; } = true;

    [JsonProperty("_notes")]
    [JsonConverter(typeof(V2NoteListConverter))]
    public IList<INote> Notes { get; set; }
    
    [JsonIgnore]
    public IList<IBomb> Bombs { get => Notes.Where(e => e.Type == (int)V2NoteType.Bomb).Cast<IBomb>().ToList(); set => Notes = Notes.Where(e => e.Type != (int)V2NoteType.Bomb).Union(value.Cast<INote>()).ToList(); }

    [JsonProperty("_events")]
    [JsonConverter(typeof(V2EventListConverter))]
    public IList<IBasicEvent> BasicEvents { get; set; }

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