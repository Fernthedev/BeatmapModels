using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public abstract class AbstractV2CustomData : AbstractCustomData, ICustomData
{
    protected AbstractV2CustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }

    public override bool isV3 => false;
}