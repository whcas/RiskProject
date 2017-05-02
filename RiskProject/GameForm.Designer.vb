<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GameForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToMainMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeedBox = New System.Windows.Forms.RichTextBox()
        Me.DiceHeader = New System.Windows.Forms.Label()
        Me.ADice1 = New System.Windows.Forms.Label()
        Me.DDice1 = New System.Windows.Forms.Label()
        Me.ADice2 = New System.Windows.Forms.Label()
        Me.DDice2 = New System.Windows.Forms.Label()
        Me.ADice3 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.ExitToMainMenuToolStripMenuItem, Me.ExitToWindowsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ExitToMainMenuToolStripMenuItem
        '
        Me.ExitToMainMenuToolStripMenuItem.Name = "ExitToMainMenuToolStripMenuItem"
        Me.ExitToMainMenuToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.ExitToMainMenuToolStripMenuItem.Text = "Exit to Main Menu"
        '
        'ExitToWindowsToolStripMenuItem
        '
        Me.ExitToWindowsToolStripMenuItem.Name = "ExitToWindowsToolStripMenuItem"
        Me.ExitToWindowsToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.ExitToWindowsToolStripMenuItem.Text = "Exit to Windows"
        '
        'FeedBox
        '
        Me.FeedBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FeedBox.Location = New System.Drawing.Point(10, 120)
        Me.FeedBox.Name = "FeedBox"
        Me.FeedBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.FeedBox.Size = New System.Drawing.Size(100, 131)
        Me.FeedBox.TabIndex = 1
        Me.FeedBox.Text = ""
        '
        'DiceHeader
        '
        Me.DiceHeader.AutoSize = True
        Me.DiceHeader.Location = New System.Drawing.Point(188, 30)
        Me.DiceHeader.Name = "DiceHeader"
        Me.DiceHeader.Size = New System.Drawing.Size(77, 13)
        Me.DiceHeader.TabIndex = 3
        Me.DiceHeader.Text = "The Dice Rolls"
        Me.DiceHeader.Visible = False
        '
        'ADice1
        '
        Me.ADice1.AutoSize = True
        Me.ADice1.Location = New System.Drawing.Point(188, 50)
        Me.ADice1.Name = "ADice1"
        Me.ADice1.Size = New System.Drawing.Size(39, 13)
        Me.ADice1.TabIndex = 4
        Me.ADice1.Text = "Label1"
        Me.ADice1.Visible = False
        '
        'DDice1
        '
        Me.DDice1.AutoSize = True
        Me.DDice1.Location = New System.Drawing.Point(240, 50)
        Me.DDice1.Name = "DDice1"
        Me.DDice1.Size = New System.Drawing.Size(39, 13)
        Me.DDice1.TabIndex = 5
        Me.DDice1.Text = "Label2"
        Me.DDice1.Visible = False
        '
        'ADice2
        '
        Me.ADice2.AutoSize = True
        Me.ADice2.Location = New System.Drawing.Point(188, 70)
        Me.ADice2.Name = "ADice2"
        Me.ADice2.Size = New System.Drawing.Size(39, 13)
        Me.ADice2.TabIndex = 6
        Me.ADice2.Text = "Label3"
        Me.ADice2.Visible = False
        '
        'DDice2
        '
        Me.DDice2.AutoSize = True
        Me.DDice2.Location = New System.Drawing.Point(240, 70)
        Me.DDice2.Name = "DDice2"
        Me.DDice2.Size = New System.Drawing.Size(39, 13)
        Me.DDice2.TabIndex = 7
        Me.DDice2.Text = "Label4"
        Me.DDice2.Visible = False
        '
        'ADice3
        '
        Me.ADice3.AutoSize = True
        Me.ADice3.Location = New System.Drawing.Point(188, 90)
        Me.ADice3.Name = "ADice3"
        Me.ADice3.Size = New System.Drawing.Size(39, 13)
        Me.ADice3.TabIndex = 8
        Me.ADice3.Text = "Label5"
        Me.ADice3.Visible = False
        '
        'GameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.ADice3)
        Me.Controls.Add(Me.DDice2)
        Me.Controls.Add(Me.ADice2)
        Me.Controls.Add(Me.DDice1)
        Me.Controls.Add(Me.ADice1)
        Me.Controls.Add(Me.DiceHeader)
        Me.Controls.Add(Me.FeedBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "GameForm"
        Me.Text = "GameForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToMainMenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToWindowsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FeedBox As RichTextBox
    Friend WithEvents DiceHeader As Label
    Friend WithEvents ADice1 As Label
    Friend WithEvents DDice1 As Label
    Friend WithEvents ADice2 As Label
    Friend WithEvents DDice2 As Label
    Friend WithEvents ADice3 As Label
End Class
