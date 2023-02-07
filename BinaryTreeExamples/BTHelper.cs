using System;
using System.Collections.Generic;
using System.Text;
using DataStructureCore;

namespace BinaryTreeExamples
{
    //כאן יופיעו כל הפעולות העזר עבור עצים
    class BTHelper
    {

        #region יצירת עץ
        public static BinNode<int> CreateTree()
        {
            BinNode<int> root;
            BinNode<int> left;
            BinNode<int> right;
            //קליטת הנתון
            int val = InputData();
            //אם נקלט null
            if (val == -1)
                return null;
            //אחרת צור את השורש
            root = new BinNode<int>(val);
            //צור את תת העץ השמאלי
            left = CreateTree();
            //צור את תת העץ הימני
            right = CreateTree();
            //חבר את תת העץ השמאלי לשורש
            root.SetLeft(left);
            //חבר את תת העץ הימני לשורש
            root.SetRight(right);
            //החזר את שורש תת העץ/שורש העץ
            return root;
        }

        /// <summary>
        /// פעולה היוצרת עץ רנדומלי בגובה
        /// height
        /// ערך כל צומת בטווח שבין max ל min
        /// </summary>
        /// <param name="height"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static BinNode<int> CreateRandomTree(int height, int min, int max)
        {
            Random rnd = new Random();
            BinNode<int> root;
            BinNode<int> left;
            BinNode<int> right;

            if (height == -1)
                return null;
            int val = rnd.Next(min, max + 1);
            root = new BinNode<int>(val);
            left = CreateRandomTree(height - 1, min, max);
            right = CreateRandomTree(height - 1, min, max);
            root.SetLeft(left);
            root.SetRight(right);
            return root;
        }

        private static int InputData()
        {
            Console.WriteLine("Please enter Value, enter -1 for null value (end Branch)");
            return int.Parse(Console.ReadLine());
        }


        #endregion



        #region הדפסה
        public static void PrintPreOrder<T>(BinNode<T> root)//הדפסה תחילית
        {
            if (root != null)
            {
                Console.WriteLine(root.GetValue());
                PrintPreOrder(root.GetLeft());
                PrintPreOrder(root.GetRight());
            }
        }
        public static void PrintInOrder<T>(BinNode<T> root)//הדפסה תוכית
        {
            if (root != null)
            {
                PrintInOrder(root.GetLeft());
                Console.WriteLine(root.GetValue());
                PrintInOrder(root.GetRight());
            }
        }
        public static void PrintPostOrder<T>(BinNode<T> root)//הדפסה סופית
        {
            if (root != null)
            {
                PrintPostOrder(root.GetLeft());
                PrintPostOrder(root.GetRight());
                Console.WriteLine(root.GetValue());
            }
        }
        #endregion


        #region ספירה
        public static int CountPreorder<T>(BinNode<T> root)
        {
            if (root == null)
                return 0; 
            return 1+CountPreorder(root.GetLeft())+CountPreorder(root.GetRight());
        }
        public static int CountInOrder<T>(BinNode<T>root)
        {
            if (root == null)
                return 0; 
            return CountInOrder(root.GetLeft())+1+CountInOrder(root.GetRight());
        }
        public static int CountPostOrder<T>(BinNode<T>root)
        {
            if (root == null)
                return 0; 
            return CountPostOrder(root.GetLeft())+CountPostOrder(root.GetRight())+1;
        }
        #endregion

        public static bool IsExistInTree<T>(BinNode<T> root, T val)
        {
            if (root == null)
                return false;
            //בשורש או בצן ימין או בצד שמאל
            return root.GetValue().Equals(val)||IsExistInTree(root.GetLeft(), val)||IsExistInTree(root.GetRight(),val);
        }

        

        public static bool IsLeaf<T>(BinNode<T>root)
        {
            //עץ ריק הוא לא עלה
            if (root == null)
                return false;
            //לעלה אין ילד שמאלי ואין ילד ימני. אם אין יוחזר אמת. אחרת יוחזר שקר
            return !root.HasLeft() && !root.HasRight(); 
        }
        public static bool EachHasTwoChilds<T>(BinNode<T> root)
        {
            if (root == null)
                return true;
            return (!root.HasLeft()&&!IsLeaf(root))|| (!root.HasRight()&&!IsLeaf(root))&&EachHasTwoChilds(root.GetRight())&&EachHasTwoChilds(root.GetLeft());
        }

        //פעולה המקבלץ עץ בינארי של אותיות קטנות ומעדכנת את הערכים של כל הצמתים להיות האות העוקבת באופן מעגלי
        public static void UpdateLetters(BinNode<char> root)
        {
            if (root != null)
            {
                root.SetValue((char)(((root.GetValue()-'a' + 1)%26)+'a'));
          
                UpdateLetters(root.GetLeft());
                UpdateLetters(root.GetRight());
            }
        }

        //פעולה גנרית המקבלת עץ ודפיסה את כל העלים בעץ משמאל לימין
        public static void PrintLeafs<T>(BinNode<T>root)
        {
            if(root != null)
            {
                if(IsLeaf(root))
                    Console.WriteLine(root.GetValue());
               PrintLeafs(root.GetLeft());
                PrintLeafs(root.GetRight());

            }
        }
    }





}
