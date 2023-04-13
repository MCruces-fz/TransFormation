using System.DirectoryServices;

namespace TransFormation
{
    public partial class Form1 : Form
    {

        bool goFront, goBack, goLeft, goRight;
        private Player player = new Player(150, 400, 3 * (float)Math.PI / 2);

        public Form1()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    goFront = true;
                    break;
                case Keys.S:
                    goBack = true;
                    break;
                case Keys.D:
                    goRight = true;
                    break;
                case Keys.A:
                    goLeft = true;
                    break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    goFront = false;
                    break;
                case Keys.S:
                    goBack = false;
                    break;
                case Keys.D:
                    goRight = false;
                    break;
                case Keys.A:
                    goLeft = false;
                    break;
            }
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            // Create movement method in Player class
            if (goFront) player.transport("front");
            if (goBack) player.transport("back");
            if (goRight) player.rotate("right");
            if (goLeft) player.rotate("left");

            picBox1.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            // Draw Player
            Pen viewColour = new Pen(Brushes.Yellow);
            canvas.DrawLine(viewColour, new Point((int)player.X, (int)player.Y), new Point((int)player.X2, (int)player.Y2));


            Brush playerColour = Brushes.Black;
            canvas.FillEllipse(playerColour, player.bodyRect);

            // Draw Walls
            Pen wallColour = new Pen(Brushes.BlueViolet);
            canvas.DrawLine(viewColour, new Point(50, 100), new Point(250, 100));

        }
    }
}