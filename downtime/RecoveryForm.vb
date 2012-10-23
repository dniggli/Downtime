Imports NUnit.Framework
Imports AutoItHelper.AutoItX
Imports System.Text.RegularExpressions

<TestFixture()> _
Public Class RecoveryForm

    Public Shared fixTEST As String = ""
    Public Shared Sub autoit()
        Dim myorder As New RecoveryForm
        Application.Run(myorder)

    End Sub

    Public Shared tests As String = ""

    <Test()> _
   Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If WinExists("Search") Then




            ' If Not Me.TextBoxOrderNumber.Text = String.Empty Then
            'If Not Me.TextBox1.Text = String.Empty Then
            Me.Visible = False
            Dim numberstart As String = TextBoxOrderNumber.Text
            ' Dim numberend As String = TextBox1.Text
            Dim n = numberstart
            'Do While (n < (numberend + 1))
            'System.Threading.Thread.Sleep(500)
            automatedrecovery(n)
            'n = n + 1
            ' Loop
            'Else
            '    Dim msg As String
            '    Dim title As String
            '    Dim style As MsgBoxStyle
            '    Dim response As MsgBoxResult

            '    msg = "Must Enter Ending Order Number"   ' Define message.
            '    style = MsgBoxStyle.DefaultButton1
            '    title = "MsgBox"   ' Define title.
            '    ' Display message.
            '    response = MsgBox(msg, style, title)
            '    If response = MsgBoxResult.Ok Then TextBox1.Focus()

            'End If

            'Else

            'Dim msg As String
            'Dim title As String
            'Dim style As MsgBoxStyle
            'Dim response As MsgBoxResult

            'msg = "Must Enter Starting Order Number"   ' Define message.
            'style = MsgBoxStyle.DefaultButton1
            'title = "MsgBox"   ' Define title.
            '' Display message.
            'response = MsgBox(msg, style, title)
            'If response = MsgBoxResult.Ok Then TextBoxOrderNumber.Focus()

            'End If

        Else

            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "Must Open OrderEntry Lookup Screen"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then Exit Sub

        End If

    End Sub

    Sub automatedrecovery(ByVal startnumber As String)
        'Dim da As New MySqlDataAdapter("select * from dtdb1.Table1 where ordernumber like '68166609' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim da As New MySqlDataAdapter("select * from dtdb1.Table1 where ordernumber like '" & startnumber & "' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
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
            
            If BILLING = String.Empty Then
                Dim msg As String
                Dim title As String
                Dim style As MsgBoxStyle
                Dim response As MsgBoxResult

                msg = "No Billing #"   ' Define message.
                style = MsgBoxStyle.DefaultButton1
                title = "MsgBox"   ' Define title.
                ' Display message.
                response = MsgBox(msg, style, title)
                If response = MsgBoxResult.Ok Then
                    Me.Visible = True
                    TextBoxOrderNumber.Focus()

                    Exit Sub
                End If
            End If

            Dim DICT As Dictionary(Of String, String()) = New Dictionary(Of String, String())

            DICT.Add("bluetest", Split(bluetest, ","))

            DICT.Add("redtest", Split(redtest, ","))

            DICT.Add("greentest", Split(greentest, ","))

            DICT.Add("lavhemtest", Split(lavhemtest, ","))


            DICT.Add("lavchemtest", Split(lavchemtest, ","))



            DICT.Add("serology", Split(ser, ","))

            DICT.Add("heppat", Split(hepp, ","))

            DICT.Add("urinehem", Split(urinehem, ","))

            DICT.Add("urinechem", Split(urinechem, ","))

            DICT.Add("bloodgas", Split(bloodgas, ","))



            DICT.Add("gray", Split(graytest, ","))

            DICT.Add("viral", Split(Viralloadbox, ","))

            DICT.Add("csf", Split(csfbox, ","))

            DICT.Add("fluid", Split(fluidbox, ","))



            AutoItHelper.AutoItX.Sleep(500)
            WinActivate("Search")
            AutoItHelper.AutoItX.ControlSend("Search", "", "[CLASS:Edit; INSTANCE:7]", BILLING, 0)
            AutoItHelper.AutoItX.Sleep(200)
            WinActivate("Search")
            AutoItHelper.AutoItX.Send("{ENTER}")
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.Send("!w")
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.Send("{o}")

            AutoItHelper.AutoItX.Sleep(500)
          
            If WinWaitActive("Order info", "", 1) Then
                AutoItHelper.AutoItX.Send("{ENTER}")
            End If

            AutoItHelper.AutoItX.Sleep(500)
            AutoItHelper.AutoItX.Send("SD")

            AutoItHelper.AutoItX.Sleep(100)
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Sleep(100)
            Dim n As Integer = 0
            Dim reqdr As String = AutoItHelper.AutoItX.WinGetText("Order Entry - [New Order  - Edit Mode]", "")
            Console.WriteLine(reqdr)
            Dim drname As Array = reqdr.Split("&")

            Dim newseq As Match = Regex.Match(reqdr, "\bDr:\n([A-Z 0-9]+)\n.+$", RegexOptions.Multiline)

            'Do While n < 10
            '    Dim tstcd As String = newtest.Groups(n).Value
            '    n = n + 1
            '    Console.WriteLine(tstcd)
            'Loop
            ''dim testdr As String =  

            ''For Each d As String In drname

            ''    Dim parsetest = drname(n)
            ''    n = n + 1
            ''    Console.WriteLine(parsetest)
            ''Next
            'Dim drcodearray As String = drname(2)

            'Dim drfirst As Array = drcodearray.Split(" ")

            'Dim drcodesect As String = drfirst(1).ToString


            'Dim newseq As Match = Regex.Match(drcodesect, "^Dr:\n([A-Z 0-9]+)\n.+$", RegexOptions.Multiline)



            Dim drcode As String = newseq.Groups(1).Value





            AutoItHelper.AutoItX.ControlSend("Order Entry - [New Order  - Edit Mode]", "", "[CLASS:Edit; INSTANCE:33]", drcode, 0)

            'AutoItHelper.AutoItX.Send("{TAB}")
            'AutoItHelper.AutoItX.Sleep(100)
            'AutoItHelper.AutoItX.Send("{TAB}")
            'AutoItHelper.AutoItX.Sleep(100)
            'AutoItHelper.AutoItX.Send("{TAB}")
            'AutoItHelper.AutoItX.Sleep(100)
            'AutoItHelper.AutoItX.Send("{F2}")
            'AutoItHelper.AutoItX.Sleep(200)
            ''AutoItHelper.AutoItX.Send(drlast)
            'AutoItHelper.AutoItX.Sleep(100)
            'AutoItHelper.AutoItX.Send("{TAB}")
            ''AutoItHelper.AutoItX.Send(drfirst)
            'AutoItHelper.AutoItX.Send("!F")
            'WinWaitClose("Doctor Search Screen")
            'AutoItHelper.AutoItX.ControlFocus("Order Entry - [New Order  - Edit Mode]", "", "[CLASS:Edit; INSTANCE:2]")


            'AutoItHelper.AutoItX.Send("^V")


            AutoItHelper.AutoItX.ControlSend("Order Entry - [New Order  - Edit Mode]", "", "[CLASS:ComboBox; INSTANCE:1]", priority, 0)
            AutoItHelper.AutoItX.Sleep(500)
            AutoItHelper.AutoItX.ControlSend("Order Entry - [New Order  - Edit Mode]", "", "[CLASS:Edit; INSTANCE:15]", ordernumber, 0)

            AutoItHelper.AutoItX.Sleep(700)
            WinActivate("Order Entry - [New Order  - Edit Mode]")
            AutoItHelper.AutoItX.Send("!2")
            'AutoItHelper.AutoItX.SetOptions(true)

            For Each testtype As String In DICT.Keys
                For Each test As String In DICT(testtype)

                    AutoItHelper.AutoItX.Send(test)
                    AutoItHelper.AutoItX.Send("{ENTER}")
                    AutoItHelper.AutoItX.Sleep(300)
                    If WinExists("Order Entry", "RBS") Then

                        Do Until AutoItHelper.AutoItX.WinExists("Order Entry", "RBS") = False
                            WinActivate("Order Entry", "RBS")
                            AutoItHelper.AutoItX.Sleep(100)
                            Send("{ENTER}")
                            AutoItHelper.AutoItX.Sleep(200)
                        Loop

                    End If
                    If WinExists("Order Entry", "RBS <SSIGN>: reflex 'SSIGN' on Ord# NEW") Then
                        Do Until AutoItHelper.AutoItX.WinExists("Order Entry", "RBS <SSIGN>: reflex 'SSIGN' on Ord# NEW") = False
                            WinActivate("Order Entry", "RBS <SSIGN>: reflex 'SSIGN' on Ord# NEW")
                            AutoItHelper.AutoItX.Sleep(100)
                            Send("{ENTER}")
                            AutoItHelper.AutoItX.Sleep(200)
                        Loop
                    End If
                    If WinExists("Order Entry", "not defined") Then
                        AutoItHelper.AutoItX.Sleep(100)
                        Send("{ENTER}")
                        AutoItHelper.AutoItX.Sleep(200)
                        tests = test
                        Dim Iform As New InputBoxFormRecover

                        Iform.ShowDialog(Me)
                        AutoItHelper.AutoItX.Sleep(200)
                        Iform.Focus()
                        'TopMost = True
                        'Dim testfix As String = InputBox("Correct unknown test: " & test)
                        'TopMost = False
                        Console.WriteLine(fixTEST)
                        AutoItHelper.AutoItX.ControlSend("Order Entry", "New Order  - Edit Mode", "[CLASS:Edit; INSTANCE:1]", fixTEST, 0)
                        AutoItHelper.AutoItX.Sleep(100)
                        WinActivate("Order Entry - [New Order  - Edit Mode]")
                        AutoItHelper.AutoItX.Sleep(50)
                        Send("{ENTER}")

                    End If

                    AutoItHelper.AutoItX.Sleep(200)
                Next
            Next
            AutoItHelper.AutoItX.Send("{F9}")
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.Send(";")
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send(collectiontime)
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send(DateTimeFunctions.datetoordentry(colldate))
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send(receivetime)
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send(DateTimeFunctions.datetoordentry(colldate))
            AutoItHelper.AutoItX.Send("{ENTER}")
            AutoItHelper.AutoItX.Sleep(200)
            AutoItHelper.AutoItX.Send("^s")
            AutoItHelper.AutoItX.Sleep(1000)
            If WinExists("Result must be entered for this test:") Then

                WinWaitClose("Result must be entered for this test:")
            End If

            If WinExists("Results must be entered for these tests:") Then

                WinWaitClose("Results must be entered for these tests:")
            End If

            AutoItHelper.AutoItX.Send("y")
            AutoItHelper.AutoItX.Sleep(500)
            WinWaitActive("Standard Label", "1")
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send("{TAB}")
            'AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send("{ENTER}")
            AutoItHelper.AutoItX.Sleep(500)


            'For Each kv As KeyValuePair(Of String, String()) In DICT

            '    Console.WriteLine(kv.Key)


            'Next

        Catch ex As Exception

        End Try
        Me.Visible = True
    End Sub



    Private Sub TextBoxOrderNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxOrderNumber.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1_Click(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub RecoveryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class