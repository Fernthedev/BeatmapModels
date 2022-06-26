
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2CustomEventCustomData : AbstractV2CustomData, ICustomEventCustomData
{
    public V2CustomEventCustomData(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }

    public override IBeatmapJSON Clone() => new V2CustomEventCustomData(new Dictionary<string, JToken>(UnserializedData));
}

