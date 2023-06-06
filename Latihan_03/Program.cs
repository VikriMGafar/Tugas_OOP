using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latihan_3
{
    abstract class BentukBenda
    {
        static int jumlahObjek = 0;
        protected double luas;
        public abstract double Luas();
        public BentukBenda()
        {
            jumlahObjek++;
        }

        public static int getJumlahObjek() { return jumlahObjek; }
    }

    class SegiTiga : BentukBenda
    {
        static int jumlahObjek = 0;
        int nomorObjek;
        public double alas, tinggi;

        //// <summary>
        //// Mengambil jumlah objek yang telah dibuat oleh SegiTiga
        //// <summary>

        public static int JumlahObjek
        {
            get { return jumlahObjek; }
        }

        //// <summary>
        //// Constructor ini akan membentuk objek segiTiga dengan 2 buah paraMeter
        //// <summary>
        //// <param name = "LebarAlas"> Ini merupakan lebar alas dari segitiga bertipa pecahan </param>
        //// <param name = "Tinggi"> Tinggi segi tiga bertipe pecahan juga.</param>

        public SegiTiga(double LebarAlas, double Tinggi)
        {
            jumlahObjek++;
            nomorObjek = jumlahObjek;
            alas = LebarAlas;
            tinggi = Tinggi;
            luas = Luas();
        }
        //// <summary>
        //// Membuat objek segitiga dengan lebar alas 20 dan tinggi 50
        //// <summary>

        public SegiTiga() : this(20, 50) { }

        //// <summary>
        //// SegiTiga yang akan dibuat merpakan segitiga sama-sisi
        //// <summary>
        //// <param name = "sisi"> Panjang salah satu sisi bernilai pecahan</param>

        public SegiTiga(double sisi) : base()
        {
            jumlahObjek++;
            nomorObjek = jumlahObjek;
            alas = sisi;
            double sudutRadian = 30.0 / 180.0 * Math.PI;
            tinggi = sisi * Math.Cos(sudutRadian);
            luas = Luas();
        }

        public override double Luas()
        {
            luas = alas * tinggi / 2;
            return luas;
        }

        public override string ToString()
        {
            string hasil = "\nSegi Tiga ke " + nomorObjek;
            hasil += "\n\tLebar Alas\t: " + alas;
            hasil += "\n\tTinggi\t: " + tinggi;
            hasil += "\n\tLuas Segi Tiga\t: " + Luas();

            return hasil;
        }
    }

    class SegiEmpat : BentukBenda
    {
        static int jumlahObjek = 0;
        int noObjek;
        public double panjang, lebar;

        public static int JumlahObjek
        {
            get { return jumlahObjek; }
        }

        public SegiEmpat(double panjang, double lebar)
        {
            jumlahObjek++;
            noObjek = jumlahObjek;
            this.panjang = panjang;
            this.lebar = lebar;
            luas = Luas();

        }

        public SegiEmpat() : this(5, 6) { }

        public SegiEmpat(double sisi)
        {
            jumlahObjek++;
            noObjek = jumlahObjek;
            panjang = sisi;
            lebar = sisi;
            luas = Luas();
        }

        public override double Luas()
        {
            luas = panjang * lebar;
            return luas;
        }

        public override string ToString()
        {
            string hasil = "\nSegi empat ke " + noObjek;
            hasil += "\n\tPanjang\t: " + panjang;
            hasil += "\n\tLebar\t: " + lebar;
            hasil += "\n\tLuas Segi4\t: " + Luas();

            return hasil;
        }



    }

    class Lingkaran : BentukBenda
    {
        static int jumlahObjek = 0;
        int noObjek;
        public double jariJari;

        public static int JumlahObjek
        {
            get { return jumlahObjek; }
        }

        public Lingkaran(double jariJari)
        {
            jumlahObjek++;
            noObjek = jumlahObjek;
            this.jariJari = jariJari;
            luas = Luas();

        }

        public Lingkaran() : this(7.2) { }


        public override double Luas()
        {
            luas = 0.5 * Math.PI * (jariJari * jariJari);
            return luas;
        }

        public override string ToString()
        {
            string hasil = "\nLingkaran ke " + noObjek;
            hasil += "\n\tJari-Jari\t: " + jariJari;
            hasil += "\n\tLuas Lingkaran\t: " + Luas();

            return hasil;
        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            SegiTiga sg3a = new SegiTiga(6, 10);
            Console.WriteLine(sg3a);
            SegiTiga sg3b = new SegiTiga();
            Console.WriteLine(sg3b);
            SegiTiga sg3c = new SegiTiga(15);
            Console.WriteLine(sg3c);


            Console.WriteLine("\n\nJumlah Segi Tiga: " + SegiTiga.JumlahObjek + " buah");
            Console.WriteLine("\nJumlah bentuk benda: " + BentukBenda.getJumlahObjek() + " buah");
            Console.ReadKey();


            SegiEmpat sg4a = new SegiEmpat(10.3, 4.6);
            Console.WriteLine(sg4a);
            SegiEmpat sg4b = new SegiEmpat();
            Console.WriteLine(sg4b);
            SegiEmpat sg4c = new SegiEmpat(8);
            Console.WriteLine(sg4c);

            Console.WriteLine("\n\nJumlah Segi Empat: " + SegiEmpat.JumlahObjek + " buah");
            Console.WriteLine("\nJumlah bentuk benda: " + BentukBenda.getJumlahObjek() + " buah");
            Console.ReadKey();

            Lingkaran lingkaran1 = new Lingkaran(4.6);
            Console.WriteLine(lingkaran1);
            Lingkaran lingkaran2 = new Lingkaran();
            Console.WriteLine(lingkaran2);

            Console.WriteLine("\n\nJumlah Lingkaran: " + Lingkaran.JumlahObjek + " buah");
            Console.WriteLine("\nJumlah bentuk benda: " + BentukBenda.getJumlahObjek() + " buah");
            Console.ReadKey();
        }
    }
}