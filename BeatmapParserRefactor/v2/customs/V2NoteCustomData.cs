
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2NoteCustomData : V2ObjectCustomData, INoteCustomData
{
    public V2NoteCustomData(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }

    public override IBeatmapJSON Clone() => new V2NoteCustomData(new Dictionary<string, JToken>(UnserializedData));
}

