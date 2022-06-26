
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public class V2ListConverter<I, T> : JsonConverter<IList<I>>
    where I : IBeatmapJSON 
    where T : class, I

{
    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, IList<I> value, JsonSerializer serializer) => throw new NotImplementedException();

    public override IList<I> ReadJson(JsonReader reader, Type objectType, IList<I> existingValue, bool hasExistingValue,
        JsonSerializer serializer) =>
        serializer.Deserialize<List<T>>(reader)?.Cast<I>().ToList();
}

public class V2NoteListConverter : V2ListConverter<INote, V2Note> { }
public class V2ObstacleListConverter : V2ListConverter<IObstacle, V2Obstacle> { }
public class V2EventListConverter : V2ListConverter<IEvent, V2Event> { }
public class V2CustomEventListConverter : V2ListConverter<ICustomEvent, V2CustomEvent> { }
public class V2SliderListConverter : V2ListConverter<ISlider, V2Slider> { }
public class V2WaypointListConverter : V2ListConverter<IWaypoint, V2Waypoint> { }
