using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    class DbAddCategories
    {
        public void AddData(string id, string name, string parent, string image)
        {
            
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Администратор\source\repos\TestApp\TestApp\ServiceDataBase.mdf;Integrated Security=True";
            

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("CategoriesProcedure", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter idParam = new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = id
                    };

                    command.Parameters.Add(idParam);
                    
                    SqlParameter nameParam = new SqlParameter
                    {
                        ParameterName = "@Name",
                        Value = name
                    };

                    command.Parameters.Add(nameParam);

                    SqlParameter parentParam = new SqlParameter
                    {
                        ParameterName = "@Parent",
                        Value = parent
                    };

                    command.Parameters.Add(parentParam);

                    SqlParameter imageParam = new SqlParameter
                    {
                        ParameterName = "@Image",
                        Value = image
                    };

                    command.Parameters.Add(imageParam);

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
    }
}
