# Python classes are used to create new user-defined data structures that contain arbitrary information about something.

########################## Class ##########################
# Class is a blueprint for creating objects. Objects have properties and methods. 

class Class1:
    num = 5
    def __init__(self):
        print("Inside Constructor")
        # Local variable, so won't reflect in class variable 
        num = 100 
        # To access class variable, use self.num, and get self as argument in __init__ method
        self.num = 200

    def myMethod(self):
        print("Inside Method")
        print(self.num) # Accessing class variable using self 

Class1().myMethod()
print(Class1.num) # Accessing class variable using class name


########################## Constructor ##########################
# Constructor is a special method in Python which is used to initialize the object. It is called when the object is created.
# Constructor is defined using __init__ method.
# Constructor is optional. If not defined, Python provides default constructor.
# Constructor can take arguments.
# Constructor can be overloaded.

class Class2:
    def __init__(self, num):
        self.num = num

    def myMethod(self):
        print("Inside Method")
        print(self.num)

Class2(10).myMethod()


########################## Destructor ##########################
# Destructor is a special method in Python which is used to destroy the object.
# Destructor is defined using __del__ method.
# Destructor is optional. If not defined, Python provides default destructor.
# Destructor can't take arguments.
# Destructor can't be overloaded.

class Class3:
    def __init__(self):
        print("Inside Constructor")

    def __del__(self):
        print("Inside Destructor")

Class3()


########################## Can create new data members of class and delete them ##########################

object_var = Class3()
object_var.NewVariable = 45
print(object_var.NewVariable)
del object_var.NewVariable
# print(object_var.NewVariable) # Throws error as object_var.NewVariable is deleted


########################## Instance and Class Variables ##########################
# Instance variables are for data unique to each instance 
# class variables are for attributes and methods shared by all instances of the class

class Class4:
    classVar = 10
    def __init__(self, instanceVar):
        self.instanceVar = instanceVar

object1 = Class4(20)
object2 = Class4(30)
print(object1.classVar) # 10
print(object2.classVar) # 10
print(object1.instanceVar) # 20
print(object2.instanceVar) # 30

class Dog:
    tricks = []                  # mistaken use of a class variable

    def __init__(self, name):
        self.name = name

    def add_trick(self, trick):
        self.tricks.append(trick)

dog1 = Dog('Fido')
dog2 = Dog('Buddy')
dog1.add_trick('roll over')
dog2.add_trick('play dead')
print(dog1.tricks)                # ['roll over', 'play dead']  (expected output ['roll over'])

# Inside Destructor of object_var is executed at the end 