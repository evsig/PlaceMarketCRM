using CRM.DB.Models;
using Dapper;
using System;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.DB.Storages
{
    public class ProductStorage
    {
		private const string dbconnectionString = @"Data Source=EVS1G-MASH1N3;
			Initial Catalog=DevEduHomeWork;
			Integrated Security=True;
			Connect Timeout=30;
			Encrypt=False;
			TrustServerCertificate=False;
			ApplicationIntent=ReadWrite;
			MultiSubnetFailover=False";
        //private const string dbconnectionString = @"
        //    Data Source=.\SQLEXPRESS;
        //    Initial Catalog=DevEduHomeWork;
        //    Integrated Security=True";
        internal static class SpName
        {
            public const string ProductsGetAll = "Product_SelectAll";
            public const string ProductGetById = "Product_GetById";
            //public const string ProductGetById = "Product_SelectById";
            //public const string ProductSearch = "Product_Search";
        }

		public Product ProductGetById(int? id)
		{
			using IDbConnection сonnection = new SqlConnection(dbconnectionString);
			try
			{
				var result = сonnection.Query<Product>(
					SpName.ProductGetById,
					new { id },
					commandType: CommandType.StoredProcedure
				).First();
				return result;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}

		public List<Product> ProductsGetAll()
		{
			using IDbConnection сonnection = new SqlConnection(dbconnectionString);
			try
			{
				var result = сonnection.Query<Product>(
					SpName.ProductsGetAll,
					null,
					commandType: CommandType.StoredProcedure
					).ToList();
				return result;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
	}
}
