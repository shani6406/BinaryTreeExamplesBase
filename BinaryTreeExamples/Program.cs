using System;
using DataStructureCore;
namespace BinaryTreeExamples
{
    class Program
    {
       
        static void Main(string[] args)
        {
          
          

            BinNode<int> root = new BinNode<int>(54);
            BinNode<int> left = new BinNode<int>(null, 48, new BinNode<int>(55));
            BinNode<int> right = new BinNode<int>(new BinNode<int>(63), 77, null);
            root.SetRight(right);
            root.SetLeft(left);
            Console.WriteLine("InOrder:");
            BTHelper.PrintInOrder(root);
            Console.WriteLine();
            Console.WriteLine("PreOrder:");
            BTHelper.PrintPreOrder(root);
            Console.WriteLine();
            Console.WriteLine("PostOrder:");
            BTHelper.PrintPostOrder(root);
            Console.WriteLine();

            Console.WriteLine("does 63 exsists in tree?");
            Console.WriteLine(BTHelper.IsExistsInTree(root,63));
            Console.WriteLine($"There are {BTHelper.CountTreeNodes(root)} Nodes in tree" );
            


            Console.WriteLine("Print Random Tree");
            BinNode<int> rootRandom = BTHelper.CreateRandomTree(2, 10, 99);
            Console.WriteLine("InOrder:");
            BTHelper.PrintInOrder(rootRandom);
            Console.WriteLine();
            Console.WriteLine("PreOrder:");
            BTHelper.PrintPreOrder(rootRandom);
            Console.WriteLine();
            Console.WriteLine("PostOrder:");
            BTHelper.PrintPostOrder(rootRandom);
            Console.WriteLine();
            Console.WriteLine("does 63 exsists in tree?");
            Console.WriteLine(BTHelper.IsExistsInTree(rootRandom, 63));
            Console.WriteLine($"There are {BTHelper.CountTreeNodes(rootRandom)} Nodes in tree");


            width = BTHelper.BinTreeWidthVersion2(rootRandom);
            Console.WriteLine($" Now with a Counter Array Function Width Level is {width[0]} and width of this tree is {width[1]}");
            Console.WriteLine();
            Console.WriteLine("\nPress any Key To continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("The Nodes in Tree Width level are:");
            BTHelper.PrintNodesInLevel(rootRandom, width[0]);
            Console.WriteLine("\nPress any Key To continue...");
            Console.ReadKey();
            Console.Clear();



        }
    }
}
