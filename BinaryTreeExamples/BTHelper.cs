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
        public static int CountTreeNodes<T>(BinNode<T> root)
        {
           
        }
        #endregion

        #region האם ערך קיים בעץ
        public static bool IsExistsInTree<T>(BinNode<T> root, T val)
        {
            

        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool EachHasTwoChilds<T>(BinNode<T> root)
        {
           
        }

        /// <summary>
        /// עמ 176 שאלה 9 מהספר
        /// </summary>
        /// <param name="root"></param>
        public static void UpdateCharTree(BinNode<char> root)
            {
           
         
        }

        /// <summary>
        /// תרגיל 14
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>

        public static int CountLeaves<T>(BinNode<T> root)
        {
           
                
        }
        /// <summary>
        /// שאלה 12
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int CountBiggerInBetween(BinNode<double> root)
        {
          
        }

        #endregion


        #region גובה עץ
        /// <summary>
        /// פעולה המחשבת את גובה העץ בסריקה סופית
        /// גובה תת עץ שמאל, גובה תת עץ ימין ואז הגובה של העץ כולו הינו
        /// 1+ גובה המקסימלי מבין שני תתי העצים
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int BinTreeHight<T>(BinNode<T> root)
        {

            //אם הגענו לסוף מסלול בעץ (או עץ ריק) או שהגענו לעלה
            if (root == null || !root.HasLeft() && !root.HasRight())
                //גובה העץ 0
                return 0;
            //נחשב את הגובה של תת העץ השמאלי
            int leftChildHight = BinTreeHight(root.GetLeft());
            //נחשב את הגובה של תת העץ הימני
            int rightChildHight = BinTreeHight(root.GetRight());

            //גובה העץ זה הקשת שמחברת בין השורש לתת העץ הגבוה ביותר
            return 1 + Math.Max(leftChildHight, rightChildHight);
        }
        #endregion

        #region הדפסת רמה בעץ

        #region פעולת המעטפת
        /// <summary>
        /// הדפסת הצמתים ברמה מסוימת בעץ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="targetLevel"></param>
        public static void PrintNodesInLevel<T>(BinNode<T> root, int targetLevel)
        {
            if (root == null)
                Console.WriteLine("Nothing To Print");
            //נצטרך לסרוק את העץ מהשורש עד לרמה שנרצה...
            else
                PrintNodesInLevel(root, targetLevel, 0);
        }
        #endregion

        #region פעולת ההדפסה
        /// <summary>
        /// הפעולה תדפיס את ערך הצומת ברמה המבוקשת
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="targetLevel">הרמה שנרצה להדפיס</param>
        /// <param name="currentLevel">הרמה הנוכחית שאליה הגענו בסריקה</param>
        private static void PrintNodesInLevel<T>(BinNode<T> root, int targetLevel, int currentLevel)
        {
            if (root == null)
            {
                Console.WriteLine("Nothing To Print");
                return;
            }
            //הגענו לרמה שלנו!
            else if (targetLevel == currentLevel)
                Console.Write(root.GetValue() + " ");
            else
            {
                PrintNodesInLevel(root.GetLeft(), targetLevel, currentLevel + 1);
                PrintNodesInLevel(root.GetRight(), targetLevel, currentLevel + 1);
            }


        }
        #endregion
        #endregion

        #region חישוב רוחב של עץ

        #region פעולת ראשית
        /// <summary>
        /// פעולה מחשבת את רוחב העץ- הרמה שמכילה את הכי הרבה צמתים
        /// הפעולה תחזיר מערך בגודל 2 - בתא 0 יוחזר הרמה שמכילה את הכי הרבה צמתים
        /// ובתא 1 - הרוחב של העץ
        /// נגדיר h - גובה של העץ
        /// נגדיר n- כמות הצמתים בעץ
        /// CountNodesInLevel -  O(n)
        /// הפעולה מחשבת גובה ואז רצה בלולאה כגובה העץ ולכן נקבל
        /// 
        /// o(h)+(o(h) * O(n)).
        /// ==>(o(h) * O(n))
        /// במקרה הגרוע זה עץ שרשרת (כמו שרשרת חוליות רגילה)
        /// במקרה כזה 
        /// h==n
        /// ולכן
        /// O(n^2)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int[] BinTreeWidth<T>(BinNode<T> root)
        {
            const int MAX_LEVEL_CELL = 0;
            const int MAX_WIDTH_CELL = 1;
            //עץ ריק- רוחב 0
            if (root == null)
                return null;
            //נחשב גובה של העץ
            int height = BinTreeHight(root);
            //נגדיר מערך בגודל 2
            int[] width = new int[2];
            //איתחול המערך- רמה 0 שורשר
            //ברמה 0 יש צומת אחת
            width[MAX_LEVEL_CELL] = 0;
            width[MAX_WIDTH_CELL] = 1;
            //אם העץ הוא רק צומת אחת - עץ עלה
            //סיימנו
            if (height == 0)
                return width;

            //אחרת נבדוק כמה צמתים יש בכל רמה
            //אם הרמה מכילה את הכמות המקסימלית- נעדכן את המערך שלנו
            for (int currentTreeLevel = 1; currentTreeLevel <= height; currentTreeLevel++)
            {
                //נבדוק מה רוחב רמה הנוכחית
                int currentWidth = CountNodesInLevel(root, currentTreeLevel);
                if (currentWidth > width[MAX_WIDTH_CELL])
                {
                    width[MAX_LEVEL_CELL] = currentTreeLevel;
                    width[MAX_WIDTH_CELL] = currentWidth;
                }
            }

            return width;


        }
        #endregion


        #region פעולות עזר
        /// <summary>
        /// פעולת מעטפת המקבלת רמה בעץ ומחזירה כמה צמתים יש באותה רמה
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="currentTreeLevel"></param>
        /// <returns></returns>
        private static int CountNodesInLevel<T>(BinNode<T> root, int currentTreeLevel)
        {
            //עץ ריק מקרה חריג
            if (root == null)
                return 0;
            //אנחנו צריכים לרדת בעץ לרמה המבוקשת ולכן צריך פעולת עזר שתעזור לנו להגיע לאותה רמה
            //נתחיל לחפש מהשורש של העץ 
            return CountNodesInLevel(root, currentTreeLevel, 0);
        }

        /// <summary>
        /// פעולה המקבלת שורש עץ, את הרמה שאליה נרצה להגיע והרמה הנוכחית בה אנו נמצאים
        /// הפעולה תחזיר את כמות הצמתים ברמה המבוקשת
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="targetTreeLevel">הרמה המבוקשת</param>
        /// <param name="currentLevel"> הרמה הנוכחית בעץ</param>
        /// <returns></returns>
        private static int CountNodesInLevel<T>(BinNode<T> root, int targetTreeLevel, int currentLevel)
        {
            //אם בטעות עברנו את הרמה שאותה אנחנו מחפשים...
            if (currentLevel > targetTreeLevel)
                return -1;
            //מצב שלא אמור לקרות...
            if (root == null)
                return 0;
            //כאשר הגענו לרמה שחיפשנו
            if (targetTreeLevel == currentLevel)
                return 1;
            //אם לא הגענו לרמה שחיפשנו= נחזיר כמה צמתים יש בתת עץ שמאל ברמה שלנו + כמה יש בתת עץ ימין
            //ברמה שביקשנו
            return CountNodesInLevel(root.GetLeft(), targetTreeLevel, currentLevel + 1) + CountNodesInLevel(root.GetRight(), targetTreeLevel, currentLevel + 1);
        }
        #endregion

        #endregion

        #region חישוב רוחב של עץ באמצעות מערך מונים
        /// <summary>
        /// n= כמות הצמתים
        /// CountNodesInLevel- מבצעת סריקה אחת על העץ ולכן O(n)
        /// FindMax- במקרה של עץ שרשרת (כמו שרשרת חוליות)- O(n)
        /// ולכן קיבלנו
        /// O(n) + O(n)=O(n)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int[] BinTreeWidthVersion2<T>(BinNode<T> root)
        {
            //מערך בגודל גובה העץ + 1 )
            //כי יש 1 יותר רמות מגובה העץ
            int[] treeLevels = new int[BinTreeHight(root) + 1];
            int currentLevel = 0;
            //המערך יכיל בסוף הפעולה בכל רמה את כמות הצמתים שלה
            CountNodesInLevel(root, treeLevels, currentLevel);
            //יוחזר מערך המכיל את הרמה המקסימלית והערך המקסימלי באותה רמה
            return FindMax(treeLevels);


        }


        #region פעולות עזר
        /// <summary>
        /// הפעולה מקבלת שורש עץ
        /// מערך מונים בגודל גובה העץ
        /// ורמה נוכחית
        /// הפעולה תוסיף 1 בתא המייצג את מספר הרמה בתהליך הסריקה
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="treeLevels"></param>
        /// <param name="currentLevel"></param>
        private static void CountNodesInLevel<T>(BinNode<T> root, int[] treeLevels, int currentLevel)
        {
            if (root == null)
                return;
            treeLevels[currentLevel]++;
            CountNodesInLevel(root.GetLeft(), treeLevels, currentLevel + 1);
            CountNodesInLevel(root.GetRight(), treeLevels, currentLevel + 1);
        }

        /// <summary>
        /// מציאת מקסימום במערך.
        /// הפעולה מחזירה מערך בגודל 2
        /// תא הראשון המיקום של הערך המקסימלי
        /// והתא השני הערך המקסימלי במערך
        /// </summary>
        /// <param name="treeLevels"></param>
        /// <returns></returns>
        private static int[] FindMax(int[] treeLevels)
        {
            const int MAX_LEVEL_CELL = 0;
            const int MAX_WIDTH_CELL = 1;
            int[] maxWidth = new int[2];
            maxWidth[MAX_LEVEL_CELL] = 0;
            maxWidth[MAX_WIDTH_CELL] = 1;
            for (int i = 0; i < treeLevels.Length; i++)
            {
                if (treeLevels[i] > maxWidth[MAX_WIDTH_CELL])
                {
                    maxWidth[MAX_LEVEL_CELL] = i;
                    maxWidth[MAX_WIDTH_CELL] = treeLevels[i];
                }
            }
            return maxWidth;
        }
        #endregion
        #endregion

        #region Binary Search Tree

        #region הוספת ערך לעץ חיפוש
        public static void AddToBST(BinNode<int> t, int x)
        {
            if (t.GetValue() > x)
            {
                if (!t.HasLeft())
                    t.SetLeft(new BinNode<int>(x));
                else
                    AddToBST(t.GetLeft(), x);
            }
            else
            {
                if (!t.HasRight())
                    t.SetRight(new BinNode<int>(x));
                else
                    AddToBST(t.GetRight(), x);
            }

        }
        #endregion

        #region מקסימום/מינימום בעץ חיפוש
        public static int FindMaxInBST(BinNode<int> t)
        {
            //int min=t.GetValue();
            int max = t.GetValue();
            //while(t.HasLeft())
            while (t.HasRight())
            {
                //t=t.GetLeft();
                t = t.GetRight();
                //min=t.GetValue();
                max = t.GetValue();
            }
            //return min;
            return max;
        }
        #endregion

        #region האם עץ חיפוש

        /// <summary>
        /// כל צומת צריך להיות גדול יותר מהכי גדול בתת העץ השמאלי שלו
        /// ויותר קטן מהכי קטן בתת עץ הימני שלו
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsBST(BinNode<int> t)
        {
            if (t == null)
                return true;

            if (t.GetValue() <= FindMax(t.GetLeft()))
                return false;
            if (t.GetValue() > FindMin(t.GetRight()))
                return false;
            return IsBST(t.GetLeft()) && IsBST(t.GetRight());

        }

        public static int FindMin(BinNode<int> t)
        {
            if (t == null)
                return int.MaxValue;
            if (IsLeaf(t))
            {
                return t.GetValue();
            }
            return Math.Min(t.GetValue(), Math.Min(FindMin(t.GetLeft()), FindMin(t.GetRight())));
        }


        public static int FindMax(BinNode<int> t)
        {
            if (t == null)
                return int.MinValue;
            if (IsLeaf(t))
            {
                return t.GetValue();
            }
            return Math.Max(t.GetValue(), Math.Max(FindMax(t.GetLeft()), FindMax(t.GetRight())));
        }
        #endregion

        #region מצא הורה בעץ חיפוש
        public static BinNode<int> FindParent(BinNode<int> root, BinNode<int> child)
        {
            if (root == null || root == child)
                return null;

            if (child.GetValue() < root.GetValue())
            {
                if (root.HasLeft())
                {
                    if (root.GetLeft() == child)
                        return root;
                    else
                        return FindParent(root.GetLeft(), child);
                }
                return null;
            }
            else if (child.GetValue() > root.GetValue())
            {
                if (root.HasRight())
                {
                    if (root.GetRight() == child)
                        return root;
                    else
                        return FindParent(root.GetRight(), child);
                }

            }
            return null;
        }
            #endregion

            #region מחיקת ערך בעץ חיפוש
            //            The node has no children(it's a leaf node). You can delete it. ...
            //The node has just one child.To delete the node, replace it with that child. ...
            //The node has two children.In this case, find the MAX in the LEFT Side of the node. (or MIN of the RIGHT SIDE OF THE NODE)

            public static BinNode<int> RemoveFromBST(BinNode<int> root, int key)
            {


                if (root == null)
                    return root;
                
             
                if (root.GetValue() > key)
                {
                   BinNode<int> parent = RemoveFromBST(root.GetLeft(), key);
                    root.SetLeft(parent);
                }
                if (root.GetValue() < key)
                {
                    BinNode<int> parent = RemoveFromBST(root.GetRight(), key);
                    root.SetRight(parent);
                }


                if (root.GetValue() == key)
                {
                    if (!root.HasLeft() && !root.HasRight())
                        return null;
                    if (!root.HasLeft())
                        return root.GetRight();
                    if (!root.HasRight())
                        return root.GetLeft();
                    else
                    {
                        int maxval = FindMaxInBST(root.GetLeft());
                        root.SetValue(maxval);
                        root.SetLeft(RemoveFromBST(root.GetLeft(), maxval));
                    }
                }
                return root;
            }
        }


               


                #endregion
                #endregion

            
       




}
