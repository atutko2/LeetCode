/* 
114. Flatten Binary Tree to Linked List
Medium
Given the root of a binary tree, flatten the tree into a "linked list":

The "linked list" should use the same TreeNode class where the right child pointer points to the next node in the list and the left child pointer is always null.
The "linked list" should be in the same order as a pre-order traversal of the binary tree.

Passes - Beats 91% of C# users
*/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    List<TreeNode> Nodes = new List<TreeNode>();
    public void Flatten(TreeNode root) {
        recurse(root);
        TreeNode curNode = root;
        foreach( TreeNode node in Nodes ){
            if(node != root) {
                curNode.left = null;
                curNode.right = node;
                curNode = node;
            }
        }
    }

    public void recurse(TreeNode curNode) {
        if(curNode == null)
            return;
        Nodes.Add(curNode);
        recurse(curNode.left);
        recurse(curNode.right);
    }
}
