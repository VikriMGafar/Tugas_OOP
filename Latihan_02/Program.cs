using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Latihan_02
{
    abstract class BentukBenda
    {
        protected double luas;
        public abstract double Luas();

        public double kalidua(double satu)
        {
            double dobel = satu * 2;
            return dobel;
        }
    }

    class SegiTiga : BentukBenda
    {
        double alas, tinggi;
        double luassegitiga;
        double luassegitiga2;
        public SegiTiga(double LebarAlas, double Tinggi)
        {
            alas = LebarAlas;
            tinggi = Tinggi;
            luassegitiga = Luas();
            luassegitiga2 = kalidua(luassegitiga);
        }

        public override double Luas()
        {
            luas = alas * tinggi / 2.0;
            return luas;
        }

        public override string ToString()
        {
            string hasil = "Segi Tiga"
                + "\n\tAlas\t: " + alas
                + "\n\tTinggi\t: " + tinggi
                + "\n\tLuas\t: " + luassegitiga
                + "\n\tLuas kali 2\t: " + luassegitiga2;

            return hasil;
        }
    }

    class SegiEmpat : BentukBenda
    {
        double panjang, lebar;
        public SegiEmpat(double Panjang, double Lebar)
        {
            panjang = Panjang;
            lebar = Lebar;
            luas = Luas();
        }

        public override double Luas()
        {
            luas = panjang * lebar;
            return luas;
        }

        public override string ToString()
        {
            string hasil = "Segi Empat"
                + "\n\tPanjang\t: " + panjang
                + "\n\tLebar\t: " + lebar
                + "\n\tLuas\t: " + luas;
            return hasil;

        }
    }

    class lingkaran : BentukBenda
    {
        double JariJari;

        public lingkaran(double jariJari)
        {
            JariJari = jariJari;
            luas = Luas();
        }

        public override double Luas()
        {
            luas = 0.5 * Math.PI * (JariJari * JariJari);
            return luas;
        }

        public override string ToString()
        {
            string hasil = "Lingkaran"
                + "\n\tJari - Jari\t: " + JariJari
                + "\n\tLuas\t: " + luas;
            return hasil;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SegiTiga segi3 = new SegiTiga(2.4, 2.5);
            Console.WriteLine(segi3);
            Console.ReadKey();

            SegiEmpat segi4 = new SegiEmpat(2.0, 4.5);
            Console.WriteLine(segi4);
            Console.ReadKey();

            lingkaran lingkaran = new lingkaran(14);
            Console.WriteLine(lingkaran);
            Console.ReadKey();

        }
    }
}