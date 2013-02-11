Public Class InputBoxFormRecover

    Private Sub InputBoxForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.TopMost = True
        Me.Activate()

        Dim a As String = "Please enter correct test for:" + " " + RecoveryForm.tests


        Me.LabelTestError.Text = a


        Me.TextBoxTestFix.Focus()
        'InputBoxFormRecover.TextBoxTestFix.Text = b
        'Me.label()


    End Sub


    Private Sub ButtonInput_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonInput.Click
        RecoveryForm.fixTEST = TextBoxTestFix.Text
        Me.Close()
    End Sub
    Sub label()
        Dim a As String = "Please enter correct test for:"
        Dim b As String = a + " " + RecoveryForm.tests
        Me.LabelTestError.Text = b
        Console.WriteLine(Me.LabelTestError.Text)
    End Sub



    Private Sub TextBoxTestFix_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxTestFix.KeyPress
        If e.KeyChar = Chr(13) Then
            ButtonInput_Click(Me, EventArgs.Empty)
        End If

    End Sub

    
End Class