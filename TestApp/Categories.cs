using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TestApp
{
   public class Categories
    {
        public string idVal { get; set; }
        public string nameVal { get; set; }
        public string parentVal { get; set; }
        public string imageVal { get; set; }
        

        public List<string> GetData()
        {
            DbAddCategories dbAddCategories = new DbAddCategories();

            XmlDocument docCategories = new XmlDocument();

            var categoriesList = new List<string>();

            docCategories.Load("https://pastebin.com/raw/DaphFFN2");

            XmlNodeList elemCategory = docCategories.GetElementsByTagName("category");
            for (int i = 0; i < elemCategory.Count; i++)
            {
                idVal = elemCategory[i].Attributes["id"].Value;
                nameVal = elemCategory[i].Attributes["name"].Value;
                parentVal = elemCategory[i].Attributes["parent"].Value;
                imageVal = elemCategory[i].Attributes["image"].Value;

                categoriesList.Add(idVal + " - " + nameVal + " - " + parentVal + " - " + imageVal);

                dbAddCategories.AddData(idVal, nameVal, parentVal, imageVal);
            }

            return categoriesList;
        }
    }
}
