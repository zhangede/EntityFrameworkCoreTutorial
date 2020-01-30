using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1
{
    public class AusschreibungBewerber
    {
        [Key]
        public int AusschreibungBewerberId { get; set; }

        public int BewerberId { get; set; }
        public Bewerber Bewerber { get; set; }

        public int AusschreibungId { get; set; }
        public Ausschreibung Ausschreibung { get; set; }
    }
}
