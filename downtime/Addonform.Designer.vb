<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Addons
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
        Me.ordernumber = New System.Windows.Forms.TextBox
        Me.firstname = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Buttonpopulate = New System.Windows.Forms.Button
        Me.ButtonWrite = New System.Windows.Forms.Button
        Me.lastname = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.collectiontime = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.receivetime = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBoxWard = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.priority = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.mrn = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.DOB = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.redtest = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.bluetest = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lavhemtest = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.greentest = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lavchemtest = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.graytest = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.urinehem = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.urinechem = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.bloodgas = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.problem = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cal1 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.comment = New System.Windows.Forms.TextBox
        Me.ButtonPrint = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.buttonRead = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.hepp = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.ser = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.sendout = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.colldate = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.ordertechid = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.csfbox = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.fluidbox = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Viralloadbox = New System.Windows.Forms.TextBox
        Me.TextBoxbillingnumber = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.ComboBoxprinter = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'ordernumber
        '
        Me.ordernumber.Location = New System.Drawing.Point(12, 25)
        Me.ordernumber.MaxLength = 8
        Me.ordernumber.Name = "ordernumber"
        Me.ordernumber.Size = New System.Drawing.Size(226, 20)
        Me.ordernumber.TabIndex = 0
        '
        'firstname
        '
        Me.firstname.Location = New System.Drawing.Point(12, 108)
        Me.firstname.Name = "firstname"
        Me.firstname.Size = New System.Drawing.Size(223, 20)
        Me.firstname.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "order #"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "First Name"
        '
        'Buttonpopulate
        '
        Me.Buttonpopulate.BackColor = System.Drawing.SystemColors.Control
        Me.Buttonpopulate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Buttonpopulate.Location = New System.Drawing.Point(751, 148)
        Me.Buttonpopulate.Name = "Buttonpopulate"
        Me.Buttonpopulate.Size = New System.Drawing.Size(72, 25)
        Me.Buttonpopulate.TabIndex = 98
        Me.Buttonpopulate.Text = "fill boxes"
        Me.Buttonpopulate.UseVisualStyleBackColor = True
        Me.Buttonpopulate.Visible = False
        '
        'ButtonWrite
        '
        Me.ButtonWrite.Location = New System.Drawing.Point(725, 347)
        Me.ButtonWrite.Name = "ButtonWrite"
        Me.ButtonWrite.Size = New System.Drawing.Size(206, 23)
        Me.ButtonWrite.TabIndex = 60
        Me.ButtonWrite.Text = "Print"
        Me.ButtonWrite.UseVisualStyleBackColor = True
        '
        'lastname
        '
        Me.lastname.Location = New System.Drawing.Point(12, 64)
        Me.lastname.Name = "lastname"
        Me.lastname.Size = New System.Drawing.Size(226, 20)
        Me.lastname.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "last name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 415)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "collection time"
        '
        'collectiontime
        '
        Me.collectiontime.Location = New System.Drawing.Point(15, 431)
        Me.collectiontime.Name = "collectiontime"
        Me.collectiontime.Size = New System.Drawing.Size(113, 20)
        Me.collectiontime.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(154, 415)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "receive time"
        '
        'receivetime
        '
        Me.receivetime.Location = New System.Drawing.Point(157, 433)
        Me.receivetime.Name = "receivetime"
        Me.receivetime.Size = New System.Drawing.Size(119, 20)
        Me.receivetime.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 363)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "location"
        '
        'ComboBoxWard
        '
        Me.ComboBoxWard.Location = New System.Drawing.Point(15, 379)
        Me.ComboBoxWard.Name = "ComboBoxWard"
        Me.ComboBoxWard.Size = New System.Drawing.Size(108, 20)
        Me.ComboBoxWard.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 316)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "priority"
        '
        'priority
        '
        Me.priority.Location = New System.Drawing.Point(12, 332)
        Me.priority.MaxLength = 1
        Me.priority.Name = "priority"
        Me.priority.Size = New System.Drawing.Size(33, 20)
        Me.priority.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "mrn"
        '
        'mrn
        '
        Me.mrn.Location = New System.Drawing.Point(12, 219)
        Me.mrn.Name = "mrn"
        Me.mrn.Size = New System.Drawing.Size(181, 20)
        Me.mrn.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 150)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "DOB"
        '
        'DOB
        '
        Me.DOB.Location = New System.Drawing.Point(12, 166)
        Me.DOB.MaxLength = 10
        Me.DOB.Name = "DOB"
        Me.DOB.Size = New System.Drawing.Size(129, 20)
        Me.DOB.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 461)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "redtest"
        '
        'redtest
        '
        Me.redtest.Location = New System.Drawing.Point(18, 478)
        Me.redtest.Name = "redtest"
        Me.redtest.Size = New System.Drawing.Size(220, 20)
        Me.redtest.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 518)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "blue test"
        '
        'bluetest
        '
        Me.bluetest.Location = New System.Drawing.Point(15, 534)
        Me.bluetest.Name = "bluetest"
        Me.bluetest.Size = New System.Drawing.Size(223, 20)
        Me.bluetest.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 571)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "lav hem test"
        '
        'lavhemtest
        '
        Me.lavhemtest.Location = New System.Drawing.Point(12, 583)
        Me.lavhemtest.Name = "lavhemtest"
        Me.lavhemtest.Size = New System.Drawing.Size(226, 20)
        Me.lavhemtest.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 616)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "green test"
        '
        'greentest
        '
        Me.greentest.Location = New System.Drawing.Point(12, 632)
        Me.greentest.Name = "greentest"
        Me.greentest.Size = New System.Drawing.Size(193, 20)
        Me.greentest.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 670)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "lav chem test"
        '
        'lavchemtest
        '
        Me.lavchemtest.Location = New System.Drawing.Point(15, 685)
        Me.lavchemtest.Name = "lavchemtest"
        Me.lavchemtest.Size = New System.Drawing.Size(190, 20)
        Me.lavchemtest.TabIndex = 30
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 719)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "gray test"
        '
        'graytest
        '
        Me.graytest.Location = New System.Drawing.Point(12, 736)
        Me.graytest.Name = "graytest"
        Me.graytest.Size = New System.Drawing.Size(275, 20)
        Me.graytest.TabIndex = 32
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(395, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "urine hem"
        '
        'urinehem
        '
        Me.urinehem.Location = New System.Drawing.Point(389, 25)
        Me.urinehem.Name = "urinehem"
        Me.urinehem.Size = New System.Drawing.Size(275, 20)
        Me.urinehem.TabIndex = 34
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(398, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 13)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "urine chem"
        '
        'urinechem
        '
        Me.urinechem.Location = New System.Drawing.Point(389, 71)
        Me.urinechem.Name = "urinechem"
        Me.urinechem.Size = New System.Drawing.Size(275, 20)
        Me.urinechem.TabIndex = 36
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(401, 96)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 13)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "blood gass"
        '
        'bloodgas
        '
        Me.bloodgas.Location = New System.Drawing.Point(389, 113)
        Me.bloodgas.Name = "bloodgas"
        Me.bloodgas.Size = New System.Drawing.Size(275, 20)
        Me.bloodgas.TabIndex = 38
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(376, 579)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 13)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "problem"
        '
        'problem
        '
        Me.problem.Location = New System.Drawing.Point(379, 595)
        Me.problem.Name = "problem"
        Me.problem.Size = New System.Drawing.Size(190, 20)
        Me.problem.TabIndex = 52
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(385, 648)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(23, 13)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "call"
        '
        'cal1
        '
        Me.cal1.Location = New System.Drawing.Point(379, 664)
        Me.cal1.Name = "cal1"
        Me.cal1.Size = New System.Drawing.Size(138, 20)
        Me.cal1.TabIndex = 54
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(376, 712)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(50, 13)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "comment"
        '
        'comment
        '
        Me.comment.Location = New System.Drawing.Point(379, 733)
        Me.comment.Name = "comment"
        Me.comment.Size = New System.Drawing.Size(461, 20)
        Me.comment.TabIndex = 56
        '
        'ButtonPrint
        '
        Me.ButtonPrint.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.ButtonPrint.Location = New System.Drawing.Point(851, 150)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(80, 23)
        Me.ButtonPrint.TabIndex = 105
        Me.ButtonPrint.Text = "Print1"
        Me.ButtonPrint.UseVisualStyleBackColor = True
        Me.ButtonPrint.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(786, 304)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(55, 13)
        Me.Label25.TabIndex = 107
        Me.Label25.Text = "PRINTER"
        '
        'buttonRead
        '
        Me.buttonRead.Location = New System.Drawing.Point(789, 61)
        Me.buttonRead.Name = "buttonRead"
        Me.buttonRead.Size = New System.Drawing.Size(75, 23)
        Me.buttonRead.TabIndex = 108
        Me.buttonRead.Text = "Read"
        Me.buttonRead.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(389, 149)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 13)
        Me.Label22.TabIndex = 109
        Me.Label22.Text = "Hepatitis Test"
        '
        'hepp
        '
        Me.hepp.Location = New System.Drawing.Point(389, 166)
        Me.hepp.Name = "hepp"
        Me.hepp.Size = New System.Drawing.Size(275, 20)
        Me.hepp.TabIndex = 40
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(392, 203)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 13)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Serology Test"
        '
        'ser
        '
        Me.ser.Location = New System.Drawing.Point(389, 220)
        Me.ser.Name = "ser"
        Me.ser.Size = New System.Drawing.Size(275, 20)
        Me.ser.TabIndex = 42
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(393, 261)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(71, 13)
        Me.Label24.TabIndex = 113
        Me.Label24.Text = "Sendout Test"
        '
        'sendout
        '
        Me.sendout.Location = New System.Drawing.Point(389, 277)
        Me.sendout.Name = "sendout"
        Me.sendout.Size = New System.Drawing.Size(275, 20)
        Me.sendout.TabIndex = 44
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(751, 5)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(68, 13)
        Me.Label26.TabIndex = 115
        Me.Label26.Text = "Todays Date"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(754, 24)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 116
        '
        'colldate
        '
        Me.colldate.Location = New System.Drawing.Point(808, 552)
        Me.colldate.Name = "colldate"
        Me.colldate.Size = New System.Drawing.Size(135, 20)
        Me.colldate.TabIndex = 117
        Me.colldate.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(908, 719)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(46, 13)
        Me.Label27.TabIndex = 118
        Me.Label27.Text = "Tech ID"
        '
        'ordertechid
        '
        Me.ordertechid.Enabled = False
        Me.ordertechid.Location = New System.Drawing.Point(870, 736)
        Me.ordertechid.Name = "ordertechid"
        Me.ordertechid.Size = New System.Drawing.Size(113, 20)
        Me.ordertechid.TabIndex = 119
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(389, 316)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(51, 13)
        Me.Label28.TabIndex = 120
        Me.Label28.Text = "CSF Test"
        '
        'csfbox
        '
        Me.csfbox.Location = New System.Drawing.Point(389, 332)
        Me.csfbox.Name = "csfbox"
        Me.csfbox.Size = New System.Drawing.Size(275, 20)
        Me.csfbox.TabIndex = 46
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(389, 373)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 13)
        Me.Label29.TabIndex = 122
        Me.Label29.Text = "Fluid Test"
        '
        'fluidbox
        '
        Me.fluidbox.Location = New System.Drawing.Point(389, 396)
        Me.fluidbox.Name = "fluidbox"
        Me.fluidbox.Size = New System.Drawing.Size(275, 20)
        Me.fluidbox.TabIndex = 48
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(389, 434)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(78, 13)
        Me.Label30.TabIndex = 124
        Me.Label30.Text = "Viral Load Test"
        '
        'Viralloadbox
        '
        Me.Viralloadbox.Location = New System.Drawing.Point(389, 450)
        Me.Viralloadbox.Name = "Viralloadbox"
        Me.Viralloadbox.Size = New System.Drawing.Size(275, 20)
        Me.Viralloadbox.TabIndex = 50
        '
        'TextBoxbillingnumber
        '
        Me.TextBoxbillingnumber.Location = New System.Drawing.Point(12, 276)
        Me.TextBoxbillingnumber.Name = "TextBoxbillingnumber"
        Me.TextBoxbillingnumber.Size = New System.Drawing.Size(181, 20)
        Me.TextBoxbillingnumber.TabIndex = 125
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(12, 257)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(74, 13)
        Me.Label31.TabIndex = 126
        Me.Label31.Text = "Billing Number"
        '
        'ComboBoxprinter
        '
        Me.ComboBoxprinter.FormattingEnabled = True
        Me.ComboBoxprinter.Location = New System.Drawing.Point(768, 320)
        Me.ComboBoxprinter.Name = "ComboBoxprinter"
        Me.ComboBoxprinter.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxprinter.TabIndex = 127
        '
        'Addons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 846)
        Me.Controls.Add(Me.ComboBoxprinter)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TextBoxbillingnumber)
        Me.Controls.Add(Me.Viralloadbox)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.fluidbox)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.csfbox)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.ordertechid)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.colldate)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.sendout)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.ser)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.hepp)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.buttonRead)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.ButtonPrint)
        Me.Controls.Add(Me.comment)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cal1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.problem)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.bloodgas)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.urinechem)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.urinehem)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.graytest)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lavchemtest)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.greentest)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lavhemtest)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.bluetest)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.redtest)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DOB)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.mrn)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.priority)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboBoxWard)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.receivetime)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.collectiontime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lastname)
        Me.Controls.Add(Me.ButtonWrite)
        Me.Controls.Add(Me.Buttonpopulate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.firstname)
        Me.Controls.Add(Me.ordernumber)
        Me.Name = "Addons"
        Me.Text = "Addon"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ordernumber As System.Windows.Forms.TextBox
    Friend WithEvents firstname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonWrite As System.Windows.Forms.Button
    Friend WithEvents lastname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents collectiontime As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents receivetime As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxWard As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents priority As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents mrn As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DOB As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents redtest As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents bluetest As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lavhemtest As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents greentest As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lavchemtest As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents graytest As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents urinehem As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents urinechem As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents bloodgas As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents problem As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cal1 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents comment As System.Windows.Forms.TextBox
    Friend WithEvents ButtonPrint As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Buttonpopulate As System.Windows.Forms.Button
    Friend WithEvents buttonRead As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents hepp As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ser As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents sendout As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents colldate As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ordertechid As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents csfbox As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents fluidbox As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Viralloadbox As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxbillingnumber As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxprinter As System.Windows.Forms.ComboBox

End Class
