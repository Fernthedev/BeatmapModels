using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3BeatmapCustomData : AbstractV3CustomData, IBeatmapCustomData
{
    [JsonConstructor]
    public V3BeatmapCustomData(IDictionary<string, JToken>? dictionary, IReadOnlyList<ICustomEvent>? customEvents) : base(dictionary)
    {
        CustomEvents = customEvents;
    }


    [JsonProperty("customEvents")]
    [JsonConverter(typeof(V3CustomEventListConverter))]
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
        return new V3BeatmapCustomData(new Dictionary<string, JToken>(UnserializedData), CustomEvents?.ToList());
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}