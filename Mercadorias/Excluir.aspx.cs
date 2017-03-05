using Mercadorias.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                using (SqlConnection con = ConnetionFactory.ConexaoSqlSever())
                {
                    
                    using (SqlCommand comando = new SqlCommand("DELETE FROM mercadorias where idMercadoria = @id", con))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        comando.ExecuteNonQuery();
                    }
                    con.Close();
                }

            }
            catch (SqlException)
            {

                throw;
            }

            Response.Redirect("Lista.aspx");

        }
    }
}