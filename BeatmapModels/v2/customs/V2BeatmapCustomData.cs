using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2BeatmapCustomData : AbstractV2CustomData, IBeatmapCustomData
{
    [JsonConstructor]
    public V2BeatmapCustomData(IDictionary<string, JToken>? dictionary, IReadOnlyList<ICustomEvent>? customEvents) : base(dictionary)
    {
        CustomEvents = customEvents;
    }


    [JsonProperty("_customEvents")]
    [JsonConverter(typeof(V2CustomEventListConverter))]
    public IReadOnlyList<ICustomEvent>? CustomEvents
    {
        get;
        set;
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2BeatmapCustomData(new Dictionary<string, JToken>(UnserializedData), CustomEvents?.ToList());
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}