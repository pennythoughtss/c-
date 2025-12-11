using System.Data;
using System.Text;
using FNAF;

namespace FNAF
{

    // I sure am spending a lot of time making this look pretty
    // when I could be MAKING IT WORK INSTEAD

    class Animation()
    {
        Random random = new Random();
        

        public void sixAM_YAY_1()
        {
            List<string> anim = ["       AM", "0      AM"," 0     AM","  0    AM",
            "   0   AM","    0  AM","     0 AM","     0 AM","0    0 AM"," 0   0 AM","  0  0 AM",
            "   0 0 AM","    00 AM","    00 AM",":   00 AM"," :  00 AM","  : 00 AM","   :00 AM","   :00 AM",
            "6  :00 AM"," 6 :00 AM","  6:00 AM","  6:00 AM","  6:00 AM","- 6:00 AM -","\\ 6:00 AM \\","| 6:00 AM |","/ 6:00 AM /",
            "- 6:00 AM -"];
            
            string spacer = "   ";
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (string step in anim)
            {
                Utils.ClearCurrentConsoleLine();
                Console.Write(spacer + step);
                Thread.Sleep(150);
            }
            for(int i = 0; i < 4; i++)
            {
                Utils.ClearCurrentConsoleLine();
                Console.Write(spacer + anim[24]);
                Thread.Sleep(150);
                Utils.ClearCurrentConsoleLine();
                Console.Write(spacer + anim[25]);
                Thread.Sleep(150);
                Utils.ClearCurrentConsoleLine();
                Console.Write(spacer + anim[26]);
                Thread.Sleep(150);
                Utils.ClearCurrentConsoleLine();
                Console.Write(spacer + anim[27]);
                Thread.Sleep(150);
                Utils.ClearCurrentConsoleLine();
                Console.Write(spacer + anim[28]);
                Thread.Sleep(150);
            }
        }

        public void youDied_OhNo()
        {
            List<string> line1 = ["","v v v v v","v v v v v","v v v v v","",""];
            List<string> line2 = ["","","v v v v v","v v v v v","v v v v v",""];
            List<string> line3 = ["","","","v v v v v","v v v v v","v v v v v"];
            List<string> line4 = ["","",""," ^ ^ ^ ^"," ^ ^ ^ ^"," ^ ^ ^ ^"];
            List<string> line5 = ["",""," ^ ^ ^ ^"," ^ ^ ^ ^"," ^ ^ ^ ^",""];
            List<string> line6 = [""," ^ ^ ^ ^"," ^ ^ ^ ^"," ^ ^ ^ ^","",""];
            string spacer = "    ";
            List<string> line7 = ["v v v v v", " v v v v v"];
            List<string> line8 = [" ^ ^ ^ ^", "  ^ ^ ^ ^"];
            Console.ForegroundColor = ConsoleColor.Red;
            for(int i=0; i<line1.Count(); i++)
            {
                Console.Clear();
                Console.WriteLine(spacer + line1[i]);
                Console.WriteLine(spacer + line2[i]);
                Console.WriteLine(spacer + line3[i]);
                Console.WriteLine(spacer + line4[i]);
                Console.WriteLine(spacer + line5[i]);
                Console.WriteLine(spacer + line6[i]);
                Thread.Sleep(20);
            }
            for (int i=0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine("\n");
                Console.WriteLine(spacer + line7[0]);
                Console.WriteLine(spacer + line8[0]);
                Thread.Sleep(100);
                Console.Clear();
                Console.WriteLine("\n");
                Console.WriteLine(spacer + line7[1]);
                Console.WriteLine(spacer + line8[1]);
                Thread.Sleep(100);
            }

            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine(spacer + line7[0]);
            Console.WriteLine(spacer + line8[0]);
            Thread.Sleep(200);
        }

        public string AudioOnly()
        {
            string defString = "N/A, N/A, N/A, N/A";
            string refString = "~`!@#$%^&*()_+=<>?/|....,";
            var randString = new StringBuilder();
            int num1 = 0;
            int num2 = 0;

            foreach(char c in defString)
            {
                num1 = random.Next(0,2);
                if (num1 == 0)
                {
                    num2 = random.Next(0,refString.Length);
                    randString.Append(refString[num2]);

                }
                else
                {
                    randString.Append(c);
                }
            }

            return "[" + randString.ToString() + "]";
            
        }

        public void CurrentNightDisplay(int n)
        {
            List<string> anim = [$" //  NIGHT {n}  \\\\",$" /   NIGHT {n}   \\",
            $"     NIGHT {n}",$"   / NIGHT {n} \\",$"  // NIGHT {n} \\\\"];

            string spacer = "    ";
            
            for(int i = 0; i < 4; i++)
            {
                foreach (string step in anim)
            {
                Utils.ClearCurrentConsoleLine();
                Console.Write(spacer + step);
                Thread.Sleep(200);
            }
            }
            
        }
        
    }
}