using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransFormation
{
    internal class Doom
    {
        Maze tMaze;

        public List<PointF> wallPoints = new();
        public PointF[] fPoints = new PointF[] { new PointF(1f, 1f), new PointF(1f, 1f), new PointF(1f, 1f), new PointF(1f, 1f), };
        /*fPoints = new PointF[] { new PointF(-16 * wall.point2.X / wall.point2.Y, -50 / wall.point2.Y)};*/
        Point origin;

        public Doom(PictureBox picBox, Maze maze)
        {
            this.tMaze = maze;
            Console.WriteLine(tMaze.walls.Count);

            origin = new Point(picBox.Size.Width / 2, picBox.Size.Height / 2);
            updateSceneDesign(origin);
        }

        public void updateSceneDesign(Point origin)
        {
            foreach (Wall wall in tMaze.walls)
            {
                float tX1 = wall.point1.X - origin.X;
                float tY1 = wall.point1.Y - origin.Y;
                float tX2 = wall.point2.X - origin.X;
                float tY2 = wall.point2.Y - origin.Y;

                this.fPoints[0] = new PointF(- 50 * tX1 / tY1 + origin.X, -700 / tY1 + origin.Y); // (X1, Y1a)
                this.fPoints[1] = new PointF(- 50 * tX1 / tY1 + origin.X,  700 / tY1 + origin.Y); // (X1, Y1b)
                this.fPoints[2] = new PointF(- 50 * tX2 / tY2 + origin.X,  700 / tY2 + origin.Y); // (X2, Y2b)
                this.fPoints[3] = new PointF(- 50 * tX2 / tY2 + origin.X, -700 / tY2 + origin.Y); // (X2, Y2a)

                /*
                this.fPoints[0] = new PointF(-16 * wall.point1.X / wall.point1.Y, -50 / wall.point1.Y); // (X1, Y1a)
                this.fPoints[1] = new PointF(-16 * wall.point1.X / wall.point1.Y,  50 / wall.point1.Y); // (X1, Y1b)
                this.fPoints[2] = new PointF(-16 * wall.point2.X / wall.point2.Y,  50 / wall.point2.Y); // (X2, Y2b)
                this.fPoints[3] = new PointF(-16 * wall.point2.X / wall.point2.Y, -50 / wall.point2.Y); // (X2, Y2a)
                */
            }
        }

        public void drawWalls(Graphics canvas)
        {
            Pen wallColour = new Pen(Brushes.DarkOrange, 5);

            canvas.DrawPolygon(wallColour, fPoints);
        }

        public void drawGradient(Graphics canvas)
        {
            using (PathGradientBrush path_brush = new PathGradientBrush(fPoints))
            {
                path_brush.CenterColor = Color.White;
                path_brush.SurroundColors = new Color[] {
                    Color.Lime, Color.Cyan, Color.Blue, Color.Magenta
                };

                canvas.FillPolygon(path_brush, fPoints);
            }
        }
    }
}
