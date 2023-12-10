'''
113. Path Sum II
Diff: Medium
Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values in the path equals targetSum. Each path should be returned as a list of the node values, not node references.

A root-to-leaf path is a path starting from the root and ending at any leaf node. A leaf is a node with no children.
Passes - Beats 69% of python users
'''


# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    rv = []
    def pathSum(self, root: Optional[TreeNode], targetSum: int) -> List[List[int]]:
        self.rv = []
        self.recurse(root, 0, targetSum, [])
        return self.rv
    
    def recurse(self, curN, curSum, targetSum, curList):
        # if we are at a null node backup
	if(curN == None):
            return

	# add the current val to the current sum and append to the current list
        curSum += curN.val
        curList.append(curN.val)

        # if we are at a leaf, check if the value is correct
        if(curN.left == None and curN.right == None):
            if(curSum == targetSum):
                # create a shallow copy to put in the return list
                self.rv.append(list(curList))
	    # pop whatever value we found off the current list so the next list is valid
            curList.pop()
        else:
	    # recurse left and right, then pop the current value
            self.recurse(curN.left, curSum, targetSum, curList)
            self.recurse(curN.right, curSum, targetSum, curList)
            curList.pop()


