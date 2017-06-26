using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

using System.Net;
using System.Security;

namespace PS__Usage
{
    public partial class auth : Form
    {
        string URL;
        string USERNAME;
        string PASSWORD;
        Microsoft.SharePoint.Client.ClientContext clientContextSource;

        public auth()
        {
            InitializeComponent();
        }

        private void auth_Load(object sender, EventArgs e)
        {
            textBox1.Text = "https://spe307094.sharepoint.com/";
            textBox2.Text = "renato.gomes@spe307094.onmicrosoft.com";
            textBox3.Text = "DAtsun77!";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            URL = textBox1.Text;
            USERNAME = textBox2.Text;
            PASSWORD = textBox3.Text;
            using (clientContextSource = new Microsoft.SharePoint.Client.ClientContext(URL))
            {
                /* For Converting Password to SecureString for Authenticating User To Sharepoint Online */

                SecureString encodedSourcepassWord = new SecureString();
                foreach (char c in PASSWORD) encodedSourcepassWord.AppendChar(c);
                clientContextSource.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(USERNAME, encodedSourcepassWord);

                /* For Converting Password to SecureString for Authenticating User To Sharepoint Online */
                /* For Defining the Security Channel you can see in the browser in which site is open */
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                /* For Defining the Security Channel you can see in the browser in which site is open */

                // Execute the query to the server.    
                try
                {
                    clientContextSource.ExecuteQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
                
                Console.WriteLine("Connected");

                //using HtmlAgilityPack;
                string Url = "https://spe307094.sharepoint.com";///sites/pwa/_layouts/15/AppMonitoringDetails.aspx?AppInstanceId=5d566d18-d5ce-4a4b-918c-d019c897d4c0";
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(Url);
                int x = 0;
                
                while (doc.DocumentNode.SelectNodes("//div")[x].InnerHtml != null)
                {
                    var pcode = doc.DocumentNode.SelectNodes("//div")[x].InnerHtml;
                    Console.WriteLine(pcode);
                    x++;
                }               

            }
        }
        
    }
}
