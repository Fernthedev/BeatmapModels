using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3Beatmap : IBeatmap
{
    public V3Beatmap(string? version, bool useNormalEventsAsCompatibleEvents, IList<V3BpmChangeEventData> bpmEvents,
        IList<V3RotationEventData> rotationEvents, IList<IBasicEvent> basicEvents,
        IList<V3ColorBoostEvent> colorBoostBeatmapEvents, IList<V3LightColorEventBoxGroup> lightColorEventBoxGroups,
        IList<V3LightRotationEventBoxGroup> lightRotationEventBoxGroups, IList<V3BurstSliderData> burstSliders,
        IList<V3SliderData> sliders, IList<INote> notes, IList<IBomb> bombs, IList<IObstacle> obstacles,
        IList<IWaypoint> waypoints, IBeatmapCustomData? beatmapCustomData, IDictionary<string, JToken>? unserializedData)
    {
        Version = version;
        UseNormalEventsAsCompatibleEvents = useNormalEventsAsCompatibleEvents;
        BpmEvents = bpmEvents;
        RotationEvents = rotationEvents;
        BasicEvents = basicEvents;
        ColorBoostBeatmapEvents = colorBoostBeatmapEvents;
        LightColorEventBoxGroups = lightColorEventBoxGroups;
        LightRotationEventBoxGroups = lightRotationEventBoxGroups;
        BurstSliders = burstSliders;
        Sliders = sliders;
        Notes = notes;
        Bombs = bombs;
        Obstacles = obstacles;
        Waypoints = waypoints;
        BeatmapCustomData = beatmapCustomData;
        UnserializedData = unserializedData ?? new Dictionary<string, JToken>();
    }

    [JsonProperty("version")] 
    public string? Version { get; set; }

    [JsonProperty("useNormalEventsAsCompatibleEvents")]
    public bool UseNormalEventsAsCompatibleEvents { get; set; }
    
    // public IList<IEvent> Events
    // {
        // // TODO: Separate into BasicEvents, BPM, Rotation and ColorBoost events IF applicable
        // get => BasicEvents.Union<IEvent>(ColorBoostBeatmapEvents).Union(BpmEvents).Union(RotationEvents).ToList();
        // set => throw
        //     // TODO: Separate into BasicEvents and ColorBoost events IF applicable
        //     new InvalidOperationException();
    // }
    
    [JsonProperty("bpmEvents")] 
    public IList<V3BpmChangeEventData> BpmEvents { get; }

    [JsonProperty("rotationEvents")] 
    public IList<V3RotationEventData> RotationEvents { get; }

    [JsonProperty("basicBeatmapEvents")]
    [JsonConverter(typeof(V3BasicEventListConverter))]
    public IList<IBasicEvent> BasicEvents { get; set; }

    [JsonProperty("colorBoostBeatmapEvents")]
    public IList<V3ColorBoostEvent> ColorBoostBeatmapEvents { get; set; }


    [JsonProperty("lightColorEventBoxGroups")]
    public IList<V3LightColorEventBoxGroup> LightColorEventBoxGroups { get; }

    [JsonProperty("lightRotationEventBoxGroups")]
    public IList<V3LightRotationEventBoxGroup> LightRotationEventBoxGroups { get; }


    [JsonProperty("burstSliders")]
    public IList<V3BurstSliderData> BurstSliders { get; set; }
    
    [JsonProperty("sliders")]
    public IList<V3SliderData> Sliders { get; set; }

    [JsonProperty("colorNotes")]
    [JsonConverter(typeof(V3NoteListConverter))]
    public IList<INote> Notes { get; set; }


    [JsonProperty("bombNotes")]
    [JsonConverter(typeof(V3BombListConverter))]
    public IList<IBomb> Bombs { get; set; }

    [JsonProperty("obstacles")]
    [JsonConverter(typeof(V3ObstacleListConverter))]
    public IList<IObstacle> Obstacles { get; set; }

    [JsonConverter(typeof(V3WaypointListConverter))]
    [JsonProperty("waypoints")]
    public IList<IWaypoint> Waypoints { get; set; }


    


    [JsonProperty("customData")]
    [TypeConverter(typeof(V3BeatmapCustomData))]
    [JsonConverter(typeof(ConcreteConverter<V3BeatmapCustomData>))]
    public IBeatmapCustomData? BeatmapCustomData { get; set; }

    [JsonIgnore]
    public ICustomData? UntypedCustomData
    {
        get => BeatmapCustomData;
        set => BeatmapCustomData = value is null
            ? null
            : value as V3BeatmapCustomData ??
              throw new InvalidCastException(
                  $"Expected type {typeof(V3BeatmapCustomData)}, got type {value.GetType()}");
    }
    
    [JsonExtensionData] 
    public IDictionary<string, JToken> UnserializedData { get; }
    
    public bool isV3 => true;

    public IBeatmapJSON Clone()
    {
        return new V3Beatmap(Version, UseNormalEventsAsCompatibleEvents,
            BpmEvents, RotationEvents, BasicEvents, ColorBoostBeatmapEvents, LightColorEventBoxGroups,
            LightRotationEventBoxGroups, BurstSliders.ToList(), Sliders.ToList(), Notes.ToList(), Bombs.ToList(), Obstacles.ToList(), Waypoints.ToList(),
            UntypedCustomData?.Clone() as V3BeatmapCustomData, new Dictionary<string, JToken>(UnserializedData));
    }
}