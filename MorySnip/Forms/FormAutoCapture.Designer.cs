using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip
{
    [DesignerGenerated()]
    public partial class FormAutoCapture : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                    components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutoCapture));
            this._Label1 = new System.Windows.Forms.Label();
            this._NumericUpDown_Start = new System.Windows.Forms.NumericUpDown();
            this._Label2 = new System.Windows.Forms.Label();
            this._NumericUpDown_Interval = new System.Windows.Forms.NumericUpDown();
            this._Label3 = new System.Windows.Forms.Label();
            this._NumericUpDown_Count = new System.Windows.Forms.NumericUpDown();
            this._Button_Start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._NumericUpDown_Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._NumericUpDown_Interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._NumericUpDown_Count)).BeginInit();
            this.SuspendLayout();
            // 
            // _Label1
            // 
            resources.ApplyResources(this._Label1, "_Label1");
            this._Label1.Name = "_Label1";
            // 
            // _NumericUpDown_Start
            // 
            resources.ApplyResources(this._NumericUpDown_Start, "_NumericUpDown_Start");
            this._NumericUpDown_Start.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._NumericUpDown_Start.Name = "_NumericUpDown_Start";
            this._NumericUpDown_Start.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _Label2
            // 
            resources.ApplyResources(this._Label2, "_Label2");
            this._Label2.Name = "_Label2";
            // 
            // _NumericUpDown_Interval
            // 
            this._NumericUpDown_Interval.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            resources.ApplyResources(this._NumericUpDown_Interval, "_NumericUpDown_Interval");
            this._NumericUpDown_Interval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this._NumericUpDown_Interval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._NumericUpDown_Interval.Name = "_NumericUpDown_Interval";
            this._NumericUpDown_Interval.Value = new decimal(new int[] {
            333,
            0,
            0,
            0});
            // 
            // _Label3
            // 
            resources.ApplyResources(this._Label3, "_Label3");
            this._Label3.Name = "_Label3";
            // 
            // _NumericUpDown_Count
            // 
            resources.ApplyResources(this._NumericUpDown_Count, "_NumericUpDown_Count");
            this._NumericUpDown_Count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._NumericUpDown_Count.Name = "_NumericUpDown_Count";
            this._NumericUpDown_Count.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // _Button_Start
            // 
            resources.ApplyResources(this._Button_Start, "_Button_Start");
            this._Button_Start.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._Button_Start.Name = "_Button_Start";
            this._Button_Start.UseVisualStyleBackColor = true;
            // 
            // FormAutoCapture
            // 
            this.AcceptButton = this._Button_Start;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._Button_Start);
            this.Controls.Add(this._NumericUpDown_Count);
            this.Controls.Add(this._Label3);
            this.Controls.Add(this._NumericUpDown_Interval);
            this.Controls.Add(this._Label2);
            this.Controls.Add(this._NumericUpDown_Start);
            this.Controls.Add(this._Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutoCapture";
            ((System.ComponentModel.ISupportInitialize)(this._NumericUpDown_Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._NumericUpDown_Interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._NumericUpDown_Count)).EndInit();
            this.ResumeLayout(false);

        }
        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private NumericUpDown _NumericUpDown_Start;

        internal NumericUpDown NumericUpDown_Start
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NumericUpDown_Start;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NumericUpDown_Start != null)
                {
                }

                _NumericUpDown_Start = value;
                if (_NumericUpDown_Start != null)
                {
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private NumericUpDown _NumericUpDown_Interval;

        internal NumericUpDown NumericUpDown_Interval
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NumericUpDown_Interval;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NumericUpDown_Interval != null)
                {
                }

                _NumericUpDown_Interval = value;
                if (_NumericUpDown_Interval != null)
                {
                }
            }
        }

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private NumericUpDown _NumericUpDown_Count;

        internal NumericUpDown NumericUpDown_Count
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _NumericUpDown_Count;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_NumericUpDown_Count != null)
                {
                }

                _NumericUpDown_Count = value;
                if (_NumericUpDown_Count != null)
                {
                }
            }
        }

        private Button _Button_Start;

        internal Button Button_Start
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button_Start;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button_Start != null)
                {
                }

                _Button_Start = value;
                if (_Button_Start != null)
                {
                }
            }
        }
    }
}
