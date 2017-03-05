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
    public partial class lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            List<Mercadoria> mercadorias = new List<Mercadoria>();
            try
            {
                using (SqlConnection conn = ConnetionFactory.ConexaoSqlSever())
                {

                    //Cria um comando para selecionar registros da tabela
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM mercadorias ORDER BY idMercadoria ASC", conn))
                    {

                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Obtém os registros, um por vez
                            while (reader.Read() == true)
                            {
                                Mercadoria mercadoria = new Mercadoria();
                                mercadoria.IdMercadoria = reader.GetInt32(0);
                                mercadoria.TipoMercadoria = reader.GetString(1);
                                mercadoria.NomeMercadoria = reader.GetString(2);
                                mercadoria.TipoNegocio = reader.GetString(3);
                                mercadoria.Quantidade = reader.GetInt32(4);
                                mercadoria.Preco = reader.GetString(5);

                                mercadorias.Add(mercadoria);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

            listRepeater.DataSource = mercadorias;
            listRepeater.DataBind();

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cadastro.aspx");
        }
    }
}