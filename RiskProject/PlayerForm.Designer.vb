<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayerForm
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
        Me.TitleLab = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AICreateBtn = New System.Windows.Forms.Button()
        Me.NameInput = New System.Windows.Forms.TextBox()
        Me.ColorInput = New System.Windows.Forms.ComboBox()
        Me.HumCreateBtn = New System.Windows.Forms.Button()
        Me.HumOrAILab = New System.Windows.Forms.Label()
        Me.WhichType = New System.Windows.Forms.ComboBox()
        Me.TypeLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TitleLab
        '
        Me.TitleLab.AutoSize = True
        Me.TitleLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLab.Location = New System.Drawing.Point(15, 35)
        Me.TitleLab.Name = "TitleLab"
        Me.TitleLab.Size = New System.Drawing.Size(246, 39)
        Me.TitleLab.TabIndex = 0
        Me.TitleLab.Text = "Player Design"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Colour:"
        '
        'AICreateBtn
        '
        Me.AICreateBtn.Location = New System.Drawing.Point(197, 191)
        Me.AICreateBtn.Name = "AICreateBtn"
        Me.AICreateBtn.Size = New System.Drawing.Size(75, 23)
        Me.AICreateBtn.TabIndex = 5
        Me.AICreateBtn.Text = "Create"
        Me.AICreateBtn.UseVisualStyleBackColor = True
        Me.AICreateBtn.Visible = False
        '
        'NameInput
        '
        Me.NameInput.Location = New System.Drawing.Point(150, 90)
        Me.NameInput.Name = "NameInput"
        Me.NameInput.Size = New System.Drawing.Size(121, 20)
        Me.NameInput.TabIndex = 6
        '
        'ColorInput
        '
        Me.ColorInput.FormattingEnabled = True
        Me.ColorInput.Items.AddRange(New Object() {"Red", "Yellow", "Green", "Blue", "Purple"})
        Me.ColorInput.Location = New System.Drawing.Point(149, 125)
        Me.ColorInput.Name = "ColorInput"
        Me.ColorInput.Size = New System.Drawing.Size(121, 21)
        Me.ColorInput.TabIndex = 7
        '
        'HumCreateBtn
        '
        Me.HumCreateBtn.Location = New System.Drawing.Point(197, 152)
        Me.HumCreateBtn.Name = "HumCreateBtn"
        Me.HumCreateBtn.Size = New System.Drawing.Size(75, 23)
        Me.HumCreateBtn.TabIndex = 8
        Me.HumCreateBtn.Text = "Create"
        Me.HumCreateBtn.UseVisualStyleBackColor = True
        Me.HumCreateBtn.Visible = False
        '
        'HumOrAILab
        '
        Me.HumOrAILab.AutoSize = True
        Me.HumOrAILab.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HumOrAILab.Location = New System.Drawing.Point(71, 4)
        Me.HumOrAILab.Name = "HumOrAILab"
        Me.HumOrAILab.Size = New System.Drawing.Size(126, 39)
        Me.HumOrAILab.TabIndex = 4
        Me.HumOrAILab.Text = "Label4"
        '
        'WhichType
        '
        Me.WhichType.FormattingEnabled = True
        Me.WhichType.Items.AddRange(New Object() {"The Conquerer", "The Deffender", "The Agent of Chaos", "The Indicisive One", "Random Type"})
        Me.WhichType.Location = New System.Drawing.Point(149, 160)
        Me.WhichType.Name = "WhichType"
        Me.WhichType.Size = New System.Drawing.Size(121, 21)
        Me.WhichType.TabIndex = 9
        '
        'TypeLabel
        '
        Me.TypeLabel.AutoSize = True
        Me.TypeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeLabel.Location = New System.Drawing.Point(20, 155)
        Me.TypeLabel.Name = "TypeLabel"
        Me.TypeLabel.Size = New System.Drawing.Size(66, 25)
        Me.TypeLabel.TabIndex = 10
        Me.TypeLabel.Text = "Type:"
        '
        'PlayerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 225)
        Me.Controls.Add(Me.TypeLabel)
        Me.Controls.Add(Me.WhichType)
        Me.Controls.Add(Me.HumCreateBtn)
        Me.Controls.Add(Me.ColorInput)
        Me.Controls.Add(Me.NameInput)
        Me.Controls.Add(Me.AICreateBtn)
        Me.Controls.Add(Me.HumOrAILab)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TitleLab)
        Me.Name = "PlayerForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TitleLab As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents AICreateBtn As Button
    Friend WithEvents NameInput As TextBox
    Friend WithEvents ColorInput As ComboBox
    Friend WithEvents HumCreateBtn As Button
    Friend WithEvents HumOrAILab As Label
    Friend WithEvents WhichType As ComboBox
    Friend WithEvents TypeLabel As Label
End Class
