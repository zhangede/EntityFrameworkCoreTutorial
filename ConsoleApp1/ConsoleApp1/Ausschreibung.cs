using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1
{
    public class Ausschreibung
    {
        [Key]
        public int AusschreibungId { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Einstellungsdatum { get; set; }

        public List<AusschreibungBewerber> AusschreibungenBewerber { get; set; }
    }
}