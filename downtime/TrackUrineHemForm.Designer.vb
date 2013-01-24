<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrackUrineHemForm
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
        Me.ORDERNUMBER = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.oldtrackingcomment = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.OLDTRACKTAG = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.OLDTRKLOCATN = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.OLDTECH = New System.Windows.Forms.TextBox
        Me.SUBMITTRACK = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.trackcomment = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tracktagbox = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Techidbox = New System.Windows.Forms.TextBox
        Me.trklocatn = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order Number"
        '
        'ORDERNUMBER
        '
        Me.ORDERNUMBER.Enabled = False
        Me.ORDERNUMBER.Location = New System.Drawing.Point(39, 51)
        Me.ORDERNUMBER.MaxLength = 10
        Me.ORDERNUMBER.Name = "ORDERNUMBER"
        Me.ORDERNUMBER.Size = New System.Drawing.Size(126, 20)
        Me.ORDERNUMBER.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Old Tracking Comment"
        '
        'oldtrackingcomment
        '
        Me.oldtrackingcomment.Enabled = False
        Me.oldtrackingcomment.Location = New System.Drawing.Point(39, 173)
        Me.oldtrackingcomment.Name = "oldtrackingcomment"
        Me.oldtrackingcomment.Size = New System.Drawing.Size(204, 20)
        Me.oldtrackingcomment.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 236)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "OLD TRACKING TAG"
        '
        'OLDTRACKTAG
        '
        Me.OLDTRACKTAG.Enabled = False
        Me.OLDTRACKTAG.Location = New System.Drawing.Point(39, 252)
        Me.OLDTRACKTAG.Name = "OLDTRACKTAG"
        Me.OLDTRACKTAG.Size = New System.Drawing.Size(204, 20)
        Me.OLDTRACKTAG.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(42, 304)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "OLD TRACKING LOCATION"
        '
        'OLDTRKLOCATN
        '
        Me.OLDTRKLOCATN.Enabled = False
        Me.OLDTRKLOCATN.Location = New System.Drawing.Point(39, 320)
        Me.OLDTRKLOCATN.Name = "OLDTRKLOCATN"
        Me.OLDTRKLOCATN.Size = New System.Drawing.Size(147, 20)
        Me.OLDTRKLOCATN.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 401)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "OLD TECH ID"
        '
        'OLDTECH
        '
        Me.OLDTECH.Enabled = False
        Me.OLDTECH.Location = New System.Drawing.Point(39, 418)
        Me.OLDTECH.Name = "OLDTECH"
        Me.OLDTECH.Size = New System.Drawing.Size(112, 20)
        Me.OLDTECH.TabIndex = 9
        '
        'SUBMITTRACK
        '
        Me.SUBMITTRACK.Location = New System.Drawing.Point(486, 104)
        Me.SUBMITTRACK.Name = "SUBMITTRACK"
        Me.SUBMITTRACK.Size = New System.Drawing.Size(123, 23)
        Me.SUBMITTRACK.TabIndex = 11
        Me.SUBMITTRACK.Text = "SUBMIT TRACKING"
        Me.SUBMITTRACK.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(460, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "NEW TRACKING COMMENT"
        '
        'trackcomment
        '
        Me.trackcomment.Enabled = False
        Me.trackcomment.Location = New System.Drawing.Point(463, 172)
        Me.trackcomment.Name = "trackcomment"
        Me.trackcomment.Size = New System.Drawing.Size(271, 20)
        Me.trackcomment.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(463, 235)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "NEW TRACKING TAG"
        '
        'tracktagbox
        '
        Me.tracktagbox.Enabled = False
        Me.tracktagbox.Location = New System.Drawing.Point(463, 251)
        Me.tracktagbox.Name = "tracktagbox"
        Me.tracktagbox.Size = New System.Drawing.Size(113, 20)
        Me.tracktagbox.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(460, 304)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Track Location"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(463, 379)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Tech ID"
        '
        'Techidbox
        '
        Me.Techidbox.Enabled = False
        Me.Techidbox.Location = New System.Drawing.Point(463, 401)
        Me.Techidbox.Name = "Techidbox"
        Me.Techidbox.Size = New System.Drawing.Size(121, 20)
        Me.Techidbox.TabIndex = 19
        '
        'trklocatn
        '
        Me.trklocatn.FormattingEnabled = True
        Me.trklocatn.Items.AddRange(New Object() {"UA->STORE"})
        Me.trklocatn.Location = New System.Drawing.Point(463, 320)
        Me.trklocatn.Name = "trklocatn"
        Me.trklocatn.Size = New System.Drawing.Size(195, 21)
        Me.trklocatn.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(583, 236)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Format (?###)"
        '
        'Trackurinehemfrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 570)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.trklocatn)
        Me.Controls.Add(Me.Techidbox)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tracktagbox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.trackcomment)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.SUBMITTRACK)
        Me.Controls.Add(Me.OLDTECH)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.OLDTRKLOCATN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.OLDTRACKTAG)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.oldtrackingcomment)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ORDERNUMBER)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Trackurinehemfrom"
        Me.Text = "Urine Hem Traking"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ORDERNUMBER As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents oldtrackingcomment As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OLDTRACKTAG As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OLDTRKLOCATN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OLDTECH As System.Windows.Forms.TextBox
    Friend WithEvents SUBMITTRACK As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents trackcomment As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tracktagbox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Techidbox As System.Windows.Forms.TextBox
    Friend WithEvents trklocatn As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
