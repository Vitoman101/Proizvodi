using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Proizvodi
{
    public partial class index : System.Web.UI.Page
    {
        string connectionString = @"Server=localhost;Database=ASPNET;Uid=root;pwd=asd123";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Clear();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand sqlCmd = new MySqlCommand("ProizvodAddOrEdit", sqlCon);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("_id", Convert.ToInt32(id.Value == "" ? "0" : id.Value));
                    sqlCmd.Parameters.AddWithValue("_naziv", txtNaziv.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_opis", txtOpis.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_kategorija", txtKategorija.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_dobavljac", txtDobavljac.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_proizvodjac", txtProizvodjac.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("_cena", Convert.ToDecimal(txtCena.Text.Trim()));
                    sqlCmd.ExecuteNonQuery();
                    Clear();
                    lblSuccessMessage.Text = "Podatak je unet u bazu";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        void Clear()
        {
            id.Value = "";
            txtNaziv.Text = txtCena.Text = txtDobavljac.Text = txtKategorija.Text = txtOpis.Text = txtProizvodjac.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            lblErrorMessage.Text = lblSuccessMessage.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void GridFill()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString)) 
            { 
                sqlCon            
            }
        }
    }
}