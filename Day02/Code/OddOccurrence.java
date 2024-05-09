// you can also use imports, for example:
import java.util.*;

// you can write to stdout for debugging purposes, e.g.
// System.out.println("this is a debug message");

class Solution {
    public int solution(int[] A) {
        Map<Integer, Integer> map = new HashMap<>();
        for(int i=0;i<A.length;i++){
            if(!map.containsKey(A[i])){
                map.put(A[i], i);
            }
            else{
                map.remove(A[i]);
            }
        }
        for(int val: map.keySet()){
            return val;
        }
        // System.out.println(map);
        return 0;
    }
}