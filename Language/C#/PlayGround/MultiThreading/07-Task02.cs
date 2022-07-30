
/*
这里演示Task.WaitAny()、Task.WaitAll()、TaskFactory.ContinueWhenAny()、TaskFactory.ContinueWhenAll()四个方法，这四个方法之间由于线程的不可预测性，没有先后顺序，但是只要灵活应用，基本上能解决绝大多数多线程业务场景；
示例2、示例1虽然等待了多线程完成，但是卡界面了，这里展示一种既可以等待多线程完成，又不卡界面的方式；这里只是展示个小技巧，实战中不要线程套线程
*/