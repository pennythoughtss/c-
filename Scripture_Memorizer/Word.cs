
namespace Memorizer
{
    class Word(string word, bool hidden = false)
    {
        string _word = word;
        bool _hidden = hidden;

        void Hide()
        {
            _hidden = true;
        }
        void Show()
        {
            _hidden = false;
        }

        public void Display()
        {
            if (_hidden != true)
            {
                Console.Write(_word);
            }
            else
            {
                for (int i = 0; i < _word.Length; i++)
                {
                    Console.Write("_");
                }
            }
            Console.Write(" ");
        }

        bool IsHidden()
        {
            return _hidden;
        }


    }
}