# Datatypes
print("-------------------- Datatypes --------------------")
marks = 30.5
print(type(marks)) # float
marks = 30
print(type(marks)) # int
marks = '30'
print(type(marks)) # str
marks = True
print(type(marks)) # bool
marks = None
print(type(marks)) # NoneType
marks = [1, 2, 3]
print(type(marks)) # list
marks = (1, 2, 3)
print(type(marks)) # tuple
marks = {1, 2, 3}
print(type(marks)) # set
marks = {'name': 'John', 'age': 30}
print(type(marks)) # dict

# --------------------------------------------------------------------------------------------------------------------------------

# Datatype Conversion
print("-------------------- Datatype Conversion --------------------")
marks = 30.5
marks = int(marks)
print(marks)
print(type(marks)) # int

marks = 30
marks = float(marks)
print(marks)
print(type(marks)) # float

marks = 30
marks = str(marks)
print(marks)
print(type(marks)) # str

marks = '30'
marks = int(marks)
print(marks)
print(type(marks)) # int

marks = '30'
marks = float(marks)
print(marks)
print(type(marks)) # float

marks = '30'
marks = bool(marks)
print(marks)       # True
print(type(marks)) # bool

marks = '-1'
marks = bool(marks)
print(marks)       # True
print(type(marks)) # bool

marks = None
marks = bool(marks)
print(marks)       # False
print(type(marks)) # bool

# --------------------------------------------------------------------------------------------------------------------------------

# Understanding datatypes
print("-------------------- Understanding datatypes --------------------")

# List
# List is mutable (can be changed after creation), takes duplicate values
# can have different datatypes
print("-------------------- List --------------------")
list_vals = [1,2,3,4,5,2]
print(list_vals)
list_vals.append(6) # add to the end of the list
print(list_vals)
list_vals.insert(2, 7) # insert at a specific index (index, value)
print(list_vals)
list_vals.remove(7) # remove by value
print(list_vals)
list_vals.pop(2) # remove by index
print(list_vals)
list_vals[3] = "hello" # update by index
print(list_vals)
list_vals.clear() # remove all elements
print(list_vals)
print(len(list_vals)) # get the length of the list


# Tuple
# Tuple is immutable (cannot be changed after creation), takes duplicate values
# can have different datatypes
print("-------------------- Tuple --------------------")
tuple_vals = (1,2,3,4,5,2)
print(tuple_vals)
print(tuple_vals[3])
print(tuple_vals.count(2)) # count the number of times a value appears
print(tuple_vals.index(2)) # get the 1st index of a value
print(tuple_vals.index(2, 3)) # get the index of a value starting from a specific index
print(tuple_vals)
print(len(tuple_vals))


# Set
# Set is mutable (can be changed after creation), does not take duplicate values
# can have different datatypes
# A set itself may be modified, but the elements contained in the set must be of an immutable type.
# Hence, lists and dictionaries cannot be included in a set, but tuples can.
print("-------------------- Set --------------------")
set_vals = {1,2,3,4,5,2}
print(set_vals)
print(len(set_vals)) # get the length of the set
set_vals.add(6) # add a value
print(set_vals)
set_vals.remove(6) # remove a value
print(set_vals)
set_vals.discard(3) # remove a value
print(set_vals)
set_vals.pop() # remove a random value
print(set_vals)
set_vals.update(["hi", "hello"]) # add multiple values
print(set_vals)
set_vals.clear() # remove all elements
print(set_vals)


# Dictionary
# Dictionary is mutable (can be changed after creation), does not take duplicate keys
# can have different datatypes
print("-------------------- Dictionary --------------------")
val = {1: "One", 1: "Duplicate One", 3: "Three"}
print(val) # ignores duplicate keys and takes the last value
print(len(val)) # get the length of the dictionary
print(val[3]) # get value by key
val[3] = "New Three" # update value by key
print(val)
val[4] = "Four" # add a new key value pair
print(val)
val.pop(4) # remove by key
print(val)
val.popitem() # remove the last key value pair
print(val)
val.clear() # remove all key value pairs
print(val)

# Complex Numbers
# Complex numbers are written with a "j" as the imaginary part
print("-------------------- Complex Numbers --------------------")
x = 3+5j
print(x)
print(type(x))
print(x.real)
print(x.imag)
print(x.conjugate()) # returns the complex conjugate, same real part, imaginary part equal in magnitude but opposite in sign # 3-5j
print(type(x.conjugate()))
print(type(x.real)) # float
print(type(x.imag)) # float

# --------------------------------------------------------------------------------------------------------------------------------
