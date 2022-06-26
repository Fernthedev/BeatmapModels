
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class AbstractV2CustomData : AbstractCustomData, ICustomData
{
    public override bool isV3 => false;

    public AbstractV2CustomData(IDictionary<string, JToken?>? unserializedData): base(unserializedData ?? new Dictionary<string, JToken?>()) {}

    protected AbstractV2CustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }
}

