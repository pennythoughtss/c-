using System;
using System.Collections;
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

    static int currentNight = 1; //////////// change current night
    static bool quit = true;
    static bool game = true;
    static bool playedAnim = false;
    static int menuTimer = 300;
    static bool exitingTheGame = false;
    static bool randomStat =false;

    static int menuSelect = 1;
    static bool options = false;
    static bool options2 = false;
    static int optionsSelect = 1;
    //current night display when you start the night
    static bool hasDisplayedNight = false;

    public static Utils utils = new Utils();
    public static Office office = new Office();
    public static Animation animation = new Animation();
    public static SecurityCamera camera = new SecurityCamera();
    static Random random = new Random();

    //make sure to initalize the animatronics
    static Bonnie bonnie = new Bonnie();
    static Chica chica = new Chica();
    static Foxy foxy = new Foxy();
    static Freddy freddy = new Freddy();

    static void resetLogic()
    {
        tick = 0;
        dt_current = 1;
        dt_last = 0;
        toggleDev = false;
        seconds = 0;
        miliseconds = 0;
        setDownTimer = 0;
        setDownStall = 0;
        playedAnim = false;
        menuTimer = 300;
        exitingTheGame = false;
        randomStat =false;

        menuSelect = 1;
        freddy.canAttack = false;

        freddy.currentPOS = 0;
        bonnie.currentPOS = 0;
        chica.currentPOS = 0;
        foxy.currentPOS = 0;

        options = false;
        options2 = false;
        optionsSelect = 1;

        hasDisplayedNight = false;
    
    }



//for the update section because I keep losing it
////////////////////////////////////////////////////////////////////////////////////// 
    static void UpdateLogic()
    {   
        if (utils.death != true && utils.victory != true && !exitingTheGame)
        {
            //IMPORTANT DO NOT REMOVE// MAIN CLOCK FOR IN GAME TIME
            utils.setTime(miliseconds);
            bonnie.setAI(utils.currNight_AI[1]); // bonnie is #1
            chica.setAI(utils.currNight_AI[2]);
            foxy.setAI(utils.currNight_AI[3]);
            freddy.setAI(utils.currNight_AI[0]);

            if (utils.currTime == 6)
            {
                utils.victory = true;
            }
            if (office.isCameraUP)
            {
                foxy.isCameraStalled = true;
                setDownStall = random.Next(83, 1748);
                if (freddy.AI < 10 && !freddy.isPhase2)
                {
                    freddy.isCameraStalled = true;
                }
                else if(camera.currentCamera == freddy.path[freddy.currentPOS] && freddy.isPhase2)
                {
                    freddy.isCameraStalled = true;
                }
                else{freddy.isCameraStalled = false;}

            }
            else
            {
                if (setDownStall > 0)
                {
                    setDownStall--;
                    foxy.isCameraStalled = true;
                }
                else{foxy.isCameraStalled = false;}
                freddy.isCameraStalled = false;
            }

            // for the love of everything just make sure to add the animatronic update functions
            if (!office.isPowerOut)
            {
                bonnie.updateMovement(seconds);
                chica.updateMovement(seconds);
                foxy.updateMovement(seconds);
            }
            else
            {
                bonnie.currentPOS = 0;
                chica.currentPOS = 0;
                foxy.currentPOS = 0;
                freddy.currentPOS = 7;
            }
            
            freddy.updateMovement(seconds);

            office.setDoorDisplay();
            camera.updateAnimatronicPos(freddy.getCurrentPos(), bonnie.getCurrentPos(), chica.getCurrentPos(), foxy.getCurrentPos());
            camera.updateCameraData();
            office.setUseage();
            office.updatePower(currentNight);


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

    if (utils.death != true && utils.victory != true && !exitingTheGame && hasDisplayedNight)
        {
        if (dt_current > dt_last)
            {
                //temporary animatronic position display
                Console.Clear();
                Console.WriteLine($"Power: {office.powerRounded}%, Useage: {office.powerUseage}, {utils.time[utils.currTime]}:00 , Current Night: {currentNight}");
                if (toggleDev)
                {
                    Console.WriteLine(miliseconds);
                    Console.WriteLine($"Bonnie: {bonnie.getCurrentPos()}, AI:{bonnie.AI}, {bonnie.movementCheck}");
                    Console.WriteLine($"Chica: {chica.getCurrentPos()}, AI:{chica.AI}, {chica.movementCheck}"); 
                    Console.WriteLine($"Foxy: {foxy.getCurrentPos()}, AI:{foxy.AI}, {foxy.movementCheck}, isCameraStalled = {foxy.isCameraStalled}");
                    Console.WriteLine($"Freddy: {freddy.getCurrentPos()}, AI:{freddy.AI}, {freddy.movementCheck}, isCameraStalled = {freddy.isCameraStalled}, canAttack = {freddy.canAttack}");
                }
                

                
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
                    if(office.cameraEnabled){office.doorsEnabled = true;}
                    
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
                    else{Console.ResetColor();quit=true;}
                }
            }
        }
        else if (utils.victory == true)
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
                    else
                    {
                        Console.ResetColor();
                        if (currentNight < 6)
                        {
                            resetLogic();
                            office.resetOffice();
                            utils.resetUtil();
                            currentNight++;
                            utils.setCurrNight(currentNight);
                        }
                        else{quit=true;}
                        
                    }
                }
            }
        }

        else if (exitingTheGame == true)
        {

            if (dt_current > dt_last)
            {
                if (menuTimer > 250)
                {
                menuTimer--;
                Console.Clear();
                Console.WriteLine("exiting the game...");
                dt_last = dt_current;
                }
                else if (menuTimer > 230)
                {
                    menuTimer--;
                    Console.Clear();
                    dt_last = dt_current;
                }
                else{Console.Clear();quit=true;}
            }
        }
        else if (!hasDisplayedNight)
        {
            Console.Clear();
            Console.WriteLine();
            animation.CurrentNightDisplay(currentNight);
            hasDisplayedNight = true;
            Console.Clear();
        }
    }
    
////////////////////////////////////////////////////////////////////////////////////

    
    static void Main()
    {
        //init until the main loop
        Console.WriteLine("\n");

        Console.CursorVisible = false;

        // TODO set the next night when you win I guess
        
        //office.powerOut();

        //bonnie.currentPOS = 5;
        //office.ChangeLeftDoor(1);


//event listeners for key control stuff
        Task.Factory.StartNew(() =>
            {
                while (game)
                {
                    
                if (!quit)
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.C)
                    {
                        if (office.cameraEnabled)
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
                        exitingTheGame = true;
                    }
                    

                }
                    else
                    {
                        randomStat=false;
                    }
                }
                
                
            });

////////////////// MAIN LOOP////////////////////////////////////////////////////////////
        while (game)
        {
            //main menu
            if (quit)
            {
                if (!options)
                {
                    Console.Clear();
                    exitingTheGame = false;
                    utils.displayMenu(menuSelect, currentNight);
                    ConsoleKey thisKey = Console.ReadKey().Key;
                    if (thisKey == ConsoleKey.Enter)
                    {
                        switch (menuSelect)
                        {
                            case 1:
                                {
                                    quit=false;
                                    resetLogic();
                                    office.resetOffice();
                                    utils.resetUtil();
                                    utils.setCurrNight(currentNight);

                                    break;
                                }
                            case 2: {options=true;break;}
                            case 3: {game=false;break;}
                        }
                    
                    }
                    if (thisKey == ConsoleKey.S || thisKey == ConsoleKey.DownArrow)
                    {
                        if (menuSelect < 3){menuSelect++;}
                        else{menuSelect = 1;}
                    }
                    if (thisKey == ConsoleKey.W || thisKey == ConsoleKey.UpArrow)
                    {
                        if (menuSelect > 1){menuSelect--;}
                        else{menuSelect = 3;}
                    }
                    if (thisKey == ConsoleKey.Escape)
                    {
                        game = false;
                    }
                }
                else if (options && !options2)
                {
                    Console.Clear();
                    exitingTheGame = false;
                    utils.displayOptionsMenu(optionsSelect);
                    ConsoleKey thisKey = Console.ReadKey().Key;
                        if (thisKey == ConsoleKey.Escape){options=false;}
                        if (thisKey == ConsoleKey.S || thisKey == ConsoleKey.DownArrow)
                        {
                            if (optionsSelect < 2 && optionsSelect !=5){optionsSelect++;}
                            else{optionsSelect = 1;}
                        }
                        if (thisKey == ConsoleKey.W || thisKey == ConsoleKey.UpArrow)
                        {
                            if (optionsSelect > 1 ){optionsSelect--;}
                            else{optionsSelect = 2;}
                        }
                        if (thisKey == ConsoleKey.Enter)
                        {
                            switch (optionsSelect)
                            {
                                case 1:
                                {
                                    options2 = true;
                                    break;
                                }
                                case 2: {options=false;break;}
                        }
                    }
                    
                }
                    else if (options2)
                    {
                        Console.Clear();
                        exitingTheGame = false;
                        utils.displayOptionsMenu2(currentNight);
                        ConsoleKey thisKey = Console.ReadKey().Key;
                        if (thisKey == ConsoleKey.Enter || thisKey == ConsoleKey.Escape)
                        {
                            options2 = false;
                        }
                        if (thisKey == ConsoleKey.W || thisKey == ConsoleKey.UpArrow)
                        {
                            if(currentNight < 6){currentNight++;}
                            else if (currentNight == 6){currentNight=20;}
                            else{currentNight=1;}
                        }
                        if (thisKey == ConsoleKey.S || thisKey == ConsoleKey.DownArrow)
                        {
                            if(currentNight > 1){currentNight--;}
                            else if (currentNight == 1){currentNight=20;}
                            else{currentNight=6;}
                        }
                    }
                    Thread.Sleep(1);
                }
                
            
            else if (!quit)
            {
                //does code stuff, add update funtions
                UpdateLogic();
                UpdateVisual();
                Thread.Sleep(1);
            }
        }
        
        
        
        
        Console.WriteLine("End game");
        Thread.Sleep(1000);
    }
    

}