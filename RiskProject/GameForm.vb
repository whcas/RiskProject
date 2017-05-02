Public Class GameForm

    Public NewGame As Game
    Public ButtonPressed As Boolean = False
    Public WhichButtonPressed As String
    Public EndPhase As Button

    Private Sub ExitToMainMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToMainMenuToolStripMenuItem.Click
        Me.Hide()
        My.Forms.MenuForm.Show()
        My.Forms.MenuForm.Enabled = True
    End Sub
    Private Sub ExitToWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToWindowsToolStripMenuItem.Click
        Application.Exit()
    End Sub
    Public Sub CreateGame()
        Dim BGImage As String = My.Forms.NewGame.MapFileDialog.FileName
        BGImage = Strings.Left(BGImage, Len(BGImage) - 3)
        BGImage = BGImage + "png"
        Me.BackgroundImage = New System.Drawing.Bitmap(BGImage)
        Me.Size = Me.BackgroundImage.Size
        Dim EndPhasePoint As Point = Me.Size
        EndPhasePoint.X = EndPhasePoint.X - 100
        EndPhasePoint.Y = 40
        EndPhase = createButton(EndPhasePoint, "End Phase", Color.Black)
        NewGame = New Game(My.Forms.NewGame.MapFileDialog.FileName.ToString())
        Dim i As Object
        For i = 1 To Convert.ToInt64(My.Forms.NewGame.HumanPlayersNum.Text)
            Me.Enabled = False
            My.Forms.PlayerForm.CreateHumPlayer(i)
            While My.Forms.PlayerForm.Done = False
                Application.DoEvents()
            End While
            Me.Enabled = True
        Next
        For i = 1 To Convert.ToInt64(My.Forms.NewGame.ComputerPlayersNum.Text)
            Me.Enabled = False
            My.Forms.PlayerForm.CreateAIPlayer(i)
            While My.Forms.PlayerForm.Done = False
                Application.DoEvents()
            End While
            Me.Enabled = True
        Next
        NewGame.DivyTerr(NewGame)
        NewGame.drawmap(NewGame)
        Me.Refresh()
        GameplayLoop()
    End Sub
    Public Sub AddToFeed(ByVal Text As String)
        Dim NewText As String
        If FeedBox.Text = "" Then
            NewText = Text
        Else
            NewText = FeedBox.Text + Environment.NewLine + Environment.NewLine + Text
        End If
        FeedBox.Text = NewText
        FeedBox.SelectionStart = FeedBox.TextLength
        FeedBox.ScrollToCaret()
    End Sub

    Public Function createButton(ByVal point As Point, ByVal name As String, ByVal color As Color)
        Dim myButton As New Button
        myButton.Location = point
        myButton.Height = 40
        myButton.Width = 80
        myButton.Text = name
        myButton.BackColor = Color.Transparent
        myButton.FlatStyle = FlatStyle.Flat
        myButton.FlatAppearance.BorderSize = 2
        myButton.FlatAppearance.BorderColor = color
        myButton.Cursor = Cursors.Hand
        AddHandler(myButton.Click), AddressOf MyButton_click
        Controls.Add(myButton)
        Return myButton
    End Function
    Public Function CreateLabel(ByVal point As Point)
        Dim MyLabel As New Label
        point.Y = (point.Y - 10)
        MyLabel.Location = point
        MyLabel.BackColor = Color.Black
        MyLabel.ForeColor = Color.White
        MyLabel.Width = 20
        Controls.Add(MyLabel)
        Return MyLabel
    End Function
    Private Sub MyButton_click(sender As Object, e As EventArgs)
        WhichButtonPressed = sender.text
        ButtonPressed = True
    End Sub
    Public Sub WaitForButton()
        ButtonPressed = False
        WhichButtonPressed = ""
        Do Until ButtonPressed = True
            Application.DoEvents()
        Loop
    End Sub

    Private Sub EndPhaseBut_Click(sender As Object, e As EventArgs)
        WhichButtonPressed = sender.text
        ButtonPressed = True
    End Sub
    Public Sub GameplayLoop()
        Randomize()
        Dim CurrentPlayer As Integer = (Rnd() * (NewGame.Players.Count - 1))
        Dim WinningPlayer As Integer
        Dim HasWon As Boolean = False
        Dim PhaseOver As Boolean = False
        Do Until HasWon = True
            NewGame.Reinforce(CurrentPlayer)
            Do Until PhaseOver = True
                NewGame.Attack(CurrentPlayer)
                If WhichButtonPressed = "End Phase" Then
                    ButtonPressed = False
                    PhaseOver = True
                End If
            Loop
            PhaseOver = False
            Do Until WhichButtonPressed = "End Phase"
                ButtonPressed = False
                NewGame.Redeploy(CurrentPlayer)
            Loop
            PhaseOver = False
            If NewGame.PlayerWon(CurrentPlayer) = True Then
                WinningPlayer = CurrentPlayer
                HasWon = True
            End If
            If CurrentPlayer < (NewGame.ReturnPlayerNum() - 1) Then
                CurrentPlayer = CurrentPlayer + 1
            Else
                CurrentPlayer = 1
            End If
        Loop
        MsgBox("Congratulations player " & NewGame.Players(WinningPlayer).GetName & " you have WON THE GAME. Thank you all for playing.")

    End Sub

End Class