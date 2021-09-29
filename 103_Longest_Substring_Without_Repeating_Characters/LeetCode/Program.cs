using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        // wrong thought....
        static int  LengthOfLongestSubstring(string s)
        {

            var helperSet = new HashSet<char>();

            StringBuilder candidate = new StringBuilder();
            StringBuilder final = new StringBuilder();

            // first character
            final.Append(s[0]);

            if (s.Length == 1)
                return 1;

            foreach (char _s in s)
            {
                if (!helperSet.Contains(_s)){
                    candidate.Append(_s);


                }
                else
                {

                    if (candidate.ToString().Length > final.ToString().Length)
                    {
                        final = candidate;
                    }


                    candidate = new StringBuilder();
                    candidate.Append(_s);
                }

                helperSet.Add(_s);

            }



            return final.ToString().Length;

        }

        static int LengthOfLongestSubstringHuaHua(string s)
        {

            // https://tinyurl.com/35y46xuj

            if (s.Length == 1)
                return 1;

            var helperDic = new Dictionary<char, int>();


            int maxLength = 0;

            int left = 0;
            int right ;

            Console.WriteLine("s[right]" + "\t" + "right" + "\t" + "left" + "\t" + "m" + "\t" + "string");


            for (int i = 0; i < s.Length; i++)
            {
                right = i;
                if (helperDic.ContainsKey(s[i]))
                {
                    // 避免跳到上一個 aabaab!bb
                    // ex: 
                    left =
                    Math.Max(helperDic[s[i]] + 1, left);
                    //right = i;

                }


                String substring = s.Substring(left, right - left + 1);
                ////Console.WriteLine(s[i].ToString() + " " + helperDic[s[i]].ToString());

                //////Console.WriteLine(substring + " " + s.ToString() + " " + left.ToString() +" "+ right.ToString());
                //Console.WriteLine(s[i] + "\t" + right.ToString() + "\t" + left.ToString() + "\t" + substring + "\t" + s.ToString());


                var lines = helperDic.Select(kvp => $"{kvp.Key}:{kvp.Value}");
                var helperDicString = string.Join(string.Empty, lines);

                Console.WriteLine(s[i] + "\t\t" + right.ToString() + "\t" + left.ToString() + "\t" + helperDicString + "\t" + substring);


                maxLength = Math.Max(maxLength, right - left + 1);

                helperDic[s[i]] = i;

            }



            return maxLength;

        }

        // it works ! ....
        static int LengthOfLongestSubstringLeetCode(string s)
        {
            if (s == null || s == String.Empty)
                return 0;

            HashSet<char> set = new HashSet<char>();
            int currentMax = 0,
                left = 0,
                right = 0;

            while (right < s.Length)
            {
                if (!set.Contains(s[right]))
                {

                    set.Add(s[right]);
                    currentMax = Math.Max(currentMax, right - left + 1);
                    right += 1;

                }
                else
                {
                    set.Remove(s[left]);
                    left += 1;
                }



            }


            return currentMax;
        }

        static void Main(string[] args)
        {


            //Console.WriteLine(LengthOfLongestSubstringHuaHua(" "));
            Console.WriteLine(LengthOfLongestSubstringHuaHua("abcabcbb") + "\n");
            Console.WriteLine(LengthOfLongestSubstringHuaHua("aabaab!bb") + "\n");
            Console.WriteLine(LengthOfLongestSubstringHuaHua("bbbbbb") + "\n");
            Console.WriteLine(LengthOfLongestSubstringHuaHua("uqinntq"));


        }
    }



}
