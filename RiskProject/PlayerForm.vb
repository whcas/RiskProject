Public Class PlayerForm
    Public Done As Boolean = False
    Public Sub CreateAIPlayer(ByVal Number As Integer)
        Me.Show()
        Done = False
        HumOrAILab.Text = "AI" & Number
        AICreateBtn.Visible = True
        HumCreateBtn.Visible = False
        Height = 264
        TypeLabel.Show()
        WhichType.Show()
        Dim CurCol As String = ColorInput.Text
        For i = 0 To ColorInput.Items.Count - 1
            If CurCol = ColorInput.Items(i) Then
                ColorInput.Items.Remove(i)
                Me.Refresh()
                Exit For
            End If
        Next
    End Sub
    Public Sub CreateHumPlayer(ByVal Number As Integer)
        Me.Show()
        Done = False
        HumOrAILab.Text = "Human" & Number
        AICreateBtn.Visible = False
        HumCreateBtn.Visible = True
        Height = 224
        TypeLabel.Hide()
        WhichType.Hide()
        Dim CurCol As String = ColorInput.Text
        For i = 0 To ColorInput.Items.Count - 1
            If CurCol = ColorInput.Items(i) Then
                ColorInput.Items.Remove(i)
                Me.Refresh()
                Exit For
            End If
        Next
    End Sub

    Private Sub AICreateBtn_Click(sender As Object, e As EventArgs) Handles AICreateBtn.Click
        ColorInput.BackColor = Color.White
        NameInput.BackColor = Color.White
        If Not NameInput.Text = "" Then
            If Not ColorInput.Text = "" Then
                My.Forms.GameForm.NewGame.Players.Add(New Computer_Player(NameInput.Text, ColorInput.Text, My.Forms.GameForm.NewGame.Players.Count, WhichType.Text))
                NameInput.Text = ""
                NameInput.BackColor = Color.White
                ColorInput.Text = ""
                ColorInput.BackColor = Color.White
                Me.Hide()
                Done = True
            Else
                ColorInput.BackColor = Color.OrangeRed
            End If
        Else
            NameInput.BackColor = Color.OrangeRed
        End If
    End Sub

    Private Sub HumCreateBtn_Click(sender As Object, e As EventArgs) Handles HumCreateBtn.Click
        ColorInput.BackColor = Color.White
        NameInput.BackColor = Color.White
        If Not NameInput.Text = "" Then
            If Not ColorInput.Text = "" Then
                My.Forms.GameForm.NewGame.Players.Add(New Player(NameInput.Text, ColorInput.Text, My.Forms.GameForm.NewGame.Players.Count))
                NameInput.Text = ""
                NameInput.BackColor = Color.White
                ColorInput.Text = ""
                ColorInput.BackColor = Color.White
                Me.Hide()
                Done = True
            Else
                ColorInput.BackColor = Color.OrangeRed
            End If
        Else
            NameInput.BackColor = Color.OrangeRed
        End If
    End Sub
End Class