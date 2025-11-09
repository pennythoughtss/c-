namespace Activity
{
    class Breathing : Activity
    {
        int num = 20;
        
        public void DisplayIntro()
        {
            string title = "Breathing Activity";
            string description = "You will reflect while you take long deep breaths";
            Intro(title, description);
            num = Int32.Parse(Console.ReadLine());
            Intro2();
        }

        public void BreathingActivity()
        {
            DisplayIntro();
            Console.Clear();
            Console.WriteLine("Think deeply while you breathe: ");
            int duration = 1000 * num;
            Console.WriteLine("\n");
            int i = 0;

            while (duration > 0)
            {
                animation.Breathe2(i);
                Thread.Sleep(1300);
                duration -= 1300;
                if (i < 7)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }


            }

            Outro();

        }

    }

}