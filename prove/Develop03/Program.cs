using System;
using System.Collections.Generic;

public class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    public ScriptureReference(string book, int chapter, int startVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = null;
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
        if (EndVerse.HasValue)
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
    }
}

public class Scripture
{
    private List<string> hiddenWords;

    public ScriptureReference Reference { get; private set; }
    public string Text { get; private set; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Text = text;
        hiddenWords = new List<string>();
    }

    public void HideRandomWord()
    {
        string[] words = Text.Split(' ');
        Random random = new Random();
        int wordIndex;

        do
        {
            wordIndex = random.Next(words.Length);
        }
        while (hiddenWords.Contains(words[wordIndex]));

        hiddenWords.Add(words[wordIndex]);
        words[wordIndex] = "______";

        Text = string.Join(" ", words);
    }

    public void RevealHiddenWords()
    {
        string[] words = Text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == "______")
            {
                words[i] = hiddenWords[i];
            }
        }

        hiddenWords.Clear();
        Text = string.Join(" ", words);
    }

    public bool IsFullyHidden()
    {
        string[] words = Text.Split(' ');

        foreach (string word in words)
        {
            if (word != "______")
            {
                return false;
            }
        }

        return true;
    }

    public override string ToString()
    {
        return $"{Reference.ToString()}\n{Text}";
    }
}

public class ScriptureLibrary
{
    private List<Scripture> scriptures;
    private Random random;

    public ScriptureLibrary()
    {
        scriptures = new List<Scripture>();
        random = new Random();
    }

    public void AddScripture(Scripture scripture)
    {
        scriptures.Add(scripture);
    }

    public Scripture GetScripture(int index)
    {
        if (index >= 0 && index < scriptures.Count)
        {
            return scriptures[index];
        }

        return null;
    }

    public Scripture SelectRandomScripture()
    {
        if (scriptures.Count > 0)
        {
            int index = random.Next(scriptures.Count);
            return scriptures[index];
        }

        return null;
    }
}

public class Program
{
    private static void Main()
    {
        ScriptureLibrary library = new ScriptureLibrary();

        // Add some example scriptures to the library
        library.AddScripture(new Scripture(
            new ScriptureReference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son, " +
            "that whoever believes in him shall not perish but have eternal life."
       
