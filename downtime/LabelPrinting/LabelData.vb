Public Class LabelData
    Public orderNumber As String
    Public location As String
    Public lastname As String
    Public firstname As String
    Public medreqnum As String
    Public testlist As String
    Public extension As String
    Public specimenType As String
    Public collectiontime As String
    Public todaysdate As String
    Public priority As String

    Sub New(ByVal _ordernumber As String, ByVal _tests As String, ByVal _extension As String, ByVal _specimentype As String, ByVal _PRIORITY As String, ByVal _medreqnum As String, ByVal _lastname As String, ByVal _firstname As String, ByVal _location As String, ByVal _collectiontime As String, ByVal _todaysdate As String)
        orderNumber = _ordernumber
        lastname = _lastname
        firstname = _firstname
        medreqnum = _medreqnum
        extension = _extension
        specimenType = _specimentype
        priority = _PRIORITY
        location = _location
        collectiontime = _collectiontime
        todaysdate = _todaysdate
        testlist = _tests



    End Sub

    Sub New(ByVal _ordernumber As String, ByVal _tests As String, ByVal _extension As String, ByVal _specimentype As String, ByVal _PRIORITY As String, ByVal _medreqnum As String, ByVal _lastname As String, ByVal _firstname As String, ByVal _location As String)
        orderNumber = _ordernumber
        extension = _extension
        specimenType = _specimentype
        priority = _PRIORITY
        testlist = _tests
        medreqnum = _medreqnum
        lastname = _lastname
        firstname = _firstname
        location = _location
    End Sub

    Sub New(ByVal _ordernumber As String, ByVal _PRIORITY As String, ByVal _medreqnum As String, ByVal _lastname As String, ByVal _firstname As String, ByVal _location As String)
        orderNumber = _ordernumber
        extension = ""
        specimenType = ""
        priority = _PRIORITY
        testlist = ""
        medreqnum = _medreqnum
        lastname = _lastname
        firstname = _firstname
        location = _location
    End Sub

    ''' <summary>
    ''' THIS PRINTS COLLECTION LABLES FOR TUBES 
    ''' </summary>
    ''' <param name="ldata"></param>
    ''' <param name="printer"></param>
    ''' <remarks></remarks>
    Sub LabelPrint(ByVal printer As String)
        If testlist = String.Empty Then Return
        Dim sTemplatelines As New ArrayList


        Dim label As String

        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS" & vbNewLine
        label += "^FO  0, 15,^A0B,29        ^FD" & orderNumber.Substring(4) & "^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FD" & orderNumber & "-" & extension & "^FS" & vbNewLine
        If priority = "STAT" Then
            label += "^FO260, 3                 ^GB 60, 13,35,,100^FS"
        End If
        label += "^FO260, 13,^A0,28         ^FR^FD" & priority & "^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FD" & lastname & "," & firstname & "^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FD" & medreqnum & "^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*" & specimenType & "*/" & location & "^FS" & vbNewLine
        If testlist.Length > 37 Then
            label += "^FO  0, 92,^AB            ^FD" & testlist.Substring(0, 37) & "^FS" & vbNewLine

        Else
            label += "^FO  0, 92,^AB            ^FD" & testlist & "^FS" & vbNewLine
        End If
        label += "^FO  0,107,^AB            ^FD^FS" & vbNewLine
        label += "^FO  0,122,^AB            ^FD^FS" & vbNewLine
        If testlist.Length > 74 Then
            label += "^FO  0, 112,^AB            ^FD" & testlist.Substring(37, 34) & "...^FS" & vbNewLine

        ElseIf testlist.Length > 37 Then
            label += "^FO  0, 112,^AB            ^FD" & testlist.Substring(37) & "^FS" & vbNewLine



        End If
        label += "^FO365,100,^A0,40         ^FD*" & specimenType & "*^FS" & vbNewLine
        label += vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FO0025,137,^BC,,N,,,A,^FD" & orderNumber & extension & "^FS" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine
        label += "^XZ" & vbNewLine






        OrderEntry.strNecessary.Append(label)


    End Sub


    ''' <summary>
    ''' THIS PRINTS COMMENT LABLES
    ''' </summary>
    ''' <param name="ldata1"></param>
    ''' <param name="printer"></param>
    ''' <remarks></remarks>
    Sub LabelPrint1(ByVal printer As String)
        If testlist = String.Empty Then Return
        Dim sTemplatelines As New ArrayList


        Dim label As String

        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS" & vbNewLine
        label += "^FO  0, 15,^A0B,29        ^FD" & orderNumber.Substring(4) & "^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FD" & orderNumber & "" & extension & "^FS" & vbNewLine
        If priority = "STAT" Then
            label += "^FO260, 3                 ^GB 60, 13,35,,100^FS"
        End If
        label += "^FO260, 13,^A0,28,^FR     ^FD" & priority & "^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FD" & lastname & "," & firstname & "^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FD" & medreqnum & "^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*" & specimenType & "*/" & location & "^FS" & vbNewLine
        label += "^FO  0, 92,^AB            ^FD" & testlist & "^FS" & vbNewLine
        label += "^FO  0,107,^AB            ^FD^FS" & vbNewLine
        label += "^FO  0,122,^AB            ^FD^FS" & vbNewLine
        label += "^FO365,100,^A0,40         ^FD*" & specimenType & "*^FS" & vbNewLine
        label += vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine
        label += "^XZ" & vbNewLine





        OrderEntry.strNecessary.Append(label)



    End Sub

    ''' <summary>
    ''' THIS PRINTS DEMOGRAPHIC LABLES FOR REQS
    ''' </summary>
    ''' <param name="ldata2"></param>
    ''' <param name="printer"></param>
    ''' <remarks></remarks>
    Sub LabelPrint2(ByVal printer As String)
        If testlist = String.Empty Then Return

        Dim sTemplatelines As New ArrayList


        Dim label As String


        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS" & vbNewLine
        label += "^FO  0, 15,^A0B,29        ^FD" & orderNumber.Substring(4) & "^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FD" & orderNumber & "" & extension & "^FS" & vbNewLine
        If priority = "STAT" Then
            label += "^FO260, 3                 ^GB 60, 13,35,,100^FS"
        End If
        label += "^FO260, 13,^A0,28,^FR     ^FD" & priority & "^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FD" & lastname & "," & firstname & "^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FD" & medreqnum & "^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*" & specimenType & "*/" & location & "^FS" & vbNewLine
        label += "^FO  0, 92,^AB            ^FD^FS" & vbNewLine
        label += "^FO  0,107,^A0,22,20      ^FD" & collectiontime & " @ " & testlist & " On " & todaysdate & "  ^FS" & vbNewLine
        label += "^FO  0,122,^AB            ^FD^FS" & vbNewLine
        label += "^FO365,100,^A0,40         ^FD*" & specimenType & "*^FS" & vbNewLine
        label += vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FO0025,137,^B3,N,72,N,^FD" & orderNumber & extension & "^FS" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine
        label += "^XZ" & vbNewLine
        OrderEntry.strNecessary.Append(label)
    End Sub

    ''' <summary>
    ''' Prints STAT Aliquot Collection Labels for Tubes(For Aliquotform only)
    ''' </summary>
    ''' <param name="ldata"></param>
    ''' <param name="printer"></param>
    ''' <remarks></remarks>
    Sub LabelPrintal1(ByVal printer As String)
        If testlist = String.Empty Then Return
        Dim sTemplatelines As New ArrayList


        Dim label As String


        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS" & vbNewLine
        label += "^FO  0, 15,^A0B,29        ^FD" & orderNumber.Substring(4) & "^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FD" & orderNumber & "-" & extension & "^FS" & vbNewLine
        label += "^FO260, 3                 ^GB 60, 13,35,,100^FS"
        label += "^FO260, 13,^A0,28         ^FR^FD" & priority & "^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FD" & lastname & "," & firstname & "^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FD" & medreqnum & "^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*" & specimenType & "*/" & location & "^FS" & vbNewLine
        If testlist.Length > 37 Then
            label += "^FO  0, 92,^AB            ^FD" & testlist.Substring(0, 37) & "^FS" & vbNewLine

        Else
            label += "^FO  0, 92,^AB            ^FD" & testlist & "^FS" & vbNewLine
        End If
        label += "^FO  0,107,^AB            ^FD^FS" & vbNewLine
        label += "^FO  0,122,^AB            ^FD^FS" & vbNewLine
        If testlist.Length > 74 Then
            label += "^FO  0, 112,^AB            ^FD" & testlist.Substring(37, 34) & "...^FS" & vbNewLine

        ElseIf testlist.Length > 37 Then
            label += "^FO  0, 112,^AB            ^FD" & testlist.Substring(37) & "^FS" & vbNewLine



        End If
        label += "^FO365,60,^A0B,,22,20    ^FD*" & orderNumber & "*^FS" & vbNewLine
        label += "^FO390,40,^A0B,,17,15    ^FD*" & lastname & "," & firstname & "*^FS" & vbNewLine

        label += vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FO0025,137,^BC,,N,,,A,^FD" & orderNumber & extension & "^FS" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine
        label += "^BY1,2" & vbNewLine
        label += "^FO420,40,^BCB,,N,       ^FD" & orderNumber & "^FS" & vbNewLine
        label += "^XZ" & vbNewLine


        OrderEntry.strNecessary.Append(label)
    End Sub

    ''' <summary>
    ''' Print ROUTINE Aliquot Collection Labels for Tubes (For Aliquotform only)
    ''' </summary>
    ''' <param name="ldata"></param>
    ''' <param name="printer"></param>
    ''' <remarks></remarks>
    Sub LabelPrintal2(ByVal printer As String)
        If testlist = String.Empty Then Return
        Dim sTemplatelines As New ArrayList


        Dim label As String


        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS" & vbNewLine
        label += "^FO  0, 15,^A0B,29        ^FD" & orderNumber.Substring(4) & "^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FD" & orderNumber & "-" & extension & "^FS" & vbNewLine
        label += "^FO260, 13,^A0,28         ^FR^FD" & priority & "^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FD" & lastname & "," & firstname & "^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FD" & medreqnum & "^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*" & specimenType & "*/" & location & "^FS" & vbNewLine
        If testlist.Length > 37 Then
            label += "^FO  0, 92,^AB            ^FD" & testlist.Substring(0, 37) & "^FS" & vbNewLine

        Else
            label += "^FO  0, 92,^AB            ^FD" & testlist & "^FS" & vbNewLine
        End If
        label += "^FO  0,107,^AB            ^FD^FS" & vbNewLine
        label += "^FO  0,122,^AB            ^FD^FS" & vbNewLine
        If testlist.Length > 74 Then
            label += "^FO  0, 112,^AB            ^FD" & testlist.Substring(37, 34) & "...^FS" & vbNewLine

        ElseIf testlist.Length > 37 Then
            label += "^FO  0, 112,^AB            ^FD" & testlist.Substring(37) & "^FS" & vbNewLine



        End If

        label += "^FO365,60,^A0B,,22,20    ^FD*" & orderNumber & "*^FS" & vbNewLine
        label += "^FO390,40,^A0B,,17,15    ^FD*" & lastname & "," & firstname & "*^FS" & vbNewLine

        label += vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FO0025,137,^BC,,N,,,A,^FD" & orderNumber & extension & "^FS" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine

        label += "^BY1,2" & vbNewLine
        label += "^FO420,40,^BCB,,N,       ^FD" & orderNumber & "^FS" & vbNewLine
        label += "^XZ" & vbNewLine




        OrderEntry.strNecessary.Append(label)


    End Sub


    Function setTestsExtensionSpecimenType(ByVal tests As String, ByVal extension As String, ByVal st As String) As LabelData
        Return New LabelData(orderNumber, tests, extension, st, priority, medreqnum, lastname, firstname, location, collectiontime, todaysdate)
    End Function





End Class
