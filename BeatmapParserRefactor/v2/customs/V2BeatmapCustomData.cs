using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2BeatmapCustomData : AbstractV2CustomData, IBeatmapCustomData
{
    public V2BeatmapCustomData(IDictionary<string, JToken?>? unserializedData, IReadOnlyList<ICustomEvent>? customEvents) :
        base(unserializedData)
    {
        CustomEvents = customEvents;
    }

    [JsonConstructor]
    public V2BeatmapCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
        // CustomEvents = this["_customEvents"]?.ToObject<IEnumerable<V2CustomEvent>>()?.Cast<ICustomEvent>().ToList();
    }


    public IReadOnlyList<ICustomEvent>? CustomEvents
    {
        get => this["_customEvents"]?.ToObject<IEnumerable<V2CustomEvent>>()?.Cast<ICustomEvent>().ToList();
        set => this["_customEvents"] = value == null ? JValue.CreateNull() : JArray.FromObject(value);
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2BeatmapCustomData(this, CustomEvents?.ToList());
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}