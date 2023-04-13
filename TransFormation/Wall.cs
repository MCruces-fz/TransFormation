using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransFormation
{
    internal class Wall
    {
        public Point point1;
        public Point point2;
        public Pen material;
        public int wallThickness = 3;
        public Wall() 
        { 
            this.point1 = new Point(50, 100); 
            this.point2 = new Point(250, 100); 
            this.material = new Pen(Color.BlueViolet, wallThickness);
        }

        public Wall(Point point1, Point point2) 
        { 
            this.point1 = point1; 
            this.point2 = point2; 
            this.material = new Pen(Color.Orange, wallThickness);
        }

        public Wall(Point point1, Point point2, Pen material)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.material = material;
        }
    }
}
