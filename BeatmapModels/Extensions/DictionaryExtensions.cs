using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public static class DictionaryExtensions
{
    
    [return: MaybeNull]
    public static T GetOrDefault<K, T>(this IDictionary<K, T> self, K key)
    {
        return self.TryGetValue(key, out var val) ? val : default;
    }
}