using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Latihan_06
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

        public void kurangiMahasiwa()
        {
            JumlahMahasiswa--;
        }
    }

    class Dosen
    {
        public Dosen()
        {

        }
    }
    class Mahasiswa
    {
        public string NamaMahasiswa { get; set; }
        public string NomorIndukMahasiswa { get; set; }
        //public string TempatTanggalLahir { get; set; }
        public string TempatLahir { get; set; }
        public DateTime TanggalLahir { get; set; }
        public Prodi ProgramStudi { get; set; }
        public Dosen PembimbingAkademik { get; set; }
        static public int JumlahMahasiswa { get; private set; } = 0;

        public Mahasiswa(string namaMahasiswa)
        {
            JumlahMahasiswa++;
            NamaMahasiswa = namaMahasiswa;
            Console.WriteLine("Mahasiswa ditambahkan, nama " + namaMahasiswa);
        }

        public Mahasiswa(string namaMahasiswa, Prodi programStudi) : this(namaMahasiswa)
        {
            ProgramStudi = programStudi;
            ProgramStudi.tambahMahasiswa();
            Console.WriteLine("\tProgram Studi: " + programStudi.NamaProdi);
        }

        public Mahasiswa(string namaMahasiswa, Prodi programStudi, string nomorInduk, string tempatLahir, DateTime tanggalLahir) : this(namaMahasiswa, programStudi)
        {
            NomorIndukMahasiswa = nomorInduk;
            TempatLahir = tempatLahir;
            TanggalLahir = tanggalLahir;

            Console.WriteLine("\tNomor Induk Mahasiswa: " + NomorIndukMahasiswa);
            //Console.WriteLine("\tTempat Tanggal lahir: " + TempatTanggalLahir);
            Console.WriteLine("\tTempat Tanggal lahir: " + tempatLahir + ", " + tanggalLahir + "\n\n");
        }
    }

    class Program
    {
        static void bacaFileMahasiswa(string fileMahasiswa, Prodi prodi,Dictionary<int, Mahasiswa> mahasiswa)
        {
            const string folderOutput ="../../../output/";
            if (!Directory.Exists(folderOutput))
            {
                Directory.CreateDirectory(folderOutput);
            }

            string fileOutput = folderOutput + "Mahasiswa.CSV";
            //string hasil = "No., NIM, Nama Mahasiswa, Tempat Lahir, Tanggal Lahir\n";
            string hasil = "No., NIM, Nama Mahasiswa, Tempat Lahir, Tanggal Lahir, program Studi\n";
            try
            {
                string mhs = File.ReadAllText(fileMahasiswa);
                string[] baris = mhs.Split("\n");
                for(int i  = 0; i < baris.Length; i++)
                {
                    string[] kolom = baris[i].Trim().Split("|");
                    
                    string[] str_ttl = kolom[2].Split(",");
                    DateTime ttl = DateTime.Parse(str_ttl[1]);            
                    Mahasiswa m = new Mahasiswa(kolom[1], prodi, kolom[0], str_ttl[0] ,ttl);

                    mahasiswa.Add(i, m);
                    hasil += (i + 1) + ", " + kolom[0] + ", " + kolom[1] + ", " + str_ttl[0] +", "+ ttl +", " + prodi.NamaProdi +"\n" ;
                }
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            File.WriteAllText(fileOutput, hasil );
            fileOutput = Path.GetFullPath(fileOutput);
            Console.WriteLine("\nOutput telah ditulis ke file " + fileOutput);
        }

        static void Main(string[] args)
        {
            Dictionary<int, Mahasiswa> mahasiswa = new Dictionary<int, Mahasiswa>();
            Prodi psti = new Prodi("Teknik Informatika");
            bacaFileMahasiswa("../../../mahasiswa_psti.txt", psti, mahasiswa);
            Console.ReadKey();
        }
    }
}
