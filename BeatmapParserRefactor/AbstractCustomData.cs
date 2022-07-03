using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class AbstractCustomData : ICustomData
{
    protected AbstractCustomData(IDictionary<string, JToken>? dictionary)
    {
        UnserializedData = dictionary ?? new Dictionary<string, JToken>();
    }

    [JsonIgnore] 
    public abstract bool isV3 { get; }

    public abstract IBeatmapJSON Clone();

    [JsonExtensionData]
    public IDictionary<string, JToken> UnserializedData
    {
        get;
        set;
    }

    public abstract ICustomData ShallowClone();

    public abstract ICustomData DeepCopy();
}