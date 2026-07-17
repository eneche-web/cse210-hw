using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference_reference;
    private List<Word>_words;

    public Scripture(ReferenceEqualityComparer reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }
    public string GetDisplayText()
    {
        string text = "";
        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} {text}";
    }
    public void HiddenRandomWords(int numberToHide)
    {
        Random random = new Random();

        List<Word> visibleWords = _words.Where(w => ! w.IsHidden()). ToList();
        for (int i = 0;
        i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);

            visibleWords[index].Hide();

            visibleWords.RemoveAt(index);
        }
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}