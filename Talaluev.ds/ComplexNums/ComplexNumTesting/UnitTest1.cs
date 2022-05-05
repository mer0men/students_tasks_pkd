using Microsoft.VisualStudio.TestTools.UnitTesting;
using fefu;
using static System.Math;
namespace ComplexNumTesting
{
    [TestClass]
    public class ComplexNums
    {
        [TestMethod]
        public void Addition1()
        {
            Complex_Num a = new Complex_Num(3, 2);
            Complex_Num b = new Complex_Num(1, 1);
            Complex_Num res = a + b;
            Assert.AreEqual(res.real, 4);
            Assert.AreEqual(res.img, 3);
        }
        [TestMethod]
        public void Addition2()
        {
            Complex_Num a = new Complex_Num(1.5, 3.4);
            Complex_Num b = new Complex_Num(0.4, 12.7);
            Complex_Num res = a + b;
            Assert.AreEqual(res.real, 1.9);
            Assert.AreEqual(res.img, 16.1);
        }
        [TestMethod]
        public void Addition3()
        {
            Complex_Num a = new Complex_Num(Sqrt(6), 34.5);
            Complex_Num b = new Complex_Num(8999.123, Sqrt(3));
            Complex_Num res = a + b;
            Assert.AreEqual(res.real, 9001.57249);
            Assert.AreEqual(res.img, 36.23205);
        }
        [TestMethod]
        public void substraction1()
        {
            Complex_Num a = new Complex_Num(3, 2);
            Complex_Num b = new Complex_Num(1, 1);
            Complex_Num res = a - b;
            Assert.AreEqual(res.real, 2);
            Assert.AreEqual(res.img, 1);
        }
        [TestMethod]
        public void substraction2()
        {
            Complex_Num a = new Complex_Num(-201, 48);
            Complex_Num b = new Complex_Num(-1234, -678);
            Complex_Num res = a - b;
            Assert.AreEqual(res.real, 1033);
            Assert.AreEqual(res.img, 726);
        }
        [TestMethod]
        public void substraction3()
        {
            Complex_Num a = new Complex_Num(Sqrt(12), Sqrt(98));
            Complex_Num b = new Complex_Num(789.154, -123.987);
            Complex_Num res = a - b;
            Assert.AreEqual(res.real, -785.6899);
            Assert.AreEqual(res.img, 133.88649);
        }
        [TestMethod]
        public void multiplication1()
        {
            Complex_Num a = new Complex_Num(18, 24);
            Complex_Num b = new Complex_Num(12 ,-19);
            Complex_Num res = a * b;
            Assert.AreEqual(res.real, 672);
            Assert.AreEqual(res.img, -54);
        }
        [TestMethod]
        public void multiplication2()
        {
            Complex_Num a = new Complex_Num(15.48, 14.96);
            Complex_Num b = new Complex_Num(78.1, 21.4567);
            Complex_Num res = a * b;
            Assert.AreEqual(res.real, 887.99577);
            Assert.AreEqual(res.img, 1500.52572);
        }
        [TestMethod]
        public void multiplication3()
        {
            Complex_Num a = new Complex_Num(-78.123, Sqrt(14));
            Complex_Num b = new Complex_Num(Sqrt(5), -71.6);
            Complex_Num res = a * b;
            Assert.AreEqual(res.real, 93.21433);
            Assert.AreEqual(res.img, 5601.9734);
        }
        [TestMethod]
        public void division1()
        {
            Complex_Num a = new Complex_Num(15,7);
            Complex_Num b = new Complex_Num(6,4);
            Complex_Num res = a / b;
            Assert.AreEqual(res.real, 2.26923);
            Assert.AreEqual(res.img, -0.34615);
        }
        [TestMethod]
        public void division2()
        {
            Complex_Num a = new Complex_Num(-45.12, 0);
            Complex_Num b = new Complex_Num(56 , -78.65);
            Complex_Num res = a / b;
            Assert.AreEqual(res.real, -0.27105);
            Assert.AreEqual(res.img, -0.38069);
        }
        [TestMethod]
        public void division3()
        {
            Complex_Num a = new Complex_Num(Sqrt(13), 4561);
            Complex_Num b = new Complex_Num(15, Sqrt(8));
            Complex_Num res = a / b;
            Assert.AreEqual(res.real, 55.59888);
            Assert.AreEqual(res.img, 293.58284);
        }
        [TestMethod]
        public void pow1()
        {
            Complex_Num a = new Complex_Num(5, 4);
            double n = 3;
            Complex_Num res = Complex_Num.Pow(a, n);
            Assert.AreEqual(res.real, -115);
            Assert.AreEqual(res.img, 236);
        }
        [TestMethod]
        public void pow2()
        {
            Complex_Num a = new Complex_Num(-8, Sqrt(8));
            double n = 8;
            Complex_Num res = Complex_Num.Pow(a, n);
            Assert.AreEqual(res.real, -24506368);
            Assert.AreEqual(res.img, -11029146.10282);
        }
        [TestMethod]
        public void pow3()
        {
            Complex_Num a = new Complex_Num(12.8, Sqrt(12));
            double n = 4;
            Complex_Num res = Complex_Num.Pow(a, n);
            Assert.AreEqual(res.real, 15191.0656);
            Assert.AreEqual(res.img, 26930.64649);
        }
        [TestMethod]
        public void to_string1()
        {
            Complex_Num a = new Complex_Num(-4, 0);
            string res = Complex_Num.To_String(a);
            Assert.AreEqual(res, "-4");
        }
        [TestMethod]
        public void to_string2()
        {
            Complex_Num a = new Complex_Num(0, 15);
            string res = Complex_Num.To_String(a);
            Assert.AreEqual(res, "15i");
        }
        [TestMethod]
        public void to_string3()
        {
            Complex_Num a = new Complex_Num(12, -Sqrt(5));
            string res = Complex_Num.To_String(a);
            Assert.AreEqual(res, "12 - 2,23606797749979i");
        }
        [TestMethod]
        public void to_string4()
        {
            Complex_Num a = new Complex_Num(1, -1);
            string res = Complex_Num.To_String(a);
            Assert.AreEqual(res, "1 - i");
        }
        [TestMethod]
        public void to_polar1()
        {
            Complex_Num a = new Complex_Num(1, -1);
            Polar_Num res = Complex_Num.ToPolar(a);
            Assert.AreEqual(res.r, 1.41421);
            Assert.AreEqual(res.angle, 315);
        }
        [TestMethod]
        public void to_polar2()
        {
            Complex_Num a = new Complex_Num(18,-78);
            Polar_Num res = Complex_Num.ToPolar(a);
            Assert.AreEqual(res.r, 80.04998);
            Assert.AreEqual(res.angle, 282,995);
        }
        [TestMethod]
        public void to_polar3()
        {
            Complex_Num a = new Complex_Num(15, -Sqrt(4));
            Polar_Num res = Complex_Num.ToPolar(a);
            Assert.AreEqual(res.r, 15.13275);
            Assert.AreEqual(res.angle, 352, 40536);
        }
    }
    [TestClass]
    public class PolarNums
    {
        [TestMethod]
        public void to_string1()
        {
            Polar_Num a = new Polar_Num(5,39);
            string res = Polar_Num.ToString(a);
            Assert.AreEqual(res , "(5 ; 39)");
        }
        [TestMethod]
        public void to_string2()
        {
            Polar_Num a = new Polar_Num(0, -39);
            string res = Polar_Num.ToString(a);
            Assert.AreEqual(res, "(0 ; -39)");
        }
        [TestMethod]
        public void to_string3()
        {
            Polar_Num a = new Polar_Num(-12, 0);
            string res = Polar_Num.ToString(a);
            Assert.AreEqual(res, "(-12 ; 0)");
        }
        [TestMethod]
        public void to_complex1()
        {
            Polar_Num a = new Polar_Num(1.41421, 315);
            Complex_Num res = Polar_Num.ToComplex(a);
            Assert.AreEqual(res.real, 1);
            Assert.AreEqual(res.img, -1);
        }
        [TestMethod]
        public void to_complex2()
        {
            Polar_Num a = new Polar_Num(80.34 , 13.53);
            Complex_Num res = Polar_Num.ToComplex(a);
            Assert.AreEqual(res.real, 78.11037);
            Assert.AreEqual(res.img, 18.7959);
        }
        [TestMethod]
        public void to_complex3()
        {
            Polar_Num a = new Polar_Num(Sqrt(5), 80);
            Complex_Num res = Polar_Num.ToComplex(a);
            Assert.AreEqual(res.real, 0.38829);
            Assert.AreEqual(res.img, 2.2021);
        }
    }
}