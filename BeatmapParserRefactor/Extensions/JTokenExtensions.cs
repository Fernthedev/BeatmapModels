using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using UnityEngine;


[PublicAPI]
public static class JTokenExtensions
{
    public static Vector3 AsVector3(this JToken jToken)
    {
        var values = jToken.Values<float>().ToArray();

        if (values.Length < 3) throw new InvalidOperationException($"Expected array size: 3 got {values.Length}");

        return new Vector3(values[0], values[1], values[2]);
    }

    public static Vector2 AsVector2(this JToken jToken)
    {
        var values = jToken.Values<float>().ToArray();

        if (values.Length < 2) throw new InvalidOperationException($"Expected array size: 3 got {values.Length}");

        return new Vector2(values[0], values[1]);
    }

    public static Color AsColor(this JToken jToken, bool omitAlpha = true)
    {
        var values = jToken.Values<float>().ToArray();

        if (values.Length < 3) throw new InvalidOperationException($"Expected array size: 3 got {values.Length}");

        return new Color(values[0], values[1], values[2], !omitAlpha && values.Length >= 4 ? values[3] : 0);
    }

    public static Quaternion AsQuaternion(this JToken jToken)
    {
        var values = jToken.Values<float>().ToArray();

        if (values.Length < 3) throw new InvalidOperationException($"Expected array size: 4 got {values.Length}");

        return new Quaternion(values[0], values[1], values[2], values[3]);
    }

    public static Quaternion AsQuaternionEuler(this JToken jToken)
    {
        var values = jToken.Values<float>().ToArray();

        if (values.Length < 3) throw new InvalidOperationException($"Expected array size: 4 got {values.Length}");

        return Quaternion.Euler(jToken.AsVector3());
    }
}
