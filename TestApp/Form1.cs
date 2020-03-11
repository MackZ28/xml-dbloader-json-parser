using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TestApp
{
    public partial class Form1 : Form
    {
        ErrorCodes codes = new ErrorCodes();

        Categories categories = new Categories();

        JsonToTxt jsonToTxt = new JsonToTxt();

        
        public Form1()
        {
            InitializeComponent();
        }


        private async void SeekButton_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            
            await Task.Run(() => {
                jsonToTxt.JsonParse();
            });
            
            List<string> errorCodesRes = await Task.Factory.StartNew<List<string>>(
                                             () => codes.GetData(),
                                             TaskCreationOptions.None);

            foreach(string res in errorCodesRes)
            {
                listView.Items.Add(new ListViewItem(res));
            }

            List<string> categoriesRes = await Task.Factory.StartNew<List<string>>(
                                             () => categories.GetData(),
                                             TaskCreationOptions.None);

            

            foreach (string res in categoriesRes)
            {
                listView1.Items.Add(new ListViewItem(res));
            }
            
        }
    }
}
