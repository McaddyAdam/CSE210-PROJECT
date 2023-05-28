using System;
using System.Collections.Generic;

namespace ScriptureMemoryProgram
{
    // Class representing a word in the scripture
    public class ScriptureWord
    {
        public string Text { get; set; }
        public bool IsHidden { get; set; }

        public ScriptureWord(string text)
        {
            Text = text;
            IsHidden = false;
        }
    }

    // Class representing the scripture reference
    public class ScriptureReference
    {
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int StartVerse { get; set; }
        public int EndVerse { get; set; }

        public ScriptureReference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = verse;
            EndVerse = verse;
        }

        public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            if (StartVerse == EndVerse)
                return $"{Book} {Chapter}:{StartVerse}";
            else
                return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }

    // Class representing the scripture itself
    public class Scripture
    {
        private List<ScriptureWord> words;

        public ScriptureReference Reference { get; set; }

        public Scripture(ScriptureReference reference, string text)
        {
            Reference = reference;
            words = new List<ScriptureWord>();

            // Split the scripture text into words
            string[] wordArray = text.Split(' ');

            // Create ScriptureWord objects for each word in the text
            foreach (string word in wordArray)
            {
                words.Add(new ScriptureWord(word));
            }
        }

        // Hide a random word in the scripture
        public bool HideRandomWord()
        {
            List<ScriptureWord> visibleWords = GetVisibleWords();

            if (visibleWords.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(visibleWords.Count);
                visibleWords[randomIndex].IsHidden = true;
                return true;
            }

            return false;
        }

        // Get all visible words in the scripture
        public List<ScriptureWord> GetVisibleWords()
        {
            List<ScriptureWord> visibleWords = new List<ScriptureWord>();
            foreach (ScriptureWord word in words)
            {
                if (!word.IsHidden)
                    visibleWords.Add(word);
            }
            return visibleWords;
        }

        // Check if all words in the scripture are hidden
        public bool AreAllWordsHidden()
        {
            foreach (ScriptureWord word in words)
            {
                if (!word.IsHidden)
                    return false;
            }
            return true;
        }

        // Get the complete scripture text, including hidden words
        public string GetFullText()
        {
            string fullText = "";
            foreach (ScriptureWord word in words)
            {
                if (word.IsHidden)
                    fullText += "____ ";
                else
                    fullText += word.Text + " ";
            }
            return fullText.Trim();
        }
    }

    public class Program
    {
        private static List<Scripture> scriptures;

        static void Main(string[] args)
        {
            InitializeScriptures();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press enter to reveal more words or type 'quit
