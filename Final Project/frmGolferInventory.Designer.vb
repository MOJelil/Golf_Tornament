<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGolferInventory
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSponsor = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxYear = New System.Windows.Forms.ComboBox()
        Me.ListBoxGolfers = New System.Windows.Forms.ListBox()
        Me.ButtonSubmit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Sponsor:"
        '
        'cboSponsor
        '
        Me.cboSponsor.FormattingEnabled = True
        Me.cboSponsor.Location = New System.Drawing.Point(123, 20)
        Me.cboSponsor.Name = "cboSponsor"
        Me.cboSponsor.Size = New System.Drawing.Size(149, 21)
        Me.cboSponsor.TabIndex = 87
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(323, 299)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(244, 37)
        Me.btnExit.TabIndex = 86
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(320, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Year:"
        '
        'ComboBoxYear
        '
        Me.ComboBoxYear.FormattingEnabled = True
        Me.ComboBoxYear.Location = New System.Drawing.Point(418, 20)
        Me.ComboBoxYear.Name = "ComboBoxYear"
        Me.ComboBoxYear.Size = New System.Drawing.Size(149, 21)
        Me.ComboBoxYear.TabIndex = 90
        '
        'ListBoxGolfers
        '
        Me.ListBoxGolfers.FormattingEnabled = True
        Me.ListBoxGolfers.Location = New System.Drawing.Point(28, 85)
        Me.ListBoxGolfers.Name = "ListBoxGolfers"
        Me.ListBoxGolfers.Size = New System.Drawing.Size(539, 199)
        Me.ListBoxGolfers.TabIndex = 91
        '
        'ButtonSubmit
        '
        Me.ButtonSubmit.Location = New System.Drawing.Point(28, 299)
        Me.ButtonSubmit.Name = "ButtonSubmit"
        Me.ButtonSubmit.Size = New System.Drawing.Size(210, 37)
        Me.ButtonSubmit.TabIndex = 93
        Me.ButtonSubmit.Text = "Submit"
        Me.ButtonSubmit.UseVisualStyleBackColor = True
        '
        'frmGolferInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 359)
        Me.Controls.Add(Me.ButtonSubmit)
        Me.Controls.Add(Me.ListBoxGolfers)
        Me.Controls.Add(Me.ComboBoxYear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboSponsor)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmGolferInventory"
        Me.Text = "Golfer_Inventory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents cboSponsor As ComboBox
    Friend WithEvents btnExit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBoxYear As ComboBox
    Friend WithEvents ListBoxGolfers As ListBox
    Friend WithEvents ButtonSubmit As Button
End Class
