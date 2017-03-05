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
    public partial class Cadastro1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                //Itens do DropDownList
                ddlTpNegocio.DataTextField = "tipoNegocio";
                ddlTpNegocio.DataValueField = "id";
                ddlTpNegocio.DataBind();
                ddlTpNegocio.Items.Insert(0, new ListItem("Venda", "0"));
                ddlTpNegocio.Items.Insert(0, new ListItem("Compra", "1"));

                // lista de mercadorias obtidas do banco
                List<Mercadoria> mercadorias = new List<Mercadoria>();
                try
                {
                    //abre uma conexão com o banco
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
                        //fecha a conexão
                        conn.Close();
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                // adiciona as mercadorias no repeater(Table)
                listRepeater.DataSource = mercadorias;
                listRepeater.DataBind();


            

        }

        //Botão de cadastro
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            string nomeMercadoria = textNome.Text;
            string tipoMercadoria = tpMercadoria.Text;

            string tipoNegocio = ddlTpNegocio.SelectedItem.Text;

            string preco = txtpreco.Text;
           
            int quantidade;
            if (int.TryParse(txtquantidade.Text, out quantidade) == false)
            {
                return;
            }


            //abre uma conexão com o banco
            using (SqlConnection conn = ConnetionFactory.ConexaoSqlSever())
            {
                
                // Cria um comando para selecionar registros da tabela
                using (SqlCommand cmd = new SqlCommand("insert into mercadorias (tipoMercadoria, nomeMercadoria, tipoNegocio, quantidade, preco) VALUES (@tipoMercadoria, @nomeMercadoria, @tipoNegocio, @quantidade, @preco);", conn))
                {



                    cmd.Parameters.AddWithValue("@tipoMercadoria", tipoMercadoria);
                    cmd.Parameters.AddWithValue("@nomeMercadoria", nomeMercadoria);
                    cmd.Parameters.AddWithValue("@tipoNegocio", tipoNegocio);
                    cmd.Parameters.AddWithValue("@quantidade", quantidade);
                    cmd.Parameters.AddWithValue("@preco", preco);

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
            }


            Response.Redirect("Lista.aspx");
        }
    }
}