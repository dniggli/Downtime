Imports MySql.Data.MySqlClient
Imports CodeBase2.MySql.URMC
Imports downtimeC
Imports HL7

Public Class AutolabAliquotForm
    Public Shared ALIQUOTSTR As New System.Text.StringBuilder("")


    'prints empgraphic labels for stats only!!
    Sub printdemographiclabels()


        Dim test As New List(Of String)
        If Me.priority.Text = "S" Then Me.priority.Text = "STAT"

        'test.Add("ld")
        'test.Add("glu")
        'test.Add("phos")

        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            fn2.LabelPrint2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            fn2.LabelPrint2(Me.ComboBoxprinter.Text)
        End If

        Dim printer As String = ComboBoxprinter.Text
        'RawPrinterHelper.SendStringToPrinter(printer, orderentry.strNecessary.ToString)
        Dim NameToIP As Dictionary(Of String, String) = Send_IP_Printer.GetLabelersListOfIPs_byGroup("/Strong/Specimen Management")
        Dim PrinterDNSName As String = NameToIP(printer.ToUpper).ToString
        If Not PrinterDNSName.Contains(".") Then
            printer = CodeBase2.DNS.NameToIPString(PrinterDNSName)
            Send_IP_Printer.PrintLabel(printer, GlobalMutableState.strNecessary.ToString)
        Else
            Send_IP_Printer.PrintLabel(NameToIP(printer.ToUpper), GlobalMutableState.strNecessary.ToString)
        End If

    End Sub
    'prints demographic labels for routines
    Sub printdemographiclabelsr()
        Dim test As New List(Of String)

        'test.Add("ld")
        'test.Add("glu")
        'test.Add("phos")

        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            fn2.LabelPrint2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            fn2.LabelPrint2(Me.ComboBoxprinter.Text)
        End If

        PrintLabels.apply(ComboBoxprinter.Text)


    End Sub
    'Dave: Give it a password to connect!!!!  in both the readDowntimeTable and writeDowntimeTable subroutines
    Sub printDowntimeLables1()
        Dim test As New List(Of String)
        If Me.priority.Text = "S" Then Me.priority.Text = "STAT"

        'test.Add("ld")
        'test.Add("glu")
        'test.Add("phos")

        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            fn2.LabelPrint2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            fn2.LabelPrint2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.comment.Text = String.Empty Then
            Dim ordcmt1 As New LabelData(Me.ordernumber.Text, Me.comment.Text, "", "CMT", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            ordcmt1.LabelPrint1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.redtest.Text = String.Empty Then
            Dim rt1 As New LabelData(Me.ordernumber.Text, Me.redtest.Text, "00", "SST", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            rt1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.bluetest.Text = String.Empty Then
            Dim bt1 As New LabelData(Me.ordernumber.Text, Me.bluetest.Text, "23", "BLU", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            bt1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.greentest.Text = String.Empty Then
            Dim gt1 As New LabelData(Me.ordernumber.Text, Me.greentest.Text, "40", "GRN", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            gt1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.lavchemtest.Text = String.Empty Then
            Dim lct1 As New LabelData(Me.ordernumber.Text, Me.lavchemtest.Text, "79", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            lct1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.lavhemtest.Text = String.Empty Then
            Dim lht1 As New LabelData(Me.ordernumber.Text, Me.lavhemtest.Text, "18", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            lht1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.graytest.Text = String.Empty Then
            Dim gtr1 As New LabelData(Me.ordernumber.Text, Me.graytest.Text, "19", "GRY", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            gtr1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.urinechem.Text = String.Empty Then
            Dim uc1 As New LabelData(Me.ordernumber.Text, Me.urinechem.Text, "27", "URC", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            uc1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.urinehem.Text = String.Empty Then
            Dim uh1 As New LabelData(Me.ordernumber.Text, Me.urinehem.Text, "UA", "UAC", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            uh1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.bloodgas.Text = String.Empty Then
            Dim bg1 As New LabelData(Me.ordernumber.Text, Me.bloodgas.Text, "20", "SYR", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            bg1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.sendout.Text = String.Empty Then
            Dim sendot As New LabelData(Me.ordernumber.Text, Me.sendout.Text, "05", "REF", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            sendot.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.ser.Text = String.Empty Then
            Dim sero As New LabelData(Me.ordernumber.Text, Me.ser.Text, "41", "SRL", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            sero.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.hepp.Text = String.Empty Then
            Dim heppe As New LabelData(Me.ordernumber.Text, Me.hepp.Text, "42", "SHP", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            heppe.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.csfbox.Text = String.Empty Then
            Dim csf1 As New LabelData(Me.ordernumber.Text, Me.csfbox.Text, "26", "CSF", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            csf1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.fluidbox.Text = String.Empty Then
            Dim fluid1 As New LabelData(Me.ordernumber.Text, Me.fluidbox.Text, "38", "FLD", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            fluid1.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.Viralloadbox.Text = String.Empty Then
            Dim vrl As New LabelData(Me.ordernumber.Text, Me.Viralloadbox.Text, "74", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            vrl.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.OTHERBOX.Text = String.Empty Then
            Dim OTHER As New LabelData(Me.ordernumber.Text, Me.OTHERBOX.Text, "", "OTH", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            OTHER.LabelPrintal1(Me.ComboBoxprinter.Text)
        End If

        PrintLabels.apply(ComboBoxprinter.Text)



    End Sub

    Sub printDowntimeLablesR1()
        Dim test As New List(Of String)
        If Me.priority.Text = "S" Then Me.priority.Text = "STAT"

        'test.Add("ld")
        'test.Add("glu")
        'test.Add("phos")

        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            fn2.LabelPrint2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then
            Dim fn2 As New LabelData(Me.ordernumber.Text, Me.collectiontime.Text, "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text, "Collected", Me.DateTimePicker1.Text)
            fn2.LabelPrint2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.comment.Text = String.Empty Then
            Dim ordcmt1 As New LabelData(Me.ordernumber.Text, Me.comment.Text, "", "CMT", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            ordcmt1.LabelPrint1(Me.ComboBoxprinter.Text)
        End If
        If Not Me.redtest.Text = String.Empty Then
            Dim rt1 As New LabelData(Me.ordernumber.Text, Me.redtest.Text, "00", "SST", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            rt1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.bluetest.Text = String.Empty Then
            Dim bt1 As New LabelData(Me.ordernumber.Text, Me.bluetest.Text, "23", "BLU", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            bt1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.greentest.Text = String.Empty Then
            Dim gt1 As New LabelData(Me.ordernumber.Text, Me.greentest.Text, "40", "GRN", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            gt1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.lavchemtest.Text = String.Empty Then
            Dim lct1 As New LabelData(Me.ordernumber.Text, Me.lavchemtest.Text, "79", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            lct1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.lavhemtest.Text = String.Empty Then
            Dim lht1 As New LabelData(Me.ordernumber.Text, Me.lavhemtest.Text, "18", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            lht1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.graytest.Text = String.Empty Then
            Dim gtr1 As New LabelData(Me.ordernumber.Text, Me.graytest.Text, "19", "GRY", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            gtr1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.urinechem.Text = String.Empty Then
            Dim uc1 As New LabelData(Me.ordernumber.Text, Me.urinechem.Text, "27", "URC", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            uc1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.urinehem.Text = String.Empty Then
            Dim uh1 As New LabelData(Me.ordernumber.Text, Me.urinehem.Text, "UA", "UAC", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            uh1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.bloodgas.Text = String.Empty Then
            Dim bg1 As New LabelData(Me.ordernumber.Text, Me.bloodgas.Text, "20", "SYR", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            bg1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.sendout.Text = String.Empty Then
            Dim sendot As New LabelData(Me.ordernumber.Text, Me.sendout.Text, "05", "REF", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            sendot.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.ser.Text = String.Empty Then
            Dim sero As New LabelData(Me.ordernumber.Text, Me.ser.Text, "41", "SRL", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            sero.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.hepp.Text = String.Empty Then
            Dim heppe As New LabelData(Me.ordernumber.Text, Me.hepp.Text, "42", "SHP", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            heppe.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.csfbox.Text = String.Empty Then
            Dim csf1 As New LabelData(Me.ordernumber.Text, Me.csfbox.Text, "26", "CSF", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            csf1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.fluidbox.Text = String.Empty Then
            Dim fluid1 As New LabelData(Me.ordernumber.Text, Me.fluidbox.Text, "38", "FLD", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            fluid1.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.Viralloadbox.Text = String.Empty Then
            Dim vrl As New LabelData(Me.ordernumber.Text, Me.Viralloadbox.Text, "74", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            vrl.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        If Not Me.OTHERBOX.Text = String.Empty Then
            Dim OTHER As New LabelData(Me.ordernumber.Text, Me.OTHERBOX.Text, "", "OTH", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.ComboBoxWard.Text)
            OTHER.LabelPrintal2(Me.ComboBoxprinter.Text)
        End If
        PrintLabels.apply(ComboBoxprinter.Text)


    End Sub


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
        csf = csfbox.Text
        fluid = fluidbox.Text
        receivetime1 &= ":00"





        Dim comm As New MySqlCommand("insert into dtdb1.Table1 (ordernumber,COLLECTIONTIME,RECEIVETIME,LOCATION,PRIORITY,MRN,DOB,FIRSTNAME,REDTEST,BLUETEST,LAVHEMTEST,GREENTEST,LAVCHEMTEST,GRYTEST,URINEHEM,URINECHEM,BLOODGAS,PROBLEM,CALLS,ORDERCOMMENT,LASTNAME,SENDOUT,SEROLOGY,HEPPETITAS,COLLECTDATE,TECHID,CSFTEST,FLUIDTEST,VIRALLOADTEST)VALUES('" _
                           & ordernumber1 & "', '" & collectiontime1 & "','" & receivetime1 & "','" & location1 & "', '" & priority1 & "', '" & mrn1 & "','" & dob1 & "','" & fn & "', '" & rt & "', '" & bt & "', '" & lht & "','" & gt & "', '" & lct & "', '" & grt & "','" & uh & "','" & uc & "','" & bg & "', '" & prob & "','" & cal & "','" & ordcmt & "','" & lastname1 & "','" & senot & "','" & serr & "', '" & hep & "','" & colld & "','" & techids & "','" & csf & "','" & fluid & "','" & viral & "')", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))


        comm.Connection.Open()
        comm.ExecuteNonQuery()
        comm.Connection.Close()

    End Sub

    Private Sub ButtonWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWrite.Click



        If Me.ComboBoxWard.Text = String.Empty Then checklocation()
        If Not Me.ComboBoxWard.Text = String.Empty Then writeandprint()



    End Sub

    Sub writeandprint()

        'writeDowntimeTable()
        If priority.Text = "S" Then printDowntimeLables1()
        If priority.Text = "R" Then printDowntimeLablesR1()
        If priority.Text = "U" Then printDowntimeLables1()

        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C
                If TB Is Me.ComboBoxprinter Then
                    Dim printer As String = TB.Text
                    TB.Text = printer
                    Continue For
                End If
                TB.Clear()
            End If
        Next
        ordernumber.Focus()
        Dim STRLENGTH As Integer = GlobalMutableState.strNecessary.Length
        GlobalMutableState.strNecessary.Remove(0, STRLENGTH)

    End Sub

    Sub checklocation()
        If Me.ComboBoxWard.Text = String.Empty Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "No Location Enterd"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then ComboBoxWard.Text = ""
            ComboBoxWard.Focus()
            ' User chose Yes.
            ' Perform some action.

        End If

    End Sub


    Sub readDowntimeTable()
        Dim da As New MySqlDataAdapter("select * from dtdb1.Table1 where ordernumber like '" & Me.ordernumber.Text & "' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim t As New DataTable

        da.Fill(t)



        Try

            Dim r As DataRow = t.Rows(0)


            ordernumber.Text = r("ordernumber").ToString
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
            Application.DoEvents()   'Display the changes immediately (redraw the label text)
            System.Threading.Thread.Sleep(500) 'do it slow enough so we can actually read the text before it changes, pause half a second
        Catch exitsub As Exception

        End Try

    End Sub

    Public Function checkfororder() As Boolean

        Dim tf As Boolean = True
        Dim ch As New MySqlDataAdapter("select * from dtdb1.Table1 where ordernumber like '" & Me.ordernumber.Text & "' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim n As New DataTable


        ch.Fill(n)

        Try
            Dim q As DataRow = n.Rows(0)
            If Not q("firstname").ToString = String.Empty Then
                readDowntimeTable()

                Exit Function

            End If

        Catch msgbox As Exception
        End Try
        If firstname.Text = String.Empty Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "Order Does Not exist ."   ' Define message.
            style = MsgBoxStyle.OkOnly
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
                'ordernumber.Focus()
                checkfororder = True


            End If
        End If


    End Function

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
                ComboBoxprinter.Text = "s56"
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





    'Private Sub ordernumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ordernumber.KeyUp
    '    If Char.IsNumber(e.KeyChar) = False Then
    '        If e.KeyChar = CChar(ChrW(Keys.Back)) Then
    '            e.Handled = False
    '        Else
    '            e.Handled = True
    '        End If
    '    End If
    'End Sub
    Private Sub ComboBoxprinter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxprinter.KeyUp

        If e.KeyCode = Keys.Enter Then
            ButtonWrite_Click(Me, EventArgs.Empty)
        End If

    End Sub

    Private Sub ordernumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ordernumber.KeyUp



        If e.KeyCode = Keys.Enter Then

            checkfororder()
        End If
    End Sub

    'Private Sub ordernumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ordernumber.TextChanged
    '    If ordernumber.Text.Length = 8 Then checkfororder()
    '    If Me.ordernumber.Text = "11119999" Then
    '        Me.Buttonpopulate.Visible = True
    '        Me.ButtonWrite.Visible = True
    '        Me.ButtonPrint.Visible = True
    '        Me.buttonRead.Visible = True
    '    End If
    'End Sub


    'Sub Techid2()

    '    ordertechid.Text = main.Username

    'End Sub


    Private Sub read_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonRead.Click
        readDowntimeTable()
    End Sub

    Private Sub ComboBoxWard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxWard.TextChanged

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

    End Sub

    Private Sub printdem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printdem.Click

        If ComboBoxprinter.Text = String.Empty Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "INVALID PRINTER"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
                ComboBoxprinter.Focus()
                Exit Sub
            End If
        Else

            If checkfororder() = False Then
                If priority.Text = "S" Then printdemographiclabels()
                If priority.Text = "R" Then printdemographiclabelsr()
                If priority.Text = "U" Then printdemographiclabels()
            Else
                Exit Sub
            End If
        End If



        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C
                If TB Is Me.ComboBoxprinter Then
                    Dim printers As String = TB.Text
                    TB.Text = printers
                    Continue For
                End If
                TB.Clear()
            End If
        Next
        ordernumber.Focus()
    End Sub



    Private Sub aliquotform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        printerlist()
        ComboBoxprinter.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxprinter.AutoCompleteSource = AutoCompleteSource.ListItems

        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C
                If TB Is Me.ComboBoxprinter Then
                    Dim printers As String = TB.Text
                    TB.Text = printers
                    Continue For
                End If
                TB.Enabled = False
            End If
        Next

    End Sub
    Sub printerlist()
        Dim ch As New MySqlDataAdapter("select name from pathdirectory.device d join pathdirectory.device_has_group dg on d.Device_ID = dg.Device_ID where Group_ID = '41' order by name", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim dtble As New DataTable
        ch.Fill(dtble)
        For Each dr As DataRow In dtble.Rows

            ComboBoxprinter.Items.Add(dr("name").ToString)

        Next

    End Sub


    Private Sub ComboBoxprinter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxprinter.SelectedIndexChanged
        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C
                If TB Is Me.ComboBoxprinter Then
                    Dim printers As String = TB.Text
                    TB.Text = printers
                    Continue For
                End If
                TB.Enabled = True
                ordernumber.Focus()
            End If
        Next
    End Sub




End Class

