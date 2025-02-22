using System.Collections.Generic;

namespace AlgAndDS.DataStructuresRealisations;

public class HashTable<K, V>
{
    private const int DefaultSize = 16;
    private System.Collections.Generic.LinkedList<KeyValuePair<K, V>>[] buckets;
    private int count;

    public int Count => count;

    public HashTable(int size = DefaultSize)
    {
        buckets = new System.Collections.Generic.LinkedList<KeyValuePair<K, V>>[size];
        for (int i = 0; i < size; i++)
        {
            buckets[i] = new System.Collections.Generic.LinkedList<KeyValuePair<K, V>>();
        }
    }

    private int GetBucketIndex(K key) => 
        Math.Abs(key.GetHashCode()) % buckets.Length;

    public void Insert(K key, V value)
    {
        int index = GetBucketIndex(key);
        System.Collections.Generic.LinkedList<KeyValuePair<K, V>> bucket = buckets[index];

        foreach (var pair in bucket)
        {
            if (pair.Key.Equals(key))
                throw new ArgumentException("Ключ уже существует");
        }
        
        bucket.AddLast(new KeyValuePair<K, V>(key, value));
        count++;
    }

    public V Get(K key)
    {
        int index = GetBucketIndex(key);
        var bucket = buckets[index];

        foreach (var pair in bucket)
        {
            if (pair.Key.Equals(key))
                return pair.Value;
        }

        throw new KeyNotFoundException("Ключ не найден");
    }

    public bool Remove(K key)
    {
        int index = GetBucketIndex(key);
        var bucket = buckets[index];

        foreach (var pair in bucket)
        {
            if (pair.Key.Equals(key))
            {
                bucket.Remove(pair);
                count--;
                return true;
            }
        }

        return false;
    }

    public bool Contains(K key)
    {
        int index = GetBucketIndex(key);
        var bucket = buckets[index];

        foreach (var pair in bucket)
        {
            if (pair.Key.Equals(key))
                return true;
        }

        return false;
    }
}