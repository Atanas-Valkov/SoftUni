namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string allWords = File.ReadAllText(wordsFilePath);
            string text = File.ReadAllText(textFilePath);
            string[] words = allWords.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> result = new Dictionary<string, int>();
            List<string> linesForOutput = new List<string>();
            foreach (var word in words)
            {
                int wordCounter = WordCountr(text, word);
                result[word] = wordCounter;
            }

            var sortedResult = result.OrderByDescending(x => x.Value);
            foreach (var(word, count) in sortedResult)
            {
                linesForOutput.Add($"{word} - {count}");
            }

            File.WriteAllLines(outputFilePath, linesForOutput);
        }

        public static int WordCountr(string text, string word)
        {
            string lowerWords = word.ToLower();
            string lowerText = text.ToLower();
            int index = 0;
            int counter = 0;
            while (true)
            {
                int posibleNextWord = lowerText.IndexOf(lowerWords, index);

                if (posibleNextWord < 0)
                {
                    break;
                }

                int previousSymbolIndex = posibleNextWord - 1;
                int nextSymbolIndex = posibleNextWord + word.Length;
                index = posibleNextWord + 1;

                if (previousSymbolIndex - 1 >= 0 && char.IsLetter(text[previousSymbolIndex]))
                {
                    continue;
                }

                if (nextSymbolIndex > text.Length && char.IsLetter(text[nextSymbolIndex]))
                {
                    continue;
                }
                counter++;
            }

            return counter;
        }
    }
}
