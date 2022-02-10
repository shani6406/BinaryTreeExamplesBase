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


        #region סריקות
        #region סריקה תחילית
        /// <summary>
        /// פעולה המדפיסה עץ בינארי בסריקה תחילית
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        public static void PrintPreOrder<T>(BinNode<T> root)
        {
            //אם ריק- לא נדפיס כלום
            if (root == null)
                return;
            //נדפיס את השורש
            Console.Write(root.GetValue()+",");
            //נדפיס את תת העץ השמאלי
            PrintPreOrder(root.GetLeft());
            //נדפיס את תת העץ הימני
            PrintPreOrder(root.GetRight());

        }
        #endregion

        #region סריקה תוכית
        /// <summary>
        /// פעולה המדפיסה עץ בינארי בסריקה תוכית
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        public static void PrintInOrder<T>(BinNode<T> root)
        {
            //אם ריק- לא נדפיס כלום
            if (root == null)
                return;
           
            //נדפיס את תת העץ השמאלי
            PrintPreOrder(root.GetLeft());
            //נדפיס את השורש
            Console.Write(root.GetValue() + ",");
            //נדפיס את תת העץ הימני
            PrintPreOrder(root.GetRight());

        }
        #endregion

        #region סריקה סופית
        /// <summary>
        /// פעולה המדפיסה עץ בינארי בסריקה סופית
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        public static void PrintPostOrder<T>(BinNode<T> root)
        {
            //אם ריק- לא נדפיס כלום
            if (root == null)
                Console.WriteLine("end");

            //נדפיס את תת העץ השמאלי
            PrintPreOrder(root.GetLeft());
           
            //נדפיס את תת העץ הימני
            PrintPreOrder(root.GetRight());

            //נדפיס את השורש
            Console.Write(root.GetValue() + ",");

        }
        #endregion
        #endregion



        #region האם עלה
        /// <summary>
        /// פעולה הבודקת האם הצומת הוא עלה
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns>אמת אם עלה ושקר אחרת</returns>
        public static bool IsLeaf<T>(BinNode<T> root)
        {
            //עץ ריק הוא לא עלה
            if (root == null)
                return false;
            //לעלה אין ילד שמאלי ואין ילד ימני. אם אין יוחזר אמת. אחרת יוחזר שקר
            return !root.HasLeft() && !root.HasRight();
        }
        #endregion


        #region פעולות על עצים
        #region ספירת צמתים
        /// <summary>
        /// פעולה המקבלת שורש של עץ ומחזירה את כמות הצמתים בעץ
        /// n- מספר הצמתים
        /// הפעולה מבקרת בכל צומת בדיוק פעם אחת
        /// ולכן O(n)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int CountTreeNodes<T> (BinNode<T> root)
        {
            //אין שורש או הגענו לקצה של העץ
            if (root == null)
                return 0;
            //נספור את הצומת הנוכחית + כמות הצמתים בתת עץ שמאל+ כמות הצמתים בתת עץ ימין
            return 1 + CountTreeNodes(root.GetLeft()) + CountTreeNodes(root.GetRight());
        }
        #endregion

        #region האם ערך קיים בעץ
        public static bool IsExistsInTree<T>(BinNode<T> root,T val)
        {
            //עץ ריק או הגענו לקצה - הערך לא נמצא...
            if (root == null)
                return false;
            //אם הערך בשורש הנוכחי שווה לערך שמחפשים - מצאנו!
            if (root.GetValue().Equals(val))
                return true;
            //נבדוק אם הערך נמצא בצד שמאל
            bool left = IsExistsInTree(root.GetLeft(), val);
            //נבדוק אם הערך נמצא בצד ימין
            bool right = IsExistsInTree(root.GetRight(), val);
            //נחזיר אם הוא נמצא בתת עץ שמאל או בתת עץ ימין
            return left || right;

            //ניתן לרשום את שורות 189 - 196 בשורה אחת
            //return (root.GetValue().Equals(val) || IsExistsInTree(root.GetLeft(), val) || IsExistsInTree(root.GetRight(), val));
        }
        #endregion
        #endregion
    }



}
