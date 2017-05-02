<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuForm
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
        Me.LoadBtn = New System.Windows.Forms.Button()
        Me.NewBtn = New System.Windows.Forms.Button()
        Me.ExitBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(90, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 108)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Risk"
        '
        'LoadBtn
        '
        Me.LoadBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadBtn.Location = New System.Drawing.Point(120, 226)
        Me.LoadBtn.Name = "LoadBtn"
        Me.LoadBtn.Size = New System.Drawing.Size(180, 65)
        Me.LoadBtn.TabIndex = 1
        Me.LoadBtn.Text = "Load"
        Me.LoadBtn.UseVisualStyleBackColor = True
        '
        'NewBtn
        '
        Me.NewBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewBtn.Location = New System.Drawing.Point(119, 156)
        Me.NewBtn.Name = "NewBtn"
        Me.NewBtn.Size = New System.Drawing.Size(180, 65)
        Me.NewBtn.TabIndex = 2
        Me.NewBtn.Text = "New"
        Me.NewBtn.UseVisualStyleBackColor = True
        '
        'ExitBtn
        '
        Me.ExitBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitBtn.Location = New System.Drawing.Point(151, 297)
        Me.ExitBtn.Name = "ExitBtn"
        Me.ExitBtn.Size = New System.Drawing.Size(116, 52)
        Me.ExitBtn.TabIndex = 3
        Me.ExitBtn.Text = "Exit"
        Me.ExitBtn.UseVisualStyleBackColor = True
        '
        'MenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 395)
        Me.Controls.Add(Me.ExitBtn)
        Me.Controls.Add(Me.NewBtn)
        Me.Controls.Add(Me.LoadBtn)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MenuForm"
        Me.Text = "Main Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents LoadBtn As Button
    Friend WithEvents NewBtn As Button
    Friend WithEvents ExitBtn As Button
End Class
