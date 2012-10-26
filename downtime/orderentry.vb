Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.IO
Imports ADODB

Public Class orderentry
    Public Shared NUMBER As String = ""
    Public Shared LSTNAME As String = ""
    Public Shared FSTNAME As String = ""
    Public Shared Tdate As Integer
    Public Shared strNecessary As New System.Text.StringBuilder("")
    ''' <summary>
    ''' Starts the Order Thread
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Order()
        Dim myorder As New orderentry
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
        Dim ch As New MySqlDataAdapter("select name from pathdirectory.device d join pathdirectory.device_has_group dg on d.Device_ID = dg.Device_ID where Group_ID = '41' order by name", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim dtble As New DataTable
        ch.Fill(dtble)
        For Each dr As DataRow In dtble.Rows

            ComboBoxprinter.Items.Add(dr("name").ToString)

        Next

    End Sub
    Sub cliniclist()
        Dim ch As New MySqlDataAdapter("select * from dtdb1.CLINIC", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim dtble As New DataTable
        ch.Fill(dtble)
        For Each dr As DataRow In dtble.Rows

            ComboBoxWard.Items.Add(dr("Clinic_code").ToString)

        Next

    End Sub

    'Dave: Give it a password to connect!!!!  in both the readDowntimeTable and writeDowntimeTable subroutines
    Sub printDowntimeLables()
        Dim test As New List(Of String)
        If Me.priority.Text = "S" Then Me.priority.Text = "STAT"


        'test.Add("ld")
        'test.Add("glu")
        'test.Add("phos")

        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint2(fn2, Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint2(fn2, Me.ComboBoxprinter.Text)
        End If
        If Not Me.comment.Text = String.Empty Then
            Dim ordcmt1 As New LabelData(Me.ordernumber.Text, Me.comment.Text, "", "CMT", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint1(ordcmt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.redtest.Text = String.Empty Then

            Dim rt1 As New LabelData(Me.ordernumber.Text, Me.redtest.Text, "00", "SST", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(rt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.bluetest.Text = String.Empty Then

            Dim bt1 As New LabelData(Me.ordernumber.Text, Me.bluetest.Text, "23", "BLU", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(bt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.greentest.Text = String.Empty Then

            Dim gt1 As New LabelData(Me.ordernumber.Text, Me.greentest.Text, "40", "GRN", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(gt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.lavchemtest.Text = String.Empty Then

            Dim lct1 As New LabelData(Me.ordernumber.Text, Me.lavchemtest.Text, "79", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(lct1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.lavhemtest.Text = String.Empty Then

            Dim lht1 As New LabelData(Me.ordernumber.Text, Me.lavhemtest.Text, "18", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(lht1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.graytest.Text = String.Empty Then

            Dim gtr1 As New LabelData(Me.ordernumber.Text, Me.graytest.Text, "19", "GRY", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(gtr1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.urinechem.Text = String.Empty Then

            Dim uc1 As New LabelData(Me.ordernumber.Text, Me.urinechem.Text, "27", "URC", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(uc1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.urinehem.Text = String.Empty Then

            Dim uh1 As New LabelData(Me.ordernumber.Text, Me.urinehem.Text, "UA", "UAC", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(uh1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.bloodgas.Text = String.Empty Then

            Dim bg1 As New LabelData(Me.ordernumber.Text, Me.bloodgas.Text, "20", "SYR", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(bg1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.sendout.Text = String.Empty Then

            Dim sendot As New LabelData(Me.ordernumber.Text, Me.sendout.Text, "1N", "REF", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(sendot, Me.ComboBoxprinter.Text)
        End If
        If Not Me.ser.Text = String.Empty Then

            Dim sero As New LabelData(Me.ordernumber.Text, Me.ser.Text, "41", "SRL", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(sero, Me.ComboBoxprinter.Text)
        End If
        If Not Me.hepp.Text = String.Empty Then

            Dim heppe As New LabelData(Me.ordernumber.Text, Me.hepp.Text, "42", "SHP", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(heppe, Me.ComboBoxprinter.Text)
        End If
        If Not Me.csfbox.Text = String.Empty Then

            Dim csf1 As New LabelData(Me.ordernumber.Text, Me.csfbox.Text, "26", "CSF", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(csf1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.fluidbox.Text = String.Empty Then

            Dim fluid1 As New LabelData(Me.ordernumber.Text, Me.fluidbox.Text, "38", "FLD", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(fluid1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.Viralloadbox.Text = String.Empty Then

            Dim vrl As New LabelData(Me.ordernumber.Text, Me.Viralloadbox.Text, "74", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(vrl, Me.ComboBoxprinter.Text)
        End If
        If Not Me.OTHERBOX.Text = String.Empty Then

            Dim other1 As New LabelData(Me.ordernumber.Text, Me.OTHERBOX.Text, "", "OTH", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(other1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.TextBoxIMMUNO.Text = String.Empty Then

            Dim rt1 As New LabelData(Me.ordernumber.Text, Me.TextBoxIMMUNO.Text, "2R", "SST", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(rt1, Me.ComboBoxprinter.Text)
        End If


        'Dim filepath As String = "lbl.txt"
        'Dim fs As New FileStream(filepath, FileMode.Open, FileAccess.Write, FileShare.Write)

        'Threading.Thread.Sleep(500)
        'Dim writing As New StreamWriter(fs, System.Text.Encoding.UTF8)

        'writing.WriteLine(strNecessary)


        'writing.Close()
        'fs.Close()
        'fs.Dispose()

   PrintLabels.apply(ComboBoxprinter.Text)




    End Sub

    Sub printDowntimeLablesR()
        Dim test As New List(Of String)
        If Me.priority.Text = "S" Then Me.priority.Text = "STAT"

        'test.Add("ld")
        'test.Add("glu")
        'test.Add("phos")

        If Not Me.firstname.Text = String.Empty Then

            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint2(fn2, Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then

            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            LabelPrint2(fn2, Me.ComboBoxprinter.Text)
        End If
        If Not Me.comment.Text = String.Empty Then

            Dim ordcmt1 As New LabelData(Me.ordernumber.Text, Me.comment.Text, "", "CMT", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint1(ordcmt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.redtest.Text = String.Empty Then

            Dim rt1 As New LabelData(Me.ordernumber.Text, Me.redtest.Text, "00", "SST", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(rt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.bluetest.Text = String.Empty Then

            Dim bt1 As New LabelData(Me.ordernumber.Text, Me.bluetest.Text, "23", "BLU", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(bt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.greentest.Text = String.Empty Then

            Dim gt1 As New LabelData(Me.ordernumber.Text, Me.greentest.Text, "40", "GRN", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(gt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.lavchemtest.Text = String.Empty Then

            Dim lct1 As New LabelData(Me.ordernumber.Text, Me.lavchemtest.Text, "79", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(lct1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.lavhemtest.Text = String.Empty Then

            Dim lht1 As New LabelData(Me.ordernumber.Text, Me.lavhemtest.Text, "18", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(lht1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.graytest.Text = String.Empty Then

            Dim gtr1 As New LabelData(Me.ordernumber.Text, Me.graytest.Text, "19", "GRY", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(gtr1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.urinechem.Text = String.Empty Then

            Dim uc1 As New LabelData(Me.ordernumber.Text, Me.urinechem.Text, "27", "URC", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(uc1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.urinehem.Text = String.Empty Then

            Dim uh1 As New LabelData(Me.ordernumber.Text, Me.urinehem.Text, "UA", "UAC", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(uh1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.bloodgas.Text = String.Empty Then

            Dim bg1 As New LabelData(Me.ordernumber.Text, Me.bloodgas.Text, "20", "SYR", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(bg1, Me.ComboBoxprinter.Text)
        End If



        If Not Me.sendout.Text = String.Empty Then

            Dim sendot As New LabelData(Me.ordernumber.Text, Me.sendout.Text, "05", "REF", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(sendot, Me.ComboBoxprinter.Text)
        End If
        If Not Me.ser.Text = String.Empty Then

            Dim sero As New LabelData(Me.ordernumber.Text, Me.ser.Text, "41", "SRL", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(sero, Me.ComboBoxprinter.Text)
        End If
        If Not Me.hepp.Text = String.Empty Then

            Dim heppe As New LabelData(Me.ordernumber.Text, Me.hepp.Text, "42", "SHP", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(heppe, Me.ComboBoxprinter.Text)
        End If
        If Not Me.csfbox.Text = String.Empty Then

            Dim csf1 As New LabelData(Me.ordernumber.Text, Me.csfbox.Text, "26", "CSF", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(csf1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.fluidbox.Text = String.Empty Then

            Dim fluid1 As New LabelData(Me.ordernumber.Text, Me.fluidbox.Text, "38", "FLD", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(fluid1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.Viralloadbox.Text = String.Empty Then

            Dim vrl As New LabelData(Me.ordernumber.Text, Me.Viralloadbox.Text, "74", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(vrl, Me.ComboBoxprinter.Text)
        End If
        If Not Me.OTHERBOX.Text = String.Empty Then

            Dim other1 As New LabelData(Me.ordernumber.Text, Me.OTHERBOX.Text, "", "OTH", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(other1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.TextBoxIMMUNO.Text = String.Empty Then

            Dim rt1 As New LabelData(Me.ordernumber.Text, Me.TextBoxIMMUNO.Text, "2R", "SST", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            LabelPrint(rt1, Me.ComboBoxprinter.Text)
        End If





  PrintLabels.apply(ComboBoxprinter.Text)

    End Sub

    'http://www.vbmysql.com/articles/vbnet-mysql-tutorial/the-vbnet-mysql-tutorial-part-4
    Sub writeDowntimeTable()

        Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz"
        Dim ran As New Random
        Dim length As Integer = ran.Next(0, 20) ' get a random length

        Dim ranletter As String = alphabet.Substring(ran.Next(0, 25), 1)



        Dim fn As String = String.Empty
        Dim ordernumber1 As String = String.Empty
        Dim lastname1 As String = String.Empty
        Dim collectiontime1 As String = String.Empty
        Dim receivetime1 As String = String.Empty
        Dim location1 As String = String.Empty
        Dim priority1 As String = String.Empty
        Dim mrn1 As String = String.Empty
        Dim dob1 As String = String.Empty
        Dim rt As String = String.Empty
        Dim bt As String = String.Empty
        Dim lht As String = String.Empty
        Dim gt As String = String.Empty
        Dim lct As String = String.Empty
        Dim grt As String = String.Empty
        Dim uh As String = String.Empty
        Dim uc As String = String.Empty
        Dim bg As String = String.Empty
        Dim prob As String = String.Empty
        Dim ordcmt As String = String.Empty
        Dim cal As String = String.Empty
        Dim hep As String = String.Empty
        Dim serr As String = String.Empty
        Dim senot As String = String.Empty
        Dim colld As String = String.Empty
        Dim techids As String = String.Empty
        Dim csf As String = String.Empty
        Dim fluid As String = String.Empty
        Dim viral As String = String.Empty
        Dim other As String = String.Empty
        Dim BILLING As String = String.Empty
        Dim IMMUNO As String = String.Empty

        lastname1 = lastname.Text
        ordernumber1 = ordernumber.Text
        fn = firstname.Text
        collectiontime1 = collectiontime.Text
        receivetime1 = receivetime.Text
        location1 = ComboBoxWard.Text
        priority1 = priority.Text
        mrn1 = mrn.Text
        rt = redtest.Text
        bt = bluetest.Text
        lht = lavhemtest.Text
        lct = lavchemtest.Text
        gt = greentest.Text
        uh = urinehem.Text
        grt = graytest.Text
        uc = urinechem.Text
        bg = bloodgas.Text
        prob = problem.Text
        cal = cal1.Text
        ordcmt = comment.Text
        hep = hepp.Text
        dob1 = DOB.Text
        senot = sendout.Text
        serr = ser.Text
        colldate.Text = DateTimePicker1.Text
        colld = colldate.Text
        techids = ordertechid.Text
        viral = Viralloadbox.Text
        other = OTHERBOX.Text
        csf = csfbox.Text
        fluid = fluidbox.Text
        BILLING = TextBoxbillingnumber.Text
        IMMUNO = TextBoxIMMUNO.Text

        If Not mrn.Text.ToString Like "X*" Then
            While mrn1.ToString.Length < 12
                mrn1 = "0" & mrn1
            End While
        End If



        'Dim para As New MySqlParameter
        'para.ParameterName = "?CollectionTime"
        Dim comm As New MySqlCommand("update dtdb1.Table1 set COLLECTIONTIME = ?CollectionTime, RECEIVETIME = '" & receivetime1 & "',LOCATION = '" & location1 & "',PRIORITY = '" & priority1 & "',MRN = '" & mrn1 & "',DOB = '" & dob1 & "',FIRSTNAME = '" & fn & "',REDTEST = '" & rt & "',BLUETEST = '" & bt & "',LAVHEMTEST = '" & lht & "',GREENTEST = '" & gt & "',LAVCHEMTEST = '" & lct & "',GRYTEST = '" & grt & "',URINEHEM = '" & uh & "',URINECHEM = '" & uc & "',BLOODGAS = '" & bg & "',PROBLEM = '" & prob & "',CALLS = '" & cal & "',ORDERCOMMENT = '" & ordcmt & "',LASTNAME = '" & lastname1 & "',SENDOUT = '" & senot & "',SEROLOGY = '" & serr & "' ,HEPPETITAS = '" & hep & "',COLLECTDATE = '" & colld & "',TECHID = '" & techids & "',CSFTEST = '" & csf & "' ,FLUIDTEST = '" & fluid & "',VIRALLOADTEST = '" & viral & "',OTHERTEST = '" & other & "', BILLINGNUMBER = '" & BILLING & "', IMMUNOTEST = '" & IMMUNO & "' WHERE ordernumber = '" & ordernumber1 & "'", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))
        comm.Parameters.AddWithValue("?CollectionTime", collectiontime1)
        'comm.Parameters.Add(para)
        '& ordernumber1 & "', '" & collectiontime1 & "','" & receivetime1 & "','" & location1 & "', '" & priority1 & "', '" & mrn1 & "','" & dob1 & "','" & fn & "', '" & rt & "', '" & bt & "', '" & lht & "','" & gt & "', '" & lct & "', '" & grt & "','" & uh & "','" & uc & "','" & bg & "', '" & prob & "','" & cal & "','" & ordcmt & "','" & lastname1 & "','" & senot & "','" & serr & "', '" & hep & "','" & colld & "','" & techids & "','" & csf & "','" & fluid & "','" & viral & "')", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))


        comm.Connection.Open()
        comm.ExecuteNonQuery()
        comm.Connection.Close()

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

            Dim CHECK As New MySqlDataAdapter("select * from dtdb1.ordernumber", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
            Dim datatable As New DataTable
            CHECK.Fill(datatable)
            For Each rw As DataRow In datatable.Rows
                COUNT = COUNT + 1

            Next
            If Not COUNT = 1 Then
                Dim comm As New MySqlCommand("truncate TABLE dtdb1.ordernumber", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))

                comm.Connection.Open()
                comm.ExecuteNonQuery()
                comm.Connection.Close()

                Dim ch As New MySqlCommand("insert into dtdb1.ordernumber (OrderLast,Ordernumber)values ('1', '7500');", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))
                ch.Connection.Open()
                ch.ExecuteNonQuery()
                ch.Connection.Close()

                getordernumber()
            End If
            'End If
            'Dim ch As New MySqlDataAdapter("select * from dtdb1.ordernumber ORDER BY Key DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
            'Dim COUNT As Integer = 0
            'While COUNT < 5000
        Else
            getordernumber()
        End If
    End Sub

    Sub getordernumber()
        'Dim DEFAULTDATE As String = "1111-11-11"

        Dim ch As New MySqlDataAdapter("insert into dtdb1.ordernumber (OrderLast,Ordernumber) select OrderLast+1, ordernumber+1 from dtdb1.ordernumber ORDER BY OrderLast DESC LIMIT 1;select OrderLast, Ordernumber from dtdb1.ordernumber ORDER BY OrderLast DESC LIMIT 1;", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")

        Dim n As New DataTable

        ch.Fill(n)

        Dim q As DataRow = n.Rows(0)

        Dim h As String = q("Ordernumber").ToString


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

        Dim comm As New MySqlCommand("insert into dtdb1.Table1(ordernumber)value('" & alphanum & "');", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))

        comm.Connection.Open()
        comm.ExecuteNonQuery()
        comm.Connection.Close()
        'COUNT = COUNT + 1
        'Console.WriteLine(NUMBER)
        'End While


        'ordernumber.Text = date2ordernumber(Date.Now) + neworernumber
        LSTNAME = lastname.Text
        FSTNAME = firstname.Text

        writeandprint()


    End Sub
    Public Sub ButtonWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWrite.Click
        ButtonClick()
    End Sub
    Sub ButtonClick()
        If redtest.Text = "" Then
        Else
            Dim dict As New Dictionary(Of String, String)
            Dim tests As String = redtest.Text
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
            Dim dt As New DataTable
            Dim ditests As New MySqlDataAdapter("select * from dtdb1.DITests;", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
            ditests.Fill(dt)
            For Each dr As DataRow In dt.Rows
                Dim ditest As String = dr("TestCode").ToString
                Dim sequence As String = dr("CodeSequence").ToString
                drs.Add(ditest, sequence)
                Console.WriteLine(ditest)
            Next
            For Each testtype As String In dict.Keys
                testtype.Replace(" ", "")
                Try
                    Dim checkstest As String = drs(testtype)

                Catch
                    Dim msg As String
                    Dim title As String
                    Dim style As MsgBoxStyle
                    Dim response As MsgBoxResult

                    msg = "Please Enter Correct SST Test For: '" & testtype & "' " & vbNewLine & "Tests must be seperated with a comma!" ' Define message.
                    style = MsgBoxStyle.DefaultButton1
                    title = "MsgBox"   ' Define title.
                    ' Display message.
                    response = MsgBox(msg, style, title)
                    If response = MsgBoxResult.Ok Then redtest.Focus()

                    Exit Sub
                End Try


            Next

        End If



        If Me.ordernumber.Enabled = True Then Me.ordernumber.Enabled = False
        Try
            Dim locat As String = String.Empty
            locat = ComboBoxWard.Text
            Dim locat1 As String = Microsoft.VisualBasic.Left(locat, 1)


            If Not (locat1 = "S" Or locat1 = "A") Then
                Dim msg As String
                Dim title As String
                Dim style As MsgBoxStyle
                Dim response As MsgBoxResult

                msg = "Location must start with 'S' for inpatient or 'A' for outpatient"   ' Define message.
                style = MsgBoxStyle.DefaultButton1
                title = "MsgBox"   ' Define title.
                ' Display message.
                response = MsgBox(msg, style, title)
                If response = MsgBoxResult.Ok Then ComboBoxWard.Text = ""
                ComboBoxWard.Focus()
                ' User chose Yes.
                ' Perform some action.

            End If
        Catch msgbox As Exception
        End Try
        If Me.ComboBoxWard.Text = String.Empty Then

            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "No Location Enterd"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            'Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
                ComboBoxWard.Focus()
                Exit Sub
            End If
        End If

        Dim a As String = collectiontime.Text

        Dim d As Match = Regex.Match(a, "([0-9]{2}):([0-9]{2})")
        If Not d.Success Then




            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "collection time not in proper format ##:##"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
                mrn.Focus()
                Exit Sub
                ' User chose Yes.
                ' Perform some action.
            End If
        End If


        Dim E1 As String = receivetime.Text

        Dim F As Match = Regex.Match(E1, "([0-9]{2}):([0-9]{2})")
        If Not F.Success Then




            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "Receive time must be in proper format(##:##)"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
                mrn.Focus()
                Exit Sub
                ' User chose Yes.
                ' Perform some action.
            End If
        End If

        Dim xact As String = Microsoft.VisualBasic.Left(mrn.Text, 1)
        If Not xact = "X" Then
            If mrn.Text.ToString = String.Empty Then
                Dim msg As String
                Dim title As String
                Dim style As MsgBoxStyle
                Dim response As MsgBoxResult

                msg = "Must enter MRN"   ' Define message.
                style = MsgBoxStyle.DefaultButton1
                title = "MsgBox"   ' Define title.
                ' Display message.
                response = MsgBox(msg, style, title)
                If response = MsgBoxResult.Ok Then
                    mrn.Focus()
                    Exit Sub
                    ' User chose Yes.
                    ' Perform some action.
                End If
            End If
        End If

        If Not (TextBoxbillingnumber.Text Like "S000*" Or TextBoxbillingnumber.Text Like "SX*") Then

            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "MUST ENTER BILLING # LIKE 'S000##########' OR 'SX#######'"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
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
                    Dim printer As String = TB.Text
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
            Dim locat As String = ComboBoxWard.Text
            Dim locat1 As String = Microsoft.VisualBasic.Left(locat, 1)
            If Not locat1 = "S" Or "A" Then
                Dim msg As String
                Dim title As String
                Dim style As MsgBoxStyle
                Dim response As MsgBoxResult

                msg = "Location must start with 'S' for inpatient or 'A' for outpatient"   ' Define message.
                style = MsgBoxStyle.DefaultButton1
                title = "MsgBox"   ' Define title.
                ' Display message.
                response = MsgBox(msg, style, title)
                If response = MsgBoxResult.Ok Then ComboBoxWard.Text = ""
                ComboBoxWard.Focus()
                ' User chose Yes.
                ' Perform some action.

            End If
        Catch msgbox As Exception
        End Try
        If Me.ComboBoxWard.Text = String.Empty Then

            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "No Location Enterd"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            'Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
                ComboBoxWard.Focus()
                Exit Sub
            End If
        End If

    End Sub



    Sub checkmrn()
        If Me.mrn.Text.Length < 12 Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "Must have 12 digits for MRN"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then mrn.Focus()
            ' User chose Yes.
            ' Perform some action.

        End If
    End Sub

    Sub checkfororder()
        Dim ch As New MySqlDataAdapter("select * from dtdb1.Table1 where ordernumber like '" & Me.ordernumber.Text & "' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim n As New DataTable
        ordernumber.Enabled = False

        ch.Fill(n)

        Try
            Dim q As DataRow = n.Rows(0)
            If Not q("firstname").ToString = String.Empty Then
                Dim msg As String
                Dim title As String
                Dim style As MsgBoxStyle
                Dim response As MsgBoxResult

                msg = "Order already exists. Do you wish to edit?"   ' Define message.
                style = MsgBoxStyle.YesNo
                title = "MsgBox"   ' Define title.
                ' Display message.
                response = MsgBox(msg, style, title)
                If response = MsgBoxResult.Yes Then readDowntimeTable()
                If response = MsgBoxResult.No Then
                    ordernumber.Clear()
                    Exit Sub

                End If
            End If
        Catch msgbox As Exception
        End Try
        If firstname.Text = String.Empty Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "Order Does Not exist exists."   ' Define message.
            style = MsgBoxStyle.OkOnly
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
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

            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "MUST ENTER BILLING # LIKE 'S000##########' OR 'SX#######'"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
                TextBoxbillingnumber.Focus()
                Exit Sub
                ' User chose Yes.
                ' Perform some action.
            End If
        End If





        Dim da As New MySqlDataAdapter("select * from dtdb1.Table1 where billingnumber like '" & Me.TextBoxbillingnumber.Text & "' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim t As New DataTable

        Try

            da.Fill(t)
            Dim r As DataRow = t.Rows(0)


            Dim fristname1 As String = r("firstname").ToString
            Dim lastname1 As String = r("lastname").ToString
            Dim mrn1 As String = r("mrn").ToString

            Dim msg As String

            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "ADD VISIT TO " & vbNewLine & " " & vbNewLine & " " & lastname1 & ", " & fristname1 & "  " & vbNewLine & " MRN: " & mrn1 & ""  ' Define message.

            style = MsgBoxStyle.YesNo
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
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
                Dim msg1 As String

                Dim title1 As String
                Dim style1 As MsgBoxStyle
                Dim response1 As MsgBoxResult

                msg1 = "WOULD YOU LIKE TO ADD A NEW PATIENT?"  ' Define message.

                style1 = MsgBoxStyle.YesNo
                title1 = "MsgBox"   ' Define title.
                ' Display message.
                response1 = MsgBox(msg1, style1, title1)
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
        Dim da As New MySqlDataAdapter("select * from dtdb1.Table1 where ordernumber like '" & Me.ordernumber.Text & "' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim t As New DataTable



        da.Fill(t)
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
                Dim running As String = "high"
                Dim runs As String = "45654125"

                Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz"
                Dim ran As New Random
                Dim length As Integer = ran.Next(0, 20) ' get a random length
                Dim ranstring As String = String.Empty
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




    Private Sub collectiontime1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles collectiontime.TextChanged, receivetime.TextChanged



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




    Private Sub ComboBoxWard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

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
            Dim ordnum As String = ComboBoxoldorder.Text
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
        Dim n As String = "98106501"
        Dim nend As String = "98107000"
        Do While (n < nend)
            AddOrders(n)
            n = n + 1
        Loop

    End Sub

    Sub AddOrders(ByVal ordernumber As String)


        Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz"
        Dim ran As New Random
        Dim length As Integer = ran.Next(0, 20) ' get a random length

        Dim ranletter As String = alphabet.Substring(ran.Next(0, 25), 1)



        Dim fn As String = String.Empty
        Dim lastname1 As String = String.Empty
        Dim collectiontime1 As String = String.Empty
        Dim receivetime1 As String = String.Empty
        Dim location1 As String = String.Empty
        Dim priority1 As String = String.Empty
        Dim mrn1 As String = String.Empty
        Dim dob1 As String = String.Empty
        Dim rt As String = String.Empty
        Dim bt As String = String.Empty
        Dim lht As String = String.Empty
        Dim gt As String = String.Empty
        Dim lct As String = String.Empty
        Dim grt As String = String.Empty
        Dim uh As String = String.Empty
        Dim uc As String = String.Empty
        Dim bg As String = String.Empty
        Dim prob As String = String.Empty
        Dim ordcmt As String = String.Empty
        Dim cal As String = String.Empty
        Dim hep As String = String.Empty
        Dim serr As String = String.Empty
        Dim senot As String = String.Empty
        Dim colld As String = String.Empty
        Dim techids As String = String.Empty
        Dim csf As String = String.Empty
        Dim fluid As String = String.Empty
        Dim viral As String = String.Empty
        Dim other As String = String.Empty
        Dim BILLING As String = String.Empty
        Dim IMMUNO As String = String.Empty

        lastname1 = lastname.Text
        fn = firstname.Text
        collectiontime1 = collectiontime.Text
        receivetime1 = receivetime.Text
        location1 = ComboBoxWard.Text
        priority1 = priority.Text
        mrn1 = mrn.Text
        rt = redtest.Text
        bt = bluetest.Text
        lht = lavhemtest.Text
        lct = lavchemtest.Text
        gt = greentest.Text
        uh = urinehem.Text
        grt = graytest.Text
        uc = urinechem.Text
        bg = bloodgas.Text
        prob = problem.Text
        cal = cal1.Text
        ordcmt = comment.Text
        hep = hepp.Text
        dob1 = DOB.Text
        senot = sendout.Text
        serr = ser.Text
        colldate.Text = DateTimePicker1.Text
        colld = colldate.Text
        techids = ordertechid.Text
        viral = Viralloadbox.Text
        other = OTHERBOX.Text
        csf = csfbox.Text
        fluid = fluidbox.Text
        BILLING = TextBoxbillingnumber.Text
        IMMUNO = TextBoxIMMUNO.Text

        If Not mrn.Text.ToString Like "X*" Then
            While mrn1.ToString.Length < 12
                mrn1 = "0" & mrn1
            End While
        End If




        Dim comm As New MySqlCommand("insert into dtdb1.Table1 (ordernumber,COLLECTIONTIME,RECEIVETIME,LOCATION,PRIORITY,MRN,DOB,FIRSTNAME,REDTEST,BLUETEST,LAVHEMTEST,GREENTEST,LAVCHEMTEST,GRYTEST,URINEHEM,URINECHEM,BLOODGAS,PROBLEM,CALLS,ORDERCOMMENT,LASTNAME,SENDOUT,SEROLOGY,HEPPETITAS,COLLECTDATE,TECHID,CSFTEST,FLUIDTEST,VIRALLOADTEST, BILLINGNUMBER)VALUES('" _
                           & ordernumber & "', '" & collectiontime1 & "','" & receivetime1 & "','" & location1 & "', '" & priority1 & "', '" & mrn1 & "','" & dob1 & "','" & fn & "', '" & rt & "', '" & bt & "', '" & lht & "','" & gt & "', '" & lct & "', '" & grt & "','" & uh & "','" & uc & "','" & bg & "', '" & prob & "','" & cal & "','" & ordcmt & "','" & lastname1 & "','" & senot & "','" & serr & "', '" & hep & "','" & colld & "','" & techids & "','" & csf & "','" & fluid & "','" & viral & "', '" & BILLING & "')", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))


        comm.Connection.Open()
        comm.ExecuteNonQuery()
        comm.Connection.Close()
    End Sub



    Private Sub ComboBoxprinter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxprinter.SelectedIndexChanged

    End Sub
End Class

