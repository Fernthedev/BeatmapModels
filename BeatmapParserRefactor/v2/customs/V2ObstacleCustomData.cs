using Newtonsoft.Json.Linq;

public class V2ObstacleCustomData : V2ObjectCustomData, IObstacleCustomData
{
    public V2ObstacleCustomData(IDictionary<string, JToken?>? unserializedData) : base(unserializedData)
    {
    }

    public V2ObstacleCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }


    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2ObstacleCustomData(this);
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}