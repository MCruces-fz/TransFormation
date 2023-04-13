using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TransFormation
{
    internal class Player
    {
        private float _X;
        public float X 
        { 
            get => _X;
            set 
            {
                _X = value;
                updateBodyDesign();
            } 
        }

        private float _Y;
        public float Y 
        { 
            get => _Y;
            set 
            {
                _Y = value;
                updateBodyDesign();
            }
        }

        private float _theta;
        public float theta 
        { 
            get => _theta;
            set 
            { 
                _theta = value;
                updateBodyDesign();
            }
        }

        public float lineLength = 7;

        public float X2 { get; set; }
        public float Y2 { get; set; }

        public float linearSpeed = 3;
        public float angularSpeed = 0.1f;

        public float bodySize = 5;
        public RectangleF bodyRect;


        public Player()
        {
            X = 0;
            Y = 0;
            theta = (float)(Math.PI / 2);

            updateBodyDesign();
        }

        public Player(float x, float y, float th)
        {
            X = x;
            Y = y;
            this.theta = th;

            updateBodyDesign();
        }

        public void updateBodyDesign()
        {
            bodyRect = new RectangleF(X - bodySize / 2, Y - bodySize / 2, bodySize, bodySize);
            X2 = X + (float)(lineLength * Math.Cos(theta));
            Y2 = Y + (float)(lineLength * Math.Sin(theta));
        }

        public void transport(string direction)
        {
            switch (direction)
            {
                case "front":
                    X += (float)(linearSpeed * Math.Cos(theta));
                    Y += (float)(linearSpeed * Math.Sin(theta));
                    break;
                case "back":
                    X -= (float)(linearSpeed * Math.Cos(theta));
                    Y -= (float)(linearSpeed * Math.Sin(theta));
                    break;
            }
        }

        public void rotate(string direction)
        {
            switch (direction)
            {
                case "right":
                    theta += (float)angularSpeed;
                    break;
                case "left":
                    theta -= (float)angularSpeed;
                    break;
            }
        }
    }
}
