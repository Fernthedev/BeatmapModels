using System.Collections.Generic;
using Newtonsoft.Json;

public class V3LightRotationEventBox : V3EventBox
{
    public V3LightRotationEventBox(V3IndexFilter indexFilter, float beatDistributionParam,
        DistributionParamType beatDistributionParamType, float rotationDistributionParam,
        DistributionParamType rotationDistributionParamType, V3Axis axis, bool flipRotation,
        bool rotationDistributionShouldAffectFirstBaseEvent, IList<V3LightRotationBaseData> lightRotationBaseDataList) :
        base(indexFilter, beatDistributionParam, beatDistributionParamType)
    {
        RotationDistributionParam = rotationDistributionParam;
        RotationDistributionParamType = rotationDistributionParamType;
        Axis = axis;
        FlipRotation = flipRotation;
        RotationDistributionShouldAffectFirstBaseEvent = rotationDistributionShouldAffectFirstBaseEvent;
        LightRotationBaseDataList = lightRotationBaseDataList;
    }

    [JsonProperty("s")]
    public float RotationDistributionParam { get; set; }

    [JsonProperty("t")]
    public DistributionParamType RotationDistributionParamType { get; set; }

    [JsonProperty("a")]
    public V3Axis Axis { get; set; }

    [JsonProperty("r")]
    public int FlipRotationInt { get; set; }

    [JsonIgnore]
    public bool FlipRotation
    {
        get => FlipRotationInt == 1;
        set => FlipRotationInt = value ? 1 : 0;
    }

    [JsonProperty("b")]
    public int RotationDistributionShouldAffectFirstBaseEventInt { get; set; }

    [JsonIgnore]
    public bool RotationDistributionShouldAffectFirstBaseEvent
    {
        get => RotationDistributionShouldAffectFirstBaseEventInt == 1;
        set => RotationDistributionShouldAffectFirstBaseEventInt = value ? 1 : 0;
    }


    [JsonProperty("l")]
    public IList<V3LightRotationBaseData> LightRotationBaseDataList { get; set; }
}