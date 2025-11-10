
namespace Activity
{
    class Activity()
    {
        protected Animation animation = new Animation();
        protected void Intro(string title, string description)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {title}. \n{description}.");
            Thread.Sleep(750);
            Console.WriteLine("How long (in seconds) would you like this activity to be? :");
        }
        protected void Intro2()
        {
            Console.Clear();
            Console.WriteLine($"Prepare to begin");

            animation.Load2();
        }
    
        protected void Outro()
        {
            Console.Clear();
            Console.WriteLine("Good job :)");
            animation.Load2(3);

        }
    }
}