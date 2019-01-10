<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LedgerSummary
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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fYes = New System.Windows.Forms.RadioButton()
        Me.fNo = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(396, 230)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.fNo)
        Me.GroupBox1.Controls.Add(Me.fYes)
        Me.GroupBox1.Location = New System.Drawing.Point(317, 163)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(154, 47)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Floating"
        '
        'fYes
        '
        Me.fYes.AutoSize = True
        Me.fYes.Location = New System.Drawing.Point(17, 19)
        Me.fYes.Name = "fYes"
        Me.fYes.Size = New System.Drawing.Size(43, 17)
        Me.fYes.TabIndex = 0
        Me.fYes.TabStop = True
        Me.fYes.Text = "Yes"
        Me.fYes.UseVisualStyleBackColor = True
        '
        'fNo
        '
        Me.fNo.AutoSize = True
        Me.fNo.Location = New System.Drawing.Point(96, 19)
        Me.fNo.Name = "fNo"
        Me.fNo.Size = New System.Drawing.Size(39, 17)
        Me.fNo.TabIndex = 1
        Me.fNo.TabStop = True
        Me.fNo.Text = "No"
        Me.fNo.UseVisualStyleBackColor = True
        '
        'LedgerSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 288)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Name = "LedgerSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ledger Summary Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPrint As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents fNo As RadioButton
    Friend WithEvents fYes As RadioButton
End Class
