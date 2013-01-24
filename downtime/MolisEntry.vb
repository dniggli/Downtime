Imports NUnit.Framework
Imports AutoItHelper.AutoItX
Imports System.Threading
Imports System.Text.RegularExpressions

Public Class MolisEntry

    Shared myOrder As MolisEntry
    Public Shared Sub MolisEnter()
        If WinExists("Molis") Then

            myOrder = New MolisEntry
            Application.Run(myorder)

        Else
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "You must be logged into Molis"   ' Define message.
            style = MsgBoxStyle.DefaultButton1
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If

        If myOrder IsNot Nothing Then
            myOrder.TextBoxOrderNumber.Focus()
            myOrder.TextBoxOrderNumber.Clear()
        End If

    End Sub


    Public Sub RetriveDTData()
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


            Dim fullname As String = lastname + "," + firstname

            Dim lavtest As String = Microsoft.VisualBasic.Right(TextBoxOrderNumber.Text, 2)

            Dim d As Dictionary(Of String, String()) = New Dictionary(Of String, String())

            If lavtest = "18" Then

                Dim lavordernumber As String = ordernumber + "18"

                WinActivate("Molis", "MWMSBE 30")
                'AutoItHelper.AutoItX.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 163, 57)

                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", lavordernumber, 0)

                AutoItHelper.AutoItX.Send("{TAB}")
                If priority = "S" Then AutoItHelper.AutoItX.Send("{SPACE}")

                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", fullname, 0)

                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", mrn, 0)

                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", DOB, 0)

                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", ComboBoxWard, 0)


                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", colldate, 0)




                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", collectiontime, 0)


                AutoItHelper.AutoItX.Sleep(200)
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Send("{TAB}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.Send("{DELETE}")
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", receivetime, 0)

                AutoItHelper.AutoItX.Sleep(200)
                'AutoItHelper.AutoItX.Send("{TAB}")

                Dim e As String() = lavhemtest.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
                For Each i As String In e
                    If i = "SPLT" Then i = "PLT"
                    If i = "SHCT" Then i = "HCT"
                    If i = " SPLT" Then i = "PLT"
                    If i = " SHCT" Then i = "HCT"
                    If i = " PLT" Then i = "PLT"
                    If i = " HCT" Then i = "HCT"
                    If i = " CBCD" Then i = "CBCD"
                    If i = " CBC" Then i = "CBC"
                    If i = " RETA" Then i = "RET"
                    If i = "RETA" Then i = "RET"
                    If i = " HH" Then i = "HH"


                    AutoItHelper.AutoItX.Sleep(200)
                    AutoItHelper.AutoItX.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 179, 601)
                    AutoItHelper.AutoItX.Send(i)
                    AutoItHelper.AutoItX.Send("{TAB}")

                    AutoItHelper.AutoItX.Send("{DELETE}")
                    AutoItHelper.AutoItX.Send("{DELETE}")
                    AutoItHelper.AutoItX.Send("{DELETE}")
                    AutoItHelper.AutoItX.Send("{DELETE}")
                    AutoItHelper.AutoItX.Send("{DELETE}")
                    AutoItHelper.AutoItX.Send("{DELETE}")
                    AutoItHelper.AutoItX.Send("{DELETE}")
                    AutoItHelper.AutoItX.Sleep(400)

                    ''clicking on test buttons
                    'If i = "CBC" Then
                    '    AutoItHelper.AutoItX.Sleep(200)
                    '    AutoItHelper.AutoItX.ControlClick("Molis", "CBC", "[CLASS:Button; INSTANCE:3]", "Button3", 1, 59, 30)
                    '    AutoItHelper.AutoItX.Send("{SPACE}")
                    'End If


                    'If i = "CBCD" Then

                    '    AutoItHelper.AutoItX.Sleep(200)
                    '    AutoItHelper.AutoItX.ControlClick("Molis", "CBCD", "[CLASS:Button; INSTANCE:11]", "Button11", 1, 41, 32)
                    '    AutoItHelper.AutoItX.Send("{SPACE}")

                    'End If

                    'If i = "HH" Then
                    '    AutoItHelper.AutoItX.Sleep(200)
                    '    AutoItHelper.AutoItX.ControlClick("Molis", "HH", "[CLASS:Button; INSTANCE:15]", "Button15", 1, 87, 45)
                    '    AutoItHelper.AutoItX.Send("{SPACE}")
                    'End If


                    ''Mnualy entering test text
                    'If i = "HCT" Then
                    '    AutoItHelper.AutoItX.Sleep(200)
                    '    AutoItHelper.AutoItX.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 179, 601)
                    '    AutoItHelper.AutoItX.Send(i)
                    '    AutoItHelper.AutoItX.Send("{TAB}")
                    'End If

                    'If i = "PLT" Then
                    '    AutoItHelper.AutoItX.Sleep(200)
                    '    AutoItHelper.AutoItX.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 179, 601)
                    '    AutoItHelper.AutoItX.Send(i)
                    '    AutoItHelper.AutoItX.Send("{TAB}")
                    'End If
                Next


            End If
            AutoItHelper.AutoItX.Sleep(800)
            




            AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send("{SPACE}")

          
            AutoItHelper.AutoItX.Sleep(200)


            AutoItHelper.AutoItX.WinActivate("MolisEntry")
            TextBoxOrderNumber.Focus()
            TextBoxOrderNumber.Clear()


        Catch
        End Try
    End Sub

    Private Sub ButtonRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRun.Click
        RetriveDTData()
    End Sub

    Private Sub TextBoxOrderNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxOrderNumber.KeyPress
        If e.KeyChar = Chr(13) Then
            ButtonRun_Click(Me, EventArgs.Empty)
        End If
    End Sub
End Class