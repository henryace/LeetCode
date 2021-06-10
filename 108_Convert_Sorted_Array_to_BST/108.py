# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:       
    def sortedArrayToBST(self, nums: List[int]) -> TreeNode:
        def buildBST(l:int,r:int) -> TreeNode:
            if l > r : return None
            m = l + (r-l) // 2
            node = TreeNode(nums[m] )
            node.left = buildBST(l, m-1)
            node.right = buildBST( m+1,r)
            return node
        # if len(nums) == 0: return None
        return buildBST(0, len(nums)-1) if len(nums) > 0 else None