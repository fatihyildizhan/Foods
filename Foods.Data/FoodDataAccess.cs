using System.Linq;
using System.Data;
using System.Collections.Generic;
// Dapper
using Dapper;
// Self
using Foods.Data.Models;

namespace Foods.Data
{
    public class FoodDataAccess
    {
        public List<FoodFull> GetFoods()
        {
            using (IDbConnection con = new System.Data.SqlClient.SqlConnection(Helper.ConValue("FoodsDB")))
            {
                // "dbo.sp_GetCountries @name", new { name = name }
                return con.Query<FoodFull>("SELECT * FROM FoodsFull").ToList();
            }
        }

        public void AddFood(Food f)
        {
            using (IDbConnection con = new System.Data.SqlClient.SqlConnection(Helper.ConValue("FoodsDB")))
            {
                con.Execute("dbo.sp_insertFood @name, @price, @currencyId, @countryId", f);
            }
        }
    }
}
