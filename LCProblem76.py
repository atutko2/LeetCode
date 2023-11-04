"""
76. Minimum Window Substring - Hard Difficulty
Given two strings s and t of lengths m and n respectively, return the minimum window 
substring
 of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".

The testcases will be generated such that the answer is unique.

"""


""" 
Solves 265 of 267 tests for the problem, but too slow :(

class Solution(object):
    def minWindow(self, s, t):
        """
        :type s: str
        :type t: str
        :rtype: str
        """
        if len(t) > len(s):
            return ""
        
        sourceOfTruth = {}

        # set all the variables to -1, so we can mark when it is found
        for x in t:
            val = sourceOfTruth.get(x)
            if(val != None):
                sourceOfTruth[x] += 1
            else:
                sourceOfTruth[x] = 1
        
        dic = sourceOfTruth.copy()
        count = 0
        countTrue = 0
        rv = ""
        rvs = []
        # get all potential substrings
        for x in s: 
            # if we have not found the start of an array
            val = dic.get(x)
            if(val == None):
                count += 1
                continue
            # we have found the start of a substring
            else:
                for y in range(count, len(s)):
                    print(s[y])
                    rv += s[y]
                    val = dic.get(s[y])
                    if(val != None and val > 0):
                        dic[s[y]] -= 1
                        countTrue += 1
                    if(countTrue == len(t)):
                        rvs.append(rv)
                        break
                rv = ""
                dic = sourceOfTruth.copy()
                countTrue = 0
            count += 1

        # find the shortest of these substrings
        rv = s + "BS"
        for x in rvs:
            if len(x) < len(rv):
                rv = x
        
        if rv == (s + "BS"):
            return ""
        else:
            return rv
"""

# Not my solution, but I understand it
class Solution(object):
    def minWindow(self, s, t):
        """
        :type s: str
        :type t: str
        :rtype: str
        """
        if len(t) > len(s):
            return ""
        
        dic = collections.defaultdict(int)
        # set all the variables to the total count of them, so we can mark when it is found
        for x in t:
            dic[x] += 1
        
        countNeeded = len(t)
        rv= (0, len(s)+1)
        start = 0
        end = len(s)-1
        # sliding window, we need the end of the window to determine its length
        for end, x in enumerate(s): 
            # if the value of our dictionary is greater than 0, 
            # we still haven't all of the needed letters
            if dic[x] > 0:
                countNeeded -= 1
            dic[x] -= 1
            # if countNeeded == 0, we have found a valid substring
            if countNeeded == 0:
                # move the left side of the window
                while True:
                    tmp = s[start]
                    if dic[tmp] == 0:
                        break
                    dic[tmp] += 1
                    start += 1
                # if the substring we just found is smaller then the current best, update best
                if end - start < rv[1] - rv[0]:
                    rv = (start, end)
                # update the starts total found
                dic[s[start]] += 1
                countNeeded += 1
                start += 1
        if rv[1] > len(s):
            return ''
        else:
            return s[rv[0]:rv[1]+1]
                 
                                                
