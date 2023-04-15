namespace TransFormation
{
    public partial class Form1 : Form
    {
        private float X0 { set; get; }
        private float Y0 { set; get; }

        bool goFront, goBack, goLeft, goRight;
        private Player player;
        private Maze maze = new Maze(new Wall());


        Transform transform;
        Doom doom;

        public Form1()
        {
            InitializeComponent();

            this.X0 = picBox1.Size.Width / 2;
            this.Y0 = picBox1.Size.Height / 2;
            this.player = new Player(X0, Y0, 3 * (float)Math.PI / 2);
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
            picBox2.Invalidate();
            picBox3.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            player.drawPlayer(canvas);
            maze.drawWalls(canvas);
        }

        private void UpdatePictureBoxGraphics2(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            transform = new Transform(picBox2, player, maze);

            transform.drawPlayer(canvas);
            transform.tMaze.drawWalls(canvas);

        }

        private void UpdatePictureBoxGraphics3(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            doom = new Doom(picBox3, transform.tMaze);

            doom.drawWalls(canvas);
            // doom.drawGradient(canvas);
        }
    }
}