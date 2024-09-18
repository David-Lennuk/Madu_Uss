using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Madu_Uus
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запрос имени пользователя
            Console.Write("Sisestage oma nimi: ");
            string playerName = Console.ReadLine();

            int foodCounter = 0;
            string gameOver = "Game Over";
            string message = "Iidi, võtta jalad alla ja muru peal jaluta!";
            Console.SetWindowSize(80, 25);

            Walls walls = new Walls(26, 80);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw(food.x, food.y, food.sym);

            bool gameOverFlag = false;
            bool messageDisplayed = false; // Флаг для проверки, было ли сообщение показано

            // Создаем и запускаем таймер
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (!gameOverFlag)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    gameOverFlag = true;
                    Console.Clear();
                    int x = Console.WindowWidth;
                    int y = Console.WindowHeight;
                    Console.SetCursorPosition((x - gameOver.Length) / 2, y / 2);
                    Console.WriteLine(gameOver);
                }
                else
                {
                    if (snake.Eat(food))
                    {
                        // Очистка старой еды
                        Console.SetCursorPosition(food.x, food.y);
                        Console.Write(' ');

                        food = foodCreator.CreateFood();
                        foodCounter += 1;
                        food.Draw(food.x, food.y, food.sym);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        snake.Move();
                        Console.ForegroundColor = ConsoleColor.Red;

                    }
                }

                // Обновляем счетчик еды и таймер
                Console.SetCursorPosition(0, 0);
                Console.Write($"Toit söödud: {foodCounter}");

                // Показываем прошедшее время
                TimeSpan elapsedTime = stopwatch.Elapsed;
                Console.SetCursorPosition(Console.WindowWidth - 10, 0);
                Console.Write($"Aeg: {elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}");

                // Проверяем, прошло ли 1 минуты и не было ли сообщение уже показано
                if (elapsedTime.TotalMinutes >= 1 && !messageDisplayed)
                {
                    Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
                    Console.WriteLine(message);
                    messageDisplayed = true;
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            // Сохраняем результаты после окончания игры
            SaveScore(playerName, foodCounter, stopwatch.Elapsed);

            // Выводим список игроков с их результатами
            DisplayScores();

            // Ожидаем нажатие клавиши перед завершением программы
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.WriteLine("Väljumiseks vajutage suvalist klahvi");
            Console.ReadKey();
        }

        // Метод для сохранения имени, очков и времени в файл
        static void SaveScore(string playerName, int score, TimeSpan elapsedTime)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"..\..\..\nimekirja.txt", true))
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

        // Метод для отображения списка игроков с их результатами
        static void DisplayScores()
        {
            string file = @"..\..\..\nimekirja.txt";
            Console.WriteLine("\nMängijad ja nende punktid:");

            if (File.Exists(file))
            {
                string[] scores = File.ReadAllLines(file);
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
