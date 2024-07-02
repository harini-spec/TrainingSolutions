
########################## Understanding Destructor ##########################
# Inside Destructor is executed at the end when execution is completed at the last 
# This is because the object is destroyed at the end of the program - Garbage Collection
# It is also called right after "Inside constructor" as the object is destroyed after the execution of the method
# Destructor is called when the object is destroyed, not when the object goes out of scope

class Class5:
    def __init__(self):
        print("Inside Constructor")

    def __del__(self):
        print("Inside Destructor")

Class5() # Temp object - as soon as __init__ method is executed, object is destroyed as ref count is 0, so destructor is called
print("End") # Destructor is called at the end of the program - Garbage Collection

# O/P:
# Inside Constructor
# Inside Destructor
# End
# Inside Destructor

class Class6:
    def __init__(self):
        print("Inside Constructor")

    def __del__(self):
        print("Inside Destructor")

class_obj = Class6() # Here object is not destroyed as it is assigned to class_obj 
print("End") # Destructor is called at the end of the program - Garbage Collection

# O/P:
# Inside Constructor
# End
# Inside Destructor - As object is destroyed when class_obj goes out of scope
# Inside Destructor - Garbage collection