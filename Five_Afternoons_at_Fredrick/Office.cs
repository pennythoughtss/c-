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

        public void ChangeLeftDoor(int status) //0 for open, 1 for closed
        {
            if (doorsEnabled)
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
            else
            {
                doorDisabledMessage = true;
            }
        }

        public void ChangeRightDoor(int status)
        {
            if (doorsEnabled)
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
            else
            {
                doorDisabledMessage = true;
            }
        }
    }
}