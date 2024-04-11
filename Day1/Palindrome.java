class Solution {
    public boolean isPalindrome(int x) {
        if(x<0) return false;
        else{
            String val = String.valueOf(x);
            int n = val.length();
            for(int i=0;i<n/2;i++){
                if(val.charAt(i)==val.charAt(n-i-1)){
                    continue;
                }
                else{
                    return false;
                }
            }
            return true;
        }
    } 
}