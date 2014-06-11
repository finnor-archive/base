<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GlobalAlignment
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
        Me.align = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.sequence_1 = New System.Windows.Forms.TextBox
        Me.sequence_2 = New System.Windows.Forms.TextBox
        Me.score = New System.Windows.Forms.TextBox
        Me.alignSeq1 = New System.Windows.Forms.TextBox
        Me.alignSeq2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'align
        '
        Me.align.Location = New System.Drawing.Point(208, 208)
        Me.align.Name = "align"
        Me.align.Size = New System.Drawing.Size(81, 59)
        Me.align.TabIndex = 0
        Me.align.Text = "Align"
        Me.align.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sequence 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(277, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sequence 2"
        '
        'sequence_1
        '
        Me.sequence_1.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sequence_1.Location = New System.Drawing.Point(21, 25)
        Me.sequence_1.Multiline = True
        Me.sequence_1.Name = "sequence_1"
        Me.sequence_1.Size = New System.Drawing.Size(204, 172)
        Me.sequence_1.TabIndex = 3
        '
        'sequence_2
        '
        Me.sequence_2.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sequence_2.Location = New System.Drawing.Point(280, 25)
        Me.sequence_2.Multiline = True
        Me.sequence_2.Name = "sequence_2"
        Me.sequence_2.Size = New System.Drawing.Size(194, 172)
        Me.sequence_2.TabIndex = 4
        '
        'score
        '
        Me.score.Location = New System.Drawing.Point(137, 228)
        Me.score.Name = "score"
        Me.score.Size = New System.Drawing.Size(39, 20)
        Me.score.TabIndex = 5
        '
        'alignSeq1
        '
        Me.alignSeq1.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alignSeq1.Location = New System.Drawing.Point(31, 354)
        Me.alignSeq1.Name = "alignSeq1"
        Me.alignSeq1.Size = New System.Drawing.Size(443, 18)
        Me.alignSeq1.TabIndex = 6
        '
        'alignSeq2
        '
        Me.alignSeq2.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alignSeq2.Location = New System.Drawing.Point(31, 402)
        Me.alignSeq2.Name = "alignSeq2"
        Me.alignSeq2.Size = New System.Drawing.Size(443, 18)
        Me.alignSeq2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 386)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Aligned Sequence 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 338)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Aligned Sequence 1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(53, 231)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Similarity Score"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 308)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Global Alignment"
        '
        'GlobalAlignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 434)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.alignSeq2)
        Me.Controls.Add(Me.alignSeq1)
        Me.Controls.Add(Me.score)
        Me.Controls.Add(Me.sequence_2)
        Me.Controls.Add(Me.sequence_1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.align)
        Me.Name = "GlobalAlignment"
        Me.Text = "Global Alignment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents align As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents sequence_1 As System.Windows.Forms.TextBox
    Friend WithEvents sequence_2 As System.Windows.Forms.TextBox
    Friend WithEvents score As System.Windows.Forms.TextBox
    Friend WithEvents alignSeq1 As System.Windows.Forms.TextBox
    Friend WithEvents alignSeq2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
