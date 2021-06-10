/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
class Solution {
public:
    TreeNode* sortedArrayToBST(vector<int>& nums) {

        return nums.size() > 0 ? buildBST(nums, 0, nums.size()-1) : nullptr ;
    }
    
private:
            TreeNode* buildBST(vector<int>& auxNums, int l, int r){
                if (l > r) return nullptr;
                int m = l + (r-l)/2;
                TreeNode* node = new TreeNode(auxNums[m]);
                node->left = buildBST(auxNums, l , m-1);
                node->right = buildBST(auxNums, m +1 , r);              
            return node;
        }
};
