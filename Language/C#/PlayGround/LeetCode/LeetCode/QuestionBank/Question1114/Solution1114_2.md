#### ��������

> ������������[��������](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E5%B9%B6%E5%8F%91%E8%AE%A1%E7%AE%97%2F9939802%3Ffr%3Daladdin)�ĳ������ó����£������ڶ��̣߳������̣��� _ͬʱ_ ִ�С�

ͬʱ���в�������ȫָ���̻��߳��ڲ�ͬ������ CPU �϶������У���������£�����һ������ CPU �Ͻ���ִ�ж���̻߳���̡�_�����ȿ����߳��У�Ҳ���ڽ����С�_

������ҪΪ�����������ơ������Ӧ�ò��������ܻ�����һЩ©�������������ͬ�����Է�Ϊ���֣�

-   **��̬����**�����ڶ����֮��ľ���ִ�У����³���δ����������˳�������
    
-   **����**����������ȴ�һЩ��Ҫ��Դ������û�г������ִ�С�
    
-   **��Դ����**�����̱����ð����������������Դ��
    

�����д��ھ�̬����������չʾһ����̬���������ӡ�

������һ������ `withdraw(amount)`�����������С�ڵ�ǰ����ӵ�ǰ����м�ȥ��������Ȼ�󷵻��������������£�

```
balance = 500
def withdraw(amount):
    if (amount < balance):
        balance -= amount
    return balance

```

```
int balance = 500;
int withdraw(int amount) {
  if (amount < balance) {
    balance -= amount;
  }
  return balance;
}

```

���� _����_ �÷���ִ�к������Զ����Ϊ����

�����п��ܳ��־�̬������ʹ������Ϊ���������������߳�ͬʱʹ�ò�ͬ�Ĳ���ִ�и÷��������磺�߳� 1 ִ�� `withdraw(amount=400)`���߳� 2 ִ�� `withdraw(amount=200)`���������̵߳�ִ��˳������ͼ��ʾ����ÿ��ʱ��ִֻ��һ����䡣

![](./Solution1114_2.png)

��������ִ�н���������ɸ������Ⲣ���������������

#### [](https://leetcode.cn/problems/print-in-order/solution/an-xu-da-yin-by-leetcode//#�޾�������)�޾�������

����������һ����ͬ����������߳�/����֮�乲��һЩ��Դ�����磺���������޷�������Դ�����Լ������ֹ��������ͱ���� _��Դ�����Э��_ ���⡣

�������˼·���������ȷ�������� **�ؼ����ִ���Ķ�ռ��**�����磺���ͼ��������Ϳ��Է�ֹ������벻һ�µ�״̬��

> ���������Ľ������Ϊ����ҪĳЩ�ؼ����ִ�����������ԣ����ڸ�����ʱ���ڣ�ֻ��һ���߳̿��Խ���ؼ����ִ��롣

���Խ����ֻ��ƿ������ƹؼ����ִ�����ʵ�������ǰ��ʾ���Ĺؼ����ִ����������������ͼ���������䡣Ȼ���������������̣߳�������ͼ��ִ��˳��

![](./Solution1114_2_2.png)

�ڸû����£�һ��һ���߳̽���ؼ����֣����Ϳ�����ֹ�����߳̽���ùؼ����֡����磬��ʱ��� 3��`�߳� 2` ����ؼ����֣���ô��ʱ��� 4�����û����������`�߳� 1` �Ϳ��ܽ���ؼ����֡���������߳�ͬʱ���У���֤ϵͳ��һ���ԣ���ȷ�������ȷ��

������߳�δ����Ȩ����ؼ����룬������Ϊ���̱߳����������˯��״̬�����磬`�߳� 1` ��ʱ��� 4 ��������֮��ؼ����ֱ��ͷţ�����֪ͨ�����ȴ��̡߳�`�߳� 2` ��ʱ��� 5 �ͷ��˹ؼ����֣��Ϳ���֪ͨ `�߳� 1` ���롣

> ���ֻ��ƻ����л��������ȴ��̵߳Ĺ��ܡ�

��֮��Ϊ�˷�ֹ���ֲ�������״̬����Ҫһ�־������ֹ��ܵĻ��ƣ�1���ؼ����ֵķ��ʿ��ƣ�2��֪ͨ�����̡߳�

#### [](https://leetcode.cn/problems/print-in-order/solution/an-xu-da-yin-by-leetcode//#����һ��ʹ��-synchronization)����һ��ʹ�� synchronization

**˼·**

��ĿҪ��˳������ִ��������������ÿ���������ڵ������߳������С�Ϊ�˱�֤�̵߳�ִ��˳�򣬿����ڷ���֮�䴴��һЩ������ϵ�����ڶ������������ڵ�һ������֮��ִ�У����������������ڵڶ�������֮��ִ�С�

> ������֮���������ϵ�γ������з������ض���ִ��˳������ `A < B`, `B < C`�������з�����ִ��˳��Ϊ `A < B < C`��

![](Solution1114_2_3.png)

������ϵ����ͨ����������ʵ�֡�ʹ��һ��������� `firstJobDone` Э����һ��������ڶ���������ִ��˳��ʹ����һ��������� `secondJobDone` Э���ڶ��������������������ִ��˳��

**�㷨**

-   ���ȳ�ʼ��������� `firstJobDone` �� `secondJobDone`����ʼֵ��ʾ���з���δִ�С�
    
-   ���� `first()` û��������ϵ������ֱ��ִ�С��ڷ��������±��� `firstJobDone` ��ʾ�÷���ִ����ɡ�
    
-   ���� `second()` �У���� `firstJobDone` ��״̬�����δ���������ȴ�״̬������ִ�з��� `second()`���ڷ���ĩβ�����±��� `secondJobDone` ��ʾ���� `second()` ִ����ɡ�
    
-   ���� `third()` �У���� `secondJobDone` ��״̬���뷽�� `second()` ���ƣ�ִ�� `third()` ֮ǰ����Ҫ�ȵȴ� `secondJobDone` ��״̬��

![](./Solution1114_2_4.png)

**ʵ��**

�����㷨��ʵ���ںܴ�̶���ȡ����ѡ��ı�����ԡ������� Java��C++ �� Python �ж�����[����](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E4%BA%92%E6%96%A5%E4%BA%8B%E4%BB%B6%2F9980508%3Ffr%3Daladdin)��[�ź���](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E4%BF%A1%E5%8F%B7%E9%87%8F%2F9807501%3Ffr%3Daladdin)������ͬ���ԶԲ��������в�ͬʵ�֡�

```Python
from threading import Lock

class Foo:
    def __init__(self):
        self.firstJobDone = Lock()
        self.secondJobDone = Lock()
        self.firstJobDone.acquire()
        self.secondJobDone.acquire()

    def first(self, printFirst: 'Callable[[], None]') -> None:
        # printFirst() outputs "first".
        printFirst()
        # Notify the thread that is waiting for the first job to be done.
        self.firstJobDone.release()

    def second(self, printSecond: 'Callable[[], None]') -> None:
        # Wait for the first job to be done
        with self.firstJobDone:
            # printSecond() outputs "second".
            printSecond()
            # Notify the thread that is waiting for the second job to be done.
            self.secondJobDone.release()

    def third(self, printThird: 'Callable[[], None]') -> None:

        # Wait for the second job to be done.
        with self.secondJobDone:
            # printThird() outputs "third".
            printThird()

```

```Cpp
#include <semaphore.h>

class Foo {

protected:
    sem_t firstJobDone;
    sem_t secondJobDone;

public:

    Foo() {
        sem_init(&firstJobDone, 0, 0);
        sem_init(&secondJobDone, 0, 0);
    }

    void first(function<void()> printFirst) {
        // printFirst() outputs "first".
        printFirst();
        sem_post(&firstJobDone);
    }

    void second(function<void()> printSecond) {
        sem_wait(&firstJobDone);
        // printSecond() outputs "second".
        printSecond();
        sem_post(&secondJobDone);
        
    }

    void third(function<void()> printThird) {
        sem_wait(&secondJobDone);
        // printThird() outputs "third".
        printThird();
    }
};

```

```Java
class Foo {

  private AtomicInteger firstJobDone = new AtomicInteger(0);
  private AtomicInteger secondJobDone = new AtomicInteger(0);

  public Foo() {}

  public void first(Runnable printFirst) throws InterruptedException {
    // printFirst.run() outputs "first".
    printFirst.run();
    // mark the first job as done, by increasing its count.
    firstJobDone.incrementAndGet();
  }

  public void second(Runnable printSecond) throws InterruptedException {
    while (firstJobDone.get() != 1) {
      // waiting for the first job to be done.
    }
    // printSecond.run() outputs "second".
    printSecond.run();
    // mark the second as done, by increasing its count.
    secondJobDone.incrementAndGet();
  }

  public void third(Runnable printThird) throws InterruptedException {
    while (secondJobDone.get() != 1) {
      // waiting for the second job to be done.
    }
    // printThird.run() outputs "third".
    printThird.run();
  }
}


```
