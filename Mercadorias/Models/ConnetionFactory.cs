using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mercadorias.Models
{
    public static class ConnetionFactory
    {
        public static SqlConnection ConexaoSqlSever(){

            try
            {
                SqlConnection conn = new SqlConnection("Server=tcp:cadastro.database.windows.net,1433;Initial Catalog=Cadastro;Persist Security Info=False;User ID=willfelipe;Password=Band123ATW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                conn.Open();

                return conn;
            }
            catch (SqlException)
            {

                throw;
            }

        }
    }
}