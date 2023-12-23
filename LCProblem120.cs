/*
120. Triangle
Medium
Given a triangle array, return the minimum path sum from top to bottom.

For each step, you may move to an adjacent number of the row below. More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.
Passed - Beats 95% of C# users
*/
public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        int n = triangle.Count;

        for( int i = n-1; i > 0; i--) {
            int m = triangle[i].Count;
            for(int j = 0; j < m-1; j++) {
                triangle[i-1][j] += Math.Min(triangle[i][j], triangle[i][j+1]);
            }
        }
        return triangle[0][0];
    }
}
