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
                //var bewMustermann = ctx.BewerberSet.Include(x => x.AusschreibungenBewerber).ThenInclude(x => x.Ausschreibung).FirstOrDefault(x => x.Nachname == "Mustermann");
                var bewMustermann = ctx.BewerberSet.FirstOrDefault(x => x.Nachname == "Mustermann");

                foreach (var item in bewMustermann.AusschreibungenBewerber)
                {
                    Console.WriteLine($"{bewMustermann.Nachname} - {item.Ausschreibung.Bezeichnung}");
                }

                //var bewMusterfrau = ctx.BewerberSet.Include(x => x.AusschreibungenBewerber).ThenInclude(x => x.Ausschreibung).FirstOrDefault(x => x.Nachname == "Musterfrau");
                var bewMusterfrau = ctx.BewerberSet.FirstOrDefault(x => x.Nachname == "Musterfrau");

                foreach (var item in bewMusterfrau.AusschreibungenBewerber)
                {
                    Console.WriteLine($"{bewMusterfrau.Nachname} - {item.Ausschreibung.Bezeichnung}");
                }

                var bewMusterjunge = ctx.BewerberJungSet.FirstOrDefault(x => x.Nachname == "Musterjunge");

                Console.WriteLine($"{bewMusterjunge.Nachname} - {bewMusterjunge.UnterschriftErziehungsberechtigteVorhanden}");
               // Console.WriteLine($"{bewMusterjunge.Adressen.FirstOrDefault().AuslandAdresse.Adresse1} - {bewMusterjunge.UnterschriftErziehungsberechtigteVorhanden}");

                var bewMusterj = ctx.BewerberSet.FirstOrDefault(x => x.Nachname == "Musterjunge");

                Console.WriteLine($"{bewMusterj.Nachname}");
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


                var bewerberJung = new BewerberJung
                {
                    Nachname = "Musterjunge",
                    UnterschriftErziehungsberechtigteVorhanden = true
                };

                //Adresse adresse = new Adresse
                //{
                //    AuslandAdresse = new AuslandAdresse
                //    {
                //        Adresse1 = "A",
                //        Adresse2 = "B",
                //        Adresse3 = "C"
                //    },
                //    Bewerber = bewerberJung
                //};

                //Adresse adresse2 = new Adresse
                //{
                //    AuslandAdresse = new AuslandAdresse
                //    {
                //        Adresse1 = "A",
                //        Adresse2 = "B",
                //        Adresse3 = "C"
                //    },
                //    Bewerber = bewMustermann
                //};


                Adresse adresse3 = new Adresse
                {
                    Strasse = "Lankwitzer Str. 4",
                    Ort = "Berlin",

                };

                adresse3.AuslandAdressen.Add(
                    new AuslandAdresse
                    {
                        Adresse1 = "A",
                        Adresse2 = "B",
                        Adresse3 = "C"
                    }
                    );


                adresse3.AuslandAdressen.Add(
                    new AuslandAdresse
                    {
                        Adresse1 = "d",
                        Adresse2 = "e",
                        Adresse3 = "f"
                    }
                    );


                bewMusterfrau.Adressen.Add(adresse3);

                //ctx.Add(adresse);
                //ctx.Add(adresse2);
                ctx.Add(bewerberJung);

                ctx.SaveChanges();
            }
        }
    }
}
