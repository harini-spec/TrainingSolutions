public class Solution {
    public bool IsPalindrome(int x) {
        if(x<0)
            return false;
        else{
            int temp = x;
            int reverse = 0;
            while(temp!=0){
                int rem = temp%10;
                reverse = reverse*10 + rem;
                temp /= 10;
            }
            if(reverse==x){
                return true;
            }
            else
                return false;
        }
    }
}