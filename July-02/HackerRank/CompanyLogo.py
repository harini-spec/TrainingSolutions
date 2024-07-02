#!/bin/python3

import math
import os
import random
import re
import sys



if __name__ == '__main__':
    s = input()
    char_list = list(s)
    occurence_dict = {}
    for i in char_list:
        if(i not in occurence_dict.keys()):
            occurence_dict[i] = 1
        else:
            occurence_dict[i] = occurence_dict.get(i)+1
    occurence_sorted_list = sorted(occurence_dict.items(), key=lambda x: (-x[1], x[0]))
    for i in range(0,3):
        print(occurence_sorted_list[i][0], occurence_sorted_list[i][1])
        
