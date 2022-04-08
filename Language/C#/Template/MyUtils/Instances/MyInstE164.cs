using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public class MyInstE164
    {
        private bool recFlag;    //用于指定是否需要进行下一次递归
        private int recTime;     //用户记录递归处理的层数，最多递归16层，防止特出情况出现死递归
        private List<string> ccodeInfoStr;     //国家code信息
        private List<ulong> ccodeInfoULong;    //国家code信息
        private List<E164CoDestInfo> data2doStr;           //需要加工的数据信息
        private List<E164CoDestInfoULong> data2doULong;    //需要加工的数据信息

        #region 处理冗余code
        /// <summary>
        /// Level2更彻底，但是有风险，下面这种情况Level2会处理，而Level1不会处理
        /// destA	52			destA	52
        /// destA	52722		destB	52722
        /// destB	527220		destA	527228
        /// destB	527221		destA	527229
        /// destB	527222
        /// destB	527223
        /// destB	527224
        /// destB	527225
        /// destB	527226
        /// destB	527227
        /// Level1会处理下面这种情况
        /// destA	52			destA	52
        /// destB	527220		destB	52722
        /// destB	527221		destA	527228
        /// destB	527222		destA	527229
        /// destB	527223
        /// destB	527224
        /// destB	527225
        /// destB	527226
        /// destB	527227
        /// </summary>
        public enum CleanCodeLevel { Level1, Level2 };

        //处理冗余的code，主方法，string形式实现
        public List<E164CoDest> CleanRedundantData(List<E164CoDest> data, List<string> countryCodes, CleanCodeLevel level)
        {
            //保证整个列表中code没有重复，有重复直接抛异常跳出，人工处理重复的部分
            if (data.Count != data.Select(i => i.Code).ToList().Distinct().Count())
            {
                throw new Exception("code有重复，请手动去除重复后处理。");
            }

            //排序，稍后查找的时候，找到第一个就跳出
            ccodeInfoStr = countryCodes.OrderByDescending(o => o.Length).ThenBy(o => o).ToList();

            //准备数据
            data2doStr = new List<E164CoDestInfo>();
            data = data.OrderBy(o => o.Code).ToList();
            foreach (E164CoDest item in data)
            {
                data2doStr.Add(new E164CoDestInfo()
                {
                    CCode = GetCCode(item.Code),
                    Code = item.Code,
                    Destination = item.Destination,
                    CodeLen = item.Code.Length
                });
            }

            //开始计算
            if (level == CleanCodeLevel.Level1)
            {
                CleanRedundantDataLevel1(data2doStr);
            }
            else if (level == CleanCodeLevel.Level2)
            {
                recTime = 0;
                CleanRedundantDataLevel2(data2doStr);
            }

            //返回结果
            List<E164CoDest> result = new List<E164CoDest>();
            foreach (E164CoDestInfo item in data2doStr)
            {
                result.Add(new E164CoDest()
                {
                    Code = item.Code,
                    Destination = item.Destination
                });
            }

            return result;
        }

        //处理冗余的code，简单处理，处理的不彻底，相对安全，string形式实现
        private void CleanRedundantDataLevel1(List<E164CoDestInfo> data)
        {
            //1、一组（xxxx0~xxxx9）code有9项/8项/7项，补充为10项，注意不能存在xxxx这个code
            var query1 = data.ToDictionary(codest => codest.Code);

            List<string> subCode9 = new List<string>();
            List<string> subCode8 = new List<string>();
            List<string> subCode7 = new List<string>();
            List<string> subCode6 = new List<string>();
            var subCode0 = data
                .Where(w => w.CodeLen > 1 && !query1.ContainsKey(w.Code.Substring(0, w.CodeLen - 1)))
                .Select(s => s.Code.Substring(0, s.CodeLen - 1))
                .GroupBy(g => g)
                .Select(s => new { s.Key, cnt = s.Count() });
            subCode9 = subCode0.Where(w => w.cnt == 9).Select(s => s.Key).OrderBy(o => o).ToList();
            subCode8 = subCode0.Where(w => w.cnt == 8).Select(s => s.Key).OrderBy(o => o).ToList();
            subCode7 = subCode0.Where(w => w.cnt == 7).Select(s => s.Key).OrderBy(o => o).ToList();
            subCode6 = subCode0.Where(w => w.cnt == 6).Select(s => s.Key).OrderBy(o => o).ToList();

            //1.1、处理项目为9的部分
            foreach (string item in subCode9)
            {
                //找出少的那1项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                string suffix = string.Empty;
                List<string> destinfo = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    if (query1.ContainsKey(item + i.ToString()))
                    {
                        destinfo.Add(query1[item + i.ToString()].Destination);
                    }
                    else
                    {
                        suffix = i.ToString();
                    }
                }

                //如果没有数量大于等于3的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 3)
                {
                    continue;
                }

                //补全
                if (suffix.Length > 0)  //这个判断原则上永远为真
                {
                    string codeNew = item + suffix;
                    string destNew = GetDestination(codeNew, query1);
                    if (destNew.Length > 0)
                    {
                        data.Add(new E164CoDestInfo
                        {
                            CCode = GetCCode(codeNew),  //destNew.Length > 0，就说明ccode不为空
                            Code = codeNew,
                            Destination = destNew,
                            CodeLen = codeNew.Length
                        });
                    }
                }
            }

            //1.2、处理项目为8的部分
            foreach (string item in subCode8)
            {
                //找出少的那2项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                string[] suffixes = new string[2];
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query1.ContainsKey(item + i.ToString()))
                    {
                        destinfo.Add(query1[item + i.ToString()].Destination);
                    }
                    else
                    {
                        suffixes[index] = i.ToString();
                        index++;
                    }
                }

                //如果没有数量大于等于4的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 4)
                {
                    continue;
                }

                //补全
                if (suffixes[1].Length > 0)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    string codeNew0 = item + suffixes[0];
                    string codeNew1 = item + suffixes[1];
                    string ccodeNew = GetCCode(codeNew0);
                    string destNew = GetDestination(codeNew0, query1);

                    if (destNew.Length > 0)
                    {
                        data.Add(new E164CoDestInfo
                        {
                            CCode = ccodeNew,
                            Code = codeNew0,
                            Destination = destNew,
                            CodeLen = codeNew0.Length
                        });

                        data.Add(new E164CoDestInfo
                        {
                            CCode = ccodeNew,
                            Code = codeNew1,
                            Destination = destNew,
                            CodeLen = codeNew1.Length
                        });
                    }
                }
            }

            //1.3、处理项目为7的部分
            foreach (string item in subCode7)
            {
                //找出少的那3项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                string[] suffixes = new string[3];
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query1.ContainsKey(item + i.ToString()))
                    {
                        destinfo.Add(query1[item + i.ToString()].Destination);
                    }
                    else
                    {
                        suffixes[index] = i.ToString();
                        index++;
                    }
                }

                //如果没有数量大于等于5的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 5)
                {
                    continue;
                }

                //补全
                if (suffixes[2].Length > 0)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    string codeNew0 = item + suffixes[0];
                    string codeNew1 = item + suffixes[1];
                    string codeNew2 = item + suffixes[2];
                    string ccodeNew = GetCCode(codeNew0);
                    string destNew = GetDestination(codeNew0, query1);

                    if (destNew.Length > 0)
                    {
                        data.Add(new E164CoDestInfo
                        {
                            CCode = ccodeNew,
                            Code = codeNew0,
                            Destination = destNew,
                            CodeLen = codeNew0.Length
                        });

                        data.Add(new E164CoDestInfo
                        {
                            CCode = ccodeNew,
                            Code = codeNew1,
                            Destination = destNew,
                            CodeLen = codeNew1.Length
                        });

                        data.Add(new E164CoDestInfo
                        {
                            CCode = ccodeNew,
                            Code = codeNew2,
                            Destination = destNew,
                            CodeLen = codeNew2.Length
                        });
                    }
                }
            }

            //1.4、处理项目为6的部分
            foreach (string item in subCode6)
            {
                //找出少的那4项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                string[] suffixes = new string[4];
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query1.ContainsKey(item + i.ToString()))
                    {
                        destinfo.Add(query1[item + i.ToString()].Destination);
                    }
                    else
                    {
                        suffixes[index] = i.ToString();
                        index++;
                    }
                }

                //如果没有数量大于等于6的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 6)
                {
                    continue;
                }

                //补全
                if (suffixes[3].Length > 0)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    string codeNew0 = item + suffixes[0];
                    string codeNew1 = item + suffixes[1];
                    string codeNew2 = item + suffixes[2];
                    string codeNew3 = item + suffixes[3];
                    string ccodeNew = GetCCode(codeNew0);
                    string destNew = GetDestination(codeNew0, query1);

                    if (destNew.Length > 0)
                    {
                        data.Add(new E164CoDestInfo
                        {
                            CCode = ccodeNew,
                            Code = codeNew0,
                            Destination = destNew,
                            CodeLen = codeNew0.Length
                        });

                        data.Add(new E164CoDestInfo
                        {
                            CCode = ccodeNew,
                            Code = codeNew1,
                            Destination = destNew,
                            CodeLen = codeNew1.Length
                        });

                        data.Add(new E164CoDestInfo
                        {
                            CCode = ccodeNew,
                            Code = codeNew2,
                            Destination = destNew,
                            CodeLen = codeNew2.Length
                        });

                        data.Add(new E164CoDestInfo
                        {
                            CCode = ccodeNew,
                            Code = codeNew3,
                            Destination = destNew,
                            CodeLen = codeNew3.Length
                        });
                    }
                }
            }

            //2、处理项目数量为10的部分
            List<string> subCode10 = data
                .Where(w => w.CodeLen > 1)
                .Select(s => s.Code.Substring(0, s.CodeLen - 1))
                .GroupBy(g => g)
                .Select(s => new { s.Key, cnt = s.Count() })
                .Where(w => w.cnt == 10)
                .Select(s => s.Key)
                .OrderBy(o => o)
                .ToList();

            //2.1、删除无用的大code
            foreach (string item in subCode10)
            {
                if (data.Exists(w => w.Code == item))
                {
                    //如果存在，即删除
                    for (int j = data.Count - 1; j >= 0; j--)
                    {
                        if (data[j].Code == item)
                        {
                            data.RemoveAt(j);
                            break;
                        }
                    }
                }
            }

            //2.2、重新计算一下subCode10，经过2.1操作后，subCode10可能会有变化
            subCode10 = data
                .Where(w => w.CodeLen > 1)
                .Select(s => s.Code.Substring(0, s.CodeLen - 1))
                .GroupBy(g => g)
                .Select(s => new { s.Key, cnt = s.Count() })
                .Where(w => w.cnt == 10)
                .Select(s => s.Key)
                .OrderBy(o => o)
                .ToList();

            //2.3、重新规划code
            var query2 = data.ToLookup(codest => codest.CodeLen - 1);
            foreach (string item in subCode10)
            {
                //找出对应的10项中运营商数量最多的那个运营商名称
                var destNewInfo = query2[item.Length]
                    .Where(w => w.Code.StartsWith(item))
                    .Select(s => s.Destination)
                    .GroupBy(g => g)
                    .Select(s => new { s.Key, cnt = s.Count() })
                    .OrderByDescending(o => o.cnt)
                    .ThenByDescending(o => o.Key)
                    .First();

                int j = 1;
                for (int i = data.Count - 1; i >= 0; i--)
                {
                    if (data[i].CodeLen == item.Length + 1
                        && data[i].Destination == destNewInfo.Key
                        && data[i].Code.StartsWith(item))
                    {
                        data.RemoveAt(i);

                        if (j++ > destNewInfo.cnt)
                        {
                            break;
                        }
                    }
                }

                data.Add(new E164CoDestInfo
                {
                    CCode = GetCCode(item),
                    Code = item,
                    Destination = destNewInfo.Key,
                    CodeLen = item.Length
                });
            }

            //3、如果同一个运营商内部有code包含关系，删除小code
            //例如DestA有code 480、4801-4808，则直接将4801-4808这几条数据删除
            //注意，如果A运营商有两个code：4801与480123，B运营商有code：48012，这个时候，A运营商的小code 480123不能删除
            var query3 = data.ToDictionary(codest => codest.Code);
            for (int i = data.Count - 1; i >= 0; i--)
            {
                E164CoDestInfo codest = data[i];
                string ccode = codest.CCode;
                string code = codest.Code;

                while (code.Length > ccode.Length)
                {
                    code = code.Substring(0, code.Length - 1);
                    if (query3.ContainsKey(code))
                    {
                        if (query3[code].Destination == codest.Destination)
                        {
                            data.RemoveAt(i);
                        }
                        break;
                    }
                }
            }
        }

        //处理冗余的code，递归方法，处理的更彻底，但是有风险，string形式实现
        private void CleanRedundantDataLevel2(List<E164CoDestInfo> data)
        {
            recFlag = false;
            recTime++;    //记录递归的层数

            //1、如果同一个运营商内部有code包含关系，删除小code
            //例如DestA有code 480、4801-4808，则直接将4801-4808这几条数据删除
            //注意，如果A运营商有两个code：4801与480123，B运营商有code：48012，这个时候，A运营商的小code 480123不能删除
            var query1 = data.ToDictionary(codest => codest.Code);
            for (int i = data.Count - 1; i >= 0; i--)
            {
                E164CoDestInfo codest = data[i];
                string ccode = codest.CCode;
                string code = codest.Code;

                while (code.Length > ccode.Length)
                {
                    code = code.Substring(0, code.Length - 1);
                    if (query1.ContainsKey(code))
                    {
                        if (query1[code].Destination == codest.Destination)
                        {
                            data.RemoveAt(i);
                            //recFlag = true;  //这个操作不需要进行第二次操作
                        }
                        break;
                    }
                }
            }

            //2、一组（xxxx0~xxxx9）code有9项/8项/7项，补充为10项
            List<string> subCode9 = new List<string>();
            List<string> subCode8 = new List<string>();
            List<string> subCode7 = new List<string>();
            List<string> subCode6 = new List<string>();
            var subCode0 = data
                .Where(w => w.CodeLen > 1)
                .Select(s => s.Code.Substring(0, s.CodeLen - 1))
                .GroupBy(g => g)
                .Select(s => new { s.Key, cnt = s.Count() });
            subCode9 = subCode0.Where(w => w.cnt == 9).Select(s => s.Key).OrderBy(o => o).ToList();
            subCode8 = subCode0.Where(w => w.cnt == 8).Select(s => s.Key).OrderBy(o => o).ToList();
            subCode7 = subCode0.Where(w => w.cnt == 7).Select(s => s.Key).OrderBy(o => o).ToList();
            subCode6 = subCode0.Where(w => w.cnt == 6).Select(s => s.Key).OrderBy(o => o).ToList();

            var query2 = data.ToDictionary(codest => codest.Code);

            //2.1、处理项目为9的部分
            foreach (string item in subCode9)
            {
                //找出少的那1项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                string suffix = string.Empty;
                List<string> destinfo = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    if (query2.ContainsKey(item + i.ToString()))
                    {
                        destinfo.Add(query2[item + i.ToString()].Destination);
                    }
                    else
                    {
                        suffix = i.ToString();
                    }
                }

                //如果没有数量大于等于3的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 3)
                {
                    continue;
                }

                //补全
                if (suffix.Length > 0)  //这个判断原则上永远为真
                {
                    if (query2.ContainsKey(item))
                    {
                        //如果存在，即更新
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (data[j].Code == item)
                            {
                                data[j].Code += suffix;
                                data[j].CodeLen++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        //如果不存在，即插入
                        string codeNew = item + suffix;
                        string destNew = GetDestination(codeNew, query2);
                        if (destNew.Length > 0)
                        {
                            data.Add(new E164CoDestInfo
                            {
                                CCode = GetCCode(codeNew),  //destNew.Length > 0，就说明ccode不为空
                                Code = codeNew,
                                Destination = destNew,
                                CodeLen = codeNew.Length
                            });
                        }
                    }
                }
            }

            //2.2、处理项目为8的部分
            foreach (string item in subCode8)
            {
                //找出少的那2项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                string[] suffixes = new string[2];
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query2.ContainsKey(item + i.ToString()))
                    {
                        destinfo.Add(query2[item + i.ToString()].Destination);
                    }
                    else
                    {
                        suffixes[index] = i.ToString();
                        index++;
                    }
                }

                //如果没有数量大于等于4的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 4)
                {
                    continue;
                }

                //补全
                if (suffixes[1].Length > 0)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    if (query2.ContainsKey(item))
                    {
                        //如果存在，将其改为缺少的第1项，然后再添加缺少的第2项
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (data[j].Code == item)
                            {
                                data.Add(new E164CoDestInfo
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code + suffixes[1],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data[j].Code += suffixes[0];
                                data[j].CodeLen++;

                                break;
                            }
                        }
                    }
                    else
                    {
                        //如果不存在，即插入缺少的2项
                        string codeNew0 = item + suffixes[0];
                        string codeNew1 = item + suffixes[1];
                        string ccodeNew = GetCCode(codeNew0);
                        string destNew = GetDestination(codeNew0, query2);

                        if (destNew.Length > 0)
                        {
                            data.Add(new E164CoDestInfo
                            {
                                CCode = ccodeNew,
                                Code = codeNew0,
                                Destination = destNew,
                                CodeLen = codeNew0.Length
                            });

                            data.Add(new E164CoDestInfo
                            {
                                CCode = ccodeNew,
                                Code = codeNew1,
                                Destination = destNew,
                                CodeLen = codeNew1.Length
                            });
                        }
                    }
                }
            }

            //2.3、处理项目为7的部分
            foreach (string item in subCode7)
            {
                //找出少的那3项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                string[] suffixes = new string[3];
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query2.ContainsKey(item + i.ToString()))
                    {
                        destinfo.Add(query2[item + i.ToString()].Destination);
                    }
                    else
                    {
                        suffixes[index] = i.ToString();
                        index++;
                    }
                }

                //如果没有数量大于等于5的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 5)
                {
                    continue;
                }

                //补全
                if (suffixes[2].Length > 0)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    if (query2.ContainsKey(item))
                    {
                        //如果存在，将其改为缺少的第1项，然后再添加缺少的后2项
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (data[j].Code == item)
                            {
                                data.Add(new E164CoDestInfo
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code + suffixes[1],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data.Add(new E164CoDestInfo
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code + suffixes[2],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data[j].Code += suffixes[0];
                                data[j].CodeLen++;

                                break;
                            }
                        }
                    }
                    else
                    {
                        //如果不存在，即插入缺少的3项，这里就3项，不写循环了
                        string codeNew0 = item + suffixes[0];
                        string codeNew1 = item + suffixes[1];
                        string codeNew2 = item + suffixes[2];
                        string ccodeNew = GetCCode(codeNew0);
                        string destNew = GetDestination(codeNew0, query2);

                        if (destNew.Length > 0)
                        {
                            data.Add(new E164CoDestInfo
                            {
                                CCode = ccodeNew,
                                Code = codeNew0,
                                Destination = destNew,
                                CodeLen = codeNew0.Length
                            });

                            data.Add(new E164CoDestInfo
                            {
                                CCode = ccodeNew,
                                Code = codeNew1,
                                Destination = destNew,
                                CodeLen = codeNew1.Length
                            });

                            data.Add(new E164CoDestInfo
                            {
                                CCode = ccodeNew,
                                Code = codeNew2,
                                Destination = destNew,
                                CodeLen = codeNew2.Length
                            });
                        }
                    }
                }
            }

            //2.4、处理项目为6的部分
            foreach (string item in subCode6)
            {
                //找出少的那4项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                string[] suffixes = new string[4];
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query2.ContainsKey(item + i.ToString()))
                    {
                        destinfo.Add(query2[item + i.ToString()].Destination);
                    }
                    else
                    {
                        suffixes[index] = i.ToString();
                        index++;
                    }
                }

                //如果没有数量大于等于6的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 6)
                {
                    continue;
                }

                //补全
                if (suffixes[3].Length > 0)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    if (query2.ContainsKey(item))
                    {
                        //如果存在，将其改为缺少的第1项，然后再添加缺少的后3项
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (data[j].Code == item)
                            {
                                data.Add(new E164CoDestInfo
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code + suffixes[1],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data.Add(new E164CoDestInfo
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code + suffixes[2],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data.Add(new E164CoDestInfo
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code + suffixes[3],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data[j].Code += suffixes[0];
                                data[j].CodeLen++;

                                break;
                            }
                        }
                    }
                    else
                    {
                        //如果不存在，即插入缺少的4项，这里就4项，不写循环了
                        string codeNew0 = item + suffixes[0];
                        string codeNew1 = item + suffixes[1];
                        string codeNew2 = item + suffixes[2];
                        string codeNew3 = item + suffixes[3];
                        string ccodeNew = GetCCode(codeNew0);
                        string destNew = GetDestination(codeNew0, query2);

                        if (destNew.Length > 0)
                        {
                            data.Add(new E164CoDestInfo
                            {
                                CCode = ccodeNew,
                                Code = codeNew0,
                                Destination = destNew,
                                CodeLen = codeNew0.Length
                            });

                            data.Add(new E164CoDestInfo
                            {
                                CCode = ccodeNew,
                                Code = codeNew1,
                                Destination = destNew,
                                CodeLen = codeNew1.Length
                            });

                            data.Add(new E164CoDestInfo
                            {
                                CCode = ccodeNew,
                                Code = codeNew2,
                                Destination = destNew,
                                CodeLen = codeNew2.Length
                            });

                            data.Add(new E164CoDestInfo
                            {
                                CCode = ccodeNew,
                                Code = codeNew3,
                                Destination = destNew,
                                CodeLen = codeNew3.Length
                            });
                        }
                    }
                }
            }

            //3、处理项目数量为10的部分
            List<string> subCode10 = data
                .Where(w => w.CodeLen > 1)
                .Select(s => s.Code.Substring(0, s.CodeLen - 1))
                .GroupBy(g => g)
                .Select(s => new { s.Key, cnt = s.Count() })
                .Where(w => w.cnt == 10)
                .Select(s => s.Key)
                .OrderBy(o => o)
                .ToList();

            //3.1、删除无用的大code
            foreach (string item in subCode10)
            {
                if (data.Exists(w => w.Code == item))
                {
                    //如果存在，即删除
                    for (int j = data.Count - 1; j >= 0; j--)
                    {
                        if (data[j].Code == item)
                        {
                            data.RemoveAt(j);
                            break;
                        }
                    }
                }
            }

            //3.2、重新规划code
            var query3 = data.ToLookup(codest => codest.CodeLen - 1);
            foreach (string item in subCode10)
            {
                //找出对应的10项中运营商数量最多的那个运营商名称
                var destNewInfo = query3[item.Length]
                    .Where(w => w.Code.StartsWith(item))
                    .Select(s => s.Destination)
                    .GroupBy(g => g)
                    .Select(s => new { s.Key, cnt = s.Count() })
                    .OrderByDescending(o => o.cnt)
                    .ThenByDescending(o => o.Key)
                    .First();

                int j = 1;
                for (int i = data.Count - 1; i >= 0; i--)
                {
                    if (data[i].CodeLen == item.Length + 1
                        && data[i].Destination == destNewInfo.Key
                        && data[i].Code.StartsWith(item))
                    {
                        data.RemoveAt(i);

                        if (j++ > destNewInfo.cnt)
                        {
                            break;
                        }
                    }
                }

                data.Add(new E164CoDestInfo
                {
                    CCode = GetCCode(item),
                    Code = item,
                    Destination = destNewInfo.Key,
                    CodeLen = item.Length
                });
            }

            //递归
            //subCode9.Count > 0 || subCode7.Count > 0 || subCode8.Count > 0 都会转为 subCode10.Count > 0
            if (subCode10.Count > 0)
            {
                recFlag = true;
            }

            if (recFlag && recTime <= 16)
            {
                CleanRedundantDataLevel2(data);
            }
        }

        //处理冗余的code，主方法，ulong形式实现
        public List<E164CoDestULong> CleanRedundantData(List<E164CoDestULong> data, List<ulong> countryCodes, CleanCodeLevel level)
        {
            //保证整个列表中code没有重复，有重复直接抛异常跳出，人工处理重复的部分
            if (data.Count != data.Select(i => i.Code).ToList().Distinct().Count())
            {
                throw new Exception("code有重复，请手动去除重复后处理。");
            }

            //排序，稍后查找的时候，找到第一个就跳出
            ccodeInfoULong = countryCodes.OrderByDescending(o => o).ToList();

            //准备数据
            data2doULong = new List<E164CoDestInfoULong>();
            data = data.OrderBy(o => o.Code.ToString()).ToList();
            foreach (E164CoDestULong item in data)
            {
                data2doULong.Add(new E164CoDestInfoULong()
                {
                    CCode = GetCCode(item.Code),
                    Code = item.Code,
                    Destination = item.Destination,
                    CodeLen = item.Code.MyLength()
                });
            }

            //开始计算
            if (level == CleanCodeLevel.Level1)
            {
                CleanRedundantDataLevel1(data2doULong);
            }
            else if (level == CleanCodeLevel.Level2)
            {
                recTime = 0;
                CleanRedundantDataLevel2(data2doULong);
            }

            //返回结果
            List<E164CoDestULong> result = new List<E164CoDestULong>();
            foreach (E164CoDestInfoULong item in data2doULong)
            {
                result.Add(new E164CoDestULong()
                {
                    Code = item.Code,
                    Destination = item.Destination
                });
            }

            return result;
        }

        //处理冗余的code，简单处理，处理的不彻底，相对安全，ulong形式实现
        private void CleanRedundantDataLevel1(List<E164CoDestInfoULong> data)
        {
            //1、一组（xxxx0~xxxx9）code有9项/8项/7项，补充为10项，注意不能存在xxxx这个code
            var query1 = data.ToDictionary(codest => codest.Code);

            List<ulong> subCode9 = new List<ulong>();
            List<ulong> subCode8 = new List<ulong>();
            List<ulong> subCode7 = new List<ulong>();
            List<ulong> subCode6 = new List<ulong>();
            var subCode0 = data
                .Where(w => w.CodeLen > 1 && !query1.ContainsKey(w.Code / 10))
                .Select(s => s.Code / 10)
                .GroupBy(g => g)
                .Select(s => new { s.Key, cnt = s.Count() });
            subCode9 = subCode0.Where(w => w.cnt == 9).Select(s => s.Key).OrderBy(o => o.ToString()).ToList();
            subCode8 = subCode0.Where(w => w.cnt == 8).Select(s => s.Key).OrderBy(o => o.ToString()).ToList();
            subCode7 = subCode0.Where(w => w.cnt == 7).Select(s => s.Key).OrderBy(o => o.ToString()).ToList();
            subCode6 = subCode0.Where(w => w.cnt == 6).Select(s => s.Key).OrderBy(o => o.ToString()).ToList();

            //1.1、处理项目为9的部分
            foreach (ulong item in subCode9)
            {
                //找出少的那1项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                int suffix = -1;
                List<string> destinfo = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    if (query1.ContainsKey(item * 10 + (ulong)i))
                    {
                        destinfo.Add(query1[item * 10 + (ulong)i].Destination);
                    }
                    else
                    {
                        suffix = i;
                    }
                }

                //如果没有数量大于等于3的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 3)
                {
                    continue;
                }

                //补全
                if (suffix > -1)  //这个判断原则上永远为真
                {
                    ulong codeNew = item * 10 + (ulong)suffix;
                    string destNew = GetDestination(codeNew, query1);
                    if (destNew.Length > 0)
                    {
                        data.Add(new E164CoDestInfoULong
                        {
                            CCode = GetCCode(codeNew),  //destNew.Length > 0，就说明ccode不为空
                            Code = codeNew,
                            Destination = destNew,
                            CodeLen = codeNew.MyLength()
                        });
                    }
                }
            }

            //1.2、处理项目为8的部分
            foreach (ulong item in subCode8)
            {
                //找出少的那2项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                int[] suffixes = new int[2] { -1, -1 };
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query1.ContainsKey(item * 10 + (ulong)i))
                    {
                        destinfo.Add(query1[item * 10 + (ulong)i].Destination);
                    }
                    else
                    {
                        suffixes[index] = i;
                        index++;
                    }
                }

                //如果没有数量大于等于4的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 4)
                {
                    continue;
                }

                //补全
                if (suffixes[1] > -1)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    ulong codeNew0 = item * 10 + (ulong)suffixes[0];
                    ulong codeNew1 = item * 10 + (ulong)suffixes[1];
                    ulong ccodeNew = GetCCode(codeNew0);
                    string destNew = GetDestination(codeNew0, query1);

                    if (destNew.Length > 0)
                    {
                        data.Add(new E164CoDestInfoULong
                        {
                            CCode = ccodeNew,
                            Code = codeNew0,
                            Destination = destNew,
                            CodeLen = codeNew0.MyLength()
                        });

                        data.Add(new E164CoDestInfoULong
                        {
                            CCode = ccodeNew,
                            Code = codeNew1,
                            Destination = destNew,
                            CodeLen = codeNew1.MyLength()
                        });
                    }
                }
            }

            //1.3、处理项目为7的部分
            foreach (ulong item in subCode7)
            {
                //找出少的那3项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                int[] suffixes = new int[3] { -1, -1, -1 };
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query1.ContainsKey(item * 10 + (ulong)i))
                    {
                        destinfo.Add(query1[item * 10 + (ulong)i].Destination);
                    }
                    else
                    {
                        suffixes[index] = i;
                        index++;
                    }
                }

                //如果没有数量大于等于5的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 5)
                {
                    continue;
                }

                //补全
                if (suffixes[2] > -1)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    ulong codeNew0 = item * 10 + (ulong)suffixes[0];
                    ulong codeNew1 = item * 10 + (ulong)suffixes[1];
                    ulong codeNew2 = item * 10 + (ulong)suffixes[2];
                    ulong ccodeNew = GetCCode(codeNew0);
                    string destNew = GetDestination(codeNew0, query1);

                    if (destNew.Length > 0)
                    {
                        data.Add(new E164CoDestInfoULong
                        {
                            CCode = ccodeNew,
                            Code = codeNew0,
                            Destination = destNew,
                            CodeLen = codeNew0.MyLength()
                        });

                        data.Add(new E164CoDestInfoULong
                        {
                            CCode = ccodeNew,
                            Code = codeNew1,
                            Destination = destNew,
                            CodeLen = codeNew1.MyLength()
                        });

                        data.Add(new E164CoDestInfoULong
                        {
                            CCode = ccodeNew,
                            Code = codeNew2,
                            Destination = destNew,
                            CodeLen = codeNew2.MyLength()
                        });
                    }
                }
            }

            //1.4、处理项目为6的部分
            foreach (ulong item in subCode6)
            {
                //找出少的那4项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                int[] suffixes = new int[4] { -1, -1, -1, -1 };
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query1.ContainsKey(item * 10 + (ulong)i))
                    {
                        destinfo.Add(query1[item * 10 + (ulong)i].Destination);
                    }
                    else
                    {
                        suffixes[index] = i;
                        index++;
                    }
                }

                //如果没有数量大于等于6的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 6)
                {
                    continue;
                }

                //补全
                if (suffixes[3] > -1)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    ulong codeNew0 = item * 10 + (ulong)suffixes[0];
                    ulong codeNew1 = item * 10 + (ulong)suffixes[1];
                    ulong codeNew2 = item * 10 + (ulong)suffixes[2];
                    ulong codeNew3 = item * 10 + (ulong)suffixes[3];
                    ulong ccodeNew = GetCCode(codeNew0);
                    string destNew = GetDestination(codeNew0, query1);

                    if (destNew.Length > 0)
                    {
                        data.Add(new E164CoDestInfoULong
                        {
                            CCode = ccodeNew,
                            Code = codeNew0,
                            Destination = destNew,
                            CodeLen = codeNew0.MyLength()
                        });

                        data.Add(new E164CoDestInfoULong
                        {
                            CCode = ccodeNew,
                            Code = codeNew1,
                            Destination = destNew,
                            CodeLen = codeNew1.MyLength()
                        });

                        data.Add(new E164CoDestInfoULong
                        {
                            CCode = ccodeNew,
                            Code = codeNew2,
                            Destination = destNew,
                            CodeLen = codeNew2.MyLength()
                        });

                        data.Add(new E164CoDestInfoULong
                        {
                            CCode = ccodeNew,
                            Code = codeNew3,
                            Destination = destNew,
                            CodeLen = codeNew3.MyLength()
                        });
                    }
                }
            }

            //2、处理项目数量为10的部分
            List<ulong> subCode10 = data
                .Where(w => w.CodeLen > 1)
                .Select(s => s.Code / 10)
                .GroupBy(g => g)
                .Select(s => new { s.Key, cnt = s.Count() })
                .Where(w => w.cnt == 10)
                .Select(s => s.Key)
                .OrderBy(o => o)
                .ToList();

            //2.1、删除无用的大code
            foreach (ulong item in subCode10)
            {
                if (data.Exists(w => w.Code == item))
                {
                    //如果存在，即删除
                    for (int j = data.Count - 1; j >= 0; j--)
                    {
                        if (data[j].Code == item)
                        {
                            data.RemoveAt(j);
                            break;
                        }
                    }
                }
            }

            //2.2、重新规划code
            var query2 = data.ToLookup(codest => codest.CodeLen - 1);
            foreach (ulong item in subCode10)
            {
                //找出对应的10项中运营商数量最多的那个运营商名称
                var destNewInfo = query2[item.MyLength()]
                    .Where(w => w.Code.MyStartsWith(item))
                    .Select(s => s.Destination)
                    .GroupBy(g => g)
                    .Select(s => new { s.Key, cnt = s.Count() })
                    .OrderByDescending(o => o.cnt)
                    .ThenByDescending(o => o.Key)
                    .First();

                int j = 1;
                for (int i = data.Count - 1; i >= 0; i--)
                {
                    if (data[i].CodeLen == item.MyLength() + 1
                        && data[i].Destination == destNewInfo.Key
                        && data[i].Code.MyStartsWith(item))
                    {
                        data.RemoveAt(i);

                        if (j++ > destNewInfo.cnt)
                        {
                            break;
                        }
                    }
                }

                data.Add(new E164CoDestInfoULong
                {
                    CCode = GetCCode(item),
                    Code = item,
                    Destination = destNewInfo.Key,
                    CodeLen = item.MyLength()
                });
            }

            //3、如果同一个运营商内部有code包含关系，删除小code
            //例如DestA有code 480、4801-4808，则直接将4801-4808这几条数据删除
            //注意，如果A运营商有两个code：4801与480123，B运营商有code：48012，这个时候，A运营商的小code 480123不能删除
            var query3 = data.ToDictionary(codest => codest.Code);
            for (int i = data.Count - 1; i >= 0; i--)
            {
                E164CoDestInfoULong codest = data[i];
                ulong ccode = codest.CCode;
                ulong code = codest.Code;

                while (code.MyLength() > ccode.MyLength())
                {
                    code /= 10;
                    if (query3.ContainsKey(code))
                    {
                        if (query3[code].Destination == codest.Destination)
                        {
                            data.RemoveAt(i);
                        }
                        break;
                    }
                }
            }
        }

        //处理冗余的code，递归方法，处理的更彻底，但是有风险，ulong形式实现
        private void CleanRedundantDataLevel2(List<E164CoDestInfoULong> data)
        {
            recFlag = false;
            recTime++;    //记录递归的层数

            //1、如果同一个运营商内部有code包含关系，删除小code
            //例如DestA有code 480、4801-4808，则直接将4801-4808这几条数据删除
            //注意，如果A运营商有两个code：4801与480123，B运营商有code：48012，这个时候，A运营商的小code 480123不能删除
            var query1 = data.ToDictionary(codest => codest.Code);
            for (int i = data.Count - 1; i >= 0; i--)
            {
                E164CoDestInfoULong codest = data[i];
                ulong ccode = codest.CCode;
                ulong code = codest.Code;

                while (code.MyLength() > ccode.MyLength())
                {
                    code /= 10;
                    if (query1.ContainsKey(code))
                    {
                        if (query1[code].Destination == codest.Destination)
                        {
                            data.RemoveAt(i);
                            //recFlag = true;  //这个操作不需要进行第二次操作
                        }
                        break;
                    }
                }
            }

            //2、一组（xxxx0~xxxx9）code有9项/8项/7项，补充为10项
            List<ulong> subCode9 = new List<ulong>();
            List<ulong> subCode8 = new List<ulong>();
            List<ulong> subCode7 = new List<ulong>();
            List<ulong> subCode6 = new List<ulong>();
            var subCode0 = data
                .Where(w => w.CodeLen > 1)
                .Select(s => s.Code / 10)
                .GroupBy(g => g)
                .Select(s => new { s.Key, cnt = s.Count() });
            subCode9 = subCode0.Where(w => w.cnt == 9).Select(s => s.Key).OrderBy(o => o.ToString()).ToList();
            subCode8 = subCode0.Where(w => w.cnt == 8).Select(s => s.Key).OrderBy(o => o.ToString()).ToList();
            subCode7 = subCode0.Where(w => w.cnt == 7).Select(s => s.Key).OrderBy(o => o.ToString()).ToList();
            subCode6 = subCode0.Where(w => w.cnt == 6).Select(s => s.Key).OrderBy(o => o.ToString()).ToList();

            var query2 = data.ToDictionary(codest => codest.Code);

            //2.1、处理项目为9的部分
            foreach (ulong item in subCode9)
            {
                //找出少的那1项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                int suffix = -1;
                List<string> destinfo = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    if (query2.ContainsKey(item * 10 + (ulong)i))
                    {
                        destinfo.Add(query2[item * 10 + (ulong)i].Destination);
                    }
                    else
                    {
                        suffix = i;
                    }
                }

                //如果没有数量大于等于3的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 3)
                {
                    continue;
                }

                //补全
                if (suffix > -1)  //这个判断原则上永远为真
                {
                    if (query2.ContainsKey(item))
                    {
                        //如果存在，即更新
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (data[j].Code == item)
                            {
                                data[j].Code = data[j].Code * 10 + (ulong)suffix;
                                data[j].CodeLen++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        //如果不存在，即插入
                        ulong codeNew = item * 10 + (ulong)suffix;
                        string destNew = GetDestination(codeNew, query2);
                        if (destNew.Length > 0)
                        {
                            data.Add(new E164CoDestInfoULong
                            {
                                CCode = GetCCode(codeNew),  //destNew.Length > 0，就说明ccode不为空
                                Code = codeNew,
                                Destination = destNew,
                                CodeLen = codeNew.MyLength()
                            });
                        }
                    }
                }
            }

            //2.2、处理项目为8的部分
            foreach (ulong item in subCode8)
            {
                //找出少的那2项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                int[] suffixes = new int[2] { -1, -1 };
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query2.ContainsKey(item * 10 + (ulong)i))
                    {
                        destinfo.Add(query2[item * 10 + (ulong)i].Destination);
                    }
                    else
                    {
                        suffixes[index] = i;
                        index++;
                    }
                }

                //如果没有数量大于等于4的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 4)
                {
                    continue;
                }

                //补全
                if (suffixes[1] > -1)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    if (query2.ContainsKey(item))
                    {
                        //如果存在，将其改为缺少的第1项，然后再添加缺少的第2项
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (data[j].Code == item)
                            {
                                data.Add(new E164CoDestInfoULong
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code * 10 + (ulong)suffixes[1],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data[j].Code = data[j].Code * 10 + (ulong)suffixes[0];
                                data[j].CodeLen++;

                                break;
                            }
                        }
                    }
                    else
                    {
                        //如果不存在，即插入缺少的2项
                        ulong codeNew0 = item * 10 + (ulong)suffixes[0];
                        ulong codeNew1 = item * 10 + (ulong)suffixes[1];
                        ulong ccodeNew = GetCCode(codeNew0);
                        string destNew = GetDestination(codeNew0, query2);

                        if (destNew.Length > 0)
                        {
                            data.Add(new E164CoDestInfoULong
                            {
                                CCode = ccodeNew,
                                Code = codeNew0,
                                Destination = destNew,
                                CodeLen = codeNew0.MyLength()
                            });

                            data.Add(new E164CoDestInfoULong
                            {
                                CCode = ccodeNew,
                                Code = codeNew1,
                                Destination = destNew,
                                CodeLen = codeNew1.MyLength()
                            });
                        }
                    }
                }
            }

            //2.3、处理项目为7的部分
            foreach (ulong item in subCode7)
            {
                //找出少的那3项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                int[] suffixes = new int[3] { -1, -1, -1 };
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query2.ContainsKey(item * 10 + (ulong)i))
                    {
                        destinfo.Add(query2[item * 10 + (ulong)i].Destination);
                    }
                    else
                    {
                        suffixes[index] = i;
                        index++;
                    }
                }

                //如果没有数量大于等于5的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 5)
                {
                    continue;
                }

                //补全
                if (suffixes[2] > -1)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    if (query2.ContainsKey(item))
                    {
                        //如果存在，将其改为缺少的第1项，然后再添加缺少的后2项
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (data[j].Code == item)
                            {
                                data.Add(new E164CoDestInfoULong
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code * 10 + (ulong)suffixes[1],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data.Add(new E164CoDestInfoULong
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code * 10 + (ulong)suffixes[2],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data[j].Code = data[j].Code * 10 + (ulong)suffixes[0];
                                data[j].CodeLen++;

                                break;
                            }
                        }
                    }
                    else
                    {
                        //如果不存在，即插入缺少的3项，这里就3项，不写循环了
                        ulong codeNew0 = item * 10 + (ulong)suffixes[0];
                        ulong codeNew1 = item * 10 + (ulong)suffixes[1];
                        ulong codeNew2 = item * 10 + (ulong)suffixes[2];
                        ulong ccodeNew = GetCCode(codeNew0);
                        string destNew = GetDestination(codeNew0, query2);

                        if (destNew.Length > 0)
                        {
                            data.Add(new E164CoDestInfoULong
                            {
                                CCode = ccodeNew,
                                Code = codeNew0,
                                Destination = destNew,
                                CodeLen = codeNew0.MyLength()
                            });

                            data.Add(new E164CoDestInfoULong
                            {
                                CCode = ccodeNew,
                                Code = codeNew1,
                                Destination = destNew,
                                CodeLen = codeNew1.MyLength()
                            });

                            data.Add(new E164CoDestInfoULong
                            {
                                CCode = ccodeNew,
                                Code = codeNew2,
                                Destination = destNew,
                                CodeLen = codeNew2.MyLength()
                            });
                        }
                    }
                }
            }

            //2.4、处理项目为6的部分
            foreach (ulong item in subCode6)
            {
                //找出少的那4项，并记录已有项的运营商，用于分析是否需要执行下面的步骤
                int[] suffixes = new int[4] { -1, -1, -1, -1 };
                List<string> destinfo = new List<string>();
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (query2.ContainsKey(item * 10 + (ulong)i))
                    {
                        destinfo.Add(query2[item * 10 + (ulong)i].Destination);
                    }
                    else
                    {
                        suffixes[index] = i;
                        index++;
                    }
                }

                //如果没有数量大于等于6的运营商，跳出
                if (destinfo.GroupBy(g => g).Select(s => s.Count()).OrderByDescending(o => o).First() < 6)
                {
                    continue;
                }

                //补全
                if (suffixes[3] > -1)  //检查最后一项是否被赋值，这个判断原则上永远为真
                {
                    if (query2.ContainsKey(item))
                    {
                        //如果存在，将其改为缺少的第1项，然后再添加缺少的后3项
                        for (int j = 0; j < data.Count; j++)
                        {
                            if (data[j].Code == item)
                            {
                                data.Add(new E164CoDestInfoULong
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code * 10 + (ulong)suffixes[1],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data.Add(new E164CoDestInfoULong
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code * 10 + (ulong)suffixes[2],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data.Add(new E164CoDestInfoULong
                                {
                                    CCode = data[j].CCode,
                                    Code = data[j].Code * 10 + (ulong)suffixes[3],
                                    Destination = data[j].Destination,
                                    CodeLen = data[j].CodeLen + 1
                                });

                                data[j].Code += data[j].Code * 10 + (ulong)suffixes[0];
                                data[j].CodeLen++;

                                break;
                            }
                        }
                    }
                    else
                    {
                        //如果不存在，即插入缺少的4项，这里就4项，不写循环了
                        ulong codeNew0 = item * 10 + (ulong)suffixes[0];
                        ulong codeNew1 = item * 10 + (ulong)suffixes[1];
                        ulong codeNew2 = item * 10 + (ulong)suffixes[2];
                        ulong codeNew3 = item * 10 + (ulong)suffixes[3];
                        ulong ccodeNew = GetCCode(codeNew0);
                        string destNew = GetDestination(codeNew0, query2);

                        if (destNew.Length > 0)
                        {
                            data.Add(new E164CoDestInfoULong
                            {
                                CCode = ccodeNew,
                                Code = codeNew0,
                                Destination = destNew,
                                CodeLen = codeNew0.MyLength()
                            });

                            data.Add(new E164CoDestInfoULong
                            {
                                CCode = ccodeNew,
                                Code = codeNew1,
                                Destination = destNew,
                                CodeLen = codeNew1.MyLength()
                            });

                            data.Add(new E164CoDestInfoULong
                            {
                                CCode = ccodeNew,
                                Code = codeNew2,
                                Destination = destNew,
                                CodeLen = codeNew2.MyLength()
                            });

                            data.Add(new E164CoDestInfoULong
                            {
                                CCode = ccodeNew,
                                Code = codeNew3,
                                Destination = destNew,
                                CodeLen = codeNew3.MyLength()
                            });
                        }
                    }
                }
            }

            //3、处理项目数量为10的部分
            List<ulong> subCode10 = data
                .Where(w => w.CodeLen > 1)
                .Select(s => s.Code / 10)
                .GroupBy(g => g)
                .Select(s => new { s.Key, cnt = s.Count() })
                .Where(w => w.cnt == 10)
                .Select(s => s.Key)
                .OrderBy(o => o)
                .ToList();

            //3.1、删除无用的大code
            foreach (ulong item in subCode10)
            {
                if (data.Exists(w => w.Code == item))
                {
                    //如果存在，即删除
                    for (int j = data.Count - 1; j >= 0; j--)
                    {
                        if (data[j].Code == item)
                        {
                            data.RemoveAt(j);
                            break;
                        }
                    }
                }
            }

            //3.2、重新规划code
            var query3 = data.ToLookup(codest => codest.CodeLen - 1);
            foreach (ulong item in subCode10)
            {
                //找出对应的10项中运营商数量最多的那个运营商名称
                var destNewInfo = query3[item.MyLength()]
                    .Where(w => w.Code.MyStartsWith(item))
                    .Select(s => s.Destination)
                    .GroupBy(g => g)
                    .Select(s => new { s.Key, cnt = s.Count() })
                    .OrderByDescending(o => o.cnt)
                    .ThenByDescending(o => o.Key)
                    .First();

                int j = 1;
                for (int i = data.Count - 1; i >= 0; i--)
                {
                    if (data[i].CodeLen == item.MyLength() + 1
                        && data[i].Destination == destNewInfo.Key
                        && data[i].Code.MyStartsWith(item))
                    {
                        data.RemoveAt(i);

                        if (j++ > destNewInfo.cnt)
                        {
                            break;
                        }
                    }
                }

                data.Add(new E164CoDestInfoULong
                {
                    CCode = GetCCode(item),
                    Code = item,
                    Destination = destNewInfo.Key,
                    CodeLen = item.MyLength()
                });
            }

            //递归
            //subCode9.Count > 0 || subCode7.Count > 0 || subCode8.Count > 0 都会转为 subCode10.Count > 0
            if (subCode10.Count > 0)
            {
                recFlag = true;
            }

            if (recFlag && recTime <= 16)
            {
                CleanRedundantDataLevel2(data);
            }
        }
        #endregion

        #region 展开运营商code
        //展开运营商的code，string形式实现
        //目的：将运营商的code展开，保证以展开后的code开头的号码，一定是该运营商的，即运营商展开code后，就没有小code属于其他运营商了；
        //例如：DestA：8801，DestB：8801[0-3]；那么展开DestA就是DestA：8801[4-9]；
        public List<E164CoDest> ExpandDestCode(List<E164CoDest> data, List<string> countryCodes, string destination)
        {
            //保证整个列表中code没有重复，有重复直接抛异常跳出，人工处理重复的部分
            if (data.Count != data.Select(i => i.Code).ToList().Distinct().Count())
            {
                throw new Exception("code有重复，请手动去除重复后处理。");
            }

            //排序，稍后查找的时候，找到第一个就跳出
            ccodeInfoStr = countryCodes.OrderByDescending(o => o.Length).ThenBy(o => o).ToList();

            //准备数据
            data2doStr = new List<E164CoDestInfo>();
            data = data.OrderBy(o => o.Code).ToList();
            foreach (E164CoDest item in data)
            {
                data2doStr.Add(new E164CoDestInfo()
                {
                    CCode = GetCCode(item.Code),
                    Code = item.Code,
                    Destination = item.Destination,
                    CodeLen = item.Code.Length
                });
            }

            //开始计算
            return ExpandDestCodeBody(data2doStr, destination);
        }

        //展开运营商的code的具体实现，string形式实现
        private List<E164CoDest> ExpandDestCodeBody(List<E164CoDestInfo> data, string destination)
        {
            List<E164CoDest> result = new List<E164CoDest>();

            E164CoDestInfo[] destTars = data
                .Where(w => w.Destination == destination)
                .OrderByDescending(o => o.CodeLen)
                .ThenByDescending(o => o.Code)
                .ToArray();

            //循环处理每一项destination的code
            for (int i = 0; i < destTars.Length; i++)
            {
                //找出destTar[i].Code的小code
                List<string> subCodes = new List<string>();
                for (int j = data.Count - 1; j >= 0; j--)
                {
                    if (data[j].CCode == destTars[i].CCode
                        && data[j].Destination != destination
                        && data[j].Code.StartsWith(destTars[i].Code))
                    {
                        subCodes.Add(data[j].Code);
                        data.RemoveAt(j);
                    }
                }

                if (subCodes.Count == 0)
                {
                    result.Add(new E164CoDest()
                    {
                        Code = destTars[i].Code,
                        Destination = destination
                    });

                    continue;
                }

                //计算小code的最大长度，用于计算循环的次数
                int maxSubLen = subCodes.Max(max => max.Length);
                int mainDestLen = destTars[i].CodeLen;
                int times = 0;
                //循环计算展开后的code
                while (times < maxSubLen - mainDestLen)
                {
                    var dic1 = subCodes.ToDictionary(d => d);
                    string[] query = subCodes.Where(w => w.Length == maxSubLen - times).Select(s => s.Substring(0, s.Length - 1)).Distinct().ToArray();

                    //计算结果
                    foreach (string item in query)
                    {
                        for (int m = 0; m < 10; m++)
                        {
                            if (!dic1.ContainsKey(item + m.ToString()))
                            {
                                result.Add(new E164CoDest()
                                {
                                    Code = item + m.ToString(),
                                    Destination = destination
                                });
                            }
                        }
                    }

                    //修正subCodes
                    var dic2 = query.ToDictionary(d => d);
                    for (int n = subCodes.Count - 1; n >= 0; n--)
                    {
                        if (dic2.ContainsKey(subCodes[n].Substring(0, subCodes[n].Length - 1)))
                        {
                            subCodes.RemoveAt(n);
                        }
                    }
                    subCodes.AddRange(query);
                    subCodes = subCodes.Distinct().ToList();

                    times++;
                }
            }

            //结果可能会有重复，比方说源数据为：A,123/1231; B,1232/1233/1234，那么展开A的结果会有两条1231
            //这个是后来发现的问题，就在这里去重复了，如果想要优化，可以考虑能不能在过程中处理，而不是在这里去重复
            return result.Distinct().ToList();
        }

        //展开运营商的code，ulong形式实现
        public List<E164CoDestULong> ExpandDestCode(List<E164CoDestULong> data, List<ulong> countryCodes, string destination)
        {
            //保证整个列表中code没有重复，有重复直接抛异常跳出，人工处理重复的部分
            if (data.Count != data.Select(i => i.Code).ToList().Distinct().Count())
            {
                throw new Exception("code有重复，请手动去除重复后处理。");
            }

            //排序，稍后查找的时候，找到第一个就跳出
            ccodeInfoULong = countryCodes.OrderByDescending(o => o).ToList();

            //准备数据
            data2doULong = new List<E164CoDestInfoULong>();
            data = data.OrderBy(o => o.Code.ToString()).ToList();
            foreach (E164CoDestULong item in data)
            {
                data2doULong.Add(new E164CoDestInfoULong()
                {
                    CCode = GetCCode(item.Code),
                    Code = item.Code,
                    Destination = item.Destination,
                    CodeLen = item.Code.MyLength()
                });
            }

            //开始计算
            return ExpandDestCodeBody(data2doULong, destination);
        }

        //展开运营商的code的具体实现，ulong形式实现
        private List<E164CoDestULong> ExpandDestCodeBody(List<E164CoDestInfoULong> data, string destination)
        {
            List<E164CoDestULong> result = new List<E164CoDestULong>();

            E164CoDestInfoULong[] destTars = data
                .Where(w => w.Destination == destination)
                .OrderByDescending(o => o.CodeLen)
                .ThenByDescending(o => o.Code)
                .ToArray();

            //循环处理每一项destination的code
            for (int i = 0; i < destTars.Length; i++)
            {
                //找出destTar[i].Code的小code
                List<ulong> subCodes = new List<ulong>();
                for (int j = data.Count - 1; j >= 0; j--)
                {
                    if (data[j].CCode == destTars[i].CCode
                        && data[j].Destination != destination
                        && data[j].Code.MyStartsWith(destTars[i].Code))
                    {
                        subCodes.Add(data[j].Code);
                        data.RemoveAt(j);
                    }
                }

                if (subCodes.Count == 0)
                {
                    result.Add(new E164CoDestULong()
                    {
                        Code = destTars[i].Code,
                        Destination = destination
                    });

                    continue;
                }

                //计算小code的最大长度，用于计算循环的次数
                int maxSubLen = subCodes.Max(max => max.MyLength());
                int mainDestLen = destTars[i].CodeLen;
                int times = 0;
                //循环计算展开后的code
                while (times < maxSubLen - mainDestLen)
                {
                    var dic1 = subCodes.ToDictionary(d => d);
                    ulong[] query = subCodes.Where(w => w.MyLength() == maxSubLen - times).Select(s => s / 10).Distinct().ToArray();

                    //计算结果
                    foreach (ulong item in query)
                    {
                        for (int m = 0; m < 10; m++)
                        {
                            if (!dic1.ContainsKey(item * 10 + (ulong)m))
                            {
                                result.Add(new E164CoDestULong()
                                {
                                    Code = item * 10 + (ulong)m,
                                    Destination = destination
                                });
                            }
                        }
                    }

                    //修正subCodes
                    var dic2 = query.ToDictionary(d => d);
                    for (int n = subCodes.Count - 1; n >= 0; n--)
                    {
                        if (dic2.ContainsKey(subCodes[n] / 10))
                        {
                            subCodes.RemoveAt(n);
                        }
                    }
                    subCodes.AddRange(query);
                    subCodes = subCodes.Distinct().ToList();

                    times++;
                }
            }

            //结果可能会有重复，比方说源数据为：A,123/1231; B,1232/1233/1234，那么展开A的结果会有两条1231
            //这个是后来发现的问题，就在这里去重复了，如果想要优化，可以考虑能不能在过程中处理，而不是在这里去重复
            return result.Distinct().ToList();
        }
        #endregion

        #region 对比code
        public Dictionary<string, (string lcode, string rcode)> CompareCode(HashSet<string> codeleft, HashSet<string> coderight, List<string> countryCodes)
        {
            Dictionary<string, (string lcode, string rcode)> result = new Dictionary<string, (string lcode, string rcode)>();

            //排序，稍后查找的时候，找到第一个就跳出
            ccodeInfoStr = countryCodes.OrderByDescending(o => o.Length).ThenBy(o => o).ToList();
            //赋值一份原始的右表，后面需要用
            HashSet<string> coderightcopy = new HashSet<string>(coderight);

            //遍历左表
            foreach (string item in codeleft)
            {
                if (coderight.Remove(item))
                {
                    result.Add(item, (item, item));
                }
                else
                {
                    string ccode = GetCCode(item);
                    if (ccode.Length != 0)
                    {
                        bool flag = false;
                        string subcode = item.Substring(0, item.Length - 1);
                        while (subcode.Length >= ccode.Length)
                        {
                            if (coderightcopy.Contains(subcode))
                            {
                                flag = true;
                                break;
                            }
                            subcode = subcode.Substring(0, subcode.Length - 1);
                        }

                        if (flag)
                        {
                            result.Add(item, (item, subcode));
                        }
                        else
                        {
                            result.Add(item, (item, string.Empty));
                        }
                    }
                }
            }

            //遍历右表
            foreach (string item in coderight)
            {
                string ccode = GetCCode(item);
                if (ccode.Length != 0)
                {
                    bool flag = false;
                    string subcode = item.Substring(0, item.Length - 1);
                    while (subcode.Length >= ccode.Length)
                    {
                        if (codeleft.Contains(subcode))
                        {
                            flag = true;
                            break;
                        }
                        subcode = subcode.Substring(0, subcode.Length - 1);
                    }

                    if (flag)
                    {
                        result.Add(item, (subcode, item));
                    }
                    else
                    {
                        result.Add(item, (string.Empty, item));
                    }
                }
            }

            return result;
        }

        public Dictionary<ulong, (ulong lcode, ulong rcode)> CompareCode(HashSet<ulong> codeleft, HashSet<ulong> coderight, List<ulong> countryCodes)
        {
            Dictionary<ulong, (ulong lcode, ulong rcode)> result = new Dictionary<ulong, (ulong lcode, ulong rcode)>();

            //排序，稍后查找的时候，找到第一个就跳出
            ccodeInfoULong = countryCodes.OrderByDescending(o => o).ToList();
            //赋值一份原始的右表，后面需要用
            HashSet<ulong> coderightcopy = new HashSet<ulong>(coderight);

            //遍历左表
            foreach (ulong item in codeleft)
            {
                if (coderight.Remove(item))
                {
                    result.Add(item, (item, item));
                }
                else
                {
                    ulong ccode = GetCCode(item);
                    if (ccode != 0)
                    {
                        bool flag = false;
                        ulong subcode = item / 10;
                        while (subcode >= ccode)
                        {
                            if (coderightcopy.Contains(subcode))
                            {
                                flag = true;
                                break;
                            }
                            subcode /= 10;
                        }

                        if (flag)
                        {
                            result.Add(item, (item, subcode));
                        }
                        else
                        {
                            result.Add(item, (item, 0));
                        }
                    }
                }
            }

            //遍历右表
            foreach (ulong item in coderight)
            {
                ulong ccode = GetCCode(item);
                if (ccode != 0)
                {
                    bool flag = false;
                    ulong subcode = item / 10;
                    while (subcode >= ccode)
                    {
                        if (codeleft.Contains(subcode))
                        {
                            flag = true;
                            break;
                        }
                        subcode /= 10;
                    }

                    if (flag)
                    {
                        result.Add(item, (subcode, item));
                    }
                    else
                    {
                        result.Add(item, (0, item));
                    }
                }
            }

            return result;
        }
        #endregion

        #region 找出号码对应的code
        public string GetCodebyNumber(string number, HashSet<string> codes)
        {
            string result = string.Empty;

            int len = number.Length;
            for (int i = 0; i < len; i++)
            {
                if (codes.Contains(number.Substring(0, len - i)))
                {
                    result = number.Substring(0, len - i);
                    break;
                }
            }

            return result;
        }

        public ulong GetCodebyNumber(ulong number, HashSet<ulong> codes)
        {
            ulong result = 0;

            int len = number.MyLength();
            for (int i = 0; i < len; i++)
            {
                if (codes.Contains(number / (ulong)Math.Pow(10, i)))
                {
                    result = number / (ulong)Math.Pow(10, i);
                    break;
                }
            }

            return result;
        }
        #endregion

        #region 通过code查找ccode
        //通过code查找ccode
        //查找国家code这个位置有优化的空间
        //    如果是77开头，直接返回77，如果是1开头，按照现在的逻辑找，其他的按照二分法找
        //    担心以后有意外，出现其他国家code有包含关系，这里就这样写了
        private string GetCCode(string code)
        {
            string result = string.Empty;

            foreach (string item in ccodeInfoStr)
            {
                if (code.StartsWith(item))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        private ulong GetCCode(ulong code)
        {
            ulong result = 0;

            foreach (ulong item in ccodeInfoULong)
            {
                if (code.MyStartsWith(item))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }
        #endregion

        #region 通过code查找其对应的运营商名称
        //通过code查找其对应的运营商名称
        private string GetDestination(string code, Dictionary<string, E164CoDestInfo> data)
        {
            string result = string.Empty;

            string ccode = GetCCode(code);
            if (ccode.Length != 0)
            {
                while (code.Length >= ccode.Length)
                {
                    if (data.ContainsKey(code))
                    {
                        result = data[code].Destination;
                        break;
                    }
                    code = code.Substring(0, code.Length - 1);
                }
            }

            return result;
        }

        private string GetDestination(ulong code, Dictionary<ulong, E164CoDestInfoULong> data)
        {
            string result = string.Empty;

            ulong ccode = GetCCode(code);
            if (ccode != 0)
            {
                while (code >= ccode)
                {
                    if (data.ContainsKey(code))
                    {
                        result = data[code].Destination;
                        break;
                    }
                    code /= 10;
                }
            }

            return result;
        }
        #endregion
    }

    public struct E164CoDest
    {
        public string Code { get; set; }
        public string Destination { get; set; }
    }

    public struct E164CoDestULong
    {
        public ulong Code { get; set; }
        public string Destination { get; set; }
    }

    public class E164CoDestInfo  //如果声明为Struct，无法更改其属性，没有搞清楚，就使用Class了
    {
        public string CCode { get; set; }
        public string Code { get; set; }
        public string Destination { get; set; }
        public int CodeLen { get; set; }
    }

    public class E164CoDestInfoULong  //如果声明为Struct，无法更改其属性，没有搞清楚，就使用Class了
    {
        public ulong CCode { get; set; }
        public ulong Code { get; set; }
        public string Destination { get; set; }
        public int CodeLen { get; set; }
    }
}
