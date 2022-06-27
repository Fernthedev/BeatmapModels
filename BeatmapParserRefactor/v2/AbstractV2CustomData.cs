using Newtonsoft.Json.Linq;

public abstract class AbstractV2CustomData : AbstractCustomData, ICustomData
{
    public AbstractV2CustomData(IDictionary<string, JToken?>? unserializedData) : base(unserializedData ??
        new Dictionary<string, JToken?>())
    {
    }

    protected AbstractV2CustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }

    public override bool isV3 => false;
}