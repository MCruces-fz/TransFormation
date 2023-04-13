using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransFormation
{

    internal class Maze
    {
        public List<Wall> walls = new List<Wall>();

        public Maze() { }

        public Maze(Wall wall)
        {
            walls.Add(wall);
        }

        public void drawWalls(Graphics canvas)
        {
            foreach (Wall wall in walls)
            {
                canvas.DrawLine(wall.material, wall.point1, wall.point2);
            }
        }
    }
}
