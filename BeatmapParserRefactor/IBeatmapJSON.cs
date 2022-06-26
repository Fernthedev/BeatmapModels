using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// An item that is stored in a beatmap JSON
/// </summary>
public interface IBeatmapJSON
{
    [JsonIgnore] bool isV3 { get; }

    IBeatmapJSON Clone();

    [JsonExtensionData] IDictionary<string, JToken> UnserializedData { get; }
}


public interface IBeatmapCustomJSON : IBeatmapJSON
{
    [CanBeNull]
    [JsonIgnore]
    ICustomData UntypedCustomData { get; set; }
}

public interface IBeatmapItem : IBeatmapJSON
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
