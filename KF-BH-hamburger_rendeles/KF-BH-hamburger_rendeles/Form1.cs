using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KF_BH_hamburger_rendeles
{
    public partial class Form1 : Form
    {
        private List<Hamburger> hamburgerek;
        private List<Bankkartya> bankkartyak;
        public Form1()
        {
            InitializeComponent();
            hamburgerek = new List<Hamburger>();
            bankkartyak = new List<Bankkartya>();
            Adatokbetoltese();
            for (int i = 0; i < 3; i++)
            {
                Bankkartya_generalo();
            }

            radioButton1.Text = hamburgerek[0].nev;
            radioButton3.Text = hamburgerek[1].nev;
            radioButton5.Text = hamburgerek[2].nev;
            radioButton7.Text = hamburgerek[3].nev;
            radioButton8.Text = hamburgerek[4].nev;
            radioButton9.Text = hamburgerek[5].nev;

            radioButton1.CheckedChanged += Hamburger_CheckedChanged;
            radioButton3.CheckedChanged += Hamburger_CheckedChanged;
            radioButton5.CheckedChanged += Hamburger_CheckedChanged;
            radioButton7.CheckedChanged += Hamburger_CheckedChanged;
            radioButton8.CheckedChanged += Hamburger_CheckedChanged;
            radioButton9.CheckedChanged += Hamburger_CheckedChanged;

            radioButton1.Checked = true;

        }




        private void Adatokbetoltese()
        {
            List<string> beolv = File.ReadAllLines("osszetevok.txt").ToList();
            foreach (var item in beolv)
            {
                string[] adatok = item.Split(';');
                string nev = adatok[0];
                List<string> zoldsegek = adatok[1].Split(',').ToList();
                List<string> szoszok = adatok[2].Split(',').ToList();
                string meret = adatok[3];
                Hamburger ujHamburger = new Hamburger()
                {
                    nev = nev,
                    zoldsegek = zoldsegek,
                    szoszok = szoszok,
                    meret = meret
                };
                hamburgerek.Add(ujHamburger);
            }
        }

        private void Hamburger_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked) 
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;

                Hamburger kivalasztott = KivalasztottHamburger();
                if (kivalasztott != null)
                {
                    Zoldsegek_valasztas(kivalasztott);
                    Szosz_valasztas(kivalasztott);
                    Meret_valasztas(kivalasztott);
                }
            }
        }

        private Hamburger KivalasztottHamburger()
        {
            if (radioButton1.Checked) return hamburgerek[0];
            if (radioButton3.Checked) return hamburgerek[1];
            if (radioButton5.Checked) return hamburgerek[2];
            if (radioButton7.Checked) return hamburgerek[3];
            if (radioButton8.Checked) return hamburgerek[4];
            if (radioButton9.Checked) return hamburgerek[5];
            return null;
        }

        private void Zoldsegek_valasztas(Hamburger hamburger)
        {
            for (int i = 0; i < hamburger.zoldsegek.Count(); i++)
            {
                if (hamburger.zoldsegek[i] == "saláta")
                {
                    checkBox1.Checked = true;
                }
                if (hamburger.zoldsegek[i] == "paradicsom")
                {
                    checkBox2.Checked = true;
                }
                if (hamburger.zoldsegek[i] == "jalapeno")
                {
                    checkBox3.Checked = true;
                }
                if (hamburger.zoldsegek[i] == "hagyma")
                {
                    checkBox4.Checked = true;
                }
                if (hamburger.zoldsegek[i] == "uborka")
                {
                    checkBox5.Checked = true;
                }
                if (hamburger.zoldsegek[i] == "kukorica")
                {
                    checkBox6.Checked = true;
                }
            }
        }

        private void Szosz_valasztas(Hamburger hamburger)
        {
            for (int i = 0; i < hamburger.szoszok.Count(); i++)
            {
                if (hamburger.szoszok[i] == "ketchup")
                {
                    checkBox7.Checked = true;
                }
                if (hamburger.szoszok[i] == "McChicken")
                {
                    checkBox8.Checked = true;
                }
                if (hamburger.szoszok[i] == "mustár")
                {
                    checkBox9.Checked = true;
                }
                if (hamburger.szoszok[i] == "barbecue")
                {
                    checkBox10.Checked = true;
                }
                if (hamburger.szoszok[i] == "fokhagymás")
                {
                    checkBox11.Checked = true;
                }
                if (hamburger.szoszok[i] == "majonéz")
                {
                    checkBox12.Checked = true;
                }
            }
        }

        private void Meret_valasztas(Hamburger hamburger)
        {
            if (hamburger.meret == "nagy")
            {
                radioButton2.Checked = true;
            }
            else if (hamburger.meret == "közepes")
            {
                radioButton4.Checked = true;
            }
            else 
            {
                radioButton6.Checked = true;
            }
        }

        public class Hamburger
        {
            public string nev { get; set; }
            public List<string> zoldsegek { get; set; }
            public List<string> szoszok { get; set; }
            public string meret { get; set; }
        }

        public class Bankkartya
        {
            public string nev { get; set; }
            public string szam { get; set; }
            public DateTime lejarat { get; set; }
            public string cvc { get; set; }
            public int keret { get; set; }
        }
        private void Bankkartya_generalo()
        {
            Random rnd = new Random();
            List<string> vezeteknevek = new List<string>
            {
                "Nagy","Kovács","Tóth","Szabó","Horváth","Varga","Kiss","Molnár","Németh","Farkas",
                "Balogh","Papp","Lakatos","Takács","Juhász","Oláh","Mészáros","Simon","Rácz","Fekete",
                "Szilágyi","Török","Fehér","Balázs","Gál","Kocsis","Orsós","Sipos","Katona","Lukács",
                "Bíró","Bodnár","Soós","Hegedűs","Pintér","Bognár","György","Jakab","Antal","Király",
                "Bálint","Fodor","Boros","Szekeres","Vincze","Somogyi","Veres","Illés","László","Major",
                "Fülöp","Szalai","Kelemen","Pál","Sárosi","Pap","Orosz","Szűcs","Vas","Tari",
                "Bakos","Berki","Cseh","Dénes","Erdős","Fazekas","Gergely","Halász","Igaz","Jancsó",
                "Kardos","Lengyel","Madarász","Novák","Pék","Rózsa","Sándor","Szarka","Tamás","Urbán",
                "Virág","Zentai","Csányi","Dobos","Elek","Fábián","Gombos","Huszár","Kárpáti","Miklós"
            };
            List<string> keresztnevek = new List<string>
            {
                "Ádám","Bálint","Balázs","Bence","Botond","Csaba","Dániel","Dávid","Dominik","Gábor",
                "Gergő","Hunor","István","János","Krisztián","László","Levente","Márk","Máté","Mihály",
                "Norbert","Péter","Richárd","Roland","Sándor","Tamás","Zoltán","Zsolt","Ákos","András",
                "Attila","Béla","Csanád","Ferenc","György","Imre","József","Kálmán","Kornél","Lajos",
                "Miklós","Olivér","Ottó","Róbert","Szabolcs","Tibor","Viktor","Vilmos","Zalán","Zsigmond",
                "Anna","Barbara","Beáta","Bernadett","Boglárka","Csilla","Dóra","Edina","Emese","Eszter",
                "Éva","Fanni","Gabriella","Henrietta","Ildikó","Judit","Katalin","Kinga","Laura","Lilla",
                "Mariann","Melinda","Mónika","Nóra","Orsolya","Petra","Réka","Rita","Sára","Szilvia",
                "Tímea","Vanda","Veronika","Viktória","Virág","Zita","Zsófia","Alexandra","Anett","Bianka"
            };
            string nev = vezeteknevek[rnd.Next(vezeteknevek.Count)] + " " + keresztnevek[rnd.Next(keresztnevek.Count)];
            string szam = "";
            for (int i = 0; i < 16; i++)
            {
                szam += rnd.Next(0, 10).ToString();
            }
            DateTime lejarat = DateTime.Now.AddYears(3);
            string cvc = "";
            for (int i = 0; i < 3; i++)
            {
                cvc += rnd.Next(0, 10).ToString();
            }
            int keret = rnd.Next(500, 142001);
            Bankkartya ujKartya = new Bankkartya()
            {
                nev = nev,
                szam = szam,
                lejarat = lejarat,
                cvc = cvc,
                keret = keret
            };
            bankkartyak.Add(ujKartya);
        }


    }
}
