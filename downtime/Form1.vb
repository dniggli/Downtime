
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO.StreamWriter
Imports System.Web

Public Class Form1


    Public Shared Valid As Boolean = False
    Public Shared Username As String = ""
    Public Shared query As String = ""

    Dim orderTHREAD As Thread
    Dim chemtrackTHREAD As Thread
    Dim queryTHREAD As Thread
    Dim aliquotTHREAD As Thread
    Dim autolabTHREAD As Thread
    Dim addonTHREAD As Thread
    Dim hemTACKTHREAD As Thread
    Dim urinehemtrackTHREAD As Thread
    Dim urinechemtrackTHREAD As Thread
    Dim CoagtrackTHREAD As Thread
    Dim recoverthread As Thread
    Dim DIEntry As Thread
    Dim molis As Thread




    Private Sub orderent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles orderent.Click
        If orderTHREAD Is Nothing Then
            orderTHREAD = New Thread(AddressOf orderentry.Order)
            orderTHREAD.SetApartmentState(ApartmentState.STA)
            orderTHREAD.Start()
        ElseIf Not orderTHREAD.IsAlive Then
            orderTHREAD = New Thread(AddressOf orderentry.Order)
            orderTHREAD.SetApartmentState(ApartmentState.STA)
            orderTHREAD.Start()
        End If
    End Sub

    Private Sub archtrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles archtrack.Click



        If chemtrackTHREAD Is Nothing Then
            chemtrackTHREAD = New Thread(AddressOf TrackSMSfrom.Tracking)
            chemtrackTHREAD.Start()
        ElseIf Not chemtrackTHREAD.IsAlive Then
            chemtrackTHREAD = New Thread(AddressOf TrackSMSfrom.Tracking)
            chemtrackTHREAD.Start()
        End If
    End Sub

    Private Sub query1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)





    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Select Case Me.ComboBox1.Text
            Case "STAT Query"
                runqueryForm("SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.RECEIVETIME, Table1.LOCATION, Table1.PRIORITY, Table1.LASTNAME, Table1.BLUETEST, Table1.REDTEST, Table1.LAVHEMTEST, Table1.GREENTEST, Table1.OTHERTEST, Table1.LAVCHEMTEST, Table1.GRYTEST, Table1.URINEHEM, Table1.URINECHEM, Table1.BLOODGAS, Table1.TECHID, Table1.CALLS FROM dtdb1.Table1 GROUP BY Table1.COLLECTIONTIME, Table1.RECEIVETIME, Table1.LOCATION, Table1.PRIORITY, Table1.LASTNAME, Table1.BLUETEST, Table1.REDTEST, Table1.LAVHEMTEST, Table1.GREENTEST, Table1.LAVCHEMTEST, Table1.GRYTEST, Table1.URINEHEM, Table1.URINECHEM, Table1.BLOODGAS, Table1.TECHID, Table1.CALLS HAVING(((Table1.PRIORITY) Like ""S"")) ORDER BY Table1.ordernumber;", "STAT Query")
            Case "Last Name Query"
                Dim Lname As String = InputBox("LastName", "EnterLastName")
                runqueryForm("SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.LOCATION, Table1.PRIORITY, Table1.FIRSTNAME, Table1.LASTNAME, Table1.CALLS, Table1.REDTEST, Table1.LAVCHEMTEST, Table1.BLUETEST, Table1.LAVHEMTEST, Table1.GREENTEST, Table1.GRYTEST, Table1.URINEHEM, Table1.URINECHEM, Table1.BLOODGAS, Table1.TECHID, Table1.ORDERCOMMENT FROM(Table1) WHERE Table1.LASTNAME='" & Lname & "' ORDER BY ID;", "Last Name Query")
            Case "Tracking Query"
                Dim ordernum As String = InputBox("ordernumber", "enterordernumber")
                If ordernum = "*" Then
                    runqueryForm("SELECT * FROM dtdb1.dttracking where tracklocation = 'OT->STOR';", "Tracking Query")
                Else
                    runqueryForm("SELECT dttracking.ordernumber, dttracking.TRACKING, dttracking.TRACKINGCOMMENT, dttracking.tracklocation, dttracking.TIMESTAMP, dttracking.tracktechid FROM (dttracking) where dttracking.ordernumber = '" & ordernum & "';", "Tracking Query")
                End If
            Case "Med Req Query"
                Dim medreq As String = InputBox("Med Req Number (Must Enter All 12 Digits - ############)", "EnterMedReqNumber")
                runqueryForm("SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.LOCATION, Table1.PRIORITY, Table1.MRN, Table1.FIRSTNAME, Table1.LASTNAME,Table1.CALLS, Table1.REDTEST, Table1.LAVCHEMTEST, Table1.BLUETEST, Table1.LAVHEMTEST, Table1.GREENTEST, Table1.GRYTEST, Table1.URINEHEM, Table1.URINECHEM, Table1.BLOODGAS, Table1.OTHERTEST, Table1.TECHID, Table1.ORDERCOMMENT FROM dtdb1.Table1 where Table1.MRN = '" & medreq & "';", "Med Req Query")
            Case "Coag Query"
                runqueryForm("SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.LOCATION, Table1.PRIORITY, Table1.FIRSTNAME, Table1.LASTNAME, Table1.CALLS, Table1.BLUETEST, Table1.OTHERTEST, Table1.ORDERCOMMENT FROM dtdb1.Table1 where BLUETEST <> '' ;", "Coag Query")
            Case "Chemistry Query"
                runqueryForm("SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.LOCATION, Table1.PRIORITY, Table1.FIRSTNAME, Table1.LASTNAME, Table1.CALLS, Table1.REDTEST, Table1.LAVCHEMTEST, Table1.GREENTEST, Table1.GRYTEST, Table1.OTHERTEST, Table1.TECHID, Table1.ORDERCOMMENT FROM dtdb1.Table1 where REDTEST <> '' or LAVCHEMTEST <> '' OR GREENTEST <> '' or GRYTEST <> '' ;", "Chemistry Query")
            Case "Bloodgas Query"
                query = "SELECT T.ordernumber, T.COLLECTIONTIME, T.LOCATION, T.PRIORITY, T.FIRSTNAME, T.LASTNAME, T.CALLS, T.BLOODGAS, T.OTHERTEST, T.TECHID, T.ORDERCOMMENT FROM dtdb1.Table1 T where BLOODGAS <> '';"
                runqueryForm(query, "Bloodgas Query")
            Case "Hematology Query"
                query = "SELECT T.ordernumber, T.COLLECTIONTIME, T.LOCATION, T.PRIORITY, T.FIRSTNAME, T.LASTNAME, T.CALLS, T.LAVHEMTEST, T.OTHERTEST, T.TECHID, T.ORDERCOMMENT FROM dtdb1.Table1 T where LAVHEMTEST <> '';"
                runqueryForm(query, "Hematology Query")
            Case "Urinalisys Query"
                query = "SELECT T.ordernumber, T.COLLECTIONTIME, T.LOCATION, T.PRIORITY, T.FIRSTNAME, T.LASTNAME, T.CALLS, T.URINEHEM, T.FLUIDTEST, T.CSFTEST, T.OTHERTEST, T.TECHID FROM dtdb1.Table1 T where URINEHEM <> '' OR FLUIDTEST <> '' OR CSFTEST <> '';"
                runqueryForm(query, "Urinalisys Query")
        End Select




    End Sub

    Sub runqueryForm(ByVal q As String, ByVal Queryname As String)

        Dim args As New Hashtable
        args.Add("Query", q)
        args.Add("QueryName", Queryname)

        Dim QUERYTHREAD As Thread
        ' If queryTHREAD Is Nothing Then
        QUERYTHREAD = New Thread(AddressOf statorderqueryform.ThreadStart)
        QUERYTHREAD.Start(args)
        ' ElseIf Not queryTHREAD.IsAlive Then
        'queryTHREAD = New Thread(AddressOf statorderqueryform.ThreadStart)
        'queryTHREAD.Start(q)
        'End If

    End Sub



    Private Sub autolab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles autolab.Click
        If autolabTHREAD Is Nothing Then
            autolabTHREAD = New Thread(AddressOf autolabaliquotform.autolab)
            autolabTHREAD.SetApartmentState(ApartmentState.STA)
            autolabTHREAD.Start()

        ElseIf Not autolabTHREAD.IsAlive Then
            autolabTHREAD = New Thread(AddressOf autolabaliquotform.autolab)
            autolabTHREAD.SetApartmentState(ApartmentState.STA)
            autolabTHREAD.Start()

        End If
    End Sub

    Private Sub aliquot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aliquot.Click
        If aliquotTHREAD Is Nothing Then
            aliquotTHREAD = New Thread(AddressOf aliquotform.aliquot)
            aliquotTHREAD.SetApartmentState(ApartmentState.STA)
            aliquotTHREAD.Start()
        ElseIf Not aliquotTHREAD.IsAlive Then
            aliquotTHREAD = New Thread(AddressOf aliquotform.aliquot)
            aliquotTHREAD.SetApartmentState(ApartmentState.STA)
            aliquotTHREAD.Start()
        End If
    End Sub

    Private Sub addon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addon.Click
        If addonTHREAD Is Nothing Then
            addonTHREAD = New Thread(AddressOf Addons.addon)
            addonTHREAD.SetApartmentState(ApartmentState.STA)
            addonTHREAD.Start()
        ElseIf Not addonTHREAD.IsAlive Then
            addonTHREAD = New Thread(AddressOf Addons.addon)
            addonTHREAD.SetApartmentState(ApartmentState.STA)
            addonTHREAD.Start()
        End If
    End Sub

    Private Sub hemtrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hemtrack.Click
        If hemTACKTHREAD Is Nothing Then
            hemTACKTHREAD = New Thread(AddressOf Trackhemfrom.Tracking1)
            hemTACKTHREAD.Start()
        ElseIf Not hemTACKTHREAD.IsAlive Then
            hemTACKTHREAD = New Thread(AddressOf Trackhemfrom.Tracking1)
            hemTACKTHREAD.Start()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If urinehemtrackTHREAD Is Nothing Then
            urinehemtrackTHREAD = New Thread(AddressOf Trackurinehemfrom.Tracking2)
            urinehemtrackTHREAD.Start()
        ElseIf Not urinehemtrackTHREAD.IsAlive Then
            urinehemtrackTHREAD = New Thread(AddressOf Trackurinehemfrom.Tracking2)
            urinehemtrackTHREAD.Start()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If urinechemtrackTHREAD Is Nothing Then
            urinechemtrackTHREAD = New Thread(AddressOf Trackurinechemfrom.Tracking4)
            urinechemtrackTHREAD.Start()
        ElseIf Not urinechemtrackTHREAD.IsAlive Then
            urinechemtrackTHREAD = New Thread(AddressOf Trackurinechemfrom.Tracking4)
            urinechemtrackTHREAD.Start()
        End If
    End Sub

    Private Sub buttoncoagtrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncoagtrack.Click
        If CoagtrackTHREAD Is Nothing Then
            CoagtrackTHREAD = New Thread(AddressOf Trackcoagfrom.Tracking1)
            CoagtrackTHREAD.Start()
        ElseIf Not CoagtrackTHREAD.IsAlive Then
            CoagtrackTHREAD = New Thread(AddressOf Trackcoagfrom.Tracking1)
            CoagtrackTHREAD.Start()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult

        msg = "Must enter user name 'URMCLAB' with NO password!" ' Define message.
        style = MsgBoxStyle.DefaultButton1
        title = "MsgBox"   ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)



        Dim Login As New LoginForm2
        Dim F1 As New restartwheel

        Login.ShowDialog()
        If Valid Then
            Valid = False
            F1.ShowDialog()
        End If



    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        orderentry.Tdate = Date.Now.Day
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If recoverthread Is Nothing Then
            recoverthread = New Thread(AddressOf RecoveryForm.autoit)
            recoverthread.Start()
        ElseIf Not recoverthread.IsAlive Then
            recoverthread = New Thread(AddressOf RecoveryForm.autoit)
            recoverthread.Start()
        End If
    End Sub

    Private Sub ButtonDI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDI.Click
        If DIEntry Is Nothing Then
            DIEntry = New Thread(AddressOf DIOrderEntryForm.DIRecover)
            DIEntry.Start()
        ElseIf Not DIEntry.IsAlive Then
            DIEntry = New Thread(AddressOf DIOrderEntryForm.DIRecover)
            DIEntry.Start()
        End If
    End Sub

    Private Sub ButtonMolis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMolis.Click
        If molis Is Nothing Then
            molis = New Thread(AddressOf MolisEntry.MolisEnter)
            molis.Start()
        ElseIf Not molis.IsAlive Then
            molis = New Thread(AddressOf MolisEntry.MolisEnter)
            molis.Start()
        End If
    End Sub
End Class

