Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Imports System.Data

Public Class Form1

    Public Shared NUMBER As String
    Public Shared strNecessary As String
    'Public Shared strNecessary As New System.Text.StringBuilder("")

    'Dave: Give it a password to connect!!!!  in both the readDowntimeTable and writeDowntimeTable subroutines

    Public Shared Sub HH()
        Dim myHH As New Form1
        Application.Run(myHH)

    End Sub

    Sub printDowntimeLablesR()
        Dim test As New List(Of String)
        If Me.priority.Text = "S" Then Me.priority.Text = "STAT"
        'test.Add("ld")
        'test.Add("glu")
        'test.Add("phos")
        Dim count As Integer

        For count = 0 To 4
            Dim fn1 As New LabelData(Me.TextBoxordernumber.Text, "", "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(fn1, Me.ComboBoxprinter.Text)
        Next




        'If Not Me.firstname.Text = String.Empty Then
        '    Dim fn1 As New LabelData(Me.ordernumber.Text, "", "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
        '    LabelPrint(fn1, Me.ComboBoxprinter.Text)
        'End If
        'If Not Me.firstname.Text = String.Empty Then
        '    Dim fn1 As New LabelData(Me.ordernumber.Text, "", "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
        '    LabelPrint(fn1, Me.ComboBoxprinter.Text)
        'End If

        'If Not Me.firstname.Text = String.Empty Then
        '    Dim fn1 As New LabelData(Me.ordernumber.Text, "", "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
        '    LabelPrint(fn1, Me.ComboBoxprinter.Text)
        'End If
        'If Not Me.firstname.Text = String.Empty Then
        '    Dim fn1 As New LabelData(Me.ordernumber.Text, "", "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
        '    LabelPrint(fn1, Me.ComboBoxprinter.Text)

        'End If
        If Not Me.comment.Text = String.Empty Then
            Dim ordcmt1 As New LabelData1(Me.TextBoxordernumber.Text, Me.comment.Text, "", "CMT", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint1(ordcmt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.hrdtest.Text = String.Empty Then
            Dim rt1 As New LabelData(Me.TextBoxordernumber.Text, Me.hrdtest.Text, "96", "HRD", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(rt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.bluetest.Text = String.Empty Then
            Dim bt1 As New LabelData(Me.TextBoxordernumber.Text, Me.bluetest.Text, "95", "BLU", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(bt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.greentest.Text = String.Empty Then
            Dim gt1 As New LabelData(Me.TextBoxordernumber.Text, Me.greentest.Text, "40", "GRN", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(gt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.fluid.Text = String.Empty Then
            Dim lct1 As New LabelData(Me.TextBoxordernumber.Text, Me.fluid.Text, "38", "FLD", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(lct1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.lavhemtest.Text = String.Empty Then
            Dim lht1 As New LabelData(Me.TextBoxordernumber.Text, Me.lavhemtest.Text, "94", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(lht1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.graytest.Text = String.Empty Then
            Dim gtr1 As New LabelData(Me.TextBoxordernumber.Text, Me.graytest.Text, "19", "GRY", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(gtr1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.urinechem.Text = String.Empty Then
            Dim uc1 As New LabelData(Me.TextBoxordernumber.Text, Me.urinechem.Text, "27", "URC", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(uc1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.hsttest.Text = String.Empty Then
            Dim uh1 As New LabelData(Me.TextBoxordernumber.Text, Me.hsttest.Text, "60", "HST", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(uh1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.bloodgas.Text = String.Empty Then
            Dim bg1 As New LabelData(Me.TextBoxordernumber.Text, Me.bloodgas.Text, "20", "SYR", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(bg1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.csftest.Text = String.Empty Then
            Dim csf As New LabelData(Me.TextBoxordernumber.Text, Me.csftest.Text, "26", "CSF", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(csf, Me.ComboBoxprinter.Text)
        End If
        If Not Me.sendout.Text = String.Empty Then
            Dim snd As New LabelData(Me.TextBoxordernumber.Text, Me.sendout.Text, "", "SND", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(snd, Me.ComboBoxprinter.Text)
        End If
        If Not Me.OTHERBOX.Text = String.Empty Then
            Dim other1 As New LabelData(Me.TextBoxordernumber.Text, Me.OTHERBOX.Text, "", "OTH", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(other1, Me.ComboBoxprinter.Text)
        End If


        Dim printer As String = ComboBoxprinter.Text
        Console.WriteLine(strNecessary)
        Dim NameToIP As Dictionary(Of String, String) = CodeBase2.Labeler.Send_IP_Printer.GetLabelersList_byGroup("/Highland/Specimen Management")
        Dim NameToIP2 As Dictionary(Of String, String) = CodeBase2.Labeler.Send_IP_Printer.GetLabelersList_byGroup("/Strong/Microbiology")



        For Each kvp As KeyValuePair(Of String, String) In NameToIP2
            NameToIP.Add(kvp.Key, kvp.Value)
        Next




        Dim PrinterDNSName As String = NameToIP(printer.ToUpper).ToString
        If Not PrinterDNSName.Contains(".") Then
            printer = CodeBase2.DNS.NameToIPString(PrinterDNSName)
            CodeBase2.Labeler.Send_IP_Printer.PrintLabel(printer, strNecessary.ToString)
        Else
            CodeBase2.Labeler.Send_IP_Printer.PrintLabel(NameToIP(printer.ToUpper), strNecessary.ToString)
        End If
        'strNecessary.Remove(0, strNecessary.Length)
        strNecessary = ""
    End Sub

    Sub printDowntimeLables()
        Dim test As New List(Of String)
        If Me.priority.Text = "S" Then Me.priority.Text = "STAT"
        'test.Add("ld")
        'test.Add("glu")
        'test.Add("phos")

        If Not Me.firstname.Text = String.Empty Then
            Dim fn1 As New LabelData(Me.TextBoxordernumber.Text, "", "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(fn1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then
            Dim fn1 As New LabelData(Me.TextBoxordernumber.Text, "", "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(fn1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then
            Dim fn1 As New LabelData(Me.TextBoxordernumber.Text, "", "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(fn1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.firstname.Text = String.Empty Then
            Dim fn1 As New LabelData(Me.TextBoxordernumber.Text, "", "", "", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(fn1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.comment.Text = String.Empty Then
            Dim ordcmt1 As New LabelData1(Me.TextBoxordernumber.Text, Me.comment.Text, "", "CMT", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint3(ordcmt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.hrdtest.Text = String.Empty Then
            Dim rt1 As New LabelData(Me.TextBoxordernumber.Text, Me.hrdtest.Text, "96", "HRD", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(rt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.bluetest.Text = String.Empty Then
            Dim bt1 As New LabelData(Me.TextBoxordernumber.Text, Me.bluetest.Text, "95", "BLU", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(bt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.greentest.Text = String.Empty Then
            Dim gt1 As New LabelData(Me.TextBoxordernumber.Text, Me.greentest.Text, "40", "GRN", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(gt1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.fluid.Text = String.Empty Then
            Dim lct1 As New LabelData(Me.TextBoxordernumber.Text, Me.fluid.Text, "38", "FLD", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(lct1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.lavhemtest.Text = String.Empty Then
            Dim lht1 As New LabelData(Me.TextBoxordernumber.Text, Me.lavhemtest.Text, "94", "LAV", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(lht1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.graytest.Text = String.Empty Then
            Dim gtr1 As New LabelData(Me.TextBoxordernumber.Text, Me.graytest.Text, "19", "GRY", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(gtr1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.urinechem.Text = String.Empty Then
            Dim uc1 As New LabelData(Me.TextBoxordernumber.Text, Me.urinechem.Text, "27", "URC", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(uc1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.hsttest.Text = String.Empty Then
            Dim uh1 As New LabelData(Me.TextBoxordernumber.Text, Me.hsttest.Text, "60", "HST", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(uh1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.bloodgas.Text = String.Empty Then
            Dim bg1 As New LabelData(Me.TextBoxordernumber.Text, Me.bloodgas.Text, "20", "SYR", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(bg1, Me.ComboBoxprinter.Text)
        End If
        If Not Me.csftest.Text = String.Empty Then
            Dim csf As New LabelData(Me.TextBoxordernumber.Text, Me.csftest.Text, "26", "CSF", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(csf, Me.ComboBoxprinter.Text)
        End If
        If Not Me.sendout.Text = String.Empty Then
            Dim snd As New LabelData(Me.TextBoxordernumber.Text, Me.sendout.Text, "", "SND", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint2(snd, Me.ComboBoxprinter.Text)
        End If
        If Not Me.OTHERBOX.Text = String.Empty Then
            Dim other1 As New LabelData(Me.TextBoxordernumber.Text, Me.OTHERBOX.Text, "", "OTH", Me.priority.Text, Me.mrn.Text, Me.lastname.Text, Me.firstname.Text, Me.locatin.Text)
            LabelPrint(other1, Me.ComboBoxprinter.Text)
        End If

        Dim printer As String = ComboBoxprinter.Text
        Console.WriteLine(strNecessary)
        Dim NameToIP As Dictionary(Of String, String) = CodeBase2.Labeler.Send_IP_Printer.GetLabelersList_byGroup("/Highland/Specimen Management")
        Dim NameToIP2 As Dictionary(Of String, String) = CodeBase2.Labeler.Send_IP_Printer.GetLabelersList_byGroup("/Strong/Microbiology")



        For Each kvp As KeyValuePair(Of String, String) In NameToIP2
            NameToIP.Add(kvp.Key, kvp.Value)
        Next




        Dim PrinterDNSName As String = NameToIP(printer.ToUpper).ToString
        If Not PrinterDNSName.Contains(".") Then
            printer = CodeBase2.DNS.NameToIPString(PrinterDNSName)
            CodeBase2.Labeler.Send_IP_Printer.PrintLabel(printer, strNecessary.ToString)
        Else
            CodeBase2.Labeler.Send_IP_Printer.PrintLabel(NameToIP(printer.ToUpper), strNecessary.ToString)
        End If
        'strNecessary.Remove(0, strNecessary.Length)
        strNecessary = ""
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
        Dim fld As String = String.Empty
        Dim grt As String = String.Empty
        Dim hst As String = String.Empty
        Dim uc As String = String.Empty
        Dim bg As String = String.Empty
        Dim prob As String = String.Empty
        Dim ordcmt As String = String.Empty
        Dim cal As String = String.Empty
        Dim sndt As String = String.Empty
        Dim csf As String = String.Empty
        Dim lct As String = String.Empty

        lastname1 = lastname.Text
        ordernumber1 = TextBoxordernumber.Text
        fn = firstname.Text
        collectiontime1 = collectiontime.Text
        receivetime1 = receivetime.Text
        location1 = locatin.Text
        priority1 = priority.Text
        mrn1 = mrn.Text
        rt = hrdtest.Text
        bt = bluetest.Text
        lht = lavhemtest.Text
        fld = fluid.Text
        gt = greentest.Text
        hst = hsttest.Text
        grt = graytest.Text
        uc = urinechem.Text
        bg = bloodgas.Text
        prob = problem.Text
        cal = cal1.Text
        ordcmt = comment.Text
        sndt = sendout.Text
        csf = csftest.Text


        dob1 = DOB.Text

        receivetime1 &= ":00"





        Dim comm As New MySqlCommand("insert into Downtime.HHDowntime (ORDERNUMBER,COLLECTIONTIME,RECEIVETIME,LOCATION,PRIORITY,MRN,DOB,FIRSTNAME,LASTNAME,REDTEST,BLUETEST,LAVHEMTEST,GREENTEST,LAVCHEMTEST,GRYTEST,URINECHEM,BLOODGAS,PROBLEM,CALLS,ORDERCOMMENT,SENDOUTTEST,FLUIDTEST,SSTTEST,CSFTEST,OTHER)VALUES('" _
                            & ordernumber1 & "', '" & collectiontime1 & "','" & receivetime1 & "','" & location1 & "', '" & priority1 & "', '" & mrn1 & "','" & dob1 & "','" & fn & "','" & lastname1 & "','" & rt & "', '" & bt & "', '" & lht & "','" & gt & "', '" & lct & "', '" & grt & "','" & uc & "','" & bg & "', '" & prob & "','" & cal & "','" & ordcmt & "','" & sndt & "', '" & fld & "','" & hst & "','" & csf & "','" & OTHERBOX.Text.ToString & "')", New MySqlConnection("server=localhost;uid=dniggli;pwd=vvo084;"))



        comm.Connection.Open()
        comm.ExecuteNonQuery()
        comm.Connection.Close()

    End Sub

    Private Sub ButtonWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWrite.Click
        If Me.locatin.Text = String.Empty Then checklocation()
        If Not Me.locatin.Text = String.Empty Then writeandprint()



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

    Sub writeandprint()

        writeDowntimeTable()
        If priority.Text = "" Then printDowntimeLablesR()
        If priority.Text = "S" Then printDowntimeLables()
        If priority.Text = "R" Then printDowntimeLablesR()

        If priority.Text = "U" Then printDowntimeLables()

        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C
                If TB Is Me.TextBoxordernumber Then

                    Dim order As String = TB.Text
                    ''Dim count As Integer = 0
                    ''While count < 2000



                    'Dim ordernums As String = Microsoft.VisualBasic.Right(order, 4)
                    'Dim monthyear As String = Microsoft.VisualBasic.Left(order, 4)
                    'Dim letters As String = Microsoft.VisualBasic.Left(ordernums, 1)
                    'letters = letters.ToUpper
                    'Dim ordernumber As Integer = Microsoft.VisualBasic.Right(ordernums, 3)
                    'letters = Asc(letters)

                    order = order + 1

                    'Dim DATES1 As DateTime = Date.Now
                    'Dim NEWDATES1 As DateTime = DATES1.AddDays(COUNT)

                    'Dim alphanum As String = date2ordernumber(Date.Now) + Chr(letters) + ordernumber.ToString
                    NUMBER = order
                    'NUMBER = alphanum





                    'Dim ordernums As String = Microsoft.VisualBasic.Right(order, 4)
                    'Dim monthyear As String = Microsoft.VisualBasic.Left(order, 4)
                    'Dim letter As String = Microsoft.VisualBasic.Left(ordernums, 1)
                    'letter = letter.ToUpper
                    'Dim ordernumber As Integer = Microsoft.VisualBasic.Right(ordernums, 3)

                    'letter = Asc(letter) & "000"
                    'ordernumber = ordernumber + 1
                    'ordernumber = CStr(CInt(letter) + CInt(ordernumber))

                    'letter = Chr(Microsoft.VisualBasic.Left(ordernumber, 2))
                    'Dim newordernumber As String = Microsoft.VisualBasic.Right(ordernumber, 3)
                    'newordernumber = newordernumber.PadLeft(3, "0")

                    'order = monthyear & letter & newordernumber
                    'Console.WriteLine(order)
                    'count = count + 1
                    'TB.Text = NUMBER
                    'End While
                    Continue For
                End If
                TB.Clear()
            End If
        Next

        TextBoxordernumber.Text = NUMBER

    End Sub

    Sub checklocation()
        If Me.locatin.Text = String.Empty Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "No Location Enterd"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then locatin.Text = ""
            locatin.Focus()
            ' User chose Yes.
            ' Perform some action.

        End If

    End Sub


    Sub readDowntimeTable()
        Dim da As New MySqlDataAdapter("select * from dtdb1.hhdowntime where ORDERNUMBER like '" & Me.TextBoxordernumber.Text & "' ORDER BY ID DESC LIMIT 1", "server=localhost;uid=dniggli;pwd=vvo084;")
        Dim t As New DataTable

        da.Fill(t)



        Dim r As DataRow = t.Rows(0)


        TextBoxordernumber.Text = r("orderNUMBER").ToString
        firstname.Text = r("firstname").ToString
        lastname.Text = r("lastname").ToString
        mrn.Text = r("mrn").ToString
        collectiontime.Text = r("collectiontime").ToString
        receivetime.Text = r("receivetime").ToString
        priority.Text = r("priority").ToString
        locatin.Text = r("location").ToString
        bluetest.Text = r("bluetest").ToString
        hrdtest.Text = r("redtest").ToString
        greentest.Text = r("greentest").ToString
        urinechem.Text = r("urinechem").ToString
        hsttest.Text = r("SSTTEST").ToString
        graytest.Text = r("grytest").ToString
        comment.Text = r("ordercomment").ToString
        problem.Text = r("problem").ToString
        fluid.Text = r("fluidtest").ToString
        lavhemtest.Text = r("lavhemtest").ToString
        bloodgas.Text = r("bloodgas").ToString
        DOB.Text = r("dob").ToString
        cal1.Text = r("calls").ToString
        sendout.Text = r("sendouttest").ToString
        csftest.Text = r("csftest").ToString
        hrdtest.Text = r("redtest").ToString
        OTHERBOX.Text = r("OTHER").ToString

        Application.DoEvents()   'Display the changes immediately (redraw the label text)
        System.Threading.Thread.Sleep(500) 'do it slow enough so we can actually read the text before it changes, pause half a second

    End Sub

    'Private Sub ButtonRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonpopulate.Click
    '    Buttonpopulate.Visible = False
    '    For Each C As Control In Me.Controls
    '        If TypeOf C Is TextBox Then
    '            Dim TB As TextBox = C
    '            Dim running As String = "high"
    '            Dim runs As String = "45654125"

    '            Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz"
    '            Dim ran As New Random
    '            Dim length As Integer = ran.Next(0, 20) ' get a random length
    '            Dim ranstring As String = String.Empty
    '            For x As Integer = 0 To length
    '                ranstring &= alphabet.Substring(ran.Next(0, 25), 1)
    '            Next

    '            TB.AppendText(ranstring)
    '            ordernumber.Text = runs
    '            mrn.Text = runs
    '            TextBoxLabeler.Text = "s56"
    '            DOB.Text = "08/28/2003"
    '            priority.Text = "S"
    '            DOB.Text = "10"
    '            cal1.Text = "585-987-7848"
    '            collectiontime.Text = "20:50"
    '            receivetime.Text = "20:55"



    '        End If
    '    Next

    'End Sub




    Private Sub collectiontime1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles collectiontime.TextChanged, receivetime.TextChanged



    End Sub





    Private Sub ordernumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxordernumber.KeyPress
        'If Char.IsNumber(e.KeyChar) = False Then
        '    If e.KeyChar = CChar(ChrW(Keys.Back)) Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'End If
    End Sub


    Private Sub ordernumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxordernumber.TextChanged
        If Me.TextBoxordernumber.Text = "11119999" Then
            Me.Buttonpopulate.Visible = True
            Me.ButtonWrite.Visible = True
            Me.ButtonPrint.Visible = True
            Me.buttonRead.Visible = True
        End If
    End Sub



    Private Sub read_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonRead.Click
        readDowntimeTable()
    End Sub

    Private Sub TextBoxLabeler_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

    End Sub

    Private Sub lavchemtest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fluid.TextChanged

    End Sub

    Private Sub sendout_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendout.TextChanged

    End Sub

    Private Sub csftest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csftest.TextChanged

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        printerlist()
        ComboBoxprinter.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxprinter.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub
    Sub printerlist()
        Dim ch As New MySqlDataAdapter("select name from pathdirectory.device d join pathdirectory.device_has_group dg on d.Device_ID = dg.Device_ID where Group_ID like '5%' Or Group_ID like '36' order by name", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim dtble As New DataTable
        ch.Fill(dtble)
        For Each dr As DataRow In dtble.Rows

            ComboBoxprinter.Items.Add(dr("name").ToString)

        Next

    End Sub

    Private Sub ComboBoxprinter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxprinter.SelectedIndexChanged

    End Sub
End Class

