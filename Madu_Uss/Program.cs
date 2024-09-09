using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Madu_Uss
{
    class Program
    {
        static void Main(string[] args)
        {

            Point p1 = new Point(1, 3, '*');
            //p1.x = 1;
            //p1.y = 3;
            //p1.sym = '*';
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            //p2.x = 4;
            //p2.y = 5;
            //p2.sym = '#';
            p2.Draw();

            HorizontalLine line = new HorizontalLine(5, 10, 8, '+');
            line.Drow();


            //----------------------------------------------------
            ////tund 6
            //List<int> numList = new List<int>();
            //numList.Add(0);
            //numList.Add(1);
            //numList.Add(2);

            //int x = numList[0];
            //int y = numList[1];
            //int z = numList[2];

            //foreach (int i in numList)
            //{ 
            //    Console.WriteLine(i);
            //}

            //numList.RemoveAt(0); 

            //List<Point> pList = new List<Point>();
            //pList.Add(p1);
            //pList.Add(p2);
            //---------------------------------------------------

            //---------------------------------------------------
            //tund 1-2
            //int x1 = 1;
            //int y1 = 3;
            //char sym1 = '*';

            //Draw( x1, y1, sym1 );

            //int x2 = 4;
            //int y2 = 5;
            //char sym2 = '#';

            //Draw( x2, y2, sym2 );
            //------------------------------------------------------


            Console.SetBufferSize(80, 25);
            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            upLine.Drow();
            downLine.Drow();
            leftLine.Drow();
            rightLine.Drow();

            Point p = new Point(4, 5, '*');
            p.Draw();


            Console.ReadLine();
        }                                                                                                                                                                      
    }
}