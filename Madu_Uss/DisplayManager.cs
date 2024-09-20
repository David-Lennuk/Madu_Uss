using System;

namespace Madu_Uus
{
    internal class DisplayManager
    {
        public void DisplayGameOver(string gameOver)
        {
            Console.Clear();
            int x = Console.WindowWidth;
            int y = Console.WindowHeight;
            Console.SetCursorPosition((x - gameOver.Length) / 2, y / 2);
            Console.WriteLine(gameOver);
        }

        public void DisplayScoreAndTime(int foodCounter, TimeSpan elapsedTime)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Toit söödud: {foodCounter}");
            Console.SetCursorPosition(Console.WindowWidth - 10, 0);
            Console.Write($"Aeg: {elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}");
        }

        public void DisplayMessage(string message)
        {
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(message);
        }

        public void WaitForExit()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.WriteLine("Väljumiseks vajutage suvalist klahvi");
            Console.ReadKey();
        }
    }
}
