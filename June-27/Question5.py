# 5. Add validation the entered name, age, date of birth and phone print details in proper format

def validateDOB(dob):
    if len(dob) == 10 and dob[2] == '/' and dob[5] == '/':
        if dob[:2].isnumeric() and dob[3:5].isnumeric() and dob[6:].isnumeric():
            if dob[:2] <= '31' and dob[3:5] <= '12' and dob[6:] <= '2021':
                return True
    return False

name = input("Enter your name: ")
age = int(input("Enter your age: "))
dob = input("Enter your date of birth (DD/MM/YYYY): ")
phone = input("Enter your phone number (Without country code): ")

if name.isalpha() and len(name)>2 and age > 0 and validateDOB(dob) and phone.isnumeric() and len(phone) == 10:
    print('Name:'.ljust(25) + name)
    print('Age:'.ljust(25) + str(age))
    print('Date of Birth:'.ljust(25) + dob)
    print('Phone Number:'.ljust(25) + phone)
else:
    print("Invalid input. Please enter valid details.")
