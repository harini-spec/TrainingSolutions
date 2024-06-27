# 10. Print a pyramid of stars for the number of rows specified
#    *
#   ***
#  ******

# Method 1
rows = int(input("Enter number of rows: "))
inc_val = 1
for i in range(rows):
    for j in range(rows-i-1):
        print(" ", end="")
    for j in range(i+inc_val):
        print("*", end="")
    inc_val += 1
    print()

# Method 2
# rows = int(input("Enter number of rows: "))
# for i in range(1, rows+1):
#     print(" "*(rows-i) + "*"*(2*i-1))