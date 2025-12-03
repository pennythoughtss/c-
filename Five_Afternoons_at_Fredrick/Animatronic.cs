
using System.Runtime.InteropServices.Marshalling;

namespace FNAF
{
    // abstract class framework for the animatronics
    // bro idk this junk is messy, I'll deal with it later
    // TODO clean this up

    public abstract class Animatronic()
    {
        protected virtual string name => "Endo";
        protected virtual double interval => 0;
        protected virtual bool isCameraStalled => false;
        //protected virtual List<string> path => [];
        // protected virtual int AI => 0;
        // protected virtual int currentPOS => 0;

        public virtual void attack()
        {
            Console.Write($"You've been gotten by {name}!");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        public virtual int nextPOS()
        {
            return 0;
        }

        public virtual void updateMovement(double seconds)
        {
        //    if (isCameraStalled)
        //     {
                
        //     }
        }

        public virtual void setAI(int AI_Level)
        {
            //set yo bad boy AI

        }


    }
}