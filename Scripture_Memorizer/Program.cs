using Memorizer;

class Program
{
    static void Main()
    {
        Reference myRef = new Reference("john", 8, 21);
        Scripture myScript = new Scripture("once there was a young boy", myRef);
        myScript.init(); // need to init every time you make a new one

        myScript.DisplayScripture();
        
    }
}