Imports NUnit.Framework
Imports System.IO
Imports MySql.Data.MySqlClient

Imports CodeBase2
Imports System.Text.RegularExpressions


Imports System.Collections.Generic
Imports System.Data.Odbc

Imports System.Web
Imports CodeBase2.Databases


<TestFixture()> _
Public Class UnitTests

    <Test()> _
    Sub TestDITests()
        AutoItHelper.AutoItX.ControlFocus("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:2]")

        Dim DICT As Dictionary(Of String, String()) = New Dictionary(Of String, String())


        Dim d As New Dictionary(Of String, String)
        Dim dt As New DataTable
        Dim ditests As New MySqlDataAdapter("select * from dtdb1.DITests1;", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        ditests.Fill(dt)
        For Each dr As DataRow In dt.Rows
            Dim ditest As String = dr("TestCode").ToString
            Dim sequence As String = dr("CodeSequence").ToString
            d.Add(ditest, sequence)
        Next



        For Each testtype As String In d.Keys


            Dim test As String = d(testtype)


            Dim spacecheck As String = Microsoft.VisualBasic.Left(testtype, 1)
            If spacecheck = " " Then
                testtype = testtype.Trim(" ")

                Dim space As String = " "
                If test = "" Then
                Else

                    AutoItHelper.AutoItX.Sleep(200)
                    AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:2]", test, 1)
                    AutoItHelper.AutoItX.Sleep(200)
                    AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:2]", space, 1)
                    Console.WriteLine(testtype + ", " + test)
                    AutoItHelper.AutoItX.Sleep(200)
                    Console.WriteLine(testtype + ", " + test)
                    AutoItHelper.AutoItX.ControlSend("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:2]", "{HOME}", 0)
                End If



                'Dim msg As String
                'Dim title As String
                'Dim style As MsgBoxStyle
                'Dim response As MsgBoxResult

                'msg = "test placed for '" & testtype & "'"   ' Define message.
                'style = MsgBoxStyle.DefaultButton1
                'title = "MsgBox"   ' Define title.
                '' Display message.
                'response = MsgBox(msg, style, title)
                'If response = MsgBoxResult.Ok Then
                '    AutoItHelper.AutoItX.ControlFocus("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:2]")
                '    ' User chose Yes.
                '    ' Perform some action.
            End If


        Next
    End Sub
    '<Test()> _
    'Sub resporders()

    '    Dim n As Integer

    '    For n = 0 To 252
    '        Dim ordernumber As Integer = 99049500
    '        ordernumber = ordernumber + n
    '        Dim stordernumber = ordernumber.ToString

    '        Dim fn2 As New LabelData(stordernumber, "", "", "REQ", "STAT", "", "", "", "", "Collected", "")
    '        LabelPrint2(fn2, "S72")

    '        Dim bg1 As New LabelData(stordernumber, "", "20", "SYR", "STAT", "", "", "", "")
    '        LabelPrint(bg1, "S72")


    '        Dim printer As String = "S72"

    '        Dim NameToIP As Dictionary(Of String, String) = CodeBase2.Labeler.Send_IP_Printer.GetLabelersList_byGroup("/Strong/Specimen Management")
    '        Dim PrinterDNSName As String = NameToIP(printer.ToUpper).ToString
    '        If Not PrinterDNSName.Contains(".") Then
    '            printer = CodeBase2.DNS.NameToIPString(PrinterDNSName)
    '            CodeBase2.Labeler.Send_IP_Printer.PrintLabel(printer, orderentry.strNecessary.ToString)
    '        Else
    '            CodeBase2.Labeler.Send_IP_Printer.PrintLabel(NameToIP(printer.ToUpper), orderentry.strNecessary.ToString)
    '        End If

    '        Dim STRLENGTH As Integer = orderentry.strNecessary.Length
    '        orderentry.strNecessary.Remove(0, STRLENGTH)

    '        System.Threading.Thread.Sleep(1500)
    '        Console.WriteLine(ordernumber)
    '    Next

    'End Sub

End Class
