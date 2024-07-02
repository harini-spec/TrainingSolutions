# String Formatting
marks = 30.5
print('You scored {}'.format(marks)) # {} is a placeholder for a string
print('You scored %s' % marks) # %s is a placeholder for a string
print('You scored %.2f' % marks) # %f is a placeholder for a float

# Output
list_vals = [1,2,3,4,5,2]
tuple_vals = (1,2,3,4,5,2) # Tuple is immutable (cannot be changed after creation), takes duplicate values 
set_vals = {1,2,3,4,5}  # Set is mutable (can be changed after creation), ignores duplicate values
dict_vals = {'name': 'John', 'age': 30}
print(list_vals)
print(tuple_vals)
print(set_vals)
print(dict_vals)