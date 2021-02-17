using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Immutable;

namespace DataStructures
{
    /// <summary>
    /// Class that enables to create binary tree and edit using operations add, remove, get
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class BinaryTree<K, V> : IEnumerable<Node< K, V>> where K : IComparable
    {

        internal Node<K, V> Root { get; private set; }

        /// <summary>
        /// This propetry returns amount of nodes in this tree;
        /// </summary>
        public int Counter { get; private set; }

        /// <summary>
        /// Initialize tree with null root.
        /// </summary>
        public BinaryTree() { }

        /// <summary>
        /// Initilalize tree with root's customized params.
        /// </summary>
        /// <typaram name="key"></param>
        /// <param name="value"></param>
        public BinaryTree(K key, V value)
        {
            Root = new Node<K, V>(key, value);
            Counter = 1;
        }

        /// <summary>
        /// Checks if this node exists.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(K key)
        {
            return FindNode(key) != null;
        }

        /// <summary>
        /// Method finds node with required key. Throws ArgumentNullException in case key is null
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node<K, V> FindNode(K key)
        {
            if (key == null)
            {
                return null;
            }
            Node<K, V> node = Root;
            while (node != null)
            {
                switch (node.Key.CompareTo(key))
                {
                    case 0:
                        return node;
                    case 1:
                        node = node.LeftNode;
                        break;
                    default:
                        node = node.RightNode;
                        break;
                }
            }
            return null;
        }

        /// <summary>
        /// This method adds new node to the binary tree. If node with new key already exists, it gains new value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool AddNode(K key, V value)
        {
            if (key == null || value == null)
            {
                return false;
            }
            if (Root == null)
            {
                Root = new Node<K, V>(key, value);
                Counter++;
            }
            else
            {
                AddNode(Root, key, value);
            }
            return true;
        }

        private void AddNode(Node<K, V> node, K key, V value)
        {
            switch(node.Key.CompareTo(key))
            {
                case 0:
                    break;
                case 1:
                    if (node.LeftNode == null)
                    {
                        node.LeftNode = new Node<K, V>(key, value, node);
                        Counter++;
                    }
                    else
                    {
                        AddNode(node.LeftNode, key, value);
                    }
                    break;
                default:
                    if (node.RightNode == null)
                    {
                        node.RightNode = new Node<K, V>(key, value, node);
                        Counter++;
                    }
                    else
                    {
                        AddNode(node.RightNode, key, value);
                    }
                    break;

            }
        }


        /// <summary>
        /// Method inserts into binary tree all unique elements from collection
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<Node<K, V>> collection)
        {
            foreach(Node<K, V> node in collection)
            {
                AddNode(node.Key, node.Value);
            }
        }


        /// <summary>
        /// Removes node, if it exists.
        /// </summary>
        /// <param name="key"></param>
        public bool RemoveNode(K key)
        {
            if (key == null || Root == null)
            {
                return false;
            }
            Root = RemoveNode(Root, key);
            return true;
        }

        private Node<K, V> RemoveNode(Node<K, V> node, K key)
        {
            if (node == null)
            {
                return null;
            }
            switch (key.CompareTo(node.Key))
            {
                case -1:
                    node.LeftNode = RemoveNode(node.LeftNode, key);
                    return node;
                case 1:
                    node.RightNode = RemoveNode(node.RightNode, key);
                    return node;
                default:
                    break;
            }
            if (node.LeftNode == null)
            {
                Counter--;
                return node.RightNode;
            }
            else
            {
                if (node.RightNode == null)
                {
                    Counter--;
                    return node.LeftNode;
                }
                else
                {
                    Node<K, V> minNode = FindMinNode(node.RightNode);
                    node.Key = minNode.Key;
                    node.Value = minNode.Value;
                    node.RightNode = RemoveNode(node.RightNode, node.Key);
                    return node;
                }
            }
        }

        private Node<K, V> FindMinNode(Node<K, V> node)
        {
            if (node.LeftNode == null)
            {
                return node;
            }
            return FindMinNode(node.LeftNode);
        }


        public IEnumerator<Node<K, V>> GetEnumerator()
        {
            return new TreeEnumerator<K, V>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class TreeEnumerator<K, V> : IEnumerator<Node<K, V>> where K : IComparable
    {

        private bool isLeft = true;
        private bool isRight = true;
        private int count;
        private Node<K, V> Root { get; set; }
        private Node<K, V> Node { get; set; }
        public TreeEnumerator(BinaryTree<K, V> tree)
        {
            count = tree.Counter;
            Root = tree.Root;
            Node = Root;
            Current = Root;
        }

        public Node<K, V> Current
        {
            get; private set;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            while (count != 0)
            {
                if (Node.LeftNode != null && isLeft)
                {
                    isRight = true;
                    Node = Node.LeftNode;
                }
                else
                {
                    if(Current == Node.RightNode || Node.RightNode == null)
                    {
                        isRight = false;
                    }
                    else
                    {
                        isRight = true;
                    }
                    Current = Node;
                    if (Node.RightNode != null)
                    {
                        if (isRight)
                        {
                            isLeft = true;
                            Node = Node.RightNode;
                        }
                        else
                        {
                            if(Node.Parent != null)
                            {
                                Node = Node.Parent;
                                continue;
                            }
                            else
                            {
                                Node = Node.RightNode;
                                isRight = true;
                                isLeft = true;
                            }
                        }
                    }
                    else
                    {
                        isLeft = false;
                        Node = Node.Parent;
                    }
                    count--;
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            Node = Root;
        }
    }
}
