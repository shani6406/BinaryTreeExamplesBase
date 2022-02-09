using System;
using DataStructureCore;
namespace BinaryTreeExamples
{
    class Program
    {
       
        static void Main(string[] args)
        {
          
          

            BinNode<int> t = new BinNode<int>(54);
            BinNode<int> left = new BinNode<int>(null, 48, new BinNode<int>(54));
            t.SetLeft(left);
            BinNode<int> right = new BinNode<int>(new BinNode<int>(63), 77, null);
            t.SetRight(right);

            Console.WriteLine(t);
           
          
       
            
           
        }
    }
}
