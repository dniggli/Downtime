Public Class main
    Public Shared Valid As Boolean = False
    Public Shared Username As String = ""


    ''' <summary>
    ''' Starts the main thread of the application
    ''' </summary>
    ''' <remarks></remarks>
    <MTAThread()> _
    Public Shared Sub main()
        Application.EnableVisualStyles()

        Dim Login As New LoginForm1
        Dim F1 As New MainMenu

        Application.Run(Login)
        If Valid Then
            Valid = False
            
            Application.Run(F1)
        End If

    End Sub






End Class
