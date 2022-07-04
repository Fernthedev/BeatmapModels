using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3Note : V3BeatmapObject<V3NoteCustomData>, INote
{
    public V3Note(IDictionary<string, JToken>? unserializedData, float time, V3NoteCustomData? typedCustomData,
        int lineIndex, int lineLayer, int angleOffset, int type, int cutDirection) : base(unserializedData, time,
        typedCustomData, lineIndex, lineLayer)
    {
        AngleOffset = angleOffset;
        Type = type;
        CutDirection = cutDirection;
    }


    [JsonProperty("a")]
    public int AngleOffset { get; set; }

    [JsonIgnore]
    public V3NoteColorType Color
    {
        get => (V3NoteColorType)Type;
        set => Type = (int)value;
    }

    public override IBeatmapJSON Clone()
    {
        return new V3Note(new Dictionary<string, JToken>(UnserializedData), Time,
            TypedCustomData?.Clone() as V3NoteCustomData, LineIndex, LineLayer, AngleOffset, Type, CutDirection);
    }

    [JsonProperty("c")]
    public int Type { get; set; }

    [JsonProperty("d")]
    public int CutDirection { get; set; }

    [JsonIgnore]
    public INoteCustomData? CustomData
    {
        get => TypedCustomData;
        set => TypedCustomData = CustomDataWrap(value);
    }
}