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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RandevuAl : Form
    {
        
        public RandevuAl()
        {
            InitializeComponent();
        }

        Sinif sinif;
        BindingList<Sinif> list = new BindingList<Sinif>();

        Dictionary<string, double> yapilacaklar = new Dictionary<string, double> {

        { "ombre", 3500 },
        { "kaş alımı",100 },
        { "fön", 200 },
        { "maşa", 300 },
        { "makyaj", 1000 },
        { "kalıcı oje", 600 },
        { "saç kesimi", 400 },
        { "açma boyama", 3000 },
        { "dip boyama", 1000 },

        };

        private void Randevu_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
            comboBox1.DataSource = new BindingSource(yapilacaklar, null);

            dataGridView1.DataSource = list.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["ad"].Value.ToString();
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["sira"].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells["yapılacak islem"].Value.ToString();
                checkBox1.Checked = (Boolean)dataGridView1.CurrentRow.Cells["indirim"].Value;
                dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells["tarih"].Value;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                   string.IsNullOrWhiteSpace(maskedTextBox1.Text) ||
                   string.IsNullOrWhiteSpace(textBox3.Text) ||
                   comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Tüm alanlar doldurulmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ad = textBox1.Text;
            string telefon = maskedTextBox1.Text;
            string sira = textBox3.Text;
            bool indirim = checkBox1.Checked;
            DateTime tarih = dateTimePicker1.Value;
            string yapilacak = comboBox1.Text;

         

            if (ad.Any(char.IsDigit) || ad.Any(char.IsDigit))
            {
                MessageBox.Show("Ad ve soyad kısmında rakam olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (telefon.Any(char.IsLetter))
            {
                MessageBox.Show("Telefon kısmında harf bulunamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
               
            foreach (var item in list)
            {
                if (item.Ad == ad && item.Telefon == telefon && item.Sira == sira && item.Tarih == tarih && item.Yapilacak == yapilacak)
                {
                    MessageBox.Show("Aynı randevu zaten mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Sinif Randevu = new Sinif(sira, ad, telefon, tarih, indirim, yapilacak);

            list.Add(Randevu);
            dataGridView1.DataSource = list.ToList();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow SelectedRow = dataGridView1.SelectedRows[0];
                Sinif secilenRandevu = SelectedRow.DataBoundItem as Sinif;

                if (secilenRandevu != null)
                {
                    if (list.Contains(secilenRandevu))
                    {
                        list.Remove(secilenRandevu);
                    }
                }
            }
            dataGridView1.DataSource = list.ToList();
        }      

        private void button3_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Sinif secilenRandevu = selectedRow.DataBoundItem as Sinif;

            if (secilenRandevu != null)
            {
                string ad = textBox1.Text;
                string telefon = maskedTextBox1.Text;
                string sira = textBox3.Text;
                bool indirim = checkBox1.Checked;
                DateTime tarih = dateTimePicker1.Value;
                string yapilacak = comboBox1.Text;

                secilenRandevu.Ad = ad;
                secilenRandevu.Telefon = telefon;
                secilenRandevu.Sira = sira;
                secilenRandevu.İndirim = indirim;
                secilenRandevu.Tarih = tarih;
                secilenRandevu.Yapilacak = yapilacak;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox3.Text = "";
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                label7.Text = comboBox1.SelectedValue.ToString();
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (comboBox1.SelectedItem != null)
                {
                    double ucret = Convert.ToDouble(comboBox1.SelectedValue.ToString());
                    double indirim = ucret * 10 / 100;
                    double tutar = ucret - indirim;
                    label7.Text = "indirimli deger:" + tutar.ToString();

                }
            }
            else
            {
                label7.Text = "";
            }
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
