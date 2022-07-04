// The amount of interfaces used here feels so wrong
// and yet it feels so right


using System.Collections.Generic;

public interface IBeatmap : IBeatmapCustomJSON
{
    string? Version { get; set; }
    public bool UseNormalEventsAsCompatibleEvents { get; set; }

    IList<INote> Notes { get; set; }

    // On v2 this WILL copy the list with only bombs
    IList<IBomb> Bombs { get; set; }

    // v2 returns all events
    // on v3, this will return ONLY basic events
    IList<IBasicEvent> BasicEvents { get; set; }
    IList<IObstacle> Obstacles { get; set; }
    IList<IWaypoint> Waypoints { get; set; }

    IBeatmapCustomData? BeatmapCustomData { get; set; }

    // TODO: The rest
}

public interface IBomb : IBeatmapObject
{
    public int LineLayer { get; set; }

    public INoteCustomData? CustomData { get; set; }
}

public interface INote : IBeatmapObject
{
    public int Type { get; set; }

    public int CutDirection { get; set; }
    public int LineLayer { get; set; }
    public INoteCustomData? CustomData { get; set; }
}

public interface IObstacle : IBeatmapObject
{
    public int Type { get; set; }

    public float Duration { get; set; }

    public int Width { get; set; }

    public IObstacleCustomData? CustomData { get; set; }
}

public interface IBasicEvent : ICustomBeatmapItem
{
    public BeatmapEventType Type { get; set; }

    public int Value { get; set; }

    public float? FloatValue { get; set; }

    public IEventCustomData? CustomData { get; set; }
}

public interface ISlider : ICustomBeatmapItem
{
    public int ColorType { get; set; }
    public float HeadTime { get; set; }
    public int HeadLineIndex { get; set; }
    public int HeadLineLayer { get; set; }
    public float HeadControlPointLengthMultiplier { get; set; }
    public int HeadCutDirection { get; set; }

    public float TailTime { get; set; }
    public int TailLineIndex { get; set; }
    public int TailLineLayer { get; set; }
    public float TailControlPointLengthMultiplier { get; set; }
    public int TailCutDirection { get; set; }
    public int SliderMidAnchorMode { get; set; }
}

public interface IWaypoint : IBeatmapObject
{
    public int LineLayer { get; set; }
    public int OffsetDirection { get; set; }

    public IObjectCustomData? CustomData { get; set; }
}

public interface ICustomEvent : ICustomBeatmapItem
{
    public string Type { get; set; }

    public ICustomEventCustomData? CustomData { get; set; }
}