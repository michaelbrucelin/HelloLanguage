public class StringLength {
    public static void main(String[] args) {
        String str1 = "Hello World, 你好，世界。";
        System.out.println("'" + str1 + "'`s length:\t" + str1.length());
        System.out.println("'" + str1 + "'`s CodePoint count:\t" + str1.codePointCount(0, str1.length()));
        System.out.println("'" + str1 + "'`s Char count:\t" + str1.toCharArray().length);
        System.out.println("");

        String str2 = "Ħĕŀŀō Ŵŏŕļđ, 你好，世界。";
        System.out.println("'" + str2 + "'`s length:\t" + str2.length());
        System.out.println("'" + str2 + "'`s CodePoint count:\t" + str2.codePointCount(0, str2.length()));
        System.out.println("'" + str2 + "'`s Char count:\t" + str2.toCharArray().length);
        System.out.println("");

        String str3 = "\uDBFF\uDFFCsurpi\u0301se!\uDBFF\uDFFD";
        System.out.println("'" + str3 + "'`s length:\t" + str3.length());
        System.out.println("'" + str3 + "'`s CodePoint count:\t" + str3.codePointCount(0, str3.length()));
        System.out.println("'" + str3 + "'`s Char count:\t" + str3.toCharArray().length);
    }
}

/**
 * 'Hello World, 你好，世界。'`s length: 19
 * 'Hello World, 你好，世界。'`s CodePoint count: 19
 * 'Hello World, 你好，世界。'`s Char count: 19
 * 
 * 'Ħĕŀŀō Ŵŏŕļđ, 你好，世界。'`s length: 19
 * 'Ħĕŀŀō Ŵŏŕļđ, 你好，世界。'`s CodePoint count: 19
 * 'Ħĕŀŀō Ŵŏŕļđ, 你好，世界。'`s Char count: 19
 * 
 * '􏿼surpíse!􏿽'`s length: 13
 * '􏿼surpíse!􏿽'`s CodePoint count: 11
 * '􏿼surpíse!􏿽'`s Char count: 13
 */