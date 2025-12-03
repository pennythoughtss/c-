using FNAF;

namespace FNAF
{
    class Office()
    {
        public bool isDoorClosed_L = false;
        public bool isDoorClosed_R = false;
        public bool doorsEnabled = true;
        public bool doorDisabledMessage = false;

        public bool isCameraUP = false;
        public bool isCameraSetDown = false;

        public int power = 100;

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
            Program.utils.officeDisplay = @"
            ___               ___
            | | q   OFFICE  e | |
            | | a    ----   d | |";        }
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
            ___               ___
            | | q   OFFICE  e | |
            |_| a    ----   d | |";        }
        public void displayOfficeNormalRLight()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            | | q   OFFICE  e | |
            | | a    ----   d |_|";        }
        public void displayOfficeNormalLight()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            | | q   OFFICE  e | |
            |_| a    ----   d |_|";        }
        public void displayOfficeLCLOSEDLight()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            |\| q   OFFICE  e | |
            |\| a    ----   d |_|";        }
        public void displayOfficeRCLOSEDLight()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            | | q   OFFICE  e |\|
            |_| a    ----   d |\|";        }


        public void displayOfficeNormalLLightSPOOK()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            |v| q   OFFICE  e | |
            |_| a    ----   d | |";        }
        public void displayOfficeNormalRLightSPOOK()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            | | q   OFFICE  e |v|
            | | a    ----   d |_|";        }
        public void displayOfficeNormalLightSPOOKR()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            | | q   OFFICE  e |v|
            |_| a    ----   d |_|";        }
        public void displayOfficeNormalLightSPOOKL()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            |v| q   OFFICE  e | |
            |_| a    ----   d |_|";        }
        public void displayOfficeNormalLightSPOOK()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            |v| q   OFFICE  e |v|
            |_| a    ----   d |_|";        }
        public void displayOfficeLCLOSEDLightSPOOK()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            |\| q   OFFICE  e |v|
            |\| a    ----   d |_|";        }
        public void displayOfficeRCLOSEDLightSPOOK()
        {
            Program.utils.officeDisplay = @"
            ___               ___
            |v| q   OFFICE  e |\|
            |_| a    ----   d |\|";        }

        public void powerOut()
        {
            doorsEnabled = false;

        }
    }
}