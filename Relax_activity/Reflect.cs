namespace Activity
{
    class Reflect : Activity
    {
        List<string> prompt1 = ["Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."];
        List<string> prompt2 = ["Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"];
        private int num = 17;
        
        public void DisplayIntro()
        {
            string title = "Reflecting Activity";
            string description = "You will reflect while you take long deep breaths";
            Intro(title, description);
            num = int.Parse(Console.ReadLine());
            Intro2();
        }

        public void ReflectActivity()
        {
            Random radnom = new Random();
            DisplayIntro();
            int duration = 1000 * num;
            int dur = 8000;
            Console.Clear();
            Console.WriteLine("Think deeply about the topic: ");
            Console.WriteLine("\n");
            int i = 0;
            bool hasShownPrompt = false;
            bool hasShownPrompt2 = false;

            
            while (duration > 0)
            {
                while (dur >= 0 && duration > 0)
                {

                    if (hasShownPrompt == false)
                    {
                        Console.Clear();
                        int rand1 = radnom.Next(0, prompt1.Count);
                        Console.WriteLine(prompt1[rand1]);
                        Console.WriteLine();
                        hasShownPrompt = true;
                    }
                    animation.load3(i,duration);
                    Thread.Sleep(250);
                    duration -= 250;
                    dur -= 250;
                    if (i < 7)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }

                }
                while (0 > dur && dur > -8000 && duration > 0)
                {
                    if (hasShownPrompt2 == false)
                    {
                        Console.Clear();
                        int rand2 = radnom.Next(0, prompt2.Count);
                        Console.WriteLine(prompt2[rand2]);
                        Console.WriteLine();
                        hasShownPrompt2 = true;
                    }
                    animation.load3(i,duration);
                    Thread.Sleep(250);
                    duration -= 250;
                    dur -= 250;
                    if (i < 7)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                }
                dur = 8000;
                hasShownPrompt = false;
                hasShownPrompt2 = false;

            }
        }

    }

}