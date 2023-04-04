using System.Drawing;

namespace GeometryBasic
{
    public class GeometryBasicFunctions
    {
        public static int GetDistance(Point a, Point b)
        {
            return (int)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static int GetOrientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (val == 0) return 0;
            return (val > 0) ? 1 : -1;
        }

        public static bool DoIntersect(Point L1x, Point L1y, Point L2x, Point L2y)
        {
            if (GetOrientation(L1x, L1y, L2x) * GetOrientation(L1x, L1y, L2y) < 0 && GetOrientation(L2x, L2y, L1x) * GetOrientation(L2x, L2y, L1y) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public struct Segment
        {
            public Point a;
            public Point b;
            public Segment(Point a, Point b)
            {
                this.a = a;
                this.b = b;
            }
        }
    }
}