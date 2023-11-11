"""
80. Remove Duplicates from Sorted Array II
Medium
Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.

Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.

Return k after placing the final result in the first k slots of nums.

Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
"""
# Beats 60% of python users
class Solution(object):
    def removeDuplicates(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        count = 0
        for num in nums: 
            # the first two elements are always where they should be
            # after that, all we need to do is keep track of the  current position
            # and replace that location with the current element if it isn't the same 2
            # slots before it
            if(count == 0 or count == 1 or nums[count-2] != num):
                nums[count] = num
                count += 1

        return count
