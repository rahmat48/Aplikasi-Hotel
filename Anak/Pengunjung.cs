using Hotel.Induk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Anak
{
    class Pengunjung : Manusia
    {
        public override string Nama { get; set; }
        public override string Nik { get; set; }
        public override string Alamat { get; set; }
        public int Nokamar { get; set; }
        public int Lamanya { get; set; }

        public double Biaya { get; set; }
        public int penginput { get; set; }
        public int banyaknya { get; set; }
        public double TotalTambahan { get; set; }

        public double TotalBiaya()
        {
            return (Biaya * Lamanya) + TotalTambahan;
        }

    }
}
