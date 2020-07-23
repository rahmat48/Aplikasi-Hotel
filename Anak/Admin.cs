using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Induk;
namespace Hotel.Anak
{
    public class Admin
    {
        public Admin(string username, string pass)
        {
            Username = username;
            Pass = pass;
        }

        public string Username { get; set; }
        public string Pass { get; set; }

    }
}
