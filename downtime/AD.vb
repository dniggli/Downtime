
Imports System.DirectoryServices

'TODO - Performance Enhancement:  Restructure User and Computer so It doesn't need to perform multiple searches.  It should retrieve the data for all properties in a single search.

'       .PropertiesToLoad.Add(Field)     To do this we need to add multiple fields to our search instead of searching one field at a time

'
Public Module AD

    Private Function auth(ByVal UserName As String, ByVal Password As String, ByVal LDAPpath As String) As Boolean

        'DirectoryEntry Class can be used to authenticate a username and password against active directory. You can force authentication to occur by retrieving the nativeObject property.

        Dim user As String = "URMC-SH" + "\" + UserName

        Dim entry As DirectoryEntry = New DirectoryEntry(LDAPpath, user, Password)



        Dim result As Boolean = False

        Try

            ' Bind to the native object to force authentication to happen

            Dim objnative As Object = entry.NativeObject

            ' "User authenticated" Move to the next page.

            Console.WriteLine("Authenticated")

            result = True

        Catch ex As Exception

            ' Throw New Exception("User not authenticated: " + ex.Message)

            result = False

        End Try



        Return result

    End Function



    Function Authenticate(ByVal UserName As String, ByVal Password As String) As Boolean

        'If authentication fails it assumes it cannot locate the domain, and tries again after specifying a domain controller





        Dim LDAPpath As String = "LDAP://URMC-SH.ROCHESTER.EDU"



        If auth(UserName, Password, LDAPpath) Then

            Return True

        Else

            LDAPpath = "LDAP://urmcshdc01.urmc-sh.rochester.edu/DC=URMC-SH,DC=ROCHESTER,DC=EDU"

            Return auth(UserName, Password, LDAPpath)

        End If



    End Function


End Module
