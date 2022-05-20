using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sonal_DropDown.Models
{
    public class CascadeDDL
    {
        private DbConfig db = new DbConfig();
        public List<Cascading> GetCountries()
        {
            SqlCommand cmd = new SqlCommand("SP_GetCountry", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            //open coonection if it's closed
            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();

            var result = cmd.ExecuteReader();
            List<Cascading> ls = new List<Cascading>();
            while(result.Read())
            {
                Cascading obj = new Cascading();
                obj.Id =(int) result[0];
                obj.Name =result[1].ToString();
                ls.Add(obj);
            }
            db.sql.Close();
            return ls;
        }

        public List<Cascading> GetStates(int Id)
        {
            SqlCommand cmd = new SqlCommand("SP_GetState", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@CountryId";
            sqlParameter.Value = Id;
            sqlParameter.DbType = DbType.Int32;
            cmd.Parameters.Add(sqlParameter);

            //open coonection if it's closed
            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();

            SqlDataReader result = cmd.ExecuteReader();

            List<Cascading> statelist = new List<Cascading>();
            while (result.Read())
            {
                Cascading obj = new Cascading();
                obj.Id = (int)result[0];
                obj.Name = result[1].ToString();
                statelist.Add(obj);
            }
            db.sql.Close();
            return statelist;
        }

        public List<Cascading> GetCities(int Id)
        {
            SqlCommand cmd = new SqlCommand("SP_GetCity", db.sql);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@StateId";
            sqlParameter.Value = Id;
            sqlParameter.DbType = DbType.Int32;
            cmd.Parameters.Add(sqlParameter);
            //open coonection if it's closed
            if (db.sql.State == ConnectionState.Closed)
                db.sql.Open();

            SqlDataReader result = cmd.ExecuteReader();
            List<Cascading> cityList = new List<Cascading>();
            while (result.Read())
            {
                Cascading obj = new Cascading();
                obj.Id = (int)result[0];
                obj.Name = result[1].ToString();
                cityList.Add(obj);
            }
            db.sql.Close();
            return cityList;
        }

    }
}