class Solution(object):
    def lengthOfLongestSubstring(self, s):
        if(s == " "):
            return 1
        longest_substring = ""
        substring = ""
        for char in s:
            if(char not in substring):
                substring += char
            else:
                if(len(substring) > len(longest_substring)):
                    longest_substring = substring 
                    index = substring.index(char)
                    if(index==len(substring)-1):     # If repeating char is last character
                        substring = char
                    else:                   
                        substring = substring[index+1:]+char
                else:                                # If length of substring is not greater than longest_substring, reset substring value
                    index = substring.index(char)
                    substring = substring[index+1:]+char
 
        if(len(substring) > len(longest_substring)):
            longest_substring = substring 
        return len(longest_substring)
        