//using System;
//using System.Data;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Reflection;
//using System.Configuration;
//using System.Collections;

//namespace PineForest.CommonLayer
//{
//        public static int Sort<T>(this List<T> list, string sortExpression)
//        {
//            string[] sortExpressions = sortExpression.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

//            List<GenericComparer> comparers = new List<GenericComparer>();
            
//            foreach (string sortExpress in sortExpressions)
//            {
//                string sortProperty = sortExpress.Trim().Split(' ')[0].Trim();
//                string sortDirection = sortExpress.Trim().Split(' ')[1].Trim();

//                Type type = typeof(T);
//                PropertyInfo PropertyInfo = type.GetProperty(sortProperty);
//                if (PropertyInfo == null)
//                {
//                    PropertyInfo[] props = type.GetProperties();
//                    foreach (PropertyInfo info in props)
//                    {
//                        if (info.Name.ToString().ToLower() == sortProperty.ToLower())
//                        {
//                            PropertyInfo = info;
//                            break;
//                        }
//                    }
//                    if (PropertyInfo == null)
//                    {
//                        throw new Exception(String.Format("{0} is not a valid property of type: \"{1}\"", sortProperty,type.Name));
//                    }
//                }

//                SortDirection SortDirection = SortDirection.Ascending;
//                if (sortDirection.ToLower() == "asc" || sortDirection.ToLower() == "ascending")
//                {
//                    SortDirection = SortDirection.Ascending;
//                }
//                else if (sortDirection.ToLower() == "desc" || sortDirection.ToLower() == "descending")
//                {
//                    SortDirection = SortDirection.Descending;
//                }
//                else
//                {
//                    throw new Exception("Valid SortDirections are: asc, ascending, desc and descending");
//                }

//                comparers.Add(new GenericComparer { SortDirection = SortDirection, PropertyInfo = PropertyInfo, comparers = comparers });
//            }
//            list.Sort(comparers[0].Compare);
//        }

//        public class GenericComparer
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
