class Trie {
public:
    /** Initialize your data structure here. */
    Trie():root(new Node()) { }
    
    /** Inserts a word into the trie. */
    void insert(string word) {
        Node * p = root.get();
        for(char c:word){
            if( !p->children[c-'a'])
                p->children[c-'a'] = new Node();
            p = p->children[c-'a'];
        }
        p->is_word = true;
    }
    
    /** Returns if the word is in the trie. */
    bool search(string word) {
        Node * p = root.get();
        for(char c:word){
            if( !p->children[c-'a'])
                return false;
            p = p->children[c-'a'];
        }
        return p && p-> is_word;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    bool startsWith(string prefix) {
        Node * p = root.get();
        for(char c:prefix){
            if( !p->children[c-'a'])
                return false;
            p = p->children[c-'a'];
        }
        return p != nullptr;
    }
private:

    
    struct Node{
        bool is_word; vector<Node*> children;
        
        Node(): is_word(false), children(26, nullptr){};
        ~Node(){
            for(Node* _children : children)
                if (_children) delete _children;
        }
    };
    
    std:: unique_ptr<Node> root;
};

/**
 * Your Trie object will be instantiated and called as such:
 * Trie* obj = new Trie();
 * obj->insert(word);
 * bool param_2 = obj->search(word);
 * bool param_3 = obj->startsWith(prefix);
 */