Imports System.Threading
Imports System.IO

Public Class StatOrderQueryForm
    ''' <summary>
    ''' Starts the Query Thread
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ThreadStart(ByVal args As Object)
        Application.Run(New StatOrderQueryForm(args))

    End Sub


    Dim QUERY As String
    Dim QUERYName As String
    Public Sub New(ByVal args As Hashtable)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.QUERY = args("Query")
        Me.QUERYName = args("QueryName")
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim statorder As New MySqlDataAdapter("SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.RECEIVETIME, Table1.LOCATION, Table1.PRIORITY, Table1.LASTNAME, Table1.BLUETEST, Table1.REDTEST, Table1.LAVHEMTEST, Table1.GREENTEST, Table1.LAVCHEMTEST, Table1.GRYTEST, Table1.URINEHEM, Table1.URINECHEM, Table1.BLOODGAS, Table1.CALLS FROM dtdb1.Table1 GROUP BY Table1.COLLECTIONTIME, Table1.RECEIVETIME, Table1.LOCATION, Table1.PRIORITY, Table1.LASTNAME, Table1.BLUETEST, Table1.REDTEST, Table1.LAVHEMTEST, Table1.GREENTEST, Table1.LAVCHEMTEST, Table1.GRYTEST, Table1.URINEHEM, Table1.URINECHEM, Table1.BLOODGAS, Table1.CALLS HAVING(((Table1.PRIORITY) Like ""S"")) ORDER BY Table1.ordernumber;", "server=lis-s22104-db1;Database=dtdb1;uid=dniggli;pwd=vvo084")
        Dim statorder As New MySqlDataAdapter(QUERY, "server=lis-s22104-db1;Database=dtdb1;uid=dniggli;pwd=vvo084")
        Me.Text = QUERYName
        Dim t As New DataTable

        statorder.Fill(t)


        Me.DataGridView1.DataSource = t


    End Sub



    Private oStringFormat As StringFormat
    Private oStringFormatComboBox As StringFormat
    Private oButton As Button
    Private oCheckbox As CheckBox
    Private oComboBox As ComboBox

    Private nTotalWidth As Int16
    Private nRowPos As Int16
    Private NewPage As Boolean
    Private nPageNo As Int16
    Private Header As String = "Header Test"
    Private sUserName As String = "Will"

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint

        oStringFormat = New StringFormat
        oStringFormat.Alignment = StringAlignment.Near
        oStringFormat.LineAlignment = StringAlignment.Center
        oStringFormat.Trimming = StringTrimming.EllipsisCharacter

        oStringFormatComboBox = New StringFormat
        oStringFormatComboBox.LineAlignment = StringAlignment.Center
        oStringFormatComboBox.FormatFlags = StringFormatFlags.NoWrap
        oStringFormatComboBox.Trimming = StringTrimming.EllipsisCharacter

        oButton = New Button
        oCheckbox = New CheckBox
        oComboBox = New ComboBox

        nTotalWidth = 0
        For Each oColumn As DataGridViewColumn In DataGridView1.Columns

            nTotalWidth += oColumn.Width

        Next
        nPageNo = 1
        NewPage = True
        nRowPos = 0

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Static oColumnLefts As New ArrayList
        Static oColumnWidths As New ArrayList
        Static oColumnTypes As New ArrayList
        Static nHeight As Int16

        Dim nWidth, i, nRowsPerPage As Int16
        Dim nTop As Int16 = e.MarginBounds.Top
        Dim nLeft As Int16 = e.MarginBounds.Left

        If nPageNo = 1 Then

            For Each oColumn As DataGridViewColumn In DataGridView1.Columns

                nWidth = CType(Math.Floor(oColumn.Width / nTotalWidth * nTotalWidth * (e.MarginBounds.Width / nTotalWidth)), Int16)

                nHeight = e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height + 11

                oColumnLefts.Add(nLeft)
                oColumnWidths.Add(nWidth)
                oColumnTypes.Add(oColumn.GetType)
                nLeft += nWidth

            Next

        End If

        Do While nRowPos < DataGridView1.Rows.Count - 1

            Dim oRow As DataGridViewRow = DataGridView1.Rows(nRowPos)

            If nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then

                DrawFooter(e, nRowsPerPage)

                NewPage = True
                nPageNo += 1
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    e.Graphics.DrawString(Header, New Font(DataGridView1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(Header, New Font(DataGridView1.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13)

                    ' Draw Columns
                    nTop = e.MarginBounds.Top
                    i = 0
                    For Each oColumn As DataGridViewColumn In DataGridView1.Columns

                        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                        e.Graphics.DrawString(oColumn.HeaderText, oColumn.InheritedStyle.Font, New SolidBrush(oColumn.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                        i += 1

                    Next
                    NewPage = False

                End If

                nTop += nHeight
                i = 0
                For Each oCell As DataGridViewCell In oRow.Cells

                    If oColumnTypes(i) Is GetType(DataGridViewTextBoxColumn) OrElse oColumnTypes(i) Is GetType(DataGridViewLinkColumn) Then

                        e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)

                    ElseIf oColumnTypes(i) Is GetType(DataGridViewButtonColumn) Then

                        oButton.Text = oCell.Value.ToString
                        oButton.Size = New Size(oColumnWidths(i), nHeight)
                        Dim oBitmap As New Bitmap(oButton.Width, oButton.Height)
                        oButton.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                        e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))

                    ElseIf oColumnTypes(i) Is GetType(DataGridViewCheckBoxColumn) Then

                        oCheckbox.Size = New Size(14, 14)
                        oCheckbox.Checked = CType(oCell.Value, Boolean)
                        Dim oBitmap As New Bitmap(oColumnWidths(i), nHeight)
                        Dim oTempGraphics As Graphics = Graphics.FromImage(oBitmap)
                        oTempGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                        oCheckbox.DrawToBitmap(oBitmap, New Rectangle(CType((oBitmap.Width - oCheckbox.Width) / 2, Int32), CType((oBitmap.Height - oCheckbox.Height) / 2, Int32), oCheckbox.Width, oCheckbox.Height))
                        e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))

                    ElseIf oColumnTypes(i) Is GetType(DataGridViewComboBoxColumn) Then

                        oComboBox.Size = New Size(oColumnWidths(i), nHeight)
                        Dim oBitmap As New Bitmap(oComboBox.Width, oComboBox.Height)
                        oComboBox.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                        e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                        e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + 1, nTop, oColumnWidths(i) - 16, nHeight), oStringFormatComboBox)

                    ElseIf oColumnTypes(i) Is GetType(DataGridViewImageColumn) Then

                        Dim oCellSize As Rectangle = New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight)
                        Dim oImageSize As Size = CType(oCell.Value, Image).Size
                        e.Graphics.DrawImage(oCell.Value, New Rectangle(oColumnLefts(i) + CType(((oCellSize.Width - oImageSize.Width) / 2), Int32), nTop + CType(((oCellSize.Height - oImageSize.Height) / 2), Int32), CType(oCell.Value, Image).Width, CType(oCell.Value, Image).Height))

                    End If

                    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))

                    i += 1

                Next

            End If

            nRowPos += 1
            nRowsPerPage += 1

        Loop

        DrawFooter(e, nRowsPerPage)

        e.HasMorePages = False

    End Sub

    Private Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32)

        Dim sPageNo As String = nPageNo.ToString + " of " + Math.Ceiling(DataGridView1.Rows.Count / RowsPerPage).ToString

        ' Right Align - User Name
        e.Graphics.DrawString(sUserName, DataGridView1.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, DataGridView1.Font, e.MarginBounds.Width).Width), e.MarginBounds.Top + e.MarginBounds.Height + 7)

        ' Left Align - Date/Time
        e.Graphics.DrawString(Now.ToLongDateString + " " + Now.ToShortTimeString, DataGridView1.Font, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + e.MarginBounds.Height + 7)

        ' Center  - Page No. Info
        e.Graphics.DrawString(sPageNo, DataGridView1.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, DataGridView1.Font, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + e.MarginBounds.Height + 31)

    End Sub

    Private Sub PrintDocument1_PrintPage_1(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dlg As New PrintPreviewDialog()

        dlg.Document = PrintDocument1

        dlg.ShowDialog()



        'This code gives you the page setup form...

        Dim psDlg As New PageSetupDialog










    End Sub

    Private Sub PrintPreviewDialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click




        Dim db As New MySqlDataAdapter(QUERY, New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"))
        Dim dt As New DataTable

        db.Fill(dt)
        Try

            Dim sw1 As New StreamWriter("C:\Program Files\downtime\Testlist.csv", False)
            sw1.Close()
        Catch


            Dim msg1 As String
            Dim title1 As String
            Dim style1 As MsgBoxStyle
            Dim response1 As MsgBoxResult

            msg1 = "file must be colsed"   ' Define message.
            style1 = MsgBoxStyle.DefaultButton1
            title1 = "MsgBox"   ' Define title.
            'Display message.
            response1 = MsgBox(msg1, style1, title1)


            AutoItHelper.AutoItX.WinActivate("Microsoft Excel - Testlist.csv")

            Thread.Sleep(2000)
            AutoItHelper.AutoItX.WinActivate("MsgBox")
            AutoItHelper.AutoItX.WinWaitClose("Microsoft Excel - Testlist.csv")


        End Try
        Dim sw As New StreamWriter("C:\Program Files\downtime\Testlist.csv", False)

        'Write line 1 for column names
        Dim columnnames As String = ""
        For Each dc As DataColumn In dt.Columns
            columnnames &= """" & dc.ColumnName & ""","
        Next
        columnnames = columnnames.TrimEnd(","c)
        sw.WriteLine(columnnames)
        'Write out the rows
        For Each dr As DataRow In dt.Rows
            Dim row As String = ""
            For Each dc As DataColumn In dt.Columns
                If TypeOf (dr(dc.ColumnName)) Is Byte() Then

                    row &= """" & getstring(dr(dc.ColumnName)) & ""","
                Else
                    row &= """" & dr(dc.ColumnName).ToString & ""","
                End If


            Next
            row = row.TrimEnd(","c)
            sw.WriteLine(row)
        Next
        'Done writing

        sw.Close()


        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult

        msg = "Your file is done. Would you like to open?"   ' Define message.
        style = MsgBoxStyle.YesNo
        title = "MsgBox"   ' Define title.
        'Display message.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then
            Dim excel As Microsoft.Office.Interop.Excel.Application

            Dim wb As Microsoft.Office.Interop.Excel.Workbook

            Try

                excel = New Microsoft.Office.Interop.Excel.Application
                wb = excel.Workbooks.Open("C:\Program Files\downtime\Testlist.csv")
                excel.Visible = True
                wb.Activate()

            Catch ex As Exception
                MessageBox.Show("Error accessing Excel: " + ex.ToString())



            End Try
        End If
        If response = MsgBoxResult.Yes Then
            Exit Sub
        End If

    End Sub
    Function getstring(ByVal value As Byte()) As String
        Dim enc As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding
        Return enc.GetString(value)
    End Function
End Class