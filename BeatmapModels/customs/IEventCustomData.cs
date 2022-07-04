using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public interface IEventCustomData : ICustomData
{
    Color? Color { get; set; }

    /// <summary>
    ///     May cause allocations
    ///     Ensure to call `set` on modified instances
    ///     Proceed with caution
    /// </summary>
    IReadOnlyList<int>? LightIDs { get; set; }
}