<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.btnGolfers = New System.Windows.Forms.Button()
        Me.btnGS = New System.Windows.Forms.Button()
        Me.btnSponsor = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGolfers
        '
        Me.btnGolfers.Location = New System.Drawing.Point(23, 85)
        Me.btnGolfers.Name = "btnGolfers"
        Me.btnGolfers.Size = New System.Drawing.Size(131, 69)
        Me.btnGolfers.TabIndex = 0
        Me.btnGolfers.Text = "Manage Golfers"
        Me.btnGolfers.UseVisualStyleBackColor = True
        '
        'btnGS
        '
        Me.btnGS.Location = New System.Drawing.Point(256, 85)
        Me.btnGS.Name = "btnGS"
        Me.btnGS.Size = New System.Drawing.Size(131, 69)
        Me.btnGS.TabIndex = 1
        Me.btnGS.Text = "Manage Statistics"
        Me.btnGS.UseVisualStyleBackColor = True
        '
        'btnSponsor
        '
        Me.btnSponsor.Location = New System.Drawing.Point(23, 233)
        Me.btnSponsor.Name = "btnSponsor"
        Me.btnSponsor.Size = New System.Drawing.Size(131, 69)
        Me.btnSponsor.TabIndex = 2
        Me.btnSponsor.Text = "Manage Sponsors"
        Me.btnSponsor.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(266, 233)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(131, 69)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 328)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSponsor)
        Me.Controls.Add(Me.btnGS)
        Me.Controls.Add(Me.btnGolfers)
        Me.Name = "frmMain"
        Me.Text = "GOLF-A-THON"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGolfers As Button
    Friend WithEvents btnGS As Button
    Friend WithEvents btnSponsor As Button
    Friend WithEvents btnExit As Button
End Class
