using Newtonsoft.Json.Linq;

public abstract class AbstractV3CustomData : AbstractCustomData, ICustomData
{
    protected AbstractV3CustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }

    public override bool isV3 => false;
}