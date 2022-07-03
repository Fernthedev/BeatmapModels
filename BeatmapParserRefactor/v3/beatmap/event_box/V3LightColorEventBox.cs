using BeatmapParserRefactor.v3.beatmap.event_box;
using Newtonsoft.Json;

public class V3LightColorEventBox : V3EventBox
{
    [JsonProperty("r")]
    public float BrightnessDistributionParam { get; set; }

    [JsonProperty("t")]
    public DistributionParamType BrightnessDistributionParamType { get; set; }

    [JsonProperty("b")]
    public int BrightnessDistributionShouldAffectFirstBaseEventInt { get; set; }

    [JsonIgnore]
    public bool BrightnessDistributionShouldAffectFirstBaseEvent {
        get => BrightnessDistributionShouldAffectFirstBaseEventInt == 1;
        set => BrightnessDistributionShouldAffectFirstBaseEventInt = value ? 1 : 0;
    }


    [JsonProperty("e")]
    public IList<V3LightColorBaseData> LightColorBaseDataList { get; set; }

    public V3LightColorEventBox(V3IndexFilter indexFilter, float beatDistributionParam, DistributionParamType beatDistributionParamType, float brightnessDistributionParam, DistributionParamType brightnessDistributionParamType, bool brightnessDistributionShouldAffectFirstBaseEvent, IList<V3LightColorBaseData> lightColorBaseDataList) : base(indexFilter, beatDistributionParam, beatDistributionParamType)
    {
        BrightnessDistributionParam = brightnessDistributionParam;
        BrightnessDistributionParamType = brightnessDistributionParamType;
        BrightnessDistributionShouldAffectFirstBaseEvent = brightnessDistributionShouldAffectFirstBaseEvent;
        LightColorBaseDataList = lightColorBaseDataList;
    }
}