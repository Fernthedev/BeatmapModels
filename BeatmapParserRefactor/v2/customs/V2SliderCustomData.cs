
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2SliderCustomData : V2ObjectCustomData, ICustomData
{
    public V2SliderCustomData(IDictionary<string, JToken?>? unserializedData) : base(unserializedData)
    {
    }

    public V2SliderCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }

    public override IBeatmapJSON Clone() => ShallowClone();
    public override ICustomData ShallowClone()
    {
        return new V2SliderCustomData(this);
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}

