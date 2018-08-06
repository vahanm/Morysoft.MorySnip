Public Class Form_Preview

    Private Sub Form_Preview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WebBrowser_Comment.DocumentText = "<!DOCTYPE html><html lang=""en"" xmlns=""http://www.w3.org/1999/xhtml""><head><meta charset=""utf-8"" /></head><body contenteditable=""true"" style=""min-height: 200px;margin: 3px;""></body></html>"
    End Sub
End Class