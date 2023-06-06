using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace Latihan_04
{
    class Prodi
    {
        public string NamaProdi { get; set; }
        public Dosen Kaprodi { get; set; }
        static public int JumlahProdi { get; private set; } = 0;
        public int JumlahDosen { get; private set; } = 0;
        public int JumlahMahasiswa { get; private set; } = 0;

        public Prodi(string namaProdi)
        {
            JumlahProdi++;
            NamaProdi = namaProdi;
        }

        public Prodi(string NamaProdi, Dosen kaprodi) : this(NamaProdi)
        {
            Kaprodi = kaprodi;
        }
        public void tambahMahasiswa()
        {
            JumlahMahasiswa++;
        }

        public void kurangiMahasiswa()
        {
            JumlahMahasiswa--;
        }
    }

    class Dosen
    {
        //private string nama;
        //public string Nama
        //{
        //    get { return nama; }
        //    set { nama = value; }
        //}
        
        public string NamaDosen { get; set; }
        public string NIP { get; set; }

        static public int JumlahDosen { get; private set; } = 0;

        public Dosen(string namaDosen, string NIP)
        {
            NamaDosen = namaDosen;
            this.NIP = NIP;

        }

        public void tambahDosen()
        {
            JumlahDosen++;
        }

        public void KurangiDosen()
        {
            JumlahDosen--;
        }
    }

    class Mahasiswa
    {
        public string NamaMahasiswa { get; set; } 
        public string NomorIndukMahasiswa { get; set; }
        public string TempatTanggalLahir { get; set; }
        public Prodi ProgramStudi { get; set; }
        public Dosen PembimbingAkademik { get; set; }
        static public int JumlahMahasiswa { get; private set; } = 0;

        public Mahasiswa (string namaMahasiswa) {
            JumlahMahasiswa++;
            NamaMahasiswa= namaMahasiswa;
            Console.WriteLine("Mahasiswa ditambahkan, nama " + namaMahasiswa);
        }

        public Mahasiswa(string namaMahasiswa, Prodi programStudi): this(namaMahasiswa)
        {
            ProgramStudi = programStudi;
            ProgramStudi.tambahMahasiswa();
            Console.WriteLine("\tProgram Studi: " + programStudi.NamaProdi);
        }

        public Mahasiswa(string namaMahasiswa, Prodi programStudi, string nomorInduk, string tempatTanggalLahir) : this(namaMahasiswa, programStudi)
        {
            NomorIndukMahasiswa = nomorInduk;
            TempatTanggalLahir = tempatTanggalLahir;

            Console.WriteLine("\tNomor Induk Mahasiswa: " + NomorIndukMahasiswa);
            Console.WriteLine("\tTempat Tanggal lahir: " + TempatTanggalLahir);
        }
    }   


    class Program
    {
        static int jumlahtotalmhs = 0;
        static void bacaFileMahasiswa(string fileMahasiswa, Prodi prodi, Dictionary<int, Mahasiswa> mahasiswa)
        {
            try
            {
                string mhs = File.ReadAllText(fileMahasiswa);
                string[] baris = mhs.Split("\n");
                for (int i = 0; i < baris.Length; i++)
                {
                    //116103001|Reynaldi|Jakarta, 12/05/1998
                    jumlahtotalmhs = jumlahtotalmhs + 1 ;
                    string[] kolom = baris[i].Split("|");
                    Mahasiswa m = new Mahasiswa(kolom[1], prodi, kolom[0], kolom[2]);
                    mahasiswa.Add(jumlahtotalmhs, m);
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

        }

        static void Main(string[] args)
        {
            Dictionary<int, Mahasiswa> mahasiswa = new Dictionary<int, Mahasiswa>();

            Prodi psti = new Prodi("Teknik Informatika");
            bacaFileMahasiswa("../../../mahasiswa_psti.txt", psti, mahasiswa);


            Prodi HI = new Prodi("Hubungan Internasional");
            bacaFileMahasiswa("../../../mahasiswa_HI.txt", HI, mahasiswa) ;


            Console.ReadKey();
            Console.WriteLine("");
            Console.ReadKey();


        }
            
    }
}

