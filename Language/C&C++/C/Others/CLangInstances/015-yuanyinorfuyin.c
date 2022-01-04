#include <stdio.h>

/*
判断输入的字母是元音，还是辅音。
英语有26个字母，元音只包括 a、e、i、o、u 这五个字母，其余的都为辅音。y是半元音、半辅音字母，但在英语中都把他当作辅音。
*/

int main()
{
    char c;
    int isLowercaseVowel, isUppercaseVowel;

    printf("输入一个字母: ");
    scanf("%c", &c);

    // 小写字母元音
    isLowercaseVowel = (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');

    // 大写字母元音
    isUppercaseVowel = (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U');

    // if 语句判断
    if (isLowercaseVowel || isUppercaseVowel)
        printf("%c  是元音", c);
    else
        printf("%c 是辅音", c);
    return 0;
}