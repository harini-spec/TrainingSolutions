# 9. Find All Permutations of a given string

from itertools import permutations

initial_string = input("Enter a string: ")
permutations_list = ["".join(p) for p in permutations(initial_string)]
# Without join, output would be a list of tuples
# [('a', 'b', 'c'), ('a', 'c', 'b'), ('b', 'a', 'c'), ('b', 'c', 'a'), ('c', 'a', 'b'), ('c', 'b', 'a')]
# p takes one tuple at a time 
print(permutations_list)