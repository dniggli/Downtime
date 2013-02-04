Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions
Public Class RestartWheel

    Dim monthday As String = ""
    Dim ordernumber As String = ""
    Dim TDate As String = ""
    Dim dict As New Dictionary(Of String, String)


    Public Shared Sub number()
        Dim myorder As New RestartWheel
        Application.Run(myorder)

    End Sub
    Sub Deleteoldinfo()



        Dim comm1 As New MySqlCommand("truncate table dtdb1.ordernumber", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))

        comm1.Connection.Open()
        comm1.ExecuteNonQuery()
        comm1.Connection.Close()

    End Sub


    Sub Deleteoldtrackinfo()

        Dim comm As New MySqlCommand("truncate table dtdb1.dttracking", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))

        comm.Connection.Open()
        comm.ExecuteNonQuery()
        comm.Connection.Close()

    End Sub


    Sub submitneworder()

        Dim comm2 As New MySqlCommand("truncate table dtdb1.Table1", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))

        comm2.Connection.Open()
        comm2.ExecuteNonQuery()
        comm2.Connection.Close()



        TDate = DateTimeFunctions.datetomysql(Date.Now)

        '..........//////use to reinstate alpha-neumaric(also un-comment line items 540-547 in orderentry)\\\\\\\\.........


        Dim comm As New MySqlCommand("insert into dtdb1.ordernumber (Ordernumber, Date) VALUES ('" & ordernumber & "', '" & TDate & "');", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))

        'Dim comm As New MySqlCommand("insert into dtdb1.ordernumber (Ordernumber, Date) VALUES ('5000', '" & TDate & "');", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))
        comm.Connection.Open()
        comm.ExecuteNonQuery()
        comm.Connection.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        If ComboBoxNewOrderNumber.SelectedIndex.ToString.Length > 1 Then
            Dim msg1 As String
            Dim title1 As String
            Dim style1 As MsgBoxStyle
            Dim response1 As MsgBoxResult

            msg1 = "Ordernumber has not been selected.  Please select Ordernubmer"   ' Define message.
            style1 = MsgBoxStyle.OkOnly
            title1 = "MsgBox"   ' Define title.
            ' Display message.
            response1 = MsgBox(msg1, style1, title1)
            If response1 = MsgBoxResult.Ok Then
                Exit Sub
            End If

        End If


        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult

        msg = "Are you Sure you Want to Clear ALL DATA????"   ' Define message.
        style = MsgBoxStyle.YesNo
        title = "MsgBox"   ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then
            Deleteoldinfo()
            submitneworder()

        End If
        If response = MsgBoxResult.No Then
            Exit Sub
        End If



        msg = "Old Data Has Been Cleard and Ordernumber Has Been Reset."   ' Define message.
        style = MsgBoxStyle.OkOnly
        title = "MsgBox"   ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Ok Then

        End If


    End Sub

    Private Sub Buttondelettrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttondelettrack.Click
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult

        msg = "Are you Sure you Want to reset tracking?"   ' Define message.
        style = MsgBoxStyle.YesNo
        title = "MsgBox"   ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then
            Deleteoldtrackinfo()

        End If
        If response = MsgBoxResult.No Then Exit Sub

    End Sub

    Function date2ordernumber(ByVal dates As String)
        Dim ordend As String = dates

        Dim dateend As System.Text.RegularExpressions.Match = Regex.Match(ordend, "([0-9]+)/([0-9]+)/([0-9]+)")
        Dim endmonth As String = dateend.Groups(1).Value
        Dim endday As String = dateend.Groups(2).Value
        Dim endyear As String = dateend.Groups(3).Value
        While endday.Length < 2
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

    Private Sub restartwheel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load








        '.......................///////////// Create Alpha-neumaric OrderNumber \\\\\\\\\\\\\\\\\........................



        Dim DatabaseNumber As New MySqlDataAdapter("select * from dtdb1.NumberWheel;", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")

        Dim dt As New DataTable
        DatabaseNumber.Fill(dt)

        Dim dr As DataRow = dt.Rows(0)

        Dim datanumber As String = dr("OrderNumberAlpha").ToString
        Dim lownumber As String = dr("OrderNumberNumer").ToString




        Dim n As Integer = Convert.ToInt32(lownumber)

        Do While n < 8001
            Dim nonalphaordernumber As String = (date2ordernumber(Date.Now) + n.ToString)
            ComboBoxNewOrderNumber.Items.Add(nonalphaordernumber)

            dict.Add(nonalphaordernumber, n.ToString)

            n = n + 500


        Loop

        Dim ordernums As String = Microsoft.VisualBasic.Right(datanumber, 3)
        Dim letters As String = Microsoft.VisualBasic.Left(datanumber, 2)
        Dim alphanum As String = date2ordernumber(Date.Now) + Chr(letters) + ordernums
        Dim ordnumend As String = letters + ordernums



        ComboBoxNewOrderNumber.Items.Add(alphanum)

        dict.Add(alphanum, ordnumend)






    End Sub

    Private Sub ButtonNumberReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNumberReset.Click


        If ComboBoxNewOrderNumber.SelectedIndex.ToString.Length > 1 Then
            Dim msg1 As String
            Dim title1 As String
            Dim style1 As MsgBoxStyle
            Dim response1 As MsgBoxResult

            msg1 = "Ordernumber has not been selected.  Please select Ordernubmer"   ' Define message.
            style1 = MsgBoxStyle.OkOnly
            title1 = "MsgBox"   ' Define title.
            ' Display message.
            response1 = MsgBox(msg1, style1, title1)
            If response1 = MsgBoxResult.Ok Then
                Exit Sub
            End If

        End If

        Dim ch As New MySqlDataAdapter("SELECT Date FROM dtdb1.ordernumber order BY Date DESC lIMIT 1;", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim dtble As New DataTable
        ch.Fill(dtble)

        Dim q As DataRow = dtble.Rows(0)
        Dim datestring As Date = q("Date")

        Dim checkdate As Date = Date.Now.Date


        If Not checkdate = datestring Then

            Dim comm1 As New MySqlCommand("truncate table dtdb1.ordernumber", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))

            comm1.Connection.Open()
            comm1.ExecuteNonQuery()
            comm1.Connection.Close()

            submitneworder()

            Dim msg1 As String
            Dim title1 As String
            Dim style1 As MsgBoxStyle
            Dim response1 As MsgBoxResult

            msg1 = "Order Number Has Been Reset"   ' Define message.
            style1 = MsgBoxStyle.OkOnly
            title1 = "MsgBox"   ' Define title.
            ' Display message.
            response1 = MsgBox(msg1, style1, title1)



        Else
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult

            msg = "Order Number has already been reset for today.  Would you like to reset it again?"   ' Define message.
            style = MsgBoxStyle.YesNo
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.No Then

            ElseIf response = MsgBoxResult.Yes Then

                Dim comm1 As New MySqlCommand("truncate table dtdb1.ordernumber", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))

                comm1.Connection.Open()
                comm1.ExecuteNonQuery()
                comm1.Connection.Close()

                submitneworder()

                Dim msg1 As String
                Dim title1 As String
                Dim style1 As MsgBoxStyle
                Dim response1 As MsgBoxResult

                msg1 = "Order Number Has Been Reset"   ' Define message.
                style1 = MsgBoxStyle.OkOnly
                title1 = "MsgBox"   ' Define title.
                ' Display message.
                response1 = MsgBox(msg1, style1, title1)
            End If




        End If


    End Sub

    Private Sub ComboBoxNewOrderNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxNewOrderNumber.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBoxNewOrderNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxNewOrderNumber.SelectedIndexChanged

        ordernumber = dict(ComboBoxNewOrderNumber.SelectedItem)

    End Sub
End Class
