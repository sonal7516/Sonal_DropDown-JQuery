using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sonal_DropDown.Models
{
    public class DbConfig
    {
        public SqlConnection sql { get; set; }

        public DbConfig()
        {
            string Cnn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            sql = new SqlConnection(Cnn);
        }
    }
}