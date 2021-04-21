(module
    ;; 从 JavaScript 命名空间导入
    (import  "console"  "log" (func  $log (param  i32  i32))) ;; 导入 log 函数
    (import  "js"  "mem" (memory  1)) ;; 导入 1 页 内存（64kb）
   
    ;; 我们的模块的数据段
    (data (i32.const 0) "Hello World from WebAssembly!")
   
    ;; 函数声明：导出 helloWorld()，无参数
    (func (export  "helloWorld")
        i32.const 0  ;; 传递偏移 0 到 log
        i32.const 29  ;; 传递长度 29 到 log（示例文本的字符串长度）
        call  $log
        )
)