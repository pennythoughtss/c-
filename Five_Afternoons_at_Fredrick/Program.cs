using System;
using FNAF;

// main loop and timer are run from here, oooh boy its gonna get messy in here

class Program()
{

    //static System.Timers.Timer aTimer = new System.Timers.Timer();
    
    static int FPS = 60; // FPS for visual updates only, 60fps or higher just updates as fast as the screen
    static int tick = 0;
    static int dt_current = 1;
    static int dt_last = 0;

    static double seconds = 0;
    static int miliseconds = 0;
    static int setDownTimer = 0;

    static int currentNight = 6;
    static bool quit = false;
    static bool playedAnim = false;
    static int menuTimer = 300;

    public static Utils utils = new Utils();
    public static Office office = new Office();
    public static Animation animation = new Animation();

    //make sure to initalize the animatronics
    static Bonnie bonnie = new Bonnie();
    static Chica chica = new Chica();


//for the update section because I keep losing it
////////////////////////////////////////////////////////////////////////////////////// 
/// static void Update(Object source, System.Timers.ElapsedEventArgs e) 
    static void UpdateLogic()
    {   
        if (utils.death != true && utils.victory != true)
        {
            //IMPORTANT DO NOT REMOVE// MAIN CLOCK FOR IN GAME TIME
            utils.setTime(miliseconds);
            bonnie.setAI(utils.currNight_AI[1]); // bonnie is #1
            chica.setAI(utils.currNight_AI[2]);
            if (utils.currTime == 6)
            {
                utils.victory = true;
            }

            // for the love of everything just make sure to add the animatronic update functions
            bonnie.updateMovement(seconds);
            chica.updateMovement(seconds);

            office.setDoorDisplay();

        }
 
    }


// update for visuals ///////////////////////////////////
    public static void UpdateVisual()
    {
        miliseconds += 1;
            seconds = (double) miliseconds / 100;
            tick += 1;
        
            if (tick >= 100/FPS)
            {
                dt_current += 1;
                tick = 0;
            } 

    if (utils.death != true && utils.victory != true)
        {
        if (dt_current > dt_last)
            {
                //temporary animatronic position display
                Console.Clear();
                Console.WriteLine($"Power: {office.power}, {utils.time[utils.currTime]}:00 AM, {miliseconds}");
                Console.WriteLine($"Bonnie: {bonnie.getCurrentPos()}, AI:{bonnie.AI}, {bonnie.movementCheck}");
                Console.WriteLine($"Chica: {chica.getCurrentPos()}, AI:{chica.AI}, {chica.movementCheck}");

                
                office.displayOffice();

                if (office.isCameraUP)
                {
                    Console.WriteLine("\nCamera is up!");
                    setDownTimer = 100;
                }
                else
                { 
                    if (setDownTimer > 0)
                    {
                        setDownTimer--;
                        office.isCameraSetDown = true;
                        Console.WriteLine("\nCamera set down");
                    }
                    else
                    {
                        office.isCameraSetDown = false;
                    }
                    
                }

                dt_last = dt_current;
            }
        }

//// death and victory screens ///////////////////////////////
/// 
        if (utils.death == true)
        {
            if (dt_current > dt_last)
            {
                if (!playedAnim)
                {
                    Console.Clear();
                    Console.WriteLine();
                    animation.youDied_OhNo();
                    playedAnim=true;
                }
                else{
                    if (menuTimer > 0)
                    {
                        menuTimer--;
                        Console.Clear();
                        Console.WriteLine($"You were killed by {utils.whoKilledYou}!");
                        Console.WriteLine("Your body has been stuffed in an animatronic suit.");
                        dt_last = dt_current;
                    }
                    else{quit=true;}
                }
            }
        }
        if (utils.victory == true)
        {

            if (dt_current > dt_last)
            {
                
                if (!playedAnim)
                {
                    Console.Clear();
                    Console.WriteLine();
                    animation.sixAM_YAY_1();
                    playedAnim=true;
                }
                else{
                    if (menuTimer > 0)
                    {
                    menuTimer--;
                    Console.Clear();
                    Console.WriteLine($"Congradulations! You survived night {currentNight}");
                    dt_last = dt_current;
                    }
                    else{quit=true;}
                }
            }
        }
    }
    
////////////////////////////////////////////////////////////////////////////////////

    
    static void Main()
    {
        //init until the main loop
        Console.WriteLine("\n");

        //aTimer.Elapsed += Update;
        //aTimer.Interval = 1; // ~ bad boy updates every millisecond, maybe a bad idea
        

        Console.CursorVisible = false;

        // TODO set the next night when you win I guess
        utils.setCurrNight(currentNight);

        //bonnie.currentPOS = 5;
        //office.ChangeLeftDoor(1);


        //aTimer.Enabled = true;

//event listeners for key control stuff
        Task.Factory.StartNew(() =>
            {
                while (quit != true)
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.C)
                    {
                       if (office.isCameraUP)
                        {
                            office.isCameraUP = false;
                        }
                        else
                        {
                            office.isCameraUP = true;
                        }
                    }
                    if (key == ConsoleKey.A)
                    {
                        if (office.doorsEnabled){
                            if (office.isDoorClosed_L)
                            {
                                office.ChangeLeftDoor(0);
                            }
                            else
                            {
                                office.ChangeLeftDoor(1);
                            }
                    }
                    }
                    if (key == ConsoleKey.D)
                    {
                        if (office.doorsEnabled){
                            if (office.isDoorClosed_R)
                            {
                                office.ChangeRightDoor(0);
                            }
                            else
                            {
                                office.ChangeRightDoor(1);
                            }
                    }
                    }
                    if (key == ConsoleKey.Q)
                    {
                        if (office.doorsEnabled){
                            if(!office.isLightON_L)
                            {
                                office.isLightON_L = true;
                            }
                             else {office.isLightON_L = false;}
                        }
                    }
                    if (key == ConsoleKey.E)
                    {
                        if (office.doorsEnabled){
                                if(!office.isLightON_R)
                            {
                                office.isLightON_R = true;
                            }
                             else {office.isLightON_R = false;}
                        }
                    }

                    if (key == ConsoleKey.Escape)
                    {
                        quit = true;
                    }
                    

                }
                
                
            });

////////////////// MAIN LOOP////////////////////////////////////////////////////////////
        while (quit != true)
        {
            //does code stuff, will update automatically

            UpdateLogic();
            UpdateVisual();
            Thread.Sleep(1);
        }
        

        //aTimer.Dispose();
        Thread.Sleep(500);
        Console.WriteLine("\n--End game");
        Thread.Sleep(1000);
    }
    

}