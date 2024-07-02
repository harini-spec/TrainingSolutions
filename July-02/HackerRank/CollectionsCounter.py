from collections import Counter

shoes_count = int(input())
shoe_sizes = list(map(int, input().split(" ")))
customer_count = int(input())
customer_size = []
customer_amount = []
for i in range(customer_count):
    user_input = input().split(" ")
    customer_size.append(int(user_input[0]))
    customer_amount.append(int(user_input[1]))

shoe_sizes_count_dict = Counter(shoe_sizes)

amount = 0
for i in range(customer_count):
    if customer_size[i] in shoe_sizes_count_dict.keys() and shoe_sizes_count_dict.get(customer_size[i])>0:
        amount += customer_amount[i]
        shoe_sizes_count_dict[customer_size[i]] = shoe_sizes_count_dict.get(customer_size[i])-1
        
print(amount)
