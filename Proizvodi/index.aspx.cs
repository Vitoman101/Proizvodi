using System;
using System.Collections.Generic;
using System.Data;
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
                GridFill();
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
                    GridFill();
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
                sqlCon.Open();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("ProizvodViewAll", sqlCon);
                sqlData.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                gvProizvod.DataSource = dtbl;
                gvProizvod.DataBind();
            }
        }

        protected void lnkSelect_OnClick(object sender, EventArgs e)
        {
            int proizvodID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlData = new MySqlDataAdapter("ProizvodViewByID", sqlCon);
                sqlData.SelectCommand.Parameters.AddWithValue("_id", proizvodID);
                sqlData.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlData.Fill(dtbl);
                txtNaziv.Text = dtbl.Rows[0][1].ToString();
                txtOpis.Text = dtbl.Rows[0][2].ToString();
                txtKategorija.Text = dtbl.Rows[0][3].ToString();
                txtProizvodjac.Text = dtbl.Rows[0][4].ToString();
                txtDobavljac.Text = dtbl.Rows[0][5].ToString();
                txtCena.Text = dtbl.Rows[0][6].ToString();

                id.Value = dtbl.Rows[0][0].ToString();

                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }
    }
}