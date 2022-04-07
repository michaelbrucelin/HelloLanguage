using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// 这里整理了一些常用的LINQ的扩展方法
/// </summary>
namespace MyLinqInAction
{
    public static class MyLinqExtensions
    {
        /// <summary>
        /// 直接应用于LINQ的ForEach方法，摘自于《LINQ实战》 page:141
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> func)
        {
            foreach (var item in source)
                func(item);
        }

        /// <summary>
        /// 配合LINQ使用，逐行遍历文本文件，摘自于《LINQ实战》 page:143
        /// </summary>
        public static IEnumerable<String> Lines(this StreamReader source)
        {
            String line;

            if (source == null)
                throw new ArgumentNullException("source");

            while ((line = source.ReadLine()) != null)
                yield return line;
        }

        /// <summary>
        /// 直接应用于LINQ的方法，获取元素某个属性最大值的那个元素，摘自于《LINQ实战》 page:147
        /// Linq内建的方法只能获取属性的最大值，而不能获取对应的那个元素
        /// </summary>
        public static TElement MaxElement<TElement, TData>(this IEnumerable<TElement> source, Func<TElement, TData> selector) where TData : IComparable<TData>
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            Boolean firstElement = true;
            TElement result = default(TElement);
            TData maxValue = default(TData);
            foreach (TElement element in source)
            {
                var candidate = selector(element);
                if (firstElement || (candidate.CompareTo(maxValue) > 0))
                {
                    firstElement = false;
                    maxValue = candidate;
                    result = element;
                }
            }
            return result;
        }
    }
}