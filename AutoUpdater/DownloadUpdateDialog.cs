using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Windows.Forms;

namespace AutoUpdaterDotNET
{
    internal partial class DownloadUpdateDialog : Form
    {
        private readonly string _downloadURL;

        private string _tempPath;

        public DownloadUpdateDialog(string downloadURL)
        {
            this.InitializeComponent();

            this._downloadURL = downloadURL;
        }

        private void DownloadUpdateDialogLoad(object sender, EventArgs e)
        {
            var webClient = new WebClient();

            var uri = new Uri(this._downloadURL);

            this._tempPath = String.Format(@"{0}{1}", Path.GetTempPath(), GetFileName(this._downloadURL));

            webClient.DownloadProgressChanged += this.OnDownloadProgressChanged;

            webClient.DownloadFileCompleted += this.OnDownloadComplete;

            webClient.DownloadFileAsync(uri, this._tempPath);
        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) => this.progressBar.Value = e.ProgressPercentage;

        private void OnDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            var processStartInfo = new ProcessStartInfo { FileName = _tempPath, UseShellExecute = true };
            Process.Start(processStartInfo);
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(1);
            }
        }

        private static string GetFileName(string url)
        {
            string fileName = String.Empty;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            httpWebRequest.Method = "HEAD";
            httpWebRequest.AllowAutoRedirect = false;
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpWebResponse.StatusCode.Equals(HttpStatusCode.Redirect) || httpWebResponse.StatusCode.Equals(HttpStatusCode.Moved) || httpWebResponse.StatusCode.Equals(HttpStatusCode.MovedPermanently))
            {
                if (httpWebResponse.Headers["Location"] != null)
                {
                    string location = httpWebResponse.Headers["Location"];
                    fileName = GetFileName(location);
                    return fileName;
                }
            }
            if (httpWebResponse.Headers["content-disposition"] != null)
            {
                string contentDisposition = httpWebResponse.Headers["content-disposition"];
                if (!String.IsNullOrEmpty(contentDisposition))
                {
                    const string lookForFileName = "filename=";
                    int index = contentDisposition.IndexOf(lookForFileName, StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                    {
                        fileName = contentDisposition.Substring(index + lookForFileName.Length);
                    }

                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Substring(1, fileName.Length - 2);
                    }
                }
            }
            if (String.IsNullOrEmpty(fileName))
            {
                var uri = new Uri(url);

                fileName = Path.GetFileName(uri.LocalPath);
            }
            return fileName;
        }
    }
}
