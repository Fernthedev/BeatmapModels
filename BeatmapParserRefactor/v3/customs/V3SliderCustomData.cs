using Newtonsoft.Json.Linq;

public class V3SliderCustomData : V3ObjectCustomData, ICustomData
{
    public V3SliderCustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V3SliderCustomData(new Dictionary<string, JToken>(UnserializedData));
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}