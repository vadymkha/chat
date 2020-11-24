using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(textBox1.Text);
            req.Method = "GET";
            if(checkBox1.Checked==true)
            {
                WebProxy proxy = new WebProxy(textBox2.Text);
                proxy.Credentials = new NetworkCredential(textBox3.Text, textBox4.Text);
                req.Proxy = proxy;
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default);
            textBox5.Text = sr.ReadToEnd();
        }
    }
}
