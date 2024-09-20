using System;
using System.IO;

namespace Madu_Uus
{
    internal class ScoreManager
    {
        private const string FilePath = @"..\..\..\nimekirja.txt";

        public void SaveScore(string playerName, int score, TimeSpan elapsedTime)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath, true))
                {
                    string timeFormatted = $"{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
                    sw.WriteLine($"{playerName}:{score}--{timeFormatted}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fail ei leitud: ");
            }
        }

        public void DisplayScores()
        {
            Console.WriteLine("\nMängijad ja nende punktid:");

            if (File.Exists(FilePath))
            {
                string[] scores = File.ReadAllLines(FilePath);
                foreach (string score in scores)
                {
                    Console.WriteLine(score);
                }
            }
            else
            {
                Console.WriteLine("Veel pole tulemusi.");
            }
        }
    }
}
