#### ����һ�����㹱��ֵ

**����**������ǧ��Ҫ��`countUniqueChars`��������󵼣�Ϊ���Ż�����������˺þòŷ��ֲ���Ҫʵ�����������  
**˼·**����Ҫ�����Ӵ���Ψһ�ַ������ǿ��Լ���ÿ���ַ��Ĺ���ֵ��Ȼ����Ӽ��ɡ�  
Ϊ�˼���ĳ���ַ��Ĺ���ֵ��������Ҫ�ҵ�����ǰ��ͬһ���ַ���λ��`lastIndex`�ͺ�һ����ͬ�ַ���λ��`nextIndex`��Ȼ���������`lastIndex + 1`��`nextIndex - 1`����Ӵ��Ĺ���ֵ��Ȼ�����Ǳ��������ַ��������������ַ��Ĺ���ֵ�ۼӼ��ɡ�  
![](./assets/img/Solution0828_4.png)  
����ֻ��26����д��ĸ��Ϊ�˷��㣺  
������һ������`lastIndexMap`���ǰһ����ͬ�ַ���λ�ã���һ������`curIndexMap`��ŵ�ǰ�ַ���λ�ã��ҵ�`next`�ַ������`cur`�ַ��Ĺ���ֵ��  
**��������**

```Java
public int uniqueLetterString(String s) {
    // �洢last�ַ�ǰһ���ַ�����λ��
    int[] lastIndexMap = new int[26];
    // �洢cur�ַ���ǰ����λ��
    int[] curIndexMap = new int[26];
    Arrays.fill(lastIndexMap, -1);
    Arrays.fill(curIndexMap, -1);
    char[] chars = s.toCharArray();
    int ans = 0;
    for (int i = 0; i < chars.length; i++) {
        // next�ַ�
        int index = chars[i] - 'A';
        // cur�ַ�����������-1������cur�ַ��Ĺ���ֵ
        if (curIndexMap[index] > -1) {
            ans += (i - curIndexMap[index]) * (curIndexMap[index] - lastIndexMap[index]);
        }
        // �������cur��last
        lastIndexMap[index] = curIndexMap[index];
        curIndexMap[index] = i;
    }
    // �������next�ַ��Ĺ���ֵ�����һ��λ�þ���s.length()
    for (int i = 0; i < 26; i++) {
        if (curIndexMap[i] > -1) {
            ans += (curIndexMap[i] - lastIndexMap[i]) * (s.length() - curIndexMap[i]);
        }
    }
    return ans;
}
```
