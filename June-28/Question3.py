# 3) Sort score and name of players print the top 10 

players_data = {"Ram": 100, 
                "Shyam": 200, 
                "Ghanshyam": 300, 
                "Radha": 400, 
                "Sita": 500, 
                "Gita": 600, 
                "Rita": 700, 
                "Sunita": 800, 
                "Anita": 900, 
                "Manita": 1000, 
                "Janita": 1100, 
                "Kanita": 1200, 
                "Banita": 1300, 
                "Tanita": 1400, 
                "Panita": 1500, 
                "Vanita": 1600, 
                "Sanita": 1700, 
                "Danita": 1800, 
                "Lanita": 1900, 
                "Nanita": 2000}

players_data = dict(sorted(players_data.items(), key=lambda x: x[1], reverse=True)) # reverse = True for descending order, lambda takes score values, sorted based on key value which is lambda value = score 
print("Top 10 players are:")
for i in range(0, 10):
    print(list(players_data.keys())[i], ":", list(players_data.values())[i]) # Takes all keys as list and gets data from index 
