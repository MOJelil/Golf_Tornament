Public Class frmManageGolfers
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSelect1 As String = ""
        Dim strSelect2 As String = ""
        Dim strSelect3 As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim Reader As OleDb.OleDbDataReader
        Dim Table1 As DataTable = New DataTable
        Dim Table2 As DataTable = New DataTable
        Dim Table3 As DataTable = New DataTable

        Try
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Close()
            End If
            cboGolfers.BeginUpdate()
            ComboTshirts.BeginUpdate()
            ComboGenders.BeginUpdate()

            strSelect1 = "SELECT intGolferID, strGolferLastName + ', ' + strGolferFirstName AS Name FROM TGolfers"
            strSelect2 = "SELECT intShirtSizeID, strShirtSizeDesc FROM TShirtSizes"
            strSelect3 = "SELECT intGenderID, strGenderDesc FROM TGenders"

            cmdSelect = New OleDb.OleDbCommand(strSelect1, con)
            Reader = cmdSelect.ExecuteReader
            Table1.Load(Reader)
            cboGolfers.ValueMember = "intGolferID"
            cboGolfers.DisplayMember = "Name"
            cboGolfers.DataSource = Table1

            cmdSelect = New OleDb.OleDbCommand(strSelect2, con)
            Reader = cmdSelect.ExecuteReader
            Table2.Load(Reader)
            ComboTshirts.ValueMember = "intShirtSizeID"
            ComboTshirts.DisplayMember = "strShirtSizeDesc"
            ComboTshirts.DataSource = Table2

            cmdSelect = New OleDb.OleDbCommand(strSelect3, con)
            Reader = cmdSelect.ExecuteReader
            Table3.Load(Reader)
            ComboGenders.ValueMember = "intGenderID"
            ComboGenders.DisplayMember = "strGenderDesc"
            ComboGenders.DataSource = Table3

            If cboGolfers.Items.Count > 0 Then
                cboGolfers.SelectedIndex = 0
            End If
            If ComboTshirts.Items.Count > 0 Then
                ComboTshirts.SelectedIndex = 0
            End If
            If ComboGenders.Items.Count > 0 Then
                ComboGenders.SelectedIndex = 0
            End If
            cboGolfers.EndUpdate()
            ComboTshirts.EndUpdate()
            ComboGenders.EndUpdate()

            Reader.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Wipe_Out()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Get_Info()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand
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

            result = MessageBox.Show("Are you sure you want to Delete Golfer: First Name, " + cboGolfers.Text + "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    strDelete = "Delete FROM TGolfers 
                                        WHERE intGolferID = " + cboGolfers.SelectedValue.ToString

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

    Private Sub btnUpdateSproc_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

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

            strSelect = "UPDATE TGolfers "
            strSelect += "SET strGolferFirstName = '"
            strSelect += txtFirstName.Text
            strSelect += "'"
            strSelect += ",strGolferLastName = '"
            strSelect += txtLastName.Text
            strSelect += "'"
            strSelect += ",strGolferStreetAddress = '"
            strSelect += txtAddress.Text
            strSelect += "'"
            strSelect += ",strGolferCity = '"
            strSelect += txtCity.Text
            strSelect += "'"
            strSelect += ",strGolferState = '"
            strSelect += txtState.Text
            strSelect += "'"
            strSelect += ",strGolferZip = '"
            strSelect += txtZip.Text
            strSelect += "'"
            strSelect += ",strGolferPhoneNumber = '"
            strSelect += txtPhone.Text
            strSelect += "'"
            strSelect += ",strGolferEmail = '"
            strSelect += txtEmail.Text
            strSelect += "'"
            strSelect += " WHERE intGolferID = "
            strSelect += cboGolfers.SelectedValue.ToString
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

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim strInsert As String
        Dim strGolferFirstName As String = ""
        Dim strGolferLastName As String = ""
        Dim strGolferStreetAddress As String = ""
        Dim strGolferCity As String = ""
        Dim strGolferState As String = ""
        Dim strGolferZip As String = ""
        Dim strGolferPhoneNumber As String = ""
        Dim strGolferEmail As String = ""

        Dim cmdInsert As OleDb.OleDbCommand
        Dim intRowsAffected As Integer

        For Each Control As Control In Controls
            If TypeOf Control Is TextBox Then
                If Control.Text = String.Empty Then
                    MessageBox.Show("Enter Player informations in the form!")
                End If
            End If
        Next


        strGolferFirstName = txtFirstName.Text
        strGolferLastName = txtLastName.Text
        strGolferStreetAddress = txtAddress.Text
        strGolferCity = txtCity.Text
        strGolferState = txtState.Text
        strGolferZip = txtZip.Text
        strGolferPhoneNumber = txtPhone.Text
        strGolferEmail = txtEmail.Text

        Try
            If Validation() = True Then
                If OpenDatabaseConnectionSQLServer() = False Then
                    MessageBox.Show(Me, "Database connection error." + vbCrLf +
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Close()
                End If
                strInsert = "Insert into TGolfers (strGolferFirstName, strGolferLastName, strGolferStreetAddress, strGolferCity, strGolferState, strGolferZip, strGolferPhoneNumber, strGolferEmail, intShirtSizeID, intGenderID)" +
                            " Values ('" + strGolferFirstName + "','" + strGolferLastName + "','" + strGolferStreetAddress + "','" + strGolferCity + "','" + strGolferState + "','" + strGolferZip + "','" + strGolferPhoneNumber + "','" + strGolferEmail + "'," + ComboTshirts.SelectedValue.ToString + "," + ComboGenders.SelectedValue.ToString + ")"


                cmdInsert = New OleDb.OleDbCommand(strInsert, con)
                intRowsAffected = cmdInsert.ExecuteNonQuery()

                If intRowsAffected > 0 Then
                    MessageBox.Show("Player has been successfully added!", "Success")
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
        For Each Control As Control In Controls
            If TypeOf Control Is TextBox Then
                Control.Text = String.Empty
            End If
        Next
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


            strSelect = "SELECT strGolferFirstName, strGolferLastName, strGolferStreetAddress, strGolferCity, strGolferState, strGolferZip, strGolferPhoneNumber, strGolferEmail
                     FROM TGolfers 
                     WHERE intGolferID = " + cboGolfers.SelectedValue.ToString

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
        frmGolferInventory.ShowDialog()
    End Sub
End Class