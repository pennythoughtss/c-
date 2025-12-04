using System.Text;
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
        private List<string> AnimatronicOnCamera = ["No", "No", "No", "No"];

        public string currentCamera = "1A";
        public int currentCamNum = 0;

        public void viewCamera(string foxyPos)
        {
            var cameraDisplay = new StringBuilder();
            Console.WriteLine($"{currentCamera} : {camNameList[currentCamNum]}");

            if (currentCamera == "6")
            {
                cameraDisplay.Append(Program.animation.AudioOnly());
            }
            else
            {
                if (AnimatronicOnCamera.Contains("Freddy")){cameraDisplay.Append("Freddy ");}
                if (AnimatronicOnCamera.Contains("Bonnie")){cameraDisplay.Append("Bonnie ");}
                if (AnimatronicOnCamera.Contains("Chica")){cameraDisplay.Append("Chica");}
                if (AnimatronicOnCamera.Contains("Foxy")){cameraDisplay.Append(foxyPos);}
            }

            Console.WriteLine("[" + cameraDisplay.ToString() + "]");
            
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
            currentCamera = camList[currentCamNum];

            //checks if animatronics are on camera and sets stuff accordingly
            if (AnimatronicPos.Contains(currentCamera))
            {
                if(AnimatronicPos[0] == currentCamera){AnimatronicOnCamera[0] = "Freddy";}
                else if(AnimatronicPos[0] != currentCamera){AnimatronicOnCamera[0] = "No";}
                if(AnimatronicPos[1] == currentCamera){AnimatronicOnCamera[1] = "Bonnie";}
                else if(AnimatronicPos[1] != currentCamera){AnimatronicOnCamera[1] = "No";}
                if(AnimatronicPos[2] == currentCamera){AnimatronicOnCamera[2] = "Chica";}
                else if(AnimatronicPos[2] != currentCamera){AnimatronicOnCamera[2] = "No";}
                if(AnimatronicPos[3] == currentCamera){AnimatronicOnCamera[3] = "Foxy";}
                else if(AnimatronicPos[3] != currentCamera){AnimatronicOnCamera[3] = "No";}
            }
            else
            {
                AnimatronicOnCamera = ["No","No","No","No"];
            }
        }
    }
}