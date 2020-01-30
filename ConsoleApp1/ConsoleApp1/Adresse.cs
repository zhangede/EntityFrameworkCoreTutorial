using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1
{
    public class Adresse
    {
        [Key]
        public int AdresseId { get; set; }
        public string Ort { get; set; }
        public string Strasse { get; set; }



        public int BewerberId { get; set; }
        public Bewerber Bewerber { get; set; }
    }
}
