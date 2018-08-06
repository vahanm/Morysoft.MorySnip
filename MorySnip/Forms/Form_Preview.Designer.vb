<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Preview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Preview))
        Me.TextBox_Title = New System.Windows.Forms.TextBox()
        Me.PictureBox_Image = New System.Windows.Forms.PictureBox()
        Me.Button_OK = New System.Windows.Forms.Button()
        Me.WebBrowser_Comment = New System.Windows.Forms.WebBrowser()
        Me.Panel_Comment = New System.Windows.Forms.Panel()
        CType(Me.PictureBox_Image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Comment.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox_Title
        '
        resources.ApplyResources(Me.TextBox_Title, "TextBox_Title")
        Me.TextBox_Title.Name = "TextBox_Title"
        '
        'PictureBox_Image
        '
        resources.ApplyResources(Me.PictureBox_Image, "PictureBox_Image")
        Me.PictureBox_Image.BackColor = System.Drawing.SystemColors.Window
        Me.PictureBox_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox_Image.Name = "PictureBox_Image"
        Me.PictureBox_Image.TabStop = False
        '
        'Button_OK
        '
        resources.ApplyResources(Me.Button_OK, "Button_OK")
        Me.Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button_OK.Name = "Button_OK"
        Me.Button_OK.UseVisualStyleBackColor = True
        '
        'WebBrowser_Comment
        '
        Me.WebBrowser_Comment.AllowNavigation = False
        resources.ApplyResources(Me.WebBrowser_Comment, "WebBrowser_Comment")
        Me.WebBrowser_Comment.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser_Comment.Name = "WebBrowser_Comment"
        '
        'Panel_Comment
        '
        resources.ApplyResources(Me.Panel_Comment, "Panel_Comment")
        Me.Panel_Comment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_Comment.Controls.Add(Me.WebBrowser_Comment)
        Me.Panel_Comment.Name = "Panel_Comment"
        '
        'Form_Preview
        '
        Me.AcceptButton = Me.Button_OK
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel_Comment)
        Me.Controls.Add(Me.Button_OK)
        Me.Controls.Add(Me.PictureBox_Image)
        Me.Controls.Add(Me.TextBox_Title)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Preview"
        CType(Me.PictureBox_Image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Comment.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox_Title As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox_Image As System.Windows.Forms.PictureBox
    Friend WithEvents Button_OK As System.Windows.Forms.Button
    Friend WithEvents WebBrowser_Comment As System.Windows.Forms.WebBrowser
    Friend WithEvents Panel_Comment As System.Windows.Forms.Panel
End Class
