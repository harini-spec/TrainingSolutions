class Solution(object):
    def convert(self, s, numRows):
        if(numRows == 1):
            return s

        if(len(s)%numRows != 0):
            val = (len(s)/numRows) + 1
        else:
            val = len(s)/numRows 
        if((val+len(s))%numRows != 0):
            cols = (val + len(s))/numRows + 1
        else:
            cols = (val + len(s))/numRows
        if(numRows < 11):
            cols = len(s)

        rows, cols = (numRows, cols)
        zigzag = [["" for i in range(cols)] for j in range(rows)]
        str_counter = 0
        counter = 0
        is_reverse = False
        flag = False

        for i in range (0,cols):
            while(True):
                if(str_counter >= (len(s))):
                    flag = True
                    break
                if(not is_reverse):
                    zigzag[counter][i] = s[str_counter]
                    str_counter += 1
                    counter += 1
                else:
                    zigzag[counter][i] = s[str_counter]
                    str_counter += 1
                    counter -= 1
                if(counter == numRows and not is_reverse):
                    if(numRows == 2):
                        counter = 0
                    else:
                        counter -= 2
                    is_reverse = True
                    break
                elif(counter <= 0 and is_reverse):
                    if(numRows == 2):
                        counter = 1
                    is_reverse = False
                    break
        
            if(flag):
                break

        result_string = ""
        for i in range(0, numRows):
            for j in range(0, cols):
                if(zigzag[i][j]!=" "):
                    result_string += zigzag[i][j]
        print(zigzag)
        return result_string