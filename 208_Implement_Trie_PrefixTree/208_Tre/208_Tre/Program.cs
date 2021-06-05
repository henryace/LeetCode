using System;
using System.Collections.Generic;

namespace _208_Tre
{
    class Program
    {

        public class Trie
        {
            public Node root;
            /** Initialize your data structure here. */
            public Trie()
            {
                root = new Node();
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                Node indexPointer = root;
                foreach(char c in word)
                {
                    if (!indexPointer.children.ContainsKey((c))){
                        indexPointer.children[(c)] = new Node();
                    }
                    indexPointer = indexPointer.children[(c)];

                }
                indexPointer.is_word = true;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                Node indexPointer = root;
                foreach (char c in word)
                {
                    if (!indexPointer.children.ContainsKey((c)))
                    {
                        return false;
                    }
                    indexPointer = indexPointer.children[(c)];

                }
                return indexPointer.is_word;

            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                Node indexPointer = root;
                foreach (char c in prefix)
                {
                    if (!indexPointer.children.ContainsKey((c)))
                    {
                        return false;
                    }
                    indexPointer = indexPointer.children[(c)];

                }
                return true;
            }
        }

        public class Node
        {
            public bool is_word;
            public Dictionary<char, Node> children;

            public Node() => (is_word, children) = (false, new Dictionary<char, Node>());
            //public Node()
            //{
            //    is_word = false;
            //    children = new Dictionary<char, Node>();

            //}
        }





        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            var result = trie.Search("applezz");   // return True
            Console.WriteLine(result);
            trie.Search("app");     // return False
            trie.StartsWith("app"); // return True
            trie.Insert("app");
            trie.Search("app");     // return True

        }
    }
}
