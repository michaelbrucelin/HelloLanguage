#### [](https://leetcode.cn/problems/integer-to-roman/solution/zheng-shu-zhuan-luo-ma-shu-zi-by-leetcod-75rs//#ǰ��)ǰ��

**�������ַ���**

���������� 7 ����ͬ�ĵ���ĸ������ɣ�ÿ�����Ŷ�Ӧһ���������ֵ�����⣬�������������������������������˶���� 6 �����Ϸ��š�����������ܹ� 13 �����صķ��ţ�ÿ�������� 1 ���� 2 ����ĸ��ɣ�������ͼ��ʾ��

![](./Solution0012_2_1.png)

**�������ֵ�Ψһ��ʾ��**

�����Ǵ�һ���������֡����� 140 ���������ֱ�ʾ��������һ������ȷ�ģ�

![](./Solution0012_2_2.svg)

��������ȷ���������ֵĹ����ǣ������������ִ����ҵ�ÿһλ��ѡ�񾡿��ܴ�ķ���ֵ������ 140��������ѡ��ķ���ֵΪ C=100��������������ʣ������� 40��������ѡ��ķ���ֵΪ XL=40����ˣ�140 �Ķ�Ӧ����������Ϊ C+XL=CXL��

#### [](https://leetcode.cn/problems/integer-to-roman/solution/zheng-shu-zhuan-luo-ma-shu-zi-by-leetcod-75rs//#����һ��ģ��)����һ��ģ��

**˼·**

�����������ֵ�Ψһ��ʾ����Ϊ�˱�ʾһ������������ num������Ѱ�Ҳ����� num ��������ֵ���� num ��ȥ�÷���ֵ��Ȼ�����Ѱ�Ҳ����� num ��������ֵ�����÷���ƴ������һ���ҵ��ķ���֮��ѭ��ֱ�� num Ϊ 0�����õ����ַ�����Ϊ num ���������ֱ�ʾ��

���ʱ�����Խ���һ����ֵ-���ŶԵ��б� valueSymbols������ֵ�Ӵ�С���С����� valueSymbols �е�ÿ����ֵ-���Ŷԣ�����ǰ��ֵ value ������ num����� num �в��ϼ�ȥ value��ֱ�� num С�� value��Ȼ�������һ����ֵ-���Ŷԡ��������� num Ϊ 0 ������ѭ����

**����**

```C++
const pair<int, string> valueSymbols[] = {
    {1000, "M"},
    {900,  "CM"},
    {500,  "D"},
    {400,  "CD"},
    {100,  "C"},
    {90,   "XC"},
    {50,   "L"},
    {40,   "XL"},
    {10,   "X"},
    {9,    "IX"},
    {5,    "V"},
    {4,    "IV"},
    {1,    "I"},
};

class Solution {
public:
    string intToRoman(int num) {
        string roman;
        for (const auto &[value, symbol] : valueSymbols) {
            while (num >= value) {
                num -= value;
                roman += symbol;
            }
            if (num == 0) {
                break;
            }
        }
        return roman;
    }
};

```

```Java
class Solution {
    int[] values = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
    String[] symbols = {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};

    public String intToRoman(int num) {
        StringBuffer roman = new StringBuffer();
        for (int i = 0; i < values.length; ++i) {
            int value = values[i];
            String symbol = symbols[i];
            while (num >= value) {
                num -= value;
                roman.append(symbol);
            }
            if (num == 0) {
                break;
            }
        }
        return roman.toString();
    }
}

```

```C#
public class Solution {
    readonly Tuple<int, string>[] valueSymbols = {
        new Tuple<int, string>(1000, "M"),
        new Tuple<int, string>(900, "CM"),
        new Tuple<int, string>(500, "D"),
        new Tuple<int, string>(400, "CD"),
        new Tuple<int, string>(100, "C"),
        new Tuple<int, string>(90, "XC"),
        new Tuple<int, string>(50, "L"),
        new Tuple<int, string>(40, "XL"),
        new Tuple<int, string>(10, "X"),
        new Tuple<int, string>(9, "IX"),
        new Tuple<int, string>(5, "V"),
        new Tuple<int, string>(4, "IV"),
        new Tuple<int, string>(1, "I")
    };

    public string IntToRoman(int num) {
        StringBuilder roman = new StringBuilder();
        foreach (Tuple<int, string> tuple in valueSymbols) {
            int value = tuple.Item1;
            string symbol = tuple.Item2;
            while (num >= value) {
                num -= value;
                roman.Append(symbol);
            }
            if (num == 0) {
                break;
            }
        }
        return roman.ToString();
    }
}

```

```Go
var valueSymbols = []struct {
    value  int
    symbol string
}{
    {1000, "M"},
    {900, "CM"},
    {500, "D"},
    {400, "CD"},
    {100, "C"},
    {90, "XC"},
    {50, "L"},
    {40, "XL"},
    {10, "X"},
    {9, "IX"},
    {5, "V"},
    {4, "IV"},
    {1, "I"},
}

func intToRoman(num int) string {
    roman := []byte{}
    for _, vs := range valueSymbols {
        for num >= vs.value {
            num -= vs.value
            roman = append(roman, vs.symbol...)
        }
        if num == 0 {
            break
        }
    }
    return string(roman)
}

```

```JavaScript
var intToRoman = function(num) {
    const valueSymbols = [[1000, "M"], [900, "CM"], [500, "D"], [400, "CD"], [100, "C"], [90, "XC"], [50, "L"], [40, "XL"], [10, "X"], [9, "IX"], [5, "V"], [4, "IV"], [1, "I"]];
    const roman = [];
    for (const [value, symbol] of valueSymbols) {
        while (num >= value) {
            num -= value;
            roman.push(symbol);
        }
        if (num == 0) {
            break;
        }
    }
    return roman.join('');
};

```

```Python
class Solution:

    VALUE_SYMBOLS = [
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I"),
    ]

    def intToRoman(self, num: int) -> str:
        roman = list()
        for value, symbol in Solution.VALUE_SYMBOLS:
            while num >= value:
                num -= value
                roman.append(symbol)
            if num == 0:
                break
        return "".join(roman)

```

```C
const int values[] = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
const char* symbols[] = {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};

char* intToRoman(int num) {
    char* roman = malloc(sizeof(char) * 16);
    roman[0] = '\0';
    for (int i = 0; i < 13; i++) {
        while (num >= values[i]) {
            num -= values[i];
            strcpy(roman + strlen(roman), symbols[i]);
        }
        if (num == 0) {
            break;
        }
    }
    return roman;
}

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(1)������ valueSymbols �����ǹ̶��ģ����� 13 �ַ��е�ÿ���ַ��ĳ��ִ��������ᳬ�� 3�����ѭ��������һ��ȷ�������ޡ����ڱ�����������ݷ�Χ��ѭ���������ᳬ�� 15 �Ρ�

-   �ռ临�Ӷȣ�O(1)��
