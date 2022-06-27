
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2CustomEvent : V2CustomBeatmapItem<V2CustomEventCustomData>, ICustomEvent
{
    public V2CustomEvent(IDictionary<string, JToken>? unserializedData, float time, V2CustomEventCustomData? typedCustomData) : base(unserializedData, time, typedCustomData)
    {
    }

    public override IBeatmapJSON Clone() => new V2CustomEvent(new Dictionary<string, JToken>(UnserializedData), Time, new V2CustomEventCustomData(TypedCustomData));

    public string Type
    {
        get => UnserializedData["_type"].ToObject<string>()!;
        set => UnserializedData["_type"] = value;
    }

    public ICustomEventCustomData? CustomData
    {
        get => TypedCustomData;
        set => CustomDataWrap(value);
    }


    protected override V2CustomEventCustomData Internal_CustomDataWrap(ICustomData data)
    {
        return new V2CustomEventCustomData(data);
    }
}

