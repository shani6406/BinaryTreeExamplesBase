using System;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Reflection.Emit;
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
        public static int MinBradthSearch(BinNode<int> root)
        {
            int min = root.GetValue();
            Queue<BinNode<int>> queue = new Queue<BinNode<int>>();
            BinNode<int> node;
            queue.Insert(root);
            while(!queue.IsEmpty())
            {
                node = queue.Remove();
                if(node.GetValue() < min)
                    min = node.GetValue();
                if(node.HasLeft())
                    queue.Insert(node.GetLeft());
                if(node.HasRight())
                    queue.Insert(node.GetRight());
            }
            return min;
        }
        public static int WhichLevel<T>(BinNode<T> root, T x)
        {
            if (root == null)
                return -1;
            int level = 0;
            Queue<BinNode<T>> queue = new Queue<BinNode<T>>();
            BinNode<T> node;
            Queue<int> levels = new Queue<int>();
            queue.Insert(root);
            levels.Insert(level);
            while (!queue.IsEmpty())
            {
                node = queue.Remove();
                //נשלוף את הרמה של הצומת
                level = levels.Remove();
                if (node.GetValue().Equals(x))
                    return level; 
                if(node.HasLeft())
                {
                    queue.Insert(node.GetLeft());
                    //נכניס את הרמה הבאה
                    levels.Insert(level + 1);
                } 
                if (node.HasRight())
                {
                    queue.Insert(node.GetRight());
                    //נכניס את הרמה הבאה
                    levels.Insert(level + 1);
                }
            }
            return -1;
        }

        //עמוד 184 - שאלות 38, 39, 41

        //פעולה המקבלת עץ בינארי של מספרים שלמים ומספר רמה, ומדפיסה את כל איברי העץ באותה רמה.
        public static void PrintLevel(BinNode<int> root, int level)
        {
            if (root == null)
                Console.WriteLine("there is no level");
            int l = 0;
            Queue<BinNode<int>> queue = new Queue<BinNode<int>>();
            BinNode<int> node;
            Queue<int> levels = new Queue<int>();
            queue.Insert(root);
            levels.Insert(l);
            while (!queue.IsEmpty()&&l!=level)
            {
                node = queue.Remove();
                l = levels.Remove();
                if (node.HasLeft())
                {
                    queue.Insert(node.GetLeft());
                    levels.Insert(l + 1);
                }
                if (node.HasRight())
                {
                    queue.Insert(node.GetRight());
                    levels.Insert(l + 1);
                }
            }
           while(!queue.IsEmpty())
            {
                Console.WriteLine(queue.Remove());
            }
        }
        //פעולה המקבלת עץ בינארי של מספרים שלמים ומדפיסה את ערכי הצמתים ברמות הזוגיות של העץ
        public static void PrintEvenLevels(BinNode<int> root)
        {
            if (root == null)
                Console.WriteLine("there is no even levels");
            int level = 0;
            Queue<BinNode<int>> queue = new Queue<BinNode<int>>();
            BinNode<int> node;
            Queue<int> levels = new Queue<int>();
            queue.Insert(root);
            levels.Insert(level);
            while (!queue.IsEmpty())
            {
                node = queue.Remove();
                level = levels.Remove();
                if (level%2==0)
                {
                    Console.WriteLine(node.GetValue());
                }
                if (node.HasLeft())
                {
                    queue.Insert(node.GetLeft());
                    levels.Insert(level + 1);
                }
                if (node.HasRight())
                {
                    queue.Insert(node.GetRight());
                    levels.Insert(level + 1);
                }
            }
        }
        //פעולה המקבלת שני ערכים הנמצאים בעץ בינארי של מספרים שלמים, ומחזירה את הפרש הרמות ביניהם
        public static int LevelDifference(BinNode<int> root, int v1, int v2)
        {
            int Lv1=0 ;
            int Lv2=0 ;
            int level = 0;
            Queue<BinNode<int>> queue = new Queue<BinNode<int>>();
            BinNode<int> node;
            Queue<int> levels = new Queue<int>();
            queue.Insert(root);
            levels.Insert(level);
            while (!queue.IsEmpty())
            {
                node = queue.Remove();
                level = levels.Remove();
                if (node.GetValue()==v1)
                    Lv1= level;
                if (node.GetValue() == v2)
                    Lv2 = level; 
                if (node.HasLeft())
                {
                    queue.Insert(node.GetLeft());
                    levels.Insert(level + 1);
                }
                if (node.HasRight())
                {
                    queue.Insert(node.GetRight());
                    levels.Insert(level + 1);
                }
            }
            if (Lv1 > Lv2)
                return Lv1 - Lv2;
            else if (Lv2 > Lv1)
                return Lv2 - Lv1;
            return 0;
        }

        //רוחב של עץ מוגדר כמס' הצמתים הגדול ביותר ברמה כלשהי בעץ
        //הפעולה מקבלת עץ בינארי ומחזירה את רוחבו
        public static int WidthOfTree<T>(BinNode<T> root)
        {
        if (root == null)
            return 0;
        int width = 0;
        int count=0;
        int level = 0;
        Queue<BinNode<T>> queue = new Queue<BinNode<T>>();
        BinNode<T> node;
        Queue<int> levels = new Queue<int>();
        queue.Insert(root);
        levels.Insert(level);
        width = 1;
        while (!queue.IsEmpty() )
        {
            node = queue.Remove();
            level = levels.Remove();
            if (node.HasLeft())
            {
                queue.Insert(node.GetLeft());
                levels.Insert(level + 1);
                count++;
            }
            if (node.HasRight())
            {
                queue.Insert(node.GetRight());
                levels.Insert(level + 1);
                count++;
            }
            if (width<count)
                width = count;
            if(levels.IsEmpty()||level!=levels.Head())
                 count = 0; 
        }
        return width;
        
        }
        public static int HighOfTree<T>(BinNode<T> root)
        {
            if (root == null)
                return 0;
            int level = 0;
            Queue<BinNode<T>> queue = new Queue<BinNode<T>>();
            BinNode<T> node;
            Queue<int> levels = new Queue<int>();
            queue.Insert(root);
            levels.Insert(level);
            while (!queue.IsEmpty())
            {
                node = queue.Remove();
                level = levels.Remove();
                if (node.HasLeft())
                {
                    queue.Insert(node.GetLeft());
                    levels.Insert(level + 1);
                }
                if (node.HasRight())
                {
                    queue.Insert(node.GetRight());
                    levels.Insert(level + 1);
                }
            }
            return level;

        }
        public static int WidthOfTreeArray<T>(BinNode<T> root)
        {            
            int high = HighOfTree(root);
            int[] arr = new int[high+1];
            for(int i=0; i<arr.Length; i++)
                arr[i] = 0;
            int level = 0;
            Queue<BinNode<T>> queue = new Queue<BinNode<T>>();
            BinNode<T> node;
            Queue<int> levels = new Queue<int>();
            queue.Insert(root);
            levels.Insert(level);
            while (!queue.IsEmpty())
            {
                node = queue.Remove();
                level = levels.Remove();
                arr[level]+=1;
                if (node.HasLeft())
                {
                    queue.Insert(node.GetLeft());
                    levels.Insert(level + 1);
                }
                if (node.HasRight())
                {
                    queue.Insert(node.GetRight());
                    levels.Insert(level + 1); 
                }
            }
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                    max = arr[i];
            }
            return max;
        }

        //public static bool IsLightTree(BinNode<int> root)
        //{
        //    if(root==null) return false;
        //    bool b = false; 
        //    if (root.HasLeft()&&root.HasRight())
        //    {
        //        BinNode<int> left = root.GetLeft();
        //        BinNode<int> right = root.GetRight();
        //        if (IsLeaf(left)&&IsLeaf(right))
        //        {
        //            if(left.GetValue()>right.GetValue())
        //            {
        //                if (left.GetValue() - right.GetValue() <= 2)
        //                    b=true; 
        //            }
        //            if (left.GetValue() < right.GetValue())
        //            {
        //                if (right.GetValue() - left.GetValue() <= 2)
        //                    b=true;
        //            }
        //            else
        //                return false;
        //        }
        //    }
        //    return IsLightTree(root.GetLeft())&&IsLightTree(root.GetRight()); 
        //}


        #region שאלות חזרה למבחן
        //בגרות 2019 שאלה מספר 6 
        public static bool Order(BinNode<Range> root)
        {
            if (root == null) // אם העץ ריק, להחזיר אמת
                return true;
            //if (root.GetLeft()==null && root.GetRight()==null)
            //    return true;
            if (root.HasLeft() && root.GetLeft().GetValue().GetLow() != root.GetValue().GetLow()) //אם יש לעץ בן שמאלי וגם הבן השמאלי אינו מקיים את התנאים הנדרשים, החזר שקר
                return false;
            if (root.HasLeft() && root.GetValue().GetHigh() < root.GetLeft().GetValue().GetHigh() )
                return false;
            if (root.HasRight() && root.GetRight().GetValue().GetHigh() != root.GetValue().GetHigh()) //אם יש לעץ בן ימני וגם הבן הימני אינו מקיים את התנאים הנדרשים, החזר שקר
                return false;
            if (root.HasRight() && root.GetValue().GetLow() > root.GetRight().GetValue().GetLow())
                return false;
            if(root.HasLeft()&& root.HasRight() && root.GetLeft().GetValue().GetHigh() > root.GetRight().GetValue().GetLow()) //אם יש לעץ שני בנים והבנים אינם מקיימים את התנאי הנדרש, החזר שקר
                return false;
            return Order(root.GetLeft())&&Order(root.GetRight()); //החזר עץ-טווחים אם בן שמאלי של העץ וגם בן ימני של העץ 
        }
        

        //בגרות 2020 שאלה 6
        public static int CountDivisionByThree(BinNode<int> root, int leftovers)//פעולה המחזירה את כמות הצמתים בעץ שמתחלקים ב-3 עם השארית הנתונה 
        {
            if (root == null)
                return 0;
            if(root.GetValue()%3==leftovers)
                return 1+CountDivisionByThree(root.GetLeft(), leftovers)+CountDivisionByThree(root.GetRight(), leftovers);
            else 
                return CountDivisionByThree(root.GetLeft(), leftovers) + CountDivisionByThree(root.GetRight(), leftovers);
        }

        //פעולה הבודקת אם הוא "עץ שאריות שיוויוני" כלומר, אם כמות האיברים המתחלקים ב-3 עם שארית 1 שווה לכמות האיברים המתחלקים ב-3 עם שארית 2 ושווה לכמות האיברים במתחלקים ב-3 ללא שארית 
        public static bool TreeEqual(BinNode<int> root)
        {
            return (CountDivisionByThree(root, 1) == CountDivisionByThree(root, 2) && CountDivisionByThree(root, 1) == CountDivisionByThree(root, 0));
        }


        //בגרות 2020 מועד א' שאלה 6 

        //פעולת עזר המקבלת עץ ומספר שלם ומדפיסה את המסלולים שבעץ  
        public static void PrintAll(BinNode<int> root)
        {
            PrintAll(root, 0);
            //if(root!=null)
            //{
            //    Console.WriteLine(root.GetValue());
            //}
            //PrintAll(root.GetLeft());
            //PrintAll(root.GetRight());
        }
        //פעולה המדפיסה את כל המספרים שהמסלולים בעץ מייצגים
        public static void PrintAll(BinNode<int> root, int num)
        {
            if (root != null)
            {
                num = num * 10 + root.GetValue();
                PrintAll(root.GetLeft(), num);
                PrintAll (root.GetRight(), num);
                if (IsLeaf(root)) { Console.WriteLine(num); }
            }
        }

        /*עץ זיגזג הוא עץ בינארי לא ריק שכל הצמתים מקיימים בדיוק אחד מהכללים הבאים: הצומת הוא שורש העץ,
         * הצומת הוא עלה,  הצומת הוא בן ימני שיש לו בן שמאלי,  הצומת הוא בן שמאלי שיש לו בן ימני
         מהו מספר הצמתים המינימליים בעץ זיגזג? מספר הצמתים המינימלי הוא 2*/
        public static bool IsZigZag<T>(BinNode<T> root)
        {
            if ((root == null) || (IsLeaf(root)))
                return false;
            return (IsZigZag(root.GetLeft(), 1) && IsZigZag(root.GetRight(),2));    
        }
        public static bool IsZigZag<T>(BinNode<T> root, int LeftOrRight)
        {
            if ((root == null) || (IsLeaf(root)))
                return true;
            if(LeftOrRight==1)
            {
                if(!root.HasRight())
                    return false;
            }
            if(LeftOrRight==2)
            {
                if(!root.HasLeft())
                    return false;
            }
            return (IsZigZag(root.GetLeft(), 1) && IsZigZag(root.GetRight(), 2));
        }

        /*עץ ממוין שכבתי הינו עץ ריק, או עץ שסכום האיברים בכל רמה בו קטן מסכום כל האיברים ברמה שמתחתיה. 
         * (סכום האיברים ברמה n קטן מסכום האיברים ברמה n+1)
         * האם כל אחד מהעצים הבאים הוא עץ ממוין שכבתי? נמקו
         כתוב פעולה המקבלת עץ ומחזירה אמת אם העץ הינו עץ ממוין שכבתי ושקר אחרת*/
        public static bool IsLayeredSortedTree(BinNode<int> root)
        {
            if (root == null) return true;
            int beforeSum = root.GetValue();
            int cuurentSum = 0;
            int level = 0;
            Queue<BinNode<int>> queue = new Queue<BinNode<int>>();
            BinNode<int> node;
            Queue<int> levels = new Queue<int>();
            queue.Insert(root);
            levels.Insert(level);
            while (!queue.IsEmpty())
            {
                node = queue.Remove();
                if(level != levels.Head())
                {
                    if (cuurentSum <= beforeSum)
                        return false;
                    beforeSum = cuurentSum;
                    cuurentSum = 0;
                }
                level = levels.Remove();
                if (node.HasLeft())
                {
                    queue.Insert(node.GetLeft());
                    cuurentSum += node.GetLeft().GetValue();
                    levels.Insert(level + 1);
                }
                if (node.HasRight())
                {
                    queue.Insert(node.GetRight());
                    cuurentSum += node.GetRight().GetValue();
                    levels.Insert(level + 1);
                }
            }
            return true;
        }
        
        /*עץ בוסר מוגדר כך: עלה או שורש ושני בנים,
         * שכל אחד מהם הוא עץ בוסר, 
         * כך שערכו של הבן הימני גדול מערכו של הבן השמאלי, 
         * וערכיהם של שניהם גדולים מערך השורש.*/
        public static bool IsUnripeTree(BinNode<int> root)//לא החזרתי אמת בכלל... אז איך זה בעצם יעבוד?
        {
            if(root == null) return false;  
            if(!IsLeaf(root)||!(root.HasLeft()&&root.HasRight())) return false;
            if (root.HasLeft() && root.HasRight())
            {
               int sum = root.GetRight().GetValue() + root.GetLeft().GetValue();
               if (root.GetRight().GetValue()<root.GetLeft().GetValue() || sum<root.GetValue()) return false;
            }
            return IsUnripeTree(root.GetLeft())&&IsUnripeTree(root.GetRight());
        }
        /*עץ אומגה מוגדר כך: עלה, או שורש ושני בנים שכל אחד מהם הוא עץ אומגה 
         כך שערך השורש קטן או שווה לסכום ערכי כל הצמתים בתת עץ השמאלי שלו 
        וגדול או שווה לסכום ערכי כל הצמתים בתת עץ הימני שלו. */
        public static bool IsOmegaTree(BinNode<int> T)
        {
            if(T == null) return true;
            if ((T.GetValue() > SumLeftOrRight(T.GetLeft())) && (T.GetValue() < SumLeftOrRight(T.GetLeft())))
                return false;
            return IsOmegaTree(T.GetLeft())&&IsOmegaTree(T.GetRight());
        }
        public static int SumLeftOrRight(BinNode<int> T)
        {
            if(T==null) return 0;
            return T.GetValue()+SumLeftOrRight(T.GetLeft())+ T.GetValue() + SumLeftOrRight(T.GetRight());
        }

        //בגרות 2022 שאלה 7
        //פעולה המחזירה את המחרוזת ללא התו הראשון, הפעולה נתונה ולא צריך לממש אותה  
        public static string EraseFirst(string str)
        { return ""; }
        //פעולה המחזירה אמת אם קיים בעץ מסלול המתחיל בשורש
        //ומכיל את כל האותיות של המילה הנתונה, ושקר אחרת
        public static bool WordFromRoot(BinNode<char> tree, string str)
        {
            if (str == "")
                return true;
            if(tree==null) 
                return false;
            if (tree.GetValue() != str[0])
                return false;
            str = EraseFirst(str);
            return WordFromRoot(tree.GetLeft(),str)||WordFromRoot(tree.GetRight(),str);
        }
        #endregion

        #region חיפוש עץ בינארי
        public static BinNode<int> InsertToSearchTree(BinNode<int> root, int x)
        {
            if (root == null)
               return new BinNode<int>(x);
            if(root.GetValue()>x)
                root.SetLeft(InsertToSearchTree(root.GetLeft(), x));
            
            else
                root.SetRight(InsertToSearchTree(root.GetRight(), x));
            return root; 
        }
        //public static int CountNode<T>(BinNode<T> root)
        //{
        //    int count = 0;
        //    if (root == null)
        //        return count;
        //    count++;
        //    count = 1 + CountNode(root.GetLeft()) + CountNode(root.GetRight());
        //    return count;
        //}
        //  public static int[] ImsertArray(BinNode<int> root)

        
        public static bool IsSearchTree(BinNode<int> root)
        {
            if (root == null)
                return true;
            if(root.HasLeft())
            {
                if (root.GetValue() <= MaxBradthSearch(root.GetLeft()))
                    return false;
            }
            if(root.HasRight())
            {
                if (root.GetValue() > MinBradthSearch(root.GetRight()))
                    return false;
            }
            return IsSearchTree(root.GetLeft()) && IsSearchTree(root.GetRight());
        }



        #endregion
    }

}
