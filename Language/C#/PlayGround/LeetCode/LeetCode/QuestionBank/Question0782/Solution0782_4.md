# 方法一：数学

**思路**  
根据题意，要想变为棋盘，我们首先要检查矩阵的合法性，即是否能变为棋盘，然后再计算变为棋盘移动的次数。

-   检查棋盘的合法性（由于移动行不会改变列，移动列不会改变行，因此我们只需要分别计算）
    -   要想变为棋盘，首先每行的`0`和`1`的数量要么相等（`010101`），要么差值为`1`（`01010或者10101`）
    -   假设第一行是`010101`，第二行必须为`101010`，第三行为`010101`，即第一行和第二行每个位置的数字相反，第三行和第一行相同，以此类推，第`i`行要么和第一行相同，要么和第一行相反。我们记录相同的行数数量为`sameCnt`，相反为`oppositeCnt`，则`sameCnt == oppositeCnt`或者`Math.abs(sameCnt - oppositeCnt) == 1`
    -   相同的我们计算列的合法性
-   计算移动的次数（通过合法性校验我们计算移动的次数）
    -   首先，我们统计错位的个数，每次移动是交换两个错位元素，因此错位的个数一定是偶数个，我们只需要计算第一行和第一列的移动次数即可
    -   我们假设第一行是`10101010.....`,然后计算错位的元素，设错位元素为`errorCnt`，行元素长度为`n`
        -   若`n`是偶数，则我们返回变为`010101...`和`101010...`的最小交换次数，
            -   `101010...`这种的交换次数为`errorCnt / 2`
            -   `010101...`这种的交换次数为`(n - errorCnt) / 2`
        -   若`n`是奇数，则根据`0`和`1`的数量大小，只有一种选择，由于错位数量必须为偶数，所以变换为`010101...`和`101010...`的错位数量一定是一奇一偶
            -   若`errorCnt`为奇数，返回`(n - errorCnt) / 2`
            -   若`errorCnt`为偶数，返回`errorCnt / 2`
    -   相同的我们计算移动列的次数

**代码如下**

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
 * 检查合法性 分别检查行和列
 *
 * @param board 数组
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
    //第一行当做哨兵 其他的行要么和第一行相等 要么和第一行相反
    //如：第一行0110 后续的行只能是 0110、1001
    int[] sentinel = board[0];
    int sameCnt = 0, oppositeCnt = 0;
    for (int[] cur : board) {
        //相同
        if (sentinel[0] == cur[0]) {
            for (int i = 0; i < sentinel.length; i++) {
                if (sentinel[i] != cur[i]) {
                    return false;
                }
            }
            sameCnt++;
        } else {
            //相反
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
    //第一列当做哨兵 其他的列要么和第一列相等 要么和第一列相反
    //如：第一列0110 后续的列只能是 0110、1001
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
    //假设都是10101010...
    int preNum = 1;
    int errorCnt = 0;
    for (int i : sentinel) {
        //统计有多少错位
        if (i != preNum) {
            errorCnt++;
        }
        preNum = preNum == 1 ? 0 : 1;
    }
    //数组是偶数个还是奇数个
    if (sentinel.length % 2 == 0) {
        //偶数个 可以是01010101 或者 10101010
        return Math.min(sentinel.length - errorCnt, errorCnt) / 2;
    } else {
        //奇数个 取决于1多还是0多 1多则是1 0 1 0 1 0 1 0 1 、0多则是0 1 0 1 0 1 0 1 0
        //并且错误的个数一定是偶数个
        if (errorCnt % 2 == 0) {
            return errorCnt / 2;
        } else {
            return (sentinel.length - errorCnt) >> 1;
        }
    }
}
```
