using System.Collections.Generic;

/// <summary>A scripture reference and its words, with behavior for hiding them.</summary>
public class Scripture
{
    private const int DefaultWordsToHide = 3;
    private static readonly Random Randomizer = new Random();

    private readonly Reference _reference;
    private readonly List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(wordText => new Word(wordText))
            .ToList();
    }

    public void HideRandomWords()
    {
        HideRandomWords(DefaultWordsToHide);
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int chosenIndex = Randomizer.Next(visibleWords.Count);
            visibleWords[chosenIndex].Hide();
            visibleWords.RemoveAt(chosenIndex);
        }
    }

    public string GetDisplayText()
    {
        string displayedWords = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {displayedWords}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.Count > 0 && _words.All(word => word.IsHidden());
    }
}
