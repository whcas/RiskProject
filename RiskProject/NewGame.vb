Public Class NewGame
    Private Sub CnclBtn_Click(sender As Object, e As EventArgs) Handles CnclBtn.Click, MyBase.Closed
        PickMapBtn.Text = "..."
        Me.Hide()
        My.Forms.MenuForm.Enabled = True
        My.Forms.MenuForm.Activate()
    End Sub

    Private Sub CreateBtn_Click(sender As Object, e As EventArgs) Handles CreateBtn.Click
        If PickMapBtn.Text = "..." Then
            MapFileDialog.FileName = My.Application.Info.DirectoryPath
            MapFileDialog.FileName = MapFileDialog.FileName.Substring(0, MapFileDialog.FileName.Length - 21)
            MapFileDialog.FileName = MapFileDialog.FileName + "Maps\Earth\RiskWorld.Xml"
        End If
        If (HumanPlayersNum.Text + ComputerPlayersNum.Text) < 3 Then
            MsgBox("Please enter a valid number of players")
        Else
            Me.Hide()
            My.Forms.MenuForm.Hide()
            My.Forms.GameForm.Show()
            My.Forms.GameForm.Activate()
            My.Forms.GameForm.CreateGame()
        End If
    End Sub

    Private Sub PickMapBtn_Click(sender As Object, e As EventArgs) Handles PickMapBtn.Click
        MapFileDialog.InitialDirectory = My.Application.Info.DirectoryPath
        MapFileDialog.InitialDirectory = MapFileDialog.InitialDirectory.Substring(0, MapFileDialog.InitialDirectory.Length - 21)
        MapFileDialog.InitialDirectory = MapFileDialog.InitialDirectory + "Maps"
        MapFileDialog.ShowDialog()
        PickMapBtn.Text = MapFileDialog.FileName
    End Sub
End Class