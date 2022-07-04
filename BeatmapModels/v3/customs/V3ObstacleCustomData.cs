using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class V3ObstacleCustomData : V3ObjectCustomData, IObstacleCustomData
{
    public V3ObstacleCustomData(IDictionary<string, JToken>? dictionary) : base(dictionary)
    {
    }


    public override IBeatmapJSON Clone()
    {
        return ShallowClone();
    }

    public override ICustomData ShallowClone()
    {
        return new V3ObstacleCustomData(new Dictionary<string, JToken>(UnserializedData));
    }

    public override ICustomData DeepCopy()
    {
        throw new NotImplementedException();
    }
}