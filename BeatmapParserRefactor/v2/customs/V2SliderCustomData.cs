using Newtonsoft.Json.Linq;

public class V2SliderCustomData : V2ObjectCustomData, ICustomData
{
    public V2SliderCustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2SliderCustomData(new Dictionary<string, JToken>(UnserializedData));
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}