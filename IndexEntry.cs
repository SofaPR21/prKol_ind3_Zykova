using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading.Tasks;

namespace prKol_ind3_Zykova_v6
{
    class IndexEntry
    {
        public string Slova { get; set; }

        public ArrayList Number { get; set; }

        public IndexEntry(string slova, ArrayList number)
        {
            slova = Slova;
            Number = new ArrayList();
        }
    }
}
