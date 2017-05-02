Public Class Continent
    Private Name As String
    'Used both as reference and holds the name of the continent
    Private player As Integer = 99
    'Used to represent both weather one player controls the whole continent and if so which player
    Private Value As Integer
    'used to represent the continents value for reinforcement
    Public Territories As New List(Of Territory)()
    'the list of territories contained in this continent
    Public Sub New(ByVal NewName As String, ByVal Val As Integer)
        Name = NewName
        Value = Val
    End Sub
    'constructor
    Public Function GetValue()
        Return Value
    End Function
    Public Function GetName()
        Return Name
    End Function
    Public Function GetPlayer()
        Return player
    End Function
    Public Sub SetPlayer(ByVal NewPlayer As Integer)
        player = NewPlayer
    End Sub
    Public Sub AddTerr(ByVal NewTerr As List(Of Territory))
        Territories = NewTerr
    End Sub
    'used to set the list of territories in the continent
    Public Function ReturnTerr()
        Return Territories
    End Function
    'returns the list of territories by value
End Class

