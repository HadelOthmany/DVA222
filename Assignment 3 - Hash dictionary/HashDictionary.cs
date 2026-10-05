using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment_3
{
    public class HashDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        const int DefaultCapacity = 1000;
        LinkedList<KeyValuePair<TKey, TValue>>[] Buckets;
        int _count;

        public HashDictionary()
        {
            Buckets = new LinkedList<KeyValuePair<TKey, TValue>>[DefaultCapacity];
            for (int i = 0; i < DefaultCapacity; i++)
            {
                Buckets[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            _count = 0;
        }

        protected uint GetIndex(TKey key)
        {
            return (uint)(key.GetHashCode() % Buckets.Length);
        }

        protected LinkedListNode<KeyValuePair<TKey, TValue>> Find(TKey key)
        {
            uint index = GetIndex(key);
            var bucket = Buckets[index];
            if (bucket != null)
            {
                for (var node = bucket.First; node != null; node = node.Next)
                {
                    if (EqualityComparer<TKey>.Default.Equals(node.Value.Key, key))
                    {
                        return node;
                    }
                }
            }
            return null;
        }

        public void Add(TKey key, TValue value)
        {
            uint index = GetIndex(key);
            if (Buckets[index] == null)
            {
                Buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            var node = Find(key);
            if (node != null)
            {
                throw new ArgumentException("An element with the same key already exists in the dictionary.");
            }
            Buckets[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            _count++;
        }

        public bool Remove(TKey key)
        {
            uint index = GetIndex(key);
            var bucket = Buckets[index];
            if (bucket != null)
            {
                var node = Find(key);
                if (node != null)
                {
                    bucket.Remove(node);
                    _count--;
                    return true;
                }
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var node = Find(key);
            if (node != null)
            {
                value = node.Value.Value;
                return true;
            }
            value = default(TValue);
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            return Find(key) != null;
        }

        public void Clear()
        {
            Buckets = new LinkedList<KeyValuePair<TKey, TValue>>[DefaultCapacity];
            _count = 0;
        }

        public ICollection<TKey> Keys
        {
            get
            {
                var keys = new List<TKey>();
                foreach (var bucket in Buckets)
                {
                    if (bucket != null)
                    {
                        foreach (var kvp in bucket)
                        {
                            keys.Add(kvp.Key);
                        }
                    }
                }
                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                var values = new List<TValue>();
                foreach (var bucket in Buckets)
                {
                    if (bucket != null)
                    {
                        foreach (var kvp in bucket)
                        {
                            values.Add(kvp.Value);
                        }
                    }
                }
                return values;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                var node = Find(key);
                if (node != null)
                {
                    return node.Value.Value;
                }
                throw new KeyNotFoundException("The key was not found in the dictionary.");
            }
            set
            {
                uint index = GetIndex(key);
                if (Buckets[index] == null)
                {
                    Buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                }
                var node = Find(key);
                if (node != null)
                {
                    node.Value = new KeyValuePair<TKey, TValue>(key, value);
                }
                else
                {
                    Buckets[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
                    _count++;
                }
            }
        }

        public int Count => _count;
        public bool IsReadOnly => false;

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            var node = Find(item.Key);
            return node != null && EqualityComparer<TValue>.Default.Equals(node.Value.Value, item.Value);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            foreach (var bucket in Buckets)
            {
                if (bucket != null)
                {
                    foreach (var kvp in bucket)
                    {
                        array[arrayIndex++] = kvp;
                    }
                }
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var node = Find(item.Key);
            if (node != null && EqualityComparer<TValue>.Default.Equals(node.Value.Value, item.Value))
            {
                uint index = GetIndex(item.Key);
                Buckets[index].Remove(node);
                _count--;
                return true;
            }
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new HashDictionaryEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class HashDictionaryEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private HashDictionary<TKey, TValue> dictionary;
            private int bucketIndex;
            private LinkedListNode<KeyValuePair<TKey, TValue>> currentNode;

            public HashDictionaryEnumerator(HashDictionary<TKey, TValue> dictionary)
            {
                this.dictionary = dictionary;
                bucketIndex = -1;
                currentNode = null;
            }

            public KeyValuePair<TKey, TValue> Current => currentNode.Value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (currentNode != null && currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                    return true;
                }

                while (++bucketIndex < dictionary.Buckets.Length)
                {
                    var bucket = dictionary.Buckets[bucketIndex];
                    if (bucket != null && bucket.First != null)
                    {
                        currentNode = bucket.First;
                        return true;
                    }
                }
                return false;
            }

            public void Reset()
            {
                bucketIndex = -1;
                currentNode = null;
            }
        }
    }
}
