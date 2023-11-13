/*
86. Partition List
Medium
Given the head of a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

You should preserve the original relative order of the nodes in each of the two partitions.

Passes - Beats 34% of C# users
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        if(head == null) return head;
        if(head.next == null) return head;

        // if we are partitioning on the start of the list
        // find the first value less than x, and create a new list with that
        ListNode newHead = new ListNode(-201, null);;
        if(head.val >= x) {
            // find the first value less than x
            ListNode tmpNode = head.next;
            while(tmpNode != null) {
                if(tmpNode.val < x) {
                    newHead.val = tmpNode.val;
                    break;
                }
                tmpNode = tmpNode.next;
            }

            // if no such value is found, the list is sorted
            if(tmpNode == null) return head;

            // find the rest of the values less than x and attach to the newList
            ListNode newList = newHead;
            tmpNode = tmpNode.next;
            while(tmpNode != null) {
                if(tmpNode.val < x) {
                    newList.next = new ListNode(tmpNode.val, null);
                    newList = newList.next;
                }
                tmpNode = tmpNode.next;
            }

            // now find all values >= x and add them to the list
            tmpNode = head;
            while(tmpNode != null) {
                if(tmpNode.val >= x) {
                    newList.next = new ListNode(tmpNode.val, null);
                    newList = newList.next;
                }
                tmpNode = tmpNode.next;
            }
        }
        // else we need to find the node right before the first value >= x
        else {
            // put all of the values < x on the list in order
            ListNode tmpNode = head.next;
            newHead.val = head.val;
            ListNode newList = newHead;
            while(tmpNode != null) {
                if(tmpNode.val < x) {
                    newList.next = new ListNode(tmpNode.val, null);
                    newList = newList.next;
                }
                tmpNode = tmpNode.next;
            }
            // put all of the values >= x on the list in order
            tmpNode = head;
            while(tmpNode != null) {
                if(tmpNode.val >= x) {
                    newList.next = new ListNode(tmpNode.val, null);
                    newList = newList.next;
                }
                tmpNode = tmpNode.next;
            }
        }

        return newHead;
    }
}

