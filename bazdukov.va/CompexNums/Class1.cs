using System;
using System.Numerics;
using CompexNums;

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

        public Polar ToPolar()
        {
            double value = Math.Sqrt(this.img * this.img + this.real * this.real);
            double angle = 0;
            if (this.real > 0 && this.img >= 0) angle = Math.Atan(this.img / this.real);
            if (this.real > 0 && this.img < 0) angle = Math.Atan(this.img / this.real) + 2 * Math.PI;
            if (this.real < 0) angle = Math.Atan(this.img / this.real) + Math.PI;
            if (this.real == 0 && this.img > 0) angle = Math.PI / 2;
            if (this.real == 0 && this.img < 0) angle = 3 *Math.PI / 2;
            if (this.real == 0 && this.img == 0) angle = 0;
            return new Polar(value, angle);
        }
    }
}

public class Polar
{
    private double value;
    private double angle;

    public Polar(double _value, double _angle)
    {
        value = _value;
        angle = _angle;
    }

    public Complex ToComplex()
    {
        return new Complex(this.value * Math.Cos(angle), this.value * Math.Sin(angle));
    }
    public static Polar operator +(Polar first, Polar second)
    {
        Complex a = first.ToComplex();
        Complex b = second.ToComplex();
        return ((a + b).ToPolar());
    }
    public static Polar operator -(Polar first, Polar second)
    {
        Complex a = first.ToComplex();
        Complex b = second.ToComplex();
        return ((a - b).ToPolar());
    }
    public static Polar operator *(Polar first, Polar second)
    {
        Complex a = first.ToComplex();
        Complex b = second.ToComplex();
        return ((a * b).ToPolar());
    }
    public static Polar operator /(Polar first, Polar second)
    {
        Complex a = first.ToComplex();
        Complex b = second.ToComplex();
        return ((a / b).ToPolar());
    }
}