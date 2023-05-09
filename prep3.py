import random

play_again = 'yes'

while play_again == 'yes':
    magic_number = random.randint(1, 100)
    num_guesses = 0
    
    while True:
        guess = int(input("What is your guess? "))
        num_guesses += 1
        
        if guess < magic_number:
            print("Higher")
        elif guess > magic_number:
            print("Lower")
        else:
            print("You guessed it!")
            break
            
    print(f"You made {num_guesses} guesses.")
    play_again = input("Do you want to play again? (yes or no) ").lower()

print("Thanks for playing!")
