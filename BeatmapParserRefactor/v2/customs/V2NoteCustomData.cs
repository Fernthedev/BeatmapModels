using Newtonsoft.Json.Linq;

public class V2NoteCustomData : V2ObjectCustomData, INoteCustomData
{
    public V2NoteCustomData(IDictionary<string, JToken?>? unserializedData) : base(unserializedData)
    {
    }

    public V2NoteCustomData(IEnumerable<KeyValuePair<string, JToken?>> collection) : base(collection)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2NoteCustomData(this);
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}