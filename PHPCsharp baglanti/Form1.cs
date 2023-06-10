using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace PHPCsharp_baglanti
{
    public partial class Form1 : Form
    {

        MySqlConnection mysqlbaganti = new MySqlConnection("Server=localhost;Database=phpoop;Uid=root;Pwd='';");
        MySqlCommand cmd;
        MySqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String Hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            textBox1.Text = Hwid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            int durum = 1;
            cmd = new MySqlCommand();
            mysqlbaganti.Open();
            cmd.Connection = mysqlbaganti;
            cmd.CommandText = "SELECT * FROM kullanici WHERE hwid='"+Hwid+"' AND durum='"+durum+"'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Hoş Geldiniz " + dr["kullanici_adi"] +" Bey");
                Form F2 = new Form2();
                this.Hide();
                F2.Show();
            }
            else
            {
                MessageBox.Show("Aktif üyeliğiniz bulunmuyor");
            }
            mysqlbaganti.Close();
        }
    }
}
