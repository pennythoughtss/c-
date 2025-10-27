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
            Console.WriteLine(_reference.getVerse());
            foreach (Word smolWord in _text)
            {
                smolWord.Display();
            }
        }
        public bool allWordsHidden()
        {
            int length = _text.Count();
            for (int i = 0; i < length; i++)
            {
                if (_text[i].IsHidden() != true)
                {
                    return false;
                }
            }

            return true;
        }

        public void HideWords(String ammount = "one")
        {
            Random random = new Random();
            int length = _text.Count();
            if (ammount == "one") // hides only one that isn't already hidden
            {
                int randInt = random.Next(0, length);
                while (_text[randInt].IsHidden() == true)
                {
                    randInt = random.Next(0, length);
                }
                _text[randInt].Hide();
            }
            if (ammount == "random") // takes a random number and hides them if they're not already hidden
            {
                int randHalf = random.Next(1, length);
                for (int i = 0; i < randHalf; i++)
                {
                    int randInt = random.Next(0, length);
                    while (_text[randInt].IsHidden() == true)
                    {
                        randInt = random.Next(0, length);
                    }
                    _text[randInt].Hide();
                }
            }
            if (ammount == "half") // hides half of them that are not already hidden
            {
                for (int i = 0; i < length / 2; i++)
                {
                    int randInt = random.Next(0, length);
                    while (_text[randInt].IsHidden() == true)
                    {
                        randInt = random.Next(0, length);
                    }
                    _text[randInt].Hide();
                }
            }


        }
        public void HideAll()
        {
            int length = _text.Count();
            for (int i = 0; i < length; i++)
            {
                _text[i].Hide();
            }
        }
        public void ShowAll()
        {
            int length = _text.Count();
            for (int i = 0; i < length; i++)
            {
                _text[i].Show();
            }
        }
        
        

    }
}