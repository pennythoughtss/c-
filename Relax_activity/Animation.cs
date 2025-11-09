
using System.Runtime.ExceptionServices;

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
                "Hold...",
                "Exhale...",
                "Exhale...",
                "Exhale...",
                "Hold..."
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


            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Console.Write(topAnim[step]);
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            ClearCurrentConsoleLine();
            Console.Write(lowerAnim[step]);


        }
    }
}