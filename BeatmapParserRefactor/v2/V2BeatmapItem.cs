
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class V2BeatmapItem : IBeatmapItem
{
    [JsonIgnore]
    public bool isV3 => false;
    public abstract IBeatmapJSON Clone();


    public V2BeatmapItem(IDictionary<string, JToken> unserializedData) => UnserializedData = unserializedData;
    
    [JsonExtensionData]
    public IDictionary<string, JToken> UnserializedData { get; }
    
    [JsonIgnore]
    public float Time
    {
        get => UnserializedData["_time"].ToObject<float>();
        set => UnserializedData["_time"] = value;
    }
}

public abstract class V2CustomBeatmapItem<T> : V2BeatmapItem, ICustomBeatmapItem where T: class, ICustomData
{
    public V2CustomBeatmapItem(IDictionary<string, JToken> unserializedData) : base(unserializedData) {}

    // For whatever reason 
    [CanBeNull]
    [JsonIgnore]
    public T TypedCustomData 
    {
        get => UnserializedData["_customData"]?.ToObject<T>();
        set => SetCustomData(value);
    }

    [JsonIgnore]
    public ICustomData UntypedCustomData
    {
        get => TypedCustomData;
        set => SetCustomData(value);
    }

    protected void SetCustomData([CanBeNull] ICustomData customData)
    {
        if (customData != null)
        {
            UnserializedData["_customData"] = JObject.FromObject(customData.UnserializedData);
        }
        else
        {
            UnserializedData.Remove("_customData");
        }
    }
}
