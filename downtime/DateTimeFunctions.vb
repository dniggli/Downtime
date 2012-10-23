Imports System.Text.RegularExpressions
Imports CodeBase2.Databases
Imports MySql.Data.MySqlClient

Public Module DateTimeFunctions
    ''' <summary>
    ''' Convert to Date for entry into MySQL
    ''' </summary>
    ''' <param name="mysqldate">mysql Date</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function datetomysql(ByVal mysqldate As String) As String

        Dim newdate As Match = Regex.Match(mysqldate, "([0-9]+)/([0-9]+)/([0-9]+)")
        Dim month1 As String = newdate.Groups(1).Value
        Dim day1 As String = newdate.Groups(2).Value
        Dim year1 As String = newdate.Groups(3).Value
        Dim newdate1 As String = String.Empty

        month1 = month1.PadLeft(2, "0"c)

        While day1.Length < 2
            day1 = "0" & day1
        End While

        Return year1 + "-" + month1 + "-" + day1


    End Function
    Public Function datetoordentry(ByVal mysqldate As String) As String

        Dim newdate As Match = Regex.Match(mysqldate, "([0-9]+)/([0-9]+)/([0-9]+)")
        Dim month1 As String = newdate.Groups(1).Value
        Dim day1 As String = newdate.Groups(2).Value
        Dim year1 As String = newdate.Groups(3).Value
        Dim newdate1 As String = String.Empty

        month1 = month1.PadLeft(2, "0"c)

        While day1.Length < 2
            day1 = "0" & day1
        End While

        Return month1 + day1


    End Function
    Public Function dateToSoftPath(ByVal mysqldate As String) As String

        Dim newdate As Match = Regex.Match(mysqldate, "([0-9]+)/([0-9]+)/([0-9]+)")
        Dim month1 As String = newdate.Groups(1).Value
        Dim day1 As String = newdate.Groups(2).Value
        Dim year1 As String = newdate.Groups(3).Value
        Dim newdate1 As String = String.Empty

        month1 = month1.PadLeft(2, "0"c)

        While day1.Length < 2
            day1 = "0" & day1
        End While

        Return year1 + month1 + day1


    End Function

    Public Function datetimeintomysql(ByVal mysqldatetime As String) As String
        Dim dates As String() = mysqldatetime.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

        Dim oldcoldate As Match = Regex.Match(dates(0), "([0-9]+)/([0-9]+)/([0-9]+)")
        Dim oldmonth As String = oldcoldate.Groups(1).Value
        Dim oldday As String = oldcoldate.Groups(2).Value
        Dim oldyear As String = oldcoldate.Groups(3).Value
        oldday = oldday.PadLeft(2, "0"c)
        oldmonth = oldmonth.PadLeft(2, "0"c)

        Return oldyear + "-" + oldmonth + "-" + oldday

    End Function

    Public Function datetoordernumberEnd(ByVal ordend As String)

        Dim dateend As Match = Regex.Match(ordend.ToString, "([0-9]+)/([0-9]+)/([0-9]+)")
        Dim endmonth As String = dateend.Groups(1).Value
        Dim endday As String = dateend.Groups(2).Value
        Dim endyear As String = dateend.Groups(3).Value
        While endday.ToString.Length < 2
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



        Dim newordend As String = monthend + endday
        newordend = newordend.PadRight(8, "9")

        Return newordend

    End Function

    Public Function datetoordernumberStart(ByVal ordend As String)

        Dim dateend As Match = Regex.Match(ordend.ToString, "([0-9]+)/([0-9]+)/([0-9]+)")
        Dim endmonth As String = dateend.Groups(1).Value
        Dim endday As String = dateend.Groups(2).Value
        Dim endyear As String = dateend.Groups(3).Value
        While endday.ToString.Length < 2
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



        Dim newordend As String = monthend + endday
        newordend = newordend.PadRight(8, "0")
        Return newordend
    End Function
End Module

