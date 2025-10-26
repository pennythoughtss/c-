namespace Memorizer
{
    class Reference(string book, int chapter, int startVerse, int endVerse = 0)
    {
        string _book = book;
        int _chapter = chapter;
        int _startVerse = startVerse;
        int _endVerse = endVerse;

        public string getVerse()
        {
            if (_endVerse == 0)
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            }
        }
    }
}