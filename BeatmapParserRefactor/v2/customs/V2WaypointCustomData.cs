using Newtonsoft.Json.Linq;

public class V2WaypointCustomData : V2ObjectCustomData
{
    public V2WaypointCustomData(IDictionary<string, JToken?>? unserializedData) : base(unserializedData)
    {
    }

    public V2WaypointCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2WaypointCustomData(this);
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}