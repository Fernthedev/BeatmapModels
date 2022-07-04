using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class V3EventCustomData : AbstractV3CustomData, IEventCustomData
{
    public V3EventCustomData(IDictionary<string, JToken>? dictionary, Color? color, IReadOnlyList<int>? lightIDs) : base(dictionary)
    {
        Color = color;
        LightIDs = lightIDs;
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V3EventCustomData(new Dictionary<string, JToken>(UnserializedData), Color, LightIDs);
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }

    [JsonProperty("color")]
    [JsonConverter(typeof(ColorConverter))]
    public Color? Color
    {
        get;
        set;
    }

    [JsonProperty("lightIds")]
    public IReadOnlyList<int>? LightIDs
    {
        get;
        set;
    }
}