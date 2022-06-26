using System.Collections.Generic;

public interface IBeatmapCustomData : ICustomData
{

    IList<ICustomEvent>? CustomEvents { get; }
    
    

}

