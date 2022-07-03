using Newtonsoft.Json;

public class V3IndexFilter
{
    public V3IndexFilter(IndexFilterType type, int param0, int param1, int reversedInt)
    {
        Type = type;
        Param0 = param0;
        Param1 = param1;
        ReversedInt = reversedInt;
    }

    [JsonProperty("f")]
    public IndexFilterType Type { get; set; }

    [JsonProperty("p")]
    public int Param0 { get; set; }

    [JsonProperty("t")]
    public int Param1 { get; set; }

    [JsonProperty("r")]
    public int ReversedInt { get; set; }

    [JsonIgnore]
    public bool Reversed
    {
        get => ReversedInt != 0;
        set => ReversedInt = value ? 1 : 0;
    }

    public enum IndexFilterType
    {
        Division = 1,
        StepAndOffset
    }
}