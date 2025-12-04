using FNAF;

namespace FNAF{
    
    class SecurityCamera()
    {
        public List<string> camList = ["1A", "1B", "5", "1C", "3", "2A", "2B", "4A", "4B",
        "6", "7"];
        public List<string> camNameList = ["Show Stage", "Dining Area", "Backstage",
        "Pirate Cove", "Supply Closet", "West Hall", "W. Hall Corner", "East Hall",
        "E. Hall Corner", "Kitchen (Disabled, Audio only)", "Restrooms"];

        public List<string> AnimatronicPos = ["1A","1A","1A","1C"];
        private List<int> AnimatronicOnCamera = [0,0,0,0];

        private string currentCamera = "1A";
        public int currentCamNum = 0;
        private int dt1 = 1;
        private int dt2 = 0;

        public void viewCamera()
        {
            Console.WriteLine($"{currentCamera} : {camNameList[currentCamNum]}");

            if (currentCamera == "6")
            {
                Console.WriteLine($"is Animatronic on camera? {Program.animation.AudioOnly()}");
            }
            else
            {
            Console.WriteLine($"is Animatronic on camera? [{YesNo(AnimatronicOnCamera[0])}, {YesNo(AnimatronicOnCamera[1])}, {YesNo(AnimatronicOnCamera[2])}, {YesNo(AnimatronicOnCamera[3])}]");
            }
            
        }

        private string YesNo(int status)
        {
            switch(status){
                case 0:
                    return "No";
                case 1:
                    return "Yes";
                default:
                    return "No";
            }
        }

        public void updateAnimatronicPos(string freddyPos, string bonniePos, string chicaPos, string foxyPos)
        {
            AnimatronicPos[0] = freddyPos;
            AnimatronicPos[1] = bonniePos;
            AnimatronicPos[2] = chicaPos;
            AnimatronicPos[3] = foxyPos;
        }

        public void updateCameraData()
        {
            //sets the currentCam to currentCamNum on the camList
            currentCamera = camList[currentCamNum];

            //checks if animatronics are on camera and sets stuff accordingly
            if (AnimatronicPos.Contains(currentCamera))
            {
                if(AnimatronicPos[0] == currentCamera){AnimatronicOnCamera[0] = 1;}
                else if(AnimatronicPos[0] != currentCamera){AnimatronicOnCamera[0] = 0;}
                if(AnimatronicPos[1] == currentCamera){AnimatronicOnCamera[1] = 1;}
                else if(AnimatronicPos[1] != currentCamera){AnimatronicOnCamera[1] = 0;}
                if(AnimatronicPos[2] == currentCamera){AnimatronicOnCamera[2] = 1;}
                else if(AnimatronicPos[2] != currentCamera){AnimatronicOnCamera[2] = 0;}
                if(AnimatronicPos[3] == currentCamera){AnimatronicOnCamera[3] = 1;}
                else if(AnimatronicPos[3] != currentCamera){AnimatronicOnCamera[3] = 0;}
            }
        }
    }
}