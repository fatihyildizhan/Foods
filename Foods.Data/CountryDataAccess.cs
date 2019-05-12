using System.Linq;
using System.Data;
using System.Collections.Generic;
// Dapper
using Dapper;
// Self
using Foods.Data.Models;

namespace Foods.Data
{
    public class CountryDataAccess
    {
        public List<Country> GetCountries()
        {
            using (IDbConnection con = new System.Data.SqlClient.SqlConnection(Helper.ConValue("FoodsDB")))
            {
                // "dbo.sp_GetCountries @name", new { name = name }
                return con.Query<Country>("dbo.sp_GetCountries").ToList();
            }
        }

        public void AddCountry(string name, string abbrv)
        {
            using (IDbConnection con = new System.Data.SqlClient.SqlConnection(Helper.ConValue("FoodsDB")))
            {
                Country c = new Country { Name = name, Abbr = abbrv };
                con.Execute("dbo.sp_insertCountry @name, @abbr", c);
            }
        }
    }
}
