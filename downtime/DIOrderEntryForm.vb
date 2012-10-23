Imports NUnit.Framework
Imports AutoItHelper.AutoItX
Imports System.Threading
Imports System.Text.RegularExpressions



<TestFixture()> _
Public Class DIOrderEntryForm
    Public Shared DICT As Dictionary(Of String, String()) = New Dictionary(Of String, String())
    Public Shared Sub DIRecover()
        If WinExists("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]") Then


            Dim myorder As New DIOrderEntryForm
            Application.Run(myorder)


        Else
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "You must be logged into DI with username: SMS and password: URMCLAB"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
    End Sub
    Dim inputboxx As Thread
    Public Shared wrongtests As String = ""

    <Test()> _
     Sub ButtonSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubmit.Click


        'End Sub

        'WinActivate("SoftLab 4.0.3 - Strong Memorial Hospital")
        'AutoItHelper.AutoItX.ControlSend("SoftLab 4.0.3 - Strong Memorial Hospital", "", "", "!o", 0)

        '<Test()> _
        'Sub testsplit()
        Dim ordernumbers As String = Microsoft.VisualBasic.Left(TextBoxOrderNumber.Text, 8)
        'Dim da As New MySqlDataAdapter("select * from dtdb1.Table1 where ordernumber like '74206574' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim da As New MySqlDataAdapter("select * from dtdb1.Table1 where ordernumber like '" & ordernumbers & "' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim t As New DataTable

        da.Fill(t)

        Try
            Dim r As DataRow = t.Rows(0)

            Dim ordernumber As String = r("ordernumber").ToString
            Dim firstname As String = r("firstname").ToString
            Dim lastname As String = r("lastname").ToString
            Dim mrn As String = r("mrn").ToString
            Dim collectiontime As String = r("collectiontime").ToString
            Dim receivetime As String = r("receivetime").ToString
            Dim priority As String = r("priority").ToString
            Dim ComboBoxWard As String = r("location").ToString
            Dim bluetest As String = r("bluetest").ToString
            Dim redtest As String = r("redtest").ToString
            Dim greentest As String = r("greentest").ToString
            Dim urinechem As String = r("urinechem").ToString
            Dim urinehem As String = r("urinehem").ToString
            Dim graytest As String = r("grytest").ToString
            Dim comment As String = r("ordercomment").ToString
            Dim problem As String = r("problem").ToString
            Dim lavchemtest As String = r("lavchemtest").ToString
            Dim lavhemtest As String = r("lavhemtest").ToString
            Dim bloodgas As String = r("bloodgas").ToString
            Dim DOB As String = r("dob").ToString
            Dim cal1 As String = r("calls").ToString
            Dim sendout As String = r("SENDOUT").ToString
            Dim hepp As String = r("heppetitas").ToString
            Dim ser As String = r("serology").ToString
            Dim colldate As String = r("collectdate").ToString
            Dim csfbox As String = r("CSFTEST").ToString
            Dim fluidbox As String = r("FLUIDTEST").ToString
            Dim Viralloadbox As String = r("VIRALLOADTEST").ToString
            Dim OTHERBOX As String = r("OTHERTEST").ToString
            Dim BILLING As String = r("BILLINGNUMBER").ToString

            Dim redlength As String = redtest.Length

            Dim dates As Match = Regex.Match(DOB, "([0-9]+)/([0-9]+)/([0-9]+)")
            Dim days As String = dates.Groups(0).Value
            Dim month As String = dates.Groups(1).Value
            Dim year As String = dates.Groups(2).Value
            While days.ToString.Length < 2
                days = "0" & days
            End While
            While month.ToString.Length < 2
                month = "0" & month
            End While

            'redtest = redtest.Replace("TIBC", "FE,UIBC")
            Dim fullname As String = lastname + "," + firstname

            Dim redorgreen As String = Microsoft.VisualBasic.Right(TextBoxOrderNumber.Text, 2)







            WinActivate("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]")
            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6TextBox; INSTANCE:3]", mrn, 0)

            AutoItHelper.AutoItX.Send("{ENTER}")
            AutoItHelper.AutoItX.Sleep(800)

            If WinExists("Loading Specimens", "Progress Bar") Then
                WinWaitClose("Loading Specimens")

            End If
            If WinExists("Instrument Manager", "OK") Then
                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{ENTER}")
                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6TextBox; INSTANCE:4]", fullname, 0)
                AutoItHelper.AutoItX.ControlFocus("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6TextBox; INSTANCE:4]")
                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{SPACE}")
                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{RIGHT}")
                AutoItHelper.AutoItX.Send(days)
                'AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:DTPicker20WndClass; INSTANCE:1]", day, 0)


                AutoItHelper.AutoItX.ControlClick("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6PictureBoxDC; INSTANCE:3]", "", 1, 35, 11)
                AutoItHelper.AutoItX.Sleep(200)
            End If


            If WinExists("Loading Specimens", "Progress Bar") Then
                WinWaitClose("Loading Specimens")
            End If

            AutoItHelper.AutoItX.Sleep(300)

            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:Edit; INSTANCE:1]", "{DELETE}", 0)
            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:Edit; INSTANCE:1]", "{DELETE}", 0)
            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:Edit; INSTANCE:1]", "{DELETE}", 0)
            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:Edit; INSTANCE:1]", "{DELETE}", 0)
            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:Edit; INSTANCE:1]", "{DELETE}", 0)
            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:Edit; INSTANCE:1]", "{DELETE}", 0)
            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:Edit; INSTANCE:1]", "{DELETE}", 0)
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:Edit; INSTANCE:1]", ComboBoxWard, 0)


            'Dim locat As String = AutoItHelper.AutoItX.WinGetText("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "")
            'Dim locations As String() = locat.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

            'If locations(4).Length > 6 Then
            '    AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:Edit; INSTANCE:1]", ComboBoxWard, 0)

            'End If

            Dim ordnum As String = String.Empty

            If redorgreen = "00" Then

                redtest = redtest.Replace(" ", "")

                DICT.Add("redtest", Split(redtest, ","))

                'DICT.Add("redtest", Split(redtest, ","))
                ordnum = TextBoxOrderNumber.Text
            ElseIf redorgreen = "40" Then
                DICT.Add("greentest", Split(greentest, ","))
                ordnum = TextBoxOrderNumber.Text
            ElseIf redorgreen = "79" Then
                DICT.Add("lavtest", Split(lavchemtest, ","))
                ordnum = TextBoxOrderNumber.Text
            ElseIf redorgreen = "19" Then
                DICT.Add("greytest", Split(graytest, ","))
                ordnum = TextBoxOrderNumber.Text
            End If
            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6TextBox; INSTANCE:6]", ordnum, 0)

            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.ControlClick("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6PictureBoxDC; INSTANCE:14]", "", 1, 10, 10)
            AutoItHelper.AutoItX.Sleep(800)
            If WinWaitActive("Loading Specimens", "Progress Bar", 1) Then
                WinWaitClose("Loading Specimens")

            End If

            WinActivate("Instrument Manager", "&Yes")
            AutoItHelper.AutoItX.Send("{Y}")
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.ControlClick("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6PictureBoxDC; INSTANCE:10]", "", 1, 40, 13)



            Dim d As New Dictionary(Of String, String)
            Dim dt As New DataTable
            Dim ditests As New MySqlDataAdapter("select * from dtdb1.DITests;", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
            ditests.Fill(dt)
            For Each dr As DataRow In dt.Rows
                Dim ditest As String = dr("TestCode").ToString
                Dim sequence As String = dr("CodeSequence").ToString
                d.Add(ditest, sequence)
            Next



            For Each testtype As String In DICT.Keys
                For Each test As String In DICT(testtype)

                    Dim spacecheck As String = Microsoft.VisualBasic.Left(testtype, 1)
                    If spacecheck = " " Then
                        testtype = testtype.Trim(" ")
                    End If
                    Dim space As String = " "
                    If d(test) = "" Then
                    Else

                        AutoItHelper.AutoItX.Sleep(300)
                        AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:2]", d(test), 1)
                        AutoItHelper.AutoItX.Sleep(300)
                        AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:2]", space, 1)
                        AutoItHelper.AutoItX.Sleep(300)
                        AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:2]", "{HOME}", 0)
                    End If







                Next
            Next

            AutoItHelper.AutoItX.Sleep(500)
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.Send("{DOWN}")
            AutoItHelper.AutoItX.Send("{DOWN}")
            AutoItHelper.AutoItX.Send("{SPACE}")
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:1]", "S", 0)
            AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:1]", "S", 0)
            AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:1]", "S", 0)
            AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:1]", "S", 0)
            AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:1]", "S", 0)
            AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:1]", "S", 0)
            AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:1]", "S", 0)
            AutoItHelper.AutoItX.Send("{SPACE}")
            ' AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:1]", "S ", 0)
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.Send("{SPACE}")
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.Send("{Y}")
            AutoItHelper.AutoItX.Sleep(800)
            If WinWaitActive("Loading Specimens", "Progress Bar", 1) Then
                WinWaitClose("Loading Specimens")
            End If
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.ControlFocus("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6TextBox; INSTANCE:4]")
            AutoItHelper.AutoItX.ControlSend("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:Edit; INSTANCE:3]", "SER", 0)

            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.ControlClick("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:DTPicker20WndClass; INSTANCE:3]", "", 1, 11, 9)
            AutoItHelper.AutoItX.ControlClick("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:DTPicker20WndClass; INSTANCE:2]", "", 1, 10, 12)

            AutoItHelper.AutoItX.ControlClick("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6PictureBoxDC; INSTANCE:3]", "", 1, 35, 11)
            AutoItHelper.AutoItX.Sleep(1500)
            If WinWaitActive("Loading Specimens", "Progress Bar", 2) Then
                WinWaitClose("Loading Specimens")
            End If








        Catch
        End Try

        msgboxs()


        Me.TextBoxOrderNumber.Clear()
        Sleep(1000)
        Me.Activate()
        Me.Focus()
        DICT.Clear()
    End Sub



    Private Sub TextBoxOrderNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxOrderNumber.KeyPress
        If e.KeyChar = Chr(13) Then
            ButtonSubmit_Click(Me, EventArgs.Empty)
        End If
    End Sub

    Sub msgboxs()


        Dim response As DialogResult

        response = MessageBox.Show("Order Has Been Placed.  would you like to place another order?", "Order Finished", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, False)

        If response = Windows.Forms.DialogResult.Yes Then
            AutoItHelper.AutoItX.ControlClick("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6PictureBoxDC; INSTANCE:7]", "", 1, 42, 15)


            'Me.Activate()
            'Me.TextBoxOrderNumber.Clear()


        End If

        If response = Windows.Forms.DialogResult.No Then

            AutoItHelper.AutoItX.ControlClick("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6PictureBoxDC; INSTANCE:7]", "", 1, 42, 15)
            Exit Sub
        End If


    End Sub

    Private Sub DIOrderEntryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim dt As New DataTable
        Dim ditests As New MySqlDataAdapter("select * from dtdb1.DITests;", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        ditests.Fill(dt)
        For Each dr As DataRow In dt.Rows

            Dim ditest As String = dr("TestCode").ToString
            Dim sequence As String = dr("CodeSequence").ToString
            Dim newseq As Match = Regex.Match(sequence, "([A-Z]+)")
            sequence = newseq.Groups(0).Value
            Console.WriteLine(sequence)

            Dim comm2 As New MySqlCommand("INSERT INTO dtdb1.DITests1 (TestCode, CodeSequence)Values('" & ditest & "', '" & sequence & "')", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))
            comm2.Connection.Open()
            comm2.ExecuteNonQuery()
            comm2.Connection.Close()
        Next
    End Sub
End Class