
namespace _03.IntersectionOfCircles
{
    public class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        public Circle(Point center, int radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public static bool Intersect(Circle c1, Circle c2)
        {
            if (Point.CalculateDistance(c1.Center, c2.Center) <= c1.Radius + c2.Radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}