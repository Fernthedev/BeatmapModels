using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
///     An item that is stored in a beatmap JSON
/// </summary>
public interface IBeatmapJSON
{
    [JsonIgnore] bool isV3 { get; }

    [JsonExtensionData] IDictionary<string, JToken> UnserializedData { get; }

    IBeatmapJSON Clone();
}


public interface IBeatmapCustomJSON : IBeatmapJSON
{
    [JsonIgnore] ICustomData? UntypedCustomData { get; set; }
}

public interface IBeatmapItem : IBeatmapJSON, IComparable<IBeatmapItem>
{
    float Time { get; set; }
}

public interface ICustomBeatmapItem : IBeatmapItem, IBeatmapCustomJSON
{
}

public interface IBeatmapObject : ICustomBeatmapItem
{
    public int LineIndex { get; set; }
}