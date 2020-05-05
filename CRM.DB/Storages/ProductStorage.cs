using CRM.DB.Models;
using Dapper;
using System;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CRM.Core.ConfigurationOptions;

namespace CRM.DB.Storages
{
    public class ProductStorage : IProductStorage
    {
		//private const string dbconnectionString = @"Data Source=EVS1G-MASH1N3;
		//	Initial Catalog=DevEduHomeWork;
		//	Integrated Security=True;
		//	Connect Timeout=30;
		//	Encrypt=False;
		//	TrustServerCertificate=False;
		//	ApplicationIntent=ReadWrite;
		//	MultiSubnetFailover=False";

		private IDbConnection _connection;

		public ProductStorage(IOptions<StorageOptions> storageOptions)
		{
			_connection = new SqlConnection(storageOptions.Value.DBConnectionString);
		}

		internal static class SpName
        {
            public const string ProductsGetAll = "Product_SelectAll";
            public const string ProductGetById = "Product_GetById";
        }

		public async ValueTask<Product> ProductGetById(int? id)
		{
			try
			{
				DynamicParameters param = new DynamicParameters(new { id });
				var result = await _connection.QueryAsync<Product>(
					SpName.ProductGetById,
					param,
					commandType: CommandType.StoredProcedure);
				return result.FirstOrDefault();
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
	}
}
