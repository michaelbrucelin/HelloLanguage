using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestCSharp
{
    /// <summary>
    /// 使用自定义的64进制“数字”将guid string缩短为22位
    /// </summary>
    public static class MyUtilsGuid
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// 使用0-9 a-z A-Z +-构造64进制的“数字”
        /// </summary>
        private static Dictionary<int, char> map = new Dictionary<int, char>()
        {
            {0,'0'},{1,'1'},{2,'2'},{3,'3'},{4,'4'},{5,'5'},{6,'6'},{7,'7'},{8,'8'},{9,'9'},
            {10,'a'},{11,'b'},{12,'c'},{13,'d'},{14,'e'},{15,'f'},{16,'g'},{17,'h'},{18,'i'},{19,'j'},{20,'k'},{21,'l'},{22,'m'},{23,'n'},{24,'o'},{25,'p'},{26,'q'},{27,'r'},{28,'s'},{29,'t'},{30,'u'},{31,'v'},{32,'w'},{33,'x'},{34,'y'},{35,'z'},
            {36,'A'},{37,'B'},{38,'C'},{39,'D'},{40,'E'},{41,'F'},{42,'G'},{43,'H'},{44,'I'},{45,'J'},{46,'K'},{47,'L'},{48,'M'},{49,'N'},{50,'O'},{51,'P'},{52,'Q'},{53,'R'},{54,'S'},{55,'T'},{56,'U'},{57,'V'},{58,'W'},{59,'X'},{60,'Y'},{61,'Z'},
            {62,'+'},{63,'-'}
        };

        /// <summary>
        /// 使用0-9 a-z A-Z +-构造64进制的“数字”
        /// </summary>
        private static Dictionary<char, int> map_reverse = new Dictionary<char, int>()
        {
            {'0',0},{'1',1},{'2',2},{'3',3},{'4',4},{'5',5},{'6',6},{'7',7},{'8',8},{'9',9},
            {'a',10},{'b',11},{'c',12},{'d',13},{'e',14},{'f',15},{'g',16},{'h',17},{'i',18},{'j',19},{'k',20},{'l',21},{'m',22},{'n',23},{'o',24},{'p',25},{'q',26},{'r',27},{'s',28},{'t',29},{'u',30},{'v',31},{'w',32},{'x',33},{'y',34},{'z',35},
            {'A',36},{'B',37},{'C',38},{'D',39},{'E',40},{'F',41},{'G',42},{'H',43},{'I',44},{'J',45},{'K',46},{'L',47},{'M',48},{'N',49},{'O',50},{'P',51},{'Q',52},{'R',53},{'S',54},{'T',55},{'U',56},{'V',57},{'W',58},{'X',59},{'Y',60},{'Z',61},
            {'+',62},{'-',63}
        };

        /// <summary>
        /// 使用自定义的64进制“数字”将guid string缩短为22位
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string GuidToShort(Guid guid)
        {
            char[] result = new char[22];

            BitArray bits = new BitArray(guid.ToByteArray());
            int key;
            for (int i = 0; i < 21; i++)
            {
                key = 0;
                for (int j = 0; j < 6; j++)
                {
                    key = (key << 1) | (bits[i * 6 + j] ? 1 : 0);
                }
                result[i] = map[key];
            }
            key = ((bits[126] ? 1 : 0) << 1) | (bits[127] ? 1 : 0);  // 最后一组，只剩下索引为126与127的两个值
            for (int i = 0; i < 4; i++)                              // 为了是最后一个字符不局限于0-3，随机补4位，当还原为GUID的时候，忽略这4位即可
                key = (key << 1) | (random.Next(0, 2));
            result[21] = map[key];

            return new string(result);
        }

        /// <summary>
        /// 将uuid还原为原始的guid样式
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static string GetOriginalStr(string uuid)
        {
            if (uuid.Length != 22)
                throw new Exception("Incorrect length of uuid.");
            if (Regex.IsMatch(uuid, @"[^0-9a-zA-Z+-]"))
                throw new Exception("Incorrect format of uuid.");

            BitArray buffer = new BitArray(128);
            int point;
            int index = 0;
            for (int i = 0; i < uuid.Length - 1; i++)    // 从前向后逐个字符处理
            {
                point = map_reverse[uuid[i]];
                for (int j = 0; j < 6; j++)
                {
                    buffer[index++] = (point & 32) == 32;
                    point <<= 1;
                }
            }
            point = map_reverse[uuid[uuid.Length - 1]];  // 最后一个字符单独处理
            buffer[126] = ((point >> 3) & 1) == 1;
            buffer[127] = ((point >> 2) & 1) == 1;

            byte[] result = new byte[16];
            buffer.CopyTo(result, 0);

            return new Guid(result).ToString();
        }
    }
}
