# Built-in modules

# Using the platform module
import platform
x = platform.system()
print(x)


# Using the dir() function : list all the function names (or variable names) in a module.
import platform
x = dir(platform)
# print(x)


# User defined module 
import ModuleFileExample as mfe
mfe.print_greeting() 


# Using the built-in module datetime
import datetime
x = datetime.datetime.now()
print(x)


# Using the built-in module math
import math
x = math.sqrt(64)
print(x)


# Using the built-in module json - convert from JSON to dictionary
import json
# some JSON:
x =  '{ "name":"John", "age":30, "city":"New York"}'
# parse x:
y = json.loads(x)
# the result is a Python dictionary:
print(y["age"])


# Using the built-in module json - convert from dictionary to JSON
import json
# a Python object (dict):
x = {
  "name": "John",
  "age": 30,
  "city": "New York"
}
# convert into JSON:
y = json.dumps(x)
# the result is a JSON string:
print(y)