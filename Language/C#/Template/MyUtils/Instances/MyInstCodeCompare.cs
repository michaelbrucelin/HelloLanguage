using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    //很早以前写的对比code的代码，已经弃用，现在使用MyInstE164中的代码
    public class MyInstCodeCompare
    {
        public static List<ResultRowULong> GetCodeCompareULong(List<ulong> codeleft, List<ulong> coderight, bool generalMatch = true)
        {
            //声明结果变量
            List<ResultRowULong> result = new List<ResultRowULong>();

            //code排序，为归并查找做准备
            codeleft.Sort();
            coderight.Sort();
            //复制一份，左右两个code数据
            List<ulong> listLeft = codeleft.GetRange(0, codeleft.Count);
            List<ulong> listRight = coderight.GetRange(0, coderight.Count);

            #region 计算matched
            //计算matched
            //左表中每个code到右表查找，如果找到，左表的下一项从右表上次查找到的索引继续向后查找，直到左表或右表到达最后一项停止查找
            int start = 0, end = listRight.Count - 1, count = listLeft.Count, matchIndex;
            ulong matchValue;
            for (int i = 0; i < count && start <= end;)
            {
                matchValue = listLeft[i];
                matchIndex = GetMatchedCode(start, end, matchValue, listRight);
                if (matchIndex != -1)
                {
                    result.Add(new ResultRowULong() { Key = matchValue, KeyLeft = matchValue, KeyRight = matchValue });
                    listLeft.RemoveAt(i);    //因为原有的第i项被移除，后面项的index都-1，所以i不需要自增，listLeft的长度-1
                    count--;
                    listRight.RemoveAt(matchIndex);    //因为原有的第i项被移除，后面项的index都-1，下次从listRight中的matchIndex开始查找,listRight的长度-1
                    start = matchIndex;
                    end--;
                }
                else
                {
                    i++;
                }
            }
            #endregion

            #region 计算not matched
            if (generalMatch)    //缩位匹配
            {
                int flag;
                #region 计算left
                //计算left，left中在right中没有完全匹配的项，缩位到right中查找
                //计算left和计算right可以优化，比如2637711，2637712，2637713，2637714，2637715，2637716，2637717，只要第一项找到了263771，剩下的都是263771，不需要再次查找
                int codeLeftLen, rightcount = coderight.Count - 1;
                ulong codeLeftSub;
                foreach (ulong codeLeft in listLeft)
                {
                    flag = 0;
                    codeLeftLen = (int)Math.Log10(codeLeft) + 1;
                    for (int i = 1; i < codeLeftLen; i++)
                    {
                        codeLeftSub = codeLeft / (ulong)Math.Pow(10, i);
                        if (GetMatchedCode(0, rightcount, codeLeftSub, coderight) != -1)
                        {
                            result.Add(new ResultRowULong() { Key = codeLeft, KeyLeft = codeLeft, KeyRight = codeLeftSub });
                            flag = 1;
                            break;
                        }
                    }
                    //这个地方应该可以优化，怎样才能不通过flag判断？
                    if (flag == 0)
                    {
                        result.Add(new ResultRowULong() { Key = codeLeft, KeyLeft = codeLeft, KeyRight = 0 });
                    }
                }
                #endregion
                #region 计算right
                //计算right,left中在right中没有完全匹配的项，缩位到right中查找
                //计算left和计算right可以优化，比如2637711，2637712，2637713，2637714，2637715，2637716，2637717，只要第一项找到了263771，剩下的都是263771，不需要再次查找
                int codeRightLen, leftcount = codeleft.Count - 1;
                ulong codeRightSub;
                foreach (ulong codeRight in listRight)
                {
                    flag = 0;
                    codeRightLen = (int)Math.Log10(codeRight) + 1;
                    for (int i = 1; i < codeRightLen; i++)
                    {
                        codeRightSub = codeRight / (ulong)Math.Pow(10, i);
                        if (GetMatchedCode(0, leftcount, codeRightSub, codeleft) != -1)
                        {
                            result.Add(new ResultRowULong() { Key = codeRight, KeyLeft = codeRightSub, KeyRight = codeRight });
                            flag = 1;
                            break;
                        }
                    }
                    //这个地方应该可以优化，怎样才能不通过flag判断？
                    if (flag == 0)
                    {
                        result.Add(new ResultRowULong() { Key = codeRight, KeyLeft = 0, KeyRight = codeRight });
                    }
                }
                #endregion
            }
            else    //不缩位匹配
            {
                //计算left
                foreach (ulong codeLeft in listLeft)
                {
                    result.Add(new ResultRowULong() { Key = codeLeft, KeyLeft = codeLeft, KeyRight = 0 });
                }
                //计算right
                foreach (ulong codeRight in listRight)
                {
                    result.Add(new ResultRowULong() { Key = codeRight, KeyLeft = 0, KeyRight = codeRight });
                }
            }
            #endregion

            return result;
        }

        public static List<ResultRowULongWithPrice> GetCodeCompareULongWithPrice(List<InputRowULong> codepriceleft, List<InputRowULong> codepriceright)
        {
            //声明结果变量和中间变量
            List<ResultRowULongWithPrice> result = new List<ResultRowULongWithPrice>();

            //code排序，为归并查找做准备
            //List排序是否可以优化？？？
            codepriceleft.Sort(delegate (InputRowULong v1, InputRowULong v2) { return Comparer<ulong>.Default.Compare(v1.Key, v2.Key); });
            codepriceright.Sort(delegate (InputRowULong v1, InputRowULong v2) { return Comparer<ulong>.Default.Compare(v1.Key, v2.Key); });
            //复制一份，左右两个code数据
            List<InputRowULong> listLeft = codepriceleft.GetRange(0, codepriceleft.Count);
            List<InputRowULong> listRight = codepriceright.GetRange(0, codepriceright.Count);

            //计算matched
            //左表中每个code到右表查找，如果找到，左表的下一项从右表上次查找到的索引继续向后查找，直到左表或右表到达最后一项停止查找
            int start = 0, end = listRight.Count - 1, count = listLeft.Count, matchIndex;
            InputRowULong matchitem;
            for (int i = 0; i < count && start <= end;)
            {
                matchitem = listLeft[i];
                matchIndex = GetMatchedCode(start, end, matchitem.Key, listRight);
                if (matchIndex != -1)
                {
                    result.Add(new ResultRowULongWithPrice()
                    {
                        Key = matchitem.Key,
                        KeyLeft = matchitem.Key,
                        KeyRight = matchitem.Key,
                        PriceLeft = matchitem.Price,
                        PriceRight = listRight[matchIndex].Price
                    });
                    listLeft.RemoveAt(i);    //因为原有的第i项被移除，后面项的index都-1，所以i不需要自增，listLeft的长度-1
                    count--;
                    listRight.RemoveAt(matchIndex);    //因为原有的第i项被移除，后面项的index都-1，下次从listRight中的matchIndex开始查找,listRight的长度-1
                    start = matchIndex;
                    end--;
                }
                else
                {
                    i++;
                }
            }

            int flag;
            //计算left，left中在right中没有完全匹配的项，缩位到right中查找
            //计算left和计算right可以优化，比如2637711，2637712，2637713，2637714，2637715，2637716，2637717，只要第一项找到了263771，剩下的都是263771，不需要再次查找
            int codeLeftLen, rightcount = codepriceright.Count - 1;
            ulong codeLeftSub;
            foreach (InputRowULong item in listLeft)
            {
                flag = 0;
                codeLeftLen = (int)Math.Log10(item.Key) + 1;
                for (int i = 1; i < codeLeftLen; i++)
                {
                    codeLeftSub = item.Key / (ulong)Math.Pow(10, i);
                    if ((matchIndex = GetMatchedCode(0, rightcount, codeLeftSub, codepriceright)) != -1)
                    {
                        result.Add(new ResultRowULongWithPrice()
                        {
                            Key = item.Key,
                            KeyLeft = item.Key,
                            KeyRight = codeLeftSub,
                            PriceLeft = item.Price,
                            PriceRight = codepriceright[matchIndex].Price
                        });
                        flag = 1;
                        break;
                    }
                }
                //这个地方应该可以优化，怎样才能不通过flag判断？
                if (flag == 0)
                {
                    result.Add(new ResultRowULongWithPrice()
                    {
                        Key = item.Key,
                        KeyLeft = item.Key,
                        KeyRight = 0,
                        PriceLeft = item.Price,
                        PriceRight = -1
                    });
                }
            }

            //计算right，left中在right中没有完全匹配的项，缩位到right中查找
            //计算left和计算right可以优化，比如2637711，2637712，2637713，2637714，2637715，2637716，2637717，只要第一项找到了263771，剩下的都是263771，不需要再次查找
            int codeRightLen, leftcount = codepriceleft.Count - 1;
            ulong codeRightSub;
            foreach (InputRowULong item in listRight)
            {
                flag = 0;
                codeRightLen = (int)Math.Log10(item.Key) + 1;
                for (int i = 1; i < codeRightLen; i++)
                {
                    codeRightSub = item.Key / (ulong)Math.Pow(10, i);
                    if ((matchIndex = GetMatchedCode(0, leftcount, codeRightSub, codepriceleft)) != -1)
                    {
                        result.Add(new ResultRowULongWithPrice()
                        {
                            Key = item.Key,
                            KeyLeft = codeRightSub,
                            KeyRight = item.Key,
                            PriceLeft = codepriceleft[matchIndex].Price,
                            PriceRight = item.Price
                        });
                        flag = 1;
                        break;
                    }
                }
                //这个地方应该可以优化，怎样才能不通过flag判断？
                if (flag == 0)
                {
                    result.Add(new ResultRowULongWithPrice()
                    {
                        Key = item.Key,
                        KeyLeft = 0,
                        KeyRight = item.Key,
                        PriceLeft = -1,
                        PriceRight = item.Price
                    });
                }
            }

            return result;
        }

        public static List<ResultRowULongWithPrice> GetCodeCompareULongWithPrice(Dictionary<ulong, double> codepriceleft, Dictionary<ulong, double> codepriceright)
        {
            //声明结果变量
            List<ResultRowULongWithPrice> result = new List<ResultRowULongWithPrice>();

            List<ulong> codeleft = new List<ulong>(codepriceleft.Keys);
            List<ulong> coderight = new List<ulong>(codepriceright.Keys);

            List<ResultRowULong> resultTemp = GetCodeCompareULong(codeleft, coderight);

            foreach (ResultRowULong item in resultTemp)
            {
                result.Add(new ResultRowULongWithPrice()
                {
                    Key = item.Key,
                    KeyLeft = item.KeyLeft,
                    KeyRight = item.KeyRight,
                    PriceLeft = codepriceleft.ContainsKey(item.KeyLeft) ? codepriceleft[item.KeyLeft] : -1,
                    PriceRight = codepriceright.ContainsKey(item.KeyRight) ? codepriceright[item.KeyRight] : -1
                });
            }

            return result;
        }

        public static List<ResultRowString> GetCodeCompareString(List<string> codeleft, List<string> coderight)
        {
            //声明结果变量
            List<ResultRowString> result = new List<ResultRowString>();

            //code排序，为归并查找做准备
            codeleft.Sort();
            coderight.Sort();
            //复制一份，左右两个code数据
            List<string> listLeft = codeleft.GetRange(0, codeleft.Count);
            List<string> listRight = coderight.GetRange(0, coderight.Count);

            //计算matched
            //左表中每个code到右表查找，如果找到，左表的下一项从右表上次查找到的索引继续向后查找，直到左表或右表到达最后一项停止查找。
            int start = 0, end = listRight.Count - 1, count = listLeft.Count, matchIndex;
            string matchValue;
            for (int i = 0; i < count && start <= end;)
            {
                matchValue = listLeft[i];
                matchIndex = GetMatchedCode(start, end, matchValue, listRight);
                if (matchIndex != -1)
                {
                    result.Add(new ResultRowString() { Key = matchValue, KeyLeft = matchValue, KeyRight = matchValue });
                    listLeft.RemoveAt(i);    //因为原有的第i项被移除，后面项的index都-1，所以i不需要自增，listLeft的长度-1
                    count--;
                    listRight.RemoveAt(matchIndex);    //因为原有的第i项被移除，后面项的index都-1，下次从listRight中的matchIndex开始查找,listRight的长度-1
                    start = matchIndex;
                    end--;
                }
                else
                {
                    i++;
                }
            }

            int flag;
            //计算left，left中在right中没有完全匹配的项，缩位到right中查找
            //计算left和计算right可以优化，比如2637711，2637712，2637713，2637714，2637715，2637716，2637717，只要第一项找到了263771，剩下的都是263771，不需要再次查找
            int codeLeftLen, rightcount = coderight.Count - 1;
            string codeLeftSub;
            foreach (string codeLeft in listLeft)
            {
                flag = 0;
                codeLeftLen = codeLeft.Length;
                for (int i = 1; i < codeLeftLen; i++)
                {
                    codeLeftSub = codeLeft.Substring(0, codeLeft.Length - i);
                    if (GetMatchedCode(0, rightcount, codeLeftSub, coderight) != -1)
                    {
                        result.Add(new ResultRowString() { Key = codeLeft, KeyLeft = codeLeft, KeyRight = codeLeftSub });
                        flag = 1;
                        break;
                    }
                }
                //这个地方应该可以优化，怎样才能不通过flag判断？
                if (flag == 0)
                {
                    result.Add(new ResultRowString() { Key = codeLeft, KeyLeft = codeLeft, KeyRight = "0" });
                }
            }

            //计算right，left中在right中没有完全匹配的项，缩位到right中查找
            //计算left和计算right可以优化，比如2637711，2637712，2637713，2637714，2637715，2637716，2637717，只要第一项找到了263771，剩下的都是263771，不需要再次查找
            int codeRightLen, leftcount = codeleft.Count - 1;
            string codeRightSub;
            foreach (string codeRight in listRight)
            {
                flag = 0;
                codeRightLen = codeRight.Length;
                for (int i = 1; i < codeRightLen; i++)
                {
                    codeRightSub = codeRight.Substring(0, codeRight.Length - i);
                    if (GetMatchedCode(0, leftcount, codeRightSub, codeleft) != -1)
                    {
                        result.Add(new ResultRowString() { Key = codeRight, KeyLeft = codeRightSub, KeyRight = codeRight });
                        flag = 1;
                        break;
                    }
                }
                //这个地方应该可以优化，怎样才能不通过flag判断？
                if (flag == 0)
                {
                    result.Add(new ResultRowString() { Key = codeRight, KeyLeft = "0", KeyRight = codeRight });
                }
            }

            return result;
        }

        public static List<ResultRowStringWithPrice> GetCodeCompareStringWithPrice(List<InputRowString> codepriceleft, List<InputRowString> codepriceright)
        {
            //声明结果变量和中间变量
            List<ResultRowStringWithPrice> result = new List<ResultRowStringWithPrice>();

            //code排序，为归并查找做准备
            //List排序是否可以优化？？？
            codepriceleft.Sort(delegate (InputRowString v1, InputRowString v2) { return Comparer<string>.Default.Compare(v1.Key, v2.Key); });
            codepriceright.Sort(delegate (InputRowString v1, InputRowString v2) { return Comparer<string>.Default.Compare(v1.Key, v2.Key); });
            //复制一份，左右两个code数据
            List<InputRowString> listLeft = codepriceleft.GetRange(0, codepriceleft.Count);
            List<InputRowString> listRight = codepriceright.GetRange(0, codepriceright.Count);

            //计算matched
            //左表中每个code到右表查找，如果找到，左表的下一项从右表上次查找到的索引继续向后查找，直到左表或右表到达最后一项停止查找。
            int start = 0, end = listRight.Count - 1, count = listLeft.Count, matchIndex;
            InputRowString matchitem;
            for (int i = 0; i < count && start <= end;)
            {
                matchitem = listLeft[i];
                matchIndex = GetMatchedCode(start, end, matchitem.Key, listRight);
                if (matchIndex != -1)
                {
                    result.Add(new ResultRowStringWithPrice()
                    {
                        Key = matchitem.Key,
                        KeyLeft = matchitem.Key,
                        KeyRight = matchitem.Key,
                        PriceLeft = matchitem.Price,
                        PriceRight = listRight[matchIndex].Price
                    });
                    listLeft.RemoveAt(i);    //因为原有的第i项被移除，后面项的index都-1，所以i不需要自增，listLeft的长度-1
                    count--;
                    listRight.RemoveAt(matchIndex);    //因为原有的第i项被移除，后面项的index都-1，下次从listRight中的matchIndex开始查找,listRight的长度-1
                    start = matchIndex;
                    end--;
                }
                else
                {
                    i++;
                }
            }

            int flag;
            //计算left，left中在right中没有完全匹配的项，缩位到right中查找
            //计算left和计算right可以优化，比如2637711，2637712，2637713，2637714，2637715，2637716，2637717，只要第一项找到了263771，剩下的都是263771，不需要再次查找
            int codeLeftLen, rightcount = codepriceright.Count - 1;
            string codeLeftSub;
            foreach (InputRowString item in listLeft)
            {
                flag = 0;
                codeLeftLen = item.Key.Length;
                for (int i = 1; i < codeLeftLen; i++)
                {
                    codeLeftSub = item.Key.Substring(0, item.Key.Length - i);
                    if ((matchIndex = GetMatchedCode(0, rightcount, codeLeftSub, codepriceright)) != -1)
                    {
                        result.Add(new ResultRowStringWithPrice()
                        {
                            Key = item.Key,
                            KeyLeft = item.Key,
                            KeyRight = codeLeftSub,
                            PriceLeft = item.Price,
                            PriceRight = codepriceright[matchIndex].Price
                        });
                        flag = 1;
                        break;
                    }
                }
                //这个地方应该可以优化，怎样才能不通过flag判断？
                if (flag == 0)
                {
                    result.Add(new ResultRowStringWithPrice()
                    {
                        Key = item.Key,
                        KeyLeft = item.Key,
                        KeyRight = "0",
                        PriceLeft = item.Price,
                        PriceRight = -1
                    });
                }
            }

            //计算right，left中在right中没有完全匹配的项，缩位到right中查找
            //计算left和计算right可以优化，比如2637711，2637712，2637713，2637714，2637715，2637716，2637717，只要第一项找到了263771，剩下的都是263771，不需要再次查找
            int codeRightLen, leftcount = codepriceleft.Count - 1;
            string codeRightSub;
            foreach (InputRowString item in listRight)
            {
                flag = 0;
                codeRightLen = item.Key.Length;
                for (int i = 1; i < codeRightLen; i++)
                {
                    codeRightSub = item.Key.Substring(0, item.Key.Length - 1);
                    if ((matchIndex = GetMatchedCode(0, leftcount, codeRightSub, codepriceleft)) != -1)
                    {
                        result.Add(new ResultRowStringWithPrice()
                        {
                            Key = item.Key,
                            KeyLeft = codeRightSub,
                            KeyRight = item.Key,
                            PriceLeft = codepriceleft[matchIndex].Price,
                            PriceRight = item.Price
                        });
                        flag = 1;
                        break;
                    }
                }
                //这个地方应该可以优化，怎样才能不通过flag判断？
                if (flag == 0)
                {
                    result.Add(new ResultRowStringWithPrice()
                    {
                        Key = item.Key,
                        KeyLeft = "0",
                        KeyRight = item.Key,
                        PriceLeft = -1,
                        PriceRight = item.Price
                    });
                }
            }

            return result;
        }

        public static List<ResultRowStringWithPrice> GetCodeCompareStringWithPrice(Dictionary<string, double> codepriceleft, Dictionary<string, double> codepriceright)
        {
            //声明结果变量
            List<ResultRowStringWithPrice> result = new List<ResultRowStringWithPrice>();

            List<string> codeleft = new List<string>(codepriceleft.Keys);
            List<string> coderight = new List<string>(codepriceright.Keys);

            List<ResultRowString> resultTemp = GetCodeCompareString(codeleft, coderight);

            foreach (ResultRowString item in resultTemp)
            {
                result.Add(new ResultRowStringWithPrice()
                {
                    Key = item.Key,
                    KeyLeft = item.KeyLeft,
                    KeyRight = item.KeyRight,
                    PriceLeft = codepriceleft.ContainsKey(item.KeyLeft) ? codepriceleft[item.KeyLeft] : -1,
                    PriceRight = codepriceright.ContainsKey(item.KeyRight) ? codepriceright[item.KeyRight] : -1
                });
            }

            return result;
        }

        //二分法查找值
        private static int GetMatchedCode(int low, int high, ulong value, List<ulong> list)
        {
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (list[mid] == value)
                {
                    return mid;
                }
                else if (list[mid] < value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        private static int GetMatchedCode(int low, int high, ulong value, List<InputRowULong> list)
        {
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (list[mid].Key == value)
                {
                    return mid;
                }
                else if (list[mid].Key < value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        private static int GetMatchedCode(int low, int high, string value, List<string> list)
        {
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (list[mid] == value)
                {
                    return mid;
                }
                else if (value.CompareTo(list[mid]) > 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        private static int GetMatchedCode(int low, int high, string value, List<InputRowString> list)
        {
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (list[mid].Key == value)
                {
                    return mid;
                }
                else if (value.CompareTo(list[mid].Key) > 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }
    }

    public class InputRowULong
    {
        public ulong Key { get; set; }
        public double Price { get; set; }
    }

    public class ResultRowULong
    {
        public ulong Key { get; set; }
        public ulong KeyLeft { get; set; }
        public ulong KeyRight { get; set; }
    }

    public class ResultRowULongWithPrice : ResultRowULong
    {
        public double PriceLeft { get; set; }
        public double PriceRight { get; set; }
    }

    public class InputRowString
    {
        public string Key { get; set; }
        public double Price { get; set; }
    }

    public class ResultRowString
    {
        public string Key { get; set; }
        public string KeyLeft { get; set; }
        public string KeyRight { get; set; }
    }

    public class ResultRowStringWithPrice : ResultRowString
    {
        public double PriceLeft { get; set; }
        public double PriceRight { get; set; }
    }
}
