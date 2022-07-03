using Newtonsoft.Json.Linq;

public class V2CustomEventCustomData : AbstractV2CustomData, ICustomEventCustomData
{
    public V2CustomEventCustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2CustomEventCustomData(new Dictionary<string, JToken>(UnserializedData));
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}