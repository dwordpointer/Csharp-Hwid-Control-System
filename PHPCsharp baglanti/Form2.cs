using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHPCsharp_baglanti
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public bool InternetControl()
        {
        try 
        {
            System.Net.Sockets.TcpClient kontrol = new System.Net.Sockets.TcpClient("www.google.com.tr",80);
            kontrol.Close();
            return true;
        }
        catch(Exception e)
        {
            
            return false;
        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool a = connectionservice.IsConnected();
            if (a)
            {
                //kayıt işlemleri vs vs
            }   
            else
            {
                MessageBox.Show("Süreniz Bitmiştir.");
                Application.Exit();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            bool kontrol = InternetControl();
            if (kontrol == false)
            {
                MessageBox.Show("İnternetiniz bulunmuyor.");
            }
            else
            {
                if (connectionservice.membershipday()>5)
                {
                    label1.Text = "Kalan üyelik gün sayısı: " + connectionservice.membershipday().ToString();
                }
                else if(connectionservice.membershipday() == 0)
                {
                    label1.Text = "Son gününüz";
                    label1.ForeColor = Color.Red;
                }
                else
                {
                    label1.Text = "Kalan üyelik gün sayısı: " + connectionservice.membershipday().ToString();
                    label1.ForeColor = Color.Blue;
                }
            }
        }
    }
}
