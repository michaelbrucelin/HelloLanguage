#include "01��_String.c"

/* ͨ�����㷵���Ӵ�T��next���� */
void get_next(String T, int* next)
{
	int i, k;
	i = 1;
	k = 0;
	next[1] = 0;
	while (i < T[0])      // �˴�T[0]��ʾ��T�ĳ���
	{
		if (k == 0 || T[i] == T[k])
		{
			++i;
			++k;
			next[i] = k;
		}
		else
			k = next[k];  // ���ַ�����ͬ����kֵ����
	}
}

/* �����Ӵ�T������S�е�pos���ַ�֮���λ�á��������ڣ���������ֵΪ0�� */
// T�ǿգ�1��pos��StrLength(S)
int Index_KMP(String S, String T, int pos)
{
	int i = pos;                     // i��������S�е�ǰλ���±�ֵ����pos��Ϊ1�����posλ�ÿ�ʼƥ��
	int j = 1;                       // j�����Ӵ�T�е�ǰλ���±�ֵ
	int next[255];                   // ����һnext����
	get_next(T, next);               // �Դ�T���������õ�next����
	while (i <= S[0] && j <= T[0])   // ��iС��S�ĳ��Ȳ���jС��T�ĳ���ʱ��ѭ������
	{
		if (j == 0 || S[i] == T[j])  // ����ĸ�����������������㷨������j=0�ж�
		{
			++i;
			++j;
		}
		else                         // ָ��������¿�ʼƥ��
			j = next[j];             // j�˻غ��ʵ�λ�ã�iֵ����
	}
	if (j > T[0])
		return i - T[0];
	else
		return 0;
}

/* ��ģʽ��T��next��������ֵ����������nextval */
void get_next2(String T, int* next)
{
	int i, k;
	i = 1;
	k = 0;
	next[1] = 0;
	while (i < T[0])                 // �˴�T[0]��ʾ��T�ĳ���
	{
		if (k == 0 || T[i] == T[k])  // T[i]��ʾ��׺�ĵ����ַ���T[k]��ʾǰ׺�ĵ����ַ�
		{
			++i;
			++k;
			if (T[i] != T[k])        // ����ǰ�ַ���ǰ׺�ַ���ͬ
				next[i] = k;         // ��ǰ��jΪnextval��iλ�õ�ֵ
			else
				next[i] = next[k];   // �����ǰ׺�ַ���ͬ����ǰ׺�ַ���
			// nextvalֵ��ֵ��nextval��iλ�õ�ֵ
		}
		else
			k = next[k];             // ���ַ�����ͬ����kֵ����
	}
}

int Index_KMP2(String S, String T, int pos)
{
	int i = pos;                     // i��������S�е�ǰλ���±�ֵ����pos��Ϊ1�����posλ�ÿ�ʼƥ��
	int j = 1;                       // j�����Ӵ�T�е�ǰλ���±�ֵ
	int next[255];                   // ����һnext����
	get_next2(T, next);              // �Դ�T���������õ�next����
	while (i <= S[0] && j <= T[0])   // ��iС��S�ĳ��Ȳ���jС��T�ĳ���ʱ��ѭ������
	{
		if (j == 0 || S[i] == T[j])  // ����ĸ�����������������㷨������j=0�ж�
		{
			++i;
			++j;
		}
		else                         // ָ��������¿�ʼƥ��
			j = next[j];             // j�˻غ��ʵ�λ�ã�iֵ����
	}
	if (j > T[0])
		return i - T[0];
	else
		return 0;
}
