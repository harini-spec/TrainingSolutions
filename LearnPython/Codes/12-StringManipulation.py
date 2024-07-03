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

# First letter of sentence capitalization
def capitalize(s):
    print(s.capitalize())
    return s[0].upper() + s[1:]

# Changes all the letters to lowercase
def casefold(s):
    print(s.casefold())

# Checks if the string is printable - escape characters are not printable
def printable(s):
    print(s.isprintable()) # Returns False

# Centers the string - 20 is the width of the string and * is the fill character
def centerString(s):
    print(s.center(20, "*"))

# Encodes the string - å - is a special character and is represented by \xc3\xa5 in utf-8 encoding
def EncodeString(s):
    print(s.encode()) # Hello World Sort\xc3\xa5lh - Default encoding is utf-8
    print(s.encode(encoding="ascii",errors="ignore")) # Hello World Sortlh

def CheckEndsWith(s):
    print(s.endswith("World")) # True
    print(s.endswith("World", 0, 5)) # False - Checks the substring from 0 to 5

if __name__ == "__main__":
    # a = "hello world"
    # a = capitalize(a)

    # a = "Hello WorLd"
    # a = casefold(a)

    # a = "Hello \n World"
    # printable(a) 

    # a = "Banana"
    # centerString(a)

    # a = "Hello World Sortålh"
    # EncodeString(a) 

    CheckEndsWith("Hello World")

    