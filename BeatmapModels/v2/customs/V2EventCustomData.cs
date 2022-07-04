using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class V2EventCustomData : AbstractV2CustomData, IEventCustomData
{
    public V2EventCustomData(IDictionary<string, JToken>? dictionary, Color? color, IReadOnlyList<int>? lightIDs,
        ChromaGradient? lightGradient) : base(dictionary)
    {
        Color = color;
        LightIDs = lightIDs;
        LightGradient = lightGradient;
    }
    
    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2EventCustomData(new Dictionary<string, JToken>(UnserializedData), Color, LightIDs, LightGradient);
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }

    [JsonProperty("_color")]
    [JsonConverter(typeof(ColorConverter))]
    public Color? Color { get; set; }

    [JsonProperty("_lightIds")]
    public IReadOnlyList<int>? LightIDs { get; set; }
    
    [JsonProperty("_lightGradient")]
    public ChromaGradient? LightGradient { get; set; }
}