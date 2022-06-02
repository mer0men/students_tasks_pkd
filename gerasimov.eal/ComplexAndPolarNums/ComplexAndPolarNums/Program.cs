using System;

namespace fefu
{
    class ComplexNum
    {
        public double real;
        public double imaginary;
    
        public ComplexNum(double r, double i)
        {
            this.real = r;
            this.imaginary = i;
        }
        public static ComplexNum operator + (ComplexNum a, ComplexNum b) 
            => new ComplexNum(a.real + b.real, a.imaginary + b.imaginary);
        public static ComplexNum operator - (ComplexNum a, ComplexNum b)
            => new ComplexNum(a.real - b.real, a.imaginary - b.imaginary);
        public static ComplexNum operator * (ComplexNum a, ComplexNum b)
            => new ComplexNum(a.real * b.real - a.imaginary * b.imaginary,  a.real * b.imaginary + a.imaginary * b.real);
        public static ComplexNum operator / (ComplexNum a, ComplexNum b)
            => new ComplexNum((a.real * b.real + a.imaginary * b.imaginary)/(b.real*b.real + b.imaginary*b.imaginary),(b.real*a.imaginary - a.real*b.imaginary)/b.real*b.real + b.imaginary*b.imaginary);
        public static ComplexNum Pow (ComplexNum a,  double num)
        {
            double radius, angle, real, imaginary;
            radius = Math.Round(Math.Pow(Math.Sqrt(a.real * a.real + a.imaginary * a.imaginary), num), 3);
            angle = Math.Atan(a.imaginary / a.real);
            real = Math.Round(Math.Cos(angle * num) * radius, 3);
            imaginary = Math.Round(Math.Sin(angle * num) * radius, 3);
            return new ComplexNum(real, imaginary);
        }
        public static  string ToString(ComplexNum a)
        {
            string z;
            if(a.real == 0)
            {
                if (a.imaginary == 1)
                {
                    z = "i";
                }
                else if (a.imaginary == -1)
                {
                    z = "-i";
                }
                else if (a.imaginary > 1 && a.imaginary < 0)
                {
                    z = $"{-a.imaginary}i";
                }
                else
                {
                    z = $"{a.imaginary}i";
                }
            }
            else if (a.imaginary >= 1)
            {
                if (a.imaginary == 1)
                {
                    z = $"{a.real} + i";
                }
                else
                {
                    z = $"{a.real} + {a.imaginary}i";
                }
            }
            else if (a.imaginary == 0)
            {
                z = $"{a.real}";
            }
            else
            {
                if(a.imaginary == -1)
                {
                    z = $"{a.real} - i";
                }
                else
                {
                    z = $"{a.real} + {a.imaginary}i";
                }
            }
            return z;
        }  
        public static PolarNum To_Polar(ComplexNum a)
        {
            double radius = Math.Round(Math.Sqrt(a.real * a.real + a.imaginary * a.imaginary), 3);
            double angle = Math.Round((Math.Atan(a.imaginary / a.real) * 180) / Math.PI, 3);
            if (double.IsNaN(angle))
            {
                a.real = 0;
            }
            else if (a.real < 0 && a.imaginary > 0 || a.real < 0 && a.imaginary < 0)
            {
                angle = 180 + angle;
            }
            else if (a.real > 0 && a.imaginary < 0)
            {
                angle = 360 + angle;
            }
            return new PolarNum(radius, angle);
        }
    }
    class PolarNum
    {
        public double radius;
        public double angle;
        public PolarNum(double r, double a)
        {
            this.radius = r;
            this.angle = a;
        }
        public static ComplexNum To_Complex(PolarNum b)
        {
            double real, imaginary;
            real = Math.Round(b.radius * Math.Cos((b.angle * Math.PI) / 180), 3);
            imaginary = Math.Round(b.radius * Math.Sin((b.angle * Math.PI) / 180), 3);
            return new ComplexNum(real, imaginary);
        }
        public static PolarNum operator + (PolarNum b, PolarNum x)
        {
            ComplexNum b_b = To_Complex(b);
            ComplexNum x_b = To_Complex(x);
            ComplexNum y = b_b + x_b;
            return ComplexNum.To_Polar(y);

        }
        public static PolarNum operator - (PolarNum b, PolarNum x)
        {
            ComplexNum b_b = To_Complex(b);
            ComplexNum x_b = To_Complex(x);
            ComplexNum y = b_b - x_b;
            return ComplexNum.To_Polar(y);

        }
        public static PolarNum operator * (PolarNum a, PolarNum b)
             => new PolarNum(a.radius * b.radius, a.angle + b.angle);
        public static PolarNum operator / (PolarNum a, PolarNum b)
            => new PolarNum(a.radius / b.radius, a.angle - b.angle);
        public static PolarNum Pow (PolarNum a, double num)
        {
            ComplexNum a_a = To_Complex(a);
            ComplexNum c = ComplexNum.Pow(a_a, num);
            return ComplexNum.To_Polar(c);
        }
        public static string ToString(PolarNum x)
        {
            string z = $"({x.radius},{x.angle})";
            return z;
        }
    }
    


    class MainClass
    {
        public static void Main()
        {
            float a, b;
            PolarNum num_a = new PolarNum(43, 36);
            PolarNum num_b = new PolarNum(4, 3);
            Console.WriteLine((num_a + num_b).radius);
            Console.WriteLine((num_a + num_b).angle);
            /*string Selection;
            char Event;

            double real, im;
            double r, angle;

            Console.WriteLine("Select: Complex - C, Polar - P");
            Selection = Console.ReadLine();

            if (Selection == "C")
                Console.WriteLine("Enter complex numbers");
            else
                Console.WriteLine("Enter polar numbers");

            Console.WriteLine("Select event: + - * / Pow Sqrt");
            Event = Convert.ToChar(Console.ReadLine());

            if (Selection == "C" && Event == '+')
            {
                ComplexNum num_a = new ComplexNum(1.5, 3.4);
                ComplexNum num_b = new ComplexNum(0.4, 12.7);
                Console.WriteLine((num_a + num_b).real);
                Console.WriteLine((num_a + num_b).imaginary);
            }
            else if (Selection == "C" && Event == '-')
            {
                ComplexNum num_a = new ComplexNum(3, 2);
                ComplexNum num_b = new ComplexNum(1, 1);

                Console.WriteLine($"Radius: {(num_a - num_b).real}");
                Console.WriteLine($"Angle: {(num_a - num_b).imaginary}");
            }
            else if (Selection == "C" && Event == '*')
            {
                ComplexNum num_a = new ComplexNum(3, 2);
                ComplexNum num_b = new ComplexNum(1, 1);

                Console.WriteLine($"Radius: {(num_a * num_b).real}");
                Console.WriteLine($"Angle: {(num_a * num_b).imaginary}");*/
        }
        }
    }
}
