# 4) Take name, age, date of birth and phone print details in proper format

name = input("Enter your name: ")
age = int(input("Enter your age: "))
dob = input("Enter your date of birth: ")
phone = input("Enter your phone number: ") 

print('Name:'.ljust(20) + name)
print('Age:'.ljust(20) + str(age))
print('Date of Birth:'.ljust(20) + dob)
print('Phone Number:'.ljust(20) + phone)

# Here, to print Name, 20 characters are assigned and it is left aligned. Then, the name is printed.
# Name:______15_______name