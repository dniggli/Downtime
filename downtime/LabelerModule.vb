﻿Imports Microsoft.Win32.RegistryHive
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Module Labeler
    Class LabelData
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


    End Class


    '................/////////////////// THIS PRINTS COLLECTION LABLES FOR TUBES \\\\\\\\\\\\\\\\\\\\\\\..........................


    Sub LabelPrint(ByVal ldata As LabelData, ByVal printer As String)
        Dim sTemplatelines As New ArrayList


        Dim label As String

        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS" & vbNewLine
        label += "^FO  0, 15,^A0B,29        ^FD" & ldata.orderNumber.Substring(4) & "^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FD" & ldata.orderNumber & "-" & ldata.extension & "^FS" & vbNewLine
        If ldata.priority = "STAT" Then
            label += "^FO260, 3                 ^GB 60, 13,35,,100^FS"
        End If
        label += "^FO260, 13,^A0,28         ^FR^FD" & ldata.priority & "^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FD" & ldata.lastname & "," & ldata.firstname & "^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FD" & ldata.medreqnum & "^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*" & ldata.specimenType & "*/" & ldata.location & "^FS" & vbNewLine
        If ldata.testlist.Length > 37 Then
            label += "^FO  0, 92,^AB            ^FD" & ldata.testlist.Substring(0, 37) & "^FS" & vbNewLine

        Else
            label += "^FO  0, 92,^AB            ^FD" & ldata.testlist & "^FS" & vbNewLine
        End If
        label += "^FO  0,107,^AB            ^FD^FS" & vbNewLine
        label += "^FO  0,122,^AB            ^FD^FS" & vbNewLine
        If ldata.testlist.Length > 74 Then
            label += "^FO  0, 112,^AB            ^FD" & ldata.testlist.Substring(37, 34) & "...^FS" & vbNewLine

        ElseIf ldata.testlist.Length > 37 Then
            label += "^FO  0, 112,^AB            ^FD" & ldata.testlist.Substring(37) & "^FS" & vbNewLine



        End If
        label += "^FO365,100,^A0,40         ^FD*" & ldata.specimenType & "*^FS" & vbNewLine
        label += vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FO0025,137,^BC,,N,,,A,^FD" & ldata.orderNumber & ldata.extension & "^FS" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine
        label += "^XZ" & vbNewLine



      


        orderentry.strNecessary.Append(label)


    End Sub


    '................/////////////////// THIS PRINTS COMMENT LABLES \\\\\\\\\\\\\\\\\\\\\\\..........................

    Sub LabelPrint1(ByVal ldata1 As LabelData, ByVal printer As String)
        Dim sTemplatelines As New ArrayList


        Dim label As String

        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS" & vbNewLine
        label += "^FO  0, 15,^A0B,29        ^FD" & ldata1.orderNumber.Substring(4) & "^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FD" & ldata1.orderNumber & "" & ldata1.extension & "^FS" & vbNewLine
        If ldata1.priority = "STAT" Then
            label += "^FO260, 3                 ^GB 60, 13,35,,100^FS"
        End If
        label += "^FO260, 13,^A0,28,^FR     ^FD" & ldata1.priority & "^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FD" & ldata1.lastname & "," & ldata1.firstname & "^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FD" & ldata1.medreqnum & "^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*" & ldata1.specimenType & "*/" & ldata1.location & "^FS" & vbNewLine
        label += "^FO  0, 92,^AB            ^FD" & ldata1.testlist & "^FS" & vbNewLine
        label += "^FO  0,107,^AB            ^FD^FS" & vbNewLine
        label += "^FO  0,122,^AB            ^FD^FS" & vbNewLine
        label += "^FO365,100,^A0,40         ^FD*" & ldata1.specimenType & "*^FS" & vbNewLine
        label += vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine
        label += "^XZ" & vbNewLine





        orderentry.strNecessary.Append(label)



    End Sub




    '................/////////////////// THIS PRINTS DEMOGRAPHIC LABLES FOR REQS \\\\\\\\\\\\\\\\\\\\\\\..........................


    Sub LabelPrint2(ByVal ldata2 As LabelData, ByVal printer As String)
        Dim sTemplatelines As New ArrayList


        Dim label As String


        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS" & vbNewLine
        label += "^FO  0, 15,^A0B,29        ^FD" & ldata2.orderNumber.Substring(4) & "^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FD" & ldata2.orderNumber & "" & ldata2.extension & "^FS" & vbNewLine
        If ldata2.priority = "STAT" Then
            label += "^FO260, 3                 ^GB 60, 13,35,,100^FS"
        End If
        label += "^FO260, 13,^A0,28,^FR     ^FD" & ldata2.priority & "^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FD" & ldata2.lastname & "," & ldata2.firstname & "^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FD" & ldata2.medreqnum & "^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*" & ldata2.specimenType & "*/" & ldata2.location & "^FS" & vbNewLine
        label += "^FO  0, 92,^AB            ^FD^FS" & vbNewLine
        label += "^FO  0,107,^A0,22,20      ^FD" & ldata2.collectiontime & " @ " & ldata2.testlist & " On " & ldata2.todaysdate & "  ^FS" & vbNewLine
        label += "^FO  0,122,^AB            ^FD^FS" & vbNewLine
        label += "^FO365,100,^A0,40         ^FD*" & ldata2.specimenType & "*^FS" & vbNewLine
        label += vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FO0025,137,^B3,N,72,N,^FD" & ldata2.orderNumber & ldata2.extension & "^FS" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine
        label += "^XZ" & vbNewLine





        orderentry.strNecessary.Append(label)

    End Sub




    '............................////////////////////// Prints STAT Aliquot Collection Labels for Tubes(For Aliquotform only) \\\\\\\\\\\\\\\\\\\\.........................

    Sub LabelPrintal1(ByVal ldata As LabelData, ByVal printer As String)
        Dim sTemplatelines As New ArrayList


        Dim label As String

       
        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS" & vbNewLine
        label += "^FO  0, 15,^A0B,29        ^FD" & ldata.orderNumber.Substring(4) & "^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FD" & ldata.orderNumber & "-" & ldata.extension & "^FS" & vbNewLine
        label += "^FO260, 3                 ^GB 60, 13,35,,100^FS"
        label += "^FO260, 13,^A0,28         ^FR^FD" & ldata.priority & "^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FD" & ldata.lastname & "," & ldata.firstname & "^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FD" & ldata.medreqnum & "^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*" & ldata.specimenType & "*/" & ldata.location & "^FS" & vbNewLine
        If ldata.testlist.Length > 37 Then
            label += "^FO  0, 92,^AB            ^FD" & ldata.testlist.Substring(0, 37) & "^FS" & vbNewLine

        Else
            label += "^FO  0, 92,^AB            ^FD" & ldata.testlist & "^FS" & vbNewLine
        End If
        label += "^FO  0,107,^AB            ^FD^FS" & vbNewLine
        label += "^FO  0,122,^AB            ^FD^FS" & vbNewLine
        If ldata.testlist.Length > 74 Then
            label += "^FO  0, 112,^AB            ^FD" & ldata.testlist.Substring(37, 34) & "...^FS" & vbNewLine

        ElseIf ldata.testlist.Length > 37 Then
            label += "^FO  0, 112,^AB            ^FD" & ldata.testlist.Substring(37) & "^FS" & vbNewLine



        End If
        label += "^FO365,60,^A0B,,22,20    ^FD*" & ldata.orderNumber & "*^FS" & vbNewLine
        label += "^FO390,40,^A0B,,17,15    ^FD*" & ldata.lastname & "," & ldata.firstname & "*^FS" & vbNewLine

        label += vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FO0025,137,^BC,,N,,,A,^FD" & ldata.orderNumber & ldata.extension & "^FS" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine
        label += "^BY1,2" & vbNewLine
        label += "^FO420,40,^BCB,,N,       ^FD" & ldata.orderNumber & "^FS" & vbNewLine
        label += "^XZ" & vbNewLine


        orderentry.strNecessary.Append(label)
    End Sub




    '...............//////////////// Print ROUTINE Aliquot Collection Labels for Tubes (For Aliquotform only) \\\\\\\\\\\\\...................


    Sub LabelPrintal2(ByVal ldata As LabelData, ByVal printer As String)
        Dim sTemplatelines As New ArrayList


        Dim label As String

       
        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS" & vbNewLine
        label += "^FO  0, 15,^A0B,29        ^FD" & ldata.orderNumber.Substring(4) & "^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FD" & ldata.orderNumber & "-" & ldata.extension & "^FS" & vbNewLine
        label += "^FO260, 13,^A0,28         ^FR^FD" & ldata.priority & "^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FD" & ldata.lastname & "," & ldata.firstname & "^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FD" & ldata.medreqnum & "^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*" & ldata.specimenType & "*/" & ldata.location & "^FS" & vbNewLine
        If ldata.testlist.Length > 37 Then
            label += "^FO  0, 92,^AB            ^FD" & ldata.testlist.Substring(0, 37) & "^FS" & vbNewLine

        Else
            label += "^FO  0, 92,^AB            ^FD" & ldata.testlist & "^FS" & vbNewLine
        End If
        label += "^FO  0,107,^AB            ^FD^FS" & vbNewLine
        label += "^FO  0,122,^AB            ^FD^FS" & vbNewLine
        If ldata.testlist.Length > 74 Then
            label += "^FO  0, 112,^AB            ^FD" & ldata.testlist.Substring(37, 34) & "...^FS" & vbNewLine

        ElseIf ldata.testlist.Length > 37 Then
            label += "^FO  0, 112,^AB            ^FD" & ldata.testlist.Substring(37) & "^FS" & vbNewLine



        End If

        label += "^FO365,60,^A0B,,22,20    ^FD*" & ldata.orderNumber & "*^FS" & vbNewLine
        label += "^FO390,40,^A0B,,17,15    ^FD*" & ldata.lastname & "," & ldata.firstname & "*^FS" & vbNewLine

        label += vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FO0025,137,^BC,,N,,,A,^FD" & ldata.orderNumber & ldata.extension & "^FS" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine

        label += "^BY1,2" & vbNewLine
        label += "^FO420,40,^BCB,,N,       ^FD" & ldata.orderNumber & "^FS" & vbNewLine
        label += "^XZ" & vbNewLine

       


        orderentry.strNecessary.Append(label)

      
    End Sub
End Module


'Dim printer As New Printer("172.16.60.252", "C42", Application.StartupPath & "\ZebraDriver\zsd.inf", "Zebra  LP2844-Z")
'printer.Add_IP_Port()
'printer.Add()

'make sure to pull the model name straight from the inf file or you may have problems
Class myPrinter

    Private _IPaddress As String
    Private _Name As String
    Private _INFDriverPath As String
    Private _Model As String

    Sub New(ByVal IP As String, ByVal Name As String, ByVal INFDriverPath As String, ByVal Model As String)
        _IPaddress = IP
        _Name = Name
        _INFDriverPath = INFDriverPath
        _Model = Model

    End Sub

    '''' <summary>
    '''' Add Printer IP Port
    '''' </summary>
    '''' <remarks></remarks>
    'Sub Add_IP_Port()
    '    Dim subkey As String = "SYSTEM\CurrentControlSet\Control\Print\Monitors\Standard TCP/IP Port\Ports\IP_" & _IPaddress
    '    WriteToRegistry(LocalMachine, subkey, "Protocol", &H1)
    '    WriteToRegistry(LocalMachine, subkey, "Version", &H1)
    '    WriteToRegistry(LocalMachine, subkey, "HostName", "")
    '    WriteToRegistry(LocalMachine, subkey, "IPAddress", _IPaddress)
    '    WriteToRegistry(LocalMachine, subkey, "HWAddress", "")
    '    WriteToRegistry(LocalMachine, subkey, "PortNumber", &H238C)
    '    WriteToRegistry(LocalMachine, subkey, "SNMP Community", "public")
    '    WriteToRegistry(LocalMachine, subkey, "SNMP Enabled", &H1)
    '    WriteToRegistry(LocalMachine, subkey, "SNMP Index", &H1)

    '    'Now restart print spooler to use new ports
    '    RestartService("Spooler")

    'End Sub
    ''' <summary>
    ''' Add printer and attach to Printer port
    ''' </summary>
    ''' <remarks></remarks>
    Sub Add()
        '        Shell("rundll32 printui.dll,PrintUIEntry /y /if /b ""HP LaserJet 4000""" & _
        '"/f D:\Install\Drivers\HP4000\WinXP\hp222ip6.inf /r ""\\SSMD\""" & pq & _
        '""".Printers.Amsterdam.NL.SSMD"" /m ""HP LaserJet 4000 Series PCL 6""", AppWinStyle.NormalFocus, True)
        Dim shellcmd As String
        ' "/f """ & _INFDriverPath & """ " & _
        shellcmd = "rundll32 printui.dll,PrintUIEntry /if " & _
         "/b """ & _Name & """ " & _
         "/f """ & _INFDriverPath & """ " & _
         "/r ""IP_" & _IPaddress & """ " & _
         "/m """ & _Model & """ /u"
        Shell(shellcmd, _
         AppWinStyle.NormalFocus, True)
    End Sub
    Private Sub RAW_print(ByVal s As String)
        Dim pd As New PrintDialog()

        ' You need a string to send.
        ' Open the printer dialog box, and then allow the user to select a printer.
        pd.PrinterSettings = New PrinterSettings()
        If (pd.ShowDialog() = DialogResult.OK) Then
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s)
        End If
    End Sub
End Class

Public Class RawPrinterHelper
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Structure DOCINFOW
        <MarshalAs(UnmanagedType.LPWStr)> Public pDocName As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pDataType As String
    End Structure

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function OpenPrinter(ByVal src As String, ByRef hPrinter As IntPtr, ByVal pd As Integer) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterW", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, ByRef pDI As DOCINFOW) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", _
       SetLastError:=True, CharSet:=CharSet.Unicode, _
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function is given a printer name and an unmanaged array of  
    ' bytes, the function sends those bytes to the print queue.
    ' Returns True on success or False on failure.
    Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
        Dim hPrinter As IntPtr      ' The printer handle.
        Dim dwError As Int32        ' Last error - in case there was trouble.
        Dim di As DOCINFOW = Nothing         ' Describes your document (name, port, data type).
        Dim dwWritten As Int32      ' The number of bytes written by WritePrinter().
        Dim bSuccess As Boolean     ' Your success code.

        ' Set up the DOCINFO structure.
        With di
            .pDocName = "My Visual Basic .NET RAW Document"
            .pDataType = "RAW"
        End With
        ' Assume failure unless you specifically succeed.
        bSuccess = False
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    ' Write your printer-specific bytes to the printer.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        ' If you did not succeed, GetLastError may give more information
        ' about why not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If
        Return bSuccess
    End Function ' SendBytesToPrinter()

    ' SendFileToPrinter()
    ' When the function is given a file name and a printer name, 
    ' the function reads the contents of the file and sends the
    ' contents to the printer.
    ' Presumes that the file contains printer-ready data.
    ' Shows how to use the SendBytesToPrinter function.
    ' Returns True on success or False on failure.
    Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
        ' Open the file.
        Dim fs As New FileStream(szFileName, FileMode.Open)
        ' Create a BinaryReader on the file.
        Dim br As New BinaryReader(fs)
        ' Dim an array of bytes large enough to hold the file's contents.
        Dim bytes(fs.Length) As Byte
        Dim bSuccess As Boolean
        ' Your unmanaged pointer.
        Dim pUnmanagedBytes As IntPtr

        ' Read the contents of the file into the array.
        bytes = br.ReadBytes(fs.Length)
        ' Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(fs.Length)
        ' Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, fs.Length)
        ' Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, fs.Length)
        ' Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        Return bSuccess
    End Function ' SendFileToPrinter()

    ' When the function is given a string and a printer name,
    ' the function sends the string to the printer as raw bytes.
    Public Shared Sub SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String)
        Dim pBytes As IntPtr
        Dim dwCount As Int32
        ' How many characters are in the string?
        dwCount = szString.Length()
        ' Assume that the printer is expecting ANSI text, and then convert
        ' the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        ' Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
    End Sub
End Class