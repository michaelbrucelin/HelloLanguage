class Printf2 {
    public static native String sprint(String format, double x);

    static {
        System.loadLibrary("Printf2");
    }
}
