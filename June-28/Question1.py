# 1) Longest Substring Without Repeating Characters. 
# That is in a given string find the longest substring that does not contain any character twice.

def find_longest_substring_with_no_repeating_characters(input_string):
    longest_substring = ""
    for i in range(0, len(input_string)):
        substring = ""
        for j in range (i, len(input_string)):
            if(input_string[j] not in substring):
                substring += input_string[j]
            elif(input_string[j] in substring):
                break;
        if(len(substring) > len(longest_substring)):
            longest_substring = substring
            
    return longest_substring

input_string = input("Enter your input string:")
print(find_longest_substring_with_no_repeating_characters(input_string))