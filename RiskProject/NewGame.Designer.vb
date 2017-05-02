<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewGame
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MapLab = New System.Windows.Forms.Label()
        Me.PickMapBtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.HumanPlayersNum = New System.Windows.Forms.ComboBox()
        Me.CreateBtn = New System.Windows.Forms.Button()
        Me.CnclBtn = New System.Windows.Forms.Button()
        Me.MapFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ImageFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComputerPlayersNum = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(303, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Creating A New Game"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Chose a map to play on:"
        '
        'MapLab
        '
        Me.MapLab.AutoSize = True
        Me.MapLab.Location = New System.Drawing.Point(50, 105)
        Me.MapLab.MaximumSize = New System.Drawing.Size(103, 13)
        Me.MapLab.Name = "MapLab"
        Me.MapLab.Size = New System.Drawing.Size(103, 13)
        Me.MapLab.TabIndex = 2
        Me.MapLab.Text = "Please chose a map"
        '
        'PickMapBtn
        '
        Me.PickMapBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PickMapBtn.Location = New System.Drawing.Point(158, 101)
        Me.PickMapBtn.Name = "PickMapBtn"
        Me.PickMapBtn.Size = New System.Drawing.Size(29, 23)
        Me.PickMapBtn.TabIndex = 3
        Me.PickMapBtn.Text = "..."
        Me.PickMapBtn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(212, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "How many human players"
        '
        'HumanPlayersNum
        '
        Me.HumanPlayersNum.FormattingEnabled = True
        Me.HumanPlayersNum.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.HumanPlayersNum.Location = New System.Drawing.Point(50, 164)
        Me.HumanPlayersNum.Name = "HumanPlayersNum"
        Me.HumanPlayersNum.Size = New System.Drawing.Size(147, 21)
        Me.HumanPlayersNum.TabIndex = 8
        Me.HumanPlayersNum.Text = "3"
        '
        'CreateBtn
        '
        Me.CreateBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreateBtn.Location = New System.Drawing.Point(215, 254)
        Me.CreateBtn.Name = "CreateBtn"
        Me.CreateBtn.Size = New System.Drawing.Size(114, 41)
        Me.CreateBtn.TabIndex = 11
        Me.CreateBtn.Text = "Create"
        Me.CreateBtn.UseVisualStyleBackColor = True
        '
        'CnclBtn
        '
        Me.CnclBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CnclBtn.Location = New System.Drawing.Point(215, 300)
        Me.CnclBtn.Name = "CnclBtn"
        Me.CnclBtn.Size = New System.Drawing.Size(114, 41)
        Me.CnclBtn.TabIndex = 12
        Me.CnclBtn.Text = "Cancel"
        Me.CnclBtn.UseVisualStyleBackColor = True
        '
        'MapFileDialog
        '
        Me.MapFileDialog.FileName = "OpenFileDialog1"
        '
        'ImageFileDialog
        '
        Me.ImageFileDialog.FileName = "OpenFileDialog2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(233, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "How many computer players"
        '
        'ComputerPlayersNum
        '
        Me.ComputerPlayersNum.FormattingEnabled = True
        Me.ComputerPlayersNum.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.ComputerPlayersNum.Location = New System.Drawing.Point(50, 221)
        Me.ComputerPlayersNum.Name = "ComputerPlayersNum"
        Me.ComputerPlayersNum.Size = New System.Drawing.Size(147, 21)
        Me.ComputerPlayersNum.TabIndex = 10
        Me.ComputerPlayersNum.Text = "0"
        '
        'NewGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 346)
        Me.Controls.Add(Me.CnclBtn)
        Me.Controls.Add(Me.CreateBtn)
        Me.Controls.Add(Me.ComputerPlayersNum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.HumanPlayersNum)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PickMapBtn)
        Me.Controls.Add(Me.MapLab)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "NewGame"
        Me.Text = "NewGame"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents MapLab As Label
    Friend WithEvents PickMapBtn As Button
    Friend WithEvents HumanPlayersNum As ComboBox
    Friend WithEvents CreateBtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CnclBtn As Button
    Friend WithEvents MapFileDialog As OpenFileDialog
    Friend WithEvents ImageFileDialog As OpenFileDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents ComputerPlayersNum As ComboBox
End Class
