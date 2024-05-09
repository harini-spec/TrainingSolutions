// you can also use imports, for example:
// import java.util.*;

// you can write to stdout for debugging purposes, e.g.
// System.out.println("this is a debug message");

class Solution {
    public int solution(int[] A) {
        int suml = A[0], sumr = 0;
        int diff = 0;
        for(int i=1;i<A.length;i++){
            sumr+=A[i];
        }
        diff = Math.abs(suml-sumr);
        for(int i=1;i<A.length-1;i++){
            suml+=A[i];
            sumr-=A[i];
            int val = Math.abs(suml-sumr);
            if(val<diff){
                diff = val;
            }
        }
        return diff;
    }
}