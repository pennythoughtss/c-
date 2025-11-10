namespace Activity
{
    class Breathing : Activity
    {
        int num = 20;
        
        public void DisplayIntro()
        {
            string title = "Breathing Activity";
            string description = "This activity will help you relax by walking your through breathing in and out slowly. \nClear your mind and focus on your breathing";
            Intro(title, description);
            num = int.Parse(Console.ReadLine());
            Intro2();
        }

        public void BreathingActivity()
        {
            DisplayIntro();
            Console.Clear();
            Console.WriteLine("Think deeply while you breathe: ");
            int duration = 1000 * num;
            Console.WriteLine("\n\n");
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