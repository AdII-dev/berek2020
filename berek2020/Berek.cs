using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using berek2020;

namespace berek2020
{
    public class Berek
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Section { get; set; }
        public string Entry { get; set; }
        public int Salary { get; set; }

        public Berek(string row)
        {
            var v = row.Split(';');
            Name = v[0];
            Gender = v[1];
            Section = v[2];
            Entry = v[3];
            Salary = int.Parse(v[4]);
        }
    }
}

