
using FNAF;

// setAI after in game clock un update
// put updateMovement in update

namespace FNAF
{
    class Freddy : Animatronic
    {
        static Utils utils = Program.utils;
        Random random = new Random();
        protected override string name => "Freddy";
        private double interval = utils.freddy_interval;
        public List<string> path = ["1A", "1B", "7", "6", "4A","4B","office", "power_out"];
        public bool isPhase2 = false;


        public bool isCameraStalled = false;
        public int AI = 0;
        public int currentPOS = 0;
        public int tempMil = 0;
        private int tick = 0;
        public int movementCheck = 0;
        public bool canAttack = false;


        public override void attack()
        {
            base.attack();
        }

        public override int nextPOS()
        {
            List<int> choice = [];
            switch (currentPOS)
            {
                case 0:
                return 1;
                case 1:
                return 2;
                case 2:
                return 3;
                case 3:
                return 4;
                case 4:
                return 5;
                case 5:
                if (Program.office.isDoorClosed_R != true)
                {
                    return 6;
                }
                else{return 4;}
                case 6:
                break;
                  
            }
            return 0;
        }


        public override void updateMovement(double second)
        {
            tempMil += 1;


            
            if (currentPOS <= 5)
            {
               if (tempMil == interval*100)
                {
                    movementCheck = random.Next(1,21);
                    if (movementCheck <= AI && !isCameraStalled)
                    {
                        currentPOS = nextPOS();
                    }
                    tempMil = 0;
                } 
            }
            if (currentPOS == 5)
            {
                isPhase2 = true;
                if (tempMil == interval*100)
                {
                    movementCheck = random.Next(1,21);
                    if (movementCheck <= AI && !isCameraStalled)
                    {
                        currentPOS = nextPOS();
                    }
                    tempMil = 0;
                } 
            }
            else
            {
                isPhase2 = false;
            }
            if (currentPOS == 6)
            {
                Program.office.disableDoors();
                    if (tempMil == interval*100)
                {
                    movementCheck = random.Next(0,4); //has a 1 in 4 chance of attacking every second
                    if (movementCheck <= 1)
                    {
                        attack();
                    }
                    tempMil = 0;
                } 
                
            }
            if(currentPOS == 7)
            {
                if (tempMil == interval*100)
                {
                    tick++;
                    if (tick >= 2)
                    {
                        Program.utils.isFreddyAtDoor = true;
                    }
                    if (tick >= 4) // after 4 seconds
                    {
                        canAttack = true;
                        movementCheck = random.Next(0,4); //has a 1 in 4 chance of attacking every second
                    if (movementCheck <= 1)
                    {
                        attack();
                    }
                    
                    }
                    tempMil = 0;
                    
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