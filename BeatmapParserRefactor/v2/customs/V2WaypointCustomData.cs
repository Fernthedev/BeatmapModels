using Newtonsoft.Json.Linq;

public class V2WaypointCustomData : V2ObjectCustomData
{
    public V2WaypointCustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2WaypointCustomData(new Dictionary<string, JToken>(UnserializedData));
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}