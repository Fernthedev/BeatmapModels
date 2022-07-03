using Newtonsoft.Json.Linq;

public abstract class V3ObjectCustomData : AbstractV3CustomData, IObjectCustomData
{
    protected V3ObjectCustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }
}