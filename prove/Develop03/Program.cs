using System;
using System.Collections.Generic;

namespace Scripture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reference r1 = new Reference("Book1", 1, 1);
            string x, y;
            Console.Clear();
            x = "Proverbs: 3:5-6 Trust in the Lord with all thine heart and len not unto thine own understanding; in all thy ways acknowledge him, and shall direct thy paths. This is the classic understanding of the knowledge and all should be directed there.";
            Scripture scs = new Scripture(r1, x);
            while (!scs.IsCompletelyHidden())
            {
                Console.WriteLine(scs.GetRenderedText());
                Console.WriteLine("\nPress Enter to continue or type 'quit' to Finish!!");
                y = Console.ReadLine();

                if (y == "quit")
                    break;
                else
                    scs.HidePartialWords();
                Console.Clear();
            }
        }

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Scripture
    {
        // Attributes
        private Reference reference;
        private List<Word> words;

        // Constructor
        public Scripture(Reference reference, string text)
        {
            this.reference = reference;
            words = new List<Word>();

            // Split the text of the scripture into individual words
            string[] wordTexts = text.Split(' ');

            // Create a Word object for each word and add it to the list
            foreach (string wordText in wordTexts)
            {
                Word word = new Word(wordText);
                words.Add(word);
            }
        }

        // Behaviors
        public void HideWords()
        {
            foreach (Word word in words)
            {
                word.Hide();
            }
        }

        public void ShowWords()
        {
            foreach (Word word in words)
            {
                word.Show();
            }
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }

            return true;
        }

        public void HidePartialWords()
        {
            Random random = new Random(words.Count);
            int x = 0;
            while (true)
            {
                int rnd = random.Next(0, words.Count);
                if (words[rnd].IsHidden() == false)
                {
                    words[rnd].Hide();
                    x++;
                }
                if (x > 1)
                    break;

            }
        }

        public string GetRenderedText()
        {
            string renderedText = "";

            foreach (Word word in words)
            {
                renderedText += word.GetRenderedText() + " ";
            }

            return renderedText;
        }
    }

    public class Reference
    {
        // Attributes

        private string book;
        private int chapter;
        private int verse;
        private int endVerse;

        // Constructors
        public Reference(string book, int chapter, int verse)
        {
            this.book = book;
            this.chapter = chapter;
            this.verse = verse;
        }

        public Reference(string book, int chapter, int verse, int endVerse)
        {
            this.book = book;
            this.chapter = chapter;
            this.verse = verse;
            this.endVerse = endVerse;
        }
    }

    public class Word
    {
        // Attributes
        private string text;
        private bool isHidden;

        // Constructor
        public Word(string text)
        {
            this.text = text;
            isHidden = false;
        }

        // Behaviors
        public void Show()
        {
            isHidden = false;
        }

        public void Hide()
        {
            isHidden = true;
        }

        public bool IsHidden()
        {
            return isHidden;
        }

        public string GetRenderedText()
        {
            if (isHidden)
            {
                string returns = "";
                for (int i = 0; i < text.Length; i++)
                {
                    returns += "_";
                }
                return returns;
            }
            else
            {
                return text;
            }
        }
    }
}

