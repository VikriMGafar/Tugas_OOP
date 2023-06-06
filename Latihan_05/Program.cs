using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Latihan_05
{
    class Prodi
    {
        public string NamaProdi { get; set; }
        public Dosen Kaprodi { get; set; }
        static public int JumlahProdi { get; private set; } = 0;
        public int JumlahDosen{ get; private set; } = 0;
        public int JumlahMahasiswa{ get; private set; } = 0;

        public Prodi(string namaProdi) {
            JumlahProdi++;
            NamaProdi = namaProdi;
        }

        public Prodi(string NamaProdi, Dosen kaprodi): this(NamaProdi)
        {
            Kaprodi= kaprodi;
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
        public string TempatTanggalLahir { get; set; }
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
        static void BacaFileMahasiswa(string fileMahasiswa,Prodi prodi, Dictionary<int, Mahasiswa> mahasiswa)
        {
            const string folderOutput = "../../../output/";
            if (!Directory.Exists(folderOutput))
            {
                Directory.CreateDirectory(folderOutput);
            }

            string fileOutput = folderOutput + "mahasiswa.CSV";
            string hasil = "No., NIM, Nama Mahasiswa, Tempat Lahir, Tanggal Lahir\n";
            try
            {
                string mhs = File.ReadAllText(fileMahasiswa);
                string[] baris = mhs.Split("\n");
                for (int i = 0; i < baris.Length; i++)
                {
                    //116103001|Reynaldi|Jakarta, 12/05/1998
                    string[] kolom = baris[i].Split("|");
                    Mahasiswa m = new Mahasiswa(kolom[1], prodi, kolom[0], kolom[2]);
                    string[] ttl = kolom[2].Split(",");
                    DateTime date = DateTime.Parse(ttl[1]);

                    Console.WriteLine(date);

                    mahasiswa.Add(i, m);
                    hasil += (i+1) + ", " + kolom[0] + ", " + kolom[1] + ", " + prodi.NamaProdi +", " + ttl[0] +", "+ date+ "\n";
                }

            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            File.WriteAllText(fileOutput, hasil);
            fileOutput = Path.GetFullPath(fileOutput);
            Console.WriteLine("\nOutput telah ditulis ke File " + fileOutput);
        }
        static void Main(string[] args)
        {
            Dictionary<int, Mahasiswa> mahasiswa = new Dictionary<int, Mahasiswa>();
            Prodi psti = new Prodi("Teknik Informatika");
            BacaFileMahasiswa("../../../mahasiswa_psti.txt", psti, mahasiswa);
            Console.ReadKey();
        }

    }

}
