public static class DictionaryExtensions
{
    /// <summary>
    /// Returns the value for the given key, or adds a new TValue if not present.
    /// </summary>
    public static TValue GetOrAddNew<TKey, TValue>(
        this IDictionary<TKey, TValue> dictionary,
        TKey key) where TValue : new()
    {
        if (!dictionary.TryGetValue(key, out TValue? value))
        {
            value = new TValue();
            dictionary[key] = value;
        }

        return value!;
    }

    /// <summary>
    /// Attempts to remove the value with the specified key from the dictionary.
    /// Returns true if the key was found and removed; otherwise false.
    /// </summary>
    public static bool Pop<TKey, TValue>(
        this IDictionary<TKey, TValue> dictionary,
        TKey key,
        out TValue? value)
    {
        if (dictionary.TryGetValue(key, out value))
        {
            return dictionary.Remove(key);
        }

        value = default;
        return false;
    }
}