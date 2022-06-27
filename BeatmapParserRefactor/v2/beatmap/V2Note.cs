
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2Note : V2BeatmapObject<V2NoteCustomData>, INote
{
    public V2Note(IDictionary<string, JToken>? unserializedData, float time, V2NoteCustomData? typedCustomData) : base(unserializedData, time, typedCustomData)
    {
    }

    public override IBeatmapJSON Clone() => new V2Note(new Dictionary<string, JToken>(UnserializedData), Time, new V2NoteCustomData(TypedCustomData));

    public int Type
    {
        get => UnserializedData["_type"]!.ToObject<int>();
        set => UnserializedData["_type"] = value;
    }

    public int CutDirection
    {
        get => UnserializedData["_cutDirection"]!.ToObject<int>();
        set => UnserializedData["_cutDirection"] = value;
    }

    public int LineLayer
    {
        get => UnserializedData["_lineLayer"]!.ToObject<int>();
        set => UnserializedData["_lineLayer"] = value;
    }

    public INoteCustomData? CustomData { get => TypedCustomData; set => TypedCustomData = CustomDataWrap(value); }
    protected override V2NoteCustomData Internal_CustomDataWrap(ICustomData data)
    {
        return new V2NoteCustomData(data);
    }
}

