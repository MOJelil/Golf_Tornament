Public Class frmGolferInventory

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim strSelect As String = ""
            Dim strSelectYear As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable
            Dim dtYear As DataTable = New DataTable

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Close()
            End If

            strSelect = "SELECT intSponsorID, strLastName + ', ' + strFirstName AS SponsorName FROM TSponsors"
            strSelectYear = "SELECT intEventYearID, intEventYear FROM TEventYears"

            cboSponsor.BeginUpdate()
            cmdSelect = New OleDb.OleDbCommand(strSelect, con)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)
            cboSponsor.ValueMember = "intSponsorID"
            cboSponsor.DisplayMember = "SponsorName"
            cboSponsor.DataSource = dt
            cboSponsor.EndUpdate()

            ComboBoxYear.BeginUpdate()
            cmdSelect = New OleDb.OleDbCommand(strSelectYear, con)
            drSourceTable = cmdSelect.ExecuteReader
            dtYear.Load(drSourceTable)
            ComboBoxYear.ValueMember = "intEventYearID"
            ComboBoxYear.DisplayMember = "intEventYear"
            ComboBoxYear.DataSource = dtYear
            ComboBoxYear.EndUpdate()


            If cboSponsor.Items.Count > 0 Then
                cboSponsor.SelectedIndex = 0
            End If

            If ComboBoxYear.Items.Count > 0 Then
                ComboBoxYear.SelectedIndex = 0
            End If

            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch excError As Exception
            MessageBox.Show(excError.Message)
        End Try

    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxGolfers.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonSubmit.Click
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

            strSelect = "SELECT TG.intGolferID, TG.strGolferFirstName + ' ' + TG.strGolferLastName AS Name, TGEYS.monPledgeAmount
                         FROM TGolferEventYearSponsors AS TGEYS
                         INNER Join TGolfers TG ON TG.intGolferID= TGEYS.intGolferID
                         WHERE TGEYS.intSponsorID = " + cboSponsor.SelectedValue.ToString +
                         " AND TGEYS.intEventYearID = " + ComboBoxYear.SelectedValue.ToString

            cmdSelect = New OleDb.OleDbCommand(strSelect, con)
            Reader = cmdSelect.ExecuteReader
            Table.Load(Reader)

            ListBoxGolfers.BeginUpdate()

            For Each row In Table.Rows
                insert = row.Item(0).ToString + "."
                insert += row.Item(1).ToString + "."
                insert += "          |          " + row.Item(2).ToString
                ListBoxGolfers.Items.Add(insert)
            Next

            If ListBoxGolfers.Items.Count > 0 Then
                ListBoxGolfers.SelectedIndex = 0
            End If

            ListBoxGolfers.EndUpdate()
            Reader.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
