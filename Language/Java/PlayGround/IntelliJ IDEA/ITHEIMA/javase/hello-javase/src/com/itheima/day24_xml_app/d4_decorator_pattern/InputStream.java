package com.itheima.day24_xml_app.d4_decorator_pattern;

/**
   共同父类
 */
public abstract class InputStream {
    public abstract int read();
    public abstract int read(byte[] buffer);
}
