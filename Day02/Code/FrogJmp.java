// you can also use imports, for example:
// import java.util.*;

// you can write to stdout for debugging purposes, e.g.
// System.out.println("this is a debug message");

class Solution {
    public int solution(int X, int Y, int D) {
        int diff = Y-X;
        int val = 0;
        if(X==Y)
            return 0;
        else if(D>diff){
            return 1;
        }
        else{
            if(diff%D!=0){
                val = (diff/D)+1;
            }
            else
                val = diff/D;
        }
        return val;
    }
}