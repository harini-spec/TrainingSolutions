class Solution(object):
    def convert(self, s, numRows):
        if(numRows < 2 or numRows>len(s)):
            return s

        row_diff = (numRows-1)*2
        res = []

        for i in range(0, numRows):
            for j in range(i, len(s), row_diff):
                res.append(s[j])
                if(i>0 and i<numRows-1 and j+row_diff-2*i < len(s)):
                    res.append(s[j+row_diff-2*i])
        return "".join(res)