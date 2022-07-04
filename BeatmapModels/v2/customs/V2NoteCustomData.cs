using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2NoteCustomData : V2ObjectCustomData, INoteCustomData
{
    public V2NoteCustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2NoteCustomData(new Dictionary<string, JToken>(UnserializedData));
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}