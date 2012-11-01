Imports System.Windows.Forms

Public Class LoginForm2


    Public Shared Sub login5()
        Dim login As New LoginForm2
        Application.Run(login)
    End Sub
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim b As Boolean
        If UsernameTextBox.Text = "URMCLAB" Then b = True

        'AD.Authenticate(Me.UsernameTextBox.Text, Me.PasswordTextBox.Text)
        MainMenu.Valid = b
        MainMenu.Username = UsernameTextBox.Text
        If b = True Then

            Me.Close()


        Else
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "invalid username or password"   ' Define message.
            style = MsgBoxStyle.OkOnly
            title = "MsgBox"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
            If response = MsgBoxResult.Ok Then UsernameTextBox.Focus()
        End If

        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UsernameLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameLabel.Click

    End Sub

    Private Sub UsernameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameTextBox.TextChanged
       
    End Sub
End Class
