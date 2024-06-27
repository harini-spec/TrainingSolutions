def get_even_numbers(numbers):
    for number in numbers:
        if(number % 2 == 0):
            print(number)


def get_positive_Numbers(numbers):
    positiveNumbers = []
    for number in numbers:
        if(number > 0):
            positiveNumbers.append(number)
    return positiveNumbers

def find_greater_number(number1, number2):
    if(number1 > number2):
        return (str(number1) + " is greater than " + str(number2))
    elif(number1 < number2):
        return (str(number2) + " is greater than " + str(number1))
    else:
        return "Both numbers are equal"

get_even_numbers([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]) # No return
print(get_positive_Numbers([-1, -2, -3, -4, -5, -6, +7, +8, -9, -10])) # With return 
print(find_greater_number(10, 20)) # 2 parameters with return