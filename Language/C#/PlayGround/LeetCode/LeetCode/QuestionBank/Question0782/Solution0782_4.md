# ����һ����ѧ

**˼·**  
�������⣬Ҫ���Ϊ���̣���������Ҫ������ĺϷ��ԣ����Ƿ��ܱ�Ϊ���̣�Ȼ���ټ����Ϊ�����ƶ��Ĵ�����

-   ������̵ĺϷ��ԣ������ƶ��в���ı��У��ƶ��в���ı��У��������ֻ��Ҫ�ֱ���㣩
    -   Ҫ���Ϊ���̣�����ÿ�е�`0`��`1`������Ҫô��ȣ�`010101`����Ҫô��ֵΪ`1`��`01010����10101`��
    -   �����һ����`010101`���ڶ��б���Ϊ`101010`��������Ϊ`010101`������һ�к͵ڶ���ÿ��λ�õ������෴�������к͵�һ����ͬ���Դ����ƣ���`i`��Ҫô�͵�һ����ͬ��Ҫô�͵�һ���෴�����Ǽ�¼��ͬ����������Ϊ`sameCnt`���෴Ϊ`oppositeCnt`����`sameCnt == oppositeCnt`����`Math.abs(sameCnt - oppositeCnt) == 1`
    -   ��ͬ�����Ǽ����еĺϷ���
-   �����ƶ��Ĵ�����ͨ���Ϸ���У�����Ǽ����ƶ��Ĵ�����
    -   ���ȣ�����ͳ�ƴ�λ�ĸ�����ÿ���ƶ��ǽ���������λԪ�أ���˴�λ�ĸ���һ����ż����������ֻ��Ҫ�����һ�к͵�һ�е��ƶ���������
    -   ���Ǽ����һ����`10101010.....`,Ȼ������λ��Ԫ�أ����λԪ��Ϊ`errorCnt`����Ԫ�س���Ϊ`n`
        -   ��`n`��ż���������Ƿ��ر�Ϊ`010101...`��`101010...`����С����������
            -   `101010...`���ֵĽ�������Ϊ`errorCnt / 2`
            -   `010101...`���ֵĽ�������Ϊ`(n - errorCnt) / 2`
        -   ��`n`�������������`0`��`1`��������С��ֻ��һ��ѡ�����ڴ�λ��������Ϊż�������Ա任Ϊ`010101...`��`101010...`�Ĵ�λ����һ����һ��һż
            -   ��`errorCnt`Ϊ����������`(n - errorCnt) / 2`
            -   ��`errorCnt`Ϊż��������`errorCnt / 2`
    -   ��ͬ�����Ǽ����ƶ��еĴ���

**��������**

```Java
public int movesToChessboard(int[][] board) {
    if (!check(board)) {
        return -1;
    }
    int[] col = new int[board.length];
    for (int i = 0; i < board.length; i++) {
        col[i] = board[i][0];
    }
    return getSwapCount(board[0]) + getSwapCount(col);
}

/**
 * ���Ϸ��� �ֱ����к���
 *
 * @param board ����
 * @return
 */
public boolean check(int[][] board) {
    return checkFirstRow(board) &&
            checkFirstCol(board) &&
            checkRow(board) &&
            checkCol(board);
}

public boolean checkFirstRow(int[][] board) {
    int rowOneCnt = 0;
    int rowZeroCnt = 0;
    int[] first = board[0];
    for (int num : first) {
        if (num == 0) {
            rowZeroCnt++;
        } else {
            rowOneCnt++;
        }
    }
    return rowOneCnt == rowZeroCnt || Math.abs(rowOneCnt - rowZeroCnt) == 1;
}

public boolean checkFirstCol(int[][] board) {
    int oneCnt = 0, zeroCnt = 0;
    for (int i = 0; i < board.length; i++) {
        if (board[i][0] == 0) {
            zeroCnt++;
        } else {
            oneCnt++;
        }
    }
    return oneCnt == zeroCnt || Math.abs(oneCnt - zeroCnt) == 1;
}

public boolean checkRow(int[][] board) {
    //��һ�е����ڱ� ��������Ҫô�͵�һ����� Ҫô�͵�һ���෴
    //�磺��һ��0110 ��������ֻ���� 0110��1001
    int[] sentinel = board[0];
    int sameCnt = 0, oppositeCnt = 0;
    for (int[] cur : board) {
        //��ͬ
        if (sentinel[0] == cur[0]) {
            for (int i = 0; i < sentinel.length; i++) {
                if (sentinel[i] != cur[i]) {
                    return false;
                }
            }
            sameCnt++;
        } else {
            //�෴
            for (int i = 0; i < sentinel.length; i++) {
                if (sentinel[i] + cur[i] != 1) {
                    return false;
                }
            }
            oppositeCnt++;
        }
    }
    return sameCnt == oppositeCnt || Math.abs(sameCnt - oppositeCnt) == 1;
}

public boolean checkCol(int[][] board) {
    //��һ�е����ڱ� ��������Ҫô�͵�һ����� Ҫô�͵�һ���෴
    //�磺��һ��0110 ��������ֻ���� 0110��1001
    int sameCnt = 0, oppositeCnt = 0;
    int[] sentinel = new int[board.length];
    for (int j = 0; j < board.length; j++) {
        sentinel[j] = board[j][0];
    }
    for (int j = 0; j < board.length; j++) {
        if (board[0][j] == sentinel[0]) {
            for (int i = 0; i < sentinel.length; i++) {
                if (sentinel[i] != board[i][j]) {
                    return false;
                }
            }
            sameCnt++;
        } else {
            for (int i = 0; i < sentinel.length; i++) {
                if (sentinel[i] + board[i][j] != 1) {
                    return false;
                }
            }
            oppositeCnt++;
        }
    }
    return sameCnt == oppositeCnt || Math.abs(sameCnt - oppositeCnt) == 1;
}

private int getSwapCount(int[] sentinel) {
    //���趼��10101010...
    int preNum = 1;
    int errorCnt = 0;
    for (int i : sentinel) {
        //ͳ���ж��ٴ�λ
        if (i != preNum) {
            errorCnt++;
        }
        preNum = preNum == 1 ? 0 : 1;
    }
    //������ż��������������
    if (sentinel.length % 2 == 0) {
        //ż���� ������01010101 ���� 10101010
        return Math.min(sentinel.length - errorCnt, errorCnt) / 2;
    } else {
        //������ ȡ����1�໹��0�� 1������1 0 1 0 1 0 1 0 1 ��0������0 1 0 1 0 1 0 1 0
        //���Ҵ���ĸ���һ����ż����
        if (errorCnt % 2 == 0) {
            return errorCnt / 2;
        } else {
            return (sentinel.length - errorCnt) >> 1;
        }
    }
}
```
