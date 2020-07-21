<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStatistics
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cboPayment = New System.Windows.Forms.ComboBox()
        Me.cboEventYear = New System.Windows.Forms.ComboBox()
        Me.cboSpnsorType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAmountPledged = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBoxSponsors = New System.Windows.Forms.ComboBox()
        Me.ComboBoxGolfers = New System.Windows.Forms.ComboBox()
        Me.ButtonInsert = New System.Windows.Forms.Button()
        Me.ButtonUpdate = New System.Windows.Forms.Button()
        Me.ButtonDelete = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxPaid = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(142, 260)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(218, 57)
        Me.btnExit.TabIndex = 86
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cboPayment
        '
        Me.cboPayment.FormattingEnabled = True
        Me.cboPayment.Location = New System.Drawing.Point(361, 105)
        Me.cboPayment.Name = "cboPayment"
        Me.cboPayment.Size = New System.Drawing.Size(121, 21)
        Me.cboPayment.TabIndex = 89
        '
        'cboEventYear
        '
        Me.cboEventYear.FormattingEnabled = True
        Me.cboEventYear.Location = New System.Drawing.Point(361, 66)
        Me.cboEventYear.Name = "cboEventYear"
        Me.cboEventYear.Size = New System.Drawing.Size(121, 21)
        Me.cboEventYear.TabIndex = 90
        '
        'cboSpnsorType
        '
        Me.cboSpnsorType.FormattingEnabled = True
        Me.cboSpnsorType.Location = New System.Drawing.Point(108, 66)
        Me.cboSpnsorType.Name = "cboSpnsorType"
        Me.cboSpnsorType.Size = New System.Drawing.Size(121, 21)
        Me.cboSpnsorType.TabIndex = 91
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(265, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Golfer:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Sponsor:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "Amount Pledged:"
        '
        'txtAmountPledged
        '
        Me.txtAmountPledged.Location = New System.Drawing.Point(108, 106)
        Me.txtAmountPledged.Name = "txtAmountPledged"
        Me.txtAmountPledged.Size = New System.Drawing.Size(121, 20)
        Me.txtAmountPledged.TabIndex = 103
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(395, 211)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(106, 105)
        Me.btnClear.TabIndex = 117
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(265, 113)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 118
        Me.Label13.Text = "Payment Type :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 13)
        Me.Label14.TabIndex = 119
        Me.Label14.Text = "Sponsor Type:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(265, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 120
        Me.Label15.Text = "Event Year:"
        '
        'ComboBoxSponsors
        '
        Me.ComboBoxSponsors.FormattingEnabled = True
        Me.ComboBoxSponsors.Location = New System.Drawing.Point(108, 28)
        Me.ComboBoxSponsors.Name = "ComboBoxSponsors"
        Me.ComboBoxSponsors.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxSponsors.TabIndex = 124
        '
        'ComboBoxGolfers
        '
        Me.ComboBoxGolfers.FormattingEnabled = True
        Me.ComboBoxGolfers.Location = New System.Drawing.Point(361, 28)
        Me.ComboBoxGolfers.Name = "ComboBoxGolfers"
        Me.ComboBoxGolfers.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxGolfers.TabIndex = 125
        '
        'ButtonInsert
        '
        Me.ButtonInsert.Location = New System.Drawing.Point(12, 211)
        Me.ButtonInsert.Name = "ButtonInsert"
        Me.ButtonInsert.Size = New System.Drawing.Size(104, 106)
        Me.ButtonInsert.TabIndex = 126
        Me.ButtonInsert.Text = "Insert"
        Me.ButtonInsert.UseVisualStyleBackColor = True
        '
        'ButtonUpdate
        '
        Me.ButtonUpdate.Location = New System.Drawing.Point(142, 211)
        Me.ButtonUpdate.Name = "ButtonUpdate"
        Me.ButtonUpdate.Size = New System.Drawing.Size(96, 44)
        Me.ButtonUpdate.TabIndex = 127
        Me.ButtonUpdate.Text = "Update"
        Me.ButtonUpdate.UseVisualStyleBackColor = True
        '
        'ButtonDelete
        '
        Me.ButtonDelete.Location = New System.Drawing.Point(259, 211)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(101, 45)
        Me.ButtonDelete.TabIndex = 128
        Me.ButtonDelete.Text = "Delete"
        Me.ButtonDelete.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxPaid)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(489, 193)
        Me.GroupBox1.TabIndex = 129
        Me.GroupBox1.TabStop = False
        '
        'CheckBoxPaid
        '
        Me.CheckBoxPaid.AutoSize = True
        Me.CheckBoxPaid.Location = New System.Drawing.Point(106, 145)
        Me.CheckBoxPaid.Name = "CheckBoxPaid"
        Me.CheckBoxPaid.Size = New System.Drawing.Size(47, 17)
        Me.CheckBoxPaid.TabIndex = 130
        Me.CheckBoxPaid.Text = "Paid"
        Me.CheckBoxPaid.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Payment Status:"
        '
        'frmStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 328)
        Me.Controls.Add(Me.ButtonDelete)
        Me.Controls.Add(Me.ButtonUpdate)
        Me.Controls.Add(Me.ButtonInsert)
        Me.Controls.Add(Me.ComboBoxGolfers)
        Me.Controls.Add(Me.ComboBoxSponsors)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAmountPledged)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboSpnsorType)
        Me.Controls.Add(Me.cboEventYear)
        Me.Controls.Add(Me.cboPayment)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmStatistics"
        Me.Text = "Manage_Statistics"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As Button
    Friend WithEvents cboPayment As ComboBox
    Friend WithEvents cboEventYear As ComboBox
    Friend WithEvents cboSpnsorType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAmountPledged As TextBox
    Friend WithEvents btnClear As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents ComboBoxSponsors As ComboBox
    Friend WithEvents ComboBoxGolfers As ComboBox
    Friend WithEvents ButtonInsert As Button
    Friend WithEvents ButtonUpdate As Button
    Friend WithEvents ButtonDelete As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBoxPaid As CheckBox
End Class
