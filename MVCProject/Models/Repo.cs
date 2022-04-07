using Microsoft.ApplicationBlocks.Data;
using MVCProject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class Repo
    {

        private static int KupciCount = 20000;

        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static Kupac GetKupac(int id)
        {
            
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKupac", id).Tables[0].Rows[0];
            return GetKupacFromDataRow(row);
        }
         

        public static IEnumerable<Kupac> ReadKupci() 
        {
            DataSet ds = SqlHelper.ExecuteDataset(cs, "SelectKupci", KupciCount);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetKupacFromDataRow(row);
            }
        }
        public static List<Grad> GetGradoviDrzave(int drzavaID) 
        {
            List<Grad> kolekcija = new List<Grad>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetGradovi", drzavaID);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(GetGradFromDataRow(row));
            }

            return kolekcija;
        }


        private static Kupac GetKupacFromDataRow(DataRow row)
        {
            return new Kupac
            {
                IDKupac = (int)row["IDKupac"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                Email = row["Email"].ToString(),
                Telefon = row["Telefon"].ToString(),
                Grad = GetGradFromDataRow(row)
            };

        }

        private static Grad GetGradFromDataRow(DataRow row)
        {
            return new Grad
            {
                IDGrad = (int)row["IDGrad"],
                Naziv = row["Naziv"].ToString(),
                DrzavaID = (int)row["DrzavaID"]
            };
        }


        public static List<Kupac> GetKupci() 
        {
            List<Kupac> kolekcija = new List<Kupac>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "DohvatiKupce");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(GetKupacFromDataRow(row));
            }

            return kolekcija;
        }


        public static List<Grad> GetGradovi()
        {
            List<Grad> kolekcija = new List<Grad>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "DohvatiGradove");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(GetGradFromDataRow(row));
            }

            return kolekcija;
        }

        public static int GetKupciCount()
        {
            return (int)SqlHelper.ExecuteScalar(cs, "DohvatiBrojKupaca");
        }

        public static int UpdateKupac(Kupac k)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateKupac", k.IDKupac, k.Ime, k.Prezime, k.Email, k.Telefon, k.Grad.IDGrad);
        }

   
        public static void InsertKupac(Kupac k) 
        {
            SqlHelper.ExecuteNonQuery(cs, "InsertKupac", k.Ime, k.Prezime, k.Email, k.Telefon, k.Grad.IDGrad);
        }


        public static List<Racun> GetRacuniKupca(int kupacId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(cs, "DohvatiRacuneKupca", kupacId);
            List<Racun> kolekcija = new List<Racun>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new Racun
                {
                    IDRacun = (int)row["IDRacun"],
                    DatumIzdavanja = DateTime.Parse(row["DatumIzdavanja"].ToString()),
                    BrojRacuna = row["BrojRacuna"].ToString(),
                    Komentar = row["Komentar"] != DBNull.Value ? row["Komentar"].ToString() : "-"
                });
            }

            return kolekcija;
        }

        public static Kupac GetKupac15(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(cs, "DohvatiKupca15", id);
            DataRow row = ds.Tables[0].Rows[0];

            return new Kupac
            {
                IDKupac = (int)row["IDKupac"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                Email = row["Email"].ToString()
            };
        }

        public static List<Kupac> GetKupci15()
        {
            List<Kupac> kolekcija = new List<Kupac>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "DohvatiKupce15");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add( new Kupac
                {
                    IDKupac = (int)row["IDKupac"],
                    Ime = row["Ime"].ToString(),
                    Prezime = row["Prezime"].ToString(),
                    Email = row["Email"].ToString()
                });
            }

            return kolekcija;
        }



        public static List<PodaciRacuna> GetSviPodaciRacuna(int id)
        {
            List<PodaciRacuna> kolekcija = new List<PodaciRacuna>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "SviPodaciNekogRacuna", id);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new PodaciRacuna
                {
                    BrojRacuna = row[0].ToString(),
                    NazivProizvoda = row[1].ToString(),
                    Kolicina = (short)row[2],
                    NazivPotkategorije = row[3].ToString(),
                    NazivKategorije = row[4].ToString(),
                    TipKK = row[5].ToString(),
                    Komercijalist = row[6].ToString()
                });
            }

            return kolekcija;
        }


        public static List<Kategorija> GetKategorije()
        {
            List<Kategorija> kolekcija = new List<Kategorija>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetKategorije");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new Kategorija
                {
                    IDKategorija = (int)row[0],
                    Naziv = row[1].ToString()
                });
            }

            return kolekcija;
        }

        public static List<Potkategorija> GetPotkategorije()
        {
            List<Potkategorija> kolekcija = new List<Potkategorija>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetPotkategorija");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new Potkategorija
                {
                    IDPotkategorija = (int)row[0],

                    Kategorija = new Kategorija { 
                        IDKategorija = (int)row[1],
                        Naziv = row[4].ToString()
                    },
                    Naziv = row[2].ToString()
                });
            }

            return kolekcija;
        }

        public static List<Proizvod> GetProizvodi()
        {
            List<Proizvod> kolekcija = new List<Proizvod>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetProizvodi");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kolekcija.Add(new Proizvod
                {
                   IDProizvod = (int)row[0],
                   Naziv = row[1].ToString(),
                   BrojProizvoda = row[2].ToString(),
                   Boja = row[3] != DBNull.Value ? row[3].ToString() : "-",

                    MinimalnaKolicinaNaSkladistu = (short)row[4],
                    CijenaBezPDV = double.Parse(row[5].ToString()),
                    Potkategorija = new Potkategorija {
                        IDPotkategorija = (int)row[6],
                        Naziv = row[9].ToString(),
                        Kategorija = new Kategorija
                        {
                            IDKategorija = (int)row[10],
                            Naziv = row[11].ToString()
                        }
                   }
                });
            }

            return kolekcija;
        }


        public static Kategorija GetKategorijaById(int id)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKategorijaById", id).Tables[0].Rows[0];
            return new Kategorija { IDKategorija = (int)row[0], Naziv = row[1].ToString() };
        }

        public static int UpdateKategorija(Kategorija k)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateKategorija", k.IDKategorija, k.Naziv);
        }

        public static Potkategorija GetPotkategorijaById(int id)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetPotkategorijaById", id).Tables[0].Rows[0];
            return new Potkategorija { 
                IDPotkategorija = (int)row[0], 
                Naziv = row[2].ToString(),
                Kategorija = new Kategorija {
                    IDKategorija = (int)row[3],
                    Naziv = row[4].ToString()
                }
            };
        }

        public static int UpdatePotkategorija(Potkategorija k)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdatePotkategorija", k.IDPotkategorija, k.Kategorija.IDKategorija, k.Naziv);
        }

        public static Proizvod GetProizvodById(int id)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetProizvodById", id).Tables[0].Rows[0];
            return new Proizvod
            {
                IDProizvod = (int)row[0],
                Naziv = row[1].ToString(),
                BrojProizvoda = row[2].ToString(),
                Boja = row[3] != DBNull.Value ? row[3].ToString() : "-",
                MinimalnaKolicinaNaSkladistu = (short)row[4],
                CijenaBezPDV = double.Parse(row[5].ToString()),
                Potkategorija = new Potkategorija { IDPotkategorija = (int)row[6]}
            };
        }

        public static int UpdateProizvod(Proizvod p)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateProizvod", p.IDProizvod, p.Naziv, p.BrojProizvoda, p.Boja, p.MinimalnaKolicinaNaSkladistu, p.CijenaBezPDV, p.Potkategorija.IDPotkategorija);
        }

        public static int CreateKategorija(Kategorija k)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreateKategorija", k.Naziv);

        }

        public static int CreatePotkategorija(Potkategorija pk)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreatePotkategorija", pk.Naziv, pk.Kategorija.IDKategorija);

        }

        public static int CreateProizvod(Proizvod p)
        {
            return SqlHelper.ExecuteNonQuery(cs, "CreateProizvod", p.Naziv, p.BrojProizvoda, p.Boja, p.MinimalnaKolicinaNaSkladistu, p.CijenaBezPDV, p.Potkategorija.IDPotkategorija);

        }

        public static int DeleteProizvod(int id) {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteProizvod", id);

        }

        public static int DeletePotkategorija(int id)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeletePotkategorija", id);

        }

        public static int DeleteKategorija(int id)
        {
            return SqlHelper.ExecuteNonQuery(cs, "DeleteKategorija", id);

        }

        public static bool ProvjeraUspjesnostiLogiranja(Korisnik k)
        {

            try
            {
                DataRow row = SqlHelper.ExecuteDataset(cs, "ProvjeraUspjesnostiLogiranja", k.Email, k.Lozinka).Tables[0].Rows[0];
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }


    }


}