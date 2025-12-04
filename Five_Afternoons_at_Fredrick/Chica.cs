
using FNAF;

// setAI after in game clock un update
// put updateMovement in update


namespace FNAF
{
    class Chica : Animatronic
    {
        static Utils utils = Program.utils;
        Random random = new Random();
        protected override string name => "Chica";
        private double interval = utils.chica_interval;
        public List<string> path = ["1A", "1B", "7", "6", "4A", "4B", "Doorway_R", "Inside_Office"];
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
            //fix path for chica if it seems wrong
            List<int> choice = [];
            int rand = 0;
            switch (currentPOS)
            {
                case 0:
                return 1;
                case 1:
                    choice = [2,3,4];
                    rand = random.Next(0,3);
                return choice[rand];
                case 2:
                    choice = [3,4];
                    rand = random.Next(0,2);
                return choice[rand];
                case 3:
                    choice = [4,2];
                    rand = random.Next(0,2);
                return choice[rand];
                case 4:
                    choice = [1,5];
                    rand = random.Next(0,2);
                return choice[rand];
                case 5:
                    choice = [4,6];
                    rand = random.Next(0,2);
                return choice[rand];
                case 6:
                if (Program.office.isDoorClosed_R != true)
                {
                    return 7;
                }
                else{choice = [1,4];
                    rand = random.Next(0,2);
                    return choice[rand];}
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
                Program.office.ChicaAtDoor = true;
            }
            else
            {
                Program.office.ChicaAtDoor = false;
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