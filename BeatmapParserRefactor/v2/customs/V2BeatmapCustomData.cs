using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2BeatmapCustomData : AbstractV2CustomData, IBeatmapCustomData
{
    [JsonConstructor]
    public V2BeatmapCustomData([NotNull] IDictionary<string, JToken> dictionary, IList<ICustomEvent> customEvents) : base(dictionary) => CustomEvents = customEvents;

    public V2BeatmapCustomData([NotNull] IDictionary<string, JToken> dictionary) : base(dictionary) => CustomEvents = dictionary["_customEvents"]?.ToObject<List<V2CustomEvent>>()?.Cast<ICustomEvent>().ToList();

    
    [JsonProperty("_customEvents")]
    [JsonConverter(typeof(V2CustomEventListConverter))]
    public IList<ICustomEvent>? CustomEvents
    {
        get;
    }

    public override IBeatmapJSON Clone() => new V2BeatmapCustomData(new Dictionary<string, JToken>(UnserializedData), CustomEvents.ToList());


    public ICustomData ShallowClone() => throw new System.NotImplementedException();

    public ICustomData DeepCopy() => throw new System.NotImplementedException();
}
