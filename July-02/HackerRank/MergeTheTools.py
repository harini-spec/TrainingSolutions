def merge_the_tools(string, k):
    for i in range(0, len(string), k):
        substring = string[i:i+k] 
        substring_list = []
        for j in range(0, k):
            if(substring[j] not in substring_list):
                substring_list.append(substring[j])
        print("".join(substring_list))

if __name__ == '__main__':
    string, k = input(), int(input())
    merge_the_tools(string, k)