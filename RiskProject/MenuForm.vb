Public Class MenuForm
    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click
        Me.Close()
    End Sub

    Private Sub NewBtn_Click(sender As Object, e As EventArgs) Handles NewBtn.Click
        Me.Enabled = False
        My.Forms.NewGame.Show()
    End Sub
End Class
