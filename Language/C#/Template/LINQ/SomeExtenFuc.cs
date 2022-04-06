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
    }
}