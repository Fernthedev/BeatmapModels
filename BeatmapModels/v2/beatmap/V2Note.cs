using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2Note : V2BeatmapObject<V2NoteCustomData>, INote, IBomb
{
    public V2Note(IDictionary<string, JToken>? unserializedData, float time, V2NoteCustomData? typedCustomData,
        int lineIndex, int type, int cutDirection, int lineLayer) : base(unserializedData, time, typedCustomData,
        lineIndex)
    {
        Type = type;
        CutDirection = cutDirection;
        LineLayer = lineLayer;
    }

    public override IBeatmapJSON Clone()
    {
        return new V2Note(new Dictionary<string, JToken>(UnserializedData), Time,
            TypedCustomData?.Clone() as V2NoteCustomData, LineIndex, Type, CutDirection, LineLayer);
    }

    [JsonProperty("_type")]
    public int Type { get; set; }

    [JsonProperty("_cutDirection")]
    public int CutDirection { get; set; }

    [JsonProperty("_lineLayer")]
    public int LineLayer { get; set; }

    [JsonIgnore]
    public INoteCustomData? CustomData
    {
        get => TypedCustomData;
        set => TypedCustomData = CustomDataWrap(value);
    }
}