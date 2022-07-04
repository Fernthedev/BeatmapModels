using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V2ObstacleCustomData : V2ObjectCustomData, IObstacleCustomData
{
    public V2ObstacleCustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }


    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V2ObstacleCustomData(new Dictionary<string, JToken>(UnserializedData));
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}