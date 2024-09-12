using Madu_Uss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madu_Uus
{
    class Figure
    {
        protected List<Point> pList;
        public virtual void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw(p.x, p.y, p.sym);
            }
        }
    }
}
