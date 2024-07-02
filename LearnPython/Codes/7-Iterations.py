# For loop 
print("-------------------- For Loop --------------------")
animals = ['cat', 'dog', 'monkey']
for animal in animals:
    print(animal)

# To access the index of each element within the body of a loop, use the built-in enumerate function:
animals = ['cat', 'dog', 'monkey']
for idx, animal in enumerate(animals):
    print('#%d: %s' % (idx + 1, animal))

for i in range(5):
    print(i , end=" ") # prints in same line 
print()

# with increment value (start index, end index, increment value)
# start - included, end - excluded
for x in range(2, 30, 2):
  print(x, end=" ")


# While loop 
print("\n-------------------- While Loop --------------------")
count = 0
while count < 5:
    print(count, end=" ")
    count += 1


# Do-While loop
# Python doesn't have do-while loop


# List Comprehensions
print("\n-------------------- List Comprehensions --------------------")
# List comprehensions provide a concise way to create lists.
# Common applications are to make new lists where each element is the result of some operation 
# applied to each member of another sequence or iterable, or to create a subsequence of those elements that satisfy a certain condition.
numbers = [1,2,3,4,5]
squares = []

# List comprehension for every element in numbers
square_list = [n*n for n in numbers]
print(square_list)

# List comprehensions with conditions
even_nos = [n for n in numbers if n%2==0]
print(even_nos)