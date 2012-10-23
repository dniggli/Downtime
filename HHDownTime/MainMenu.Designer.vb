<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Me.ButtonHH = New System.Windows.Forms.Button
        Me.ButtonMic = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ButtonHH
        '
        Me.ButtonHH.Location = New System.Drawing.Point(68, 57)
        Me.ButtonHH.Name = "ButtonHH"
        Me.ButtonHH.Size = New System.Drawing.Size(139, 42)
        Me.ButtonHH.TabIndex = 0
        Me.ButtonHH.Text = "Highland Module"
        Me.ButtonHH.UseVisualStyleBackColor = True
        '
        'ButtonMic
        '
        Me.ButtonMic.Location = New System.Drawing.Point(68, 150)
        Me.ButtonMic.Name = "ButtonMic"
        Me.ButtonMic.Size = New System.Drawing.Size(139, 42)
        Me.ButtonMic.TabIndex = 1
        Me.ButtonMic.Text = "Micro Module"
        Me.ButtonMic.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(109, 225)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 270)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonMic)
        Me.Controls.Add(Me.ButtonHH)
        Me.Name = "MainMenu"
        Me.Text = "MainMenu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonHH As System.Windows.Forms.Button
    Friend WithEvents ButtonMic As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
