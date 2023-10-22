using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace home_HashTable
{
    internal class MyHashTable
    { // dictionary, возможно, в разы облегчил написание, но вы его не запрещали!
        private Dictionary<int, Dictionary<string, int>> _hashtable = new Dictionary<int, Dictionary<string, int>>{};

        public void Add(string key, int value)
        {
            int hashKey = HashFunction(key);

            if (!_hashtable.ContainsKey(hashKey))
            {
                _hashtable.Add(hashKey, new Dictionary<string, int>());
                _hashtable[hashKey].Add(key, value);
            }
            else _hashtable[hashKey].Add(key, value);
        }

        public void Remove(string key)
        {
            int hashKey = HashFunction(key);

            if (!_hashtable.ContainsKey(hashKey)) throw new Exception("There is no contact " + key + "in the phonebook");
            else if (!_hashtable[hashKey].ContainsKey(key))
                throw new Exception("There is no " + key + " in the phonebook");
            else _hashtable[hashKey].Remove(key);
        }

        public int Find(string key)
        {
            int hashKey = HashFunction(key);

            if (!_hashtable.ContainsKey(hashKey)) return -1;
            else if (!_hashtable[hashKey].ContainsKey(key)) return -1;
            else return _hashtable[hashKey][key];
        }

        private int HashFunction(string key)
        {
            // https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/compute-hash-values
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(key);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            int hashKey = BitConverter.ToInt32(tmpHash);
            return hashKey;
        }

    }
}
