/*字符串的存储结构*/
#define MAXSIZE 40                 // 存储空间初始分配量

typedef char String[MAXSIZE + 1];  // 0号单元存放串的长度

#define OK 1
#define ERROR 0

typedef int Status;                // Status是函数的类型,其值是函数结果状态代码，如OK等


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


/*Index操作*/
// 返回子串T在主串S中第pos个字符之后的位置。若不存在,则函数返回值为0。
// 其中，T非空，1≤pos≤StrLength(S)。
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
