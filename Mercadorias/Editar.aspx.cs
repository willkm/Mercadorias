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
    public partial class Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //recuperando o id do registro pela queryString
                int id;
                if (int.TryParse(Request.QueryString["id"], out id) == false)
                {
                    return;
                }

                //Itens do DropDownList
                ddlTpNegocio.DataTextField = "tipoNegocio";
                ddlTpNegocio.DataValueField = "id";
                ddlTpNegocio.DataBind();
                ddlTpNegocio.Items.Insert(0, new ListItem("Venda", "0"));
                ddlTpNegocio.Items.Insert(0, new ListItem("Compra", "1"));

                try
                {
                    //abre uma conexão com o banco
                    using (SqlConnection conn = ConnetionFactory.ConexaoSqlSever())
                    {

                        //Cria um comando para selecionar registros da tabela
                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM mercadorias WHERE idMercadoria =@id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                           
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                // Obtém os registros, um por vez
                                while (reader.Read() == true)
                                {


                                    tpMercadoria.Text = reader.GetString(1).ToString();
                                    textNome.Text = reader.GetString(2).ToString();
                                    txtquantidade.Text = reader.GetInt32(4).ToString();
                                    txtpreco.Text = reader.GetString(5).ToString();


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
            }
        }

        // botão que salva as alterções
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["id"], out id) == false)
            {
                return;
            }

            string nomeMercadoria = textNome.Text;
            string tipoMercadoria = tpMercadoria.Text;

            string tipoNegocio = ddlTpNegocio.SelectedItem.Text;

            string preco = txtpreco.Text;

            int quantidade;
            if (int.TryParse(txtquantidade.Text, out quantidade) == false)
            {
                return;
            }

            using (SqlConnection conn = ConnetionFactory.ConexaoSqlSever())
            {
                
                // Cria um comando para atualizar um registro da tabela
                using (SqlCommand cmd = new SqlCommand("UPDATE mercadorias SET tipoMercadoria = @tpMerc, nomeMercadoria = @nomeMerc, tipoNegocio = @tpNeg, quantidade = @quant, preco = @preco WHERE idMercadoria = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@tpMerc", tipoMercadoria);
                    cmd.Parameters.AddWithValue("@nomeMerc", nomeMercadoria);
                    cmd.Parameters.AddWithValue("@tpNeg", tipoNegocio);
                    cmd.Parameters.AddWithValue("@quant", quantidade);
                    cmd.Parameters.AddWithValue("@preco", preco);

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

            Response.Redirect("Lista.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lista.aspx");
        }
    }
}