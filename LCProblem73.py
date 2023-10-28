"""
73. Set Matrix Zeroes
Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.

You must do it in place.
"""
# Passes - Beats 90% of Python3 users
# Medium Difficulty Problem

class Solution:
    def setZeroes(self, matrix: List[List[int]]) -> None:
        """
        Do not return anything, modify matrix in-place instead.
        """

	# get the row and column of every 0 in the n * m matrix
	# and push it onto the list
        tmpI = []
        tmpJ = []
        for i in range(len(matrix)):
            for j in range(len(matrix[0])):
                if(matrix[i][j] == 0):
                    tmpI.append(i)
                    tmpJ.append(j)
        

	# iterate over the rows found and set everything in the row to 0
        for i in tmpI:
            for j in range(len(matrix[i])):
                matrix[i][j] = 0
        
	# iterate over the columns found and set everything in the column to 0
        for j in tmpJ:
            for i in range(len(matrix)):
                matrix[i][j] = 0
        
