
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public interface IEventCustomData : ICustomData
{

    Color? Color { get; set; }

    [CanBeNull]
    IList<int> LightIDs { get; set; }

    // TODO: Remove this and make v2 exclusive?
    [CanBeNull] 
    ChromaGradient LightGadient { get; set; }
}

