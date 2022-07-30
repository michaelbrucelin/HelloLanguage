
/*
这里演示Task.WaitAny()、Task.WaitAll()、TaskFactory.ContinueWhenAny()、TaskFactory.ContinueWhenAll()四个方法，这四个方法之间由于线程的不可预测性，没有先后顺序，但是只要灵活应用，基本上能解决绝大多数多线程业务场景；
示例3、这个是示例1卡界面问题的正确解决方式，示例2只是一个小聪明，不可取
*/