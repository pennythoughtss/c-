
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FNAF
{
    // random assortment of data and stuff that I need to keep track of
    // keeps track of the data for the current night
    class Utils
    {
        private int currentNight = 1;
        private int timeTickSpeed = 60; // how long (in seconds) is each hour (60 default)

        // freddy, bonnie, chica, foxy
        private List<int> night1_AI = [0,0,0,0];
        private List<int> night2_AI = [0,3,1,1];
        private List<int> night3_AI = [1,0,5,2];
        private List<int> night4_AI = [1,2,4,6];
        private List<int> night5_AI = [3,5,7,5];
        private List<int> night6_AI = [4,10,12,16];
        private List<int> custom_AI = [20,20,20,20];

        public List<int> currNight_AI = [];

        public bool isFirstNight = true;

        // movement intervals (in seconds)
        public double freddy_interval = 3.02;
        public double bonnie_interval = 4.97;
        public double chica_interval = 4.99; //chica's interval is supposed to be 4.98 but she doesn't like it for some reason
        public double foxy_interval = 5.01; 

        public List<int> time = [12,1,2,3,4,5,6];
        public int currTime = 0;

        public bool death = false;
        public bool victory = false;

        public string whoKilledYou = "";

        public string doorDisabledMessage = "Doors disabled";
        public string officeDisplay = "";


        // sets the current night and current AI for that night
        public void setCurrNight(int night)
        {
            currentNight = night;

            switch (night)
            {
                case 1:
                currNight_AI = night1_AI;
                break;
                case 2:
                currNight_AI = night2_AI;
                break;
                case 3:
                currNight_AI = night3_AI;
                break;
                case 4:
                currNight_AI = night4_AI;
                break;
                case 5:
                currNight_AI = night5_AI;
                break;
                case 6:
                currNight_AI = night6_AI;
                break;
                case 20:
                currNight_AI = custom_AI;
                break;
            }

            if (currentNight != 1)
            {
                isFirstNight = false;
            }
        }
        public static void ClearCurrentConsoleLine()
    {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
    }

        public void setTime(double seconds)
        {
            if (seconds == 100 * timeTickSpeed)
            {
                currTime = 1;
            }
            if (seconds == 200 * timeTickSpeed)
            {
                currTime = 2;
                set_2AM();
            }
            if (seconds == 300 * timeTickSpeed)
            {
                currTime = 3;
                set_3AM();
            }
            if (seconds == 400 * timeTickSpeed)
            {
                currTime = 4;
                set_4AM();
            }
            if (seconds == 500 * timeTickSpeed)
            {
                currTime = 5;
            }
            if (seconds == 600 * timeTickSpeed)
            {
                currTime = 6;
            }
            
        }
        public void set_2AM()
        {
            if (currNight_AI[1] == 20)
            {
                currNight_AI[1] = 20;
            }
            else
            {
               currNight_AI[1] += 1; 
            }
        }

        public void set_3AM()
        {
            if (currNight_AI[1] == 20)
            {
                currNight_AI[1] = 20;
            }
            else
            {
               currNight_AI[1] += 1; 
            }
            if (currNight_AI[2] == 20)
            {
                currNight_AI[2] = 20;
            }
            else
            {
               currNight_AI[2] += 1; 
            }
            if (currNight_AI[3] == 20)
            {
                currNight_AI[3] = 20;
            }
            else
            {
               currNight_AI[3] += 1; 
            }
        }
        public void set_4AM()
        {
            if (currNight_AI[1] == 20)
            {
                currNight_AI[1] = 20;
            }
            else
            {
               currNight_AI[1] += 1; 
            }
            if (currNight_AI[2] == 20)
            {
                currNight_AI[2] = 20;
            }
            else
            {
               currNight_AI[2] += 1; 
            }
            if (currNight_AI[3] == 20)
            {
                currNight_AI[3] = 20;
            }
            else
            {
               currNight_AI[3] += 1; 
            }
        }

    }
    
    
}