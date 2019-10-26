using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Morysoft.MorySnip.Modules;

namespace Morysoft.MorySnip
{
    public class FormSaveBase : Form
    {
        private FormSaveBase _saveForm;

        public FormSaveBase SaveForm
        {
            get
            {
                if (this._saveForm == null)
                {
                    this._saveForm = new FormEdit();
                }

                return this._saveForm;
            }
            set => this._saveForm = value;
        }

        public List<Screenshot> Screenshotes { get; } = new List<Screenshot>();

        public int AddImageFromSnippingTool()
        {
            int imagesCount = this.Screenshotes.Count;

            this.Hide();

            using (var withBlock = new FormSnippingTool
            {
                SaveForm = this
            })
            {
                withBlock.ShowDialog();
            }

            this.Show();

            return this.Screenshotes.Count - imagesCount;
        }

        public void SnipFromClipboard()
        {
            var screenshotes = Snipper.FromClipboard();

            this.SaveForm.Screenshotes.AddRange(screenshotes);

            if (this.SaveForm.Screenshotes.Count == 0)
            {
                Interaction.MsgBox("No image or image file path in clipboard.", MsgBoxStyle.Critical);
            }
            else
            {
                this.SaveForm.Show();
                this.Close();
            }
        }

        public void SnipFullScreen()
        {
            this.Hide();

            this.SaveForm.Screenshotes.AddRange(Snipper.AllScreens());

            this.SaveForm.Show();

            this.Close();
        }

        public void SnipScreen(int index) => throw new NotImplementedException();

        public void SnipFromFile()
        {
            this.Hide();

            var screenshotes = Snipper.FromFiles();

            if (!screenshotes.Any())
            {
                this.Show();
            }
            else
            {
                this.SaveForm.Screenshotes.AddRange(screenshotes);

                this.SaveForm.Show();
                this.Close();
            }
        }
    }
}
