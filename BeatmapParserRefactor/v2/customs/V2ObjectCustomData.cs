using Newtonsoft.Json.Linq;

public abstract class V2ObjectCustomData : AbstractV2CustomData, IObjectCustomData
{
    protected V2ObjectCustomData(IDictionary<string, JToken?>? unserializedData) : base(unserializedData)
    {
    }

    protected V2ObjectCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }
}