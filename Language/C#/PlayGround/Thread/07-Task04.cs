
/*
这里演示Task.WaitAny()、Task.WaitAll()、TaskFactory.ContinueWhenAny()、TaskFactory.ContinueWhenAll()四个方法，这四个方法之间由于线程的不可预测性，没有先后顺序，但是只要灵活应用，基本上能解决绝大多数多线程业务场景；
示例4、一个稍微复杂的示例，可以保证Task.WaitAny/All一定在TaskFactory.ContinueWhenAny/All后面执行
这样多执行几次，可以看到Task.WaitAny/All与TaskFactory.ContinueWhenAny/All，谁先谁后完全没有规律
*/