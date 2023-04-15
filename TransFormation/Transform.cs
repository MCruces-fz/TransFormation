using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransFormation
{
    internal class Transform
    {
        Player player;
        Maze maze;

        public Maze tMaze = new Maze();

        public Point origin;

        public Transform(PictureBox picBox, Player player, Maze maze)
        {
            this.player = player;
            this.maze = maze;

            origin = new Point(picBox.Size.Width / 2, picBox.Size.Height / 2);
            updateSceneDesign(origin);
        }

        public void updateSceneDesign(Point origin)
        {

            foreach (Wall wall in maze.walls)
            {
                Wall wallee = new Wall();
                wallee.point1.X = origin.X - (int)((wall.point1.X - player.X) * Math.Sin(player.theta) - (wall.point1.Y - player.Y) * Math.Cos(player.theta));
                wallee.point1.Y = origin.Y - (int)((wall.point1.X - player.X) * Math.Cos(player.theta) + (wall.point1.Y - player.Y) * Math.Sin(player.theta));

                wallee.point2.X = origin.X - (int)((wall.point2.X - player.X) * Math.Sin(player.theta) - (wall.point2.Y - player.Y) * Math.Cos(player.theta));
                wallee.point2.Y = origin.Y - (int)((wall.point2.X - player.X) * Math.Cos(player.theta) + (wall.point2.Y - player.Y) * Math.Sin(player.theta));

                tMaze.walls.Add(wallee);
            }
        }

        public void drawPlayer(Graphics canvas)
        {
            // Draw Player
            Pen viewColour = new Pen(Brushes.Yellow);
            canvas.DrawLine(viewColour, new Point(origin.X, origin.Y), new Point(origin.X, origin.Y - (int)player.lineLength));

            // Draw View
            Brush playerColour = Brushes.Black;
            canvas.FillEllipse(playerColour, new RectangleF(origin.X - player.bodySize / 2, origin.Y - player.bodySize / 2, player.bodySize, player.bodySize));

        }
    }
}
