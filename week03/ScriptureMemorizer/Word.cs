/// <summary>A word in a scripture passage and whether it has been hidden.</summary>
public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // Keep punctuation in place while replacing each letter with one underscore.
        return string.Concat(_text.Select(character => char.IsLetter(character) ? "_" : character.ToString()));
    }
}
