using System.Reflection;

namespace Activity
{
    class Listing : Activity
    {
        bool timeIsUp = false;
        string temp = "";
        List<string> listedObj = [];
        
        List<string> prompt = ["Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"];
        private int num = 20;

        public void DisplayIntro()
        {
            string title = "Listing Activity";
            string description = "This activity will help you reflect on the good things in your life\n by having you list as many things as you can in a certain area.";
            Intro(title, description);
            num = int.Parse(""+Console.ReadLine());
            Intro2();
        }
         void HandleTimer()
        {
            timeIsUp = true;
            Console.WriteLine("Time is up!\n (press enter to continue)");
        }

        public void ListingActivity()
        {
            Random radnom = new Random();
            DisplayIntro();
            int duration = 1000 * num;
            Console.Clear();
            int rand = radnom.Next(0, prompt.Count);
            Console.WriteLine("Reflect on the prompt: ");
            Console.WriteLine(prompt[rand]);
            Console.WriteLine("");
            animation.Countdown(10);

            Console.Clear();
            Console.WriteLine(prompt[rand]);
            Console.WriteLine("Write as many ideas you can think of\nrelating to the topic: \n");

            System.Timers.Timer timer = new System.Timers.Timer(duration);
            timer.Elapsed += async (sender, e) => HandleTimer();
            timer.Start();
            
            // Guess I'm using a timer now instead of just guessing using thread delays,
            // shut up, I'm not inconsistant, YOU'RE inconsistant

            Console.CursorVisible = true;
            while (timeIsUp == false)
            {
                Console.Write("- ");
                temp = ""+Console.ReadLine();
                listedObj.Add(temp);
            }
            timer.Dispose();
            
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine($"Your list for \"{prompt[rand]}\": ");
            foreach (string obj in listedObj)
            {
                Console.WriteLine("- "+obj);
            }
            
            Console.WriteLine("Press Enter to continue");
            while (Console.ReadKey().Key != ConsoleKey.Enter) {}
            

        }

    }

}