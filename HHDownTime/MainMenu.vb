Imports System.Threading
Imports System.Drawing.Printing

Public Class MainMenu
    Dim microthread As Thread
    Dim hhthread As Thread


    Private Sub ButtonHH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHH.Click
        If hhthread Is Nothing Then
            hhthread = New Thread(AddressOf Form1.HH)
            hhthread.SetApartmentState(ApartmentState.STA)
            hhthread.Start()
        ElseIf Not hhthread.IsAlive Then
            hhthread = New Thread(AddressOf Form1.HH)
            hhthread.SetApartmentState(ApartmentState.STA)
            hhthread.Start()
        End If
    End Sub

    Private Sub ButtonMic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMic.Click
        If microthread Is Nothing Then
            microthread = New Thread(AddressOf MicroOrdrForm.Micro)
            microthread.SetApartmentState(ApartmentState.STA)
            microthread.Start()
        ElseIf Not microthread.IsAlive Then
            microthread = New Thread(AddressOf MicroOrdrForm.Micro)
            microthread.SetApartmentState(ApartmentState.STA)
            microthread.Start()
        End If
    End Sub

    Private Sub MainMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    

    
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim label As String
        label = "^XA" & vbNewLine
        label += "^FX COLLECTION LABEL ^FS"
        label += "^FO  0, 15,^A0B,29        ^FD4736^FS" & vbNewLine
        label += "^FO 30, 13,^A0,29         ^FDA6054736-10^FS" & vbNewLine
        label += "^FO278, 11,^FS" & vbNewLine
        label += "^FO280, 13,^A0,28,^FR     ^FDR^FS" & vbNewLine
        label += "^FO 30, 42,^A0,28,25      ^FDTESTSAM,STEST^FS" & vbNewLine
        label += "^FO 30, 75,^AB            ^FDM#^FS" & vbNewLine
        label += "^FO 55, 70,^A0,22,20      ^FDX000006^FS" & vbNewLine
        label += "^FO200, 70,^A0,22,20      ^FD*030*/TEST^FS" & vbNewLine
        label += "^FO325, 73,^AD            ^FD^FS" & vbNewLine
        label += "^FO 30, 95,^AB            ^FD08/06/10^FS" & vbNewLine
        label += "^FO130, 95,^AB            ^FDESO#:MRSA^FS" & vbNewLine
        label += "^FO  0, 120,^AB            ^FDLTT ^FS" & vbNewLine
        label += "^FO  0,107,^AB            ^FD^FS" & vbNewLine
        label += "^BY2,2,80" & vbNewLine
        label += "^FO0040,137,^BC,,N,,,A,^FDA605473610^FS" & vbNewLine
        label += "^FT370,160,^AD             ^FD^FS" & vbNewLine
        label += "^FO345,50,^A0B,40         ^FD*030*^FS" & vbNewLine
        label += "^FO380,55,^A0B,20,20      ^FDA6054736^FS" & vbNewLine
        label += "^FT415,200,^A0B,20,17     ^FDTESTSAM,STEST^FS" & vbNewLine
        label += "^BY1,2" & vbNewLine
        label += "^FO420,30,^BCB60,N^FDA6054736^FS" & vbNewLine
        label += "^XZ"
       
        'Dim ofd As New OpenFileDialog()
        'If ofd.ShowDialog(Me) Then
        '    Dim pd As New PrintDialog()
        '    pd.PrinterSettings = New PrinterSettings()
        '    If (pd.ShowDialog() = DialogResult.OK) Then
        '        'Print the file to the printer.
        '        'RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, ofd.FileName)
        RawPrinterHelper.SendStringToPrinter("XX", label)
        '    End If
        'End If

    End Sub
End Class