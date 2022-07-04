using Newtonsoft.Json;

public class V3LightColorBaseData
{
    public V3LightColorBaseData(float beat, V3TransitionType transitionType, V3EnvironmentColorType colorType,
        float brightness, int strobeBeatFrequency)
    {
        Beat = beat;
        TransitionType = transitionType;
        ColorType = colorType;
        Brightness = brightness;
        StrobeBeatFrequency = strobeBeatFrequency;
    }

    [JsonProperty("b")]
    public float Beat { get; set; }

    [JsonProperty("i")]
    public V3TransitionType TransitionType { get; set; }

    [JsonProperty("c")]
    public V3EnvironmentColorType ColorType { get; set; }

    [JsonProperty("s")]
    public float Brightness { get; set; }

    [JsonProperty("f")]
    public int StrobeBeatFrequency { get; set; }
}