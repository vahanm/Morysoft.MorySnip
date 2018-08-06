<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Save_Advanced
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Save_Advanced))
        Me.ComboBox_Type = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox_CopyPath = New System.Windows.Forms.CheckBox()
        Me.CheckBox_OpenFolder = New System.Windows.Forms.CheckBox()
        Me.Button_BrowseLocal = New System.Windows.Forms.Button()
        Me.Button_Edit = New System.Windows.Forms.Button()
        Me.Button_SaveCopy = New System.Windows.Forms.Button()
        Me.Button_SendToWeb = New System.Windows.Forms.Button()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.Button_SaveAs = New System.Windows.Forms.Button()
        Me.TabControl_Preview = New System.Windows.Forms.TabControl()
        Me.ImageList_Thumbs = New System.Windows.Forms.ImageList(Me.components)
        Me.Button_FromClipboard = New System.Windows.Forms.Button()
        Me.Button_CutFromScreen = New System.Windows.Forms.Button()
        Me.Button_FromFile = New System.Windows.Forms.Button()
        Me.Button_FullScreen = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Title = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox_Quality = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button_Remove = New System.Windows.Forms.Button()
        Me.ToolTip_Buttons = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button_Share_Facebook = New System.Windows.Forms.Button()
        Me.Button_Share_Odnoklassniki = New System.Windows.Forms.Button()
        Me.Button_Share_EMail = New System.Windows.Forms.Button()
        Me.Menu_Screens = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Screens_Screen1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Screens_Screen2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Screens_Screen3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Screens_Screen4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Screens_AllScreens = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Clipboard = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Clipboard_Message = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Clipboard_Separator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Clipboard_Monitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_MonitorClipboard = New System.Windows.Forms.Timer(Me.components)
        Me.Menu_Screens.SuspendLayout()
        Me.Menu_Clipboard.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox_Type
        '
        resources.ApplyResources(Me.ComboBox_Type, "ComboBox_Type")
        Me.ComboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Type.FormattingEnabled = True
        Me.ComboBox_Type.Items.AddRange(New Object() {resources.GetString("ComboBox_Type.Items"), resources.GetString("ComboBox_Type.Items1"), resources.GetString("ComboBox_Type.Items2"), resources.GetString("ComboBox_Type.Items3"), resources.GetString("ComboBox_Type.Items4"), resources.GetString("ComboBox_Type.Items5"), resources.GetString("ComboBox_Type.Items6"), resources.GetString("ComboBox_Type.Items7"), resources.GetString("ComboBox_Type.Items8")})
        Me.ComboBox_Type.Name = "ComboBox_Type"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
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
        'Button_BrowseLocal
        '
        resources.ApplyResources(Me.Button_BrowseLocal, "Button_BrowseLocal")
        Me.Button_BrowseLocal.Name = "Button_BrowseLocal"
        Me.Button_BrowseLocal.UseVisualStyleBackColor = True
        '
        'Button_Edit
        '
        resources.ApplyResources(Me.Button_Edit, "Button_Edit")
        Me.Button_Edit.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823643_doc_edit
        Me.Button_Edit.Name = "Button_Edit"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Edit, resources.GetString("Button_Edit.ToolTip"))
        Me.Button_Edit.UseVisualStyleBackColor = True
        '
        'Button_SaveCopy
        '
        resources.ApplyResources(Me.Button_SaveCopy, "Button_SaveCopy")
        Me.Button_SaveCopy.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371824300_clipboard_copy
        Me.Button_SaveCopy.Name = "Button_SaveCopy"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_SaveCopy, resources.GetString("Button_SaveCopy.ToolTip"))
        Me.Button_SaveCopy.UseVisualStyleBackColor = True
        '
        'Button_SendToWeb
        '
        resources.ApplyResources(Me.Button_SendToWeb, "Button_SendToWeb")
        Me.Button_SendToWeb.Image = Global.Morysoft.MorySnip.My.Resources.Resources.cucak_am_logo
        Me.Button_SendToWeb.Name = "Button_SendToWeb"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_SendToWeb, resources.GetString("Button_SendToWeb.ToolTip"))
        Me.Button_SendToWeb.UseVisualStyleBackColor = True
        '
        'Button_Save
        '
        resources.ApplyResources(Me.Button_Save, "Button_Save")
        Me.Button_Save.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823810_save
        Me.Button_Save.Name = "Button_Save"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Save, resources.GetString("Button_Save.ToolTip"))
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'Button_SaveAs
        '
        resources.ApplyResources(Me.Button_SaveAs, "Button_SaveAs")
        Me.Button_SaveAs.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823810_saveas
        Me.Button_SaveAs.Name = "Button_SaveAs"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_SaveAs, resources.GetString("Button_SaveAs.ToolTip"))
        Me.Button_SaveAs.UseVisualStyleBackColor = True
        '
        'TabControl_Preview
        '
        resources.ApplyResources(Me.TabControl_Preview, "TabControl_Preview")
        Me.TabControl_Preview.ImageList = Me.ImageList_Thumbs
        Me.TabControl_Preview.Name = "TabControl_Preview"
        Me.TabControl_Preview.SelectedIndex = 0
        Me.TabControl_Preview.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl_Preview.TabStop = False
        '
        'ImageList_Thumbs
        '
        Me.ImageList_Thumbs.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.ImageList_Thumbs, "ImageList_Thumbs")
        Me.ImageList_Thumbs.TransparentColor = System.Drawing.Color.Transparent
        '
        'Button_FromClipboard
        '
        Me.Button_FromClipboard.ContextMenuStrip = Me.Menu_Clipboard
        Me.Button_FromClipboard.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823721_clipboard_past
        resources.ApplyResources(Me.Button_FromClipboard, "Button_FromClipboard")
        Me.Button_FromClipboard.Name = "Button_FromClipboard"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_FromClipboard, resources.GetString("Button_FromClipboard.ToolTip"))
        Me.Button_FromClipboard.UseVisualStyleBackColor = True
        '
        'Button_CutFromScreen
        '
        Me.Button_CutFromScreen.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823693_clipboard_cut
        resources.ApplyResources(Me.Button_CutFromScreen, "Button_CutFromScreen")
        Me.Button_CutFromScreen.Name = "Button_CutFromScreen"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_CutFromScreen, resources.GetString("Button_CutFromScreen.ToolTip"))
        Me.Button_CutFromScreen.UseVisualStyleBackColor = True
        '
        'Button_FromFile
        '
        Me.Button_FromFile.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823655_folder_open
        resources.ApplyResources(Me.Button_FromFile, "Button_FromFile")
        Me.Button_FromFile.Name = "Button_FromFile"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_FromFile, resources.GetString("Button_FromFile.ToolTip"))
        Me.Button_FromFile.UseVisualStyleBackColor = True
        '
        'Button_FullScreen
        '
        Me.Button_FullScreen.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823758_monitor
        resources.ApplyResources(Me.Button_FullScreen, "Button_FullScreen")
        Me.Button_FullScreen.Name = "Button_FullScreen"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_FullScreen, resources.GetString("Button_FullScreen.ToolTip"))
        Me.Button_FullScreen.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Name = "Label5"
        '
        'TextBox_Title
        '
        resources.ApplyResources(Me.TextBox_Title, "TextBox_Title")
        Me.TextBox_Title.Name = "TextBox_Title"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'ComboBox_Quality
        '
        resources.ApplyResources(Me.ComboBox_Quality, "ComboBox_Quality")
        Me.ComboBox_Quality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Quality.FormattingEnabled = True
        Me.ComboBox_Quality.Items.AddRange(New Object() {resources.GetString("ComboBox_Quality.Items"), resources.GetString("ComboBox_Quality.Items1"), resources.GetString("ComboBox_Quality.Items2")})
        Me.ComboBox_Quality.Name = "ComboBox_Quality"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Button_Remove
        '
        resources.ApplyResources(Me.Button_Remove, "Button_Remove")
        Me.Button_Remove.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823849_trash
        Me.Button_Remove.Name = "Button_Remove"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Remove, resources.GetString("Button_Remove.ToolTip"))
        Me.Button_Remove.UseVisualStyleBackColor = True
        '
        'Button_Share_Facebook
        '
        resources.ApplyResources(Me.Button_Share_Facebook, "Button_Share_Facebook")
        Me.Button_Share_Facebook.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371825477_facebook
        Me.Button_Share_Facebook.Name = "Button_Share_Facebook"
        Me.Button_Share_Facebook.Tag = "1"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Share_Facebook, resources.GetString("Button_Share_Facebook.ToolTip"))
        Me.Button_Share_Facebook.UseVisualStyleBackColor = True
        '
        'Button_Share_Odnoklassniki
        '
        resources.ApplyResources(Me.Button_Share_Odnoklassniki, "Button_Share_Odnoklassniki")
        Me.Button_Share_Odnoklassniki.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371843972_odnoklassniki
        Me.Button_Share_Odnoklassniki.Name = "Button_Share_Odnoklassniki"
        Me.Button_Share_Odnoklassniki.Tag = "2"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Share_Odnoklassniki, resources.GetString("Button_Share_Odnoklassniki.ToolTip"))
        Me.Button_Share_Odnoklassniki.UseVisualStyleBackColor = True
        '
        'Button_Share_EMail
        '
        resources.ApplyResources(Me.Button_Share_EMail, "Button_Share_EMail")
        Me.Button_Share_EMail.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371844583_email
        Me.Button_Share_EMail.Name = "Button_Share_EMail"
        Me.Button_Share_EMail.Tag = "2"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Share_EMail, resources.GetString("Button_Share_EMail.ToolTip"))
        Me.Button_Share_EMail.UseVisualStyleBackColor = True
        '
        'Menu_Screens
        '
        Me.Menu_Screens.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Screens_Screen1, Me.Menu_Screens_Screen2, Me.Menu_Screens_Screen3, Me.Menu_Screens_Screen4, Me.ToolStripSeparator1, Me.Menu_Screens_AllScreens})
        Me.Menu_Screens.Name = "Menu_Screens"
        resources.ApplyResources(Me.Menu_Screens, "Menu_Screens")
        '
        'Menu_Screens_Screen1
        '
        Me.Menu_Screens_Screen1.Name = "Menu_Screens_Screen1"
        resources.ApplyResources(Me.Menu_Screens_Screen1, "Menu_Screens_Screen1")
        Me.Menu_Screens_Screen1.Tag = "0"
        '
        'Menu_Screens_Screen2
        '
        Me.Menu_Screens_Screen2.Name = "Menu_Screens_Screen2"
        resources.ApplyResources(Me.Menu_Screens_Screen2, "Menu_Screens_Screen2")
        Me.Menu_Screens_Screen2.Tag = "1"
        '
        'Menu_Screens_Screen3
        '
        Me.Menu_Screens_Screen3.Name = "Menu_Screens_Screen3"
        resources.ApplyResources(Me.Menu_Screens_Screen3, "Menu_Screens_Screen3")
        Me.Menu_Screens_Screen3.Tag = "2"
        '
        'Menu_Screens_Screen4
        '
        Me.Menu_Screens_Screen4.Name = "Menu_Screens_Screen4"
        resources.ApplyResources(Me.Menu_Screens_Screen4, "Menu_Screens_Screen4")
        Me.Menu_Screens_Screen4.Tag = "3"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'Menu_Screens_AllScreens
        '
        Me.Menu_Screens_AllScreens.Name = "Menu_Screens_AllScreens"
        resources.ApplyResources(Me.Menu_Screens_AllScreens, "Menu_Screens_AllScreens")
        '
        'Menu_Clipboard
        '
        Me.Menu_Clipboard.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Clipboard_Message, Me.Menu_Clipboard_Separator1, Me.Menu_Clipboard_Monitor})
        Me.Menu_Clipboard.Name = "Menu_Clipboard"
        resources.ApplyResources(Me.Menu_Clipboard, "Menu_Clipboard")
        '
        'Menu_Clipboard_Message
        '
        resources.ApplyResources(Me.Menu_Clipboard_Message, "Menu_Clipboard_Message")
        Me.Menu_Clipboard_Message.Name = "Menu_Clipboard_Message"
        '
        'Menu_Clipboard_Separator1
        '
        Me.Menu_Clipboard_Separator1.Name = "Menu_Clipboard_Separator1"
        resources.ApplyResources(Me.Menu_Clipboard_Separator1, "Menu_Clipboard_Separator1")
        '
        'Menu_Clipboard_Monitor
        '
        Me.Menu_Clipboard_Monitor.Name = "Menu_Clipboard_Monitor"
        resources.ApplyResources(Me.Menu_Clipboard_Monitor, "Menu_Clipboard_Monitor")
        '
        'Timer_MonitorClipboard
        '
        '
        'Form_Save_Advanced
        '
        Me.AcceptButton = Me.Button_SendToWeb
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button_FromClipboard)
        Me.Controls.Add(Me.Button_Remove)
        Me.Controls.Add(Me.Button_CutFromScreen)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button_FromFile)
        Me.Controls.Add(Me.TextBox_Title)
        Me.Controls.Add(Me.Button_FullScreen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button_SaveCopy)
        Me.Controls.Add(Me.Button_SaveAs)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.TabControl_Preview)
        Me.Controls.Add(Me.Button_Edit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboBox_Quality)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox_Type)
        Me.Controls.Add(Me.CheckBox_CopyPath)
        Me.Controls.Add(Me.CheckBox_OpenFolder)
        Me.Controls.Add(Me.Button_BrowseLocal)
        Me.Controls.Add(Me.Button_Share_EMail)
        Me.Controls.Add(Me.Button_Share_Odnoklassniki)
        Me.Controls.Add(Me.Button_Share_Facebook)
        Me.Controls.Add(Me.Button_SendToWeb)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Form_Save_Advanced"
        Me.Menu_Screens.ResumeLayout(False)
        Me.Menu_Clipboard.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_SaveAs As System.Windows.Forms.Button
    Friend WithEvents Button_Save As System.Windows.Forms.Button
    Friend WithEvents Button_SaveCopy As System.Windows.Forms.Button
    Friend WithEvents Button_BrowseLocal As System.Windows.Forms.Button
    Friend WithEvents CheckBox_OpenFolder As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button_Edit As System.Windows.Forms.Button
    Friend WithEvents Button_SendToWeb As System.Windows.Forms.Button
    Friend WithEvents CheckBox_CopyPath As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl_Preview As System.Windows.Forms.TabControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button_FromClipboard As System.Windows.Forms.Button
    Friend WithEvents Button_CutFromScreen As System.Windows.Forms.Button
    Friend WithEvents Button_FromFile As System.Windows.Forms.Button
    Friend WithEvents Button_FullScreen As System.Windows.Forms.Button
    Friend WithEvents TextBox_Title As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_Quality As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button_Remove As System.Windows.Forms.Button
    Friend WithEvents ToolTip_Buttons As System.Windows.Forms.ToolTip
    Friend WithEvents Button_Share_Facebook As System.Windows.Forms.Button
    Friend WithEvents ImageList_Thumbs As System.Windows.Forms.ImageList
    Friend WithEvents Button_Share_Odnoklassniki As System.Windows.Forms.Button
    Friend WithEvents Button_Share_EMail As System.Windows.Forms.Button
    Friend WithEvents Menu_Screens As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Menu_Screens_Screen1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Screens_Screen2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Screens_Screen3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Screens_Screen4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Menu_Screens_AllScreens As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Clipboard As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Menu_Clipboard_Message As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Clipboard_Separator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Menu_Clipboard_Monitor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer_MonitorClipboard As System.Windows.Forms.Timer
End Class
