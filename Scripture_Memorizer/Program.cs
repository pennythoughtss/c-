using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Memorizer;

class Program
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("---Welcome---\nPlease enter the book of the scripture\nyou would like to memorize: ");
        string book = Console.ReadLine();
        Console.Clear();
        Console.Write("Chapter? : ");
        string chapter = Console.ReadLine();
        Console.Clear();
        Console.Write("Start verse? : ");
        string startVerse = Console.ReadLine();
        Console.Clear();
        Console.Write("End verse? (type 0 if none) : ");
        string endVerse = Console.ReadLine();
        Console.Clear();

        int ch = 0;
        Int32.TryParse(chapter, out ch);
        int sVerse = 0;
        Int32.TryParse(startVerse, out sVerse);
        int eVerse = 0;
        Int32.TryParse(endVerse, out eVerse);

        Reference reference = new Reference(book, ch, sVerse, eVerse);

        Console.WriteLine("Finally, the scripture itself : ");
        string script = Console.ReadLine();

        Scripture scripture = new Scripture(script, reference);
        scripture.init();

        //when hiding words check if all words hidden first or we could get stuck in an infinite loop

        Thread.Sleep(800);
        Console.Clear();
        scripture.DisplayScripture();
        Console.WriteLine("\n(Press enter to hide a random ammount of words)");
        Console.ReadLine();
        scripture.HideWords("random");

        string choice = "";

        while (true)
        {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("\n(Press enter to show the words again)\n(type 'hide' to hide another word)\n(type 'quit' to quit)\n");
            choice = Console.ReadLine();
            if (choice == "hide")
            {
                while (scripture.allWordsHidden() != true)
                {
                    Console.Clear();
                    scripture.HideWords();
                    scripture.DisplayScripture();
                    Console.WriteLine("\n(Press enter to hide another word)\n(type 'show' to show the words)\n");
                    choice = Console.ReadLine();
                    if (choice == "show")
                    {
                        break;
                    }
                }
                break;
                
            }
            if (choice == "quit")
            {
                break;
            }
            else
            {
                scripture.ShowAll();
                Console.Clear();
                scripture.DisplayScripture();
                Console.WriteLine("\n(Press enter to hide random words)\n(type 'quit' to quit)\n");
                choice = Console.ReadLine();
                if (choice == "quit")
                {
                    break;
                }
                scripture.HideWords("random");
            }

        }
        if (scripture.allWordsHidden() == true && choice != "quit")
        {
            Console.Clear();
            Console.WriteLine("Congrats! \n (press enter to quit)");
            Console.ReadLine();
        }
        
        
    }
}