using System;
using System.Text;

namespace LabWork3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            
            try
            {
                int menu;
                Quadrilateral quadrilateral = new Quadrilateral();

                while (true)
                {
                    Console.WriteLine("[1] - input");
                    Console.WriteLine("[2] - area");
                    Console.WriteLine("[3] - perimeter");
                    Console.WriteLine("[4] - type");

                    menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Console.WriteLine("[1] - sides");
                            Console.WriteLine("[2] - points");
                            int menu2 = Convert.ToInt32(Console.ReadLine());
                            switch (menu2)
                            {
                                case 1:
                                    Console.WriteLine("Enter sides:");
                                    double[] sides = new double[4];
                                    for (int i = 0; i < 4; i++)
                                    {
                                        sides[i] = Convert.ToDouble(Console.ReadLine());
                                    }
                                    quadrilateral = new Quadrilateral(sides);
                                    break;
                                case 2:
                                    Console.WriteLine("Enter points:");
                                    Point[] points = new Point[4];
                                    for (int i = 0; i < 4; i++)
                                    {
                                        Console.WriteLine("Point " + (i+1));
                                        double x = Convert.ToDouble(Console.ReadLine());
                                        double y = Convert.ToDouble(Console.ReadLine());
                                        points[i] = new Point(x, y);
                                    }
                                    quadrilateral = new Quadrilateral(points);
                                    break;
                                default:
                                    Console.WriteLine("Wrong number");
                                    break;                            
                            }
                            break;
                        case 2:
                            Console.WriteLine("Area : " + quadrilateral.area());
                            break;
                        case 3:
                            Console.WriteLine("Perimeter : " + quadrilateral.perimeter());
                            break;
                        case 4:
                            Console.WriteLine("Type : " + quadrilateral.getType());
                            break;
                        default:
                            Console.WriteLine("Wrong number");
                            break;
                    }
                }

            } catch (Exception e)
            {

            }
        }
    }

    public class Quadrilateral : QuadrilateralBySides, QuadrilateralByPoints
    {
        private double ab { get; }
        private double bc { get; }
        private double cd { get; }
        private double ad { get; }
        private Point? a { get; } = null;
        private Point? b { get; } = null;
        private Point? c { get; } = null;
        private Point? d { get; } = null;

        public Quadrilateral(double[] sides)
        {
            this.ab = sides[0];
            this.bc = sides[1];
            this.cd = sides[2];
            this.ad = sides[3];
        }

        public Quadrilateral()
        {
            this.ab = 1;
            this.bc = 1;
            this.cd = 1;
            this.ad = 1;
        }

        public Quadrilateral(Point[] points)
        {
            this.a = points[0];
            this.b = points[1];
            this.c = points[2];
            this.d = points[3];

            ab = Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
            bc = Math.Sqrt(Math.Pow(c.x - b.x, 2) + Math.Pow(c.y - b.y, 2));
            cd = Math.Sqrt(Math.Pow(d.x - c.x, 2) + Math.Pow(d.y - c.y, 2));
            ad = Math.Sqrt(Math.Pow(d.x - a.x, 2) + Math.Pow(d.y - a.y, 2));
        }

        public double perimeter()
        {
            return ab + bc + cd + ad;
        }

        public double area()
        {
            double s = perimeter() / 2;
            return Math.Sqrt((s - ab) * (s - bc) * (s - cd) * (s - ad));
        }

        public static bool isRightAngle(Point a, Point b, Point c)
        {

            double sideA = Math.Sqrt(Math.Pow(b.x - c.x, 2) + Math.Pow(b.y - c.y, 2));
            double sideB = Math.Sqrt(Math.Pow(a.x - c.x, 2) + Math.Pow(a.y - c.y, 2));
            double sideC = Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));

            return Math.Abs(Math.Pow(sideA, 2) + Math.Pow(sideB, 2) - Math.Pow(sideC, 2)) < 0.0001; 
        }

        public QuadrilateralType getType()
        {

            if(a == null)
            {
                Console.WriteLine("Неможливо визначити, знаючи лише сторони");
                return QuadrilateralType.Any;
            }

            double ac = Math.Sqrt(Math.Pow(c.x - a.x, 2) + Math.Pow(c.y - a.y, 2));
            double bd = Math.Sqrt(Math.Pow(d.x - b.x, 2) + Math.Pow(d.y - b.y, 2));

            if (ab == bc && bc == cd && cd == ad && !isRightAngle(a,b,c))
            {

                return QuadrilateralType.Rhombus;
                
            }
            else if ((ab == cd && bc == ad && DotProduct(b.x - a.x, b.y - a.y, c.x - b.x, c.y - b.y) == 0) ||
                     (ab == bc && cd == ad && DotProduct(b.x - a.x, b.y - a.y, c.x - d.x, c.y - d.y) == 0))
            {
                return QuadrilateralType.Rectangle;
            }
            else if (ab == bc && bc == cd && cd == ad && DotProduct(b.x - a.x, b.y - a.y, c.x - d.x, c.y - d.y) == 0)
            {
                return QuadrilateralType.Square;
            }
            else
            {
                return QuadrilateralType.Any;
            }
        }

        private double DotProduct(double x1, double y1, double x2, double y2)
        {
            return x1 * x2 + y1 * y2;
        }


    }

    interface QuadrilateralBySides {

        public double perimeter();

        public double area();
        
    }

    interface QuadrilateralByPoints
    {

        public QuadrilateralType getType();

    }

    public class Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public enum QuadrilateralType
    {
        Square,
        Rectangle,
        Rhombus,
        Any
    }
}
