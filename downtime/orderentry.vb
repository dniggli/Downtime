Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.IO
Imports ADODB
Imports HL7

Public Class orderentry
    Public Shared NUMBER = ""
    Public Shared LSTNAME = ""
    Public Shared FSTNAME = ""
    Public Shared Tdate As Integer
    Public Shared strNecessary As New System.Text.StringBuilder("")

    Dim mySql = New GetMySQL()

    ''' <summary>
    ''' Starts the Order Thread
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Order()
        Dim myorder = New orderentry
        Application.Run(myorder)

    End Sub

    Private Sub orderentry_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

    End Sub

    Private Sub orderentry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C

                TB.Enabled = False
            End If
            If TypeOf C Is ComboBox Then
                Dim CB As ComboBox = C

                CB.Enabled = False
            End If
        Next
        TextBoxbillingnumber.Enabled = True
        printerlist()
        cliniclist()
        ComboBoxprinter.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxprinter.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBoxWard.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxWard.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub


    Sub printerlist()
        Dim dtble = mySql.FilledTable("select name from pathdirectory.device d join pathdirectory.device_has_group dg on d.Device_ID = dg.Device_ID where Group_ID = '41' order by name")
        For Each dr As DataRow In dtble.Rows
            ComboBoxprinter.Items.Add(dr("name").ToString)
        Next

    End Sub
    Sub cliniclist()
        Dim dtble = mySql.FilledTable("select * from dtdb1.CLINIC")
        For Each dr As DataRow In dtble.Rows
            ComboBoxWard.Items.Add(dr("Clinic_code").ToString)
        Next
    End Sub

    Sub printDTLabel2(ByVal tests As String, ByVal extension As String, ByVal specimentype As String)
        If tests <> String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, tests, extension, specimentype, Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint2(fn2, Me.ComboBoxprinter.Text)
        End If
    End Sub


    'Dave: Give it a password to connect!!!!  in both the readDowntimeTable and writeDowntimeTable subroutines
    Sub printDowntimeLables()
        Dim test As New List(Of String)
        If Me.priority.Text = "S" Then Me.priority.Text = "STAT"

        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint2(fn2, Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint2(fn2, Me.ComboBoxprinter.Text)
        End If
        printDTLabel2(Me.comment.Text, "", "CMT")
        printDTLabel2(Me.redtest.Text, "00", "SST")
        printDTLabel2(Me.bluetest.Text, "23", "BLU")
        printDTLabel2(Me.greentest.Text, "40", "GRN")
        printDTLabel2(Me.lavchemtest.Text, "79", "LAV")
        printDTLabel2(Me.lavhemtest.Text, "18", "LAV")
        printDTLabel2(Me.graytest.Text, "19", "GRY")
        printDTLabel2(Me.urinechem.Text, "27", "URC")
        printDTLabel2(Me.urinehem.Text, "UA", "UAC")
        printDTLabel2(Me.bloodgas.Text, "20", "SYR")
        printDTLabel2(Me.sendout.Text, "1N", "REF")
        printDTLabel2(Me.ser.Text, "41", "SRL")
        printDTLabel2(Me.hepp.Text, "42", "SHP")
        printDTLabel2(Me.csfbox.Text, "26", "CSF")
        printDTLabel2(Me.fluidbox.Text, "38", "FLD")
        printDTLabel2(Me.Viralloadbox.Text, "74", "LAV")
        printDTLabel2(Me.OTHERBOX.Text, "", "OTH")
        printDTLabel2(Me.TextBoxIMMUNO.Text, "2R", "SST")



        'Dim filepath = "lbl.txt"
        'Dim fs As New FileStream(filepath, FileMode.Open, FileAccess.Write, FileShare.Write)

        'Threading.Thread.Sleep(500)
        'Dim writing As New StreamWriter(fs, System.Text.Encoding.UTF8)

        'writing.WriteLine(strNecessary)


        'writing.Close()
        'fs.Close()
        'fs.Dispose()

        PrintLabels.apply(ComboBoxprinter.Text)




    End Sub

    Sub printDTLabel1(ByVal tests As String, ByVal extension As String, ByVal specimentype As String)
        If tests <> String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, tests, extension, specimentype, Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint1(fn2, Me.ComboBoxprinter.Text)
        End If
    End Sub

    Sub printDTLabel(ByVal tests As String, ByVal extension As String, ByVal specimentype As String)
        If tests <> String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, tests, extension, specimentype, Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint(fn2, Me.ComboBoxprinter.Text)
        End If
    End Sub

    Sub printDowntimeLablesR()
        Dim test As New List(Of String)
        If Me.priority.Text = "S" Then Me.priority.Text = "STAT"

        If Not Me.firstname.Text = String.Empty Then

            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint2(fn2, Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then

            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint2(fn2, Me.ComboBoxprinter.Text)
        End If

        printDTLabel1(Me.comment.Text, "", "CMT")

        printDTLabel(Me.redtest.Text, "00", "SST")
        printDTLabel(Me.bluetest.Text, "23", "BLU")
        printDTLabel(Me.greentest.Text, "40", "GRN")
        printDTLabel(Me.lavchemtest.Text, "79", "LAV")
        printDTLabel(Me.lavhemtest.Text, "18", "LAV")
        printDTLabel(Me.graytest.Text, "19", "GRY")
        printDTLabel(Me.urinechem.Text, "27", "URC")
        printDTLabel(Me.urinehem.Text, "UA", "UAC")
        printDTLabel(Me.bloodgas.Text, "20", "SYR")
        printDTLabel(Me.sendout.Text, "05", "REF")
        printDTLabel(Me.ser.Text, "41", "SRL")
        printDTLabel(Me.hepp.Text, "42", "SHP")
        printDTLabel(Me.csfbox.Text, "26", "CSF")
        printDTLabel(Me.fluidbox.Text, "38", "FLD")
        printDTLabel(Me.Viralloadbox.Text, "74", "LAV")
        printDTLabel(Me.OTHERBOX.Text, "", "OTH")
        printDTLabel(Me.TextBoxIMMUNO.Text, "2R", "SST")

        PrintLabels.apply(ComboBoxprinter.Text)

    End Sub

    'http://www.vbmysql.com/articles/vbnet-mysql-tutorial/the-vbnet-mysql-tutorial-part-4
    Sub writeDowntimeTable()

        Dim alphabet = "abcdefghijklmnopqrstuvwxyz"
        Dim ran As New Random
        Dim length As Integer = ran.Next(0, 20) ' get a random length

        Dim ranletter = alphabet.Substring(ran.Next(0, 25), 1)

        Dim fn = firstname.Text
        Dim ordernumber1 = ordernumber.Text
        Dim lastname1 = lastname.Text
        Dim collectiontime1 = collectiontime.Text
        Dim receivetime1 = receivetime.Text
        Dim location1 = ComboBoxWard.Text
        Dim priority1 = priority.Text
        Dim mrn1 = mrn.Text
        Dim dob1 = DOB.Text
        Dim rt = redtest.Text
        Dim bt = bluetest.Text
        Dim lht = lavhemtest.Text
        Dim gt = greentest.Text
        Dim lct = lavchemtest.Text
        Dim grt = graytest.Text
        Dim uh = urinehem.Text
        Dim uc = urinechem.Text
        Dim bg = bloodgas.Text
        Dim prob = problem.Text
        Dim ordcmt = comment.Text
        Dim cal = cal1.Text
        Dim hep = hepp.Text
        Dim serr = ser.Text
        Dim senot = sendout.Text

        Dim techids = ordertechid.Text
        Dim csf = csfbox.Text
        Dim fluid = fluidbox.Text
        Dim viral = Viralloadbox.Text
        Dim other = OTHERBOX.Text
        Dim BILLING = TextBoxbillingnumber.Text
        Dim IMMUNO = TextBoxIMMUNO.Text


        colldate.Text = DateTimePicker1.Text
        Dim colld = colldate.Text

        If Not mrn.Text.ToString Like "X*" Then
            While mrn1.ToString.Length < 12
                mrn1 = "0" & mrn1
            End While
        End If

        Dim p = New MySqlParameter("?CollectionTime", collectiontime1)
        mySql.ExecuteNonQuery("update dtdb1.Table1 set COLLECTIONTIME = ?CollectionTime, RECEIVETIME = '" & receivetime1 & "',LOCATION = '" & location1 & "',PRIORITY = '" & priority1 & "',MRN = '" & mrn1 & "',DOB = '" & dob1 & "',FIRSTNAME = '" & fn & "',REDTEST = '" & rt & "',BLUETEST = '" & bt & "',LAVHEMTEST = '" & lht & "',GREENTEST = '" & gt & "',LAVCHEMTEST = '" & lct & "',GRYTEST = '" & grt & "',URINEHEM = '" & uh & "',URINECHEM = '" & uc & "',BLOODGAS = '" & bg & "',PROBLEM = '" & prob & "',CALLS = '" & cal & "',ORDERCOMMENT = '" & ordcmt & "',LASTNAME = '" & lastname1 & "',SENDOUT = '" & senot & "',SEROLOGY = '" & serr & "' ,HEPPETITAS = '" & hep & "',COLLECTDATE = '" & colld & "',TECHID = '" & techids & "',CSFTEST = '" & csf & "' ,FLUIDTEST = '" & fluid & "',VIRALLOADTEST = '" & viral & "',OTHERTEST = '" & other & "', BILLINGNUMBER = '" & BILLING & "', IMMUNOTEST = '" & IMMUNO & "' WHERE ordernumber = '" & ordernumber1 & "'", p)

        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C

                TB.Enabled = False
            End If
            If TypeOf C Is ComboBox Then
                Dim CB As ComboBox = C

                CB.Enabled = False
            End If
        Next
        ComboBoxprinter.Enabled = True
        ComboBoxoldorder.Enabled = True
        TextBoxbillingnumber.Enabled = True
    End Sub


    Function date2ordernumber(ByVal dates As String)
        Dim ordend As String = dates

        Dim dateend As Match = Regex.Match(ordend.ToString, "([0-9]+)/([0-9]+)/([0-9]+)")
        Dim endmonth As String = dateend.Groups(1).Value
        Dim endday As String = dateend.Groups(2).Value
        Dim endyear As String = dateend.Groups(3).Value
        While endday.ToString.Length < 2
            endday = "0" & endday
        End While



        Dim endmnth As Integer = endyear + -2004
        endmnth = endmnth * 12


        Dim monthend As String = CStr(CInt(endmonth) + CInt(endmnth))

        If monthend > 99 Then
            Dim newmonthstart As String = Microsoft.VisualBasic.Left(monthend, 2)
            Dim newmonthend As String = Microsoft.VisualBasic.Right(monthend, 1)
            newmonthstart = newmonthstart + 55
            monthend = Chr(newmonthstart) + newmonthend
        End If
        Dim monthday As String = monthend + endday
        Return (monthday)

    End Function

    Public Sub checkdatechange()

        Dim COUNT As Integer = 0
        Dim DATES1 As Integer = Date.Now.Day

        If Not DATES1 = Tdate Then
            Dim dtable = mySql.FilledTable("select * from dtdb1.ordernumber")
            For Each rw As DataRow In dtable.Rows
                COUNT = COUNT + 1
            Next
            If Not COUNT = 1 Then
                mySql.ExecuteNonQuery("truncate TABLE dtdb1.ordernumber")
                mySql.ExecuteNonQuery("insert into dtdb1.ordernumber (OrderLast,Ordernumber)values ('1', '7500');")
                getordernumber()
            End If
        Else
            getordernumber()
        End If
    End Sub

    Sub getordernumber()
        Dim n = mySql.FilledTable("insert into dtdb1.ordernumber (OrderLast,Ordernumber) select OrderLast+1, ordernumber+1 from dtdb1.ordernumber ORDER BY OrderLast DESC LIMIT 1;select OrderLast, Ordernumber from dtdb1.ordernumber ORDER BY OrderLast DESC LIMIT 1;")

        Dim q As DataRow = n.Rows(0)
        Dim h = q("Ordernumber").ToString

        Dim neworernumber As String = h
        Dim alphanum As String

        '........//////  un-comment to use alpha-numeric ordernumbers (also un-comment line items 47-50 in Restartwheel) \\\\\\......
        If neworernumber.Length > 4 Then


            Dim ordernums As String = Microsoft.VisualBasic.Right(h, 3)
            Dim letters As String = Microsoft.VisualBasic.Left(h, 2)
            neworernumber = Chr(letters) + ordernums
            'NUMBER = alphanum


            'Dim alphanum As String = date2ordernumber(Date.Now) + h
            'NUMBER = alphanum
            'ordernumber.Text = alphanum
        End If
        alphanum = date2ordernumber(Date.Now) + neworernumber
        ordernumber.Text = alphanum
        NUMBER = alphanum

        mySql.ExecuteNonQuery("insert into dtdb1.Table1(ordernumber)value('" & alphanum & "');")

        LSTNAME = lastname.Text
        FSTNAME = firstname.Text

        writeandprint()


    End Sub

    Public Sub sendHL7(ByVal mrn As String, ByVal firstName As String, ByVal lastName As String, ByVal ordernumberAndExtension As String, ByVal ward As String, ByVal codes As IEnumerable(Of String))
        'set the IP and port to send to
        Dim sendhl = New SendHl7("lis-s22104-9000", 6669)

        'create the HL7 message
        Dim co = New OrderMessage(mrn, firstName, lastName, ordernumberAndExtension, "", ward, Sex.U, codes)
        Dim hl = co.toHl7()

        'send the hl7 message
        sendhl.SendHL7(hl)
    End Sub

    Public Sub ButtonWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWrite.Click
        ButtonClick()
    End Sub
    Sub ButtonClick()
        If redtest.Text = "" Then
        Else
            Dim dict As New Dictionary(Of String, String)
            Dim tests = redtest.Text
            Dim eAS As String() = tests.Split(New Char() {","c})
            For Each newtest As String In eAS
                Dim spacecheck As String = Microsoft.VisualBasic.Left(newtest, 1)
                If spacecheck = " " Then
                    newtest = newtest.Trim(" ")
                End If
                dict.Add(newtest, "Redtest")
                Dim c As String = newtest
            Next



            Dim drs As New Dictionary(Of String, String)

            Dim dt = mySql.FilledTable("select * from dtdb1.DITests;")

            For Each dr As DataRow In dt.Rows
                Dim ditest = dr("TestCode").ToString
                Dim sequence = dr("CodeSequence").ToString
                drs.Add(ditest, sequence)
                Console.WriteLine(ditest)
            Next
            For Each testtype As String In dict.Keys
                testtype.Replace(" ", "")
                Try
                    Dim checkstest As String = drs(testtype)
                Catch
                    If MsgBox("Please Enter Correct SST Test For: '" & testtype & "' " & vbNewLine & "Tests must be seperated with a comma!", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then
                        redtest.Focus()
                    End If


                    Exit Sub
                End Try


            Next

        End If



        If Me.ordernumber.Enabled = True Then Me.ordernumber.Enabled = False
        Try
            Dim locat = String.Empty
            locat = ComboBoxWard.Text
            Dim locat1 As String = Microsoft.VisualBasic.Left(locat, 1)

            If Not (locat1 = "S" Or locat1 = "A") Then
                If MsgBox("Location must start with 'S' for inpatient or 'A' for outpatient", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then
                    ComboBoxWard.Text = ""
                End If
                ComboBoxWard.Focus()
                ' User chose Yes.
                ' Perform some action.

            End If
        Catch msgbox As Exception
        End Try
        If Me.ComboBoxWard.Text = String.Empty Then
            If MsgBox("No Location Enterd", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then
                ComboBoxWard.Focus()
                Exit Sub
            End If
        End If

        Dim a = collectiontime.Text

        Dim d As Match = Regex.Match(a, "([0-9]{2}):([0-9]{2})")
        If Not d.Success Then
            If MsgBox("collection time not in proper format ##:##", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then
                mrn.Focus()
                Exit Sub
                ' User chose Yes.
                ' Perform some action.
            End If
        End If


        Dim E1 = receivetime.Text

        Dim F As Match = Regex.Match(E1, "([0-9]{2}):([0-9]{2})")
        If Not F.Success Then
            If MsgBox("Receive time must be in proper format(##:##)", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then
                mrn.Focus()
                Exit Sub
                ' User chose Yes.
                ' Perform some action.
            End If
        End If

        Dim xact As String = Microsoft.VisualBasic.Left(mrn.Text, 1)
        If Not xact = "X" Then
            If mrn.Text.ToString = String.Empty Then
                If MsgBox("Must enter MRN", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then
                    mrn.Focus()
                    Exit Sub
                    ' User chose Yes.
                    ' Perform some action.
                End If
            End If
        End If

        If Not (TextBoxbillingnumber.Text Like "S000*" Or TextBoxbillingnumber.Text Like "SX*") Then
            If MsgBox("MUST ENTER BILLING # LIKE 'S000##########' OR 'SX#######'", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then
                TextBoxbillingnumber.Focus()
                Exit Sub
                ' User chose Yes.
                ' Perform some action.
            End If
        End If

        If Me.ordernumber.Text = String.Empty Then
            checkdatechange()

        End If

        If Not Me.ordernumber.Text = String.Empty Then writeandprint()

        editorder.Enabled = True
        Buttoneditprevious.Enabled = True
        If Not NUMBER = "" Then
            Dim RECENT As String = NUMBER + "   " + LSTNAME + "," + FSTNAME
            ComboBoxoldorder.Items.Add(RECENT)
        End If
        'sendHL7(Me.mrn.Text,Me.firstname.Text,Me.lastname.Text,Me.ordernumber.Text + Me.sp
    End Sub

    Sub writeandprint()

        writeDowntimeTable()
        If priority.Text = "S" Then printDowntimeLables()
        If priority.Text = "R" Then printDowntimeLablesR()
        If priority.Text = "U" Then printDowntimeLables()

        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C
                'If TB Is Me.ordernumber Then
                'Dim order As Integer = TB.Text
                'order += 1
                'TB.Text = order
                'Continue For
                'End If
                If TB Is Me.ComboBoxprinter Then
                    Dim printer = TB.Text
                    TB.Text = printer
                    Continue For
                End If

                TB.Clear()
            End If
        Next
        ComboBoxoldorder.Text = String.Empty

        Dim STRLENGTH As Integer = strNecessary.Length
        strNecessary.Remove(0, STRLENGTH)
    End Sub

    Sub checklocation()
        Try
            Dim locat = ComboBoxWard.Text
            Dim locat1 As String = Microsoft.VisualBasic.Left(locat, 1)
            If Not locat1 = "S" Or "A" Then
                If MsgBox("Location must start with 'S' for inpatient or 'A' for outpatient", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then ComboBoxWard.Text = ""
                ComboBoxWard.Focus()
                ' User chose Yes.
                ' Perform some action.

            End If
        Catch msgbox As Exception
        End Try
        If Me.ComboBoxWard.Text = String.Empty Then
            If MsgBox("No Location Enterd", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then
                ComboBoxWard.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Sub checkmrn()
        If Me.mrn.Text.Length < 12 Then
            If MsgBox("Must have 12 digits for MRN", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then mrn.Focus()
            ' User chose Yes.
            ' Perform some action.

        End If
    End Sub

    Sub checkfororder()
        Dim n = mySql.FilledTable("select * from dtdb1.Table1 where ordernumber like '" & Me.ordernumber.Text & "' ORDER BY ID DESC LIMIT 1")

        ordernumber.Enabled = False

        Try
            Dim q As DataRow = n.Rows(0)
            If Not q("firstname").ToString = String.Empty Then
                Dim response As MsgBoxResult = MsgBox("Order already exists. Do you wish to edit?", MsgBoxStyle.YesNo, "MsgBox")
                If response = MsgBoxResult.Yes Then readDowntimeTable()
                If response = MsgBoxResult.No Then
                    ordernumber.Clear()
                    Exit Sub

                End If
            End If
        Catch msgbox As Exception
        End Try
        If firstname.Text = String.Empty Then
            ' Display message.
            If MsgBox("Order Does Not exist exists.", MsgBoxStyle.OkOnly, "MsgBox") = MsgBoxResult.Ok Then
                ordernumber.Clear()
                editorder.Enabled = True
                Buttoneditprevious.Enabled = True


            End If
        End If
        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C

                TB.Enabled = True
            End If
            If TypeOf C Is ComboBox Then
                Dim CB As ComboBox = C

                CB.Enabled = True
            End If
        Next

    End Sub

    Sub FINDDEMOGRAPHIC()
        If Not (TextBoxbillingnumber.Text Like "S000*" Or TextBoxbillingnumber.Text Like "SX*") Then
            If MsgBox("MUST ENTER BILLING # LIKE 'S000##########' OR 'SX#######'", MsgBoxStyle.DefaultButton1, "MsgBox") = MsgBoxResult.Ok Then
                TextBoxbillingnumber.Focus()
                Exit Sub
                ' User chose Yes.
                ' Perform some action.
            End If
        End If

        Dim t = mySql.FilledTable("select * from dtdb1.Table1 where billingnumber like '" & Me.TextBoxbillingnumber.Text & "' ORDER BY ID DESC LIMIT 1")


        Try
            Dim r As DataRow = t.Rows(0)


            Dim fristname1 = r("firstname").ToString
            Dim lastname1 = r("lastname").ToString
            Dim mrn1 = r("mrn").ToString

            Dim response As MsgBoxResult = MsgBox("ADD VISIT TO " & vbNewLine & " " & vbNewLine & " " & lastname1 & ", " & fristname1 & "  " & vbNewLine & " MRN: " & mrn1 & "", MsgBoxStyle.YesNo, "MsgBox")
            If response = MsgBoxResult.Yes Then

                firstname.Text = r("firstname").ToString
                lastname.Text = r("lastname").ToString
                mrn.Text = r("mrn").ToString
                ComboBoxWard.Text = r("location").ToString
                DOB.Text = r("dob").ToString


                For Each C As Control In Me.Controls
                    If TypeOf C Is TextBox Then
                        Dim TB As TextBox = C

                        TB.Enabled = True
                    End If
                    If TypeOf C Is ComboBox Then
                        Dim CB As ComboBox = C

                        CB.Enabled = True
                    End If

                Next

                priority.Focus()

                Exit Sub
            End If
            If response = MsgBoxResult.No Then
                Dim response1 = MsgBox("WOULD YOU LIKE TO ADD A NEW PATIENT?", MsgBoxStyle.YesNo, "MsgBox")
                If response1 = MsgBoxResult.Yes Then
                    For Each C As Control In Me.Controls
                        If TypeOf C Is TextBox Then
                            Dim TB As TextBox = C

                            TB.Enabled = True
                        End If
                        If TypeOf C Is ComboBox Then
                            Dim CB As ComboBox = C

                            CB.Enabled = True
                        End If
                    Next
                    lastname.Focus()

                End If
                If response1 = MsgBoxResult.No Then
                    TextBoxbillingnumber.Focus()
                End If
            End If

        Catch

            For Each C As Control In Me.Controls
                If TypeOf C Is TextBox Then
                    Dim TB As TextBox = C

                    TB.Enabled = True
                End If
                If TypeOf C Is ComboBox Then
                    Dim CB As ComboBox = C

                    CB.Enabled = True
                End If
                lastname.Focus()
            Next
        End Try
    End Sub

    Sub readDowntimeTable()
        Dim t = mySql.FilledTable("select * from dtdb1.Table1 where ordernumber like '" & Me.ordernumber.Text & "' ORDER BY ID DESC LIMIT 1")

        Dim r As DataRow = t.Rows(0)
        'Try

        'ordernumber.Text = r("ordernumber").ToString
        firstname.Text = r("firstname").ToString
        lastname.Text = r("lastname").ToString
        mrn.Text = r("mrn").ToString
        collectiontime.Text = r("collectiontime").ToString
        receivetime.Text = r("receivetime").ToString
        priority.Text = r("priority").ToString
        ComboBoxWard.Text = r("location").ToString
        bluetest.Text = r("bluetest").ToString
        redtest.Text = r("redtest").ToString
        greentest.Text = r("greentest").ToString
        urinechem.Text = r("urinechem").ToString
        urinehem.Text = r("urinehem").ToString
        graytest.Text = r("grytest").ToString
        comment.Text = r("ordercomment").ToString
        problem.Text = r("problem").ToString
        lavchemtest.Text = r("lavchemtest").ToString
        lavhemtest.Text = r("lavhemtest").ToString
        bloodgas.Text = r("bloodgas").ToString
        DOB.Text = r("dob").ToString
        cal1.Text = r("calls").ToString
        sendout.Text = r("SENDOUT").ToString
        hepp.Text = r("heppetitas").ToString
        ser.Text = r("serology").ToString
        colldate.Text = r("collectdate").ToString
        csfbox.Text = r("CSFTEST").ToString
        fluidbox.Text = r("FLUIDTEST").ToString
        Viralloadbox.Text = r("VIRALLOADTEST").ToString
        OTHERBOX.Text = r("OTHERTEST").ToString
        TextBoxIMMUNO.Text = r("IMMUNOTEST").ToString
        TextBoxbillingnumber.Text = r("BILLINGNUMBER").ToString
        Application.DoEvents()   'Display the changes immediately (redraw the label text)
        System.Threading.Thread.Sleep(500) 'do it slow enough so we can actually read the text before it changes, pause half a second
        'Catch exitsub As Exception

        'End Try
    End Sub



    Private Sub ButtonRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonpopulate.Click
        Buttonpopulate.Visible = False
        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C
                Dim running = "high"
                Dim runs = "45654125"

                Dim alphabet = "abcdefghijklmnopqrstuvwxyz"
                Dim ran As New Random
                Dim length As Integer = ran.Next(0, 20) ' get a random length
                Dim ranstring = String.Empty
                For x As Integer = 0 To length
                    ranstring &= alphabet.Substring(ran.Next(0, 25), 1)
                Next

                TB.AppendText(ranstring)
                ordernumber.Text = runs
                mrn.Text = runs
                ComboBoxprinter.Text = "C42"
                DOB.Text = "08/28/2003"
                priority.Text = "S"
                DOB.Text = "10"
                cal1.Text = "585-987-7848"
                collectiontime.Text = "20:50"
                receivetime.Text = "20:55"
            End If
        Next

    End Sub

    Private Sub ordernumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ordernumber.KeyPress
        'If Char.IsNumber(e.KeyChar) = False Then
        '    If e.KeyChar = CChar(ChrW(Keys.Back)) Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'End If
    End Sub


    Private Sub ordernumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ordernumber.TextChanged
        If ordernumber.Text.Length = 8 Then
            ordernumber.Enabled = False
            Techid2()
            checkfororder()
        End If
    End Sub

    Sub Techid2()
        ordertechid.Text = main.Username
    End Sub

    Private Sub editorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editorder.Click
        Buttoneditprevious.Enabled = False
        ordernumber.Enabled = True
        buttonRead.Enabled = True
        editorder.Enabled = False
        ordernumber.Focus()

    End Sub



    Private Sub cal1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cal1.TextChanged
        If Me.cal1.Text = "1111999" Then
            Me.ordernumber.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxoldorder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxoldorder.SelectedIndexChanged
        If ComboBoxoldorder.Text.Length > 8 Then
            NUMBER = ""
            FSTNAME = ""
            LSTNAME = ""
            Dim ordnum = ComboBoxoldorder.Text
            Dim ordnum1 As String = Microsoft.VisualBasic.Left(ordnum, 8)
            ordernumber.Text = ordnum1
            editorder.Enabled = False
            ordernumber.Enabled = False

        End If

    End Sub

    Protected Overrides Function ProcessTabKey(ByVal forward As Boolean) As Boolean

        If TextBoxbillingnumber.Focused Then
            Return False
        Else


            Return MyBase.ProcessTabKey(forward)
        End If

    End Function

    Private Sub TextBoxbillingnumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxbillingnumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            FINDDEMOGRAPHIC()
        End If
        If e.KeyCode = Keys.Tab Then
            FINDDEMOGRAPHIC()
        End If
    End Sub

    Private Sub ComboBoxprinter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxprinter.KeyUp
        If e.KeyCode = Keys.Enter Then
            ButtonClick()

        End If
    End Sub




    'Private Sub TextBoxbillingnumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxbillingnumber.LostFocus
    '    If lastname.Enabled = False Then
    '        FINDDEMOGRAPHIC()
    '    Else
    '    End If
    'End Sub


    Private Sub buttonRead_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonRead.Click
        Dim n = "98106501"
        Dim nend = "98107000"
        Do While (n < nend)
            AddOrders(n)
            n = n + 1
        Loop

    End Sub

    Sub AddOrders(ByVal ordernumber As String)


        Dim alphabet = "abcdefghijklmnopqrstuvwxyz"
        Dim ran As New Random
        Dim length As Integer = ran.Next(0, 20) ' get a random length

        Dim ranletter = alphabet.Substring(ran.Next(0, 25), 1)



        Dim fn = firstname.Text
        Dim lastname1 = lastname.Text
        Dim collectiontime1 = collectiontime.Text
        Dim receivetime1 = receivetime.Text
        Dim location1 = ComboBoxWard.Text
        Dim priority1 = priority.Text
        Dim mrn1 = mrn.Text
        Dim dob1 = DOB.Text
        Dim rt = redtest.Text
        Dim bt = bluetest.Text
        Dim lht = lavhemtest.Text
        Dim gt = greentest.Text
        Dim lct = lavchemtest.Text
        Dim grt = graytest.Text
        Dim uh = urinehem.Text
        Dim uc = urinechem.Text
        Dim bg = bloodgas.Text
        Dim prob = problem.Text
        Dim ordcmt = comment.Text
        Dim cal = cal1.Text
        Dim hep = hepp.Text
        Dim serr = ser.Text
        Dim senot = sendout.Text

        Dim techids = ordertechid.Text
        Dim csf = csfbox.Text
        Dim fluid = fluidbox.Text
        Dim viral = Viralloadbox.Text
        Dim other = OTHERBOX.Text
        Dim BILLING = TextBoxbillingnumber.Text
        Dim IMMUNO = TextBoxIMMUNO.Text

        colldate.Text = DateTimePicker1.Text
        Dim colld = colldate.Text

        If Not mrn.Text.ToString Like "X*" Then
            While mrn1.ToString.Length < 12
                mrn1 = "0" & mrn1
            End While
        End If



        mySql.ExecuteNonQuery("insert into dtdb1.Table1 (ordernumber,COLLECTIONTIME,RECEIVETIME,LOCATION,PRIORITY,MRN,DOB,FIRSTNAME,REDTEST,BLUETEST,LAVHEMTEST,GREENTEST,LAVCHEMTEST,GRYTEST,URINEHEM,URINECHEM,BLOODGAS,PROBLEM,CALLS,ORDERCOMMENT,LASTNAME,SENDOUT,SEROLOGY,HEPPETITAS,COLLECTDATE,TECHID,CSFTEST,FLUIDTEST,VIRALLOADTEST, BILLINGNUMBER)VALUES('" _
                           & ordernumber & "', '" & collectiontime1 & "','" & receivetime1 & "','" & location1 & "', '" & priority1 & "', '" & mrn1 & "','" & dob1 & "','" & fn & "', '" & rt & "', '" & bt & "', '" & lht & "','" & gt & "', '" & lct & "', '" & grt & "','" & uh & "','" & uc & "','" & bg & "', '" & prob & "','" & cal & "','" & ordcmt & "','" & lastname1 & "','" & senot & "','" & serr & "', '" & hep & "','" & colld & "','" & techids & "','" & csf & "','" & fluid & "','" & viral & "', '" & BILLING & "')")
    End Sub

End Class

