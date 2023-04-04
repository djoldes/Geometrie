using GeometryBasic;
using System.Drawing;
using System.Reflection;

namespace Geometrie

{
    public partial class GC6_Triangulare : Form
    {
        List<GeometryBasicFunctions.Segment> lines = new();
        SortedList<float, Tuple<Point, Point>> sortare = new (new CustomIntComparer());
        List<Point> puncte = new();
        Pen pen = new Pen(Color.Red, 5);
        Pen penline = new Pen(Color.Black, 2);
        Pen pentri = new Pen(Color.Gray, 2);

        public GC6_Triangulare()
        {
            InitializeComponent();
        }

        private void GC6_Triangulare_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            g.DrawEllipse(pen, e.X, e.Y, 5, 5);
            puncte.Add(e.Location);
            if (puncte.Count > 1)
            {
                g.DrawLine(penline, puncte[puncte.Count - 1], puncte[puncte.Count - 2]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawLine(penline, puncte[0], puncte[puncte.Count - 1]);
            for (int i = 0; i < puncte.Count; i++)
            {
                for (int j = 1; j < puncte.Count; j++)
                {
                    sortare.Add(GeometryBasicFunctions.GetDistance(puncte[i], puncte[j]), new Tuple<Point, Point>(puncte[i], puncte[j]));
                }
            }
            foreach (var item in sortare)
            {
                bool dointersect = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    if (GeometryBasicFunctions.DoIntersect(item.Value.Item1, item.Value.Item2, lines[i].a, lines[i].b))
                    {
                        dointersect = true;
                    }
                }
                if (!dointersect)
                {
                    lines.Add(new GeometryBasicFunctions.Segment(item.Value.Item1, item.Value.Item2));
                    g.DrawLine(pentri, item.Value.Item1, item.Value.Item2);
                }
            }
            MessageBox.Show("Poligonul este desenat si triangulat");
        }


        class CustomIntComparer : IComparer<float>
        {
            public int Compare(float x, float y)
            {
                if (x < y)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Random rnd = new Random();
            Pen pen = new Pen(Color.LightSalmon, 2);

            int x, y;
            int n = rnd.Next(5, 10);
            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(50, this.ClientSize.Width - 50);
                y = rnd.Next(50, this.ClientSize.Height - 50);
                points[i] = new Point(x, y);
                g.DrawEllipse(pen, x, y, 7, 7);
            }
            
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 1; j < points.Length; j++)
                {
                    sortare.Add(GeometryBasicFunctions.GetDistance(points[i], points[j]), new Tuple<Point, Point>(points[i], points[j]));
                }
            }
            foreach(var item in sortare)
            {
                bool dointersect = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    if(GeometryBasicFunctions.DoIntersect(item.Value.Item1, item.Value.Item2, lines[i].a, lines[i].b))
                    {
                        dointersect = true;
                    }                
                }
                if (!dointersect)
                {
                    lines.Add(new GeometryBasicFunctions.Segment(item.Value.Item1, item.Value.Item2));
                    g.DrawLine(pentri, item.Value.Item1, item.Value.Item2);
                }
            }
            MessageBox.Show("Poligonul este generat random, desenat si triangulat");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GC6_Triangulare NewForm = new GC6_Triangulare();
            NewForm.Show();
            this.Dispose(false);
        }
    }
}