# 2) Print the list of prime numbers up to a given number 

def find_prime_list_till_limit(limit):
    prime_list = []
    for i in range (2, limit+1):
        is_prime = True
        for j in range (2, (i//2)+1):
            if(i%j == 0):
                is_prime = False
                break;
        if(is_prime):
            prime_list.append(i)
    print(len(prime_list))
    return prime_list

input_limit = int(input("Enter the limit:"))
print(find_prime_list_till_limit(input_limit))