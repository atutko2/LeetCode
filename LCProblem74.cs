/*
74. Search a 2D Matrix
Meduim Difficulty
You are given an m x n integer matrix matrix with the following two properties:

Each row is sorted in non-decreasing order.
The first integer of each row is greater than the last integer of the previous row.
Given an integer target, return true if target is in matrix or false otherwise.

You must write a solution in O(log(m * n)) time complexity.
*/
// Passes - Beats 14% of C# Users

public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int lRow, rRow, lCol, rCol, m = 0;
        bool couldExistInRow = false;

        // find the correct row (if none exists return false)
        lRow = 0;
        rRow = matrix.Length - 1;
        while (lRow <= rRow) {
            m = lRow + (rRow - lRow) / 2;
 
            // Check if target could exist in present mid row
            if (matrix[m][0] <= target && matrix[m][matrix[0].Length-1] >= target) {
                couldExistInRow = true;
                break;
            }
 
            // If x greater, ignore left half
            if (matrix[m][0] < target)
                lRow = m + 1;
 
            // If x is smaller, ignore right half
            else
                rRow = m - 1;
        }
        // if it could exist in the current row, check for it
        if(couldExistInRow) {
            lCol = 0;
            rCol = matrix[0].Length - 1;
            while (lCol <= rCol) {
                int mCol = lCol + (rCol - lCol) / 2;
 
                // Check if target could exist in present mid row
                if (matrix[m][mCol] == target) {
                    return true;
                }
 
                // If x greater, ignore left half
                if (matrix[m][mCol] < target)
                    lCol = mCol + 1;
 
                // If x is smaller, ignore right half
                else
                    rCol = mCol - 1;
                }
        }
        return false;
    }
}
