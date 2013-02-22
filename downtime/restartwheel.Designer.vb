<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RestartWheel
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Buttondelettrack = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBoxNewOrderNumber = New System.Windows.Forms.ComboBox
        Me.ButtonNumberReset = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(35, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Clear All Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Buttondelettrack
        '
        Me.Buttondelettrack.Location = New System.Drawing.Point(41, 54)
        Me.Buttondelettrack.Name = "Buttondelettrack"
        Me.Buttondelettrack.Size = New System.Drawing.Size(112, 23)
        Me.Buttondelettrack.TabIndex = 4
        Me.Buttondelettrack.Text = "Reset Tracking"
        Me.Buttondelettrack.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(73, 37)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxNewOrderNumber)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonNumberReset)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Buttondelettrack)
        Me.SplitContainer1.Size = New System.Drawing.Size(430, 167)
        Me.SplitContainer1.SplitterDistance = 206
        Me.SplitContainer1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select Order#"
        '
        'ComboBoxNewOrderNumber
        '
        Me.ComboBoxNewOrderNumber.FormattingEnabled = True
        Me.ComboBoxNewOrderNumber.Location = New System.Drawing.Point(35, 37)
        Me.ComboBoxNewOrderNumber.Name = "ComboBoxNewOrderNumber"
        Me.ComboBoxNewOrderNumber.Size = New System.Drawing.Size(133, 21)
        Me.ComboBoxNewOrderNumber.TabIndex = 4
        '
        'ButtonNumberReset
        '
        Me.ButtonNumberReset.Location = New System.Drawing.Point(35, 79)
        Me.ButtonNumberReset.Name = "ButtonNumberReset"
        Me.ButtonNumberReset.Size = New System.Drawing.Size(133, 23)
        Me.ButtonNumberReset.TabIndex = 3
        Me.ButtonNumberReset.Text = "Reset Order Number"
        Me.ButtonNumberReset.UseVisualStyleBackColor = True
        '
        'restartwheel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 239)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "restartwheel"
        Me.Text = "RESTARTING NUMBER WHEEL"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Buttondelettrack As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonNumberReset As System.Windows.Forms.Button
    Friend WithEvents ComboBoxNewOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
