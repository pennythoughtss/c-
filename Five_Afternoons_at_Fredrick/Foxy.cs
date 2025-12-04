
using FNAF;

// setAI after in game clock un update
// put updateMovement in update


namespace FNAF
{
    class Foxy : Animatronic
    {
        static Utils utils = Program.utils;
        Random random = new Random();
        protected override string name => "Foxy";
        private double interval = utils.foxy_interval;
        public List<string> path = ["1C", "1C", "1C", "2A", "office"];
        public List<string> stages = ["Foxy_stage1", "Foxy_stage2", "Foxy_stage3","Foxy_Running", "office"];


        public bool isCameraStalled = false;
        public int AI = 0;
        public int currentPOS = 0;
        public int tempMil = 0;
        private int tempMil2 = 0;
        public int movementCheck = 0;

        private bool triggerRun = false;
        
        public string getStage()
        {
            return stages[currentPOS];
        }

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
                break;
                  
            }
            return 0;
        }

        public override void updateMovement(double second)
        {
            tempMil += 1;


            
            if (currentPOS != 3) // in pirate cove
            {
               if (tempMil == interval*100)
                {
                    movementCheck = random.Next(1,21);
                    if (movementCheck <= AI && !isCameraStalled) //has a random cooldown interval after camera set down
                    {
                        currentPOS = nextPOS();
                    }
                    tempMil = 0;
                } 
            }
            if (currentPOS == 3) //running
            {
                //wait 25s then run, if 2A is checked then run immediately
                //you have until his next movement oppertunity to react
                if ((tempMil == 2500 || Program.camera.currentCamera == "2A") && !triggerRun)
                {
                    triggerRun = true;
                }
                else if (triggerRun)
                {
                    tempMil2 ++;

                    if (tempMil2 == interval*100)
                    {
                        currentPOS=nextPOS();
                    }
                }
            }
            if (currentPOS == 4) //potential attack
            {
                if (Program.office.isDoorClosed_L)
                {
                    currentPOS=0;
                }
                else
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