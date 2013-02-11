Imports NUnit.Framework
Imports AutoItHelper
<TestFixture()> _
Public Class AutoIT
    ''how to Embed the AutoItX3.dll into the AutoItHelper http://stackoverflow.com/questions/666799/embedding-unmanaged-dll-into-a-managed-c-sharp-dll
    <Test()> _
    Public Sub AutoSoft()
        'AutoItHelper.AutoItX.WinActivate("SoftLab 4.0.3 - Strong Memorial Hospital")
        Console.WriteLine(AutoItHelper.AutoItX.ControlListView("Test Selection", "", "[CLASS:ThunderRT6ListBox; INSTANCE:2]", "GetItemCount", "", ""))
    End Sub

End Class
