using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class V2EventCustomData : AbstractV2CustomData, IEventCustomData
{
    public V2EventCustomData(IDictionary<string, JToken>? dictionary, Color? color, IReadOnlySet<int>? lightIDs, ChromaGradient? lightGradient) : base(dictionary)
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
    public Color? Color
    {
        get;
        set;
    }

    public IReadOnlySet<int>? LightIDs
    {
        get;
        set;
    }

    public ChromaGradient? LightGradient
    {
        get;
        set;
    }
}