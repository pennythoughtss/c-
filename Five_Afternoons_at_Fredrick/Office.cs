using System.Net;
using System.Runtime.CompilerServices;
using FNAF;

namespace FNAF
{
    class Office()
    {
        public bool isDoorClosed_L = false;
        public bool isDoorClosed_R = false;
        public bool isLightON_L = false;
        public bool isLightON_R = false;
        public bool doorsEnabled = true;
        public bool cameraEnabled = true;
        public bool doorDisabledMessage = false;
        public bool BonnieAtDoor = false;
        public bool ChicaAtDoor = false;

        public bool isCameraUP = false;
        public bool isCameraSetDown = false;
        public bool isPowerOut = false;

        public int power = 999;
        public int powerRounded = 100;
        public int powerUseage = 0;
        private int tempMil = 0;
        private int tick = 0;

        public void updatePower(int night)
        {
            tempMil ++;


            if(tempMil == 100)
            {
                //passive power drain
                if(night == 2 && tick == 6)
                {
                    power-= 1;
                    tick = 0;
                }
                if(night == 3 && tick == 5)
                {
                    power-= 1;
                    tick = 0;
                }
                if(night == 4 && tick == 4)
                {
                    power-= 1;
                    tick = 0;
                }
                if(night > 4 && tick == 3)
                {
                    power-= 1;
                    tick = 0;
                }

                tick ++;
                power -= powerUseage;
                powerRounded = power/10;
                tempMil = 0;

                
            }
            if(power <= 0)
            {
                powerOut();
            }
            
            
        }

// gotta do it manual cus it's stinking updating every stinking second
        public void setUseage()
        {
            if (isCameraUP)
            {
            if(isDoorClosed_L){
               if (isDoorClosed_R)
                {
                    if (isLightON_R)
                    {
                        if(isLightON_L){powerUseage=5;}
                        else{powerUseage=4;}
                    }
                    else{
                        if(isLightON_L){powerUseage=4;}
                        else{powerUseage=3;}
                    }
                }
                else
                {
                    if (isLightON_R)
                   {
                        if(isLightON_L){powerUseage=4;}
                        else{powerUseage=3;}
                    }
                    else
                    {
                        if(isLightON_L){powerUseage=3;}
                        else{powerUseage=2;} 
                    } 
                } 
            }
            else{
               if (isDoorClosed_R)
                {
                    if (isLightON_R)
                    {
                        if(isLightON_L){powerUseage=4;}
                        else{powerUseage=3;}
                    }
                    else{
                        if(isLightON_L){powerUseage=3;}
                        else{powerUseage=2;}
                    }
                }
                else
                {
                    if (isLightON_R)
                   {
                        if(isLightON_L){powerUseage=3;}
                        else{powerUseage=2;}
                    }
                    else
                    {
                        if(isLightON_L){powerUseage=2;}
                        else{powerUseage=1;} 
                    } 
                } 
            }
            } //
            else //
            {
            if(isDoorClosed_L){
               if (isDoorClosed_R)
                {
                    if (isLightON_R)
                    {
                        if(isLightON_L){powerUseage=4;}
                        else{powerUseage=3;}
                    }
                    else{
                        if(isLightON_L){powerUseage=3;}
                        else{powerUseage=2;}
                    }
                }
                else
                {
                    if (isLightON_R)
                   {
                        if(isLightON_L){powerUseage=3;}
                        else{powerUseage=2;}
                    }
                    else
                    {
                        if(isLightON_L){powerUseage=2;}
                        else{powerUseage=1;} 
                    } 
                } 
            }
            else{
               if (isDoorClosed_R)
                {
                    if (isLightON_R)
                    {
                        if(isLightON_L){powerUseage=3;}
                        else{powerUseage=2;}
                    }
                    else{
                        if(isLightON_L){powerUseage=2;}
                        else{powerUseage=1;}
                    }
                }
                else
                {
                    if (isLightON_R)
                   {
                        if(isLightON_L){powerUseage=2;}
                        else{powerUseage=1;}
                    }
                    else
                    {
                        if(isLightON_L){powerUseage=1;}
                        else{powerUseage=0;} 
                    } 
                } 
            }
            }
            
            

            
        }
        public void resetPower()
        {
            power = 999;
        }

        public void ChangeLeftDoor(int status) //0 for open, 1 for closed
        {

            switch (status)
            {
                case 0:
                isDoorClosed_L = false;
                break;
                case 1:
                isDoorClosed_L = true;
                break;
            }

        }

        public void ChangeRightDoor(int status)
        {
            switch (status)
            {
                case 0:
                isDoorClosed_R = false;
                break;
                case 1:
                isDoorClosed_R = true;
                break;
            }

        }

// theres probably a better way to do this but I'm too tired to figure it out right now
// I will actually cry if I messed up somewhere in the setDoorDisplay
        public void setDoorDisplay()
        {
            if (isDoorClosed_L && !isDoorClosed_R)
            {
                if (isLightON_R && !isLightON_L)
                {
                    if(ChicaAtDoor){displayOfficeLCLOSEDLightSPOOK();}
                    else{displayOfficeLCLOSEDRLight();}
                }
                else if (isLightON_L && !isLightON_R)
                {
                    if(BonnieAtDoor){displayOfficeLCLOSEDLLightSPOOK();}
                    else{displayOfficeLCLOSEDLLight();}
                }
                else if(isLightON_L && isLightON_R)
                {
                    if(BonnieAtDoor && !ChicaAtDoor){displayOfficeLCLOSEDBLightLSPOOK();}
                    else if(ChicaAtDoor && !BonnieAtDoor){displayOfficeLCLOSEDBLightRSPOOK();}
                    else if (ChicaAtDoor && BonnieAtDoor){displayOfficeLCLOSEDBLightBSPOOK();}
                    else{displayOfficeLCLOSEDBLight();}
                }
                else
                {
                    displayOfficeLCLOSED();
                }
                
            }
            else if (isDoorClosed_R && !isDoorClosed_L)
            {
                if (isLightON_R && !isLightON_L)
                {
                    if(ChicaAtDoor){displayOfficeRCLOSEDRLightSPOOK();}
                    else{displayOfficeRCLOSEDRLight();}
                }
                else if (isLightON_L && !isLightON_R)
                {
                    if(BonnieAtDoor){displayOfficeRCLOSEDLightSPOOK();}
                    else{displayOfficeRCLOSEDLLight();}
                }
                else if(isLightON_L && isLightON_R)
                {
                    if(BonnieAtDoor && !ChicaAtDoor){displayOfficeRCLOSEDBLightLSPOOK();}
                    else if(ChicaAtDoor && !BonnieAtDoor){displayOfficeRCLOSEDBLightRSPOOK();}
                    else if (ChicaAtDoor && BonnieAtDoor){displayOfficeRCLOSEDBLightBSPOOK();}
                    else{displayOfficeRCLOSEDBLight();}
                }
                else
                {
                    displayOfficeRCLOSED();
                }
                
            }
            else if (isDoorClosed_L && isDoorClosed_R)
            {
                if (isLightON_R && !isLightON_L)
                {
                    if(ChicaAtDoor){displayOfficeCLOSEDRLightSPOOK();}
                    else{displayOfficeCLOSEDRLight();}
                }
                else if (isLightON_L && !isLightON_R)
                {
                    if(BonnieAtDoor){displayOfficeCLOSEDLLightSPOOK();}
                    else{displayOfficeCLOSEDLLight();}
                }
                else if(isLightON_L && isLightON_R)
                {
                    if(BonnieAtDoor && !ChicaAtDoor){displayOfficeCLOSEDBLightLSPOOK();}
                    else if(ChicaAtDoor && !BonnieAtDoor){displayOfficeCLOSEDBLightRSPOOK();}
                    else if (ChicaAtDoor && BonnieAtDoor){displayOfficeCLOSEDBLightBSPOOK();}
                    else{displayOfficeCLOSEDBLight();}
                }
                else
                {
                    displayOfficeCLOSED();
                }
                
            }
            else
            {
                if (isLightON_L && !isLightON_R)
                {
                    if(BonnieAtDoor){displayOfficeNormalLLightSPOOK();}
                    else{displayOfficeNormalLLight();}
                    
                }
                else if (isLightON_R && !isLightON_L)
                {
                    if(ChicaAtDoor){displayOfficeNormalRLightSPOOK();}
                    else{displayOfficeNormalRLight();}
                }
                else if (isLightON_R && isLightON_L)
                {
                    if(ChicaAtDoor && !BonnieAtDoor){displayOfficeNormalLightSPOOKR();}
                    else if(BonnieAtDoor && !ChicaAtDoor){displayOfficeNormalLightSPOOKL();}
                    else if(ChicaAtDoor && BonnieAtDoor){displayOfficeNormalLightSPOOK();}
                    else{displayOfficeNormalLight();}
                }
                else
                {
                    displayOfficeNormal();
                }
            }
            
        }

        public void disableDoors()
        {
            doorsEnabled = false;
            doorDisabledMessage = true;
        }

        public void displayOffice()
        {
            Console.WriteLine(Program.utils.officeDisplay);
        }

        public void displayOfficeNormal()
        {
            if (!isPowerOut)
            {
                Console.ResetColor();
                Program.utils.officeDisplay = @"
            ___               ___
            | | q   OFFICE  e | |
            | | a    ----   d | |";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if (Program.utils.isFreddyAtDoor)
                {
                   Program.utils.officeDisplay = @"
            ___               ___
            |v| q   OFFICE  e | |
            | | a    ----   d | |";
            } 
                
                else
            {
                Program.utils.officeDisplay = @"
            ___               ___
            | | q   OFFICE  e | |
            | | a    ----   d | |";
            }
            }
                
                    }
        public void displayOfficeLCLOSED()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___
            |\| q   OFFICE  e | |
            |\| a    ----   d | |";        }
        public void displayOfficeRCLOSED()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___
            | | q   OFFICE  e |\|
            | | a    ----   d |\|";        }
        public void displayOfficeCLOSED()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___
            |\| q   OFFICE  e |\|
            |\| a    ----   d |\|";        }

        public void displayOfficeNormalLLight()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___
         _| | | q   OFFICE  e | |
            |_| a    ----   d | |";        }
        public void displayOfficeNormalRLight()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___  _
            | | q   OFFICE  e | | |_
            | | a    ----   d |_|";        }
        public void displayOfficeNormalLight()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| | | q   OFFICE  e | | |_
            |_| a    ----   d |_|";        }
        public void displayOfficeLCLOSEDRLight()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___  _
            |\| q   OFFICE  e | | |_
            |\| a    ----   d |_|";        }
        public void displayOfficeRCLOSEDLLight()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___
         _| | | q   OFFICE  e |\|
            |_| a    ----   d |\|";        }

////////////////////////////
        public void displayOfficeLCLOSEDLLight()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  
         _| |\| q   OFFICE  e | | 
            |\| a    ----   d | |";        }
        public void displayOfficeRCLOSEDRLight()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___  _
            | | q   OFFICE  e |\| |_
            | | a    ----   d |\|";        }

        public void displayOfficeLCLOSEDBLight()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| |\| q   OFFICE  e | | |_
            |\| a    ----   d |_|";        }
        public void displayOfficeRCLOSEDBLight()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| | | q   OFFICE  e |\| |_
            |_| a    ----   d |\|";        }

        public void displayOfficeCLOSEDRLight()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___  _
            |\| q   OFFICE  e |\| |_
            |\| a    ----   d |\|";        }
        public void displayOfficeCLOSEDLLight()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  
         _| |\| q   OFFICE  e |\| 
            |\| a    ----   d |\|";        }

        public void displayOfficeCLOSEDBLight()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| |\| q   OFFICE  e |\| |_
            |\| a    ----   d |\|";        }

        
/////////////////////////


        public void displayOfficeNormalLLightSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___
         _| |v| q   OFFICE  e | | 
            |_| a    ----   d | |";        }
        public void displayOfficeNormalRLightSPOOK()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___  _
            | | q   OFFICE  e |v| |_
            | | a    ----   d |_|";        }
        public void displayOfficeNormalLightSPOOKR()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| | | q   OFFICE  e |v| |_
            |_| a    ----   d |_|";        }
        public void displayOfficeNormalLightSPOOKL()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| |v| q   OFFICE  e | | |_
            |_| a    ----   d |_|";        }
        public void displayOfficeNormalLightSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| |v| q   OFFICE  e |v| |_
            |_| a    ----   d |_|";        }
        public void displayOfficeLCLOSEDLightSPOOK()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___  _
            |\| q   OFFICE  e |v| |_
            |\| a    ----   d |_|";        }
        public void displayOfficeRCLOSEDLightSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  
         _| |v| q   OFFICE  e |\| 
            |_| a    ----   d |\|";        }

///////////////////////////////////

        public void displayOfficeLCLOSEDLLightSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  
         V| |\| q   OFFICE  e | | 
            |\| a    ----   d | |";        }
        public void displayOfficeRCLOSEDRLightSPOOK()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___  _
            | | q   OFFICE  e |\| |V
            | | a    ----   d |\|";        }

        public void displayOfficeLCLOSEDBLightLSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         V| |\| q   OFFICE  e | | |_
            |\| a    ----   d |_|";        }

        public void displayOfficeLCLOSEDBLightRSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| |\| q   OFFICE  e |v| |_
            |\| a    ----   d |_|";        }
        public void displayOfficeLCLOSEDBLightBSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         V| |\| q   OFFICE  e |v| |_
            |\| a    ----   d |_|";        }
        public void displayOfficeRCLOSEDBLightLSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| |v| q   OFFICE  e |\| |_
            |_| a    ----   d |\|";        }
        public void displayOfficeRCLOSEDBLightRSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| | | q   OFFICE  e |\| |V
            |_| a    ----   d |\|";        }
        public void displayOfficeRCLOSEDBLightBSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| |v| q   OFFICE  e |\| |V
            |_| a    ----   d |\|";        }

        public void displayOfficeCLOSEDRLightSPOOK()
        {
            
            Program.utils.officeDisplay = @"
            ___               ___  _
            |\| q   OFFICE  e |\| |V
            |\| a    ----   d |\|";        }
        public void displayOfficeCLOSEDLLightSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  
         V| |\| q   OFFICE  e |\| 
            |\| a    ----   d |\|";        }

        public void displayOfficeCLOSEDBLightLSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         V| |\| q   OFFICE  e |\| |_
            |\| a    ----   d |\|";        }
        public void displayOfficeCLOSEDBLightRSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         _| |\| q   OFFICE  e |\| |V
            |\| a    ----   d |\|";        }
        public void displayOfficeCLOSEDBLightBSPOOK()
        {
            
            Program.utils.officeDisplay = @"
         _  ___               ___  _
         V| |\| q   OFFICE  e |\| |V
            |\| a    ----   d |\|";        }

///////////////////////////////////////
        public void powerOut()
        {
            doorsEnabled = false;
            cameraEnabled = false;
            isDoorClosed_L = false;
            isDoorClosed_R = false;
            isLightON_L = false;
            isLightON_R = false;
            isCameraUP = false;
            isPowerOut = true;

        }
    }
}