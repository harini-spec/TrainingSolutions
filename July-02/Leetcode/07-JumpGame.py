class Solution(object):

    def canJump(self, nums):
        if len(nums)==1:
            return True  

        backtrack_index = len(nums)-2 
        jump =1  

        while backtrack_index>0:
            if nums[backtrack_index]>=jump: 
                jump=1 
            else:
                jump+=1 
            backtrack_index-=1
        
        if jump <=nums[0]: 
            return True
        else:
            return False