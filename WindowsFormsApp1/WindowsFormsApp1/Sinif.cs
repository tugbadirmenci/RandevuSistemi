/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2023-2024 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........:Proje 1
** ÖĞRENCİ ADI............:Tugba Dirmenci
** ÖĞRENCİ NUMARASI.......:G201210005
** DERSİN ALINDIĞI GRUP...:2B
****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{

    public interface IYapilacakIslem
    {
        string Yapilacak { get; set; }


    }

    public class Sinif : IYapilacakIslem
    {

        string ad;
        string telefon;
        string sira;
        DateTime tarih;
        bool indirim;
        string yapilacak;


        public string Ad { get => ad; set => ad = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Sira { get => sira; set => sira = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Yapilacak { get => yapilacak; set => yapilacak = value; }
        public bool İndirim { get => indirim; set => indirim = value; }



        public Sinif(string sira, string ad, string telefon, DateTime tarih, bool indirim, string yapilacak)
        {
            this.ad = ad;
            this.telefon = telefon;
            this.sira = sira;
            this.indirim = indirim;
            this.yapilacak = yapilacak;
            this.tarih = tarih;

        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public ComboBoxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }

        public class Sinif1 : IYapilacakIslem
        {
            string sicil;
            string tcNo;
            string ad;
            string soyad;
            string yapilacak;
            string telefon;
            string evTel;
            string dogumTarih;
            string adres;

            public string Sicil { get => sicil; set => sicil = value; }
            public string TcNo { get => tcNo; set => tcNo = value; }
            public string Ad { get => ad; set => ad = value; }
            public string Soyad { get => soyad; set => soyad = value; }
            public string Telefon { get => telefon; set => telefon = value; }
            public string EvTel { get => evTel; set => evTel = value; }
            public string DogumTarih { get => dogumTarih; set => dogumTarih = value; }
            public string Adres { get => adres; set => adres = value; }
            public string Yapilacak { get => yapilacak; set => yapilacak = value; }

            public Sinif1(string sicil, string tcNo, string ad, string soyad, string yapilacak, string telefon, string evTel, string dogumTarih, string adres)
            {
                this.sicil = sicil;
                this.tcNo = tcNo;
                this.ad = ad;
                this.soyad = soyad;
                this.yapilacak = yapilacak;
                this.telefon = telefon;
                this.evTel = evTel;
                this.dogumTarih = dogumTarih;
                this.adres = adres;
            }
            public class ComboBoxItem
            {
                public string Text { get; set; }
                public string Value { get; set; }

                public ComboBoxItem(string text, string value)
                {
                    Text = text;
                    Value = value;
                }

                public override string ToString()
                {
                    return Text;
                }
            }

        }
}


