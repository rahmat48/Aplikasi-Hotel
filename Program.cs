using Hotel.Anak;
using System;
using System.Collections.Generic;

namespace Hotel
{
    class Program
    {
        static List<Karyawan> daftarKaryawan = new List<Karyawan>();
        static List<Pengunjung> daftarPengunjung = new List<Pengunjung>();
        static int banyak, max = 1, id, orang;
        static double harga, hasil;
        static double[] total = new double[20];
        static int[] lama = new int[20];
        static double[] tambahan2 = new double[20];
        static void Main(string[] args)
        {
            Admin adm = new Admin("admin", "1234");

            int pil;
        menu:
            Console.Clear();

            Console.WriteLine("=====================================================");
            Console.WriteLine("=               Aplikasi Pemesanan Kamar            =");
            Console.WriteLine("=             Hotel Permai Asik-sik Jozzz           =");
            Console.WriteLine("=                  Versi Aplikasi 1.0               =");
            Console.WriteLine("=====================================================");
            Console.WriteLine("=                                                   =");
            Console.WriteLine("=                1. Cek in Hotel                    =");
            Console.WriteLine("=                2. Data Kamar di isi               =");
            Console.WriteLine("=                3. Manajemen Karyawan              =");
            Console.WriteLine("=                4. Cek Out Hotel                   =");
            Console.WriteLine("=                5. Keluar Program                  =");
            Console.WriteLine("=                                                   =");
            Console.WriteLine("=====================================================");
            Console.WriteLine("");
            Console.Write("          Masukan Pilihan Anda [1-5]: ");
            pil = int.Parse(Console.ReadLine());


            if (pil == 1)
            {
                int x = 0;
                string pass;
                bool ketemu = false;
                Console.Clear();
                Console.Write("Masukan ID Karyawan : ");
                id = int.Parse(Console.ReadLine());
                Console.Write("Masukan Password    : ");
                pass = Console.ReadLine();

                foreach (Karyawan kry in daftarKaryawan)
                {
                    if (id == kry.IDkaryawan && pass == kry.Pass)
                    {
                        ketemu = true;
                        break;
                    }
                    x++;
                }

                if (ketemu)
                {
                    if (max <= 20)
                    {
                        Menu();
                        Proses();
                        max++;
                    }
                    else
                    {
                        Console.Write("Kamar telah penuh!!!");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("ID dan Password Anda Salah");
                    Console.ReadKey();
                }
                goto menu;
            }
            else if (pil == 2)
            {
                TampilPengunjung();
                goto menu;

            }

            else if (pil == 3)
            {
                Console.Clear();
                string username, pass;
                Console.Write("Masukan Username Admin      : ");
                username = Console.ReadLine();
                Console.Write("Masukan Password Admin      : ");
                pass = Console.ReadLine();

                if (username == "admin" && pass == "1234")
                {
                    Menukar();
                }
                else
                {
                    Console.WriteLine("Username dan Password anda Salah!!!");
                    Console.ReadKey();
                }

                goto menu;

            }
            else if (pil == 4)
            {
                HapusPengunjung();
                goto menu;
            }
            else if (pil == 5)
            {
                System.Environment.Exit(0);
            }
            else
            {
                goto menu;
            }

        }

        

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("=====================================================");
            Console.WriteLine("=                     List Kamar                    =");
            Console.WriteLine("=             Hotel Permai Asik-sik Jozzz           =");
            Console.WriteLine("=                  Versi Aplikasi 1.0               =");
            Console.WriteLine("=====================================================");
            Console.WriteLine("=                                                   =");
            Console.WriteLine("=                 Tipe Kamar Dan Kasur              =");
            Console.WriteLine("=        Standar Room-Single Bed (No.1-5)           =");
            Console.WriteLine("=        Deluxe Room-Double Bed (No.6-10)           =");
            Console.WriteLine("=        Suit Room-Triple Bed (No.11-15)            =");
            Console.WriteLine("=        Superior Room-Quadruple Bed (No.16-20)     =");
            Console.WriteLine("=                                                   =");
            Console.WriteLine("=====================================================");

        }

        static void Proses()
        {
            int pilihan, lamanya;
            string nama, nik, alamat;
            double uang, tambahan;
            char jawab;
            hasil = 0;

            Console.Write("        Masukan Berapa banyak kamar  : ");
            banyak = int.Parse(Console.ReadLine());
            Console.Write("        Masukan Nama                 : ");
            nama = Console.ReadLine();
            Console.Write("        Masukan Nik                  : ");
            nik = Console.ReadLine();
            Console.Write("        Masukan Alamat               : ");
            alamat = Console.ReadLine();

            kembali:
            bool ketemu = false;
            for (int i = 0; i < banyak; i++)
            {

                Console.Write("        Masukan Pilihan No Kamar Anda  : ");
                pilihan = int.Parse(Console.ReadLine());

                foreach (Pengunjung pengunjung in daftarPengunjung)
                {
                    if (pengunjung.Nokamar == pilihan)
                    {
                        ketemu = true;
                        break;
                    }
                }
                if (ketemu)
                {
                    Console.WriteLine("        Kamar telah terisi, silakan Cari lainnya ");
                    goto kembali;

                }


                Console.Write("        Masukan Lamanya                : ");
                lamanya = int.Parse(Console.ReadLine());

                if (pilihan == 1 || pilihan == 2 || pilihan == 3 || pilihan == 4 || pilihan == 5)
                {

                    harga = 250000;
                }
                else if (pilihan == 6 || pilihan == 7 || pilihan == 8 || pilihan == 9 || pilihan == 10)
                {
                    harga = 300000;

                }
                else if (pilihan == 11 || pilihan == 12 || pilihan == 13 || pilihan == 14 || pilihan == 15)
                {
                    harga = 400000;

                }
                else if (pilihan == 16 || pilihan == 17 || pilihan == 18 || pilihan == 19 || pilihan == 20)
                {
                    harga = 500000;

                }

                Console.Write("        Layanan Makan Kamar {0}, seharga Rp.15.000: ", i);
                jawab = char.Parse(Console.ReadLine());

                if (jawab == 'Y' || jawab == 'y')
                {
                    Console.Write("        Berapa orang ?             : ");
                    orang = int.Parse(Console.ReadLine());
                    tambahan = 15000 * orang;
                }
                else
                {
                    tambahan = 0;
                }


                daftarPengunjung.Add(new Pengunjung { Nama = nama, Nik = nik, Alamat = alamat, Nokamar = pilihan, Lamanya = lamanya, Biaya = harga, TotalTambahan = tambahan, banyaknya = orang, penginput = id });
                total[i] = harga;
                lama[i] = lamanya;
                tambahan2[i] = tambahan;
                hasil += (total[i] * lama[i]) + tambahan2[i];
            }
            balik:
            Console.Clear();
            Console.WriteLine("Pembayaran");
            Console.WriteLine("Uang yang harus anda bayar sebesar = Rp.{0}", hasil);
            Console.Write("Masukan Uang :");
            uang = double.Parse(Console.ReadLine());
            if (uang == hasil)
            {
                Console.WriteLine("Uang anda pas!!");
            }
            else if (uang < hasil)
            {
                Console.WriteLine("Uang yang dimasukan kurang, silakan input kembali!!");
                goto balik;
            }
            else
            {
                Console.WriteLine("Kembalian Uang adalah {0}", uang - hasil);
            }
            Console.ReadLine();
        }
        static void Menukar()
        {
            int pilkar;
            Console.Clear();
            Console.WriteLine("=====================================================");
            Console.WriteLine("|                 Selamat Datang Admin              |");
            Console.WriteLine("|                 Menu Input Karyawan               |");
            Console.WriteLine("=====================================================");
            Console.WriteLine("|  1. Registrasi Karyawan                           |");
            Console.WriteLine("|  2. Edit Karyawan                                 |");
            Console.WriteLine("|  3. Hapus Karyawan                                |");
            Console.WriteLine("|  4. Kembali                                       |");
            Console.WriteLine("=====================================================");
            Console.WriteLine("");
            Console.Write("          Masukan Pilihan Anda [1-4]: ");
            pilkar = int.Parse(Console.ReadLine());
            if (pilkar == 1)
            {
                RegisKaryawan();
                Console.WriteLine("\nTekan ENTER untuk kembali ke menu");
                Console.ReadKey();
            }
            else if (pilkar == 2)
            {
                Edit();
                Console.WriteLine("\nTekan ENTER untuk kembali ke menu");
                Console.ReadKey();

            }
            else if (pilkar == 3)
            {
                Hapus();
                Console.WriteLine("\nTekan ENTER untuk kembali ke menu");
                Console.ReadKey();
            }
            else if (pilkar == 4)
            {
                Console.WriteLine("\nTekan ENTER untuk kembali ke menu");
                Console.ReadKey();
            }
        }
        static void RegisKaryawan()
        {
            Console.Clear();
            int id;
            string nama, nik, alamat, pass;

            Console.Write("Masukan ID Karyawan      : ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Masukan Nama Karyawan    : ");
            nama = Console.ReadLine();
            Console.Write("Masukan Nik Karyawan     : ");
            nik = Console.ReadLine();
            Console.Write("Masukan Alamat Karyawan  : ");
            alamat = Console.ReadLine();
            Console.Write("Masukan Password Karyawan: ");
            pass = Console.ReadLine();

            daftarKaryawan.Add(new Karyawan() { IDkaryawan = id, Nama = nama, Nik = nik, Alamat = alamat, Pass = pass });
        }
        static void Edit()
        {
            string edit;
            bool ketemu1 = false;
            Tampil();
            int no = 0;
            Console.Write("Masukan Nik yang ingin diganti : ");
            edit = Console.ReadLine();
            foreach (Karyawan daftar in daftarKaryawan)
            {
                if (edit == daftar.Nik)
                {

                    Console.WriteLine("=============================");
                    Console.WriteLine("|  Data yang ingin dirubah  |");
                    Console.WriteLine("=============================");
                    Console.WriteLine("|  1. NIK                   |");
                    Console.WriteLine("|  2. Nama                  |");
                    Console.WriteLine("|  3. Alamat                |");
                    Console.WriteLine("|  4. ID                    |");
                    Console.WriteLine("|  5. Password              |");
                    Console.WriteLine("=============================");
                    Console.Write(" Masukkan Pilihan Anda : ");
                    int pil3 = int.Parse(Console.ReadLine());
                    if (pil3 == 1)
                    {
                        Console.Write("NIK yang ingin diganti : ");
                        string ganti = Console.ReadLine();
                        daftarKaryawan[no].Nik = ganti;
                    }
                    else if (pil3 == 2)
                    {
                        Console.Write("Nama yang ingin diganti : ");
                        string ganti = Console.ReadLine();
                        daftarKaryawan[no].Nama = ganti;
                    }
                    else if (pil3 == 3)
                    {
                        Console.Write("Alamat yang ingin diganti : ");
                        string ganti = Console.ReadLine();
                        daftarKaryawan[no].Alamat = ganti;
                    }
                    else if (pil3 == 4)
                    {
                        Console.Write("ID yang ingin diganti : ");
                        int ganti = int.Parse(Console.ReadLine());
                        daftarKaryawan[no].IDkaryawan = ganti;
                    }
                    else if (pil3 == 5)
                    {
                        Console.Write("Password yang ingin diganti : ");
                        string ganti = Console.ReadLine();
                        daftarKaryawan[no].Pass = ganti;
                    }
                    else
                    {
                        Menukar();
                    }
                    ketemu1 = true;
                    break;
                }
                no++;
            }
            if (ketemu1)
            {
                Console.WriteLine("Data Berhasil Diganti");
            }
            else
            {
                Console.WriteLine("Data Tidak Ditemukan");
            }
        }

        static void Hapus()
        {
            Tampil();
            string hapus;
            bool k = false;
            Console.WriteLine("Hapus data Karyawan");
            Console.WriteLine("");
            Console.Write("NIK : ");
            hapus = Console.ReadLine();
            int x = 0;
            foreach (Karyawan daftar in daftarKaryawan)
            {
                if (hapus == daftar.Nik)
                {
                    daftarKaryawan.RemoveAt(x);
                    k = true;
                    break;
                }
                x++;
            }
            if (k)
            {
                Console.WriteLine("Data Karyawan berhasil dihapus");
            }
            else
            {
                Console.WriteLine("Data Karyawan tidak ditemukan");
            }
        }

        static void Tampil()
        {
            Console.Clear();
            int no = 0;
            foreach (Karyawan daftar in daftarKaryawan)
            {
                int k = no + 1;
                Console.WriteLine("    Karyawan Ke " + k + "  ");
                Console.WriteLine("=====================");
                Console.WriteLine("Nama     : " + daftarKaryawan[no].Nama);
                Console.WriteLine("NIK      : " + daftarKaryawan[no].Nik);
                Console.WriteLine("Alamat   : " + daftarKaryawan[no].Alamat);
                Console.WriteLine("ID       : " + daftarKaryawan[no].IDkaryawan);
                Console.WriteLine("Password : " + daftarKaryawan[no].Pass);
            }
            Console.WriteLine("");
        }

        static void TampilPengunjung()
        {
            Console.Clear();
            int i = 1;
            Console.WriteLine("=============================[ List Kamar Terisi ]===============================");
            Console.WriteLine("=================================================================================");
            foreach (Pengunjung pengunjung in daftarPengunjung)
            {
                if (pengunjung.TotalTambahan > 0)
                {
                    Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}, Diinput oleh  {7}, Layanan Makan {8} orang", i, pengunjung.Nama, pengunjung.Nik, pengunjung.Alamat, pengunjung.Nokamar, pengunjung.Lamanya, pengunjung.TotalBiaya(), pengunjung.penginput, pengunjung.banyaknya);
                }
                else if (pengunjung.TotalTambahan == 0)
                {
                    Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}, {6}, Diinput oleh  {7}, Tidak Menggunakan Layanan Makan", i, pengunjung.Nama, pengunjung.Nik, pengunjung.Alamat, pengunjung.Nokamar, pengunjung.Lamanya, pengunjung.TotalBiaya(), pengunjung.penginput);
                }

                i++;
            }
            Console.WriteLine("=================================================================================");
            Console.ReadKey();
        }

        static void HapusPengunjung()
        {
            int hapus, x = 0;
            bool ketemu = false;
            TampilPengunjung();
            Console.WriteLine(" ");
            Console.Write("Masukan Nomer Kamar : ");
            hapus = int.Parse(Console.ReadLine());

            foreach (Pengunjung pengunjung in daftarPengunjung)
            {
                if (hapus == pengunjung.Nokamar)
                {
                    ketemu = true;
                    break;
                }
                x++;
            }
            if (ketemu)
            {
                daftarPengunjung.RemoveAt(x);
                Console.WriteLine("Data pengunjung dihapus, kamar ada kosong!!");
                max--;
            }
            else
            {
                Console.WriteLine("Kamar tidak ditemukan");
            }

            Console.ReadKey();

        }

    }
}
