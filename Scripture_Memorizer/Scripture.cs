using System.Dynamic;
using Memorizer;

namespace Memorizer
{
    class Scripture(string text, Reference reference)
    {
        List<Word> _text = [];
        string[] brokeString = text.Split(" ");
        Reference _reference = reference;

        public void init()
        {
            foreach (string smolText in brokeString)
            {
                _text.Add(new Word(smolText));
            }
        }

        public void DisplayScripture()
        {
            foreach (Word smolWord in _text)
            {
                smolWord.Display();
            }
        }

        

        
        

    }
}