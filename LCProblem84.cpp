/*
84. Largest Rectangle in Histogram
Hard
Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, return the area of the largest rectangle in the histogram.
*?

// Not my code, but know how it works
class Solution {
public:
    int largestRectangleArea(vector<int>& heights) {
        int maxArea = 0;
        stack<pair<int, int>> stk;
        int n = heights.size();

        // iterate over the whole list and get the largest rectangle possible
        for (int i = 0; i < heights.size(); ++i) {
            int start = i;
            // if the stack isn't empty, and the top of the stacks heigh is greater
            // then the current height, calculate the max area of that rectangle
            // this will calculate the all the rectangles to the left of the current index
            while (!stk.empty() && stk.top().second > heights[i]) {
                int index = stk.top().first;
                int height = stk.top().second;
                stk.pop();
                maxArea = max(maxArea, (i - index) * height);
                start = index;
            }

            stk.push({start, heights[i]});
        }

        // after the final iteration of the for loop, if there are still
        // indexes on the stack, calculate maxArea for those too
        while (!stk.empty()) {
            int index = stk.top().first;
            int height = stk.top().second;
            stk.pop();
            maxArea = max(maxArea, (n - index) * height);
        }

        return maxArea;
    }
};
