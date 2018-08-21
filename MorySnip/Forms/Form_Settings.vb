Imports System.Threading
Imports System.Globalization
Imports System.Net
Imports Microsoft.VisualBasic.Devices
Imports System.Collections.Specialized

Public Class Form_Settings
    Private Sub Form_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.Button_BrowseLocal.Text = Settings.DefaultPath
        Me.ComboBox_Type.SelectedIndex = Settings.FileType
        Me.ComboBox_Quality.SelectedIndex = Settings.ShareQuality

        Me.CheckBox_CopyPath.Checked = Settings.CopyPath
        Me.CheckBox_OpenFolder.Checked = Settings.OpenFolder

        'TODO: Remove to enable AutoUpdate
        'AutoUpdaterDotNET.AutoUpdater.Start("http://share.cucak.am/downloads/snipping-tool/version.xml.php")
    End Sub

    Private Sub Button_Browse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button_BrowseLocal.Click
        With New FolderBrowserDialog
            If .ShowDialog = DialogResult.OK Then
                Me.Button_BrowseLocal.Text = .SelectedPath
            End If
        End With
    End Sub

    Private Sub ComboBox_Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox_Type.SelectedIndexChanged, ComboBox_Quality.SelectedIndexChanged
        Settings.FileType = Me.ComboBox_Type.SelectedIndex
    End Sub

    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Settings.DefaultPath = Me.Button_BrowseLocal.Text
        Settings.FileType = Me.ComboBox_Type.SelectedIndex
        Settings.ShareQuality = Me.ComboBox_Quality.SelectedIndex

        Settings.CopyPath = Me.CheckBox_CopyPath.Checked
        Settings.OpenFolder = Me.CheckBox_OpenFolder.Checked
    End Sub
End Class
