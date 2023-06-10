using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace PHPCsharp_baglanti
{
    internal class connectionservice
    {
        static MySqlConnection mysqlbaganti = new MySqlConnection("Server=localhost;Database=phpoop;Uid=root;Pwd='';");

        public static bool IsConnected()
        {
            IsActive();
            String Hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            int durum = 1;
            mysqlbaganti.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = mysqlbaganti;
            cmd.CommandText = "SELECT * FROM kullanici WHERE hwid='" + Hwid +"' AND durum='"+durum+"'";
            MySqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                mysqlbaganti.Close();
                return true;
            }
            else
            {
                mysqlbaganti.Close();
                return false;
            }
        }

        public static bool IsActive()
        {
            string date;
            String Hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            mysqlbaganti.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = mysqlbaganti;
            cmd.CommandText = "SELECT * FROM kullanici WHERE hwid='" + Hwid + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                date = dr["kalan"].ToString();
                CultureInfo culture = new CultureInfo("tr-TR");
                DateTime tempdate = Convert.ToDateTime(date,culture);
                DateTime bugun = DateTime.Today;
                int sonuc = tempdate.CompareTo(bugun);
                if(sonuc == 1 || sonuc == 0)
                {
                    mysqlbaganti.Close();
                    return true;
                }
                else
                {
                    dr.Close();
                    MySqlCommand komut = new MySqlCommand();
                    komut.Connection = mysqlbaganti;
                    komut.CommandText = "UPDATE kullanici SET durum=@p1 WHERE hwid=@numara";
                    komut.Parameters.AddWithValue("@numara",Hwid);
                    komut.Parameters.AddWithValue("@p1","2");
                    mysqlbaganti.Close();
                    return false;
                }
            }
            else
            {
                mysqlbaganti.Close();
                return false;
            }
        }

        public static int membershipday()
        {
            string date;
            String Hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            mysqlbaganti.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = mysqlbaganti;
            cmd.CommandText = "SELECT * FROM kullanici WHERE hwid='" + Hwid + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                date = dr["kalan"].ToString();
                CultureInfo culture = new CultureInfo("tr-TR");
                DateTime tempdate = Convert.ToDateTime(date, culture);
                DateTime bugun = DateTime.Today;
                TimeSpan ts = tempdate - bugun;
                double toplamGun = ts.TotalDays;
                string kg = toplamGun.ToString();
                mysqlbaganti.Close();
                return Convert.ToInt32(kg);
            }
            return -1;
        }

    }
}
