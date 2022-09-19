using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class SlidingWindow
    {
        /// <summary>
        /// 获取不重复字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            // 哈希表记录字符出现的位置
            Dictionary<char, int> map = new();
            // 左指针
            int left = 0;
            // 记录最大长度
            int max = 0;
            // for循环指针充当右指针
            for (int right = 0; right < s.Length; right++)
            {
                // 当前字符
                char cur = s[right];
                // 如果遇到重复字符,左指针直接移动到该字符的下一位
                // 注意因为map中存储的值一直存在,所以要确保左指针不会回退
                if (map.ContainsKey(cur))
                {
                    left = Math.Max(map.GetValueOrDefault(cur) + 1, left);
                }
                // 更新最大长度值
                max = Math.Max(max, right - left + 1);
                // 更新哈希表中映射的下标(遇到重复值后更新成新的位置)
                map.Add(cur, right);
            }
            return max;
        }

        /// <summary>
        /// 输入: S = "ADOBECODEBANC", T = "ABC"
        /// ADOBEC
        /// DOBECODEBA
        /// OBECODEBA
        /// BECODEBA
        /// ECODEBA
        /// CODEBA
        /// ODEBANC
        /// DEBANC
        /// EBANC
        /// BANC
        /// 输出: "BANC"
        /// "efghiabcdjsfslskdjdhdhdhddhdhdaeffghicgbbklmn", "efghif"
        /// efghiabcdjsf
        /// fghiabcdjsfae
        /// ghiabcdjsfaef
        /// hiabcdjsfaefg
        /// iabcdjsfaefgh
        /// abcdjsfaefghi
        /// bcdjsfaefghi
        /// cdjsfaefghi
        /// djsfaefghi
        /// jsfaefghi
        /// sfaefghi
        /// faefghi
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string SS(string s, string t)
        {
            Dictionary<char, int> map = new();
            //map的value值代表t中某个字符出现的次数
            for (var i = 0; i < t.Length; i++)
            {
                var c = t[i];
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map[c] = 1;
                }
            }

            var left = 0;
            var right = 0;
            var count = t.Length;
            var max = int.MaxValue;
            var res = s;

            while (right < s.Length)
            {
                var c = s[right];
                //遍历s的字符，每次遇到目标字符时，map的value-1，count-1
                if (map.ContainsKey(c))
                {
                    if (map[c] > 0)
                    {
                        count--;
                    }
                    map[c]--;
                }
                right++;

                //当完成count==0，标识已经满足找到了目前字符
                while (count == 0)
                {
                    //如果满足right - left < max，说明遇到了历史以来最小字符，但并不是最小字符
                    var sss = s.Substring(left, right - left);
                    Console.WriteLine(sss);
                    if (right - left < max)
                    {
                        max = right - left; 
                        res = s.Substring(left, right - left);
                      //  Console.WriteLine(res);
                    }
                    //找到目标字符后，并不满足，因此向左前进，假如遇到目标字符，则map的value+1，count+1
                    //我的理解是留下坑位，然后right继续前进，知道找到填坑的时候，即count==0
                    //这一步也进行最优化，当没有遇到目标字符时，left会不断递增，也就是最小字符可以继续缩减
                    var d = s[left];
                    if (map.ContainsKey(d))
                    {
                        map[d]++;
                        if (map[d] > 0)
                        {
                            count++;
                        }
                    }
                    left++;
                }
            }
            return max == int.MaxValue ? "" : res;
        }
    }
}
