using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    class DbAddErrorCodes 
    {
        public void AddData(string code, string text)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Администратор\source\repos\TestApp\TestApp\ServiceDataBase.mdf;Integrated Security=True";
            

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("ErrorCodeProcedure", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter codeParam = new SqlParameter
                    {
                        ParameterName = "@Code",
                        Value = code   
                    }; 

                    command.Parameters.Add(codeParam);
                    

                    SqlParameter textParam = new SqlParameter
                    {
                        ParameterName = "@Text",
                        Value = text
                    }; 

                    command.Parameters.Add(textParam);
                    
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
