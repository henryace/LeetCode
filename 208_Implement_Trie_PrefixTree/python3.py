class TrieNode(object):
    def __init__(self):
        self.is_word = False
        self.Children = [None]*26

class Trie:

    def __init__(self):
        """
        Initialize your data structure here.
        """
        self.root = TrieNode()
        

    def insert(self, word: str) -> None:
        """
        Inserts a word into the trie.
        """
        Node = self.root
        for c in word:
            charIndex = ord(c) - ord('a')
            if not Node.Children[charIndex] :
                Node.Children[charIndex] = TrieNode()
            Node = Node.Children[charIndex]
        Node.is_word= True
        

    def search(self, word: str) -> bool:
        """
        Returns if the word is in the trie.
        """
        Node = self.root
        for c in word:
            charIndex = ord(c) - ord('a')
            if not Node.Children[charIndex] :
                return False
            Node = Node.Children[charIndex]
        return Node.is_word
      #  retunr True and Node.is_word        
        
                

    def startsWith(self, prefix: str) -> bool:
        """
        Returns if there is any word in the trie that starts with the given prefix.
        """
        Node = self.root
        for c in prefix:
            charIndex = ord(c) - ord('a')
            if not Node.Children[charIndex] : return False
            Node = Node.Children[charIndex]
        return True
      #  retunr True and Node.is_word        
              


# Your Trie object will be instantiated and called as such:
# obj = Trie()
# obj.insert(word)
# param_2 = obj.search(word)
# param_3 = obj.startsWith(prefix)