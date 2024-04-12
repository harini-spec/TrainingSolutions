# you can write to stdout for debugging purposes, e.g.
# print("this is a debug message")

def solution(A):
    sum = 0
    for i in range(len(A)):
        sum+=A[i]
    val = ((len(A)+1)*(len(A)+2))/2
    diff = val-sum
    return int(diff)