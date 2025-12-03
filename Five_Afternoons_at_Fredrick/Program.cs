using System;
using FNAF;

// main loop and timer are run from here, oooh boy its gonna get messy in here

class Program()
{

    static System.Timers.Timer aTimer = new System.Timers.Timer();
    static int FPS = 25; // made it a multiple of 1000 because it messes up my timer if not
                         // screw you and your conventional FPS
                         // screw everything else apparently I'm not even using it
    static int frames = 0;
    static int tick = 0;
    static double seconds = 0;
    static int miliseconds = 0;

    static Utils utils = new Utils();
    static Bonnie bonnie = new Bonnie();
    
    
    static void Update(Object source, System.Timers.ElapsedEventArgs e)
    {   
        // this is important, don't take it out of the update funtion
        // lol I lied I'm not even using it
        // frames += 1;
        // tick += 1;
        // if (tick == FPS)
        // {
        //     seconds += 1;
        //     tick = 0;
        // }
        //////////////////////
        miliseconds += 1;
        seconds = (double) miliseconds / 100;

        //bonnie.updateMovement(seconds);
        
        if (seconds == 4)
        {
            utils.set_2AM();
            bonnie.setAI(utils.currNight_AI[1]);
        }
        if (seconds == 8)
        {
            utils.set_3AM();
            bonnie.setAI(utils.currNight_AI[1]);
        }
        if (seconds == 12)
        {
            utils.set_4AM();
            bonnie.setAI(utils.currNight_AI[1]);
        }

        Console.Clear();
        Console.WriteLine($"{bonnie.path[bonnie.currentPOS]}, AI:{bonnie.AI}, Check:{bonnie.movementCheck}, {bonnie.tempMil}");
    }
    
    
    static void Main()
    {
        //init until the main loop
        Console.WriteLine("\n");

        aTimer.Elapsed += Update;
        aTimer.Interval = 1; // ~ bad boy updates every millisecond, maybe a bad idea
        

        Console.CursorVisible = false;

        // TODO set the next night when you win I guess
        utils.setCurrNight(6);
        bonnie.setAI(utils.currNight_AI[1]);


        aTimer.Enabled = true;

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