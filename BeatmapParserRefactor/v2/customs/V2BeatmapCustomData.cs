using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2BeatmapCustomData : AbstractV2CustomData, IBeatmapCustomData
{

    public V2BeatmapCustomData(IDictionary<string, JToken?>? unserializedData, IList<ICustomEvent>? customEvents) : base(unserializedData) => CustomEvents = customEvents;

    [JsonConstructor]
    public V2BeatmapCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
        CustomEvents = this["_customEvents"]?.ToObject<IEnumerable<V2CustomEvent>>()?.Cast<ICustomEvent>().ToList();
    }

    [JsonProperty("_customEvents")]
    [JsonConverter(typeof(V2CustomEventListConverter))]
    public IList<ICustomEvent>? CustomEvents
    {
        get;
    }

    public override IBeatmapJSON Clone() => ShallowClone();
    public override ICustomData ShallowClone()
    {
        return new V2BeatmapCustomData(this, CustomEvents?.ToList());
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}
