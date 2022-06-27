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
    IReadOnlySet<int>? LightIDs { get; set; }

    // TODO: Remove this and make v2 exclusive?
    [CanBeNull] ChromaGradient? LightGradient { get; set; }
}