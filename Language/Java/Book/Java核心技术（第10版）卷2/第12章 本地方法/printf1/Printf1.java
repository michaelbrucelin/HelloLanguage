class Printf1 {
    public static native int print(int width, int precision, double x);

    static {
        System.loadLibrary("Printf1");
    }
}
