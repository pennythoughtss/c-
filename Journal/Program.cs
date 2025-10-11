using System;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text.Json;

class Program
{
    public static string[] prompts = {"who are you?: ",
    "What do you want?: ",
    "what are you doing :",
    "No prompt, just freestyle : ",
    "Who was the most interesting person I interacted with today? :",
    "What was the best part of my day? :",
    "How did I see the hand of the Lord in my life today? :",
    "What was the strongest emotion I felt today? :",
    "If I had one thing I could do over today, what would it be?"
    };

    public static List<string> journalEntries = [];

    public static string source = "Journal.txt";


    class Entry
    {
        static public string[] newEntry(string[] prompt)
        {
            Random randomGenerator = new Random();
            int magicNum = randomGenerator.Next(1, prompt.Length);
            string rnPrompt = prompt[magicNum];
            Console.WriteLine(rnPrompt);

            string entry = Console.ReadLine();
            string time = DateTime.Now.ToShortTimeString();
            string date = DateTime.Now.ToShortDateString();

            string[] log = { date, time, rnPrompt, $"{entry} \n"};
            return log;

        }
    }
    
     class Journal
    {
        static public void readFile()
        {
            string readText = File.ReadAllText(source);
            Console.Write(readText);
        }
        
        static public void loadData()
        {
            journalEntries.Clear();
            //grabs from the source and appends to journal entries
            var lines = File.ReadLines(source).Select(l => l.Split('\n'));
            List<string[]> lineList = lines.ToList();
            
            foreach(string[] line in lineList)
            {
                journalEntries.Add(line[0]);
            }
            
        }

        static public void eraseAllData()
        {
            File.WriteAllText(source, "");
            journalEntries = [];
        }
        static public void writeFile()
        {
            foreach (string entry in journalEntries)
            {
                File.AppendAllText(source, $"{entry} \n");
            }

        }
        
        static public void addNewEntry()
        {
            journalEntries.AddRange(Entry.newEntry(prompts));

            //foreach (string entry in journalEntries)
            //{
            //    Console.WriteLine(entry);
            //}
        }

    }

    class Main_()
    {
        static void Main()
        {
            //Journal.addNewEntry();
            //Journal.writeFile();
            //Journal.readFile();
            //Journal.eraseAllData();
            //Journal.loadData();
            Journal.loadData();

            while (true)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write("\n1- New Entry");
                Console.Write("\n2- Display Journal");
                Console.Write("\n3- Save Journal");
                Console.Write("\n4- Switch Journal");
                Console.Write("\n5- Erase Journal Data");
                Console.Write("\n6- Quit");
                Console.ResetColor();

                Console.Write("\n\n What is your choice? : ");
                string userChoice = Console.ReadLine();
                int choice = int.Parse(userChoice);

                switch (choice)
                {
                    case 1:
                        Journal.addNewEntry();
                        break;
                    case 2:
                        foreach(string entry in journalEntries)
                        {
                            Console.WriteLine(entry);
                        }
                        Thread.Sleep(400);
                        break;
                    case 3:
                        Journal.writeFile();
                       /// journalEntries.Clear();

                        break;
                    case 4:
                        //
                        Console.WriteLine($"current Journal \"{source}\"");
                        Console.WriteLine("Would you like to change?");
                        string userChoice3 = Console.ReadLine();
                        if (userChoice3 == "y")
                        {
                            Console.WriteLine("Name of the file (add .txt): ");
                            source = Console.ReadLine();
                            journalEntries.Clear();
                            Journal.loadData();
                        }
                        break;
                    case 5:
                        Console.Write("\n\n Are you sure? (y/n) : ");
                        string userChoice2 = Console.ReadLine();
                        if (userChoice2 == "y")
                        {
                            Journal.eraseAllData();
                            Journal.loadData();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Thread.Sleep(600);
                            Console.WriteLine($"Data erased in {source}");
                            Console.ResetColor();
                        }
                        Thread.Sleep(400);
                        break;
                    case 6:
                        goto exit_loop;
                }

            }
            exit_loop: ;
        }
    }
}