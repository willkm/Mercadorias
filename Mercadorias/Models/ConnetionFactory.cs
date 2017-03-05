using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mercadorias.Models
{
    public static class ConnetionFactory
    {
        public static MySqlConnection ConexaoMySql(){

            using (MySqlConnection conn = new MySqlConnection("Server = localhost; Database = cadastro; Uid = root; Pwd = root;"))
            {
                
                return conn;
            }

        }
    }
}