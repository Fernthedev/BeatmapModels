
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class V2EventCustomData : AbstractV2CustomData, IEventCustomData
{


    public override IBeatmapJSON Clone() => ShallowClone();
    public override ICustomData ShallowClone()
    {
        return new V2EventCustomData(this);
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }

    public Color? Color { get; set; }
    public IList<int> LightIDs { get; set; }
    public ChromaGradient LightGadient { get; set; }

    public V2EventCustomData(IDictionary<string, JToken?>? unserializedData) : base(unserializedData)
    {
    }

    public V2EventCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }
}

