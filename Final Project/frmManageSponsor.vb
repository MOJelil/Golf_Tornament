Public Class frmManageSponsor
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim Reader As OleDb.OleDbDataReader
        Dim Table As DataTable = New DataTable

        Try
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Close()
            End If
            cboSponsors.BeginUpdate()

            strSelect = "SELECT intSponsorID, strLastName + ', '+ strFirstName AS Name FROM TSponsors"

            cmdSelect = New OleDb.OleDbCommand(strSelect, con)
            Reader = cmdSelect.ExecuteReader
            Table.Load(Reader)

            cboSponsors.ValueMember = "intSponsorID"
            cboSponsors.DisplayMember = "Name"
            cboSponsors.DataSource = Table

            If cboSponsors.Items.Count > 0 Then
                cboSponsors.SelectedIndex = 0
            End If

            cboSponsors.EndUpdate()
            Reader.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Get_Info()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strDeleteChild As String = ""
        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand
        Dim cmdDeleteChild As OleDb.OleDbCommand
        Dim Table As DataTable = New DataTable
        Dim result As DialogResult
        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            End If

            result = MessageBox.Show("Are you sure you want to Delete Golfer: Name, " + cboSponsors.Text + "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    strDeleteChild = "Delete FROM TGolferEventYearSponsors
                                        WHERE intSponsorID = " + cboSponsors.SelectedValue.ToString
                    cmdDeleteChild = New OleDb.OleDbCommand(strDeleteChild, con)
                    intRowsAffected = cmdDeleteChild.ExecuteNonQuery()

                    strDelete = "Delete FROM TSponsors 
                                        WHERE intSponsorID = " + cboSponsors.SelectedValue.ToString

                    cmdDelete = New OleDb.OleDbCommand(strDelete, con)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Delete successful!", "Success")
                    End If
                    Wipe_Out()
            End Select
            CloseDatabaseConnection()
            Form1_Load(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try
            Dim strSelect As String = ""
            Dim intRowsAffected As Integer
            Dim cmdUpdate As OleDb.OleDbCommand

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." + vbNewLine +
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            End If
            strSelect = "UPDATE TSponsors "
            strSelect += "SET strFirstName = '"
            strSelect += txtFirstName.Text
            strSelect += "'"
            strSelect += ",strLastName = '"
            strSelect += txtLastName.Text
            strSelect += "'"
            strSelect += ",strStreetAddress = '"
            strSelect += txtAddress.Text
            strSelect += "'"
            strSelect += ",strCity = '"
            strSelect += txtCity.Text
            strSelect += "'"
            strSelect += ",strState = '"
            strSelect += txtState.Text
            strSelect += "'"
            strSelect += ",strZip = '"
            strSelect += txtZip.Text
            strSelect += "'"
            strSelect += ",strPhoneNumber = '"
            strSelect += txtPhone.Text
            strSelect += "'"
            strSelect += ",strEmail = '"
            strSelect += txtEmail.Text
            strSelect += "'"
            strSelect += " WHERE intSponsorID = "
            strSelect += cboSponsors.SelectedValue.ToString
            strSelect += ";"

            cmdUpdate = New OleDb.OleDbCommand(strSelect, con)
            intRowsAffected = cmdUpdate.ExecuteNonQuery()
            If intRowsAffected > 0 Then
                MessageBox.Show("Update successful!")
            Else
                MessageBox.Show("Update failed!")
            End If
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim strInsert As String
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""

        Dim cmdInsert As OleDb.OleDbCommand
        Dim intRowsAffected As Integer

        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strStreetAddress = txtAddress.Text
        strCity = txtCity.Text
        strState = txtState.Text
        strZip = txtZip.Text
        strPhoneNumber = txtPhone.Text
        strEmail = txtEmail.Text

        Try
            If Validation() = True Then
                If OpenDatabaseConnectionSQLServer() = False Then
                    MessageBox.Show(Me, "Database connection error." + vbCrLf +
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Close()
                End If
                strInsert = "Insert into TSponsors (strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail)" +
                            " Values ('" + strFirstName + "','" + strLastName + "','" + strStreetAddress + "','" + strCity + "','" + strState + "','" + strZip + "','" + strPhoneNumber + "','" + strEmail + "')"
                cmdInsert = New OleDb.OleDbCommand(strInsert, con)
                intRowsAffected = cmdInsert.ExecuteNonQuery()

                If intRowsAffected > 0 Then
                    MessageBox.Show("Sponsor has been successfully added!", "Success")
                End If
                CloseDatabaseConnection()
                Form1_Load(sender, e)
                Wipe_Out()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    Sub Wipe_Out()
        txtFirstName.Text = String.Empty
        txtLastName.Text = ""
        txtAddress.Text = String.Empty
        txtCity.Text = String.Empty
        txtEmail.Text = String.Empty
        txtPhone.Text = String.Empty
        txtState.Text = String.Empty
        txtZip.Text = String.Empty
    End Sub

    Public Sub Get_Info()
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim Reader As OleDb.OleDbDataReader
        Dim Table As DataTable = New DataTable
        Try
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." + vbCrLf +
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            End If


            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail
                     FROM TSponsors 
                     WHERE intSponsorID = " + cboSponsors.SelectedValue.ToString

            cmdSelect = New OleDb.OleDbCommand(strSelect, con)
            Reader = cmdSelect.ExecuteReader
            Table.Load(Reader)

            txtFirstName.Text = Table.Rows(0).Item(0).ToString
            txtLastName.Text = Table.Rows(0).Item(1).ToString
            txtAddress.Text = Table.Rows(0).Item(2).ToString
            txtCity.Text = Table.Rows(0).Item(3).ToString
            txtState.Text = Table.Rows(0).Item(4).ToString
            txtZip.Text = Table.Rows(0).Item(5).ToString
            txtPhone.Text = Table.Rows(0).Item(6).ToString
            txtEmail.Text = Table.Rows(0).Item(7).ToString

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Function Validation() As Boolean

        For Each ctrl As Control In GroupBox1.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Text = String.Empty Then
                    MessageBox.Show("Please enter the value in all fields!", "Error")
                    ctrl.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormSponsorInventory.ShowDialog()
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        Wipe_Out()
    End Sub
End Class