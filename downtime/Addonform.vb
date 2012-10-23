Imports MySql.Data.MySqlClient
Public Class Addons

    ''' <summary>
    ''' Starts the Order Thread
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub addon()
        Dim myorder As New Addons
        Application.Run(myorder)

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

        Dim printer As String = ComboBoxprinter.Text
        'RawPrinterHelper.SendStringToPrinter(printer, orderentry.strNecessary.ToString)
        Dim NameToIP As Dictionary(Of String, String) = CodeBase2.Labeler.Send_IP_Printer.GetLabelersList_byGroup("/Strong/Specimen Management")
        Dim PrinterDNSName As String = NameToIP(printer.ToUpper).ToString
        If Not PrinterDNSName.Contains(".") Then
            printer = CodeBase2.DNS.NameToIPString(PrinterDNSName)
            CodeBase2.Labeler.Send_IP_Printer.PrintLabel(printer, orderentry.strNecessary.ToString)
        Else
            CodeBase2.Labeler.Send_IP_Printer.PrintLabel(NameToIP(printer.ToUpper), orderentry.strNecessary.ToString)
        End If

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

        Dim printer As String = ComboBoxprinter.Text
        'RawPrinterHelper.SendStringToPrinter(printer, orderentry.strNecessary.ToString)
        Dim NameToIP As Dictionary(Of String, String) = CodeBase2.Labeler.Send_IP_Printer.GetLabelersList_byGroup("/Strong/Specimen Management")
        Dim PrinterDNSName As String = NameToIP(printer.ToUpper).ToString
        If Not PrinterDNSName.Contains(".") Then
            printer = CodeBase2.DNS.NameToIPString(PrinterDNSName)
            CodeBase2.Labeler.Send_IP_Printer.PrintLabel(printer, orderentry.strNecessary.ToString)
        Else
            CodeBase2.Labeler.Send_IP_Printer.PrintLabel(NameToIP(printer.ToUpper), orderentry.strNecessary.ToString)
        End If

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
        Dim billing As String = String.Empty


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
        billing = TextBoxbillingnumber.Text
        receivetime1 &= ":00"





        Dim comm As New MySqlCommand("update dtdb1.Table1 set COLLECTIONTIME = ?CollectionTime, BILLINGNUMBER = '" & billing & "', RECEIVETIME = '" & receivetime1 & "',LOCATION = '" & location1 & "',PRIORITY = '" & priority1 & "',MRN = '" & mrn1 & "',DOB = '" & dob1 & "',FIRSTNAME = '" & fn & "',REDTEST = '" & rt & "',BLUETEST = '" & bt & "',LAVHEMTEST = '" & lht & "',GREENTEST = '" & gt & "',LAVCHEMTEST = '" & lct & "',GRYTEST = '" & grt & "',URINEHEM = '" & uh & "',URINECHEM = '" & uc & "',BLOODGAS = '" & bg & "',PROBLEM = '" & prob & "',CALLS = '" & cal & "',ORDERCOMMENT = '" & ordcmt & "',LASTNAME = '" & lastname1 & "',SENDOUT = '" & senot & "',SEROLOGY = '" & serr & "' ,HEPPETITAS = '" & hep & "',COLLECTDATE = '" & colld & "' ,CSFTEST = '" & csf & "' ,FLUIDTEST = '" & fluid & "',VIRALLOADTEST = '" & viral & "' WHERE ordernumber = '" & ordernumber1 & "'", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))
        '& ordernumber1 & "', '" & collectiontime1 & "','" & receivetime1 & "','" & location1 & "', '" & priority1 & "', '" & mrn1 & "','" & dob1 & "','" & fn & "', '" & rt & "', '" & bt & "', '" & lht & "','" & gt & "', '" & lct & "', '" & grt & "','" & uh & "','" & uc & "','" & bg & "', '" & prob & "','" & cal & "','" & ordcmt & "','" & lastname1 & "','" & senot & "','" & serr & "', '" & hep & "','" & colld & "','" & techids & "','" & csf & "','" & fluid & "','" & viral & "')", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))
        comm.Parameters.AddWithValue("?CollectionTime", collectiontime1)

        comm.Connection.Open()
        comm.ExecuteNonQuery()
        comm.Connection.Close()

    End Sub

    Private Sub ButtonWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWrite.Click
        'Try
        '    Dim printer As String = ComboBoxprinter.Text
        '    RawPrinterHelper.SendStringToPrinter(printer, orderentry.strNecessary.ToString)
        '    'Dim label As String = String.Empty
        '    'Dim NameToIP As Dictionary(Of String, String) = CodeBase2.Labeler.Send_IP_Printer.GetLabelersList_byGroup("/Strong/Specimen Management")
        '    'Dim PrinterDNSName As String = NameToIP(printer.ToUpper).ToString
        '    'If Not PrinterDNSName.Contains(".") Then
        '    '    printer = CodeBase2.DNS.NameToIPString(PrinterDNSName)
        '    '    CodeBase2.Labeler.Send_IP_Printer.PrintLabel(printer, label)
        '    'Else
        '    '    CodeBase2.Labeler.Send_IP_Printer.PrintLabel(NameToIP(printer.ToUpper), label)
        '    'End If





        'Catch
        '    Dim msg As String
        '    Dim title As String
        '    Dim style As MsgBoxStyle
        '    Dim response As MsgBoxResult

        '    msg = "INVALID PRINTER"   ' Define message.
        '    style = MsgBoxStyle.DefaultButton1
        '    title = "MsgBox"   ' Define title.
        '    ' Display message.
        '    response = MsgBox(msg, style, title)
        '    If response = MsgBoxResult.Ok Then
        '        ComboBoxprinter.Focus()
        '        Exit Sub
        '    End If
        'End Try
        If Me.ComboBoxWard.Text = String.Empty Then checklocation()
        If Not Me.ComboBoxWard.Text = String.Empty Then writeandprint()



    End Sub

    Sub writeandprint()

        writeDowntimeTable()
        If priority.Text = "S" Then printDowntimeLables()
        If priority.Text = "R" Then printDowntimeLablesR()
        If priority.Text = "U" Then printDowntimeLables()

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

        Dim STRLENGTH As Integer = orderentry.strNecessary.Length
        orderentry.strNecessary.Remove(0, STRLENGTH)

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
            TextBoxbillingnumber.Text = r("BILLINGNUMBER").ToString
            Application.DoEvents()   'Display the changes immediately (redraw the label text)
            System.Threading.Thread.Sleep(500) 'do it slow enough so we can actually read the text before it changes, pause half a second
        Catch exitsub As Exception

        End Try
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





    'Private Sub ordernumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ordernumber.KeyPress
    '   If Char.IsNumber(e.KeyChar) = False Then
    '      If e.KeyChar = CChar(ChrW(Keys.Back)) Then
    '         e.Handled = False
    '    Else
    '       e.Handled = True
    '  End If
    'End If
    'End Sub


    Private Sub ordernumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ordernumber.TextChanged
        If ordernumber.Text.Length = 8 Then
            readDowntimeTable()
        End If
        If Me.ordernumber.Text = "11119999" Then
            Me.Buttonpopulate.Visible = True
            Me.ButtonWrite.Visible = True
            Me.ButtonPrint.Visible = True
            Me.buttonRead.Visible = True
        End If
    End Sub


    Sub Techid2()

        ordertechid.Text = main.Username

    End Sub


    Private Sub read_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonRead.Click
        readDowntimeTable()
    End Sub

    Private Sub ComboBoxWard_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxWard.TextChanged

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

    End Sub



    Private Sub Addons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        printerlist()
        ComboBoxprinter.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxprinter.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub ComboBoxprinter_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxprinter.KeyUp
        If e.KeyCode = Keys.Enter Then
            ButtonWrite_Click(Me, EventArgs.Empty)
        End If
    End Sub

    Sub printerlist()
        Dim ch As New MySqlDataAdapter("select name from pathdirectory.device d join pathdirectory.device_has_group dg on d.Device_ID = dg.Device_ID where Group_ID = '41' order by name", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim dtble As New DataTable
        ch.Fill(dtble)
        For Each dr As DataRow In dtble.Rows

            ComboBoxprinter.Items.Add(dr("name").ToString)

        Next

    End Sub
End Class

