# 6) Find if the given number is prime

def checkPrime(num):
    flag = False 
    if(num == 1):
        print("It is neither prime nor composite")
    else:
        for i in range(2, num//2):
            if(num % i == 0):
                print("It is not a prime number")
                flag = True
                break
        if(flag == False):
            print("It is a prime number")


num = int(input("Enter a number: "))
checkPrime(num)