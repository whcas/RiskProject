Public Class Player
    Public Name As String
    Protected Number As Integer
    Public TerritoryNum As Integer = 0
    Protected PlayerColor As Color

    Public Sub New(ByVal NewName As String, ByVal NewColor As String, ByVal NewNumber As Integer)
        Name = NewName
        PlayerColor = Color.FromName(NewColor)
        Number = NewNumber
    End Sub
    Public Function GetName()
        Return Name
    End Function
    Public Function GetNumber()
        Return Number
    End Function
    Public Function GetColor()
        Return PlayerColor
    End Function
    Public Function GetTerrNum()
        Return TerritoryNum
    End Function
    Public Sub GainTerritiory()
        TerritoryNum = TerritoryNum + 1
    End Sub
    Public Sub SetTerritoryNum(ByVal NewTerrNum As Integer)
        TerritoryNum = NewTerrNum
    End Sub
    Public Sub SetNewPlayercolor(ByVal NewColor As String)
        PlayerColor = Color.FromName(NewColor)
    End Sub
    Public Function GetPlayerColor()
        Return PlayerColor
    End Function
    Public Overridable Function IsAI() As Boolean
        Return False
    End Function
    Public Sub LoseTerritory()
        TerritoryNum = TerritoryNum - 1
    End Sub


End Class
