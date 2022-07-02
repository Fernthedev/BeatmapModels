public interface IBeatmapCustomData : ICustomData
{
    IReadOnlyList<ICustomEvent>? CustomEvents { get; set; }
}