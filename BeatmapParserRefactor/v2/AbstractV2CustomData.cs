
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class AbstractV2CustomData : AbstractCustomData, ICustomData
{
    public override bool isV3 => false;

    public AbstractV2CustomData(IDictionary<string, JToken> unserializedData) => UnserializedData = unserializedData;

    [JsonExtensionData]
    public IDictionary<string, JToken> UnserializedData { get; }
}

