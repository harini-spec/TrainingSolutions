# Conditional Statements
# if, elif, else
val = 10
if val > 10:
    print("Value is greater than 10")
elif val == 10:
    print("Value is equal to 10")
else:
    print("Value is less than 10")

# Nested if
val1 = 10
val2 = 20
if val1 == 10:
    if val2 == 20:
        print("Value1 is 10 and Value2 is 20")
    else:
        print("Value1 is 10 but Value2 is not 20")
else:
    print("Value1 is not 10")

# Short Hand if
val = 60
if val > 10: print("Value is greater than 10")

# Short Hand if else
val = 60
print("Value is greater than 10") if val > 10 else print("Value is less than 10")

# Ternary Operator
# Syntax : [on_true] if [expression] else [on_false] 
val = 60
print("Value is greater than 10") if val > 10 else print("Value is less than 10") if val < 10 else print("Value is equal to 10")