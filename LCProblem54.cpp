//Given an m x n matrix, return all elements of the matrix in spiral order. 
// Passed - Beats 39% of submissions
// Medium Difficulty

class Solution {
public:
    vector<int> spiralOrder(vector<vector<int>>& matrix) {
        int colStart, colEnd, rowStart, rowEnd, i, j;
        vector<int> rv;

	// Get the start and end of the matrix
        colStart = 0;
        rowStart = 0;
        rowEnd = matrix.size();
        colEnd = matrix[0].size();
        

        
        while( colStart < colEnd && rowStart < rowEnd ) {
	    i = rowStart;
            j = colStart;
	    // iterate over the current row,
	    // push back everthing and set the value -101
            while( j < colEnd && matrix[i][j] != -101) {
                rv.push_back(matrix[i][j]);
                matrix[i][j] = -101;
                j++;
            }
            // set j to the final column in the matrix
	    // set i to the second row in the matrix (we've already pushed [firstRow][finalCol]
            j = colEnd - 1;
            i = rowStart + 1;
	    

            // iterate over the current colummn,
	    // push back everthing and set the value -101
            while( i < rowEnd && matrix[i][j] != -101) {
                rv.push_back(matrix[i][j]);
                matrix[i][j] = -101;
                i++;
            }
	    // set i to the final row
            // set j to the final col -1 (we've already pushed [rowEnd][colEnd]
            i = rowEnd - 1;
            j = colEnd - 2;

	    // iterate over the current row,
	    // push back everthing and set the value -101
            while( j >= colStart && matrix[i][j] != -101) {
                rv.push_back(matrix[i][j]);
                matrix[i][j] = -101;
                j--;
            }
	    // set j to the first column
            // set i to the final row - 1 (we've already pushed [rowEnd][colStart]
            j = colStart;
            i = rowEnd - 2;
            

            // iterate over the current colummn,
	    // push back everthing and set the value -101
            while( i > rowStart && matrix[i][j] != -101) {
                rv.push_back(matrix[i][j]);
                matrix[i][j] = -101;
                i--;
            }
           
	    // increase the starts, and decrease the ends 
            rowStart++;
            rowEnd--;
            colStart++;
            colEnd--;
        }
        return rv;
    }
};
