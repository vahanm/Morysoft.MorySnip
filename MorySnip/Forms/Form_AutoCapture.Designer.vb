<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_AutoCapture
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_AutoCapture))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown_Start = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown_Interval = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumericUpDown_Count = New System.Windows.Forms.NumericUpDown()
        Me.Button_Start = New System.Windows.Forms.Button()
        CType(Me.NumericUpDown_Start, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Interval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Count, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'NumericUpDown_Start
        '
        resources.ApplyResources(Me.NumericUpDown_Start, "NumericUpDown_Start")
        Me.NumericUpDown_Start.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown_Start.Name = "NumericUpDown_Start"
        Me.NumericUpDown_Start.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'NumericUpDown_Interval
        '
        Me.NumericUpDown_Interval.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        resources.ApplyResources(Me.NumericUpDown_Interval, "NumericUpDown_Interval")
        Me.NumericUpDown_Interval.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDown_Interval.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.NumericUpDown_Interval.Name = "NumericUpDown_Interval"
        Me.NumericUpDown_Interval.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'NumericUpDown_Count
        '
        resources.ApplyResources(Me.NumericUpDown_Count, "NumericUpDown_Count")
        Me.NumericUpDown_Count.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown_Count.Name = "NumericUpDown_Count"
        Me.NumericUpDown_Count.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Button_Start
        '
        resources.ApplyResources(Me.Button_Start, "Button_Start")
        Me.Button_Start.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_Start.Name = "Button_Start"
        Me.Button_Start.UseVisualStyleBackColor = True
        '
        'Form_AutoCapture
        '
        Me.AcceptButton = Me.Button_Start
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button_Start)
        Me.Controls.Add(Me.NumericUpDown_Count)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericUpDown_Interval)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDown_Start)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_AutoCapture"
        CType(Me.NumericUpDown_Start, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Interval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Count, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown_Start As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown_Interval As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown_Count As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button_Start As System.Windows.Forms.Button
End Class
