using System;

namespace FreeGameJam
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameJamGame())
                game.Run();
        }
    }
}
