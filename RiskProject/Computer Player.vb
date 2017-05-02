Public Class Computer_Player
    Inherits Player
    Private CurRoute As New List(Of String)
    Private ListStart As Integer = 0
    Private Type As String
    Overrides Function IsAI() As Boolean
        Return True
    End Function
    Public Sub New(ByVal NewName As String, ByVal NewColor As String, ByVal NewNumber As Integer, ByVal WhatType As String)
        MyBase.New(NewName, NewColor, NewNumber)
        Type = WhatType
    End Sub
    Public Function GetAttTerr() As String
        Return CurRoute(ListStart)
    End Function
    Public Function GetDeffTerr() As String
        Return CurRoute(ListStart + 1)
    End Function
    Public Function GetTroopNum() As Integer
        If (My.Forms.GameForm.NewGame.GetTerr(CurRoute(ListStart)).GetTroopNum() - 1) > 3 Then
            Return 3
        Else
            Return (My.Forms.GameForm.NewGame.GetTerr(CurRoute(ListStart)).GetTroopNum() - 1)
        End If
    End Function
    Public Function WinBattle()
        ListStart = ListStart + 1
        Return (My.Forms.GameForm.NewGame.GetTerr(CurRoute(ListStart)).GetTroopNum - 1)
    End Function
    Public Function LongestPath()
        Dim MyTerr As New List(Of Territory)
        Dim BestTerr As Integer
        Dim BestRoute As New List(Of String)
        Dim CurRoute As List(Of String)
        For Each CurCont As Continent In My.Forms.GameForm.NewGame.Map
            For Each CurTerr As Territory In CurCont.Territories
                If CurTerr.GetPlayerNum() = Number Then
                    MyTerr.Add(CurTerr)
                End If
            Next
        Next
        For i = 0 To (MyTerr.Count - 1)
            CurRoute = LongPathSearch(MyTerr(i), New List(Of String))
            If CurRoute.Count > BestRoute.Count Then
                BestRoute = CurRoute
                BestTerr = i
            End If
        Next
        CurRoute = BestRoute
        Me.CurRoute = CurRoute
        ListStart = 0
        Return MyTerr(BestTerr).getName
    End Function
    Private Function LongPathSearch(ByVal CurrTerr As Territory, ByRef Route As List(Of String))
        Dim UntrackedNeigh As Boolean = False
        Dim PossRoutes As New List(Of List(Of String))
        Route.Add(CurrTerr.getName)
        For i = 0 To (CurrTerr.Neighbours.Count - 1)
            If Not My.Forms.GameForm.NewGame.GetTerr(CurrTerr.Neighbours(i)).GetPlayerNum = Number Then
                For j = 0 To (Route.Count - 1)
                    If CurrTerr.Neighbours(i) = Route(j) Then
                        Exit For
                    End If
                    UntrackedNeigh = True
                Next
            End If
        Next
        If (Not UntrackedNeigh) Then
            Return Route
        End If
        Dim NotOnRoute As Boolean = True
        For i = 0 To (CurrTerr.Neighbours.Count - 1)
            If Not My.Forms.GameForm.NewGame.GetTerr(CurrTerr.Neighbours(i)).GetPlayerNum = Number Then
                For j = 0 To (Route.Count - 1)
                    If CurrTerr.Neighbours(i) = Route(j) Then
                        NotOnRoute = False
                    End If
                Next
                If NotOnRoute = True Then
                    PossRoutes.Add(LongPathSearch(My.Forms.GameForm.NewGame.GetTerr(CurrTerr.Neighbours(i)), Route))
                Else
                    NotOnRoute = True
                End If
            End If
        Next
        While PossRoutes.Count > 1
            If PossRoutes(0).Count < PossRoutes(1).Count Then
                PossRoutes.RemoveAt(0)
            Else
                PossRoutes.RemoveAt(1)
            End If
        End While
        If PossRoutes.Count < 1 Then
            Return Route
        Else
            Return PossRoutes(0)
        End If
        Return PossRoutes(0)
    End Function
End Class
