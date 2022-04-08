using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;

namespace WindowsFormsApp0
{
    public static class MyUtilsExMethods
    {
        //this String s
        //this表示当前这个方法，即MyIsEmail
        //String表示方法是String这个类的扩展方法
        //s表示当前的调用者，i.ToString();，这里的i就是调用者
        public static bool MyIsEmail(this String s)
        {
            return Regex.IsMatch(s, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");
        }

        public static bool MyIsInt(this String s)
        {
            return Regex.IsMatch(s, @"^\d+$");
        }

        public static bool MyIsFloat(this String s)
        {
            return Regex.IsMatch(s, @"^[0-9\.]+$");
        }

        //整型的长度
        public static int MyLength(this int i)
        {
            if (i < 0)
                throw new ArgumentOutOfRangeException();
            if (i == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(i)) + 1;
        }

        public static int MyLength(this uint i)
        {
            if (i == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(i)) + 1;
        }

        public static int MyLength(this long i)
        {
            if (i < 0)
                throw new ArgumentOutOfRangeException();
            if (i == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(i)) + 1;
        }

        public static int MyLength(this ulong i)
        {
            if (i == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(i)) + 1;
        }

        //整型是否以另一个整型开头
        public static bool MyStartsWith(this int i, int x)
        {
            if (i < 0 || x < 0)
                throw new ArgumentOutOfRangeException();

            if (i == 0 && x == 0)
                return true;
            else if (i == 0 || x == 0 || i < x)
                return false;
            else
            {
                //int diff = (int)Math.Log10(i) - (int)Math.Log10(x);
                int diff = i.MyLength() - x.MyLength();

                if (x == i / (int)Math.Pow(10, diff))
                    return true;
                else
                    return false;
            }
        }

        public static bool MyStartsWith(this uint i, uint x)
        {
            if (i == 0 && x == 0)
                return true;
            else if (i == 0 || x == 0 || i < x)
                return false;
            else
            {
                //int diff = (int)Math.Log10(i) - (int)Math.Log10(x);
                int diff = i.MyLength() - x.MyLength();

                if (x == i / (uint)Math.Pow(10, diff))
                    return true;
                else
                    return false;
            }
        }

        public static bool MyStartsWith(this long i, long x)
        {
            if (i < 0 || x < 0)
                throw new ArgumentOutOfRangeException();

            if (i == 0 && x == 0)
                return true;
            else if (i == 0 || x == 0 || i < x)
                return false;
            else
            {
                //int diff = (int)Math.Log10(i) - (int)Math.Log10(x);
                int diff = i.MyLength() - x.MyLength();

                if (x == i / (long)Math.Pow(10, diff))
                    return true;
                else
                    return false;
            }
        }

        public static bool MyStartsWith(this ulong i, ulong x)
        {
            if (i == 0 && x == 0)
                return true;
            else if (i == 0 || x == 0 || i < x)
                return false;
            else
            {
                //int diff = (int)Math.Log10(i) - (int)Math.Log10(x);
                int diff = i.MyLength() - x.MyLength();

                if (x == i / (ulong)Math.Pow(10, diff))
                    return true;
                else
                    return false;
            }
        }

        //List随机排序
        public static void MyRandomOrder<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = MyUtils.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        //List转DataTable
        public static DataTable MyToDataTable<T>(this IList<T> data)
        {
            DataTable dt = new DataTable();

            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {
                DataColumn dc = new DataColumn("Value");
                dt.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = item;
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in props)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }

                foreach (T item in data)
                {
                    DataRow dr = dt.NewRow();
                    foreach (PropertyDescriptor prop in props)
                    {
                        try
                        {
                            dr[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception)
                        {
                            dr[prop.Name] = DBNull.Value;
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
    }
}
