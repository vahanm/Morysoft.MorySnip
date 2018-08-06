<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_History
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_History))
        Me.ListView_History = New System.Windows.Forms.ListView()
        Me.ColumnHeader_Date = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader_Title = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList_64 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList_Icons = New System.Windows.Forms.ImageList(Me.components)
        Me.Button_Remove = New System.Windows.Forms.Button()
        Me.Button_Copy = New System.Windows.Forms.Button()
        Me.Button_ViewInBrowser = New System.Windows.Forms.Button()
        Me.ToolTip_Buttons = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'ListView_History
        '
        resources.ApplyResources(Me.ListView_History, "ListView_History")
        Me.ListView_History.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader_Date, Me.ColumnHeader_Title})
        Me.ListView_History.FullRowSelect = True
        Me.ListView_History.GridLines = True
        Me.ListView_History.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView_History.LargeImageList = Me.ImageList_64
        Me.ListView_History.Name = "ListView_History"
        Me.ListView_History.SmallImageList = Me.ImageList_Icons
        Me.ListView_History.UseCompatibleStateImageBehavior = False
        Me.ListView_History.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader_Date
        '
        resources.ApplyResources(Me.ColumnHeader_Date, "ColumnHeader_Date")
        '
        'ColumnHeader_Title
        '
        resources.ApplyResources(Me.ColumnHeader_Title, "ColumnHeader_Title")
        '
        'ImageList_64
        '
        Me.ImageList_64.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.ImageList_64, "ImageList_64")
        Me.ImageList_64.TransparentColor = System.Drawing.Color.Transparent
        '
        'ImageList_Icons
        '
        Me.ImageList_Icons.ImageStream = CType(resources.GetObject("ImageList_Icons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Icons.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Icons.Images.SetKeyName(0, "1356104164_Circle_Green.png")
        '
        'Button_Remove
        '
        resources.ApplyResources(Me.Button_Remove, "Button_Remove")
        Me.Button_Remove.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823849_trash
        Me.Button_Remove.Name = "Button_Remove"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Remove, resources.GetString("Button_Remove.ToolTip"))
        Me.Button_Remove.UseVisualStyleBackColor = True
        '
        'Button_Copy
        '
        resources.ApplyResources(Me.Button_Copy, "Button_Copy")
        Me.Button_Copy.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371824300_clipboard_copy
        Me.Button_Copy.Name = "Button_Copy"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Copy, resources.GetString("Button_Copy.ToolTip"))
        Me.Button_Copy.UseVisualStyleBackColor = True
        '
        'Button_ViewInBrowser
        '
        resources.ApplyResources(Me.Button_ViewInBrowser, "Button_ViewInBrowser")
        Me.Button_ViewInBrowser.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371996336_browser
        Me.Button_ViewInBrowser.Name = "Button_ViewInBrowser"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_ViewInBrowser, resources.GetString("Button_ViewInBrowser.ToolTip"))
        Me.Button_ViewInBrowser.UseVisualStyleBackColor = True
        '
        'Form_History
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button_Remove)
        Me.Controls.Add(Me.Button_Copy)
        Me.Controls.Add(Me.Button_ViewInBrowser)
        Me.Controls.Add(Me.ListView_History)
        Me.Name = "Form_History"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView_History As System.Windows.Forms.ListView
    Friend WithEvents Button_Remove As System.Windows.Forms.Button
    Friend WithEvents Button_Copy As System.Windows.Forms.Button
    Friend WithEvents Button_ViewInBrowser As System.Windows.Forms.Button
    Friend WithEvents ToolTip_Buttons As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList_64 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList_Icons As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader_Date As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader_Title As System.Windows.Forms.ColumnHeader
End Class
