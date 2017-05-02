Public Class Territory
    Private Name As String
    'Used both as reference and holds the name of the teritory
    Private PlayerNum As String
    'used to represent if the territory is owned and if so by whom
    Private TroopNum As Integer = 0
    'used to represent the number of troops on this territory
    Public coordinateX As Integer
    Public coordinateY As Integer
    'used as reference as to where to place the button representing this territory on the screen
    Public Neighbours As New List(Of String)()
    'used to store the territories this territory conects to

    Public Sub New(ByVal NameNew As String, ByVal X As Integer, ByVal Y As Integer)
        coordinateX = X
        coordinateY = Y
        Name = NameNew
    End Sub
    'constructor
    Public Function GetPlayerNum()
        Return PlayerNum
    End Function
    'gets the value stored in the private variable PlayerNum
    Public Sub SetPlayerNum(ByVal NewPlayerNum As Integer)
        PlayerNum = NewPlayerNum
        If TroopNum = 0 Then
            Me.AddTroop(1)
        End If
    End Sub
    'used to set the variable PlayerNum
    Public Sub SetTroopNum(ByVal NewTroop As Integer)
        TroopNum = NewTroop
    End Sub
    Public Sub AddNeigh(ByVal NewNeigh As List(Of String))
        Neighbours = NewNeigh
    End Sub
    Public Sub Addneighbour(ByVal NewNeigh As String)
        Neighbours.Add(NewNeigh)
    End Sub

    Public Function Getneighbours()
        Return Neighbours
    End Function
    'Used to give the territory its list of neighbours
    Public Sub Capture(ByVal Attacker As Integer, ByVal SurTroop As Integer)
        PlayerNum = Attacker
        AddTroop(SurTroop)
        Dim player As Player = My.Forms.GameForm.NewGame.GetPlayer(PlayerNum)
        My.Forms.GameForm.NewGame.SetButtonBorderCol(Name, player.GetPlayerColor())
    End Sub
    'used to change change the owner of the territory when captured
    Public Function LoseTroop()
        TroopNum = TroopNum - 1
        For i = 0 To (My.Forms.GameForm.NewGame.returnButtons.count - 1)
            If My.Forms.GameForm.NewGame.returnButtons(i).text = Name Then
                My.Forms.GameForm.NewGame.Labels(i).Text = TroopNum
            End If
        Next
        Return TroopNum
    End Function
    'used when the territories owner loses a battle involving this territory
    Public Sub AddTroop(ByVal NewTroop As Integer)
        TroopNum = TroopNum + NewTroop
        For i = 0 To (My.Forms.GameForm.NewGame.returnButtons.count - 1)
            If My.Forms.GameForm.NewGame.returnButtons(i).text = Name Then
                My.Forms.GameForm.NewGame.Labels(i).Text = TroopNum
            End If
        Next
    End Sub
    'used either in the reenforsement or redeployment stages
    Public Sub MoveTroops(ByVal MovingTroops As Integer)
        TroopNum = TroopNum - MovingTroops
        For i = 0 To (My.Forms.GameForm.NewGame.returnButtons.count - 1)
            If My.Forms.GameForm.NewGame.returnButtons(i).text = Name Then
                My.Forms.GameForm.NewGame.Labels(i).Text = TroopNum
            End If
        Next
    End Sub
    'used to both determin if the requested troops can be redeployed and to remove them from the territory
    Public Function getx()
        Return coordinateX
    End Function
    Public Function gety()
        Return coordinateY
    End Function
    Public Function getName()
        Return Name
    End Function
    'getters used in the creation of the button relevant to the territory
    Public Function GetOwned()
        If PlayerNum = 0 Or 1 Or 2 Or 3 Or 4 Or 5 Or 6 Then
            Return True
        Else
            Return False
        End If
    End Function
    'returns boolien that represents the ownership status of the territory
    Public Sub SetOwned(ByVal NewOwner As Integer)
        PlayerNum = NewOwner
    End Sub
    'sets owner, used primarily in the dealing stage
    Public Function GetTroopNum()
        Return TroopNum
    End Function


End Class
