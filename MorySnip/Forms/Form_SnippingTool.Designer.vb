<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_SnippingTool
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_SnippingTool))
        Me.Menu_Snip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Snip_FromClipboard = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Snip_FromFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Snip_FullScreen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Snip_Album = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Snip_History = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Snip_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Snip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Menu_Snip
        '
        resources.ApplyResources(Me.Menu_Snip, "Menu_Snip")
        Me.Menu_Snip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Menu_Snip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Snip_FromClipboard, Me.Menu_Snip_FromFile, Me.Menu_Snip_FullScreen, Me.ToolStripSeparator1, Me.Menu_Snip_Album, Me.Menu_Snip_History, Me.ToolStripSeparator2, Me.Menu_Snip_Exit})
        Me.Menu_Snip.Name = "Menu_Snip"
        '
        'Menu_Snip_FromClipboard
        '
        resources.ApplyResources(Me.Menu_Snip_FromClipboard, "Menu_Snip_FromClipboard")
        Me.Menu_Snip_FromClipboard.Name = "Menu_Snip_FromClipboard"
        '
        'Menu_Snip_FromFile
        '
        resources.ApplyResources(Me.Menu_Snip_FromFile, "Menu_Snip_FromFile")
        Me.Menu_Snip_FromFile.Image = Global.Morysoft.MorySnip.My.Resources.Resources.document
        Me.Menu_Snip_FromFile.Name = "Menu_Snip_FromFile"
        '
        'Menu_Snip_FullScreen
        '
        resources.ApplyResources(Me.Menu_Snip_FullScreen, "Menu_Snip_FullScreen")
        Me.Menu_Snip_FullScreen.Image = Global.Morysoft.MorySnip.My.Resources.Resources.Fullscreen
        Me.Menu_Snip_FullScreen.Name = "Menu_Snip_FullScreen"
        '
        'ToolStripSeparator1
        '
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'Menu_Snip_Album
        '
        resources.ApplyResources(Me.Menu_Snip_Album, "Menu_Snip_Album")
        Me.Menu_Snip_Album.Name = "Menu_Snip_Album"
        '
        'Menu_Snip_History
        '
        resources.ApplyResources(Me.Menu_Snip_History, "Menu_Snip_History")
        Me.Menu_Snip_History.Name = "Menu_Snip_History"
        '
        'ToolStripSeparator2
        '
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        '
        'Menu_Snip_Exit
        '
        resources.ApplyResources(Me.Menu_Snip_Exit, "Menu_Snip_Exit")
        Me.Menu_Snip_Exit.Image = Global.Morysoft.MorySnip.My.Resources.Resources.close
        Me.Menu_Snip_Exit.Name = "Menu_Snip_Exit"
        '
        'Form_SnippingTool
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Cursor = System.Windows.Forms.Cursors.Cross
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_SnippingTool"
        Me.Opacity = 0.7R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Magenta
        Me.Menu_Snip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Menu_Snip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Menu_Snip_FullScreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Menu_Snip_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Snip_FromClipboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Menu_Snip_FromFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Snip_Album As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Snip_History As System.Windows.Forms.ToolStripMenuItem

End Class
