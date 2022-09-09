```C++
class Solution {
public:
   int maxSumDivThree(vector<int>& A) {
        vector<int> dp = {0, INT_MIN, INT_MIN};
        for (int a : A) {
            vector<int> dp2 = {0, 0, 0};
            for (int i = 0; i < 3; ++i)
                dp2[(i + a) % 3] = max(dp[(i + a) % 3], dp[i] + a);
            dp = dp2;
        }
        return dp[0];
    }
};
```
