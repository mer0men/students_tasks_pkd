using System;

namespace fefu;

public class Polar_Num
{
    public double r;
    public double angle;

    public Polar_Num(double r, double angle)
    {
        this.r = r;
        this.angle = angle;

    }
    public static Polar_Num operator +(Polar_Num a, Polar_Num b)
    {
        Complex_Num a1 = ToComplex(a);
        Complex_Num b1 = ToComplex(b);
        Complex_Num c = a1 + b1;
        return Complex_Num.ToPolar(c);
    }
    public static Polar_Num operator -(Polar_Num a, Polar_Num b)
    {
        Complex_Num a1 = ToComplex(a);
        Complex_Num b1 = ToComplex(b);
        Complex_Num c = a1 - b1;
        return Complex_Num.ToPolar(c);
    }
    public static Polar_Num operator *(Polar_Num a, Polar_Num b)
    {
        Complex_Num a1 = ToComplex(a);
        Complex_Num b1 = ToComplex(b);
        Complex_Num c = a1 * b1;
        return Complex_Num.ToPolar(c);
    }
    public static Polar_Num operator /(Polar_Num a, Polar_Num b)
    {
        Complex_Num a1 = ToComplex(a);
        Complex_Num b1 = ToComplex(b);
        Complex_Num c = a1 / b1;
        return Complex_Num.ToPolar(c);
    }
    public static Polar_Num Pow(Polar_Num a, int num)
    {
        Complex_Num a1 = ToComplex(a);
        Complex_Num c = Complex_Num.Pow(a1, num);
        return Complex_Num.ToPolar(c);
    }
    public static string ToString(Polar_Num a)
    {
        string s = $"({a.r} ; {a.angle})";
        return s;
    }
    public static Complex_Num ToComplex(Polar_Num a)
    {
        double real, img;
        real = Math.Round(a.r * Math.Cos((a.angle * Math.PI) / 180), 5);
        img = Math.Round(a.r * Math.Sin((a.angle * Math.PI) / 180), 5);
        return new Complex_Num(real, img);
    }


}
public class Complex_Num
{
    public double real;
    public double img;


    public Complex_Num(double real, double img)
    {
        this.real = real;
        this.img = img;
    }
    public static Complex_Num operator +(Complex_Num a, Complex_Num b)
    {
        return new Complex_Num(Math.Round(a.real + b.real,5), Math.Round(a.img + b.img,5));
    }
    public static Complex_Num operator -(Complex_Num a, Complex_Num b)

    {
        return new Complex_Num(Math.Round(a.real - b.real,5), Math.Round(a.img - b.img,5));
    }
    public static Complex_Num operator *(Complex_Num a, Complex_Num b)
    {
        return new Complex_Num(Math.Round(a.real * b.real - a.img * b.img,5), Math.Round(a.real * b.img + b.real * a.img,5));
    }
    public static Complex_Num operator /(Complex_Num a, Complex_Num b)
    {
        return new Complex_Num(Math.Round((a.real * b.real + a.img * b.img) / (b.real * b.real + b.img * b.img),5),
            Math.Round((b.real * a.img - a.real * b.img) / (b.real * b.real + b.img * b.img),5));
    }
    public static Complex_Num Pow(Complex_Num a, double num)
    {
        double r, fi, real, img;
        r = Math.Round(Math.Pow(Math.Sqrt(a.real * a.real + a.img * a.img),num),5);
        fi = Math.Atan(a.img / a.real);
        real = Math.Round(Math.Cos(fi * num)*r,5);
        img = Math.Round(Math.Sin(fi * num)*r,5);
        return new Complex_Num(real, img);
    }
    public static string To_String(Complex_Num a)
    {
        string s;
        if (a.img == 0)
        {
            s = $"{a.real}";
        }
        else if (a.real == 0)
        {
            if(a.img == 1)
            {
                s = "i";
            }
            else if(a.img == -1)
            {
                s = "-i";
            }
            else
            {
                s = $"{a.img}i";
            }
        }
        else if (a.img >= 1)
        {
            if (a.img == 1)
            {
                s = $"{a.real} + i";
            }
            else
            {
                s = $"{a.real} + {a.img}i";
            }
        }
        else
        {
            if (a.img == -1)
            {
                s = $"{a.real} - i";
            }
            else
            {
                s = $"{a.real} - {Math.Abs(a.img)}i";
            }
        }
        return s;
    }
    public static Polar_Num ToPolar(Complex_Num a)
    {
        double r = Math.Round(Math.Sqrt(a.real * a.real + a.img * a.img),5);
        double angle = Math.Round((Math.Atan(a.img / a.real) * 180)/Math.PI,5);
        if (double.IsNaN(angle))
        {
            a.real = 0;
        }
        else if (a.real < 0 && a.img > 0 || a.real < 0 && a.img < 0)
        {
            angle = 180 + angle;
        }
        else if (a.real > 0 && a.img < 0)
        {
            angle = 360 + angle;
        }
        return new Polar_Num(r, angle);
    }
}
class MainClass
{
    public static void Main()
    {
    }
}
