# String manipulation

# String concatenation
a = "Hello"
b = "World"
print(a+" "+b)

# String multiplication
a = "Hello "
a = a * 3
print(a)

# String slicing
a = "Hello World"
a = a[0:5] # Excluding 5
print(a)

# String length
a = "Hello World"
print(len(a))

# String split
a = "Hello world"
a = a.split()
print(a)

# String join
a = ["Hello", "world"]
a = " ".join(a)
print(a)

# String replace
a = "Hello world"
a = a.replace("world", "Python")
print(a)

# String find
a = "Hello world"
a = a.find("world")
print(a) # Returns the index of the first occurence of the substring