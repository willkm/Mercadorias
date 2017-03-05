using Mercadorias.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mercadorias
{
    public partial class Excluir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int id;
            if (int.TryParse(Request.QueryString["id"], out id) == false)
            {
                return;
            }

            try
            {
                using (MySqlConnection con = ConnetionFactory.ConexaoMySql())
                {
                    con.Open();
                    using (MySqlCommand comando = new MySqlCommand("DELETE FROM mercadorias where idMercadoria = @id", con))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        comando.ExecuteNonQuery();
                    }
                    con.Close();
                }

            }
            catch (MySqlException)
            {

                throw;
            }

            Response.Redirect("Lista.aspx");

        }
    }
}