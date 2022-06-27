public static class DictionaryExtensions
{
    public static T? GetOrDefault<K, T>(this IDictionary<K, T> self, K key)
    {
        return self.TryGetValue(key, out var val) ? val : default;
    }
}