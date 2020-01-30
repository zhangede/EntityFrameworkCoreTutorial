using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AddData();

            ReadData();
        }

        private static void ReadData()
        {
            using (var ctx = new BewerberDbContext())
            {
                var bewMustermann = ctx.BewerberSet.Include(x => x.AusschreibungenBewerber).ThenInclude(x => x.Ausschreibung).FirstOrDefault(x => x.Nachname == "Mustermann");

                foreach (var item in bewMustermann.AusschreibungenBewerber)
                {
                    Console.WriteLine($"{bewMustermann.Nachname} - {item.Ausschreibung.Bezeichnung}");
                }

                var bewMusterfrau = ctx.BewerberSet.Include(x => x.AusschreibungenBewerber).ThenInclude(x => x.Ausschreibung).FirstOrDefault(x => x.Nachname == "Musterfrau");

                foreach (var item in bewMusterfrau.AusschreibungenBewerber)
                {
                    Console.WriteLine($"{bewMusterfrau.Nachname} - {item.Ausschreibung.Bezeichnung}");
                }
            }

            Console.ReadLine();
        }

        private static void AddData()
        {
            using (var ctx = new BewerberDbContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                ctx.Add(new Bewerber
                {
                    Nachname = "Mustermann"
                });

                ctx.SaveChanges();

                ctx.Add(new Bewerber
                {
                    Nachname = "Musterfrau"
                });

                ctx.SaveChanges();

                ctx.Add(new Ausschreibung
                {
                    Bezeichnung = "ek_gD_2020"
                });

                ctx.Add(new Ausschreibung
                {
                    Bezeichnung = "es_gD_2020"
                });

                ctx.SaveChanges();

                var bewMustermann = ctx.BewerberSet.FirstOrDefault(x => x.Nachname == "Mustermann");
                var bewMusterfrau = ctx.BewerberSet.FirstOrDefault(x => x.Nachname == "Musterfrau");

                var ausschreibungKripo = ctx.AusschreibungSet.FirstOrDefault(x => x.Bezeichnung == "ek_gD_2020");
                var ausschreibungSchuPo = ctx.AusschreibungSet.FirstOrDefault(x => x.Bezeichnung == "es_gD_2020");

                //Mustermann
                bewMustermann.AusschreibungenBewerber = new System.Collections.Generic.List<AusschreibungBewerber>
                {
                    new AusschreibungBewerber
                    {
                       Ausschreibung = ausschreibungKripo,
                       Bewerber = bewMustermann
                    },
                    new AusschreibungBewerber
                    {
                       Ausschreibung = ausschreibungSchuPo,
                       Bewerber = bewMustermann
                    }
                };

                //Musterfrau
                bewMusterfrau.AusschreibungenBewerber = new System.Collections.Generic.List<AusschreibungBewerber>
                {
                    new AusschreibungBewerber
                    {
                       Ausschreibung = ausschreibungKripo,
                       Bewerber = bewMusterfrau
                    },
                    new AusschreibungBewerber
                    {
                       Ausschreibung = ausschreibungSchuPo,
                       Bewerber = bewMusterfrau
                    }
                };

                ctx.SaveChanges();
            }
        }
    }
}
