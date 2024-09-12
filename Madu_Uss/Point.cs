using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uss
{
    internal class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point(){}
        
        public Point(int X, int Y, char Sym)
        {
            x = X;
            y = Y;
            sym = Sym;
        }
        
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }
        
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else
            {
                y = y + offset;
            }
        }

        public bool KasLoob(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        public void Draw(int x, int y, char sym)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(sym);
        }

                public void Tuhjenda()
        {
            sym = ' ';
            Draw(x, y, sym);
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}
