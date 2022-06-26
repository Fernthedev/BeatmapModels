
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class V2EventCustomData : AbstractV2CustomData, IEventCustomData
{
    public V2EventCustomData(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }

    public override IBeatmapJSON Clone() => new V2EventCustomData(new Dictionary<string, JToken>(UnserializedData));
    public Color? Color { get; set; }
    public IList<int> LightIDs { get; set; }
    public ChromaGradient LightGadient { get; set; }
}

