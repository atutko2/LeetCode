/*
90. Subsets II
Medium
Given an integer array nums that may contain duplicates, return all possible 
subsets
 (the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.
Passes - Beats 53%
*/

class Solution {
public:
    vector<vector<int>> subsetsWithDup(vector<int>& nums) {
        // Set_size of power set of a set with set_size 
        // n is (2^n-1) 
        unsigned int pow_set_size = pow(2, nums.size()); 
        set<vector<int>> mySet;
        vector<int> tmp;
        mySet.insert(tmp);

        // Iterate from 000..0 to 111..1 
        for (int i = 0; i < pow_set_size; i++) { 
            for (int j = 0; j < nums.size(); j++) { 
                // Check if jth bit in the counter is set 
                // If set then add the jth element from set to the vector
		// sort, and add it to the set power set
		// we sort the vector so that values like [1,4,4] and [4,4,1]
		// get caught 
                if (i & (1 << j)) {
                    tmp.push_back(nums[j]);
                    sort(tmp.begin(), tmp.end());
                    mySet.insert(tmp);
                }
            } 
	    // clear the array to get new values
            tmp.clear();
        } 
	// convert the set to a vector
        vector<vector<int>> rv(mySet.begin(), mySet.end());
        return rv;
    }
};
