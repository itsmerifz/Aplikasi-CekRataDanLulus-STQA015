using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PAWFinalTest_Program
{
    /// <summary>
    /// Main Class
    /// </summary>
    class ProgramUtama
    {
        public string nama;
        public int kelas;
        public double rata;
        public double rataMTK;
        public double rataBInd;
        public double rataBIng;
        public double rataAgm;
        public double rataSB;
        public string[] mapel = { "Matematika", "Bahasa Indonesia", "Bahasa Inggris", "Agama", "Seni Budaya" };
        public List<double> hadir = new List<double>();
        public List<double> tugas = new List<double>();
        public List<double> uas = new List<double>();

        /// <summary>
        /// Method mengisi data variabel
        /// </summary>
        /// <remarks>Method digunakan untuk mengisi data untuk digunakan pada method lainnya</remarks>
        public void isiData()
        {
            Console.Clear();
            Console.WriteLine("=================================================================");
            Console.WriteLine("\tFORM DATA SISWA");
            Console.WriteLine("=================================================================");
            Console.Write("Masukkan Nama Lengkap Siswa : ");
            nama = Console.ReadLine();
            Console.Write("Masukkan Kelas Siswa : ");
            kelas = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        /// <summary>
        /// Method mengisi nilai
        /// </summary>
        /// <remarks>Method digunakan untuk mengisi nilai siswa</remarks>
        public void isiNilai()
        {
            Console.Clear();
            try
            {
                double a, b, c;

                Console.WriteLine("=================================================================");
                Console.WriteLine("\tFORM NILAI SISWA");
                Console.WriteLine("=================================================================");
                for (int i = 0; i < mapel.Length; i++)
                {
                    Console.Write("Masukkan Nilai Kehadiran Dari Mata Pelajaran " + mapel[i] + " : ");
                    a = double.Parse(Console.ReadLine());
                    hadir.Add(a);
                    Console.Write("Masukkan Nilai Tugas Dari Mata Pelajaran " + mapel[i] + " : ");
                    b = double.Parse(Console.ReadLine());
                    tugas.Add(b);
                    Console.Write("Masukkan Nilai UAS Dari Mata Pelajaran " + mapel[i] + " : ");
                    c = double.Parse(Console.ReadLine());
                    uas.Add(c);
                }
                Console.Clear();
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("SILAHKAN TEKAN 1 SAMPAI 100 SAJA");
            }
        }

        /// <summary>
        /// Method cek nilai siswa
        /// </summary>
        /// <remarks>Method digunakan untuk menghitung nilai rata-rata siswa dan menentukan kelulusan siswa</remarks>
        public void cekRataLulus()
        {
            Console.Clear();
            rataMTK = (hadir[0] + tugas[0] + uas[0]) / 3;
            rataBInd = (hadir[1] + tugas[1] + uas[1]) / 3;
            rataBIng = (hadir[2] + tugas[2] + uas[2]) / 3;
            rataAgm = (hadir[3] + tugas[3] + uas[3]) / 3;
            rataSB = (hadir[4] + tugas[4] + uas[4]) / 3;
            rata = (rataMTK + rataBInd + rataBIng + rataAgm + rataSB) / 5;
            
            

            Console.WriteLine("\n==============================================");
            Console.WriteLine("\tHASIL RAPORT SISWA");
            Console.WriteLine("==============================================");
            Console.WriteLine("\nNAMA LENGKAP : {0}", nama);
            Console.WriteLine("KELAS        : {0}", kelas);
            Console.WriteLine("\n================================");
            Console.WriteLine("RATA-RATA NILAI MATA PELAJARAN :");
            Console.WriteLine("================================");
            Console.WriteLine("\nMATEMATIKA : {0}", rataMTK);
            Console.WriteLine("BAHASA INDONESIA : {0}", rataBInd);
            Console.WriteLine("BAHASA INGGRIS : {0}", rataBIng);
            Console.WriteLine("AGAMA : {0}", rataAgm);
            Console.WriteLine("SENI BUDAYA : {0}", rataSB);
            Console.WriteLine("================================");
            Console.WriteLine("RATA-RATA RAPORT : {0}", rata);
            if (rata <= 78)
            {
                Console.WriteLine("\nBERDASARKAN NILAI DIATAS, MAKA MAAF TIDAK NAIK / TETAP DI KELAS {0}", kelas);
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("\nBERDASARKAN NILAI DIATAS, MAKA SELAMAT NAIK KE KELAS {0}",kelas + 1);
                Console.ReadKey();
            }
            Console.Clear();
        }

        /// <summary>
        /// Method menu
        /// </summary>
        /// <remarks>Method berisi pilihan untuk digunakan pada menu utama</remarks>
        public void menuUtama()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\tMENU UTAMA APLIKASI\n");
                    Console.WriteLine("[1] INPUT DATA SISWA" +
                        "\n[2] INPUT NILAI SISWA" +
                        "\n[3] HASIL RATA-RATA DAN PENENTU KENAIKAN KELAS" +
                        "\n[4] KELUAR");
                    Console.WriteLine("=======================================");
                    Console.Write("PILIHAN : ");
                    int pilihan = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (pilihan)
                    {
                        case 1:
                            isiData();
                            break;
                        case 2:
                            isiNilai();
                            break;
                        case 3:
                            cekRataLulus();
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("\nPILIHAN TIDAK TERSEDIA\n");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                catch(FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Exception : {0}\n ", e.Message);
                }
               
            }
        }

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        /// <remarks>Method utama aplikasi</remarks>
        static void Main(string[] args)
        {
            ProgramUtama prg = new ProgramUtama();
            Console.WriteLine("=============================================");
            Console.WriteLine("SELAMAT DATANG DI APLIKASI INPUT NILAI RAPORT");
            Console.WriteLine("\nSILAHKAN MEMILIH MENU YANG TERSEDIA");
            Console.WriteLine("=============================================");
            prg.menuUtama();
        }
    }
}