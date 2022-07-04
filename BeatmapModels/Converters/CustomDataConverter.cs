

using System;
using Newtonsoft.Json;
using UnityEngine;

public class ColorConverter : JsonConverter<Color?>
{
    public override void WriteJson(JsonWriter writer, Color? value, JsonSerializer serializer)
    {
        if (value.HasValue)
        {
            var color = value.Value;
            writer.WriteStartArray();
            writer.WriteValue(color.r);
            writer.WriteValue(color.g);
            writer.WriteValue(color.b);
            
            if (Mathf.Abs(color.a - 1f) > 0.0000001f) // don't include redundant float
            {
                writer.WriteValue(color.a);
            }

            writer.WriteEndArray();
        }
        else
        {
            writer.WriteNull();
        }
    }

    public override Color? ReadJson(JsonReader reader, Type objectType, Color? existingValue, bool hasExistingValue, JsonSerializer serializer) {
        if (reader.TokenType is JsonToken.Null || reader.TokenType == JsonToken.None)
        {
            return null;
        }
        if (reader.TokenType != JsonToken.StartArray) throw new JsonException("Expected array in color");


        var r = (float)reader.ReadAsDecimal()!.Value;
        var g = (float)reader.ReadAsDecimal()!.Value;
        var b = (float)reader.ReadAsDecimal()!.Value;

        var a = 1f;

        if (reader.TokenType != JsonToken.EndArray)
        { 
            a = (float?)reader.ReadAsDecimal() ?? 1f;
        }

        // Throw?
        while (reader.TokenType != JsonToken.EndArray) reader.Read();

        return new Color(r, g, b, a);
    }
}