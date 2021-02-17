using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// This class is an implementation of node of binary tree
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class Node<K, V> : IComparable where K: IComparable
    {
        public K Key { get; internal set; }
        public V Value { get; internal set; }
        
        internal Node<K, V> Parent { get; set; } 
        internal Node<K, V> LeftNode { get; set; }
        internal Node<K, V> RightNode { get; set; }
        public Node(K key, V value)
        {
            Key = key;
            Value = value;
            Parent = null;
        }

        internal Node(K key, V value, Node<K, V> parent)
        {
            Key = key;
            Value = value;
            Parent = parent;
        }

        public override string ToString()
        {
            return Key +"\t" + Value + ";";
        }

        /// <summary>
        /// Compare result depends on K Key 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (obj is Node<K, V> node)
                return Key.CompareTo(node.Key);
            else
                throw new ArgumentException("Object is not a Node");
        }
    }

}
