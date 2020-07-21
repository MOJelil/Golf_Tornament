
Option Explicit On

Public Module modDatabaseUtilities

    Public con As OleDb.OleDbConnection

    ' SQL Server Connection string with integrated login v1
    Private m_strDatabaseConnectionStringSQLServerV1 As String = "Provider=SQLOLEDB;" &
                                                                 "Server=(Local);" &
                                                                 "Database=dbSQL1;" &
                                                                 "Integrated Security=SSPI;"

    ' SQL Server Connection string with integrated login v2
    Private m_strDatabaseConnectionStringSQLServerV2 As String = "Provider=SQLOLEDB;" &
                                                                 "Server=(Local);" &
                                                                 "Database=dbSQL1;" &
                                                                 "Trusted_Connection=True;"

    ' SQL Express Connection string                             
    Private m_strDatabaseConnectionString As String = "Provider=SQLOLEDB;" &
                                                      "Server=(Local)\SQLEXPRESS;" &
                                                      "Assignment10=dbSQL1;" &
                                                      "User ID=sa;" &
                                                      "Password=;"





#Region "Open/Close Connection"

    ' --------------------------------------------------------------------------------
    ' Name: OpenDatabaseConnectionMSAccess
    ' Abstract: Open a connection to the database.

    ' --------------------------------------------------------------------------------
    Public Function OpenDatabaseConnectionSQLServer() As Boolean

        Dim blnResult As Boolean = False

        Try

            ' Open a connection to the database
            con = New OleDb.OleDbConnection
            con.ConnectionString = m_strDatabaseConnectionStringSQLServerV1
            con.Open()


            ' Success
            blnResult = True

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

        Return blnResult

    End Function



    ' --------------------------------------------------------------------------------
    ' Name: CloseDatabaseConnection
    ' Abstract: If the database connection is open then close it.  Release the
    '           memory.
    ' --------------------------------------------------------------------------------
    Public Function CloseDatabaseConnection() As Boolean

        Dim blnResult As Boolean = False

        Try

            ' Anything there?
            If con IsNot Nothing Then

                ' Open?
                If con.State <> ConnectionState.Closed Then

                    ' Yes, close it
                    con.Close()

                End If

                ' Clean up
                con = Nothing

            End If

            ' Success
            blnResult = True

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

        Return blnResult

    End Function

#End Region

End Module
