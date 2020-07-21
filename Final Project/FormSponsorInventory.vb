Public Class FormSponsorInventory

    Private Sub FormSponsorInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect1 As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim strSelect2 As String = ""
        Dim Reader As OleDb.OleDbDataReader
        Dim Table1 As DataTable = New DataTable
        Dim Table2 As DataTable = New DataTable

        Try
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." + vbCrLf +
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Close()
            End If


            strSelect1 = "SELECT intGolferID, strGolferLastName + ', ' + strGolferFirstName AS GolferName FROM TGolfers"

            strSelect2 = "SELECT intEventYearID, intEventYear FROM TEventYears"

            cboGolfer.BeginUpdate()
            cmdSelect = New OleDb.OleDbCommand(strSelect1, con)
            Reader = cmdSelect.ExecuteReader
            Table1.Load(Reader)
            cboGolfer.ValueMember = "intGolferID"
            cboGolfer.DisplayMember = "GolferName"
            cboGolfer.DataSource = Table1
            cboGolfer.EndUpdate()

            ComboBoxYear.BeginUpdate()
            cmdSelect = New OleDb.OleDbCommand(strSelect2, con)
            Reader = cmdSelect.ExecuteReader
            Table2.Load(Reader)
            ComboBoxYear.ValueMember = "intEventYearID"
            ComboBoxYear.DisplayMember = "intEventYear"
            ComboBoxYear.DataSource = Table2
            ComboBoxYear.EndUpdate()


            If cboGolfer.Items.Count > 0 Then
                cboGolfer.SelectedIndex = 0
            End If
            If ComboBoxYear.Items.Count > 0 Then
                ComboBoxYear.SelectedIndex = 0
            End If

            Reader.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub ButtonSubmit_Click(sender As Object, e As EventArgs) Handles ButtonSubmit.Click
        Dim strSelect, insert As String
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


            strSelect = "SELECT TSponsors.intSponsorID, TSponsors.strFirstName + ' ' + TSponsors.strLastName AS Name, TGolferEventYearSponsors.monPledgeAmount
                         FROM TGolferEventYearSponsors
                         INNER Join TSponsors ON TSponsors.intSponsorID = TGolferEventYearSponsors.intSponsorID
                         WHERE TGolferEventYearSponsors.intGolferID = " + cboGolfer.SelectedValue.ToString +
                         " AND TGolferEventYearSponsors.intEventYearID = " + ComboBoxYear.SelectedValue.ToString

            cmdSelect = New OleDb.OleDbCommand(strSelect, con)
            Reader = cmdSelect.ExecuteReader
            Table.Load(Reader)
            ListBoxSponsors.BeginUpdate()

            For Each Row In Table.Rows
                insert = Row.Item(0).ToString
                insert += Row.Item(1).ToString
                insert += "          |          " + Row.Item(2).ToString
                ListBoxSponsors.Items.Add(insert)
            Next

            If ListBoxSponsors.Items.Count > 0 Then
                ListBoxSponsors.SelectedIndex = 0
            End If

            ListBoxSponsors.EndUpdate()
            Reader.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class