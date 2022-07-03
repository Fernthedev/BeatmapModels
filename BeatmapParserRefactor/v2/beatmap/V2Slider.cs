using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class V2Slider : V2BeatmapObject<V2SliderCustomData>, ISlider
{
    public V2Slider(IDictionary<string, JToken>? unserializedData, float time, V2SliderCustomData? typedCustomData, int lineIndex, int type, int cutDirection, int lineLayer, int colorType, float headTime, int headLineIndex, int headLineLayer, float headControlPointLengthMultiplier, int headCutDirection, float tailTime, int tailLineIndex, int tailLineLayer, float tailControlPointLengthMultiplier, int tailCutDirection, int sliderMidAnchorMode) : base(unserializedData, time, typedCustomData, lineIndex)
    {
        Type = type;
        CutDirection = cutDirection;
        LineLayer = lineLayer;
        ColorType = colorType;
        HeadTime = headTime;
        HeadLineIndex = headLineIndex;
        HeadLineLayer = headLineLayer;
        HeadControlPointLengthMultiplier = headControlPointLengthMultiplier;
        HeadCutDirection = headCutDirection;
        TailTime = tailTime;
        TailLineIndex = tailLineIndex;
        TailLineLayer = tailLineLayer;
        TailControlPointLengthMultiplier = tailControlPointLengthMultiplier;
        TailCutDirection = tailCutDirection;
        SliderMidAnchorMode = sliderMidAnchorMode;
    }

    [JsonProperty("_type")]
    public int Type
    {
        get;
        set;
    }

    [JsonProperty("_cutDirection")]
    public int CutDirection
    {
        get;
        set;
    }

    [JsonProperty("_lineLayer")]
    public int LineLayer
    {
        get;
        set;
    }

    public override IBeatmapJSON Clone()
    {
        return new V2Slider(new Dictionary<string, JToken>(UnserializedData), Time,
            TypedCustomData?.Clone() as V2SliderCustomData, LineIndex, Type, CutDirection, LineLayer, ColorType, HeadTime,
            HeadLineIndex,
            HeadLineLayer, HeadControlPointLengthMultiplier, HeadCutDirection, TailTime, TailLineIndex, TailLineLayer,
            TailControlPointLengthMultiplier, TailCutDirection, SliderMidAnchorMode);
    }

    [JsonProperty("_colorType")]
    public int ColorType
    {
        get;
        set;
    }

    [JsonProperty("_headTime")]
    public float HeadTime
    {
        get;
        set;
    }

    [JsonProperty("_headLineIndex")]
    public int HeadLineIndex
    {
        get;
        set;
    }

    [JsonProperty("_headLineLayer")]
    public int HeadLineLayer
    {
        get;
        set;
    }

    [JsonProperty("_headControlPointLengthMultiplier")]
    public float HeadControlPointLengthMultiplier
    {
        get;
        set;
    }

    [JsonProperty("_headCutDirection")]
    public int HeadCutDirection
    {
        get;
        set;
    }

    [JsonProperty("_tailTime")]
    public float TailTime
    {
        get;
        set;
    }

    [JsonProperty("_tailLineIndex")]
    public int TailLineIndex
    {
        get;
        set;
    }

    [JsonProperty("_tailLineLayer")]
    public int TailLineLayer
    {
        get;
        set;
    }

    [JsonProperty("_tailControlPointLengthMultiplier")]
    public float TailControlPointLengthMultiplier
    {
        get;
        set;
    }

    [JsonProperty("_tailCutDirection")]
    public int TailCutDirection
    {
        get;
        set;
    }

    [JsonProperty("_sliderMidAnchorMode")]
    public int SliderMidAnchorMode
    {
        get;
        set;
    }
}