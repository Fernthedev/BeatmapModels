using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public class V3ListConverter<I, T> : JsonConverter<IList<I>>
    where I : IBeatmapJSON
    where T : class, I

{
    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, IList<I>? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override IList<I>? ReadJson(JsonReader reader, Type objectType, IList<I>? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        return serializer.Deserialize<List<T>>(reader)?.ToList<I>();
    }
}

public class V3NoteListConverter : V3ListConverter<INote, V3Note>
{
}

public class V3BombListConverter : V3ListConverter<IBomb, V3Bomb>
{
}

public class V3ObstacleListConverter : V3ListConverter<IObstacle, V3Obstacle>
{
}

public class V3BasicEventListConverter : V3ListConverter<IBasicEvent, V3BasicEvent>
{
}


public class V3CustomEventListConverter : V3ListConverter<ICustomEvent, V3CustomEvent>
{
}

public class V3WaypointListConverter : V3ListConverter<IWaypoint, V3Waypoint>
{
}