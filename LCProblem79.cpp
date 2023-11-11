/*
79. Word Search
Medium
Given an m x n grid of characters board and a string word, return true if word exists in the grid.

The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.
*/

// Beats 83.38 % of C++ users
class Solution {
public:
    bool exists = false;
    bool exist(vector<vector<char>>& board, string word) {
        int numFound = 0, curI, curJ;

        for(int i = 0; i < board.size(); i++){
            for(int j = 0; j < board[0].size(); j++) {
                if(board[i][j] == word[0]){
                    recurse(i, j, 0, word, board);
                }
            }
        }

        return exists;
    }

    void recurse(int i, int j, int count, string& word, vector<vector<char>>& board) {
        // if we have found a matching array, set true and return
        if(count == word.size()) {
            exists = true;
            return;
        }

        // if we are checking outside of the array return
        if(i < 0 || i > board.size()-1 || j < 0 || j > board[0].size()-1) return;

        // if the current value matches, check if the connected indexes match the next
        if(board[i][j] == word[count]) {
            // set the current char as seen
            char original = board[i][j];
            board[i][j] = '*';
            // above
            recurse(i, j-1, count+1, word, board);
            // right
            recurse(i+1, j, count+1, word, board);
            // below
            recurse(i, j+1, count+1, word, board);
            // left
            recurse(i-1, j, count+1, word, board);
            // remove the current position from being seen
            board[i][j] = original;
        } 
    }
};
