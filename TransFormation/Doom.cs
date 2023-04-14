using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransFormation
{
    internal class Doom
    {
        Maze tMaze;

        public List<PointF> wallPoints = new();
        public PointF[] fPoints = new PointF[] {new PointF(1f, 1f), new PointF(1f, 1f),new PointF(1f, 1f),new PointF(1f, 1f),};
        /*fPoints = new PointF[] { new PointF(-16 * wall.point2.X / wall.point2.Y, -50 / wall.point2.Y)};*/


        public Doom(Maze maze)
        {
            this.tMaze = maze;
            Console.WriteLine(tMaze.walls.Count);

            updateSceneDesign();
        }

        public void updateSceneDesign()
        {
            foreach (Wall wall in tMaze.walls)
            {
                this.fPoints[0] = new PointF(50 * wall.point1.X / wall.point1.Y + 100,  700 / wall.point1.Y + 100); // (X1, Y1a)
                this.fPoints[1] = new PointF(50 * wall.point1.X / wall.point1.Y + 100, -700 / wall.point1.Y + 100); // (X1, Y1b)
                this.fPoints[2] = new PointF(50 * wall.point2.X / wall.point2.Y + 100, -700 / wall.point2.Y + 100); // (X2, Y2b)
                this.fPoints[3] = new PointF(50 * wall.point2.X / wall.point2.Y + 100,  700 / wall.point2.Y + 100); // (X2, Y2a)

                /*this.fPoints[0] = new PointF(-16 * wall.point1.X / wall.point1.Y, -50 / wall.point1.Y); // (X1, Y1a)
                this.fPoints[1] = new PointF(-16 * wall.point1.X / wall.point1.Y,  50 / wall.point1.Y); // (X1, Y1b)
                this.fPoints[2] = new PointF(-16 * wall.point2.X / wall.point2.Y,  50 / wall.point2.Y); // (X2, Y2b)
                this.fPoints[3] = new PointF(-16 * wall.point2.X / wall.point2.Y, -50 / wall.point2.Y); // (X2, Y2a)*/
            }
        }
    }
}
