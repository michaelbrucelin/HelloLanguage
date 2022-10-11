/*�ַ����Ĵ洢�ṹ*/
#define MAXSIZE 40                 // �洢�ռ��ʼ������

typedef char String[MAXSIZE + 1];  // 0�ŵ�Ԫ��Ŵ��ĳ���

#define OK 1
#define ERROR 0

typedef int Status;                // Status�Ǻ���������,��ֵ�Ǻ������״̬���룬��OK��


/* ��ʼ����: ��S��T���� */
/* �������: ��S>T,�򷵻�ֵ>0;��S=T,�򷵻�ֵ=0;��S<T,�򷵻�ֵ<0 */
int StrCompare(String S, String T)
{
	int i;
	for (i = 1; i <= S[0] && i <= T[0]; ++i)
		if (S[i] != T[i])
			return S[i] - T[i];
	return S[0] - T[0];
}


/* ���ش���Ԫ�ظ��� */
int StrLength(String S)
{
	return S[0];
}


/* ��Sub���ش�S�ĵ�pos���ַ��𳤶�Ϊlen���Ӵ��� */
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


/*Index����*/
// �����Ӵ�T������S�е�pos���ַ�֮���λ�á���������,��������ֵΪ0��
// ���У�T�ǿգ�1��pos��StrLength(S)��
int Index(String S, String T, int pos)
{
	int n, m, i;
	String sub;
	if (pos > 0)
	{
		n = StrLength(S);                 // �õ�����S�ĳ���
		m = StrLength(T);                 // �õ�����T�ĳ���
		i = pos;
		while (i <= n - m + 1)
		{
			SubString(sub, S, i, m);      // ȡ�����е�i��λ�ó�����T��ȵ��Ӵ���sub
			if (StrCompare(sub, T) != 0)  // ������������
				++i;
			else                          // ���������ȣ��򷵻�iֵ
				return i;
		}
	}

	return 0;                             // �����Ӵ���T��ȣ�����0
}
