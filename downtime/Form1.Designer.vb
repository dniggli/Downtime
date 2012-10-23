<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.orderent = New System.Windows.Forms.Button
        Me.archtrack = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.autolab = New System.Windows.Forms.Button
        Me.aliquot = New System.Windows.Forms.Button
        Me.addon = New System.Windows.Forms.Button
        Me.hemtrack = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Buttoncoagtrack = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonDI = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.ButtonMolis = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(249, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Main Menu"
        '
        'orderent
        '
        Me.orderent.Location = New System.Drawing.Point(98, 43)
        Me.orderent.Name = "orderent"
        Me.orderent.Size = New System.Drawing.Size(149, 37)
        Me.orderent.TabIndex = 1
        Me.orderent.Text = "Order Entry"
        Me.orderent.UseVisualStyleBackColor = True
        '
        'archtrack
        '
        Me.archtrack.Location = New System.Drawing.Point(22, 50)
        Me.archtrack.Name = "archtrack"
        Me.archtrack.Size = New System.Drawing.Size(151, 37)
        Me.archtrack.TabIndex = 2
        Me.archtrack.Text = "SMS Archive Tracking"
        Me.archtrack.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"STAT Query", "Last Name Query", "Med Req Query", "Tracking Query", "Coag Query", "Chemistry Query", "Bloodgas Query", "Hematology Query", "Urinalisys Query"})
        Me.ComboBox1.Location = New System.Drawing.Point(379, 30)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(151, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(419, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Select Query"
        '
        'autolab
        '
        Me.autolab.Location = New System.Drawing.Point(98, 107)
        Me.autolab.Name = "autolab"
        Me.autolab.Size = New System.Drawing.Size(149, 37)
        Me.autolab.TabIndex = 6
        Me.autolab.Text = "Autolab Re-Print"
        Me.autolab.UseVisualStyleBackColor = True
        '
        'aliquot
        '
        Me.aliquot.Location = New System.Drawing.Point(282, 107)
        Me.aliquot.Name = "aliquot"
        Me.aliquot.Size = New System.Drawing.Size(149, 37)
        Me.aliquot.TabIndex = 7
        Me.aliquot.Text = "Aliquot Re-Print"
        Me.aliquot.UseVisualStyleBackColor = True
        '
        'addon
        '
        Me.addon.Location = New System.Drawing.Point(282, 43)
        Me.addon.Name = "addon"
        Me.addon.Size = New System.Drawing.Size(149, 37)
        Me.addon.TabIndex = 8
        Me.addon.Text = "Place Addon"
        Me.addon.UseVisualStyleBackColor = True
        '
        'hemtrack
        '
        Me.hemtrack.Location = New System.Drawing.Point(202, 50)
        Me.hemtrack.Name = "hemtrack"
        Me.hemtrack.Size = New System.Drawing.Size(149, 37)
        Me.hemtrack.TabIndex = 9
        Me.hemtrack.Text = "HEM Archive Tracking"
        Me.hemtrack.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(381, 50)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 37)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Urine Hem Tracking"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(109, 93)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(149, 37)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Urine Chem Tracking"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(22, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(109, 37)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Restart Ordernumber / Tracking"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Buttoncoagtrack
        '
        Me.Buttoncoagtrack.Location = New System.Drawing.Point(282, 93)
        Me.Buttoncoagtrack.Name = "Buttoncoagtrack"
        Me.Buttoncoagtrack.Size = New System.Drawing.Size(149, 37)
        Me.Buttoncoagtrack.TabIndex = 13
        Me.Buttoncoagtrack.Text = "COAG Archive Tracking"
        Me.Buttoncoagtrack.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(51, 67)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.addon)
        Me.SplitContainer1.Panel1.Controls.Add(Me.autolab)
        Me.SplitContainer1.Panel1.Controls.Add(Me.aliquot)
        Me.SplitContainer1.Panel1.Controls.Add(Me.orderent)
        Me.SplitContainer1.Panel1.Margin = New System.Windows.Forms.Padding(3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Buttoncoagtrack)
        Me.SplitContainer1.Panel2.Controls.Add(Me.hemtrack)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.archtrack)
        Me.SplitContainer1.Panel2.Margin = New System.Windows.Forms.Padding(3)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.SplitContainer1.Size = New System.Drawing.Size(563, 320)
        Me.SplitContainer1.SplitterDistance = 160
        Me.SplitContainer1.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(162, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(209, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Order Entry / Label Printing"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(238, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Archiving"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.ButtonMolis)
        Me.Panel1.Controls.Add(Me.ButtonDI)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Location = New System.Drawing.Point(51, 393)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(563, 106)
        Me.Panel1.TabIndex = 15
        '
        'ButtonDI
        '
        Me.ButtonDI.Location = New System.Drawing.Point(165, 12)
        Me.ButtonDI.Name = "ButtonDI"
        Me.ButtonDI.Size = New System.Drawing.Size(108, 36)
        Me.ButtonDI.TabIndex = 14
        Me.ButtonDI.Text = "DI Entry"
        Me.ButtonDI.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(22, 56)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(109, 37)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "Downtime Recovery"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ButtonMolis
        '
        Me.ButtonMolis.Location = New System.Drawing.Point(164, 55)
        Me.ButtonMolis.Name = "ButtonMolis"
        Me.ButtonMolis.Size = New System.Drawing.Size(109, 37)
        Me.ButtonMolis.TabIndex = 15
        Me.ButtonMolis.Text = "Molis Entry"
        Me.ButtonMolis.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 523)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Main Menu"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents orderent As System.Windows.Forms.Button
    Friend WithEvents archtrack As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents autolab As System.Windows.Forms.Button
    Friend WithEvents aliquot As System.Windows.Forms.Button
    Friend WithEvents addon As System.Windows.Forms.Button
    Friend WithEvents hemtrack As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Buttoncoagtrack As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ButtonDI As System.Windows.Forms.Button
    Friend WithEvents ButtonMolis As System.Windows.Forms.Button
End Class
