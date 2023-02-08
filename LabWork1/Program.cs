using System;

namespace LabWork1
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                int dimension;
                int menu;
                Console.WriteLine("2D [2] or 3D [3]");
                dimension = Convert.ToInt32(Console.ReadLine());

                if (dimension == 2)
                {
                    Vector2D vector2D = new Vector2D();
                    while (true)
                    {
                        Vector2D second_vector2D = new Vector2D();
                        Console.WriteLine("[1] - input");
                        Console.WriteLine("[2] - print");
                        Console.WriteLine("[3] - normolize");
                        Console.WriteLine("[4] - compare");
                        menu = Convert.ToInt32(Console.ReadLine());
                        switch (menu)
                        {
                            case 1:
                                vector2D.input();
                                break;
                            case 2:
                                vector2D.print();
                                break;
                            case 3:
                                vector2D.normolize();
                                break;
                            case 4:
                                second_vector2D.input();
                                vector2D.compare(second_vector2D);
                                break;
                            default:
                                Console.WriteLine("Wrong number");
                                break;
                        }
                    }
                }
                else if (dimension == 3)
                {
                    Vector3D vector3D = new Vector3D();
                    while (true)
                    {
                        Vector3D second_vector3D = new Vector3D();
                        Console.WriteLine("[1] - input");
                        Console.WriteLine("[2] - print");
                        Console.WriteLine("[3] - normolize");
                        Console.WriteLine("[4] - compare");
                        menu = Convert.ToInt32(Console.ReadLine());
                        switch (menu)
                        {
                            case 1:
                                vector3D.input();
                                break;
                            case 2:
                                vector3D.print();
                                break;
                            case 3:
                                vector3D.normolize();
                                break;
                            case 4:
                                second_vector3D.input();
                                vector3D.compare(second_vector3D);
                                break;
                            default:
                                Console.WriteLine("Wrong number");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong dimension");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error : " + exception.Message);
            }

        }


    }

    class Vector2D
    {
        protected double x;
        protected double y;
        protected double length;

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public double getLength()
        {
            return length;
        }

        protected virtual void countLength()
        {
            length = Math.Sqrt(x * x + y * y);
        }

        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
            countLength();
        }

        public Vector2D()
        {
            x = 0;
            y = 0;
            length = 0;
        }
        public Vector2D(Vector2D vector2D)
        {
            x = vector2D.x;
            y = vector2D.y;
            length = vector2D.length;
        }

        public virtual void print()
        {
            Console.WriteLine("Coordinate : ( " + x + " ; " + y + " );");
            Console.WriteLine("Length : " + length + ";");
        }

        public virtual void input()
        {
            try
            {
                Console.WriteLine("Enter X: ");
                double x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Y: ");
                double y = Convert.ToInt32(Console.ReadLine());
                this.x = x;
                this.y = y;
                countLength();
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Error : " + exception.Message);
            }
        }

        public virtual void normolize()
        {
            x = x / length;
            y = y / length;
            length = 1;
        }

        public virtual void compare(Vector2D second)
        {
            if (length > second.length)
            {
                Console.WriteLine("Vector is bigger");
            }
            else if (length < second.length)
            {
                Console.WriteLine("Vector is smaller");
            }
            else
            {
                Console.WriteLine("Vectors are the same");
            }
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x - v2.x, v1.y - v2.y);
        }

        public static double operator *(Vector2D v1, Vector2D v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }
    }

    class Vector3D : Vector2D
    {
        protected double z;

        public double getZ()
        {
            return z;
        }

        protected override void countLength()
        {
            length = Math.Sqrt(x * x + y * y + z * z);
        }

        public override void print()
        {
            Console.WriteLine("Coordinate : ( " + x + " ; " + y + " ; " + z + " );");
            Console.WriteLine("Length : " + length + ";");
        }

        public override void input()
        {
            try
            {
                Console.WriteLine("Enter X: ");
                double x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Y: ");
                double y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Z: ");
                double z = Convert.ToInt32(Console.ReadLine());
                this.x = x;
                this.y = y;
                this.z = z;
                countLength();
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Error : " + exception.Message);
            }
        }

        public override void normolize()
        {
            base.normolize();
            z = z / length;
        }

        public override void compare(Vector2D second)
        {
            base.compare(second);
        }

        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            countLength();
        }

        public Vector3D()
        {
            x = 0;
            y = 0;
            z = 0;
            length = 0;
        }
        public Vector3D(Vector3D vector3D)
        {
            x = vector3D.x;
            y = vector3D.y;
            z = vector3D.z;
            length = vector3D.length;
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static double operator *(Vector3D v1, Vector3D v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }
    }

}
