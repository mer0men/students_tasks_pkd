using System;
namespace CompexNums
{
    public class Complex
    {
        private double real;
        private double img;

        public Complex(double real, double img)
        {
            real = real;
            img = img;
        }
        public static Complex operator +(Complex first, Complex second)
        {
            return new Complex(first.real + second.real, first.img + second.img);
        }
        public static Complex operator -(Complex first, Complex second)
        {
            return new Complex(first.real - second.real, first.img - second.img);
        }
        public static Complex operator *(Complex first, Complex second)
        {
            double real = first.real * second.real - first.img * second.img;
            double img = first.real * second.img + first.img * second.real;
            return new Complex(real, img);
        }
        public static Complex operator /(Complex first, Complex second)
        {
            double real = (first.real * second.real + first.img * second.img) / (second.real * second.real + second.img * second.img);
            double img = (second.real * first.img - first.real * second.img) / (second.real * second.real + second.img * second.img);
            return new Complex(real, img);
        }
        public string ToComplexString()
        {
            return this.real > 0 ? $"{this.real}+{this.img}i" : $"{this.real}{this.img}i";
        }
        public Complex ComplexPow(double n)
        {
           double module = Math.Sqrt(this.real * this.real + this.img * this.img);
           double argue = Math.Atan(this.img / this.real);
           Complex z = new Complex(module * Math.Cos(argue), module * Math.Sin(argue));
           return new Complex(z.real * n, z.img * n);
        }
        
    }
}

public class Polar
{
    private double r;
    private double angle;

    public Polar(double _r, double _angle)
    {
        r = _r;
        angle = _angle;
    }
    
}