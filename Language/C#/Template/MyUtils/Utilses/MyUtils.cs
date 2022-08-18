using Microsoft.International.Converters.PinYinConverter;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp0
{
    public static class MyUtils
    {
        private static Random random = new Random();

        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }

        public static Random GetRandomWithGuid()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iRoot = BitConverter.ToInt32(buffer, 0);
            return new Random(iRoot);
        }

        // 随机枚举值
        public static T GetRandomEnum<T>()
        {
            T[] values = (T[])Enum.GetValues(typeof(T));
            return values[random.Next(0, values.Length)];
        }

        // 生成随机字符串
        public static string GetRandomString(int length)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // 生成随机字符串
        public static string GetRandomString(string chars, int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // 返回随机颜色
        public static Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }

        // 返回随机字体
        public static Font GetRandomFont(int minFontSize, int maxFontSize)
        {
            string[] fonts = { "Arial", "Verdana", "Comic Sans MS", "Impact", "Haettenschweiler", "Lucida Sans Unicode", "Garamond", "Courier New", "Book Antiqua", "Arial Narrow" };
            if (minFontSize >= maxFontSize)
            {
                return new Font(fonts[random.Next(0, fonts.Length)], minFontSize, GetRandomEnum<FontStyle>());
            }
            else
            {
                return new Font(fonts[random.Next(0, fonts.Length)], random.Next(minFontSize, maxFontSize + 1), GetRandomEnum<FontStyle>());
            }
        }

        // 字符串按照指定长度拆分为数组，如果最后一项长度不够，是否保留
        public enum StrSplitByChunkOption { keep, remove };
        // 字符串按照指定长度拆分为数组
        public static IEnumerable<string> StrSplitByChunk(string str, int chunkSize, StrSplitByChunkOption option)
        {
            if (option == StrSplitByChunkOption.keep)
            {
                int cnt = (int)Math.Ceiling(str.Length * 1.0 / chunkSize);
                return Enumerable.Range(0, cnt)
                    .Select(i => str.Substring(i * chunkSize, Math.Min(chunkSize, str.Length - chunkSize * i)));
            }
            else if (option == StrSplitByChunkOption.remove)
            {
                return Enumerable.Range(0, str.Length / chunkSize)
                    .Select(i => str.Substring(i * chunkSize, chunkSize));
            }
            else
            { return null; }
        }

        // 字符串替换
        // [[0n]]—>n位随机数字；
        // [[an]]—>n位随机小写字母；[[An]]—>n位随机大写字母；[[aAn]]—>n位随机字母（随机大小写）；
        // [[n]] —>n位随机数字字母（随机大小写）；
        // [[na]]—>n位随机数字字母（小写）；[[nA]]—>n位随机数字字母（大写）；
        // 以上结构不允许嵌套，即[[[0n]]]无效；
        public static string ReplaceMaskStr(string input)
        {
            string chars_0 = "0123456789";
            string chars_a = "abcdefghijklmnopqrstuvwxyz";
            string chars_A = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string chars_aA = chars_a + chars_A;
            string chars_0a = chars_0 + chars_a;
            string chars_0A = chars_0 + chars_A;
            string chars_0aA = chars_0 + chars_a + chars_A;

            // [[0n]]
            input = Regex.Replace(input, @"(?<!\[)\[\[0(\d)\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_0, Convert.ToInt32(match.Groups[1].Value))
                                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[an]]
            input = Regex.Replace(input, @"(?<!\[)\[\[a(\d)\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_a, Convert.ToInt32(match.Groups[1].Value))
                                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[An]]
            input = Regex.Replace(input, @"(?<!\[)\[\[A(\d)\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_A, Convert.ToInt32(match.Groups[1].Value))
                                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[aAn]]
            input = Regex.Replace(input, @"(?<!\[)\[\[aA(\d)\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_aA, Convert.ToInt32(match.Groups[1].Value))
                                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[n]]
            input = Regex.Replace(input, @"(?<!\[)\[\[(\d)\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_0aA, Convert.ToInt32(match.Groups[1].Value))
                                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[na]]
            input = Regex.Replace(input, @"(?<!\[)\[\[(\d)a\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_0a, Convert.ToInt32(match.Groups[1].Value))
                                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[nA]]
            input = Regex.Replace(input, @"(?<!\[)\[\[(\d)A\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_0A, Convert.ToInt32(match.Groups[1].Value))
                                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }));

            return input;
        }

        // OpenFileDialog
        public static string OpenFile(string filter)
        {
            string filePath = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = MyUtilsResources.StaticFilePath,
                Filter = filter
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }

            return filePath;
        }

        // OpenFileDialog
        public static string OpenFile(string filter, string initDir)
        {
            string filePath = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = initDir,
                Filter = filter
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }

            return filePath;
        }

        // SaveFileDialog
        public static string SaveFile(string filter)
        {
            string filePath = string.Empty;
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = filter
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filePath = sfd.FileName;
            }

            return filePath;
        }

        // SaveFileDialog
        public static string SaveFile(string filter, string initDir)
        {
            string filePath = string.Empty;
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = filter,
                InitialDirectory = initDir
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filePath = sfd.FileName;
            }

            return filePath;
        }


        // 生成随机DataTable，基本方法
        // colTypes表示列的数据类型，true表示该字段为string，false表示该字段为int
        public static DataTable GetRandomDataTable(bool[] colTypes, int rowCnt, int strLength, int intMin, int intMax)
        {
            // 保证随机的时候可以取到上界
            intMax++;

            DataTable dt = new DataTable();

            int colCnt = colTypes.Length;
            for (int i = 0; i < colCnt; i++)
            {
                if (colTypes[i])
                {
                    dt.Columns.Add("COL" + i.ToString());
                }
                else
                {
                    dt.Columns.Add("COL" + i.ToString(), typeof(int));
                }
            }
            for (int i = 0; i < rowCnt; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < colCnt; j++)
                {
                    if (colTypes[j])
                    {
                        dr[j] = GetRandomString(strLength);
                    }
                    else
                    {
                        dr[j] = random.Next(intMin, intMax);
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }

        // 生成随机DataTable，纯字符串
        public static DataTable GetRandomDataTable(int colCnt, int rowCnt, int strLength)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < colCnt; i++)
            {
                dt.Columns.Add("COL" + i.ToString());
            }
            for (int i = 0; i < rowCnt; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < colCnt; j++)
                {
                    dr[j] = GetRandomString(strLength);
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }

        // 生成随机DataTable，纯数字
        public static DataTable GetRandomDataTable(int colCnt, int rowCnt, int intMin, int intMax)
        {
            // 保证随机的时候可以取到上界
            intMax++;

            DataTable dt = new DataTable();
            for (int i = 0; i < colCnt; i++)
            {
                dt.Columns.Add("COL" + i.ToString(), typeof(int));
            }
            for (int i = 0; i < rowCnt; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < colCnt; j++)
                {
                    dr[j] = random.Next(intMin, intMax);
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }

        // 生成随机DataTable，随机字符串和数字
        public static DataTable GetRandomDataTable(int colCnt, int rowCnt, int strLength, int intMin, int intMax)
        {
            // true表示该字段为string，false表示该字段为int
            bool[] colTypes = new bool[colCnt];
            for (int i = 0; i < colCnt; i++)
            {
                colTypes[i] = random.Next(0, 99) % 2 == 0;
            }

            return GetRandomDataTable(colTypes, rowCnt, strLength, intMin, intMax);
        }

        // List随机排序
        public static void ListRandomOrder<T>(ref List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // List转DataTable
        public static DataTable ListToDataTable<T>(IList<T> data)
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

        // DataTable去重复，按照全局（所有列）去重复
        public static void DataTableDistinct(ref DataTable dt)
        {
            DataView view = new DataView(dt);
            string[] colNames = dt.Columns.Cast<DataColumn>()
                                          .Select(x => x.ColumnName)
                                          .ToArray();

            // dt = new DataTable();
            DataTable dtTemp = view.ToTable(true, colNames);
            dt = dtTemp;
        }

        // DataTable去重复，按照全局（所有列）去重复
        public static DataTable DataTableDistinct(DataTable dt)
        {
            DataTable dtRs = new DataTable();

            DataView view = new DataView(dt);
            string[] colNames = dt.Columns.Cast<DataColumn>()
                                          .Select(x => x.ColumnName)
                                          .ToArray();

            dtRs = view.ToTable(true, colNames);

            return dtRs;
        }

        // DataTable去重复，按照第n列去重复
        public enum DTDistinctKeep { first, last };
        public static void DataTableDistinct(ref DataTable dt, int keyIndex, DTDistinctKeep keep)
        {
            if (keyIndex >= 0 && keyIndex < dt.Columns.Count)
            {
                string keyStr;
                if (keep == DTDistinctKeep.first)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        keyStr = dt.Rows[i][keyIndex].ToString();
                        for (int j = i + 1; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j][keyIndex].ToString() == keyStr)
                            {
                                dt.Rows.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }
                else if (keep == DTDistinctKeep.last)
                {
                    int step;
                    for (int i = dt.Rows.Count - 1; i >= 0; i -= step)
                    {
                        step = 1;
                        keyStr = dt.Rows[i][keyIndex].ToString();
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (dt.Rows[j][keyIndex].ToString() == keyStr)
                            {
                                dt.Rows.RemoveAt(j);
                                step++;
                            }
                        }
                    }
                }
            }
        }

        // DataTable去重复，按照指定列去重复
        public static void DataTableDistinct(ref DataTable dt, string keyName, DTDistinctKeep keep)
        {
            int keyIndex = -1;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == keyName)
                {
                    keyIndex = i;
                    break;
                }
            }

            if (keyIndex == -1)
            {
                DataTableDistinct(ref dt);
            }
            else
            {
                DataTableDistinct(ref dt, keyIndex, keep);
            }
        }

        // DataTable去重复，按照第n列去重复
        public static DataTable DataTableDistinct(DataTable dt, int keyIndex, DTDistinctKeep keep)
        {
            DataTable dtRs = dt.Copy();

            if (keyIndex >= 0 && keyIndex < dt.Columns.Count)
            {
                string keyStr;
                if (keep == DTDistinctKeep.first)
                {
                    for (int i = 0; i < dtRs.Rows.Count; i++)
                    {
                        keyStr = dtRs.Rows[i][keyIndex].ToString();
                        for (int j = i + 1; j < dtRs.Rows.Count; j++)
                        {
                            if (dtRs.Rows[j][keyIndex].ToString() == keyStr)
                            {
                                dtRs.Rows.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }
                else if (keep == DTDistinctKeep.last)
                {
                    int step;
                    for (int i = dtRs.Rows.Count - 1; i >= 0; i -= step)
                    {
                        step = 1;
                        keyStr = dtRs.Rows[i][keyIndex].ToString();
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (dtRs.Rows[j][keyIndex].ToString() == keyStr)
                            {
                                dtRs.Rows.RemoveAt(j);
                                step++;
                            }
                        }
                    }
                }
            }

            return dtRs;
        }

        // DataTable去重复，按照指定列去重复
        public static DataTable DataTableDistinct(DataTable dt, string keyName, DTDistinctKeep keep)
        {
            int keyIndex = -1;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == keyName)
                {
                    keyIndex = i;
                    break;
                }
            }

            if (keyIndex == -1)
            {
                return DataTableDistinct(dt);
            }
            else
            {
                return DataTableDistinct(dt, keyIndex, keep);
            }
        }

        // DataTable去重复，按照指定的几列（id）去重复，没做测试
        private static bool DataTableDistinctVerifyRow(Dictionary<int, string> dic, DataRow dr)
        {
            bool flag = true;
            foreach (int item in dic.Keys)
            {
                if (dic[item] != dr[item].ToString())
                {
                    return false;
                }
            }

            return flag;
        }
        public static void DataTableDistinct(ref DataTable dt, int[] keyIndexes, DTDistinctKeep keep)
        {
            if (keyIndexes.Length == 0)
            {
                DataTableDistinct(ref dt);
            }
            else if (keyIndexes.Length == 1)
            {
                DataTableDistinct(ref dt, keyIndexes[0], keep);
            }
            else
            {
                keyIndexes = keyIndexes.Distinct().OrderBy(o => o).ToArray();
                if (keyIndexes.Min() >= 0 && keyIndexes.Max() < dt.Columns.Count)
                {
                    Dictionary<int, string> dic = new Dictionary<int, string>();
                    if (keep == DTDistinctKeep.first)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dic.Clear();
                            foreach (int item in keyIndexes)
                            {
                                dic.Add(item, dt.Rows[i][item].ToString());
                            }
                            for (int j = i + 1; j < dt.Rows.Count; j++)
                            {
                                if (DataTableDistinctVerifyRow(dic, dt.Rows[j]))
                                {
                                    dt.Rows.RemoveAt(j);
                                    j--;
                                }
                            }
                        }
                    }
                    else if (keep == DTDistinctKeep.last)
                    {
                        int step;
                        for (int i = dt.Rows.Count - 1; i >= 0; i -= step)
                        {
                            step = 1;
                            dic.Clear();
                            foreach (int item in keyIndexes)
                            {
                                dic.Add(item, dt.Rows[i][item].ToString());
                            }
                            for (int j = i - 1; j >= 0; j--)
                            {
                                if (DataTableDistinctVerifyRow(dic, dt.Rows[j]))
                                {
                                    dt.Rows.RemoveAt(j);
                                    step++;
                                }
                            }
                        }
                    }
                }
            }
        }

        // DataTable去重复，按照指定的几列（列名）去重复，没做测试
        public static void DataTableDistinct(ref DataTable dt, string[] keyNames, DTDistinctKeep keep)
        {
            List<int> list = new List<int>();

            keyNames = keyNames.Distinct().ToArray();
            foreach (string item in keyNames)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].ColumnName == item)
                    {
                        list.Add(i);
                        break;
                    }
                }
            }

            if (list.Count == 0)
            {
                DataTableDistinct(ref dt);
            }
            else if (list.Count == 1)
            {
                DataTableDistinct(ref dt, list[0], keep);
            }
            else
            {
                DataTableDistinct(ref dt, list.ToArray(), keep);
            }
        }

        // DataTable去重复，按照指定的几列（id）去重复，没做测试
        public static DataTable DataTableDistinct(DataTable dt, int[] keyIndexes, DTDistinctKeep keep)
        {
            DataTable dtRs = dt.Copy();

            if (keyIndexes.Length == 0)
            {
                return DataTableDistinct(dtRs);
            }
            else if (keyIndexes.Length == 1)
            {
                return DataTableDistinct(dtRs, keyIndexes[0], keep);
            }
            else
            {
                keyIndexes = keyIndexes.Distinct().OrderBy(o => o).ToArray();
                if (keyIndexes.Min() >= 0 && keyIndexes.Max() < dtRs.Columns.Count)
                {
                    Dictionary<int, string> dic = new Dictionary<int, string>();
                    if (keep == DTDistinctKeep.first)
                    {
                        for (int i = 0; i < dtRs.Rows.Count; i++)
                        {
                            dic.Clear();
                            foreach (int item in keyIndexes)
                            {
                                dic.Add(item, dtRs.Rows[i][item].ToString());
                            }
                            for (int j = i + 1; j < dtRs.Rows.Count; j++)
                            {
                                if (DataTableDistinctVerifyRow(dic, dtRs.Rows[j]))
                                {
                                    dtRs.Rows.RemoveAt(j);
                                    j--;
                                }
                            }
                        }
                    }
                    else if (keep == DTDistinctKeep.last)
                    {
                        int step;
                        for (int i = dtRs.Rows.Count - 1; i >= 0; i -= step)
                        {
                            step = 1;
                            dic.Clear();
                            foreach (int item in keyIndexes)
                            {
                                dic.Add(item, dtRs.Rows[i][item].ToString());
                            }
                            for (int j = i - 1; j >= 0; j--)
                            {
                                if (DataTableDistinctVerifyRow(dic, dtRs.Rows[j]))
                                {
                                    dtRs.Rows.RemoveAt(j);
                                    step++;
                                }
                            }
                        }
                    }
                }
            }

            return dtRs;
        }

        // DataTable去重复，按照指定的几列（列名）去重复，没做测试
        public static DataTable DataTableDistinct(DataTable dt, string[] keyNames, DTDistinctKeep keep)
        {
            List<int> list = new List<int>();

            keyNames = keyNames.Distinct().ToArray();
            foreach (string item in keyNames)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].ColumnName == item)
                    {
                        list.Add(i);
                        break;
                    }
                }
            }

            if (list.Count == 0)
            {
                return DataTableDistinct(dt);
            }
            else if (list.Count == 1)
            {
                return DataTableDistinct(dt, list[0], keep);
            }
            else
            {
                return DataTableDistinct(dt, list.ToArray(), keep);
            }
        }

        public static void DataTableDistinct(ref DataTable dt, DTDistinctKeep keep, params int[] keyIndexes)
        {
            DataTableDistinct(ref dt, keyIndexes, keep);
        }

        public static DataTable DataTableDistinct(DataTable dt, DTDistinctKeep keep, params int[] keyIndexes)
        {
            return DataTableDistinct(dt, keyIndexes, keep);
        }

        // DataTable按照指定的条件删除行，不要用Delete，以免.Net版本升级增加了Delete方法导致冲突
        public static DataTable MyDelete(this DataTable table, string filter)
        {
            table.Select(filter).Delete();
            return table;
        }
        private static void Delete(this IEnumerable<DataRow> rows)
        {
            foreach (var row in rows)
                row.Delete();
        }

        // 实现TextBox只能输入数字，或只能输入数字和.，应用于TextBox的KeyPress事件
        public enum KeyControlOption { OnlyNumber, NumberAndDot }
        public static void TextBox_KeyControl(object sender, KeyPressEventArgs e, KeyControlOption keyControlOption)
        {
            if (keyControlOption == KeyControlOption.OnlyNumber)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (keyControlOption == KeyControlOption.NumberAndDot)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        public enum KeyLimitedOption { Allow, Deny }
        public static void TextBox_KeyControl(object sender, KeyPressEventArgs e, char[] chars, KeyLimitedOption keyLimitedOption)
        {
            if (keyLimitedOption == KeyLimitedOption.Allow)
            {
                bool handled = true;

                if (char.IsControl(e.KeyChar))
                {
                    handled = false;
                }
                else
                {
                    foreach (char item in chars)
                    {
                        if (e.KeyChar == item)
                        {
                            handled = false;
                            break;
                        }
                    }
                }

                if (handled)
                {
                    e.Handled = true;
                }
            }
            else if (keyLimitedOption == KeyLimitedOption.Deny)
            {
                foreach (char item in chars)
                {
                    if (e.KeyChar == item)
                    {
                        e.Handled = true;
                        break;
                    }
                }
            }
        }

        public static void TextBox_KeyControl(object sender, KeyPressEventArgs e, string charStr, KeyLimitedOption keyLimitedOption)
        {
            char[] chars = charStr.ToCharArray();

            TextBox_KeyControl(sender, e, chars, keyLimitedOption);
        }

        // 实现TextBox激活多行后可以Ctrl+A全选，应用于TextBox的KeyPress事件
        public static void TextBox_MultiLine_CtrlA(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        // 实现TextBox激活多行后可以Ctrl+A全选，应用于TextBox的KeyDown事件
        public static void TextBox_MultiLine_CtrlA(object sender, KeyEventArgs e)
        {
            // if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        // DataGridView行从源移到目标之后，源中是否删除选项
        public enum DGVMoveOption { reserve, delete };

        // DataGridViewRow移到另一个DataGridView中，针对两边的DataGridView都没有绑定数据源，而是代码直接写的数据的场景
        public static void DGVSelectedRowsMove(DataGridView dgvSource, DataGridView dgvTarget, DGVMoveOption dgvMoveOption)
        {
            if (dgvMoveOption == DGVMoveOption.delete)
            {
                // dgvSource.SelectedRows的顺序与前台看到的顺序是反的，所以需要使用Reverse函数反转一下
                foreach (DataGridViewRow item in dgvSource.SelectedRows.OfType<DataGridViewRow>().Reverse().ToArray())
                {
                    dgvSource.Rows.Remove(item);
                    dgvTarget.Rows.Add(item);
                }
            }
            else if (dgvMoveOption == DGVMoveOption.reserve)
            {
                DataGridViewRow row = new DataGridViewRow();
                foreach (DataGridViewRow item in dgvSource.SelectedRows.OfType<DataGridViewRow>().Reverse().ToArray())
                {
                    row = (DataGridViewRow)item.Clone();
                    for (int i = 0; i < item.Cells.Count; i++)
                    {
                        row.Cells[i].Value = item.Cells[i].Value;
                    }
                    dgvTarget.Rows.Add(row);
                }
            }
        }

        // DataGridViewRow移到另一个DataGridView中，针对两边的DataGridView都绑定数据源（DataTable）的场景
        public static void DGVSelectedRowsMove(DataGridView dgvSource, DataGridView dgvTarget, ref DataTable dtSource, ref DataTable dtTarget, DGVMoveOption dgvMoveOption)
        {
            DataRow[] rows = new DataRow[dgvSource.SelectedRows.Count];
            for (int i = 0; i < dgvSource.SelectedRows.Count; i++)
            {
                rows[i] = ((DataRowView)dgvSource.SelectedRows[i].DataBoundItem).Row;
            }

            // dgvSource.SelectedRows的顺序与前台看到的顺序是反的，所以需要使用Reverse函数反转一下
            foreach (DataRow row in rows.Reverse())
            {
                dtTarget.Rows.Add(row.ItemArray);
                if (dgvMoveOption == DGVMoveOption.delete)
                {
                    dtSource.Rows.Remove(row);
                }
            }

            dgvSource.DataSource = dtSource;
            DataTableDistinct(ref dtTarget);
            dgvTarget.DataSource = dtTarget;
        }

        // 直接移除DataGridViewRow，针对DataGridView没有绑定数据源，而是代码直接写的数据的场景
        public static void DGVSelectedRowsMove(DataGridView dgvSource)
        {
            // dgvSource.SelectedRows的顺序与前台看到的顺序是反的，所以需要使用Reverse函数反转一下
            foreach (DataGridViewRow item in dgvSource.SelectedRows.OfType<DataGridViewRow>().Reverse().ToArray())
            {
                dgvSource.Rows.Remove(item);
            }
        }

        // 直接移除DataGridViewRow，针对DataGridView绑定数据源（DataTable）的场景
        public static void DGVSelectedRowsMove(DataGridView dgvSource, DataTable dtSource)
        {
            DataRow[] rows = new DataRow[dgvSource.SelectedRows.Count];
            for (int i = 0; i < dgvSource.SelectedRows.Count; i++)
            {
                rows[i] = ((DataRowView)dgvSource.SelectedRows[i].DataBoundItem).Row;
            }

            // dgvSource.SelectedRows的顺序与前台看到的顺序是反的，所以需要使用Reverse函数反转一下
            foreach (DataRow row in rows.Reverse())
            {
                dtSource.Rows.Remove(row);
            }
        }

        // TreeView指定展开几个level
        public static void TreeViewExpandLevels(TreeView treeview, int level)
        {
            TreeNodeCollection treenodes = treeview.Nodes;
            TreeViewExpandLevels(treenodes, level);
        }

        // TreeView指定展开几个level
        public static void TreeViewExpandLevels(TreeNodeCollection treenodes, int level)
        {
            foreach (TreeNode item in treenodes)
            {
                if (item.Level <= level)
                {
                    item.Expand();
                    TreeViewExpandLevels(item.Nodes, level);
                }
            }
        }

        // ListView切换视图
        public static void ListViewSwitchView(ListView listview)
        {
            switch (listview.View)
            {
                case View.LargeIcon:
                    listview.View = View.SmallIcon;
                    break;
                case View.SmallIcon:
                    listview.View = View.List;
                    break;
                case View.List:
                    listview.View = View.Details;
                    break;
                case View.Details:
                    listview.View = View.Tile;
                    break;
                case View.Tile:
                    listview.View = View.LargeIcon;
                    break;
                default:
                    listview.View = View.List;
                    break;
            }
        }

        // 汉字转拼音
        public enum CHS2PinYinOption { AllLetter, FirstUpper, FirstLetter };
        public static string CHS2PinYin(string str, CHS2PinYinOption convertOption)
        {
            StringBuilder sb = new StringBuilder();
            str = str.Trim();

            if (convertOption == CHS2PinYinOption.AllLetter)
            {
                foreach (char item in str)
                {
                    try
                    {
                        ChineseChar chChar = new ChineseChar(item);
                        if (chChar.PinyinCount > 0)  // if (chChar.Pinyins.Count > 0)
                        {
                            sb.Append(chChar.Pinyins[0].Substring(0, chChar.Pinyins[0].Length - 1));
                        }
                    }
                    catch
                    {
                        sb.Append(item);
                    }
                }
            }
            else if (convertOption == CHS2PinYinOption.FirstLetter)
            {
                foreach (char item in str)
                {
                    try
                    {
                        ChineseChar chChar = new ChineseChar(item);
                        if (chChar.PinyinCount > 0)  // if (chChar.Pinyins.Count > 0)
                        {
                            sb.Append(chChar.Pinyins[0].Substring(0, 1));
                        }
                    }
                    catch
                    {
                        sb.Append(item);
                    }
                }
            }
            else if (convertOption == CHS2PinYinOption.FirstUpper)
            {
                foreach (char item in str)
                {
                    try
                    {
                        ChineseChar chChar = new ChineseChar(item);
                        if (chChar.PinyinCount > 0)  // if (chChar.Pinyins.Count > 0)
                        {
                            sb.Append(chChar.Pinyins[0].Substring(0, 1).ToUpper() + chChar.Pinyins[0].Substring(1, chChar.Pinyins[0].Length - 2).ToLower());
                        }
                    }
                    catch
                    {
                        sb.Append(item);
                    }
                }
            }
            else
            {
                return string.Empty;
            }

            return sb.ToString();
        }

        // 简体繁体转换
        public static string CHSCHTConverter(string str, ChineseConversionDirection direction)
        {
            return ChineseConverter.Convert(str.Trim(), direction);
        }

        // 随机汉字
        public static string GetRandomChineseLetters(Encoding encoding, int length)
        {
            // 调用函数产生length个随机中文汉字编码
            object[] bytes = CreateRegionCode(length);

            StringBuilder sb = new StringBuilder();
            // 根据汉字编码的字节数组解码出中文汉字
            for (int i = 0; i < length; i++)
            {
                sb.Append(encoding.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[]))));
            }

            return sb.ToString();
        }

        /* 此函数在汉字编码范围内随机创建含两个元素的十六进制字节数组，每个字节数组代表一个汉字，并将四个字节数组存储在object数组中
         * 参数：length，代表需要产生的汉字个数 
         */
        private static object[] CreateRegionCode(int length)
        {
            // 定义一个字符串数组储存汉字编码的组成元素
            string[] rBase = new string[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

            // 利用GUID生成随机数
            Random rnd = GetRandomWithGuid();

            // 定义一个object数组用来
            object[] bytes = new object[length];

            /* 每循环一次产生一个含两个元素的十六进制字节数组，并将其放入object数组中
             * 每个汉字有四个区位码组成
             * 区位码第1位和区位码第2位作为字节数组第一个元素
             * 区位码第3位和区位码第4位作为字节数组第二个元素
             */
            for (int i = 0; i < length; i++)
            {
                // 区位码第1位
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();

                // 区位码第2位
                // 更换随机数发生器的种子避免产生重复值
                // rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);
                rnd = GetRandomWithGuid();
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();

                // 区位码第3位
                // rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                rnd = GetRandomWithGuid();
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();

                // 区位码第4位
                // rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                rnd = GetRandomWithGuid();
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();

                // 定义两个字节变量存储产生的随机汉字区位码
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                // 将两个字节变量存储在字节数组中
                byte[] str_r = new byte[] { byte1, byte2 };

                // 将产生的一个汉字的字节数组放入object数组中
                bytes.SetValue(str_r, i);
            }

            return bytes;
        }

        // 随机一个中文姓氏
        public static string GetRandomChineseFamilyName()
        {
            return MyUtilsResources.百家姓[random.Next(0, MyUtilsResources.百家姓.Length)];
        }

        // 随机一个中文名字
        public static string GetRandomChineseFullName(int length)
        {
            return GetRandomChineseFamilyName() + GetRandomChineseLetters(Encoding.GetEncoding("gb2312"), length);
        }

        public static string GetRandomChineseFullName()
        {
            int length = random.Next(1, 3);
            return GetRandomChineseFullName(length);
        }

        /// <summary>
        /// Returns the number of steps required to transform the source string
        /// into the target string.
        /// 比较两个字符串的相似度
        /// </summary>
        public static int CalLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) { return 0; }
            if ((source.Length == 0) || (target.Length == 0)) { return 0; }
            if (source == target) { return source.Length; }

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0) { return targetWordCount; }
            if (targetWordCount == 0) { return sourceWordCount; }

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }

        /// <summary>
        /// Calculate percentage similarity of two strings
        /// <param name="source">Source String to Compare with</param>
        /// <param name="target">Targeted String to Compare</param>
        /// <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// 比较两个字符串的相似度
        /// </summary>
        public static double CalLevenshteinSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) { return 0.0; }
            if ((source.Length == 0) || (target.Length == 0)) { return 0.0; }
            if (source == target) { return 1.0; }

            int stepsToSame = CalLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        // 读取注册表的值？下面获取文件类型名称时调用
        public static string ReadDefaultValue(string regKey)
        {
            using (var key = Registry.ClassesRoot.OpenSubKey(regKey, false))
            {
                if (key != null)
                {
                    return key.GetValue("") as string;
                }
            }
            return null;
        }

        // 获取文件类型名称
        // read from the registry, use like GetFileDescription("xml") or GetFileDescription(".xml")
        public static string GetFileDescription(string ext)
        {
            if (ext.StartsWith(".") && ext.Length > 1)
            {
                ext = ext.Substring(1);
            }

            string retVal = ReadDefaultValue(ext + "file");
            if (!string.IsNullOrEmpty(retVal))
            {
                return retVal;
            }

            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey("." + ext, false))
            {
                if (key == null) { return ext + " 文件"; }

                using (RegistryKey subkey = key.OpenSubKey("OpenWithProgids"))
                {
                    if (subkey == null) { return ext + " 文件"; }

                    string[] names = subkey.GetValueNames();
                    if (names == null || names.Length == 0) { return ""; }

                    foreach (string name in names)
                    {
                        retVal = ReadDefaultValue(name);
                        if (!string.IsNullOrEmpty(retVal))
                        {
                            return retVal;
                        }
                    }
                }
            }

            return ext + " 文件";
        }

        // 获取文件大小
        public static string GetHumanReadableFileLength(long length)
        {
            double readable = length;

            string[] sizes = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            int order = 0;

            while (readable >= 1024 && order < sizes.Length - 1)
            {
                order++;
                readable /= 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            return string.Format("{0:0.###} {1}", readable, sizes[order]);
        }

        public static string GetHumanReadableFileLength2(long length)
        {
            // Get absolute value
            long absolute_i = (length < 0 ? -length : length);
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (absolute_i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (length >> 50);
            }
            else if (absolute_i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (length >> 40);
            }
            else if (absolute_i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (length >> 30);
            }
            else if (absolute_i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (length >> 20);
            }
            else if (absolute_i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (length >> 10);
            }
            else if (absolute_i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = length;
            }
            else
            {
                return length.ToString("0 B"); // Byte
            }

            // Divide by 1024 to get fractional value
            readable = (readable / 1024);
            // Return formatted number with suffix
            return readable.ToString("0.### ") + suffix;
        }

        // 根据handle获取进程
        public static Process GetProcessByHandle(IntPtr handle)
        {
            return Process.GetProcesses().Single(p => p.Id != 0 && p.Handle == handle);
        }

        public static Process GetProcessByHandle2(IntPtr handle)
        {
            return Process.GetProcessById(MyUtilsWin32.GetProcessId(handle));
        }

        // 判断一个整数是否以另一个整数开头，1809123以1809开头，但是不以1829开头
        public static bool IsIntStartsWith(uint x, uint y)
        {
            if (x == 0 && y == 0)
                return true;
            else if (x == 0 || y == 0 || x < y)
                return false;
            else
            {
                int diff = GetIntLength(x) - GetIntLength(y);

                if (y == x / (uint)Math.Pow(10, diff))
                    return true;
                else
                    return false;
            }
        }

        public static bool IsIntStartsWith(ulong x, ulong y)
        {
            if (x == 0 && y == 0)
                return true;
            else if (x == 0 || y == 0 || x < y)
                return false;
            else
            {
                int diff = GetIntLength(x) - GetIntLength(y);

                if (y == x / (ulong)Math.Pow(10, diff))
                    return true;
                else
                    return false;
            }
        }

        // 计算整型长度
        public static int GetIntLength(int i)
        {
            if (i < 0)
                throw new ArgumentOutOfRangeException();
            if (i == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(i)) + 1;
        }

        public static int GetIntLength(uint i)
        {
            if (i == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(i)) + 1;
        }

        public static int GetIntLength(long i)
        {
            if (i < 0)
                throw new ArgumentOutOfRangeException();
            if (i == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(i)) + 1;
        }

        public static int GetIntLength(ulong i)
        {
            if (i == 0)
                return 1;

            return (int)Math.Floor(Math.Log10(i)) + 1;
        }
    }
}
