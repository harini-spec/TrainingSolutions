public class Solution {
    public int getBullsCount(string secret, string guess){
        int bulls = 0;
        for(int i=0;i<secret.Length;i++){
            if(secret[i] == guess[i])
                bulls++;
        }
        return bulls;
    }

    public string GetHint(string secret, string guess) {
        int bulls = getBullsCount(secret, guess);
        StringBuilder secretsb = new StringBuilder(secret);
        StringBuilder guesssb = new StringBuilder(guess);
        for(int i=0;i<secret.Length;i++){
            for(int j=0;j<secret.Length;j++){
                if(secret[i] == guess[i])
                {
                    secretsb[i] = '#';
                    guesssb[i]  = '#';
                }
            }
        }
        int cows = 0;
        for(int i=0;i<secret.Length;i++){
            if(secretsb[i]!='#')
            {
                for(int j=0;j<secret.Length;j++){
                    if(secretsb[i]!='#' && guesssb[j]!='#' && secretsb[i]==guesssb[j])
                        {
                            cows++;
                            secretsb[i] = '#';
                            guesssb[j] = '#';
                            break;
                        }
                }
            }
        }
        string result = bulls+"A"+cows+"B";
        return result;
    }
}