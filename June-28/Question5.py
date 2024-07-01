# 5) Credit card validation - Luhn check algorithm 

def Luhn_check(card_number):
    reverse_card_number = card_number[::-1]
    sum = 0
    for i in range (0, len(reverse_card_number)):
        if(not(reverse_card_number[i] >= '0' and reverse_card_number[i] <='9')):
            return False
        digit_val = int(reverse_card_number[i])
        if(i%2!=0):
            digit_val *= 2;
            if(digit_val>9):
                digit_val = (digit_val%10) + (digit_val//10)
            sum += digit_val
        else:
            sum += int(reverse_card_number[i])
    print(sum)
    if(sum % 10 == 0):
        print("Valid Number!")
    else:
        print("Invalid Number!")
    return True

card_number = input("Enter the card number: ")
if(not(Luhn_check(card_number))):
    print("Incorrect card value")