using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Madu_Uus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw(food.x, food.y, food.sym);

            while (true) 
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw(food.x, food.y, food.sym);
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);
            }











            //    VerticalLine v1 = new VerticalLine(0, 10, 5, '%');
            //    Draw(v1);

            //    Point p = new Point(4, 5, '*');
            //    Figure fSnake = new Snake(p, 4, Direction.RIGHT);
            //    Draw (fSnake);
            //    Snake snake = (Snake)fSnake;


            //    HorizontalLine h1 = new HorizontalLine(0, 5, 6, '&');

            //    List<Figure> figures = new List<Figure>();
            //    figures.Add(fSnake);
            //    figures.Add(v1);
            //    figures.Add(h1);

            //    foreach(var f in figures)
            //    {
            //        f.Draw();
            //    }
            //}
            //static void Draw(Figure figure)
            //{
            //    figure.Draw();
            //}

            //static void Main(string[] args)
            //{
            //    Console.SetWindowSize(80, 25);

            //    HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            //    HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            //    VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            //    VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            //    upLine.Draw();
            //    downLine.Draw();
            //    leftLine.Draw();
            //    rightLine.Draw();

            //    Point p = new Point(4, 5, '*');
            //    Snake snake = new Snake(p, 4, Direction.RIGHT);
            //    snake.Draw();
            //    snake.Move();
        }
    }
}
