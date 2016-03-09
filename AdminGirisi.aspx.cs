using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace WebTabanlıProjeEczaneStokTakip
{
    public partial class AdminGirisi1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='C:\\Users\\muge\\Documents\\Visual Studio 2010\\Projects\\WebTabanlıProjeEczaneStokTakip\\WebTabanlıProjeEczaneStokTakip\\Admin.mdb'");
            baglanti.Open();
            string ad = txtAd1.Text;
            string sifre = txtSifre1.Text;
            OleDbCommand kaydetcmd = new OleDbCommand("SELECT * From Adminler WHERE Ad = '" + ad + "' AND Sifre = '" + sifre +"'",baglanti);
            OleDbDataReader oku = kaydetcmd.ExecuteReader();
            
            
            if (oku.Read())
            {
                Session["adminAdi"] = oku["Ad"].ToString();
                Session["adminSifre"] = oku["Sifre"].ToString();
                Response.Redirect("Adminİslemleri.aspx");
                
            }
            else if(txtAd1.Text == "")
            {
                lblDurum.Visible = true;
                lblDurum.Text = "Kullanıcı adı alanı boş bırakılamaz.";
            }
            else if(txtSifre1.Text == "")
            {
                lblDurum.Visible = true;
                lblDurum.Text = "Şifre alanı boş bırakılamaz.";
            }
            else
            {
                lblDurum.Visible = true;
                lblDurum.Text = "Kullanıcı adi veya şifre hatalı";
            }
            baglanti.Close();
            baglanti.Dispose();

        }

        
    }
}