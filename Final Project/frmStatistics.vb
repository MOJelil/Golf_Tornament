Public Class frmStatistics

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim strSelect1 As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim Reader As OleDb.OleDbDataReader
            Dim Table1 As DataTable = New DataTable

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Close()
            End If
            ComboBoxGolfers.BeginUpdate()

            strSelect1 = "SELECT intGolferID, strGolferLastName + ', ' + strGolferFirstName AS Name FROM TGolfers"

            cmdSelect = New OleDb.OleDbCommand(strSelect1, con)
            Reader = cmdSelect.ExecuteReader
            Table1.Load(Reader)
            ComboBoxGolfers.ValueMember = "intGolferID"
            ComboBoxGolfers.DisplayMember = "Name"
            ComboBoxGolfers.DataSource = Table1


            If ComboBoxGolfers.Items.Count > 0 Then
                ComboBoxGolfers.SelectedIndex = 0
            End If

            ComboBoxGolfers.EndUpdate()

            Reader.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim strSelectSponsor As String = ""
            Dim cmdSelectSponsor As OleDb.OleDbCommand
            Dim Reader As OleDb.OleDbDataReader
            Dim Table As DataTable = New DataTable
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Close()
            End If
            ComboBoxSponsors.BeginUpdate()

            strSelectSponsor = "SELECT intSponsorID, strLastName + ', '+ strFirstName AS Name FROM TSponsors"

            cmdSelectSponsor = New OleDb.OleDbCommand(strSelectSponsor, con)
            Reader = cmdSelectSponsor.ExecuteReader
            Table.Load(Reader)

            ComboBoxSponsors.ValueMember = "intSponsorID"
            ComboBoxSponsors.DisplayMember = "Name"
            ComboBoxSponsors.DataSource = Table

            If ComboBoxSponsors.Items.Count > 0 Then
                ComboBoxSponsors.SelectedIndex = 0
            End If

            ComboBoxSponsors.EndUpdate()
            Reader.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." + vbCrLf +
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            End If

            strSelect = "SELECT intPaymentTypeID, strPaymentTypeDesc 
                         FROM TPaymentTypes"

            cmdSelect = New OleDb.OleDbCommand(strSelect, con)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            cboPayment.ValueMember = "intPaymentTypeID"
            cboPayment.DisplayMember = "strPaymentTypeDesc"
            cboPayment.DataSource = dt

            If cboPayment.Items.Count > 0 Then
                cboPayment.SelectedIndex = 0
            End If
            drSourceTable.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            End If

            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, con)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the player ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the players data.
            ' We are binding the column name to the combo box display and value members. 
            cboEventYear.ValueMember = "intEventYearID"
            cboEventYear.DisplayMember = "intEventYear"
            cboEventYear.DataSource = dt

            ' Select the first item in the list by default
            If cboEventYear.Items.Count > 0 Then cboEventYear.SelectedIndex = 0
            ' Clean up
            drSourceTable.Close()
            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader        


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement
            strSelect = "SELECT intSponsorTypeID, strSponsorTypeDesc FROM TSponsorTypes"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, con)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the player ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the players data.
            ' We are binding the column name to the combo box display and value members. 
            cboSpnsorType.ValueMember = "intSponsorTypeID"
            cboSpnsorType.DisplayMember = "strSponsorTypeDesc"
            cboSpnsorType.DataSource = dt



            ' Select the first item in the list by default
            If cboSpnsorType.Items.Count > 0 Then
                cboSpnsorType.SelectedIndex = 0
            End If




            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        For Each ctrl As Control In Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.Text = String.Empty
            End If
        Next
    End Sub

    Private Sub ButtonInsert_Click(sender As Object, e As EventArgs) Handles ButtonInsert.Click
        Dim strInsert1 As String
        Dim cmdInsert1 As OleDb.OleDbCommand
        Dim strInsert2 As String
        Dim cmdInsert2 As OleDb.OleDbCommand
        Dim intRowsAffected As Integer

        Dim amountPledged As Decimal = 0.0
        Dim payStatus As String = "1"
        txtAmountPledged.BackColor = Color.White

        If Not Decimal.TryParse(txtAmountPledged.Text, amountPledged) Then
            MessageBox.Show("Enter a valid amount!")
            txtAmountPledged.Focus()
            txtAmountPledged.BackColor = Color.Yellow
            Exit Sub
        End If
        If amountPledged < 0 Then
            MessageBox.Show("Enter a valid amount!")
            txtAmountPledged.Focus()
            txtAmountPledged.BackColor = Color.Yellow
            Exit Sub
        End If
        If CheckBoxPaid.Checked = True Then
            payStatus = "1"
        Else
            payStatus = "0"
        End If
        Try
            If Validation() = True Then
                If OpenDatabaseConnectionSQLServer() = False Then
                    MessageBox.Show(Me, "Database connection error." + vbCrLf +
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Close()
                End If
                strInsert1 = "Insert into TGolferEventYears (intGolferID, intEventYearID)" +
                            " Values (" + ComboBoxGolfers.SelectedValue.ToString + "," + cboEventYear.SelectedValue.ToString + ")"

                strInsert2 = "Insert into TGolferEventYearSponsors (intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid)" +
                            " Values (" + ComboBoxGolfers.SelectedValue.ToString + "," + cboEventYear.SelectedValue.ToString + "," + ComboBoxSponsors.SelectedValue.ToString + "," + amountPledged.ToString + "," + cboSpnsorType.SelectedValue.ToString + "," + cboPayment.SelectedValue.ToString + "," + payStatus + ")"


                cmdInsert1 = New OleDb.OleDbCommand(strInsert1, con)
                intRowsAffected = cmdInsert1.ExecuteNonQuery()


                cmdInsert2 = New OleDb.OleDbCommand(strInsert2, con)
                intRowsAffected = cmdInsert2.ExecuteNonQuery()

                If intRowsAffected > 0 Then
                    MessageBox.Show("Insert has been successful!")
                End If
                CloseDatabaseConnection()
                Form1_Load(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Function Validation() As Boolean

        For Each ctrl As Control In GroupBox1.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Text = String.Empty Then
                    MessageBox.Show("Please enter the value in all fields!")
                    ctrl.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub ButtonUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click

        Try
            Dim strUpdate1 As String = ""
            Dim strUpdate2 As String = ""
            Dim intRowsAffected As Integer
            Dim cmdUpdate As OleDb.OleDbCommand

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." + vbNewLine +
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            End If
            txtAmountPledged.BackColor = Color.White

            Dim amountPledged As Decimal = 0.0
            Dim payStatus As String = "1"
            If Not Decimal.TryParse(txtAmountPledged.Text, amountPledged) Then
                MessageBox.Show("Enter a valid amount!")
                txtAmountPledged.Focus()
                txtAmountPledged.BackColor = Color.Yellow
                Exit Sub
            End If

            If CheckBoxPaid.Checked = True Then
                payStatus = "1"
            Else
                payStatus = "0"
            End If

            strUpdate1 = "UPDATE TGolferEventYears "
            strUpdate1 += "SET intGolferID = "
            strUpdate1 += ComboBoxGolfers.SelectedValue.ToString
            strUpdate1 += ",intEventYearID = "
            strUpdate1 += cboEventYear.SelectedValue.ToString

            strUpdate2 = "UPDATE TGolferEventYearSponsors "
            strUpdate2 += "SET intGolferID = "
            strUpdate2 += ComboBoxGolfers.SelectedValue.ToString
            strUpdate2 += ",intEventYearID = "
            strUpdate2 += cboEventYear.SelectedValue.ToString
            strUpdate2 += ",intSponsorID = "
            strUpdate2 += ComboBoxSponsors.SelectedValue.ToString
            strUpdate2 += ",monPledgeAmount = "
            strUpdate2 += amountPledged.ToString
            strUpdate2 += ",intSponsorTypeID = "
            strUpdate2 += cboSpnsorType.SelectedValue.ToString
            strUpdate2 += ",intPaymentTypeID = "
            strUpdate2 += cboPayment.SelectedValue.ToString 
            strUpdate2 += ",blnPaid = "
            strUpdate2 += payStatus


            cmdUpdate = New OleDb.OleDbCommand(strUpdate1, con)
            cmdUpdate = New OleDb.OleDbCommand(strUpdate2, con)
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

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        Dim strDelete1 As String = ""
        Dim strDelete2 As String = ""
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

            result = MessageBox.Show("Are you sure you want to delete?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    strDelete1 = "Delete FROM TGolferEventYearSponsors 
                                        WHERE intGolferID = " + ComboBoxGolfers.SelectedValue.ToString +
                                        "AND intEventYearID = " + cboEventYear.SelectedValue.ToString +
                                        "AND intSponsorID = " + ComboBoxSponsors.SelectedValue.ToString
                    strDelete2 = "DELETE FROM TGolferEventYears
                                  WHERE intGolferID = " + ComboBoxGolfers.SelectedValue.ToString +
                                  "AND intEventYearID = " + cboEventYear.SelectedValue.ToString

                    cmdDelete = New OleDb.OleDbCommand(strDelete1, con)
                    cmdDelete = New OleDb.OleDbCommand(strDelete2, con)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    txtAmountPledged.Text = String.Empty

                    If intRowsAffected > 0 Then
                        MessageBox.Show("Delete successful!", "Success")
                    End If

            End Select
            CloseDatabaseConnection()
            Form1_Load(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class