using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer_II.剑指_Offer_II_0031
{
    public class Test0031
    {
        public void Test()
        {
            // Test01();
            Test02();
        }

        /// <summary>
        /// ["LRUCache","put","put","get","put","get","put","get","get","get"]
        /// [[2],[1,1],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]
        /// </summary>
        private void Test01()
        {
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(1, 1);  // 缓存是 {1=1}
            lRUCache.Put(2, 2);  // 缓存是 {1=1, 2=2}
            lRUCache.Get(1);     // 返回 1
            lRUCache.Put(3, 3);  // 该操作会使得关键字 2 作废，缓存是 {1=1, 3=3}
            lRUCache.Get(2);     // 返回 -1 (未找到)
            lRUCache.Put(4, 4);  // 该操作会使得关键字 1 作废，缓存是 {4=4, 3=3}
            lRUCache.Get(1);     // 返回 -1 (未找到)
            lRUCache.Get(3);     // 返回 3
            lRUCache.Get(4);     // 返回 4
        }

        /// <summary>
        /// ["LRUCache","put","get","put","get","get"]
        /// [[1],[2,1],[2],[3,2],[2],[3]]
        /// </summary>
        private void Test02()
        {
            LRUCache lRUCache = new LRUCache(1);
            lRUCache.Put(2, 1);
            lRUCache.Get(2);
            lRUCache.Put(3, 2);
            lRUCache.Get(2);
            lRUCache.Get(3);
        }
    }
}
