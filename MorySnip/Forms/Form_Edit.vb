Public Class Form_Edit
    Private Sub Form_Edit_BackgroundImageChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.BackgroundImageChanged
        Me.Editor_Main.BackgroundImage = Me.BackgroundImage
    End Sub

    Private Sub Form_Edit_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            Me.Editor_Main.Cursor = New Cursor(New IO.MemoryStream(My.Resources.PENCIL))
        Catch ex As Exception : End Try

        If Me.Images.Count = 1 Then
            Me.BackgroundImage = Me.Images(0)
        End If
    End Sub

    Public Property Image() As Screenshot
        Get
            Return Me.Editor_Main.BackgroundImage
        End Get
        Set
            Me.Editor_Main.BackgroundImage = Value.Clone
        End Set
    End Property

    Private Sub RedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click, RedToolStripMenuItem.Click
        Me.Editor_Main.CurrentPen.Color = Color.Red
        CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color = Color.Red
        Me.Button_Color.Text = "Red"

        Me.ToolStrip_Standard_Palitra.Color1 = Me.Editor_Main.CurrentPen.Color
        Me.ToolStrip_Standard_Palitra.Color2 = CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color
    End Sub

    Private Sub BlueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BlueToolStripMenuItem.Click, ToolStripMenuItem2.Click
        Me.Editor_Main.CurrentPen.Color = Color.Blue
        CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color = Color.Blue
        Me.Button_Color.Text = "Blue"

        Me.ToolStrip_Standard_Palitra.Color1 = Me.Editor_Main.CurrentPen.Color
        Me.ToolStrip_Standard_Palitra.Color2 = CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color
    End Sub

    Private Sub BlackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BlackToolStripMenuItem.Click, ToolStripMenuItem3.Click
        Me.Editor_Main.CurrentPen.Color = Color.Black
        CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color = Color.Black
        Me.Button_Color.Text = "Black"

        Me.ToolStrip_Standard_Palitra.Color1 = Me.Editor_Main.CurrentPen.Color
        Me.ToolStrip_Standard_Palitra.Color2 = CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color
    End Sub

    Private Sub WhiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles WhiteToolStripMenuItem.Click, ToolStripMenuItem4.Click
        Me.Editor_Main.CurrentPen.Color = Color.White
        CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color = Color.White
        Me.Button_Color.Text = "White"

        Me.ToolStrip_Standard_Palitra.Color1 = Me.Editor_Main.CurrentPen.Color
        Me.ToolStrip_Standard_Palitra.Color2 = CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color
    End Sub

    Private Sub CustomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CustomToolStripMenuItem.Click, ToolStripMenuItem5.Click
        Dim tmp As New ColorDialog With {
            .Color = Me.Editor_Main.CurrentPen.Color
        }

        If tmp.ShowDialog = DialogResult.OK Then
            Me.Editor_Main.CurrentPen.Color = tmp.Color
            CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color = tmp.Color

            If Me.Editor_Main.CurrentPen.Color.IsKnownColor Then
                Me.Button_Color.Text = Me.Editor_Main.CurrentPen.Color.Name
            Else
                Me.Button_Color.Text = Me.Editor_Main.CurrentPen.Color.R & ", " & Me.Editor_Main.CurrentPen.Color.G & ", " & Me.Editor_Main.CurrentPen.Color.B
            End If

            Me.ToolStrip_Standard_Palitra.Color1 = Me.Editor_Main.CurrentPen.Color
            Me.ToolStrip_Standard_Palitra.Color2 = CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color
        End If
    End Sub

    Private Sub Menu_Size_ItemClicked(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles Menu_Size.ItemClicked
        Me.Editor_Main.CurrentPen.Width = Val(e.ClickedItem.Text)
        Me.Button_Size.Text = Me.Editor_Main.CurrentPen.Width & "px"
        Me.Button_Size.Tag = Me.Editor_Main.CurrentPen.Width
    End Sub

    Private Sub Button_Back_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_Back.Click
        Me.Editor_Main.Undo()
    End Sub

    Private Sub Button_Redo_Click(sender As Object, e As EventArgs) Handles Button_Redo.Click
        Me.Editor_Main.Redo()
    End Sub

    Private Sub Button_Rotate_Left_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_Rotate_Left.Click
        Me.Editor_Main.RotateFlip(RotateFlipType.Rotate270FlipNone)
    End Sub

    Private Sub Button_Rotate_Right_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_Rotate_Right.Click
        Me.Editor_Main.RotateFlip(RotateFlipType.Rotate90FlipNone)
    End Sub

    Private Sub Button_Flip_X_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_Flip_X.Click
        Me.Editor_Main.RotateFlip(RotateFlipType.RotateNoneFlipX)
    End Sub

    Private Sub Button_Flip_Y_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_Flip_Y.Click
        Me.Editor_Main.RotateFlip(RotateFlipType.RotateNoneFlipY)
    End Sub

    Private Sub Button_OK_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        Me.Editor_Main.Render()
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Button_Exit_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button_Effect_Blur_Click(sender As Object, e As EventArgs) Handles Menu_PaintMode_Blur.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Blur
    End Sub

    Private Sub Menu_PaintMode_Puzzle_Click(sender As Object, e As EventArgs) Handles Menu_PaintMode_Puzzle.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Puzzle
    End Sub

    Private Sub Button_Effect_Invert_Click(sender As Object, e As EventArgs) Handles Menu_PaintMode_Invert.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Invert
    End Sub

    Private Sub Button_Effect_Grayscale_Click(sender As Object, e As EventArgs) Handles Menu_PaintMode_Grayscale.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Grayscale
    End Sub

    Private Sub Timer_Update_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timer_Update.Tick
        'Tools
        If Not Me.Menu_PaintMode_Free.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Free) Then
            Me.Menu_PaintMode_Free.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Free)
        End If
        If Not Me.Menu_PaintMode_Line.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Line) Then
            Me.Menu_PaintMode_Line.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Line)
        End If
        If Not Me.Menu_PaintMode_Arrow.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Arrow) Then
            Me.Menu_PaintMode_Arrow.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Arrow)
        End If
        If Not Me.Menu_PaintMode_Oval.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Oval) Then
            Me.Menu_PaintMode_Oval.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Oval)
        End If
        If Not Me.Menu_PaintMode_Rect.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Rect) Then
            Me.Menu_PaintMode_Rect.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Rect)
        End If
        If Not Me.Menu_PaintMode_Numbers.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Number) Then
            Me.Menu_PaintMode_Numbers.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Number)
        End If

        'Actions
        If Not Me.Menu_PaintMode_Highlight.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Highlight) Then
            Me.Menu_PaintMode_Highlight.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Highlight)
        End If
        If Not Me.Menu_PaintMode_Invert.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Invert) Then
            Me.Menu_PaintMode_Invert.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Invert)
        End If
        If Not Me.Menu_PaintMode_Grayscale.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Grayscale) Then
            Me.Menu_PaintMode_Grayscale.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Grayscale)
        End If
        If Not Me.Menu_PaintMode_Blur.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Blur) Then
            Me.Menu_PaintMode_Blur.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Blur)
        End If
        If Not Me.Menu_PaintMode_Puzzle.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Puzzle) Then
            Me.Menu_PaintMode_Puzzle.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Puzzle)
        End If
        If Not Me.Menu_PaintMode_Crop.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Crop) Then
            Me.Menu_PaintMode_Crop.Checked = (Me.Editor_Main.PaintMode = Editor.PaintModes.Crop)
        End If
        If Not Me.Button_Size.Tag = Me.Editor_Main.CurrentPen.Width Then
            Me.Button_Size.Text = Me.Editor_Main.CurrentPen.Width & "px"
            Me.Button_Size.Tag = Me.Editor_Main.CurrentPen.Width
        End If

        'Special actions
        If Not Me.Button_Back.Enabled = Me.Editor_Main.CanUndo Then
            Me.Button_Back.Enabled = Me.Editor_Main.CanUndo
        End If
        If Not Me.Button_Redo.Enabled = Me.Editor_Main.CanRedo Then
            Me.Button_Redo.Enabled = Me.Editor_Main.CanRedo
        End If

        Dim w As Integer = Me.Width
        Dim h As Integer = Me.Height
        Dim l As Integer = w + 4 - Me.Panel_Image.HorizontalScroll.Value
        Dim t As Integer = h + 4 - Me.Panel_Image.VerticalScroll.Value

        If Not Me.Resizer_Both.Left = l Then
            Me.Resizer_Both.Left = l
        End If
        If Not Me.Resizer_Both.Top = t Then
            Me.Resizer_Both.Top = t
        End If
        If Not Me.Resizer_Right.Left = l Then
            Me.Resizer_Right.Left = l
        End If
        If Not Me.Resizer_Right.Height = h Then
            Me.Resizer_Right.Height = h
        End If
        If Not Me.Resizer_Bottom.Top = t Then
            Me.Resizer_Bottom.Top = t
        End If
        If Not Me.Resizer_Bottom.Width = w Then
            Me.Resizer_Bottom.Width = w
        End If
    End Sub

    Private Sub Menu_PaintMode_Free_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Menu_PaintMode_Free.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Free
    End Sub

    Private Sub Menu_PaintMode_Highlight_Click(sender As Object, e As EventArgs) Handles Menu_PaintMode_Highlight.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Highlight
    End Sub

    Private Sub Menu_PaintMode_Line_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Menu_PaintMode_Line.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Line
    End Sub

    Private Sub Menu_PaintMode_Arrow_Click(sender As Object, e As EventArgs) Handles Menu_PaintMode_Arrow.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Arrow
    End Sub

    Private Sub Menu_PaintMode_Oval_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Menu_PaintMode_Oval.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Oval
    End Sub

    Private Sub Menu_PaintMode_Rect_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Menu_PaintMode_Rect.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Rect
    End Sub

    Private Sub Menu_PaintMode_Numbers_Click(sender As Object, e As EventArgs) Handles Menu_PaintMode_Numbers.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Number
    End Sub

    Private Sub Menu_PaintMode_Select_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        Me.Editor_Main.PaintMode = Editor.PaintModes.Invert
    End Sub

    Private Sub Menu_PaintMode_Fill_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Menu_PaintMode_Fill.Click
        Me.Editor_Main.FillObjecs = Me.Menu_PaintMode_Fill.Checked
    End Sub

    Private Sub Menu_PaintMode_Crop_Click(sender As Object, e As EventArgs) Handles Menu_PaintMode_Crop.Click
        Me.Editor_Main.PaintMode = Editor.PaintModes.Crop
    End Sub

    Dim ResizerX As Integer, ResizerY As Integer

    Private Sub Resizers_MouseDown(sender As Object, e As MouseEventArgs) Handles Resizer_Both.MouseDown, Resizer_Right.MouseDown, Resizer_Bottom.MouseDown
        If e.Button = MouseButtons.Left Then
            Me.ResizerX = e.X
            Me.ResizerY = e.Y
        End If
    End Sub

    Private Sub Resizer_Both_MouseMove(sender As Object, e As MouseEventArgs) Handles Resizer_Both.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Resizer_Both.Location += New Size(e.X - Me.ResizerX, e.Y - Me.ResizerY)

            Me.Resizer_Right.Location += New Size(e.X - Me.ResizerX, 0)
            Me.Resizer_Right.Size += New Size(0, e.Y - Me.ResizerY)

            Me.Resizer_Bottom.Location += New Size(0, e.Y - Me.ResizerY)
            Me.Resizer_Bottom.Size += New Size(e.X - Me.ResizerX, 0)

            Me.Editor_Main.Size += New Size(e.X - Me.ResizerX, e.Y - Me.ResizerY)
        End If
    End Sub

    Private Sub Resizer_Right_MouseMove(sender As Object, e As MouseEventArgs) Handles Resizer_Right.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Resizer_Both.Location += New Size(e.X - Me.ResizerX, 0)

            Me.Resizer_Right.Location += New Size(e.X - Me.ResizerX, 0)

            Me.Resizer_Bottom.Size += New Size(e.X - Me.ResizerX, 0)

            Me.Editor_Main.Size += New Size(e.X - Me.ResizerX, 0)
        End If
    End Sub

    Private Sub Resizer_Bottom_MouseMove(sender As Object, e As MouseEventArgs) Handles Resizer_Bottom.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Resizer_Both.Location += New Size(0, e.Y - Me.ResizerY)

            Me.Resizer_Right.Size += New Size(0, e.Y - Me.ResizerY)

            Me.Resizer_Bottom.Location += New Size(0, e.Y - Me.ResizerY)

            Me.Editor_Main.Size += New Size(0, e.Y - Me.ResizerY)
        End If
    End Sub


#Region "Publish"
    Private Sub Render()
        Me.Editor_Main.Render()
        Me.Images(0) = Me.Editor_Main.BackgroundImage
    End Sub

    Private Sub Button_Save_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_Save.Click
        Render()

        If MyBase.Publish_SaveToFile(PublishOptions.SaveToFile Or PublishOptions.CopyPathOrULR) Then
            Me.Close()
        End If
    End Sub

    Private Sub Button_SaveAs_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_SaveAs.Click
        Render()

        If MyBase.Publish_SaveToFile(PublishOptions.SaveToFile Or PublishOptions.SaveAs Or PublishOptions.CopyPathOrULR) Then
            Me.Close()
        End If
    End Sub

    Private Sub Button_SaveCopy_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button_SaveCopy.Click
        Render()

        If MyBase.Publish_ToClipboard(0) Then
            Me.Close()
        End If
    End Sub
#End Region

    Private Sub ToolStrip_Standard_Palitra_ColorChanged(sender As Object, e As EventArgs) Handles ToolStrip_Standard_Palitra.ColorChanged
        Me.Editor_Main.CurrentPen.Color = Me.ToolStrip_Standard_Palitra.Color1
        CType(Me.Editor_Main.CurrentBrush, SolidBrush).Color = Me.ToolStrip_Standard_Palitra.Color2

        If Me.Editor_Main.CurrentPen.Color.IsKnownColor Then
            Me.Button_Color.Text = Me.Editor_Main.CurrentPen.Color.Name
        Else
            Me.Button_Color.Text = Me.Editor_Main.CurrentPen.Color.R & ", " & Me.Editor_Main.CurrentPen.Color.G & ", " & Me.Editor_Main.CurrentPen.Color.B
        End If
    End Sub
End Class
