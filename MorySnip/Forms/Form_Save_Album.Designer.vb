<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Save_Album
    Inherits Form_Save_Base

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Save_Album))
        Me.Button_Remove = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button_FromFile = New System.Windows.Forms.Button()
        Me.TextBox_Title = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button_Edit = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox_Quality = New System.Windows.Forms.ComboBox()
        Me.Button_Share_EMail = New System.Windows.Forms.Button()
        Me.Button_Share_Facebook = New System.Windows.Forms.Button()
        Me.Button_SendToWeb = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox_CopyPath = New System.Windows.Forms.CheckBox()
        Me.CheckBox_OpenFolder = New System.Windows.Forms.CheckBox()
        Me.ListView_Images = New System.Windows.Forms.ListView()
        Me.ImageList_Thumbs = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip_Buttons = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Button_Remove
        '
        resources.ApplyResources(Me.Button_Remove, "Button_Remove")
        Me.Button_Remove.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823849_trash
        Me.Button_Remove.Name = "Button_Remove"
        Me.Button_Remove.UseVisualStyleBackColor = True
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Button_FromFile
        '
        resources.ApplyResources(Me.Button_FromFile, "Button_FromFile")
        Me.Button_FromFile.Image = Global.Morysoft.MorySnip.My.Resources.Resources.round_plus_32
        Me.Button_FromFile.Name = "Button_FromFile"
        Me.Button_FromFile.UseVisualStyleBackColor = True
        '
        'TextBox_Title
        '
        resources.ApplyResources(Me.TextBox_Title, "TextBox_Title")
        Me.TextBox_Title.Name = "TextBox_Title"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Name = "Label5"
        '
        'Button_Edit
        '
        resources.ApplyResources(Me.Button_Edit, "Button_Edit")
        Me.Button_Edit.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823643_doc_edit
        Me.Button_Edit.Name = "Button_Edit"
        Me.Button_Edit.UseVisualStyleBackColor = True
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'ComboBox_Quality
        '
        Me.ComboBox_Quality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Quality.FormattingEnabled = True
        Me.ComboBox_Quality.Items.AddRange(New Object() {resources.GetString("ComboBox_Quality.Items"), resources.GetString("ComboBox_Quality.Items1"), resources.GetString("ComboBox_Quality.Items2")})
        resources.ApplyResources(Me.ComboBox_Quality, "ComboBox_Quality")
        Me.ComboBox_Quality.Name = "ComboBox_Quality"
        '
        'Button_Share_EMail
        '
        resources.ApplyResources(Me.Button_Share_EMail, "Button_Share_EMail")
        Me.Button_Share_EMail.Image = Global.Morysoft.MorySnip.My.Resources.Resources.mail_48
        Me.Button_Share_EMail.Name = "Button_Share_EMail"
        Me.Button_Share_EMail.Tag = "2"
        Me.Button_Share_EMail.UseVisualStyleBackColor = True
        '
        'Button_Share_Facebook
        '
        resources.ApplyResources(Me.Button_Share_Facebook, "Button_Share_Facebook")
        Me.Button_Share_Facebook.Image = Global.Morysoft.MorySnip.My.Resources.Resources.facebook_48
        Me.Button_Share_Facebook.Name = "Button_Share_Facebook"
        Me.Button_Share_Facebook.Tag = "1"
        Me.Button_Share_Facebook.UseVisualStyleBackColor = True
        '
        'Button_SendToWeb
        '
        resources.ApplyResources(Me.Button_SendToWeb, "Button_SendToWeb")
        Me.Button_SendToWeb.Image = Global.Morysoft.MorySnip.My.Resources.Resources.cucak_am_logo
        Me.Button_SendToWeb.Name = "Button_SendToWeb"
        Me.Button_SendToWeb.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Name = "Label3"
        '
        'CheckBox_CopyPath
        '
        resources.ApplyResources(Me.CheckBox_CopyPath, "CheckBox_CopyPath")
        Me.CheckBox_CopyPath.Checked = True
        Me.CheckBox_CopyPath.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_CopyPath.Name = "CheckBox_CopyPath"
        Me.CheckBox_CopyPath.UseVisualStyleBackColor = True
        '
        'CheckBox_OpenFolder
        '
        resources.ApplyResources(Me.CheckBox_OpenFolder, "CheckBox_OpenFolder")
        Me.CheckBox_OpenFolder.Checked = True
        Me.CheckBox_OpenFolder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_OpenFolder.Name = "CheckBox_OpenFolder"
        Me.CheckBox_OpenFolder.UseVisualStyleBackColor = True
        '
        'ListView_Images
        '
        resources.ApplyResources(Me.ListView_Images, "ListView_Images")
        Me.ListView_Images.FullRowSelect = True
        Me.ListView_Images.GridLines = True
        Me.ListView_Images.LabelEdit = True
        Me.ListView_Images.LargeImageList = Me.ImageList_Thumbs
        Me.ListView_Images.Name = "ListView_Images"
        Me.ListView_Images.TileSize = New System.Drawing.Size(300, 150)
        Me.ListView_Images.UseCompatibleStateImageBehavior = False
        Me.ListView_Images.View = System.Windows.Forms.View.Tile
        '
        'ImageList_Thumbs
        '
        Me.ImageList_Thumbs.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.ImageList_Thumbs, "ImageList_Thumbs")
        Me.ImageList_Thumbs.TransparentColor = System.Drawing.Color.Transparent
        '
        'Form_Save_Album
        '
        Me.AcceptButton = Me.Button_SendToWeb
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListView_Images)
        Me.Controls.Add(Me.CheckBox_CopyPath)
        Me.Controls.Add(Me.CheckBox_OpenFolder)
        Me.Controls.Add(Me.Button_Remove)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button_FromFile)
        Me.Controls.Add(Me.TextBox_Title)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button_Edit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboBox_Quality)
        Me.Controls.Add(Me.Button_Share_EMail)
        Me.Controls.Add(Me.Button_Share_Facebook)
        Me.Controls.Add(Me.Button_SendToWeb)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Form_Save_Album"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_Remove As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button_FromFile As System.Windows.Forms.Button
    Friend WithEvents TextBox_Title As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button_Edit As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Quality As System.Windows.Forms.ComboBox
    Friend WithEvents Button_Share_EMail As System.Windows.Forms.Button
    Friend WithEvents Button_Share_Facebook As System.Windows.Forms.Button
    Friend WithEvents Button_SendToWeb As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_CopyPath As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_OpenFolder As System.Windows.Forms.CheckBox
    Friend WithEvents ListView_Images As System.Windows.Forms.ListView
    Friend WithEvents ImageList_Thumbs As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip_Buttons As System.Windows.Forms.ToolTip
End Class
