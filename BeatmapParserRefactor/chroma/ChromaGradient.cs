using System;
using System.ComponentModel;
using Newtonsoft.Json;
using UnityEngine;

// TODO: Make this a dynamically grabbed object
public class ChromaGradient : ICloneable
{
    [JsonProperty("_duration")]
    [DefaultValue(0)]
    public readonly float Duration;

    [JsonProperty("_startColor")]
    [JsonRequired]
    public readonly Color StartColor;

    [JsonProperty("_endColor")]
    [JsonRequired]
    public readonly Color EndColor;

    [JsonProperty("_easing")]
    [DefaultValue("easeLinear")]
    public readonly string EasingType;

    [JsonConstructor]
    public ChromaGradient(Color startColor, Color endColor, float duration, string easingType)
    {
        StartColor = startColor;
        EndColor = endColor;
        Duration = duration;
        EasingType = easingType;
    }

    public ChromaGradient Clone() => new ChromaGradient(StartColor, EndColor, Duration, EasingType);

    object ICloneable.Clone() => Clone();
}
