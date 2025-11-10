
using System.Runtime.ExceptionServices;


// ignore how messy this one is, I was messing around
// Some of the animations are kinda cool actually
//////////////////////////////////////////////////////

namespace Activity
{
    class Animation()
    {
        private void frame(string content, int delay)
        {
            Console.WriteLine(content);
            Thread.Sleep(delay);
        }
        private void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        public void Load1()
        {
            Console.Write("\\");
            Thread.Sleep(150);
            Console.Write("\b");
            Console.Write("|");
            Thread.Sleep(150);
            Console.Write("\b");
            Console.Write("/");
            Thread.Sleep(150);
            Console.Write("\b");
            Console.Write("/");
            Thread.Sleep(150);
            Console.Write("\b");
            Console.Write("|");
            Thread.Sleep(150);
            Console.Write("\b");
            Console.Write("\\");
            Thread.Sleep(150);
            Console.Write("\b");
        }

        public void Load2(int duration = 4)
        {
            for (int i = 0; i < duration; i++)
            {

                Console.Write(".");
                Thread.Sleep(150);
                ClearCurrentConsoleLine();
                Console.Write("..");
                Thread.Sleep(150);
                ClearCurrentConsoleLine();
                Console.Write("...");
                Thread.Sleep(150);
                ClearCurrentConsoleLine();
                Console.Write("....");
                Thread.Sleep(300);
                ClearCurrentConsoleLine();
                Console.Write(" ...");
                Thread.Sleep(150);
                ClearCurrentConsoleLine();
                Console.Write("  ..");
                Thread.Sleep(150);
                ClearCurrentConsoleLine();
                Console.Write("   .");
                Thread.Sleep(150);
                ClearCurrentConsoleLine();
                Thread.Sleep(150);
            }

        }
        public void load3(int step, int duration = 0)
        {
            List<string> anim = [" ",
            ".",
            "..",
            "...",
            "....",
            " ...",
            "  ..",
            "   ."];

            //double dur = duration / 1000;
            //Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Console.Write(anim[step]);
            //Console.SetCursorPosition(0, Console.CursorTop + 1);
            //ClearCurrentConsoleLine();
            //Console.Write(dur);

        }

        public void Countdown(int step)
        {
            for (int i = step; i >= 0; i--)
            {
                ClearCurrentConsoleLine();
                Console.Write(i);
                Thread.Sleep(1000);
            }


        }

        public void Breathe1()
        {

            Console.Write("  /");
            Thread.Sleep(250);
            Console.Write("\n  \\");
            Thread.Sleep(250);
            ClearCurrentConsoleLine();
            Console.Write("  \\ /");
            Thread.Sleep(250);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Console.Write("  / \\");
            Thread.Sleep(250);
            ClearCurrentConsoleLine();
            Console.Write("    \\");
            Thread.Sleep(250);
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            ClearCurrentConsoleLine();
            Console.Write("    /");
            Thread.Sleep(250);
            ClearCurrentConsoleLine();
            Thread.Sleep(250);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Thread.Sleep(250);
        }


        public void Breathe2(int step = 0)
        {
            List<string> notes = [
                "Inhale...",
                "Inhale...",
                "Inhale...",
                "Inhale...",
                "Exhale...",
                "Exhale...",
                "Exhale...",
                "Exhale..."
            ];
            List<string> topAnim = [
                "        / \\",
                "      / / \\ \\",
                "    / / / \\ \\ \\",
                "   // / / \\ \\ \\\\",
                "    / / / \\ \\ \\",
                "      / / \\ \\",
                "        / \\",
                " "
            ];
            List<string> lowerAnim = [
                "        \\ /",
                "      \\ \\ / /",
                "    \\ \\ \\ / / /",
                "   \\\\ \\ \\ / / //",
                "    \\ \\ \\ / / /",
                "      \\ \\ / /",
                "        \\ /",
                " "
            ];


            Console.SetCursorPosition(0, Console.CursorTop - 2);
            ClearCurrentConsoleLine();
            Console.Write(topAnim[step]);
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            ClearCurrentConsoleLine();
            Console.Write(lowerAnim[step]);
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            ClearCurrentConsoleLine();
            Console.Write(notes[step]);


        }
    }
}