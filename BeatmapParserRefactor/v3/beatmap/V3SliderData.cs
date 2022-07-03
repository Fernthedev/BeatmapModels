﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeatmapParserRefactor.v3.beatmap;

public class V3SliderData : V3BaseSliderData
{
    [JsonProperty("mu")]
    public float HeadControlPointLengthMultiplier { get; set; }

    [JsonProperty("tmu")]
    public float TailControlPointLengthMultiplier { get; set; }

    [JsonProperty("tc")]
    public NoteCutDirection TailCutDirection { get; set; }

    [JsonProperty("m")]
    public v3SliderMidAnchorMode SliderMidAnchorMode { get; set; }

    public V3SliderData(IDictionary<string, JToken>? unserializedData, float time, V3NoteColorType colorType,
        int headLine, int headLayer, NoteCutDirection headCutDirection, float tailBeat, int tailLine, int tailLayer) :
        base(unserializedData, time, colorType, headLine, headLayer, headCutDirection, tailBeat, tailLine, tailLayer)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return new V3SliderData(UnserializedData, Time, ColorType, HeadLine, HeadLayer, HeadCutDirection, TailBeat,
            TailLine, TailLayer);
    }
}