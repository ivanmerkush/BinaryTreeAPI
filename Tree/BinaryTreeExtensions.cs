using System;
using System.Collections.Generic;

namespace DataStructures
{
    public static class BinaryTreeExtensions
    {

        /// <summary>
        /// Returns all nodes of this tree. Depending on param isAscending returns ascending or descending collection.
        /// </summary>
        /// <param name="isAscending"></param>
        /// <returns></returns>
        public static bool GetNodes<K, V>(this BinaryTree<K, V> binaryTree, ICollection<Node<K, V>> collection, Direction direction) where K : IComparable
        {
            if(collection == null)
            {
                return false;
            }
            collection.Clear();
            switch (direction)
            {
                case Direction.Ascending:
                    GetNodesAscending(binaryTree.Root, collection);
                    break;
                case Direction.Descending:
                    GetNodesDescending(binaryTree.Root, collection);
                    break;
                default:
                    break;
            }
            return true;
        }


        private static void GetNodesAscending<K, V>(Node<K, V> node, ICollection<Node<K, V>> list) where K: IComparable
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

        private static void GetNodesDescending<K, V>(Node<K, V> node, ICollection<Node<K, V>> list) where K: IComparable
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
