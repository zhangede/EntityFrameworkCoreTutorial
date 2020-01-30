﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1
{
    public class Bewerber
    {
        [Key]
        public int BewerberId { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string FullName { get; set; }

        public List<AusschreibungBewerber> AusschreibungenBewerber { get; set; }
    }
}