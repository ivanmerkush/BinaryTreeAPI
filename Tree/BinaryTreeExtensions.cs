using System;
using System.Collections.Generic;

namespace DataStructures
{
    public static class BinaryTreeExtensions
    {

        /// <summary>
        /// Returns all nodes of this tree. Depending on param isAscending returns ascending or descending dictionary.
        /// </summary>
        /// <param name="isAscending"></param>
        /// <returns></returns>
        public static void GetNodes<K, V>(this BinaryTree<K, V> binaryTree, out IList<Node<K, V>> list, Direction direction) where K : IComparable
        {
            list = new List<Node<K, V>>(binaryTree.Counter);
            switch (direction)
            {
                case Direction.Ascending:
                    GetNodesAscending(binaryTree.Root, list);
                    break;
                case Direction.Descending:
                    GetNodesDescending(binaryTree.Root, list);
                    break;
                default:
                    break;
            }
        }


        private static void GetNodesAscending<K, V>(Node<K, V> node, IList<Node<K, V>> list) where K: IComparable
        {
            if (node.LeftNode != null)
            {
                GetNodesAscending(node.LeftNode, list);
            }
            list.Add(node);
            if (node.RightNode != null)
            {
                GetNodesAscending(node.RightNode, list);
            }
        }

        private static void GetNodesDescending<K, V>(Node<K, V> node, IList<Node<K, V>> list) where K: IComparable
        {
            if (node.RightNode != null)
            {
                GetNodesDescending(node.RightNode, list);
            }
            list.Add(node);
            if (node.LeftNode != null)
            {
                GetNodesDescending(node.LeftNode, list);
            }
        }
    }

    public enum Direction
    {
        Ascending,
        Descending
    }
}
