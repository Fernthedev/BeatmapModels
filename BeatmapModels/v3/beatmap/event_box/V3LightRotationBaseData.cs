using Newtonsoft.Json;

public class V3LightRotationBaseData
{
	[JsonProperty("b")]
	public float Beat { get; set; }

	[JsonProperty("e")]
	public V3EaseType EaseType { get; set; }

	[JsonProperty("l")]
	public int LoopsCount { get; set; }

	[JsonProperty("r")]
	public float Rotation { get; set; }

	[JsonProperty("o")]
	public RotationDirection Direction { get; set; }

	[JsonProperty("p")]
	public int UsePreviousEventRotationValueInt { get; set; }

	[JsonIgnore]
	public bool UsePreviousEventRotationValue
	{
		get => UsePreviousEventRotationValueInt == 1;
		set => UsePreviousEventRotationValueInt = value ? 1 : 0;
	}

	public enum RotationDirection
	{
		Automatic,
		Clockwise,
		Counterclockwise
	}

	public V3LightRotationBaseData(float beat, V3EaseType easeType, int loopsCount, float rotation, RotationDirection direction)
	{
		Beat = beat;
		EaseType = easeType;
		LoopsCount = loopsCount;
		Rotation = rotation;
		Direction = direction;
	}
}