using Newtonsoft.Json;

public class ConcreteConverter<T> : JsonConverter<T> where T : class
{
    public override T? ReadJson(JsonReader reader, Type objectType, T? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        return serializer.Deserialize<T>(reader);
    }

    public override void WriteJson(JsonWriter writer, T? value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}