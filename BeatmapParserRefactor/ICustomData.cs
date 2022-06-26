using System.Collections.Generic;
using Newtonsoft.Json.Linq;


public interface ICustomData : IDictionary<string, JToken>, IBeatmapJSON
{
    
    ICustomData ShallowClone();
    ICustomData DeepCopy();

}

