# Jump Game - Difficulty Medium
#You are given an integer array nums. 
#You are initially positioned at the array's first index, 
#and each element in the array represents your maximum 
#jump length at that position.

#Return true if you can reach the last index, or false otherwise.

# DFS - too slow
"""
class Solution:
    rv = False
    NUMS = []
    def canJump(self, nums: List[int]) -> bool:
        if(len(nums) == 1):
            return True
        self.NUMS = nums
        self.DFS(0)
        return self.rv

    def DFS(self, index: int):
        if(index >= len(self.NUMS)-1):
            self.rv = True
            return
        if(self.NUMS[index] <= 0):
            return
        
        for x in range(1, self.NUMS[index]+1):
            if(self.rv != True):
                self.DFS(x+index)
            else:
                return
"""

# This can be solved by finding the furthest you can jump at each index
# because if you make it to that index, you can make it to any index
# before it
class Solution:
    def canJump(self, nums: List[int]) -> bool:
        furthestIReached = 0
        for x in range(len(nums)):
            if(x > furthestIReached):
                return False
            furthestIReached = max(furthestIReached, x + nums[x])
            if(furthestIReached >= len(nums)-1):
                return True
        return False
