using System;
using FNAF;

// main loop and timer are run from here, oooh boy its gonna get messy in here

class Program()
{
    static int FPS = 60; // FPS for visual updates only, 60fps or higher just updates as fast as the screen
    static int tick = 0;
    static int dt_current = 1;
    static int dt_last = 0;
    static bool toggleDev = false;

    static double seconds = 0;
    static int miliseconds = 0;
    static int setDownTimer = 0;
    static int setDownStall = 0;

    static int currentNight = 6;
    static bool quit = false;
    static bool playedAnim = false;
    static int menuTimer = 300;

    public static Utils utils = new Utils();
    public static Office office = new Office();
    public static Animation animation = new Animation();
    public static SecurityCamera camera = new SecurityCamera();
    static Random random = new Random();

    //make sure to initalize the animatronics
    static Bonnie bonnie = new Bonnie();
    static Chica chica = new Chica();
    static Foxy foxy = new Foxy();


//for the update section because I keep losing it
////////////////////////////////////////////////////////////////////////////////////// 
    static void UpdateLogic()
    {   
        if (utils.death != true && utils.victory != true)
        {
            //IMPORTANT DO NOT REMOVE// MAIN CLOCK FOR IN GAME TIME
            utils.setTime(miliseconds);
            bonnie.setAI(utils.currNight_AI[1]); // bonnie is #1
            chica.setAI(utils.currNight_AI[2]);
            foxy.setAI(utils.currNight_AI[3]);

            if (utils.currTime == 6)
            {
                utils.victory = true;
            }
            if (office.isCameraUP)
            {
                foxy.isCameraStalled = true;
                setDownStall = random.Next(83, 1748);

            }
            else
            {
                if (setDownStall > 0)
                {
                    setDownStall--;
                    foxy.isCameraStalled = true;
                }
                else{foxy.isCameraStalled = false;}
            }

            // for the love of everything just make sure to add the animatronic update functions
            //bonnie.updateMovement(seconds);
            //chica.updateMovement(seconds);
            foxy.updateMovement(seconds);

            office.setDoorDisplay();
            camera.updateAnimatronicPos("1A", bonnie.getCurrentPos(), chica.getCurrentPos(), foxy.getCurrentPos());
            camera.updateCameraData();

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
                if (toggleDev)
                {
                    Console.WriteLine($"Bonnie: {bonnie.getCurrentPos()}, AI:{bonnie.AI}, {bonnie.movementCheck}");
                    Console.WriteLine($"Chica: {chica.getCurrentPos()}, AI:{chica.AI}, {chica.movementCheck}"); 
                    Console.WriteLine($"Foxy: {foxy.getCurrentPos()}, AI:{foxy.AI}, {foxy.movementCheck}");                }
                

                
                office.displayOffice();

                if (office.isCameraUP)
                {
                    Console.WriteLine("\nCamera is up!");
                    camera.viewCamera(foxy.getStage());
                    setDownTimer = 100;
                    office.doorsEnabled = false;
                }
                else
                { 
                    office.doorsEnabled = true;
                    if (setDownTimer > 0)
                    {
                        setDownTimer--;
                        office.isCameraSetDown = true;
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

        Console.CursorVisible = false;

        // TODO set the next night when you win I guess
        utils.setCurrNight(currentNight);

        //bonnie.currentPOS = 5;
        //office.ChangeLeftDoor(1);


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
                        else if (office.isCameraUP)
                            {
                                if (camera.currentCamNum > 0){camera.currentCamNum -=1;}
                                else{camera.currentCamNum = 10;}
                                
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
                        else if (office.isCameraUP)
                            {
                                if (camera.currentCamNum < 10){camera.currentCamNum +=1;}
                                else{camera.currentCamNum = 0;}
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

                    if (key == ConsoleKey.L)
                    {
                        if(!toggleDev)
                        {
                            toggleDev = true;
                        }
                        else {toggleDev = false;}
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
            //does code stuff, add update funtions

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