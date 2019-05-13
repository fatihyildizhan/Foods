using System.Linq;
using System.Data;
using System.Collections.Generic;
// Dapper
using Dapper;
// Self
using Foods.Data.Models;

namespace Foods.Data
{
    public class CurrencyDataAccess
    {
        public List<Currency> GetCurrencies()
        {
            using (IDbConnection con = new System.Data.SqlClient.SqlConnection(Helper.ConValue("FoodsDB")))
            {
                // "dbo.sp_GetCountries @name", new { name = name }
                return con.Query<Currency>("SELECT * FROM Currencies").ToList();
            }
        }
    }
}
