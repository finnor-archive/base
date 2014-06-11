<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocalAlignment
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.sequence_1 = New System.Windows.Forms.TextBox
        Me.sequence_2 = New System.Windows.Forms.TextBox
        Me.aSequence_1 = New System.Windows.Forms.TextBox
        Me.aSequence_2 = New System.Windows.Forms.TextBox
        Me.alignSeq1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Sequence1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.sScore = New System.Windows.Forms.Label
        Me.score = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(221, 195)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 61)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Align"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'sequence_1
        '
        Me.sequence_1.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sequence_1.Location = New System.Drawing.Point(40, 36)
        Me.sequence_1.Multiline = True
        Me.sequence_1.Name = "sequence_1"
        Me.sequence_1.Size = New System.Drawing.Size(190, 153)
        Me.sequence_1.TabIndex = 1
        '
        'sequence_2
        '
        Me.sequence_2.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sequence_2.Location = New System.Drawing.Point(292, 36)
        Me.sequence_2.Multiline = True
        Me.sequence_2.Name = "sequence_2"
        Me.sequence_2.Size = New System.Drawing.Size(191, 153)
        Me.sequence_2.TabIndex = 2
        '
        'aSequence_1
        '
        Me.aSequence_1.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aSequence_1.Location = New System.Drawing.Point(40, 306)
        Me.aSequence_1.Name = "aSequence_1"
        Me.aSequence_1.Size = New System.Drawing.Size(443, 18)
        Me.aSequence_1.TabIndex = 3
        '
        'aSequence_2
        '
        Me.aSequence_2.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aSequence_2.Location = New System.Drawing.Point(40, 357)
        Me.aSequence_2.Name = "aSequence_2"
        Me.aSequence_2.Size = New System.Drawing.Size(443, 18)
        Me.aSequence_2.TabIndex = 4
        '
        'alignSeq1
        '
        Me.alignSeq1.AutoSize = True
        Me.alignSeq1.Location = New System.Drawing.Point(37, 290)
        Me.alignSeq1.Name = "alignSeq1"
        Me.alignSeq1.Size = New System.Drawing.Size(103, 13)
        Me.alignSeq1.TabIndex = 5
        Me.alignSeq1.Text = "Aligned Sequence 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 341)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Aligned Sequence 2"
        '
        'Sequence1
        '
        Me.Sequence1.AutoSize = True
        Me.Sequence1.Location = New System.Drawing.Point(37, 20)
        Me.Sequence1.Name = "Sequence1"
        Me.Sequence1.Size = New System.Drawing.Size(65, 13)
        Me.Sequence1.TabIndex = 7
        Me.Sequence1.Text = "Sequence 1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(289, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Sequence 2"
        '
        'sScore
        '
        Me.sScore.AutoSize = True
        Me.sScore.Location = New System.Drawing.Point(37, 243)
        Me.sScore.Name = "sScore"
        Me.sScore.Size = New System.Drawing.Size(78, 13)
        Me.sScore.TabIndex = 9
        Me.sScore.Text = "Similarity Score"
        '
        'score
        '
        Me.score.Location = New System.Drawing.Point(121, 236)
        Me.score.Name = "score"
        Me.score.Size = New System.Drawing.Size(49, 20)
        Me.score.TabIndex = 10
        '
        'LocalAlignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 405)
        Me.Controls.Add(Me.score)
        Me.Controls.Add(Me.sScore)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Sequence1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.alignSeq1)
        Me.Controls.Add(Me.aSequence_2)
        Me.Controls.Add(Me.aSequence_1)
        Me.Controls.Add(Me.sequence_2)
        Me.Controls.Add(Me.sequence_1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "LocalAlignment"
        Me.Text = "Local Alignment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents sequence_1 As System.Windows.Forms.TextBox
    Friend WithEvents sequence_2 As System.Windows.Forms.TextBox
    Friend WithEvents aSequence_1 As System.Windows.Forms.TextBox
    Friend WithEvents aSequence_2 As System.Windows.Forms.TextBox
    Friend WithEvents alignSeq1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Sequence1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents sScore As System.Windows.Forms.Label
    Friend WithEvents score As System.Windows.Forms.TextBox

End Class
