
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2Slider : V2BeatmapObject<V2SliderCustomData>, ISlider
{
    public V2Slider(IDictionary<string, JToken> unserializedData) : base(unserializedData)
    {
    }

    public override IBeatmapJSON Clone() => new V2Slider(new Dictionary<string, JToken>(UnserializedData));

    public int Type
    {
        get => UnserializedData["_type"].ToObject<int>();
        set => UnserializedData["_type"] = value;
    }

    public int CutDirection
    {
        get => UnserializedData["_cutDirection"].ToObject<int>();
        set => UnserializedData["_cutDirection"] = value;
    }

    public int LineLayer
    {
        get => UnserializedData["_lineLayer"].ToObject<int>();
        set => UnserializedData["_lineLayer"] = value;
    }

    public int ColorType
    {
        get => UnserializedData["_colorType"].ToObject<int>();
        set => UnserializedData["_colorType"] = value;
    }

    public float HeadTime
    {
        get => UnserializedData["_headTime"].ToObject<int>();
        set => UnserializedData["_headTime"] = value;
    }

    public int HeadLineIndex
    {
        get => UnserializedData["_headLineIndex"].ToObject<int>();
        set => UnserializedData["_headLineIndex"] = value;
    }

    public int HeadLineLayer
    {
        get => UnserializedData["_headLineLayer"].ToObject<int>();
        set => UnserializedData["_headLineLayer"] = value;
    }

    public float HeadControlPointLengthMultiplier
    {
        get => UnserializedData["_headControlPointLengthMultiplier"].ToObject<int>();
        set => UnserializedData["_headControlPointLengthMultiplier"] = value;
    }

    public int HeadCutDirection
    {
        get => UnserializedData["_headCutDirection"].ToObject<int>();
        set => UnserializedData["_headCutDirection"] = value;
    }

    public float TailTime
    {
        get => UnserializedData["_tailTime"].ToObject<int>();
        set => UnserializedData["_tailTime"] = value;
    }

    public int TailLineIndex
    {
        get => UnserializedData["_tailLineIndex"].ToObject<int>();
        set => UnserializedData["_tailLineIndex"] = value;
    }

    public int TailLineLayer
    {
        get => UnserializedData["_tailLineLayer"].ToObject<int>();
        set => UnserializedData["_tailLineLayer"] = value;
    }

    public float TailControlPointLengthMultiplier
    {
        get => UnserializedData["_tailControlPointLengthMultiplier"].ToObject<int>();
        set => UnserializedData["_tailControlPointLengthMultiplier"] = value;
    }

    public int TailCutDirection
    {
        get => UnserializedData["_tailCutDirection"].ToObject<int>();
        set => UnserializedData["_tailCutDirection"] = value;
    }

    public int SliderMidAnchorMode
    {
        get => UnserializedData["_sliderMidAnchorMode"].ToObject<int>();
        set => UnserializedData["_sliderMidAnchorMode"] = value;
    }
}

