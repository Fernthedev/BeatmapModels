using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class V2EventCustomData : AbstractV2CustomData, IEventCustomData
{
    public V2EventCustomData(IDictionary<string, JToken?>? unserializedData) : base(unserializedData)
    {
    }

    public V2EventCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }


    public override IBeatmapJSON Clone() => ShallowClone();

    public override ICustomData ShallowClone()
    {
        return new V2EventCustomData(this);
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }

    
    public Color? Color
    {
        get => this["_color"]?.AsColor();
        set => this["_color"] = value == null ? JValue.CreateNull() : new JArray(value.Value.r, value.Value.g, value.Value.b, value.Value.a);
    }

    public IReadOnlySet<int>? LightIDs
    {
        get => this["_lightId"]?.ToObject<IReadOnlySet<int>>();
        set => this["_lightId"] = value == null ? JValue.CreateNull() : JObject.FromObject(value);
    }

    public ChromaGradient? LightGradient
    {
        get => this["_lightGradient"]?.ToObject<ChromaGradient>();
        set => this["_lightGradient"] = value == null ? JValue.CreateNull() : JObject.FromObject(value);
    }
}

