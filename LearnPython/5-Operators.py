# Operators

print("-------------------- Arithmetic Operators --------------------")
print(7//4) # floor division # 1
print(3%4)  # modulus
print(2**4) # exponentiation
print(3 is 3) # checks if both variables point to the same object # True

print("-------------------- Identity Operators --------------------")
# values are cached and they point to the same memory location
# is, is not
# is used to compare the memory location of the objects
# == is used to compare the values of the objects

a = 3
b = 3
print(id(a)) # 1407153664
print(id(b)) # 1407153664
print(a is b) # True
print(3 is not 3) # False

x = ["apple", "banana", "cherry"]
y = ["apple", "banana", "cherry"]
print(x is y) # False
print(x == y) # True

print("-------------------- Membership Operators --------------------")
# Membership operators are used to test if a sequence is presented in an object
# in, not in
print("banana" in x) # True
print("banana" not in x) # False
print(4 in [2,4]) # True
print(4 not in [2,4]) # False