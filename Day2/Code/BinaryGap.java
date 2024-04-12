// you can also use imports, for example:
// import java.util.*;

// you can write to stdout for debugging purposes, e.g.
// System.out.println("this is a debug message");

class Solution {
    public String binary(int n){
        String bin = "";
        while(n!=0){
            int rem = n%2;
            bin = String.valueOf(rem)+bin;
            n/=2;
        }
        return bin;
    }
    public int solution(int N) {
        String binary_val = binary(N); 
        int count = 0;
        int max = 0;
        int ones = 0;
        // System.out.println(binary_val);
        char[] ar = binary_val.toCharArray();
        for(int i=0;i<binary_val.length();i++){
            if(ar[i]=='1'){
                if(ones==0){
                    ones = 1;
                }
                else{
                    ones = 0;
                    if(count>max){
                        max = count;
                    }
                    i--;
                    count = 0;
                }
            }
            else{
                if(ones==1){
                    count++;
                }
            }
        }
        return max;
    }
}