using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Serialization;
using Activity;

class Program()
{

    static void Main()
    {
        Console.Clear();
        Reflect reflect = new Reflect();
        Breathing breathing = new Breathing();
        Listing listing = new Listing();

        // I'm so tired of staring at my laptop, I'm gonna go get dinner
        // I made beef strogenoff :)

        while (true)
        {

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("-- Welcome --");
            Console.WriteLine("Please choose an activity (enter the number): ");
            Console.WriteLine("   1- Breathing Activity");
            Console.WriteLine("   2- Reflecting Activity");
            Console.WriteLine("   3- Listing Activity");
            Console.WriteLine("   4- Quit");
            Console.WriteLine();
            int choice = 0;
            choice = int.Parse(Console.ReadLine());
            Console.CursorVisible = false;

            switch (choice)
            {
                case 1:
                    breathing.BreathingActivity();
                    break;
                case 2:
                    reflect.ReflectActivity();
                    break;
                case 3:
                    listing.ListingActivity();
                    break;
                case 4:
                    goto exit_loop;
            }

            Console.Clear();
            Console.WriteLine("Press enter to do another activity, type \"quit\" to exit\n");
            Console.CursorVisible = true;
            string choice2 = Console.ReadLine();
            if (choice2.ToLower() == "quit")
            {
                goto exit_loop;
            }

        }


    exit_loop:;

    }

}