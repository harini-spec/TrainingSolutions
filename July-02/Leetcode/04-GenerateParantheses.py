class Solution(object):
    def generateParenthesis(self, n):

        stack = []
        result = []
        
        def backtracking(openVal, closeVal):
            if(openVal == closeVal == n):
                result.append("".join(stack))

            if openVal < n:
                stack.append("(")
                backtracking(openVal+1, closeVal)
                stack.pop()

            if closeVal < openVal:
                stack.append(")")
                backtracking(openVal, closeVal+1)
                stack.pop()

        backtracking(0, 0)
        return result