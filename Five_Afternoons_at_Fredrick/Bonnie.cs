
using FNAF;

// setAI after in game clock un update
// put updateMovement in update


namespace FNAF
{
    class Bonnie : Animatronic
    {
        static Utils utils = Program.utils;
        Random random = new Random();
        protected override string name => "Bonnie";
        private double interval = utils.bonnie_interval;
        public List<string> path = ["1A", "1B", "5", "2A", "3", "2B", "Doorway_L", "Inside_Office"];
        public int AI = 0;
        public int currentPOS = 0;
        public int tempMil = 0;
        public int movementCheck = 0;
        

        public override void attack()
        {
            base.attack();
        }

        public override int nextPOS()
        {
            List<int> choice = [];
            int rand = 0;
            switch (currentPOS)
            {
                case 0:
                    choice = [1,2];
                    rand = random.Next(0,2);
                return choice[rand];
                case 1:
                    choice = [2,3];
                    rand = random.Next(0,2);
                return choice[rand];
                case 2:
                    choice = [1,3];
                    rand = random.Next(0,2);
                return choice[rand];
                case 3:
                    choice = [4,5];
                    rand = random.Next(0,2);
                return choice[rand];
                case 4:
                    choice = [3,6];
                    rand = random.Next(0,2);
                return choice[rand];
                case 5:
                    choice = [4,6];
                    rand = random.Next(0,2);
                return choice[rand];
                case 6:
                if (Program.office.isDoorClosed_L != true)
                {
                    return 7;
                }
                else{return 1;}
                case 7:
                    // in the office ready to attack when camera is set down
                    Program.office.disableDoors();

                break;
                
                
            }
            return 0;
        }

        public override void updateMovement(double second)
        {
            tempMil += 1;
            if (currentPOS == 6)
            {
                Program.office.BonnieAtDoor = true;
            }
            else
            {
                Program.office.BonnieAtDoor = false;
            }

            //if not in the office
            if (currentPOS != 7)
            {
               if (tempMil == interval*100)
                {
                    movementCheck = random.Next(1,21);
                    if (movementCheck <= AI)
                    {
                        currentPOS = nextPOS();
                    }
                    tempMil = 0;
                } 
            }
            //if in the office, waiting for camera to be set down
            else
            {
                Program.office.disableDoors();
                if (Program.office.isCameraSetDown)
                {
                    attack();
                }
            }
            
        }

        public override void setAI(int AI_Level)
        {
            AI = AI_Level;
        }

        public override string getCurrentPos()
        {
            return path[currentPOS];
        }
    }
}