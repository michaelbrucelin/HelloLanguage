using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public static class BinarySearch
    {
        #region 整型数组
        /// <summary>
        /// 二分查找目标值，如果目标值存在，返回对应的索引，如果不存在，返回-1
        /// 假定数组已排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] arr, int target)
        {
            return Search(arr, 0, arr.Length - 1, target);
        }

        /// <summary>
        /// 二分查找目标值，如果目标值存在，返回对应的索引，如果不存在，返回-1
        /// 假定数组已排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] arr, int left, int right, int target)
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target) return mid;
                else if (arr[mid] < target) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }

        /// <summary>
        /// 二分查找目标值的左边界
        /// 即如果小于等于目标值的值存在，返回最后1个对应的索引，如果不存在，返回-1
        /// 假定数组已排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="target"></param>
        /// <param name="equal">true, 返回最后1个小于等于目标值的索引，否则，返回最后1个小于目标值的索引</param>
        /// <returns></returns>
        public static int SearchLeftBorder(int[] arr, int target, bool equal)
        {
            return SearchLeftBorder(arr, 0, arr.Length - 1, target, equal);
        }

        /// <summary>
        /// 二分查找目标值的左边界
        /// 即如果小于等于目标值的值存在，返回最后1个对应的索引，如果不存在，返回-1
        /// 假定数组已排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <param name="equal">true, 返回最后1个小于等于目标值的索引，否则，返回最后1个小于目标值的索引</param>
        /// <returns></returns>
        public static int SearchLeftBorder(int[] arr, int left, int right, int target, bool equal)
        {
            int result = left - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] < target || (equal && arr[mid] <= target))
                {
                    left = mid + 1;
                    result = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }

        /// <summary>
        /// 二分查找目标值的右边界
        /// 即如果大于等于目标值的值存在，返回第1个对应的索引，如果不存在，返回数组的长度
        /// 假定数组已排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="target"></param>
        /// <param name="equal">true, 返回第1个大于等于目标值的索引，否则，返回第1个大于目标值的索引</param>
        /// <returns></returns>
        public static int SearchRightBorder(int[] arr, int target, bool equal)
        {
            return SearchRightBorder(arr, 0, arr.Length - 1, target, equal);
        }

        /// <summary>
        /// 二分查找目标值的右边界
        /// 即如果大于等于目标值的值存在，返回第1个对应的索引，如果不存在，返回数组的长度
        /// 假定列表已排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <param name="equal">true, 返回第1个大于等于目标值的索引，否则，返回第1个大于目标值的索引</param>
        /// <returns></returns>
        public static int SearchRightBorder(int[] arr, int left, int right, int target, bool equal)
        {
            int result = right + 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] > target || (equal && arr[mid] >= target))
                {
                    right = mid - 1;
                    result = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }
        #endregion

        #region 泛型列表
        /// <summary>
        /// 二分查找目标值，如果目标值存在，返回对应的索引，如果不存在，返回-1
        /// 假定列表已排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search<T>(IList<T> list, T target) where T : IComparable
        {
            return Search<T>(list, 0, list.Count - 1, target);
        }

        /// <summary>
        /// 二分查找目标值，如果目标值存在，返回对应的索引，如果不存在，返回-1
        /// 假定列表已排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search<T>(IList<T> list, int left, int right, T target) where T : IComparable
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int flag = list[mid].CompareTo(target);
                if (flag == 0) return mid;
                else if (flag < 0) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }

        /// <summary>
        /// 二分查找目标值的左边界
        /// 即如果小于等于目标值的值存在，返回最后1个对应的索引，如果不存在，返回-1
        /// 假定列表已排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="target"></param>
        /// <param name="equal">true, 返回最后1个小于等于目标值的索引，否则，返回最后1个小于目标值的索引</param>
        /// <returns></returns>
        public static int SearchLeftBorder<T>(IList<T> list, T target, bool equal) where T : IComparable
        {
            return SearchLeftBorder(list, 0, list.Count - 1, target, equal);
        }

        /// <summary>
        /// 二分查找目标值的左边界
        /// 即如果小于等于目标值的值存在，返回最后1个对应的索引，如果不存在，返回-1
        /// 假定列表已排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <param name="equal">true, 返回最后1个小于等于目标值的索引，否则，返回最后1个小于目标值的索引</param>
        /// <returns></returns>
        public static int SearchLeftBorder<T>(IList<T> list, int left, int right, T target, bool equal) where T : IComparable
        {
            int result = left - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (list[mid].CompareTo(target) < 0 || (equal && list[mid].CompareTo(target) <= 0))
                {
                    left = mid + 1;
                    result = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }

        /// <summary>
        /// 二分查找目标值的右边界
        /// 即如果大于等于目标值的值存在，返回第1个对应的索引，如果不存在，返回列表的容量
        /// 假定列表已排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="target"></param>
        /// <param name="equal">true, 返回第1个大于等于目标值的索引，否则，返回第1个大于目标值的索引</param>
        /// <returns></returns>
        public static int SearchRightBorder<T>(IList<T> list, T target, bool equal) where T : IComparable
        {
            return SearchRightBorder(list, 0, list.Count - 1, target, equal);
        }

        /// <summary>
        /// 二分查找目标值的右边界
        /// 即如果大于等于目标值的值存在，返回第1个对应的索引，如果不存在，返回列表的容量
        /// 假定列表已排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <param name="equal">true, 返回第1个大于等于目标值的索引，否则，返回第1个大于目标值的索引</param>
        /// <returns></returns>
        public static int SearchRightBorder<T>(IList<T> list, int left, int right, T target, bool equal) where T : IComparable
        {
            int result = right + 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (list[mid].CompareTo(target) > 0 || (equal && list[mid].CompareTo(target) >= 0))
                {
                    right = mid - 1;
                    result = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }
        #endregion
    }
}
