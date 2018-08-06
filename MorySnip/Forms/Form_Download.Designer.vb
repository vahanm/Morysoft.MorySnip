<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Download
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
        Me.components = New System.ComponentModel.Container()
        Me.ProgressBar_Files = New System.Windows.Forms.ProgressBar()
        Me.Timer_Begin = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ProgressBar_Files
        '
        Me.ProgressBar_Files.Location = New System.Drawing.Point(12, 12)
        Me.ProgressBar_Files.Name = "ProgressBar_Files"
        Me.ProgressBar_Files.Size = New System.Drawing.Size(308, 23)
        Me.ProgressBar_Files.TabIndex = 0
        '
        'Timer_Begin
        '
        Me.Timer_Begin.Enabled = True
        '
        'Form_Download
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 47)
        Me.Controls.Add(Me.ProgressBar_Files)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form_Download"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Download"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgressBar_Files As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer_Begin As System.Windows.Forms.Timer
End Class
