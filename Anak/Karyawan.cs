using Hotel.Induk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Anak
{
    
    public class Karyawan : Manusia
    {
        public override string Nama { get; set; }
        public override string Nik { get; set; }
        public override string Alamat { get; set; }
        public string Pass { get; set; }
        public int IDkaryawan { get; set; }
    }
}

