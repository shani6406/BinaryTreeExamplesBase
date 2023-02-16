using System;
//using System.Collections.Generic;
//using System.ComponentModel.Design.Serialization;
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

        //פעולה המקבלת עץ בינארי של אותיות קטנות ומעדכנת את הערכים של כל הצמתים להיות האות העוקבת באופן מעגלי
        public static void UpdateLetters(BinNode<char> root)
        {
            if (root != null)
            {
                root.SetValue((char)(((root.GetValue()-'a' + 1)%26)+'a'));
          
                UpdateLetters(root.GetLeft());
                UpdateLetters(root.GetRight());
            }
        }

        //פעולה גנרית המקבלת עץ ומדפיסה את כל העלים בעץ משמאל לימין
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

        //פעולה גנרית המחזירה אמת אם צומת מהווה בן לאב יחיד
        public static bool IsSingleParent<T>(BinNode<T> node)
        {
            if(node==null)
                return false;
            return ((node.HasLeft() && !node.HasRight()) || (node.HasRight() && !node.HasLeft()));
        }
        //פעולה המחזירה את מספר הבנים היחידים בעץ
        public static int CountSingleParents<T>(BinNode<T> root)
        {
            if (root == null)
                return 0;
            if (IsSingleParent(root))
                return 1+CountSingleParents(root.GetLeft()) + CountSingleParents(root.GetRight());
            return CountSingleParents(root.GetLeft())+CountSingleParents(root.GetRight());

        }
        //פעולה המקבלת עץ בינארי של מספרים שלמים ומחזירה את מספר הבנים היחידים שיש להם בן יחיד
        public static int CountSingleChild(BinNode<int> root)
        {
            if (root == null)
                return 0;
            if (IsSingleParent(root) && IsSingleParent(root.GetLeft()) || IsSingleParent(root) && IsSingleParent(root.GetRight()))
                return 1+CountSingleChild(root.GetLeft()) + CountSingleChild(root.GetRight());
            return CountSingleChild(root.GetLeft()) + CountSingleChild(root.GetRight());
        }
         //הגובה של העץ
        public static int BinTreeHight<T>(BinNode<T>root)
        {
            if (root == null)
                return 0;
            if ((IsSingleParent(root) && IsSingleParent(root.GetLeft()) || IsSingleParent(root) && IsSingleParent(root.GetRight())))
                return 1 + CountSingleParents(root.GetLeft()) + CountSingleParents(root.GetRight());
            return CountSingleParents(root.GetLeft()) + CountSingleParents(root.GetRight());
        }
        //הפעולה "מסלול עולה" - מחזירה אמת אם יש בעץ מסלול המתחיל בשורש העץ ומסתיים באחד העלים שלו,ן
        //וערכי הצמתים ממוינים בסדר עולה מהשורש לעלה אם אין מסלול כזה הפעולה תחזיר שקר
        public static bool UpPath(BinNode<int> tr)
        {
            if(tr==null) return false;
            if(IsLeaf(tr)) return true;
            if (tr.HasLeft())
            {
                if (tr.GetValue() < tr.GetLeft().GetValue())
                    return UpPath(tr.GetLeft());
            }
            if (tr.HasRight())
            {
                if (tr.GetValue() < tr.GetRight().GetValue())
                    return UpPath(tr.GetRight());
            }
            return false;
        }
        //סריקת רוחב
        public static void BradthSearch<T>(BinNode<T> root)
        {
            Queue<BinNode<T>> queue = new Queue<BinNode<T>>();
            BinNode<T> node;
            queue.Insert(root);
            while(!queue.IsEmpty())
            {
                node = queue.Remove();
                Console.WriteLine(node.GetValue());
                if(node.HasLeft())
                    queue.Insert(node.GetLeft());
                if(node.HasRight())
                    queue.Insert(node.GetRight());
            }
        }
        public static int MaxBradthSearch(BinNode<int> root)
        {
            int max = root.GetValue();
            Queue<BinNode<int>> queue = new Queue<BinNode<int>>();
            BinNode<int> node;
            queue.Insert(root);
            while(!queue.IsEmpty())
            {
                node = queue.Remove();
                if(node.GetValue() > max)
                    max = node.GetValue();
                if(node.HasLeft())
                    queue.Insert(node.GetLeft());
                if(node.HasRight())
                    queue.Insert(node.GetRight());
            }
            return max;
        }
        public static int WhichLevel(BinNode<int> root, int x)
        {
            int level = 0;
            Queue<BinNode<int>> queue = new Queue<BinNode<int>>();
            BinNode<int> node;
            queue.Insert(root);
            while (!queue.IsEmpty())
            {
                node = queue.Remove();
                if (node.GetValue() == x)
                    return level; 
                if(node.HasLeft())
                {
                    queue.Insert(node.GetLeft());
                    level++;
                } 
                if (node.HasRight())
                {
                    queue.Insert(node.GetRight());
                    level++;
                }
                   
            }

        }
    }





}
