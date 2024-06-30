# 4) Application to play the Cow and Bull game maintain score as well. - reff - Wordle of New York Times 

# Cow - correct letter in wrong position
# Bull - correct letter in correct position

import random 

def check_if_found(guess_string, chosen_word):
    bulls = 0
    cows = 0
    guess_string = guess_string.lower()
    chosen_word = chosen_word.lower()
    for guess_idx, guess_character in enumerate(guess_string):
        if(guess_character in chosen_word):
            is_bulls = False
            for chosen_word_idx, chosen_word_character in enumerate(chosen_word):
                if guess_character == chosen_word_character and guess_idx == chosen_word_idx:
                    bulls += 1
                    is_bulls = True
                    break
            if (not is_bulls):
                cows += 1

    print("Bulls:", bulls, "Cows:", cows)
    if(bulls == len(chosen_word)):
        return True
    else:
        return False

print("You have 5 guesses to guess the word:")
print("_ _ _ _ _")
words = ["Buddy", "Antic", "Water", "Stare", "lucky"]
chosen_word = random.choice(words)
tries = 5
is_found = False
score = 100
chosen_word = "buddy"
print(chosen_word)

while(tries != 0):
    guess_string = input("Enter your guess: ")
    tries -= 1
    is_found = check_if_found(guess_string, chosen_word)
    if(is_found):
        break;
    else:
        score -= 20
        
if(is_found):
    print("Congrats! You scored:", score)
else:
    print("Sorry, you lost!")