/* 字符串的存储结构 */
#include "my_macro.h"

#define MAXSIZE 40                 // 存储空间初始分配量

typedef char String[MAXSIZE + 1];  // 0号单元存放串的长度


/* 初始条件: 串S和T存在 */
/* 操作结果: 若S>T,则返回值>0;若S=T,则返回值=0;若S<T,则返回值<0 */
int StrCompare(String S, String T)
{
    int i;
    for (i = 1; i <= S[0] && i <= T[0]; ++i)
        if (S[i] != T[i])
            return S[i] - T[i];
    return S[0] - T[0];
}


/* 返回串的元素个数 */
int StrLength(String S)
{
    return S[0];
}


/* 用Sub返回串S的第pos个字符起长度为len的子串。 */
Status SubString(String Sub, String S, int pos, int len)
{
    int i;
    if (pos < 1 || pos > S[0] || len < 0 || len > S[0] - pos + 1)
        return ERROR;
    for (i = 1; i <= len; i++)
        Sub[i] = S[pos + i - 1];
    Sub[0] = len;
    return OK;
}


/* Index操作，借助其他函数实现 */
// T为非空串。若主串S中第pos个字符之后存在与T相等的子串，则返回第一个这样的子串在S中的位置，否则返回0
int Index(String S, String T, int pos)
{
    int n, m, i;
    String sub;
    if (pos > 0)
    {
        n = StrLength(S);                 // 得到主串S的长度
        m = StrLength(T);                 // 得到主串T的长度
        i = pos;
        while (i <= n - m + 1)
        {
            SubString(sub, S, i, m);      // 取主串中第i个位置长度与T相等的子串给sub
            if (StrCompare(sub, T) != 0)  // 如果两串不相等
                ++i;
            else                          // 如果两串相等，则返回i值
                return i;
        }
    }

    return 0;                             // 若无子串与T相等，返回0
}


/* Index操作，独立实现 */
// 返回子串T在主串S中第pos个字符之后的位置。若不存在,则函数返回值为0。其中，T非空，1≤pos≤StrLength(S)。
int Index2(String S, String T, int pos)
{
    int i = pos;                    // i用于主串S中当前位置下标值，从pos位置开始匹配
    int j = 1;                      // j用于子串T中当前位置下标值
    while (i <= S[0] && j <= T[0])  // 若i小于S的长度并且j小于T的长度时，循环继续
    {
        if (S[i] == T[j])           // 两字母相等则继续
        {
            ++i;
            ++j;
        }
        else                        // 指针后退重新开始匹配
        {
            i = i - j + 2;          // i退回到上次匹配首位的下一位
            j = 1;                  // j退回到子串T的首位
        }
    }

    if (j > T[0])
        return i - T[0];
    else
        return 0;
}
