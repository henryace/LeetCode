using System;
using System.Collections.Generic;

namespace _208_Tre
{
    class Program
    {

        public class Trie
        {
            public Node root { get; set; }
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
                    if (!indexPointer.children.ContainsKey((c).ToString())){
                        indexPointer.children[(c).ToString()] = new Node();
                    }
                    indexPointer = indexPointer.children[(c).ToString()];

                }
                indexPointer.is_word = true;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                Node indexPointer = root;
                foreach (char c in word)
                {
                    if (!indexPointer.children.ContainsKey((c).ToString()))
                    {
                        return false;
                    }
                    indexPointer = indexPointer.children[(c).ToString()];

                }
                return indexPointer.is_word;

            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                Node indexPointer = root;
                foreach (char c in prefix)
                {
                    if (!indexPointer.children.ContainsKey((c).ToString()))
                    {
                        return false;
                    }
                    indexPointer = indexPointer.children[(c).ToString()];

                }
                return true;
            }
        }

        public class Node
        {
            public bool is_word { get; set; }               
            public Dictionary<string, Node> children { get; set; }
            public Node()
            {
                is_word = false;
                children = new Dictionary<string, Node>();

            }
        }





        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            trie.Search("apple");   // return True
            trie.Search("app");     // return False
            trie.StartsWith("app"); // return True
            trie.Insert("app");
            trie.Search("app");     // return True

        }
    }
}
