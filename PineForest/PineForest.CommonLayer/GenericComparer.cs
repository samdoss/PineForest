//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Reflection;

//namespace PineForest.CommonLayer
//{
//    public class GenericComparer
//    {
//        public List<GenericComparer> comparers { get; set; }
//        int level = 0;

//        public SortDirection SortDirection { get; set; }
//        public PropertyInfo PropertyInfo { get; set; }

//        public int Compare<T>(T t1, T t2)
//        {
//            int ret = 0;

//            if (level >= comparers.Count)
//                return 0;

//            object t1Value = comparers[level].PropertyInfo.GetValue(t1, null);
//            object t2Value = comparers[level].PropertyInfo.GetValue(t2, null);

//            if (t1 == null || t1Value == null)
//            {
//                if (t2 == null || t2Value == null)
//                {
//                    ret = 0;
//                }
//                else
//                {
//                    ret = -1;
//                }
//            }
//            else
//            {
//                if (t2 == null || t2Value == null)
//                {
//                    ret = 1;
//                }
//                else
//                {
//                    ret = ((IComparable)t1Value).CompareTo(((IComparable)t2Value));
//                }
//            }
//            if (ret == 0)
//            {
//                level += 1;
//                ret = Compare(t1, t2);
//                level -= 1;
//            }
//            else
//            {
//                if (comparers[level].SortDirection == SortDirection.Descending)
//                {
//                    ret *= -1;
//                }
//            }
//            return ret;
//        }
//    }
//}
