using System.Collections.Generic;

public interface IBeatmapCustomData : ICustomData
{
    // TODO: POINT DEFS
    // TODO: ENV ENHANCEMENTS
    
    IReadOnlyList<ICustomEvent>? CustomEvents { get; set; }
}