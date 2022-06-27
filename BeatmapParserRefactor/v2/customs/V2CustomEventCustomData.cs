using Newtonsoft.Json.Linq;

public class V2CustomEventCustomData : AbstractV2CustomData, ICustomEventCustomData
{
    public V2CustomEventCustomData(IDictionary<string, JToken?>? unserializedData) : base(unserializedData)
    {
    }

    public V2CustomEventCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2CustomEventCustomData(this);
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}