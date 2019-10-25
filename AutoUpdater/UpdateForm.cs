using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AutoUpdaterDotNET
{
    internal partial class UpdateForm : Form
    {
        private System.Timers.Timer _timer;

        public UpdateForm(bool remindLater = false)
        {
            if (!remindLater)
            {
                this.InitializeComponent();
                var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
                this.Text = AutoUpdater.DialogTitle;
                this.labelUpdate.Text = String.Format(resources.GetString("labelUpdate.Text", CultureInfo.CurrentCulture), AutoUpdater.AppTitle);
                this.labelDescription.Text =
                    String.Format(resources.GetString("labelDescription.Text", CultureInfo.CurrentCulture),
                        AutoUpdater.AppTitle, AutoUpdater.CurrentVersion, AutoUpdater.InstalledVersion);
            }
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void UpdateFormLoad(object sender, EventArgs e)
        {
            //webBrowser.Navigate(AutoUpdater.ChangeLogURL);
        }

        private void ButtonUpdateClick(object sender, EventArgs e)
        {
            if (AutoUpdater.OpenDownloadPage)
            {
                var processStartInfo = new ProcessStartInfo(AutoUpdater.DownloadURL);

                Process.Start(processStartInfo);
            }
            else
            {
                var downloadDialog = new DownloadUpdateDialog(AutoUpdater.DownloadURL);

                try
                {
                    downloadDialog.ShowDialog();
                }
                catch (System.Reflection.TargetInvocationException)
                {
                }
            }
        }

        private void ButtonSkipClick(object sender, EventArgs e)
        {
            var updateKey = Registry.CurrentUser.CreateSubKey(AutoUpdater.RegistryLocation);
            if (updateKey != null)
            {
                updateKey.SetValue("version", AutoUpdater.CurrentVersion.ToString());
                updateKey.SetValue("skip", 1);
                updateKey.Close();
            }
        }

        private void ButtonRemindLaterClick(object sender, EventArgs e)
        {
            if (AutoUpdater.LetUserSelectRemindLater)
            {
                var remindLaterForm = new RemindLaterForm();

                var dialogResult = remindLaterForm.ShowDialog();

                if (dialogResult.Equals(DialogResult.OK))
                {
                    AutoUpdater.RemindLaterTimeSpan = remindLaterForm.RemindLaterFormat;
                    AutoUpdater.RemindLaterAt = remindLaterForm.RemindLaterAt;
                }
                else if (dialogResult.Equals(DialogResult.Abort))
                {
                    var downloadDialog = new DownloadUpdateDialog(AutoUpdater.DownloadURL);

                    try
                    {
                        downloadDialog.ShowDialog();
                    }
                    catch (System.Reflection.TargetInvocationException)
                    {
                        return;
                    }
                    return;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            var updateKey = Registry.CurrentUser.CreateSubKey(AutoUpdater.RegistryLocation);
            if (updateKey != null)
            {
                updateKey.SetValue("version", AutoUpdater.CurrentVersion);
                updateKey.SetValue("skip", 0);
                var remindLaterDateTime = DateTime.Now;
                switch (AutoUpdater.RemindLaterTimeSpan)
                {
                    case AutoUpdater.RemindLaterFormat.Days:
                        remindLaterDateTime = DateTime.Now + TimeSpan.FromDays(AutoUpdater.RemindLaterAt);
                        break;
                    case AutoUpdater.RemindLaterFormat.Hours:
                        remindLaterDateTime = DateTime.Now + TimeSpan.FromHours(AutoUpdater.RemindLaterAt);
                        break;
                    case AutoUpdater.RemindLaterFormat.Minutes:
                        remindLaterDateTime = DateTime.Now + TimeSpan.FromMinutes(AutoUpdater.RemindLaterAt);
                        break;

                }
                updateKey.SetValue("remindlater", remindLaterDateTime.ToString(CultureInfo.CreateSpecificCulture("en-US")));
                this.SetTimer(remindLaterDateTime);
                updateKey.Close();
            }
        }

        public void SetTimer(DateTime remindLater)
        {
            var timeSpan = remindLater - DateTime.Now;
            this._timer = new System.Timers.Timer
            {
                Interval = (int)timeSpan.TotalMilliseconds
            };
            this._timer.Elapsed += this.TimerElapsed;
            this._timer.Start();
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this._timer.Stop();
            AutoUpdater.Start();
        }
    }
}
