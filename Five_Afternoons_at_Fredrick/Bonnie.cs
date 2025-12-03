
using FNAF;


// put updateMovement in update
// setAI after setCurrNight and after each set_2AM, set_3AM, set_4AM

namespace FNAF
{
    class Bonnie() : Animatronic
    {
        static Utils utils = new Utils();
        Random random = new Random();
        protected override string name => "Bonnie";
        protected override double interval => utils.bonnie_interval;
        protected override bool isCameraStalled => false;
        public List<string> path = ["1A", "1B", "5", "2A", "3", "2B", "Doorway_L"];
        public int AI = 0;
        public int currentPOS = 0;
        public int tempMil = 0;
        public int movementCheck = 0;
        

        public override void attack()
        {
            // if sucessful on check disable door
            // attack when camera is next put down
            // TODO update when you have office built
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
                    attack();
                return 1;
                
            }
            return 0;
        }

        public override void updateMovement(double second)
        {
            tempMil += 1;

            if (tempMil == interval*100)
            {
                movementCheck = random.Next(0,21);
                if (movementCheck <= AI)
                {
                    currentPOS = nextPOS();
                }
                tempMil = 0;
            }
        }

        public override void setAI(int AI_Level)
        {
            AI = AI_Level;
        }
    }
}