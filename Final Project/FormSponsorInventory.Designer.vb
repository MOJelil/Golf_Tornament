<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSponsorInventory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonSubmit = New System.Windows.Forms.Button()
        Me.ListBoxSponsors = New System.Windows.Forms.ListBox()
        Me.ComboBoxYear = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboGolfer = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pick a Golfer:"
        '
        'ButtonSubmit
        '
        Me.ButtonSubmit.Location = New System.Drawing.Point(39, 308)
        Me.ButtonSubmit.Name = "ButtonSubmit"
        Me.ButtonSubmit.Size = New System.Drawing.Size(210, 37)
        Me.ButtonSubmit.TabIndex = 101
        Me.ButtonSubmit.Text = "Submit"
        Me.ButtonSubmit.UseVisualStyleBackColor = True
        '
        'ListBoxSponsors
        '
        Me.ListBoxSponsors.FormattingEnabled = True
        Me.ListBoxSponsors.Location = New System.Drawing.Point(39, 84)
        Me.ListBoxSponsors.Name = "ListBoxSponsors"
        Me.ListBoxSponsors.Size = New System.Drawing.Size(480, 212)
        Me.ListBoxSponsors.TabIndex = 99
        '
        'ComboBoxYear
        '
        Me.ComboBoxYear.FormattingEnabled = True
        Me.ComboBoxYear.Location = New System.Drawing.Point(398, 19)
        Me.ComboBoxYear.Name = "ComboBoxYear"
        Me.ComboBoxYear.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxYear.TabIndex = 98
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(292, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Year:"
        '
        'cboGolfer
        '
        Me.cboGolfer.FormattingEnabled = True
        Me.cboGolfer.Location = New System.Drawing.Point(142, 24)
        Me.cboGolfer.Name = "cboGolfer"
        Me.cboGolfer.Size = New System.Drawing.Size(121, 21)
        Me.cboGolfer.TabIndex = 95
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(295, 308)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(224, 37)
        Me.btnExit.TabIndex = 94
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'FormSponsorInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 375)
        Me.Controls.Add(Me.ButtonSubmit)
        Me.Controls.Add(Me.ListBoxSponsors)
        Me.Controls.Add(Me.ComboBoxYear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboGolfer)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormSponsorInventory"
        Me.Text = "Sponsor_Inventory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonSubmit As Button
    Friend WithEvents ListBoxSponsors As ListBox
    Friend WithEvents ComboBoxYear As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboGolfer As ComboBox
    Friend WithEvents btnExit As Button
End Class
