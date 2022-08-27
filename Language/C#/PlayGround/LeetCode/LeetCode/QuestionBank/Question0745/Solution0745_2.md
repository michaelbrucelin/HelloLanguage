#### 方法一：计算每个单词的前缀后缀组合可能性

**思路**

预先计算出每个单词的前缀后缀组合可能性，用特殊符号连接，作为键，对应的最大下标作为值保存入哈希表。检索时，同样用特殊符号连接前后缀，在哈希表中进行搜索。

**代码**

```Python3
class WordFilter:

    def __init__(self, words: List[str]):
        self.d = {}
        for i, word in enumerate(words):
            m = len(word)
            for prefixLength in range(1, m + 1):
                for suffixLength in range(1, m + 1):
                    self.d[word[:prefixLength] + '#' + word[-suffixLength:]] = i


    def f(self, pref: str, suff: str) -> int:
        return self.d.get(pref + '#' + suff, -1)

```

```Java
class WordFilter {
    Map<String, Integer> dictionary;

    public WordFilter(String[] words) {
        dictionary = new HashMap<String, Integer>();
        for (int i = 0; i < words.length; i++) {
            String word = words[i];
            int m = word.length();
            for (int prefixLength = 1; prefixLength <= m; prefixLength++) {
                for (int suffixLength = 1; suffixLength <= m; suffixLength++) {
                    dictionary.put(word.substring(0, prefixLength) + "#" + word.substring(m - suffixLength), i);
                }
            }
        }
    }

    public int f(String pref, String suff) {
        return dictionary.getOrDefault(pref + "#" + suff, -1);
    }
}

```

```C#
public class WordFilter {
    Dictionary<string, int> dictionary;

    public WordFilter(string[] words) {
        dictionary = new Dictionary<string, int>();
        for (int i = words.Length - 1; i >= 0; i--) {
            string word = words[i];
            int m = word.Length;
            for (int prefixLength = 1; prefixLength <= m; prefixLength++) {
                for (int suffixLength = 1; suffixLength <= m; suffixLength++) {
                    dictionary.TryAdd(word.Substring(0, prefixLength) + "#" + word.Substring(m - suffixLength), i);
                }
            }
        }
    }

    public int F(string pref, string suff) {
        if (dictionary.ContainsKey(pref + "#" + suff)) {
            return dictionary[pref + "#" + suff];
        }
        return -1;
    }
}

```

```C++
class WordFilter {
private:
    unordered_map<string, int> dict;
public:
    WordFilter(vector<string>& words) {
        for (int i = 0; i < words.size(); i++) {
            int m = words[i].size();
            string word = words[i];
            for (int prefixLength = 1; prefixLength <= m; prefixLength++) {
                for (int suffixLength = 1; suffixLength <= m; suffixLength++) {
                    string key = word.substr(0, prefixLength) + '#' + word.substr(m - suffixLength);
                    dict[key] = i;
                }
            }
        }
    }
    
    int f(string pref, string suff) {
        string target = pref + '#' + suff;
        return dict.count(target) ? dict[target] : -1;
    }
};

```

```C
#define MAX_STR_LEN 16

typedef struct {
    char key[MAX_STR_LEN];
    int val;
    UT_hash_handle hh;
} HashItem;

typedef struct {
    HashItem *dict;
} WordFilter;

WordFilter* wordFilterCreate(char ** words, int wordsSize) {
    WordFilter *obj = (WordFilter *)malloc(sizeof(WordFilter));
    obj->dict = NULL;
    for (int i = 0; i < wordsSize; i++) {
        int m = strlen(words[i]);
        for (int prefixLength = 1; prefixLength <= m; prefixLength++) {
            for (int suffixLength = 1; suffixLength <= m; suffixLength++) {
                char key[MAX_STR_LEN];
                strncpy(key, words[i], prefixLength);
                key[prefixLength] = '#';
                strcpy(key + prefixLength + 1, words[i] + m - suffixLength);
                key[prefixLength + 1 + suffixLength] = '\0';
                HashItem *pEntry = NULL;
                HASH_FIND_STR(obj->dict, key, pEntry);
                if (NULL == pEntry) {
                    pEntry = (HashItem *)malloc(sizeof(HashItem));
                    strcpy(pEntry->key, key);
                    HASH_ADD_STR(obj->dict, key, pEntry);
                }
                pEntry->val = i;
            }
        }
    }
    return obj;
}

int wordFilterF(WordFilter* obj, char * pref, char * suff) {
    char target[MAX_STR_LEN];
    sprintf(target, "%s#%s", pref, suff);
    HashItem *pEntry = NULL;
    HASH_FIND_STR(obj->dict, target, pEntry);
    if (NULL == pEntry) {
        return -1;
    }
    return pEntry->val;
}

void wordFilterFree(WordFilter* obj) {
    HashItem *curr, *tmp;
    HASH_ITER(hh, obj->dict, curr, tmp) {
        HASH_DEL(obj->dict, curr);  
        free(curr);          
    }
    free(obj);
}

```

```JavaScript
var WordFilter = function(words) {
    this.dictionary = new Map();
    for (let i = 0; i < words.length; i++) {
        const word = words[i];
        const m = word.length;
        for (let prefixLength = 1; prefixLength <= m; prefixLength++) {
            for (let suffixLength = 1; suffixLength <= m; suffixLength++) {
                this.dictionary.set(word.substring(0, prefixLength) + "#" + word.substring(m - suffixLength), i);
            }
        }
    }
};

WordFilter.prototype.f = function(pref, suff) {
    if (this.dictionary.has(pref + "#" + suff)) {
        return this.dictionary.get(pref + "#" + suff);
    }
    return -1;
};

```

```Golang
type WordFilter map[string]int

func Constructor(words []string) WordFilter {
    wf := WordFilter{}
    for i, word := range words {
        for j, n := 1, len(word); j <= n; j++ {
            for k := 0; k < n; k++ {
                wf[word[:j]+"#"+word[k:]] = i
            }
        }
    }
    return wf
}

func (wf WordFilter) F(pref, suff string) int {
    if i, ok := wf[pref+"#"+suff]; ok {
        return i
    }
    return -1
}

```

**复杂度分析**

-   时间复杂度：初始化消耗 O(∑i\=0n−1wi3) 时间，其中 wi 是每个单词的字符数。每次检索消耗 O(p+s)，其中 p 和 s 分别是输入的 pref 和 suff 的长度。

-   空间复杂度：初始化消耗 O(∑i\=0n−1wi3) 空间，每次检索消耗 O(p+s) 空间。
