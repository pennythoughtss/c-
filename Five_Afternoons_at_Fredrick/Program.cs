using System;

class Program()
{

    static System.Timers.Timer aTimer = new System.Timers.Timer();
    static int FPS = 25; // made it a multiple of 1000 because it messes up my timer if not
                         // screw you and your conventional FPS
    static int frames = 0;
    static int tick = 0;
    static int seconds = 0;
    
    static void ClearCurrentConsoleLine()
    {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
    }
    static void Update(Object source, System.Timers.ElapsedEventArgs e)
    {   
        // this is important, don't take it out of the update funtion
        frames += 1;
        tick += 1;
        if (tick == FPS)
        {
            seconds += 1;
            tick = 0;
        }
        //////////////////////
        // add your stuff to update


        Console.SetCursorPosition(0, Console.CursorTop - 1);
        ClearCurrentConsoleLine();
        Console.Write(frames);
        Console.SetCursorPosition(0, Console.CursorTop + 1);
        ClearCurrentConsoleLine();
        Console.Write(seconds);

    }
    
    
    static void Main()
    {
        //main loop
        aTimer.Elapsed += Update;
        aTimer.Interval = 1000 / FPS; // ~ FPS times per second
        aTimer.Enabled = true;

        Console.CursorVisible = false;
        Console.WriteLine("\n");

        // MAIN LOOP
        while (true)
        {
            //does code stuff, will update automatically

            //exit
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                aTimer.Dispose();
                break;

            }
        }
        

        aTimer.Dispose();
        Thread.Sleep(500);
        Console.WriteLine("\nttimer disposed of");
        Thread.Sleep(1000);
    }
    

}