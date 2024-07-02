if __name__ == '__main__':
    x = int(input())
    y = int(input())
    z = int(input())
    n = int(input())
    x_list = []
    y_list = []
    z_list = []
    for i in range (0,x+1):
        x_list.append(i)
    for i in range (0,y+1):
        y_list.append(i)
    for i in range (0,z+1):
        z_list.append(i)
    result = [[x,y,z] for x in x_list for y in y_list for z in z_list if (x+y+z)!=n]
    print(result)
