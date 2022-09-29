# 单例方法

这里模拟实现了单例方法，即方法在同一时间，只能有一次执行，即不可以并发调用。

下面是不同代码的执行效果：

| 代码 | 效果 |
| -- | -- |
| <code>Test1("tag01");<br/>Test1("tag02");</code> | <pre>tag01 0<br/>tag02 0<br/>tag01 1<br/>tag02 1<br/>tag02 2<br/>tag01 2<br/>tag02 3<br/>tag01 3</pre> |
| <code>Test21("tag01");<br/>Test21("tag02");</code> | <pre>tag01 0<br/>tag01 1<br/>tag01 2<br/>tag01 3<br/>tag02 0<br/>tag02 1<br/>tag02 2<br/>tag02 3</pre> |
| <code>Test22("tag01");<br/>Test22("tag02");</code> | <pre>tag02 0<br/>tag01 0<br/>tag02 1<br/>tag01 1<br/>tag02 2<br/>tag01 2<br/>tag02 3<br/>tag01 3</pre> |
| <code>Test23("tag01");<br/>Test23("tag02");</code> | <pre>tag01 0<br/>tag01 1<br/>tag01 2<br/>tag01 3<br/>tag02 0<br/>tag02 1<br/>tag02 2<br/>tag02 3</pre> |
| <code>Test24("tag01");<br/>Test24("tag02");</code> | <pre>tag01 0<br/>tag01 1<br/>tag01 2<br/>tag01 3<br/>tag02 0<br/>tag02 1<br/>tag02 2<br/>tag02 3</pre> |
| <code>Test31("tag01");<br/>Test31("tag02");</code> | <pre>tag01 0<br/>tag01 1<br/>tag01 2<br/>tag01 3</pre> |
| <code>Test32("tag01");<br/>Test32("tag02");</code> | <pre>tag02 0<br/>tag01 0<br/>tag02 1<br/>tag01 1<br/>tag02 2<br/>tag01 2<br/>tag02 3<br/>tag01 3</pre> |
| <code>Test33("tag01");<br/>Test33("tag02");</code> | <pre>tag01 0<br/>tag01 1<br/>tag01 2<br/>tag01 3</pre> |
