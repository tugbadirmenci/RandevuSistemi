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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public RandevuAl rndv;
        public Personel prsnl;
        public Hizmet hzmt;

        public Form1()
        {
            InitializeComponent();

            rndv = new RandevuAl();
            prsnl = new Personel();
            hzmt = new Hizmet();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rndv.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prsnl.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hzmt.ShowDialog();
        }
    }
}
