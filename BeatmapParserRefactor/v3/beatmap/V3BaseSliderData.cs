using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class V3BaseSliderData : V3BeatmapItem
{
    [JsonProperty("c")]
    public V3NoteColorType ColorType { get; set; }

    [JsonProperty("x")]
    public int HeadLine { get; set; }

    [JsonProperty("y")]
    public int HeadLayer { get; set; }

    [JsonProperty("d")]
    public NoteCutDirection HeadCutDirection { get; set; }

    [JsonProperty("tb")]
    public float TailBeat { get; set; }

    [JsonProperty("tx")]
    public int TailLine { get; set; }

    [JsonProperty("ty")]
    public int TailLayer { get; set; }

    protected V3BaseSliderData(IDictionary<string, JToken>? unserializedData, float time, V3NoteColorType colorType, int headLine, int headLayer, NoteCutDirection headCutDirection, float tailBeat, int tailLine, int tailLayer) : base(unserializedData, time)
    {
        ColorType = colorType;
        HeadLine = headLine;
        HeadLayer = headLayer;
        HeadCutDirection = headCutDirection;
        TailBeat = tailBeat;
        TailLine = tailLine;
        TailLayer = tailLayer;
    }
}