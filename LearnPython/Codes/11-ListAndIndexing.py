# List and Indexing

list_vals = [1,2,3,4,5,2]
print(len(list_vals)) # get the length of the list
print(list_vals)
list_vals.append(6) # add to the end of the list
print(list_vals)
list_vals.insert(2, 7) # insert at a specific index (index, value)
print(list_vals)
list_vals.remove(7) # remove by value
print(list_vals)
list_vals.pop(2) # remove by index
print(list_vals)
list_vals[3] = "hello" # update by index
print(list_vals)
list_vals.clear() # remove all elements
print(list_vals)
