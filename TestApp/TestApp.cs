using System;
using System.Collections.Generic;
using DataStructures;
using System.Linq;

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
            binaryTree1.GetNodes(out IList<Node<int, string>> list, Direction.Ascending);
                Console.WriteLine(binaryTree1.Counter);
            //foreach(Node<int, string> node in list)
            //{
            //    Console.WriteLine(node);
            //}
            //Console.WriteLine("\n\n");
            //binaryTree1.RemoveNode(1);
            binaryTree1.GetNodes(out list, Direction.Ascending);
            //Console.WriteLine(binaryTree1.Counter);
            //foreach (Node<int, string> node in list)
            //{
            //    Console.WriteLine(node);
            //}
            //Console.WriteLine("\n\n");
            //Console.WriteLine(binaryTree1.Exists(10));

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
            binaryTree1.AddNodes(keyValues);
            binaryTree1.GetNodes(out list, Direction.Ascending);
            //Console.WriteLine(binaryTree1.Counter);
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

            //BinaryTree<long, double> binaryTree2 = new BinaryTree<long, double>();

            //Dictionary<long, double> keyValues1 = new Dictionary<long, double>
            //{
            //    { -10, 0.8 },
            //    { -7, 12.7 },
            //    { -6, 15.6 },
            //    { -12, 123.5 },
            //    { -13, 43.4 },
            //    { 203, 123.3 },
            //    { 21, 67.2 },
            //    { 19, 19.1 }

            //};

            //List<Node<long, double>> list1 = new List<Node<long, double>>();
            //binaryTree2.GetNodes(list1, Direction.Descending);
            //Console.WriteLine(binaryTree2.Counter);
            //foreach (Node<long, double> node in list1)
            //{
            //    Console.WriteLine(node);
            //}
            //Console.WriteLine("\n\n");
        }
    }
}
