Imports CodeBase2.Databases


Public Class GetMySQL
    Inherits baseMySQL2

    Public Overrides ReadOnly Property GetConnection As MySql.Data.MySqlClient.MySqlConnection
        Get
            Return New MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;")

        End Get
    End Property


End Class
