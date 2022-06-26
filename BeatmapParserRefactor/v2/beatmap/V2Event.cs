
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2Event : V2CustomBeatmapItem<V2EventCustomData>, IEvent
{
    public V2Event(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }

    public override IBeatmapJSON Clone() => new V2Event(new Dictionary<string, JToken>(UnserializedData));

    public int Type
    {
        get => UnserializedData["_type"].ToObject<int>();
        set => UnserializedData["_type"] = value;
    }

    public int Value
    {
        get => UnserializedData["_value"].ToObject<int>();
        set => UnserializedData["_value"] = value;
    }

    public float? FloatValue
    {
        get => UnserializedData["_floatValue"].ToObject<float>();
        set => UnserializedData["_floatValue"] = value;
    }

    public IEventCustomData CustomData { get => TypedCustomData; set => SetCustomData(value); }
}

