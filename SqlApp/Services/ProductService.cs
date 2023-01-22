using SqlApp.Models;
using System.Data.SqlClient;

namespace SqlApp.Services
{
    public class ProductService
    {
        public static string db_source = "dbserver1209.database.windows.net";
        public static string db_user = "demoUser";
        public static string db_password = "Qwerty12345@";
        public static string db_name = "Appdb";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource= db_source;
            _builder.UserID= db_user;
            _builder.Password= db_password;
            _builder.InitialCatalog= db_name;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            var productls = new List<Product>();
            var conn = GetConnection();
            string statement = "Select ProductID, ProductName, Quantity from Products";

            conn.Open();
            SqlCommand command = new SqlCommand(statement, conn);

            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        productId = reader.GetInt32(0),
                        productName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    productls.Add(product);
                }

                
            }
            return productls;
        }


    }
}
