using System;

namespace Madu_Uus
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();

            try
            {
                game.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
