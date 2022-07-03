using Newtonsoft.Json.Linq;

public class V3CustomEventCustomData : AbstractV3CustomData, ICustomEventCustomData
{
    public V3CustomEventCustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V3CustomEventCustomData(new Dictionary<string, JToken>(UnserializedData));
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}