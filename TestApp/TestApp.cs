using System;
using System.Collections.Generic;
using DataStructures;
using System.Linq;
using System.Collections.Immutable;
namespace TestApp
{
    class TestApp
    {
        static void Main()  
        {
            BinaryTree<int, string> binaryTree1 = new BinaryTree<int, string>();
            binaryTree1.AddNode(-2, null);
            binaryTree1.AddNode(5, "qweasd");
            binaryTree1.AddNode(6, "zxc");
            binaryTree1.AddNode(-1, "fghasd");
            binaryTree1.AddNode(4, "rty");
            binaryTree1.AddNode(3, "jkl");
            binaryTree1.AddNode(9, "aaaasd");
            binaryTree1.AddNode(8, "bbb");
            binaryTree1.AddNode(10, "vbn");
            binaryTree1.AddNode(-3, "ccc");
            List<Node<int, string>> list = new List<Node<int, string>>();
            binaryTree1.GetNodes(list , Direction.Ascending);
            Console.WriteLine(binaryTree1.Counter);
            binaryTree1.GetNodes(list, Direction.Ascending);

            List<Node<int, string>> keyValues = new List<Node<int, string>>
            {
                new Node<int,string>( -10, "asd" ),
                new Node<int,string>( -7, "sssasd" ),
                new Node<int,string>( -6, "ttt" ),
                new Node<int,string>( -12, "yyy" ),
                new Node<int,string>( -13, "jjrj" ),
                new Node<int,string>( 20, "nnn" ),
                new Node<int,string>( 21, "bbbasd" ),
                new Node<int,string>( 19, "mmm" )
            };
            binaryTree1.AddRange(keyValues.ToImmutableList());
            binaryTree1.GetNodes( list, Direction.Ascending);
            foreach (Node<int, string> node in list)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("\n\n");

            var nodes = from node in binaryTree1
                        select node;

            foreach (Node<int, string> node in nodes)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("\n\n");

            nodes = from node in binaryTree1
                        where node.Value.Length > 4
                        select node;

            foreach (Node<int, string> node in nodes)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("\n\n");

            int count = binaryTree1.Counter;
            Console.WriteLine(count);

        }
    }
}
