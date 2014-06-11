<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class proteinAlignment
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
        Me.sequence_1 = New System.Windows.Forms.TextBox
        Me.sequence_2 = New System.Windows.Forms.TextBox
        Me.score = New System.Windows.Forms.TextBox
        Me.alignSeq1 = New System.Windows.Forms.TextBox
        Me.sequence1 = New System.Windows.Forms.Label
        Me.alignSeq2 = New System.Windows.Forms.TextBox
        Me.sequence2 = New System.Windows.Forms.Label
        Me.sscore = New System.Windows.Forms.Label
        Me.Alignment = New System.Windows.Forms.Label
        Me.aSeq1 = New System.Windows.Forms.Label
        Me.aSeq2 = New System.Windows.Forms.Label
        Me.clear = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'align
        '
        Me.align.Location = New System.Drawing.Point(212, 236)
        Me.align.Name = "align"
        Me.align.Size = New System.Drawing.Size(83, 61)
        Me.align.TabIndex = 0
        Me.align.Text = "Align"
        Me.align.UseVisualStyleBackColor = True
        '
        'sequence_1
        '
        Me.sequence_1.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sequence_1.Location = New System.Drawing.Point(28, 71)
        Me.sequence_1.Multiline = True
        Me.sequence_1.Name = "sequence_1"
        Me.sequence_1.Size = New System.Drawing.Size(195, 150)
        Me.sequence_1.TabIndex = 1
        '
        'sequence_2
        '
        Me.sequence_2.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sequence_2.Location = New System.Drawing.Point(286, 71)
        Me.sequence_2.Multiline = True
        Me.sequence_2.Name = "sequence_2"
        Me.sequence_2.Size = New System.Drawing.Size(195, 150)
        Me.sequence_2.TabIndex = 2
        '
        'score
        '
        Me.score.Location = New System.Drawing.Point(142, 257)
        Me.score.Name = "score"
        Me.score.Size = New System.Drawing.Size(37, 20)
        Me.score.TabIndex = 3
        '
        'alignSeq1
        '
        Me.alignSeq1.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alignSeq1.Location = New System.Drawing.Point(51, 322)
        Me.alignSeq1.Name = "alignSeq1"
        Me.alignSeq1.Size = New System.Drawing.Size(409, 18)
        Me.alignSeq1.TabIndex = 4
        '
        'sequence1
        '
        Me.sequence1.AutoSize = True
        Me.sequence1.Location = New System.Drawing.Point(25, 55)
        Me.sequence1.Name = "sequence1"
        Me.sequence1.Size = New System.Drawing.Size(65, 13)
        Me.sequence1.TabIndex = 5
        Me.sequence1.Text = "Sequence 1"
        '
        'alignSeq2
        '
        Me.alignSeq2.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alignSeq2.Location = New System.Drawing.Point(51, 368)
        Me.alignSeq2.Name = "alignSeq2"
        Me.alignSeq2.Size = New System.Drawing.Size(409, 18)
        Me.alignSeq2.TabIndex = 6
        '
        'sequence2
        '
        Me.sequence2.AutoSize = True
        Me.sequence2.Location = New System.Drawing.Point(283, 55)
        Me.sequence2.Name = "sequence2"
        Me.sequence2.Size = New System.Drawing.Size(65, 13)
        Me.sequence2.TabIndex = 7
        Me.sequence2.Text = "Sequence 2"
        '
        'sscore
        '
        Me.sscore.AutoSize = True
        Me.sscore.Location = New System.Drawing.Point(48, 260)
        Me.sscore.Name = "sscore"
        Me.sscore.Size = New System.Drawing.Size(78, 13)
        Me.sscore.TabIndex = 8
        Me.sscore.Text = "Similarity Score"
        '
        'Alignment
        '
        Me.Alignment.AutoSize = True
        Me.Alignment.Location = New System.Drawing.Point(12, 293)
        Me.Alignment.Name = "Alignment"
        Me.Alignment.Size = New System.Drawing.Size(53, 13)
        Me.Alignment.TabIndex = 9
        Me.Alignment.Text = "Alignment"
        '
        'aSeq1
        '
        Me.aSeq1.AutoSize = True
        Me.aSeq1.Location = New System.Drawing.Point(48, 306)
        Me.aSeq1.Name = "aSeq1"
        Me.aSeq1.Size = New System.Drawing.Size(103, 13)
        Me.aSeq1.TabIndex = 10
        Me.aSeq1.Text = "Aligned Sequence 1"
        '
        'aSeq2
        '
        Me.aSeq2.AutoSize = True
        Me.aSeq2.Location = New System.Drawing.Point(48, 352)
        Me.aSeq2.Name = "aSeq2"
        Me.aSeq2.Size = New System.Drawing.Size(103, 13)
        Me.aSeq2.TabIndex = 11
        Me.aSeq2.Text = "Aligned Sequence 2"
        '
        'clear
        '
        Me.clear.Location = New System.Drawing.Point(343, 236)
        Me.clear.Name = "clear"
        Me.clear.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.clear.Size = New System.Drawing.Size(83, 61)
        Me.clear.TabIndex = 12
        Me.clear.Text = "Clear Form"
        Me.clear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Adrian Flannery"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Assignment No. 3"
        '
        'proteinAlignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 416)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.clear)
        Me.Controls.Add(Me.aSeq2)
        Me.Controls.Add(Me.aSeq1)
        Me.Controls.Add(Me.Alignment)
        Me.Controls.Add(Me.sscore)
        Me.Controls.Add(Me.sequence2)
        Me.Controls.Add(Me.alignSeq2)
        Me.Controls.Add(Me.sequence1)
        Me.Controls.Add(Me.alignSeq1)
        Me.Controls.Add(Me.score)
        Me.Controls.Add(Me.sequence_2)
        Me.Controls.Add(Me.sequence_1)
        Me.Controls.Add(Me.align)
        Me.Name = "proteinAlignment"
        Me.Text = "Protein Alignment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents align As System.Windows.Forms.Button
    Friend WithEvents sequence_1 As System.Windows.Forms.TextBox
    Friend WithEvents sequence_2 As System.Windows.Forms.TextBox
    Friend WithEvents score As System.Windows.Forms.TextBox
    Friend WithEvents alignSeq1 As System.Windows.Forms.TextBox
    Friend WithEvents sequence1 As System.Windows.Forms.Label
    Friend WithEvents alignSeq2 As System.Windows.Forms.TextBox
    Friend WithEvents sequence2 As System.Windows.Forms.Label
    Friend WithEvents sscore As System.Windows.Forms.Label
    Friend WithEvents Alignment As System.Windows.Forms.Label
    Friend WithEvents aSeq1 As System.Windows.Forms.Label
    Friend WithEvents aSeq2 As System.Windows.Forms.Label
    Friend WithEvents clear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
