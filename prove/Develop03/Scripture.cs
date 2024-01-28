using System.Security.Cryptography;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> wordsToHide = _words.FindAll(w => !w.isHidden());

        if (numberToHide > wordsToHide.Count)
        {
            numberToHide = wordsToHide.Count;
        }

        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(wordsToHide.Count);
            wordsToHide[index].Hide();
            wordsToHide.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return result;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.isHidden())
            {
                return false;
            }
        }
        return true;
    }

    public string GetDisplayReference()
    {
        return _reference.GetDisplayText();
    }

    public void Reset()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }

}