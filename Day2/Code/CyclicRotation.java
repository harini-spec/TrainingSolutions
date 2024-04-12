// you can also use imports, for example:
// import java.util.*;

// you can write to stdout for debugging purposes, e.g.
// System.out.println("this is a debug message");

class Solution {
    public int[] solution(int[] A, int K) {
        int[] ans = new int[A.length];
        for(int i=0;i<A.length;i++){
            int n = i+K;
            if(n<A.length){
                ans[n] = A[i];
            }
            else{
                int quotient = n/A.length;
                int ind = n-(A.length*quotient);
                ans[ind] = A[i];
            }
        }
        return ans;
    }
}