using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security;
using System.Text.RegularExpressions;


namespace PS__Usage
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
                    

        var Url = "https://spe307094.sharepoint.com/sites/pwa/_layouts/15/AppMonitoringDetails.aspx?AppInstanceId=cfd1d02d-3c27-4224-a3a3-55a700b3c402";
            HtmlWeb web = new HtmlWeb();
                        
            webBrowser1.Navigate(Url);
            
                        
            var baseUri = new Uri("https://spe307094.sharepoint.com/sites/pwa/_layouts/15/AppMonitoringChart.aspx?Launches="); // Using this to construnct from the img SRC

            // Div and Src for different charts
            // DAY
            // <div id="Chart14DayLU"... | <Img id="ctl00_PlaceHolderMain_launchesChartImage14Day"
            // SRC: https://spe307094.sharepoint.com/sites/pwa/_layouts/15/AppMonitoringChart.aspx?Launches=Days&Data=0|99|0|0|1|5|4|3|3|0|0|1|4|0|0|1|0|0|1|1|1|2|1|0|0|1|2|0
            // MONTH
            //<div id="Chart1YearLU"... | <Img id="ctl00_PlaceHolderMain_launchesChartImage1Year"
            // SRC: https://spe307094.sharepoint.com/sites/pwa/_layouts/15/AppMonitoringChart.aspx?Launches=Month&Data=0|99|0|0|1|5|4|3|3|0|0|1|4|0|0|1|0|0|1|1|1|2|1|0|0|1|2|0
            // YEAR
            //<div id="Chart3YearLU"... | <Img id="ctl00_PlaceHolderMain_launchesChartImage3Year"
            // SRC: https://spe307094.sharepoint.com/sites/pwa/_layouts/15/AppMonitoringChart.aspx?Launches=Year&Data=0|99|0|0|1|5|4|3|3|0|0|1|4|0|0|1|0|0|1|1|1|2|1|0|0|1|2|0

            webBrowser1.Navigate(Url);
            Console.WriteLine(webBrowser1.Document);
            webBrowser1.Visible = true;
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            auth frm = new auth();
            frm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var baseUri = new Uri("https://spe307094.sharepoint.com/sites/pwa/_layouts/15/AppMonitoringChart.aspx?Launches="); // Using this to construnct from the img SRC

            textBox1.Text = webBrowser1.DocumentText;
            string pagecode = textBox1.Text;

            string test1 = "<div: class test test tet test test tes tes tes ts src: dhjkdhjklhjkhljkdhjkdnhaunfhi class /div>"; //testing if returns desired stuff

            //System.Console.WriteLine("\"{0}\"", pagecode);
            bool initial = pagecode.StartsWith("Chart.aspx?");
            System.Console.WriteLine("Starts with \"Chart.aspx?\"? {0}", initial);

            bool second = pagecode.StartsWith("Chart.aspx?", System.StringComparison.CurrentCultureIgnoreCase);
            System.Console.WriteLine("Starts with \"Chart.aspx?\"? {0} (ignoring case)", second);

            bool end = pagecode.EndsWith("Chart1YearLU", System.StringComparison.CurrentCultureIgnoreCase);
            System.Console.WriteLine("Ends with 'Chart1YearLU'? {0}", end);

            int first = pagecode.IndexOf("Launches=") + "Launches=".Length;
            int last = pagecode.LastIndexOf("\" alt=\"Launches Graph\" />");
            string threecharts = pagecode.Substring(first, last - first);
            System.Console.WriteLine("Substring between \"Chart.aspx ? Launches = Days & amp; Data =\" AND Chart1YearLU: '{0}'", threecharts);

            //Getting match to construct the Day URL chart
            Regex daychart = new Regex("Days.*?[^\"]*");
            Match match = daychart.Match(threecharts);
            //Console.WriteLine("Days match: " + match.Value);
            string daycharturl = baseUri + match.Value;
            daycharturl = daycharturl.Replace("&amp;", "&");
            Console.WriteLine("Chart Day URL: " + daycharturl);

            //Getting match to construct the Month URL chart
            Regex monthchart = new Regex("Month.*?[^\"]*");
            Match matchxmonth = monthchart.Match(threecharts);
            //Console.WriteLine("Month match: " + matchxmonth.Value);
            string monthcharturl = baseUri + matchxmonth.Value;
            monthcharturl = monthcharturl.Replace("&amp;", "&");
            Console.WriteLine("Chart Month URL: " + monthcharturl);

            //Getting match to construct the Year URL chart
            Regex yearchart = new Regex("Years.*?[^\"]*");
            Match matchxyear = yearchart.Match(threecharts);
            //Console.WriteLine("Year match: " + matchxyear.Value);
            string yearcharturl = baseUri + matchxyear.Value;
            yearcharturl = yearcharturl.Replace("&amp;", "&");
            Console.WriteLine("Chart Year URL: " + yearcharturl);

            webBrowser2.Navigate(daycharturl);
            webBrowser3.Navigate(monthcharturl);
            webBrowser4.Navigate(yearcharturl);

            ////get Chart Year using threecharts

            //bool initialx3 = pagecode.StartsWith("Chart.aspx?Launches=Days&amp;Data=");
            //System.Console.WriteLine("Starts with \"Chart.aspx?Launches=Days&amp;Data=\"? {0}", initial);

            //bool secondx3 = pagecode.StartsWith("Chart.aspx?Launches=Days&amp;Data=", System.StringComparison.CurrentCultureIgnoreCase);
            //System.Console.WriteLine("Starts with \"Chart.aspx?Launches=Days&amp;Data=\"? {0} (ignoring case)", second);

            //bool endx3 = pagecode.EndsWith("Chart1YearLU", System.StringComparison.CurrentCultureIgnoreCase);
            //System.Console.WriteLine("Ends with 'Chart1YearLU'? {0}", end);

            //int firstx3 = pagecode.IndexOf("Data=") + "Data=".Length;
            //int lastx3 = pagecode.LastIndexOf("\" alt=\"Launches Graph\" />");
            //string yearcharts = pagecode.Substring(first, last - first);
            //System.Console.WriteLine("Substring between \"Chart.aspx ? Launches = Days & amp; Data =\" AND Chart1YearLU: '{0}'", threecharts);


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
