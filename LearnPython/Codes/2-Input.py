# String Input, Output
print('Enter your name:')
name = input()
print('Hello, ' + name)
print(type(name))

# --------------------------------------------------------------------------------------------------------------------------------

# Integer Input, Output
print('Enter your age:')
age = int(input())
print('You are' , age, 'years old') # comma adds a space between the variables, preferred method as it supports diff datatypes 
print('You will be ' + str(age+1) + ' in a year') # when using +, convert int to string

# --------------------------------------------------------------------------------------------------------------------------------

# Float Input, Output
val = float(input('Press Enter to exit')) # Error if you try to enter string
print(val)
val = int(input('Press Enter to exit')) # Error if you try to enter float/string
print(val)

# --------------------------------------------------------------------------------------------------------------------------------

# List Input
# split() splits the input string into a list of strings, map() converts the list of strings to a list of integers
val = list(map(int, input('Enter 3 numbers: ').split())) 
print(val)