<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputBoxFormRecover
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
        Me.TextBoxTestFix = New System.Windows.Forms.TextBox
        Me.ButtonInput = New System.Windows.Forms.Button
        Me.LabelTestError = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TextBoxTestFix
        '
        Me.TextBoxTestFix.Location = New System.Drawing.Point(34, 60)
        Me.TextBoxTestFix.Name = "TextBoxTestFix"
        Me.TextBoxTestFix.Size = New System.Drawing.Size(175, 20)
        Me.TextBoxTestFix.TabIndex = 0
        '
        'ButtonInput
        '
        Me.ButtonInput.Location = New System.Drawing.Point(34, 108)
        Me.ButtonInput.Name = "ButtonInput"
        Me.ButtonInput.Size = New System.Drawing.Size(75, 23)
        Me.ButtonInput.TabIndex = 1
        Me.ButtonInput.Text = "ok"
        Me.ButtonInput.UseVisualStyleBackColor = True
        '
        'LabelTestError
        '
        Me.LabelTestError.AutoSize = True
        Me.LabelTestError.Location = New System.Drawing.Point(34, 22)
        Me.LabelTestError.Name = "LabelTestError"
        Me.LabelTestError.Size = New System.Drawing.Size(29, 13)
        Me.LabelTestError.TabIndex = 2
        Me.LabelTestError.Text = "label"
        '
        'InputBoxFormRecover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 143)
        Me.Controls.Add(Me.LabelTestError)
        Me.Controls.Add(Me.ButtonInput)
        Me.Controls.Add(Me.TextBoxTestFix)
        Me.Name = "InputBoxFormRecover"
        Me.Text = "InputBoxForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxTestFix As System.Windows.Forms.TextBox
    Friend WithEvents ButtonInput As System.Windows.Forms.Button
    Friend WithEvents LabelTestError As System.Windows.Forms.Label
End Class
