using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;

namespace Morysoft.MorySnip
{
    public partial class Form_Download
    {
        public string ShareId { get; set; }
        public int ItemsCount { get; set; }

        public void BeginDownload()
        {
            this.ProgressBar_Files.Maximum = this.ItemsCount;

            for (int i = 0, loopTo = this.ItemsCount - 1; i <= loopTo; i++)
            {
                do
                {
                    try
                    {
                        this.Download(this.ShareId + i.ToString("000"));
                        break;
                    }
                    catch (Exception ex)
                    {
                        switch (Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical | MsgBoxStyle.AbortRetryIgnore))
                        {
                            case MsgBoxResult.Retry:
                                {
                                    break;
                                }

                            case MsgBoxResult.Abort:
                                {
                                    break;
                                    break;
                                }

                            case MsgBoxResult.Ignore:
                                {
                                    break;
                                    break;
                                }
                        }
                    }
                }
                while (true);
                this.ProgressBar_Files.Value = i;
            }

            this.Close();
        }

        private void Download(string Id)
        {
            Network.DownloadFile(string.Format("http://share.cucak.am/snapshots/{0}.png", Id), string.Format(@"{1}\tmp\{0}.png", Id, System.IO.Path.des.SpecialDirectories.Desktop), "", "", true, 3000, true, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
        }

        private void Form_Download_Load(object sender, EventArgs e)
        {
        }

        private void Timer_Begin_Tick(object sender, EventArgs e)
        {
            this.Timer_Begin.Stop();
            this.BeginDownload();
        }
    }
}
