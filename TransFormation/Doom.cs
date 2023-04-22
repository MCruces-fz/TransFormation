using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace TransFormation
{
    internal class Doom
    {
        Maze tMaze;

        public List<PointF> wallPoints = new();
        public PointF[] fPoints = new PointF[] { new PointF(1f, 1f), new PointF(1f, 1f), new PointF(1f, 1f), new PointF(1f, 1f)};
        Point origin;
        PictureBox picBox;

        float hfov = 50f, vfov = 1000f; // Horizontal and Vertical Field of View

        public Doom(PictureBox picBox, Maze maze)
        {
            this.tMaze = maze;
            Console.WriteLine(tMaze.walls.Count);

            this.picBox = picBox;
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

                if (tY1 >= 0 && tY2 >= 0) continue;// Wall totally behind the player -> Don't draw it

                if (tY1 >= 0 || tY2 >= 0) // Wall partially behind the player
                {
                    float neary = 1e-4f, fary = 5, nearside = 1e-4f, farside = 20f; // Fix these numbers
                        
                    PointF iSect1 = intersect(tX1, tY1, tX2, tY2, -nearside, neary, -farside, fary); // Intersection left
                    PointF iSect2 = intersect(tX1, tY1, tX2, tY2,  nearside, neary,  farside, fary); // Intersection rigth
                    if (tY1 >= 0) // Left side behind
                    {
                        if (iSect1.Y < 0) 
                        {
                            tX1 = iSect1.X;
                            tY1 = iSect1.Y;
                        } else
                        {
                            tX1 = iSect2.X; // tY2 < 0 por la derecha
                            tY1 = iSect2.Y;
                        }
                    }
                    if (tY2 >= 0)
                    {
                        if (iSect1.Y < 0)
                        {
                            tX2 = iSect1.X;
                            tY2 = iSect1.Y;
                        } else
                        {
                            tX2 = iSect2.X; // tY1 < 0 por la izquierda
                            tY2 = iSect2.Y;
                        }
                    }
                }

                this.fPoints[0] = new PointF(-hfov * tX1 / tY1 + origin.X, -vfov / tY1 + origin.Y); // (X1, Y1a) RED
                this.fPoints[1] = new PointF(-hfov * tX1 / tY1 + origin.X,  vfov / tY1 + origin.Y); // (X1, Y1b) BLUE
                this.fPoints[2] = new PointF(-hfov * tX2 / tY2 + origin.X,  vfov / tY2 + origin.Y); // (X2, Y2b) GREEN
                this.fPoints[3] = new PointF(-hfov * tX2 / tY2 + origin.X, -vfov / tY2 + origin.Y); // (X2, Y2a) YELLOW

                /*
                this.fPoints[0] = new PointF(-16 * wall.point1.X / wall.point1.Y, -50 / wall.point1.Y); // (X1, Y1a)
                this.fPoints[1] = new PointF(-16 * wall.point1.X / wall.point1.Y,  50 / wall.point1.Y); // (X1, Y1b)
                this.fPoints[2] = new PointF(-16 * wall.point2.X / wall.point2.Y,  50 / wall.point2.Y); // (X2, Y2b)
                this.fPoints[3] = new PointF(-16 * wall.point2.X / wall.point2.Y, -50 / wall.point2.Y); // (X2, Y2a)
                */
            }
        }

        public PointF intersect(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            PointF iSect = new PointF();
            float cross(float a, float b, float c, float d) { return a * d - b * c; }

            float ix = cross(x1, y1, x2, y2);
            float iy = cross(x3, y3, x4, y4);
            float det = cross(x1 - x2, y1 - y2, x3 - x4, y3 - y4);
            iSect.X = cross(ix, x1 - x2, iy, x3 - x4) / det;
            iSect.Y = cross(ix, y1 - y2, iy, y3 - y4) / det;

            return iSect;
        }

        public void drawWalls(Graphics canvas)
        {
            Pen wallColour = new Pen(Brushes.DarkOrange, 5);

            canvas.DrawPolygon(wallColour, fPoints);

            RectangleF calcRect(PointF point)
            {
                float size = 6;
                RectangleF rectangle = new RectangleF(point.X - size, point.Y - size, size, size);
                return rectangle;
            }

            canvas.FillEllipse(Brushes.Red, calcRect(fPoints[0]));    // (X1, Y1a)
            canvas.FillEllipse(Brushes.Blue, calcRect(fPoints[1]));   // (X1, Y1b)
            canvas.FillEllipse(Brushes.Green, calcRect(fPoints[2]));  // (X2, Y2b)
            canvas.FillEllipse(Brushes.Yellow, calcRect(fPoints[3])); // (X2, Y2a)

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
