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
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }


        Sinif1 sinif1;
        BindingList<Sinif1> list = new BindingList<Sinif1>();

        Dictionary<string, double> yapilacaklar = new Dictionary<string, double> {

        { "ombre", 3500 },
        { "kaş alımı",100 },
        { "fön", 200 },
        { "maşa", 300 },
        { "makyaj", 1000 },
        { "kalıcı oje", 600 },
        { "saç kesimi", 400 },
        { "açma boyama", 3000 },
        { "dip boyama", 100 },

        };     

        private void Personel_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
            comboBox1.DataSource = new BindingSource(yapilacaklar, null);

            dataGridView1.DataSource = list.ToList();
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox3.Text) ||
               string.IsNullOrWhiteSpace(textBox4.Text) ||
               comboBox1.SelectedItem == null ||
               string.IsNullOrWhiteSpace(maskedTextBox1.Text) ||
               string.IsNullOrWhiteSpace(maskedTextBox2.Text) ||
               string.IsNullOrWhiteSpace(maskedTextBox3.Text) ||
               string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Tüm alanlar doldurulmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                       

            string sicil = textBox1.Text;
            string tcNo = textBox2.Text;
            string ad = textBox3.Text;
            string soyad = textBox4.Text;
            string yapilacak = comboBox1.Text;
            string telefon = maskedTextBox1.Text;
            string evTel = maskedTextBox2.Text;           
            string dogumTarih = maskedTextBox3.Text;
            string adres = textBox5.Text;

            // Ad ve Soyad alanında rakam olmadığını kontrol etme
            if (ad.Any(char.IsDigit) || soyad.Any(char.IsDigit))
            {
                MessageBox.Show("Ad ve Soyad alanları rakam içeremez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Sicil No ve TC Kimlik No içerisinde harf bulunmaması kontrolü
            if (textBox1.Text.Any(char.IsLetter) || textBox2.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Sicil No ve TC Kimlik No harf içeremez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sicil No ve TC Kimlik No uzunluk, rakam ve harf kontrolü
            if (textBox1.Text.Length != 16 || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Sicil No 16 rakamdan oluşmalıdır.", "Uyarı", MessageBoxButtons.OK);
                return;
            }

            if (textBox2.Text.Length != 11 || !textBox2.Text.All(char.IsDigit))
            {
                MessageBox.Show("TC Kimlik No 11 rakamdan oluşmalıdır.", "Uyarı", MessageBoxButtons.OK);
                return;
            }

            foreach (var item in list)
            {
                if (item.Sicil == sicil && item.TcNo == tcNo && item.Ad == ad && item.Soyad == soyad &&
                    item.Yapilacak == yapilacak && item.Telefon == telefon && item.EvTel == evTel &&
                    item.DogumTarih == dogumTarih && item.Adres == adres)
                {
                    MessageBox.Show("Aynı randevu zaten mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Sinif1 Personel = new Sinif1(sicil, tcNo, ad, soyad, yapilacak, telefon, evTel, dogumTarih, adres);

            list.Add(Personel);
            dataGridView1.DataSource = list.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow SelectedRow = dataGridView1.SelectedRows[0];
                Sinif1 secilenPersonel = SelectedRow.DataBoundItem as Sinif1;

                if (secilenPersonel != null)
                {
                    if (list.Contains(secilenPersonel))
                    {
                        list.Remove(secilenPersonel);
                    }
                }
            }
            dataGridView1.DataSource = list.ToList();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            textBox5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Sinif1 secilenPersonel = selectedRow.DataBoundItem as Sinif1;

            if (secilenPersonel != null)
            {
                string sicil =textBox1.Text;
                string tcNo = textBox2.Text;
                string ad = textBox3.Text;
                string soyad = textBox4.Text;
                string yapilacak = comboBox1.Text;
                string telefon = maskedTextBox1.Text;
                string evTel = maskedTextBox2.Text;
                string dogumTarih = maskedTextBox3.Text;
                string adres = textBox5.Text;

                secilenPersonel.Sicil = sicil;
                secilenPersonel.TcNo  = tcNo;
                secilenPersonel.Ad = ad;
                secilenPersonel.Soyad = soyad;
                secilenPersonel.Yapilacak = yapilacak;
                secilenPersonel.Telefon = telefon;
                secilenPersonel.EvTel = evTel;
                secilenPersonel.DogumTarih = dogumTarih;
                secilenPersonel.Adres = adres;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list;
            }
        }

       
       
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["Sicil No"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["TC No"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["cep tel"].Value.ToString();
                maskedTextBox2.Text = dataGridView1.CurrentRow.Cells["ev tel"].Value.ToString();
                maskedTextBox3.Text = dataGridView1.CurrentRow.Cells["dogum tarih"].Value.ToString();

                comboBox1.Text = dataGridView1.CurrentRow.Cells["yapılacak islem"].Value.ToString();


            }
            catch (Exception)
            {
                throw;
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 10 & textBox2.Text.Length < 12)
                MessageBox.Show("T.C Kimlik Numarası 11 den Küçük veya Büyük Olamaz");
        }
    }
}
