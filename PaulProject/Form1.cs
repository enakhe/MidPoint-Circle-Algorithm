namespace PaulProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 640;
            this.Height = 480;
            this.Text = "Midpoint Circle Algorithm";
            this.BackColor = Color.Black;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Paint += new PaintEventHandler(DrawCircle);
        }

        private void DrawCircle(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Red, 2);

            int x_center = this.Width / 2;
            int y_center = this.Height / 2;
            int radius = 100;

            int x = 0;
            int y = radius;
            int d = 1 - radius;

            DrawSymmetricPoints(graphics, pen, x_center, y_center, x, y);

            while (y > x)
            {
                if (d <= 0)
                {
                    d += 2 * x + 1;
                }
                else
                {
                    d += 2 * (x - y) + 1;
                    y--;
                }
                x++;

                DrawSymmetricPoints(graphics, pen, x_center, y_center, x, y);
            }
        }

        private void DrawSymmetricPoints(Graphics g, Pen pen, int xc, int yc, int x, int y)
        {
            Pen[] colors = { new Pen(Color.Red, 2), new Pen(Color.Green, 2), new Pen(Color.Blue, 2), new Pen(Color.Yellow, 2) };

            g.DrawRectangle(colors[0], xc + x, yc + y, 1, 1);
            g.DrawRectangle(colors[1], xc - x, yc + y, 1, 1);
            g.DrawRectangle(colors[2], xc + x, yc - y, 1, 1);
            g.DrawRectangle(colors[3], xc - x, yc - y, 1, 1);
            g.DrawRectangle(colors[0], xc + y, yc + x, 1, 1);
            g.DrawRectangle(colors[1], xc - y, yc + x, 1, 1);
            g.DrawRectangle(colors[2], xc + y, yc - x, 1, 1);
            g.DrawRectangle(colors[3], xc - y, yc - x, 1, 1);
        }
    }
}
