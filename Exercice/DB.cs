using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice
{
    /*
     * clair
     * clef
     * crypte
     * */
    public class DB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Clair { get; set; }
        public string Clef { get; set; }
        public string Crypte { get; set; }
        public bool Type { get; set; }
    }
}