Class Trackhemfrom

    ''' <summary>
    ''' Starts the Tracking Thread
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Tracking1()
        Dim Track As New Trackhemfrom
        Application.Run(Track)

    End Sub

    Sub writeDowntimeTable2()
        Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz"
        Dim ran As New Random
        Dim length As Integer = ran.Next(0, 20) ' get a random length

        Dim ranletter As String = alphabet.Substring(ran.Next(0, 25), 1)




        Dim ordernumber1 As String = String.Empty
        Dim trackcomnt As String = String.Empty
        Dim tracktag As String = String.Empty
        Dim trakloct As String = String.Empty
        Dim trcktech As String = String.Empty

        ordernumber1 = ORDERNUMBER.Text
        trackcomnt = trackcomment.Text
        tracktag = tracktagbox.Text
        trakloct = trklocatn.Text
        trcktech = Techidbox.Text




        Dim comm As New MySqlCommand("insert into dtdb1.dttracking (ordernumber,TRACKING,TRACKINGCOMMENT,tracklocation,tracktechid)VALUES('" _
                           & ordernumber1 & "','" & tracktag & "','" & trackcomnt & "','" & trakloct & "','" & trcktech & "')", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))


        comm.Connection.Open()
        comm.ExecuteNonQuery()
        comm.Connection.Close()

    End Sub


    Sub writeDowntimeTable()
        Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz"
        Dim ran As New Random
        Dim length As Integer = ran.Next(0, 20) ' get a random length

        Dim ranletter As String = alphabet.Substring(ran.Next(0, 25), 1)




        Dim ordernumber1 As String = String.Empty
        Dim trackcomnt As String = String.Empty
        Dim tracktag As String = String.Empty
        Dim trakloct As String = String.Empty
        Dim trcktech As String = String.Empty

        ordernumber1 = ORDERNUMBER.Text
        trackcomnt = trackcomment.Text
        tracktag = tracktagbox.Text
        trakloct = trklocatn.Text
        trcktech = Techidbox.Text


        Dim comm As New MySqlCommand("update dtdb1.dttracking set ordernumber = ?ordernumber,TRACKING= '" & tracktag & "',TRACKINGCOMMENT='" & trackcomnt & "',tracklocation = '" & trakloct & "', tracktechid = '" & trcktech & "'  WHERE ordernumber = '" & ordernumber1 & "' and tracklocation = '" & trakloct & "'", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))

        comm.Parameters.AddWithValue("?ordernumber", ordernumber1)


        'Dim comm As New MySqlCommand("insert into dtdb1.dttracking (ordernumber,TRACKING,TRACKINGCOMMENT,tracklocation,tracktechid)VALUES('" _
        '& ordernumber1 & "','" & tracktag & "','" & trackcomnt & "','" & trakloct & "','" & trcktech & "')", New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))


        comm.Connection.Open()
        comm.ExecuteNonQuery()
        comm.Connection.Close()

        ORDERNUMBER.Focus()

    End Sub

    Sub readDowntimeTable()
        SUBMITTRACK.Focus()
        Dim da As New MySqlDataAdapter("select * from dtdb1.dttracking where ordernumber like '" & Me.ORDERNUMBER.Text & "' and tracklocation like '" & Me.trklocatn.Text & "' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim t As New DataTable

        da.Fill(t)

        Dim r As DataRow
        Try
            r = t.Rows(0)
        Catch ex As Exception

            Exit Sub
        End Try

        ORDERNUMBER.Text = r("ordernumber").ToString
        OLDTRACKTAG.Text = r("tracking").ToString
        oldtrackingcomment.Text = r("trackingcomment").ToString
        OLDTECH.Text = r("tracktechid").ToString
        OLDTRKLOCATN.Text = r("tracklocation").ToString
        If Me.OLDTRACKTAG.Text = OLDTRACKTAG.Text Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "Do you wish to edit tracking information?"   ' Define message.
            style = MsgBoxStyle.YesNo
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Yes Then trackcomment.Focus()
            If response = MsgBoxResult.No Then msgboxno()
        End If
        trackcomment.Text = OLDTRACKTAG.Text + "," + oldtrackingcomment.Text

        Application.DoEvents()   'Display the changes immediately (redraw the label text)
        System.Threading.Thread.Sleep(500) 'do it slow enough so we can actually read the text before it changes, pause half a second

    End Sub

    Sub Techid1()

        Techidbox.Text = main.Username

    End Sub

    Sub readtracking1()
        SUBMITTRACK.Visible = True
        readDowntimeTable()
        Techid1()

    End Sub


    Sub msgboxno()
        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C
                If TB Is Me.tracktagbox Then
                    Dim tag As String = TB.Text
                    TB.Text = tag
                    Continue For
                End If
                TB.Clear()
            End If
        Next
    End Sub


    Sub trackmsgbox()
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult

        msg = "Track Tag Does Not Match Expected Format"   ' Define message.
        style = MsgBoxStyle.OkOnly
        title = "MsgBox"   ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)

        If response = MsgBoxResult.Ok Then Exit Sub
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackcomment.TextChanged

    End Sub



    Private Sub SUBMITTRACK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUBMITTRACK.Click


        If tracktagbox.Text = String.Empty Then
            MsgBox("track tag missing", MsgBoxStyle.OkOnly, "MsgBox")

            Exit Sub
        End If
        If trklocatn.Text = String.Empty Then
            MsgBox("no tracking location selected", MsgBoxStyle.OkOnly, "MsgBox")

            Exit Sub
        End If

        'If tracktagbox.Text.Length <> 5 Then
        'Dim msg As String
        'Dim title As String
        'Dim style As MsgBoxStyle
        'Dim response As MsgBoxResult

        'msg = "Track Tag Does Not Match Expected Format"   ' Define message.
        'style = MsgBoxStyle.OkOnly
        'title = "MsgBox"   ' Define title.
        ' Display message.
        'response = MsgBox(msg, style, title)

        'If response = MsgBoxResult.Ok Then Exit Sub
        'End If
        If trackcomment.Text = String.Empty Then
            writeDowntimeTable2()
        End If

        If Not trackcomment.Text = String.Empty Then
            writeDowntimeTable()
        End If

        For Each C As Control In Me.Controls
            If TypeOf C Is TextBox Then
                Dim TB As TextBox = C

                If TB Is Me.tracktagbox Then


                    Dim tracktag As String = TB.Text
                    Dim subTRACKTAG As Integer = Microsoft.VisualBasic.Right(tracktag, 4)
                    Dim subtracktag1 As String = Microsoft.VisualBasic.Left(tracktag, 1)
                    subTRACKTAG += 1


                    Dim subTRACKTAG_increment As String = subTRACKTAG

                    While subTRACKTAG_increment.ToString.Length < 4
                        subTRACKTAG_increment = "0" & subTRACKTAG_increment
                    End While


                    TB.Text = subtracktag1 + subTRACKTAG_increment

                    Continue For
                End If

                TB.Clear()
            End If
        Next
        ORDERNUMBER.Enabled = True
        ORDERNUMBER.Focus()
    End Sub

    Sub ORDERNUMBER_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SUBMITTRACK.KeyPress, ORDERNUMBER.KeyPress

        If e.KeyChar = Chr(13) Then
            trackcheck()
        End If

    End Sub

    Sub trackcheck()
        SUBMITTRACK.Enabled = True
        If tracktagbox.Text = String.Empty Then
            checktracktag()
        End If
        If ORDERNUMBER.Text.Length = 10 Then
            readDowntimeTable()
            tracktagbox.Focus()
        End If
    End Sub
    Private Sub ORDERNUMBER_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ORDERNUMBER.TextChanged
        'SUBMITTRACK.Enabled = True
        'If (ORDERNUMBER.Text.Length = 10 And tracktagbox.Text = String.Empty) Then
        '    checktracktag()
        'End If
        'If ORDERNUMBER.Text.Length = 10 Then
        '    readDowntimeTable()
        '    tracktagbox.Focus()
        'End If

        'Dim locat As String = Microsoft.VisualBasic.Right(ORDERNUMBER.Text, 2)
        'If locat = "23" Then trklocatn.Text = "Coag Storage"
        'If locat = "00" Then trklocatn.Text = "Chem Storage"
        'If locat = "40" Then trklocatn.Text = "Chem Storage"
        'If locat = "79" Then trklocatn.Text = "Chem Storage"
        'If locat = "19" Then trklocatn.Text = "Chem Storage"
        'If locat = "27" Then trklocatn.Text = "Chem Storage"
        'If locat = "18" Then trklocatn.Text = "Hematology storage"
    End Sub

    Sub checktracktag()
        Dim ch As New MySqlDataAdapter("select tracking from dtdb1.dttracking where ordernumber like '" & Me.ORDERNUMBER.Text & "' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
        Dim n As New DataTable
        ORDERNUMBER.Enabled = False

        ch.Fill(n)

        Try
            Dim q As DataRow = n.Rows(0)



        Catch msgbox As Exception
        End Try

        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult

        msg = "enter requierd info in Track Tag feild."   ' Define message.
        style = MsgBoxStyle.OkOnly
        title = "MsgBox"   ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Ok Then
            tracktagbox.Focus()

        End If
        tracktagbox.Focus()

        Exit Sub



    End Sub

    Sub locattrack()

        With trklocatn

        End With
    End Sub




    Private Sub tracktagbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tracktagbox.TextChanged

    End Sub

    Private Sub Techidbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Techidbox.TextChanged
        Techidbox.Text = main.Username
    End Sub

    Sub tracktag_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tracktagbox.KeyPress

        If e.KeyChar = Chr(13) Then
            SUBMITTRACK_Click(Me, EventArgs.Empty)
        End If

    End Sub



    Private Sub MySqlConnectionBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub trklocatn_Selected()
        Dim da As New MySqlDataAdapter("select * from dtdb1.dttracking.tracklocation", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        locattrack()
    End Sub

    Private Sub trklocatn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trklocatn.SelectedIndexChanged
        If (trklocatn.Text = "SHEME->STOR" Or trklocatn.Text = "COAG->STOR") Then
            trackcomment.Enabled = True
            tracktagbox.Enabled = True
            ORDERNUMBER.Enabled = True
        End If
    End Sub
End Class
