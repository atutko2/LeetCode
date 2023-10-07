// Maximum Sub Array - Calculate the largest value of a sub array that 
// is passed in and return that value


// Too slow, but works
/*public class Solution {
    public int MaxSubArray(int[] nums) {
        long bestSum = -100000, curSum;

        for(int i = 0; i < nums.Length; i++ ) {
            curSum = 0;
            for(int j = i; j < nums.Length; j++ ) {
                curSum += (long)nums[j];
                if(curSum > bestSum) {
                    bestSum = curSum;
                }
            }
            
        }
        return (int)bestSum;
    }
}*/


// recursive solution with caching (PASSES)
public class Solution {
    
    public int MaxSubArray(int[] nums) {
	// define a cache where i is whether you picked the value or not
	// and j is the current index while recursing
        int[ , ] cache = new int [2, nums.Length];


        // set all of the indexes in the cache to -1
        for( int i = 0; i < 2; i++ ) {
            for(int j = 0; j < nums.Length; j++ ) {
                cache[i, j] = -1;
            }
        }
	// return the recursive solution
        return recurse(ref nums, 0, 0, ref cache);
    }
    // enumerate all possible sums recursively
    public int recurse(ref int[] nums, int i, int mustPick, ref int[ , ] cache) {
	// if we have reached the end of the array and this is not a must pick, this is a worthless solution
        if(i == nums.Length) {
            return (mustPick == 1) ? 0 : (int)-1e5;
        }

	// if the value of this calculation has been done in the past, return that value
        if(cache[mustPick, i] != -1 ) { return cache[mustPick, i]; }

        // if a value has to be picked, take the current element 
        // and add it to the sum of the recursion
        if(mustPick == 1) {
            return cache[mustPick, i] = Math.Max(0, nums[i]+recurse(ref nums, i+1, 1, ref cache));
        }
        // else pick the max of either not choosing the next element, or choosing it
        return cache[mustPick, i] = Math.Max( recurse(ref nums, i+1, 0, ref cache), 
                                        nums[i] + recurse(ref nums, i+1, 1, ref cache) );

    }
}
