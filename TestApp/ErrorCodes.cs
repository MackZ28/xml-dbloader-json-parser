using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TestApp
{
    public class ErrorCodes
    {
        public string codeVal { get; set; }
        public string textVal { get; set; }

       
        public List<string> GetData()
        {

            DbAddErrorCodes dbAddErrorCodes = new DbAddErrorCodes();

            XmlDocument docCodes = new XmlDocument();

            var errorCodesList = new List<string>();

            docCodes.Load("https://pastebin.com/raw/qvZiZDHW");

            XmlNodeList elemCode = docCodes.GetElementsByTagName("Code");
            for (int i = 0; i < elemCode.Count; i++)
            {
                codeVal = elemCode[i].Attributes["code"].Value;
                textVal = elemCode[i].Attributes["text"].Value;
                
                errorCodesList.Add(codeVal + " - " + textVal);

                dbAddErrorCodes.AddData(codeVal, textVal);
            }

            return errorCodesList;
        }
    }
}
