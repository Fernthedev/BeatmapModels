using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public abstract class V3EventBox
{
    public enum DistributionParamType
    {
        Wave = 1,
        Step
    }

    protected V3EventBox(V3IndexFilter indexFilter, float beatDistributionParam,
        DistributionParamType beatDistributionParamType)
    {
        IndexFilter = indexFilter;
        BeatDistributionParam = beatDistributionParam;
        BeatDistributionParamType = beatDistributionParamType;
    }

    [JsonProperty("f")]
    public V3IndexFilter IndexFilter { get; set; }

    [JsonProperty("w")]
    public float BeatDistributionParam { get; set; }

    [JsonProperty("d")]
    public DistributionParamType BeatDistributionParamType { get; set; }
}

public abstract class V3EventBoxGroup : V3BeatmapItem
{
    protected V3EventBoxGroup(IDictionary<string, JToken>? unserializedData, float time, int groupId) : base(
        unserializedData, time)
    {
        GroupId = groupId;
    }

    [JsonProperty("g")]
    public int GroupId { get; set; }

    [JsonIgnore]
    public abstract IList<V3EventBox> BaseEventBoxes { get; }
}

public abstract class V3EventBoxGroup<T> : V3EventBoxGroup where T : V3EventBox
{
    public V3EventBoxGroup(IDictionary<string, JToken>? unserializedData, float time, int groupId, IList<T> eventBoxes)
        : base(unserializedData, time, groupId)
    {
        EventBoxes = eventBoxes;
    }

    [JsonIgnore]
    public override IList<V3EventBox> BaseEventBoxes => EventBoxes.ToList<V3EventBox>();

    [JsonProperty("e")]
    public IList<T> EventBoxes { get; set; }
}

public class V3LightColorEventBoxGroup : V3EventBoxGroup<V3LightColorEventBox>
{
    public V3LightColorEventBoxGroup(IDictionary<string, JToken>? unserializedData, float time, int groupId,
        IList<V3LightColorEventBox> eventBoxes) : base(unserializedData, time, groupId, eventBoxes)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return new V3LightColorEventBoxGroup(UnserializedData, Time, GroupId, EventBoxes);
    }
}

public class V3LightRotationEventBoxGroup : V3EventBoxGroup<V3LightRotationEventBox>
{
    public V3LightRotationEventBoxGroup(IDictionary<string, JToken>? unserializedData, float time, int groupId,
        IList<V3LightRotationEventBox> eventBoxes) : base(unserializedData, time, groupId, eventBoxes)
    {
    }

    public override IBeatmapJSON Clone()
    {
        return new V3LightRotationEventBoxGroup(UnserializedData, Time, GroupId, EventBoxes);
    }
}