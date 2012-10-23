Imports NUnit.Framework
Imports AutoItHelper
<TestFixture()> _
Public Class AutoIT

    <Test()> _
    Public Sub AutoSoft()
        'AutoItHelper.AutoItX.WinActivate("SoftLab 4.0.3 - Strong Memorial Hospital")
        Console.WriteLine(AutoItHelper.AutoItX.ControlListView("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:2]", "GetItemCount", "", ""))
    End Sub

End Class
