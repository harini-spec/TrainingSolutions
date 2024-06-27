# 7. Take 10 numbers and find the average of all the prime numbers in the collection

numbers = list(map(int, input("Enter 10 numbers: ").split(" ")))
prime_numbers = []
for number in numbers:
    flag = True
    if(number == 1):
        continue
    for i in range(2, number//2):
        if(number % i == 0):
            flag = False
            break 
    if(flag == True):
        prime_numbers.append(number)

print("Prime Numbers : " , prime_numbers)
average = sum(prime_numbers)/len(prime_numbers)
print("Average of prime numbers is: ", average)