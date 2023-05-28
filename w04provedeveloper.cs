import random
import datetime


class Entry:
    def __init__(self, prompt, response, date):
        self.prompt = prompt
        self.response = response
        self.date = date


class Journal:
    def __init__(self):
        self.entries = []

    def add_entry(self, entry):
        self.entries.append(entry)

    def display_journal(self):
        for entry in self.entries:
            print(f"Date: {entry.date}")
            print(f"Prompt: {entry.prompt}")
            print(f"Response: {entry.response}")
            print()

    def save_journal(self, filename):
        with open(filename, 'w') as file:
            for entry in self.entries:
                file.write(f"{entry.date}|{entry.prompt}|{entry.response}\n")

    def load_journal(self, filename):
        self.entries = []
        with open(filename, 'r') as file:
            for line in file:
                date, prompt, response = line.strip().split('|')
                entry = Entry(prompt, response, date)
                self.entries.append(entry)


class Program:
    def __init__(self):
        self.journal = Journal()
        self.prompts = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        ]

    def run(self):
        while True:
            self.display_menu()
            choice = input("Enter your choice (1-5): ")
            if choice == '1':
                self.write_new_entry()
            elif choice == '2':
                self.journal.display_journal()
            elif choice == '3':
                filename = input("Enter the filename to save: ")
                self.journal.save_journal(filename)
                print("Journal saved successfully.")
            elif choice == '4':
                filename = input("Enter the filename to load: ")
                self.journal.load_journal(filename)
                print("Journal loaded successfully.")
            elif choice == '5':
                break
            else:
                print("Invalid choice. Please try again.")

    def display_menu(self):
        print("====== Journal Program Menu ======")
        print("1. Write a new entry")
        print("2. Display the journal")
        print("3. Save the journal to a file")
        print("4. Load the journal from a file")
        print("5. Exit")

    def write_new_entry(self):
        prompt = random.choice(self.prompts)
        response = input(prompt + " ")
        date = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        entry = Entry(prompt, response, date)
        self.journal.add_entry(entry)
        print("Entry added successfully.")


if __name__ == "__main__":
    program = Program()
    program.run()
