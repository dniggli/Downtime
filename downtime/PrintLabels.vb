Imports CodeBase2.MySql.URMC
Public Module PrintLabels

    Sub apply(ByVal printer As String)
        'RawPrinterHelper.SendStringToPrinter(printer, orderentry.strNecessary.ToString)
        Dim NameToIP As Dictionary(Of String, String) = Send_IP_Printer.GetLabelersListOfIPs_byGroup("/Strong/Specimen Management")
        Dim PrinterDNSName As String = NameToIP(printer.ToUpper).ToString
        If Not PrinterDNSName.Contains(".") Then
            printer = CodeBase2.DNS.NameToIPString(PrinterDNSName)
            Send_IP_Printer.PrintLabel(printer, orderentry.strNecessary.ToString)
        Else
            Send_IP_Printer.PrintLabel(NameToIP(printer.ToUpper), orderentry.strNecessary.ToString)
        End If
    End Sub
End Module
