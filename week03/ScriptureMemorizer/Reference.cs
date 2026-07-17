public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endverse;

    //Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endverse = 0;
    }

    //Constructor for a verse range
    public Reference(string book, int chapter, int verse, int endverse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endverse = endverse;
    }

    public string GetDisplayText()
    {
        if (_endverse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endverse}";
        }
    }
}
