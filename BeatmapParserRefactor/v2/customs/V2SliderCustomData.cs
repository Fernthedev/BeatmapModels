
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2SliderCustomData : V2ObjectCustomData, ICustomData
{
    public V2SliderCustomData(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }

    public override IBeatmapJSON Clone() => new V2SliderCustomData(new Dictionary<string, JToken>(UnserializedData));
}

