class Solution(object):
    def groupAnagrams(self, strs):
        result_dict = {}
        for word in strs:
            count = [0] * 26
            for letter in word:
                count[ord(letter) - ord('a')] += 1
            key = tuple(count)
            if(key in result_dict): #instead of this condn, can use defaultdict(list) from collections
                result_dict[key].append(word)
            else:
                result_dict[key] = [word]
        return result_dict.values()