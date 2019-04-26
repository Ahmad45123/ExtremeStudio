using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtremeStudio.FunctionsForms
{
    public partial class DownloadForm : Form
    {
        public WebClient client = new WebClient();
        public string result = "";

        public DownloadForm()
        {
            client.Headers["User-Agent"] = "ExtremeStudio";
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadStringCompleted += Client_DownloadStringCompleted;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            InitializeComponent();
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                Close();
            });
        }

        private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                result = e.Result;
                Close();
            });
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                progressBar1.Value = e.ProgressPercentage;
            bytesDl.Text = e.BytesReceived/1000 + "KB of " + e.TotalBytesToReceive/1000 + "KB";
            });
        }

        public static string DownloadString(string desc, string link)
        {
            DownloadForm form = new DownloadForm();
            form.descLabel.Text = desc;
            form.client.DownloadStringAsync(new Uri(link));
            form.ShowDialog();
            return form.result;
        }

        public static void DownloadFile(string desc, string link, string path)
        {
            DownloadForm form = new DownloadForm();
            form.descLabel.Text = desc;
            form.client.DownloadFileAsync(new Uri(link), path);
            form.ShowDialog();
        }
    }
}
