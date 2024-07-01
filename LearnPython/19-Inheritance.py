# Inheritance 

########################## Single inheritance ##########################

class StudentDetails:
    def __init__(self, name, age):
        self.name = name
        self.age = age

    def display(self):
        print("Name: ", self.name)
        print("Age: ", self.age)

class StudentMarks(StudentDetails):
    def __init__(self, name, age, marks):
        super().__init__(name, age)
        self.marks = marks

    def display(self):
        super().display()
        print("Marks: ", self.marks)

student = StudentMarks("John", 20, [90, 30, 40])
student.display()


########################## Multiple inheritance ##########################
# 2 base classes, 1 derived class

class Father:
    def __init__(self, father_name):
        self.father_name = father_name

    def display_name(self):
        print("Father Name: ", self.father_name)
        
class Mother:
    def __init__(self, mother_name):
        self.mother_name = mother_name 
        
    def display_name(self):
        print("Mother Name: ", self.mother_name)  
        
class Child(Father, Mother):
    def __init__(self, fatherName, motherName, childName):
        Father.__init__(self, fatherName)
        Mother.__init__(self, motherName)
        self.name = childName
        
    def display_name(self):
        Father.display_name(self)
        Mother.display_name(self)
        print("ChildName: ", self.name)
        
Child("Ramu", "Ramya", "Somy").display_name()


########################## Multilevel inheritance ##########################

class PersonalDetails:
    def __init__(self, name, age):
        self.name = name
        self.age = age 
        
    def display(self):
        print("Name: " , self.name)
        print("Age: " , self.age)
        
class EducationalDetails(PersonalDetails):
    def __init__(self, name, age, qualification):
        super().__init__(name, age)
        self.qualification = qualification 
        
    def display(self):
        super().display()
        print("Qualification: " , self.qualification)
        
class MarkDetails(EducationalDetails):
    def __init__(self, name, age, qualification, marks):
        super().__init__(name, age, qualification)
        self.marks = marks 
        
    def display(self):
        super().display()
        print("Marks: " , self.marks)
        
obj_var = MarkDetails("Somu", 21, "BE", [90, 93, 95, 97, 91])
obj_var.display()


########################## Hierarchical inheritance ##########################
# 1 Base class, multiple classes can inherit it 

class Car:
    wheels = 4
    
    def display(self):
        print("Wheels count: ", self.wheels)
        
class BMW(Car):
    def __init__(self, company):
        self.company = company 
        
    def display(self):
        print("Company: ", self.company)    
        super().display()
        
class Audi(Car):
    def __init__(self, company):
        self.company = company 
        
    def display(self):
        print("Company: ", self.company)    
        super().display()
        
BMW("BMW").display()
Audi("Audi").display()
        
########################## Hybrid inheritance ##########################

class A:
    def display(self):
        print("Class A")

class B(A):
    def display(self):
        print("Class B")

class C(A):
    def display(self):
        print("Class C")

class D(B, C):
    pass

obj = D()
obj.display()

# Output: Class B
# Reason: Method Resolution Order (MRO) -> D -> B -> C -> A
# Checks for display method in D, not found
# Checks for display method in B, found and executed