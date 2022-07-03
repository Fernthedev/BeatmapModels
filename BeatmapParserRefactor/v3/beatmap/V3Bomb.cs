using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V3Bomb : V3BeatmapObject<V3NoteCustomData>, IBomb
{
    public V3Bomb(IDictionary<string, JToken>? unserializedData, float time, V3NoteCustomData? typedCustomData, int lineIndex, int lineLayer) : base(unserializedData, time, typedCustomData, lineIndex, lineLayer)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return new V3Bomb(new Dictionary<string, JToken>(UnserializedData), Time,
            TypedCustomData?.Clone() as V3NoteCustomData, LineIndex, LineLayer);
    }

    [JsonIgnore]
    public INoteCustomData? CustomData
    {
        get => TypedCustomData;
        set => TypedCustomData = CustomDataWrap(value);
    }
}