# Exception Handling 

# x is not defined:
try:
  print(x)
except:
    print("An exception occurred")


# The try block does not raise any errors, so the else block is executed:
try:
  print("Hello")
except:
    print("Something went wrong")
else:
    print("Nothing went wrong")


# The finally block, if specified, will be executed regardless if the try block raises an error or not.
try:
  print(x)
except:
    print("Something went wrong")
finally:
    print("The 'try except' is finished")


# You can use the else keyword to define a block of code to be executed if no errors were raised:
try:
  print("Hello")
except:
    print("Something went wrong")
else:
    print("Nothing went wrong")


# Value error - wrong datatype
try:
    x = int(input("Please enter a number: "))
except ValueError:
    print("Oops! That was no valid number. Try again...")


# ZeroDivisionError
try:
    print(10 / 0)
except ZeroDivisionError as e:
    print("You can't divide by zero!", repr(e)) # repr() returns a string containing a printable representation of an object.
    print("You can't divide by zero!", str(e))


# FileNotFoundError
try:
    with open("file.txt") as f:
        print(f.read())
except FileNotFoundError:
    print("File not found")