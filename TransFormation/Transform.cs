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

        public Transform(Player player, Maze maze)
        {
            this.player = player;
            this.maze = maze;

            updateSceneDesign();
        }

        public void updateSceneDesign()
        {
            foreach (Wall wall in maze.walls)
            {
                Wall wallee = new Wall();
                wallee.point1.X = 150-(int)((wall.point1.X - player.X) * Math.Sin(player.theta) - (wall.point1.Y - player.Y) * Math.Cos(player.theta));
                wallee.point1.Y = 400-(int)((wall.point1.X - player.X) * Math.Cos(player.theta) + (wall.point1.Y - player.Y) * Math.Sin(player.theta));

                wallee.point2.X = 150-(int)((wall.point2.X - player.X) * Math.Sin(player.theta) - (wall.point2.Y - player.Y) * Math.Cos(player.theta));
                wallee.point2.Y = 393-(int)((wall.point2.X - player.X) * Math.Cos(player.theta) + (wall.point2.Y - player.Y) * Math.Sin(player.theta));

                tMaze.walls.Add(wallee);
            }
        }
    }
}
