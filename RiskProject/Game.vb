Imports System.Xml
Public Class Game
    Public Players As New List(Of Object) 'stores the info about the players
    Public Map As New List(Of Continent) 'stores map in the form of a list of continents
    Public buttons As New List(Of Button) 'contains a list of buttons that are used for user input of which territory they are refering to
    Public Labels As New List(Of Label) 'list of labels with info on each territory

    Public Sub New(ByVal XmlLink As String) 'constructor takes the file location and runs the load map subroutine with this
        LoadMap(XmlLink)
    End Sub

    'Some Setters and Getters
    Public Function GetPlayer(ByVal PlayerNum As Integer)
        Return Players(PlayerNum)
    End Function
    Public Sub SetTerrOwner(ByVal terr As String, ByVal NewOwner As Integer)
        Dim terrloc As Point = FindTerr(terr)
        Map(terrloc.X).Territories(terrloc.Y).SetOwned(NewOwner)
    End Sub
    Public Sub SetNewPlayer(ByVal NewPlayer As Player)
        Players.Add(NewPlayer)
    End Sub
    Public Function ReturnPlayerNum()
        Return Players.Count
    End Function
    Public Function ReturnMap()
        Return Map
    End Function
    Public Function returnButtons()
        Return buttons
    End Function
    Public Sub SetLabelNum(ByVal NewVal As String, ByVal Whichlabel As Integer)
        Labels(Whichlabel).Text = NewVal
    End Sub
    Public Function GetLabelNum(ByVal WhichLabel As Integer)
        Return Labels(WhichLabel).Text
    End Function
    Public Sub SetButtonBorderCol(ByVal buttonName As String, ByVal ButtonColor As Color)
        For i = 0 To (buttons.Count - 1)
            If buttons(i).Text = buttonName Then
                buttons(i).FlatAppearance.BorderColor = ButtonColor
            End If
        Next
    End Sub

    Public Sub LoadMap(ByVal XmlLink As String) 'Parces the XML and it can parce both a save XML and a map XML
        Dim ContinentsList As New List(Of Continent)()
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode
        Dim c_nodelist As XmlNodeList
        Dim d_nodelist As XmlNodeList
        m_xmld = New XmlDocument()
        'Create the XML Document
        m_xmld.Load(XmlLink)
        'Load the Xml file
        m_nodelist = m_xmld.SelectNodes("/Save/Map/Continent")
        'Get the list of continent nodes 
        For Each m_node In m_nodelist 'Loop through the continent nodes
            Dim ConNameAttribute As String
            Dim ConValueAttribute As String
            Dim ConPlayerAttribute As String
            Dim TempTerrAttribute As Territory
            Dim TempTerrName As String
            Dim TempTerrLoc As New Point
            Dim TempTerrPlayer As String
            Dim TempTerrTroopNum As Integer
            Dim TempTerrneighbours As New List(Of List(Of String))
            Dim ConTerrListAttribute As New List(Of Territory)
            Dim TempConAttribute As Continent
            c_nodelist = m_node.ChildNodes
            For i = 0 To c_nodelist.Count - 1 'Loops through the nodes inside the continent node
                Select Case c_nodelist.Item(i).Name 'Does different things depending on the name of the child node
                    Case "ContinentName"
                        ConNameAttribute = c_nodelist.Item(i).InnerText
                    Case "Value"
                        ConValueAttribute = c_nodelist.Item(i).InnerText
                    Case "Player"
                        ConPlayerAttribute = c_nodelist.Item(i).InnerText
                    Case "Territory" 'For territories it goes through the territories child nodes
                        d_nodelist = c_nodelist.Item(i).ChildNodes
                        TempTerrneighbours.Add(New List(Of String))
                        For j = 0 To d_nodelist.Count - 1
                            Select Case d_nodelist.Item(j).Name 'And again depending on the name of the node it stores the info in a different place
                                Case "TerritoryName"
                                    TempTerrName = d_nodelist.Item(j).InnerText
                                Case "X"
                                    TempTerrLoc.X = d_nodelist.Item(j).InnerText
                                Case "Y"
                                    TempTerrLoc.Y = d_nodelist.Item(j).InnerText
                                Case "PlayerName"
                                    TempTerrPlayer = d_nodelist.Item(j).InnerText
                                Case "TroopNum"
                                    TempTerrTroopNum = d_nodelist.Item(j).InnerText
                                Case "Neighbor"
                                    TempTerrneighbours(TempTerrneighbours.Count - 1).Add(d_nodelist.Item(j).InnerText)
                            End Select
                        Next
                        'Now it will take the infornmation from those nodes to create a territory
                        TempTerrAttribute = New Territory(TempTerrName, TempTerrLoc.X, TempTerrLoc.Y)
                        If TempTerrTroopNum >= 0 Then TempTerrAttribute.SetTroopNum(TempTerrTroopNum)
                        If TempTerrPlayer IsNot Nothing Then TempTerrAttribute.SetPlayerNum(TempTerrPlayer)
                        TempTerrAttribute.AddNeigh(TempTerrneighbours(TempTerrneighbours.Count - 1))
                        ConTerrListAttribute.Add(TempTerrAttribute) 'And it adds the territory to the continents list of territories
                        TempTerrPlayer = Nothing
                        TempTerrTroopNum = Nothing
                End Select
            Next
            TempConAttribute = New Continent(ConNameAttribute, ConValueAttribute) 'Using the information from the continent node it creates a new continent and stores it
            TempConAttribute.AddTerr(ConTerrListAttribute)
            If ConPlayerAttribute IsNot Nothing Then TempConAttribute.SetPlayer(ConPlayerAttribute)
            ConPlayerAttribute = Nothing
            Map.Add(TempConAttribute)
            TempConAttribute = Nothing
        Next
        Try 'If there is a players node this code will run
            m_nodelist = m_xmld.SelectNodes("/Save/Players/Player")
            Dim TempPlayer As Player
            For i = 0 To (m_nodelist.Count - 1) 'Takes nodes and constructs players list
                c_nodelist = m_node.ChildNodes
                TempPlayer = New Player(c_nodelist.Item(0).InnerText, "Black", i)
                TempPlayer.SetTerritoryNum(c_nodelist.Item(1).InnerText)
                TempPlayer.SetNewPlayercolor(c_nodelist.Item(2).InnerText)
                Players.Add(TempPlayer)
            Next
        Catch ex As Exception
            Exit Try
        End Try
    End Sub

    'Two Different divy functions that are only slightly different so i can reuse the code for both the new and load functions

    Public Sub DivyTerr(ByRef Game As Game)
        Dim AllTerr As New List(Of Territory) 'A list of all of the territory is created so it can be gone through in a random order
        For i = 0 To (Map.Count - 1)
            AllTerr.AddRange(Game.Map(i).Territories)
        Next
        Dim CurrentPlayer As Integer = 0
        Dim CurrentTerr As Territory
        Dim CurrentTerrLoc As Point
        Dim CurrentTerrNum As Integer
        Do Until AllTerr.Count = 0 'With every itteration the territory that was randomly selected is removed from the list of territories
            Randomize()
            CurrentTerrNum = (Rnd() * (AllTerr.Count - 1))
            CurrentTerr = AllTerr(CurrentTerrNum) 'A random territory is selected
            CurrentTerrLoc = FindTerr(CurrentTerr.getName) 'The location within the continent structure is determined
            Game.Map(CurrentTerrLoc.X).Territories(CurrentTerrLoc.Y).SetPlayerNum(CurrentPlayer) 'Whichever player whose turn it is to recieve is set as the new owner of the territory
            Game.SetButtonBorderCol(Game.Map(CurrentTerrLoc.X).Territories(CurrentTerrLoc.Y).getName, (Game.Players(CurrentPlayer).GetPlayerColor)) 'the border color of the button that represents the territory is changed
            Game.Players(CurrentPlayer).GainTerritiory() 'The players territory number is then increased
            If CurrentPlayer = (Game.Players.Count - 1) Then 'The next player to recieve is then selected
                CurrentPlayer = 0
            Else
                CurrentPlayer = CurrentPlayer + 1
            End If
            AllTerr.Remove(CurrentTerr) 'The territory just dished out is the removed from the list as to progress to the point when we have no territories
        Loop
    End Sub

    Public Sub DivyLoadedTerr(ByRef Game As Game) 'Similar to the previos function but relevant the the territories already being owned
        Dim AllTerr As New List(Of Territory)
        For i = 0 To (Map.Count - 1)
            AllTerr.AddRange(Game.Map(i).Territories)
        Next
        Dim CurrentPlayer As Integer
        Dim CurrentTerr As Territory
        Dim CurrentTerrLoc As Point
        Dim CurrentTerrNum As Integer
        Do Until AllTerr.Count = 0
            Randomize()
            CurrentTerrNum = (Rnd() * (AllTerr.Count - 1)) 'Current territory still selected randomly
            CurrentTerr = AllTerr(CurrentTerrNum)
            CurrentTerrLoc = FindTerr(CurrentTerr.getName)
            CurrentPlayer = Game.Map(CurrentTerrLoc.X).Territories(CurrentTerrLoc.Y).GetPlayerNum 'Current player determined by who owns the territory rather than being a loop between the players
            Game.SetButtonBorderCol(Game.Map(CurrentTerrLoc.X).Territories(CurrentTerrLoc.Y).getName, (Game.Players(CurrentPlayer).GetPlayerColor)) 'Border color of the corisponding button is set
            AllTerr.Remove(CurrentTerr) 'Territory removed from the list
        Loop
    End Sub

    Public Sub drawmap(ByRef game As Game)
        For i As Integer = 0 To ((game.ReturnMap.Count) - 1)
            'start looping through continents
            Dim cont As Continent
            'to keep the continent being used on hand
            cont = game.ReturnMap(i)
            For j As Integer = 0 To cont.ReturnTerr.count - 1
                'start looping through territories
                Dim terr As Territory
                Dim terrName As String
                Dim terrloc As New System.Drawing.Point()
                Dim terrColor As Color = Color.Yellow
                Dim terrTroop As Integer = 0
                terr = cont.ReturnTerr(j)
                terrName = terr.getName
                terrloc.X = terr.getx
                terrloc.Y = terr.gety
                If (terr.GetPlayerNum) >= 0 Then
                    terrTroop = terr.GetTroopNum
                    terrColor = Players(terr.GetPlayerNum).GetColor
                End If
                Dim newbutton As Button = My.Forms.GameForm.createButton(terrloc, terrName, terrColor)
                'give button properties
                buttons.Add(newbutton)
                'adds button to the list
                Dim labelLocation As Point
                labelLocation.X = terrloc.X + 25
                labelLocation.Y = terrloc.Y
                Dim newLabel As Label = My.Forms.GameForm.CreateLabel(labelLocation)
                newLabel.Text = terrTroop
                Labels.Add(newLabel)
            Next
        Next
    End Sub

    'The gameplay loop methods
    Public Sub Reinforce(ByVal playernum As Integer) 'The method that calculates the amount of troops that the player can place, tells them, and adds them to the buttons pressed
        Dim ReinforceNum As Integer 'The number of the troops the player will have to place
        ReinforceNum = ((Players(playernum).GetTerrNum() / 3) - (Players(playernum).GetTerrNum() Mod 3)) 'Calulates the Amount of troops the player can place
        If ReinforceNum < 3 Then ReinforceNum = 3 'If the number calculated is lower than the minimum of 3 then it will be set to the minimum of 3
        CheckConPlayers(playernum)
        For i = 0 To (Map.Count - 1) 'Adds the troops provided by owning a whole continent
            If Map(i).GetPlayer = playernum Then
                ReinforceNum = ReinforceNum + Map(i).GetValue
            End If
        Next
        My.Forms.GameForm.AddToFeed(Players(playernum).GetName & Players(playernum).GetColor.ToString.Substring(5) & " you have " & ReinforceNum & " troops to place this turn. Please select a territory you own to place troops on it.")
        Dim ButtonPressedBool As Boolean = False
        Dim ButtonPressedName As String
        Dim TroopNum As Integer
        Dim Condition As Boolean = False
        Do Until Condition = True 'This will wait until the player has placed all of the troopos they can place
            If Players(playernum).IsAI Then
                ButtonPressedName = Players(playernum).LongestPath
            Else

                Do Until ButtonPressedBool = True 'Waits for the player to press a button
                    Application.DoEvents()
                    ButtonPressedBool = My.Forms.GameForm.ButtonPressed
                Loop
                ButtonPressedName = My.Forms.GameForm.WhichButtonPressed 'Checks what button was placed
                ButtonPressedBool = False
            End If
            Dim terrLoc As Point = FindTerr(ButtonPressedName) 'Finds the territory that was selected
            If Map(terrLoc.X).Territories(terrLoc.Y).GetPlayerNum = playernum Then 'Checks if the player owns the territory they selected
                If Players(playernum).IsAI Then
                    TroopNum = ReinforceNum
                Else
                    TroopNum = InputBox("Out of you " & ReinforceNum & " troops left how many would you like to place?") 'Asks how many Of the troops they can place that they would Like To place
                End If
                If TroopNum <= ReinforceNum And TroopNum > 0 Then 'Checks the Number they entered is between zero and the number they can place
                    Map(terrLoc.X).Territories(terrLoc.Y).AddTroop(TroopNum) 'Adds the troop to the territory
                    ReinforceNum = ReinforceNum - TroopNum
                    If ReinforceNum = 0 Then 'Checks if they have placed all of their troops
                        Condition = True 'If so it allows us to leave the loop
                    End If
                Else
                    MsgBox("That number was invalid please try again.") 'If the number was not between 0 and the reinforcement number then it repats the placement loop
                End If
            Else
                MsgBox("Please select a territory YOU OWN to place troops on it.") 'If the number was not owned by the player then it repats the placement loop
            End If
        Loop
    End Sub

    Public Sub Attack(ByVal playerNum As Integer) 'The methode that determines where you wish to attack and if you can
        My.Forms.GameForm.AddToFeed(Players(playerNum).GetName & " please select a territory you own with which you would like to attack another territory. Or press the end phase button.")
        Dim AttackingTerritory As String
        Dim defendingTerritory As String
        Dim condition As Boolean = False
        Dim defendingPlayer As Integer
        My.Forms.GameForm.EndPhase.Visible = True
        Do Until condition = True 'A loop that keeps going untill the player either selects a territory that they can attack from or the end phase button
            If Players(playerNum).IsAI Then
                My.Forms.GameForm.WhichButtonPressed = Players(playerNum).GetAttTerr()
            Else
                My.Forms.GameForm.WaitForButton() 'A method in My.Forms.GameForm that waits for the player to click a button
                If My.Forms.GameForm.WhichButtonPressed = "End Phase" Then 'If the player wants to move from the attack phase to the redeployment phase they will click this button
                    Exit Sub
                End If
            End If
            Dim terrLoc As Point = FindTerr(My.Forms.GameForm.WhichButtonPressed) 'Finds which territory the button is refering to
            If Map(terrLoc.X).Territories(terrLoc.Y).GetPlayerNum = playerNum Then 'Checks if the territory they selected is their own
                If Map(terrLoc.X).Territories(terrLoc.Y).GetTroopNum > 1 Then 'Checks if the territory is able to spare troops
                    AttackingTerritory = Map(terrLoc.X).Territories(terrLoc.Y).getName
                    condition = True 'Allows the loop to stop as a valid territory has been found
                Else
                    If Players(playerNum).IsAI() Then
                        Exit Sub
                    Else
                        MsgBox("Please select a territory with enough troops to mount an attack.")
                    End If
                End If
            Else
                MsgBox("Please select a territory YOU OWN.")
            End If
        Loop
        My.Forms.GameForm.AddToFeed(Players(playerNum).GetName & " has selected " & AttackingTerritory & " as the attacking territory. Please Select a neighbouring territory to attack")
        condition = False
        Do Until condition = True 'Another loop that loops until they select a valid oponant or chooses to end the phase
            If Players(playerNum).IsAI Then
                My.Forms.GameForm.WhichButtonPressed = Players(playerNum).GetDeffTerr()
            Else
                My.Forms.GameForm.WaitForButton()
                If My.Forms.GameForm.WhichButtonPressed = "End Phase" Then
                    Exit Sub
                End If
            End If
            Dim terrLoc As Point = FindTerr(My.Forms.GameForm.WhichButtonPressed)
            If Map(terrLoc.X).Territories(terrLoc.Y).GetPlayerNum = playerNum Then 'Makes sure that the territory is not theirs as they cannot attack themself
                MsgBox("You cannot attack yourself, please select a territory you do not own")
            Else
                For k = 0 To (Map(terrLoc.X).Territories(terrLoc.Y).Getneighbours.count - 1) 'Checks if the territory selected is a neighbour of the attacking territory
                    If Map(terrLoc.X).Territories(terrLoc.Y).Getneighbours(k) = AttackingTerritory Then
                        defendingTerritory = Map(terrLoc.X).Territories(terrLoc.Y).getName
                        defendingPlayer = Map(terrLoc.X).Territories(terrLoc.Y).GetPlayerNum
                        condition = True
                    End If
                Next
                If condition = False Then
                    MsgBox("Please select a territory that neighbours the territory you selected to attack from.")
                End If
            End If
        Loop
        Dim CanAttack As Boolean = False
        Dim NumberOfAttackers As Integer
        Do While CanAttack = False 'This loop is to wait until the player enters a valid number of troops
            If Players(playerNum).IsAI() Then
                NumberOfAttackers = GetTerr(AttackingTerritory).GetTroopNum - 1
            Else
                NumberOfAttackers = InputBox("Player " & Players(playerNum).GetName & " please input the amount of troops with which you would like to attack.")
            End If
            Dim terrLoc As Point = FindTerr(AttackingTerritory)
            If (Map(terrLoc.X).Territories(terrLoc.Y).GetTroopNum - 1) >= (NumberOfAttackers) Then 'Checks if the territory can spare the number of troops the player entered
                If NumberOfAttackers <= 3 Then 'Checks the number does not exceed the max number of troops that can be used to attack
                    If NumberOfAttackers > 0 Then CanAttack = True
                Else
                    MsgBox("You cannot mount an attack with more than 3 troops")
                End If
            Else
                MsgBox("This number exceeds the number of troops that this territory can spare")
            End If
        Loop
        Dim Candefend As Boolean = False
        Dim NumberOfdefenders As Integer
        Do While Candefend = False
            Dim terrLoc As Point = FindTerr(defendingTerritory)
            If Map(terrLoc.X).Territories(terrLoc.Y).GetTroopNum = 1 Then 'If the number of troops in only one their is only one valid number the defender can enter 
                NumberOfdefenders = 1
                Exit Do
            End If
            If Players(defendingPlayer).IsAI() Then
                NumberOfdefenders = 2
            Else
                NumberOfdefenders = InputBox("Player " & Players(defendingPlayer).GetName & " please input the amount of troops with which you would like to defend.")
            End If
            If Map(terrLoc.X).Territories(terrLoc.Y).GetTroopNum >= NumberOfdefenders Then
                If NumberOfdefenders <= 2 Then
                    Candefend = True
                Else
                    MsgBox("You cannot defend with more than 2 troops.")
                    End If
                Else
                    MsgBox("This number exceeds the number of troops that this territory has.")
            End If
        Loop
        Dim ADice As New List(Of Double)
        Dim DDice As New List(Of Double)
        Dim IntegerHolder As Integer
        Randomize()
        My.Forms.GameForm.DiceHeader.Visible = True
        For i = 1 To NumberOfAttackers 'Rolls a number of dice equal to the number of attackers and adds each to the list
            ADice.Add((Rnd() * 5) + 1)
            If i = 1 Then
                IntegerHolder = ADice(0)
                My.Forms.GameForm.ADice1.Text = IntegerHolder
                My.Forms.GameForm.ADice1.Visible = True
            ElseIf i = 2 Then
                IntegerHolder = ADice(1)
                My.Forms.GameForm.ADice2.Text = IntegerHolder
                My.Forms.GameForm.ADice2.Visible = True
            Else
                IntegerHolder = ADice(2)
                My.Forms.GameForm.ADice3.Text = IntegerHolder
                My.Forms.GameForm.ADice3.Visible = True
            End If
        Next
        For i = 1 To NumberOfdefenders
            DDice.Add((Rnd() * 5) + 1)
            If i = 1 Then
                IntegerHolder = DDice(0)
                My.Forms.GameForm.DDice1.Text = IntegerHolder
                My.Forms.GameForm.DDice1.Visible = True
            Else
                IntegerHolder = DDice(1)
                My.Forms.GameForm.DDice2.Text = IntegerHolder
                My.Forms.GameForm.DDice2.Visible = True
            End If
        Next
        Dim ACount As Integer = ADice.Count
        Dim DCount As Integer = DDice.Count
        Dim AHigh As Integer
        Dim DHigh As Integer
        'Next Finds the highest roll
        If ACount > 1 Then
            If ACount = 3 Then
                If ADice(0) < ADice(1) Then
                    If ADice(1) < ADice(2) Then
                        AHigh = ADice(2)
                        condition = True
                    Else
                        AHigh = ADice(1)
                        condition = True
                    End If
                Else
                    If ADice(0) < ADice(2) Then
                        AHigh = ADice(2)
                        condition = True
                    Else
                        AHigh = ADice(0)
                        condition = True
                    End If
                End If
            Else
                If ADice(0) > ADice(1) Then
                    AHigh = ADice(0)
                    condition = True
                Else
                    AHigh = ADice(1)
                    condition = True
                End If
            End If
        Else
            AHigh = ADice(0)
            condition = True
        End If
        If DCount > 1 Then
            If DDice(0) > DDice(1) Then
                DHigh = DDice(0)
            Else
                DHigh = DDice(1)
            End If
        Else
            DHigh = DDice(0)
            condition = True
        End If
        Dim MovingTroops As Integer
        If AHigh > DHigh Then 'When the attacker wins
            My.Forms.GameForm.AddToFeed(("Player " & playerNum & " wins with their highest dice roll of " & AHigh & " being greater than player " & defendingPlayer & "'s highest dice roll of " & DHigh))
            Dim DefTerrLoc As Point = FindTerr(defendingTerritory)
            If Map(DefTerrLoc.X).Territories(DefTerrLoc.Y).LoseTroop = 0 Then 'Checks after the defending territory loses the troop wether or not they have any troops on the territory
                If Players(playerNum).IsAI() Then
                    MovingTroops = Players(playerNum).WinBattle()
                Else
                        MovingTroops = InputBox("Congratulations " & Players(playerNum).GetName & " has captured " & defendingTerritory & " , how many troops would you like to station here.")
                End If
                Players(playerNum).GainTerritiory()
                Players(defendingPlayer).LoseTerritory()
                Dim CanInvade As Boolean = False
                Do While CanInvade = False
                    Dim AttTerrLoc As Point = FindTerr(AttackingTerritory)
                    If Map(AttTerrLoc.X).Territories(AttTerrLoc.Y).GetTroopNum > MovingTroops Then
                        CanInvade = True
                        Map(DefTerrLoc.X).Territories(DefTerrLoc.Y).Capture((playerNum), MovingTroops)
                        For i = 1 To MovingTroops
                            Map(AttTerrLoc.X).Territories(AttTerrLoc.Y).LoseTroop()
                        Next
                    Else
                        MovingTroops = InputBox("This exceeds the number of Troops " & AttackingTerritory & " can spare, please enter a valid number")
                    End If
                Loop
            Else
                My.Forms.GameForm.AddToFeed(Players(playerNum - 1).GetName & " wins the day")
            End If
        Else 'When the defender wins
            MsgBox("Player " & Players(defendingPlayer).GetName & " wins with their highest dice roll of " & DHigh & " being greater than or equal to player " & Players(playerNum).GetName & "'s highest dice roll of " & AHigh)
            Dim DefTerrLoc As Point = FindTerr(defendingTerritory)
            My.Forms.GameForm.AddToFeed("Congratulations " & Players(Map(DefTerrLoc.X).Territories(DefTerrLoc.Y).GetPlayerNum).GetName & " has won the day.")
            Dim AttTerrLoc As Point = FindTerr(AttackingTerritory)
            Map(AttTerrLoc.X).Territories(AttTerrLoc.Y).LoseTroop()
        End If
        My.Forms.GameForm.ADice1.Visible = False
        My.Forms.GameForm.ADice2.Visible = False
        My.Forms.GameForm.ADice3.Visible = False
        My.Forms.GameForm.DDice1.Visible = False
        My.Forms.GameForm.DDice2.Visible = False
        My.Forms.GameForm.DiceHeader.Visible = False
    End Sub

    Public Sub Redeploy(ByVal PlayerNum As Integer)
        My.Forms.GameForm.AddToFeed(Players(PlayerNum - 1).GetName & " please select a territory from which you would like to move troops or press the end phase button to end your turn.")
        Dim MovingTerritory As String
        Dim Condition As Boolean = False
        Do Until Condition = True
            My.Forms.GameForm.WaitForButton()
            If My.Forms.GameForm.WhichButtonPressed = "End Phase" Then
                Exit Sub
            End If
            Dim TempTerrLoc As Point = FindTerr(My.Forms.GameForm.WhichButtonPressed)
            If Map(TempTerrLoc.X).Territories(TempTerrLoc.Y).GetPlayerNum = PlayerNum Then
                If Map(TempTerrLoc.X).Territories(TempTerrLoc.Y).GetTroopNum > 1 Then
                    MovingTerritory = Map(TempTerrLoc.X).Territories(TempTerrLoc.Y).getName
                    Condition = True
                Else
                    MsgBox("You Must leave at least 1 troop on each territory you own and therefore cannot move troops from a territory with only 1 troop, please select a territory you own from which you would like to move troops.")
                End If
            Else
                MsgBox("You can only move troops from territories you own, please select a territory you own from which you would like to move troops.")
            End If
        Loop
        Dim MovingTroops As Integer = InputBox("Please enter the number of troops that you would like to move from this territories.")
        Condition = False
        Do Until Condition = True
            Dim TempTerrLoc As Point = FindTerr(MovingTerritory)
            If MovingTroops > 0 Then
                If Map(TempTerrLoc.X).Territories(TempTerrLoc.Y).GetTroopNum > MovingTroops Then
                    Condition = True
                Else
                    MovingTroops = InputBox("This number exceeds the number of troops this unit can spare please enter a valid number.")
                End If
            Else
                MovingTroops = InputBox("Please enter a number greater than zero.")
            End If
        Loop
        Dim TargetTerritory As String
        My.Forms.GameForm.AddToFeed("Now select the territory you would like to move these troops to.")
        Condition = False
        Do Until Condition = True
            My.Forms.GameForm.WaitForButton()
            TargetTerritory = My.Forms.GameForm.WhichButtonPressed
            Dim TempTerrLoc As Point = FindTerr(TargetTerritory)
            If Map(TempTerrLoc.X).Territories(TempTerrLoc.Y).GetPlayerNum = PlayerNum Then
                Condition = True
            Else
                MsgBox("You cannot move troops to a territory you do not own, please select a territory you own.")
            End If
            If TargetTerritory = MovingTerritory Then
                MsgBox("Its Pointless to move the troops to the territory that they came from, please select another")
                Condition = False
            End If
        Loop
        Dim TerrLoc As Point = FindTerr(MovingTerritory)
        Map(TerrLoc.X).Territories(TerrLoc.Y).MoveTroops(MovingTroops)
        TerrLoc = FindTerr(TargetTerritory)
        Map(TerrLoc.X).Territories(TerrLoc.Y).AddTroop(MovingTroops)
    End Sub
    Public Function PlayerWon(ByVal PlayerNum As Integer)
        Dim TerrToWin As Integer = 0
        For i = 0 To (Map.Count - 1)
            TerrToWin = TerrToWin + Map(i).Territories.Count
        Next
        If Players(PlayerNum).GetTerrNum() = TerrToWin Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub SaveGame(ByVal fileName As String)
        Dim XmlSave As New XmlDocument
        Dim Save As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Save", "")
        Dim StoreCurrentPlayer As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "CurrentPlayer", "")
        StoreCurrentPlayer.InnerText = 1
        Save.AppendChild(StoreCurrentPlayer)
        Dim Players As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Players", "")
        For i = 0 To Me.Players.Count - 1
            Dim Player As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Player", "")
            Dim Name As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Name", "")
            Name.InnerText = Me.Players(i).GetName
            Player.AppendChild(Name)
            Dim TerritoryNum As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "TerritoryNum", "")
            TerritoryNum.InnerText = Me.Players(i).GetTerrNum
            Player.AppendChild(TerritoryNum)
            Dim Color As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Color", "")
            Color.InnerText = Me.Players(i).GetColor.ToString
            Player.AppendChild(Color)
            Players.AppendChild(Player)
        Next
        Save.AppendChild(Players)
        Dim Map As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Map", "")
        For i = 0 To Me.Map.Count - 1
            Dim Continent As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Continent", "")
            Dim ContinentName As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "ContinentName", "")
            ContinentName.InnerText() = Me.Map(i).GetName
            Continent.AppendChild(ContinentName)
            Dim Value As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Value", "")
            Value.InnerText() = Me.Map(i).GetValue
            Continent.AppendChild(Value)
            Dim Player As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Player", "")
            Player.InnerText() = Me.Map(i).GetPlayer
            Continent.AppendChild(Player)
            For j = 0 To Me.Map(i).Territories.Count - 1
                Dim Territory As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Territory", "")
                Dim TerritoryName As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "TerritoryName", "")
                TerritoryName.InnerText = Me.Map(i).Territories(j).getName
                Territory.AppendChild(TerritoryName)
                Dim X As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "X", "")
                X.InnerText = Me.Map(i).Territories(j).coordinateX
                Territory.AppendChild(X)
                Dim Y As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "Y", "")
                Y.InnerText = Me.Map(i).Territories(j).coordinateY
                Territory.AppendChild(Y)
                Dim PlayerNum As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "PlayerName", "")
                PlayerNum.InnerText = Me.Map(i).Territories(j).GetPlayerNum
                Territory.AppendChild(PlayerNum)
                Dim TroopNum As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "TroopNum", "")
                TroopNum.InnerText = Me.Map(i).Territories(j).GetTroopNum
                Territory.AppendChild(TroopNum)
                For k = 0 To Me.Map(i).Territories(j).Neighbours.Count - 1
                    Dim neighbour As XmlNode = XmlSave.CreateNode(XmlNodeType.Element, "neighbour", "")
                    neighbour.InnerText = Me.Map(i).Territories(j).Neighbours(k)
                    Territory.AppendChild(neighbour)
                Next
                Continent.AppendChild(Territory)
            Next
            Map.AppendChild(Continent)
        Next
        Save.AppendChild(Map)
        XmlSave.AppendChild(Save)
        XmlSave.Save("C:\Users\William\Documents\Visual Studio 2015\Projects\My.Forms.GameForm Game\My.Forms.GameForm game\My.Forms.GameForm game" & fileName & ".XML")
    End Sub

    Public Sub CheckConPlayers(ByVal playerNum As Integer)
        Dim ConControlBool As New List(Of Boolean)

        For i = 0 To (Map.Count - 1)
            ConControlBool.Add(True)
            For j = 0 To (Map(i).Territories.Count - 1)
                If Map(i).Territories(j).GetPlayerNum = playerNum Then
                Else
                    ConControlBool(i) = False
                End If
            Next
            If ConControlBool(i) = True Then
                Map(i).SetPlayer(playerNum)
            End If
        Next
    End Sub
    Public Function FindTerr(ByVal Terr As String) As Point
        Dim location As Point
        For i = 0 To (Map.Count - 1)
            For j = 0 To (Map(i).Territories.Count - 1)
                If Map(i).Territories(j).getName = Terr Then
                    location.X = i
                    location.Y = j
                    Return location
                End If
            Next
        Next
    End Function
    'loops though the maps continents and in turn their territories to find and replace the territory's owner
    Public Function GetTerr(ByVal Terr As String) As Territory
        Dim Loc As Point = FindTerr(Terr)
        Return Map(Loc.X).Territories(Loc.Y)
    End Function
End Class
