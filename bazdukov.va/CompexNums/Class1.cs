using System;
using System.Net.Sockets;

namespace CompexNums
{
    public class Complex
    {
        private float real;
        private float img;

        public Complex(float _real, float _img)
        {
            real = _real;
            img = _img;
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
            float real = first.real * second.real - first.img * second.img;
            float img = first.real * second.img + first.img * second.real;
            return new Complex(real, img);
        }
        public static Complex operator /(Complex first, Complex second)
        {
            float real = (first.real * second.real + first.img * second.img) / (second.real * second.real + second.img * second.img);
            float img = (second.real * first.img - first.real * second.img) / (second.real * second.real + second.img * second.img);
            return new Complex(real, img);
        }
        
    }
}