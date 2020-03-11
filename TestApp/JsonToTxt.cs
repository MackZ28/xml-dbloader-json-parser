using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Newtonsoft.Json;

namespace TestApp
{
    class JsonToTxt
    {

        public void JsonParse()
        {
            try
            {
                using (StreamReader reader = new StreamReader("C:/Users/Администратор/source/repos/TestApp/TestApp/Users.json"))
                {
                    string jsonFromFile = reader.ReadToEnd();

                    List<User> items = JsonConvert.DeserializeObject<List<User>>(jsonFromFile);

                    User user = new User();

                    foreach (var item in items)
                    {
                        //Console.WriteLine("{0} {1} {2} {3} {4}", item.FullName, item.Country, item.CreatedAt, item.Id, item.Email);

                        using (StreamWriter file = new StreamWriter(@"C:\Users\Администратор\source\repos\TestApp\TestApp\UserConverted.txt", true))
                        {
                            file.WriteLine("Имя: " + item.FullName + "; Страна: " + item.Country + "; Время создания: " + item.CreatedAt + "; ID: " + item.Id + "; Email: " + item.Email);
                        }
                    }

                    using (StreamWriter file = new StreamWriter(@"C:\Users\Администратор\source\repos\TestApp\TestApp\UserConverted.txt", true))
                    {
                        file.WriteLine("$" + items.Count + "|");
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        
    }
}
