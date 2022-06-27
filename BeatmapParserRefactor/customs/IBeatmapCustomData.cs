public interface IBeatmapCustomData : ICustomData
{
    IList<ICustomEvent>? CustomEvents { get; }
}