<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Settings
    Inherits Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Settings))
        Me.ComboBox_Type = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox_CopyPath = New System.Windows.Forms.CheckBox()
        Me.CheckBox_OpenFolder = New System.Windows.Forms.CheckBox()
        Me.Button_BrowseLocal = New System.Windows.Forms.Button()
        Me.ImageList_Thumbs = New System.Windows.Forms.ImageList(Me.components)
        Me.Menu_Clipboard = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Clipboard_Message = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Clipboard_Separator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Clipboard_Monitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBox_Quality = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolTip_Buttons = New System.Windows.Forms.ToolTip(Me.components)
        Me.Menu_Screens = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Screens_Screen1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Screens_Screen2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Screens_Screen3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Screens_Screen4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Screens_AllScreens = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_MonitorClipboard = New System.Windows.Forms.Timer(Me.components)
        Me.Menu_Clipboard.SuspendLayout()
        Me.Menu_Screens.SuspendLayout()
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
        'ImageList_Thumbs
        '
        Me.ImageList_Thumbs.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.ImageList_Thumbs, "ImageList_Thumbs")
        Me.ImageList_Thumbs.TransparentColor = System.Drawing.Color.Transparent
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
        'Form_Settings
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboBox_Quality)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox_Type)
        Me.Controls.Add(Me.CheckBox_CopyPath)
        Me.Controls.Add(Me.CheckBox_OpenFolder)
        Me.Controls.Add(Me.Button_BrowseLocal)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Form_Settings"
        Me.Menu_Clipboard.ResumeLayout(False)
        Me.Menu_Screens.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button_BrowseLocal As System.Windows.Forms.Button
    Friend WithEvents CheckBox_OpenFolder As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_CopyPath As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox_Quality As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolTip_Buttons As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList_Thumbs As System.Windows.Forms.ImageList
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
