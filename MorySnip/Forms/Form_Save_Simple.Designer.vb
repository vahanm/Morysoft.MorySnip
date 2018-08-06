<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Save_Simple
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Save_Simple))
        Me.ToolTip_Buttons = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button_SendToWeb = New System.Windows.Forms.Button()
        Me.Button_SaveCopy = New System.Windows.Forms.Button()
        Me.Button_SaveAs = New System.Windows.Forms.Button()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.Button_Edit = New System.Windows.Forms.Button()
        Me.TextBox_Title = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button_SendToWeb
        '
        resources.ApplyResources(Me.Button_SendToWeb, "Button_SendToWeb")
        Me.Button_SendToWeb.Image = Global.Morysoft.MorySnip.My.Resources.Resources.cucak_am_logo
        Me.Button_SendToWeb.Name = "Button_SendToWeb"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_SendToWeb, resources.GetString("Button_SendToWeb.ToolTip"))
        Me.Button_SendToWeb.UseVisualStyleBackColor = True
        '
        'Button_SaveCopy
        '
        resources.ApplyResources(Me.Button_SaveCopy, "Button_SaveCopy")
        Me.Button_SaveCopy.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371824300_clipboard_copy
        Me.Button_SaveCopy.Name = "Button_SaveCopy"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_SaveCopy, resources.GetString("Button_SaveCopy.ToolTip"))
        Me.Button_SaveCopy.UseVisualStyleBackColor = True
        '
        'Button_SaveAs
        '
        resources.ApplyResources(Me.Button_SaveAs, "Button_SaveAs")
        Me.Button_SaveAs.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823810_saveas
        Me.Button_SaveAs.Name = "Button_SaveAs"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_SaveAs, resources.GetString("Button_SaveAs.ToolTip"))
        Me.Button_SaveAs.UseVisualStyleBackColor = True
        '
        'Button_Save
        '
        resources.ApplyResources(Me.Button_Save, "Button_Save")
        Me.Button_Save.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823810_save
        Me.Button_Save.Name = "Button_Save"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Save, resources.GetString("Button_Save.ToolTip"))
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'Button_Edit
        '
        resources.ApplyResources(Me.Button_Edit, "Button_Edit")
        Me.Button_Edit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Edit.Image = Global.Morysoft.MorySnip.My.Resources.Resources._1371823643_doc_edit
        Me.Button_Edit.Name = "Button_Edit"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Edit, resources.GetString("Button_Edit.ToolTip"))
        Me.Button_Edit.UseVisualStyleBackColor = True
        '
        'TextBox_Title
        '
        resources.ApplyResources(Me.TextBox_Title, "TextBox_Title")
        Me.TextBox_Title.Name = "TextBox_Title"
        Me.ToolTip_Buttons.SetToolTip(Me.TextBox_Title, resources.GetString("TextBox_Title.ToolTip"))
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Name = "Label3"
        Me.ToolTip_Buttons.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        '
        'Button_Cancel
        '
        resources.ApplyResources(Me.Button_Cancel, "Button_Cancel")
        Me.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.ToolTip_Buttons.SetToolTip(Me.Button_Cancel, resources.GetString("Button_Cancel.ToolTip"))
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Form_Save_Simple
        '
        Me.AcceptButton = Me.Button_SendToWeb
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button_Cancel
        Me.ControlBox = False
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.TextBox_Title)
        Me.Controls.Add(Me.Button_SaveCopy)
        Me.Controls.Add(Me.Button_SaveAs)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.Button_Edit)
        Me.Controls.Add(Me.Button_SendToWeb)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form_Save_Simple"
        Me.ToolTip_Buttons.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_SaveAs As System.Windows.Forms.Button
    Friend WithEvents Button_Save As System.Windows.Forms.Button
    Friend WithEvents Button_SaveCopy As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button_Edit As System.Windows.Forms.Button
    Friend WithEvents Button_SendToWeb As System.Windows.Forms.Button
    Friend WithEvents TextBox_Title As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip_Buttons As System.Windows.Forms.ToolTip
    Friend WithEvents Button_Cancel As System.Windows.Forms.Button
End Class
