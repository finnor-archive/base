<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class blast
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
        Me.title = New System.Windows.Forms.Label
        Me.assignment = New System.Windows.Forms.Label
        Me.inputSeq = New System.Windows.Forms.Label
        Me.inputS = New System.Windows.Forms.TextBox
        Me.sequenceRet = New System.Windows.Forms.Label
        Me.sequenceR = New System.Windows.Forms.TextBox
        Me.querySeq = New System.Windows.Forms.Label
        Me.queryS = New System.Windows.Forms.TextBox
        Me.retrievedSeq = New System.Windows.Forms.Label
        Me.retrievedS = New System.Windows.Forms.TextBox
        Me.doMSA = New System.Windows.Forms.Button
        Me.clearForm = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(9, 9)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(102, 16)
        Me.title.TabIndex = 0
        Me.title.Text = "Adrian Flannery"
        '
        'assignment
        '
        Me.assignment.AutoSize = True
        Me.assignment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assignment.Location = New System.Drawing.Point(9, 25)
        Me.assignment.Name = "assignment"
        Me.assignment.Size = New System.Drawing.Size(112, 16)
        Me.assignment.TabIndex = 1
        Me.assignment.Text = "Assignment No. 4"
        '
        'inputSeq
        '
        Me.inputSeq.AutoSize = True
        Me.inputSeq.Location = New System.Drawing.Point(13, 148)
        Me.inputSeq.Name = "inputSeq"
        Me.inputSeq.Size = New System.Drawing.Size(86, 13)
        Me.inputSeq.TabIndex = 2
        Me.inputSeq.Text = "Input Sequence:"
        '
        'inputS
        '
        Me.inputS.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputS.Location = New System.Drawing.Point(123, 77)
        Me.inputS.Multiline = True
        Me.inputS.Name = "inputS"
        Me.inputS.Size = New System.Drawing.Size(239, 168)
        Me.inputS.TabIndex = 3
        '
        'sequenceRet
        '
        Me.sequenceRet.AutoSize = True
        Me.sequenceRet.Location = New System.Drawing.Point(9, 350)
        Me.sequenceRet.Name = "sequenceRet"
        Me.sequenceRet.Size = New System.Drawing.Size(108, 13)
        Me.sequenceRet.TabIndex = 4
        Me.sequenceRet.Text = "Sequence Retrieved:"
        '
        'sequenceR
        '
        Me.sequenceR.Location = New System.Drawing.Point(123, 347)
        Me.sequenceR.Name = "sequenceR"
        Me.sequenceR.Size = New System.Drawing.Size(271, 20)
        Me.sequenceR.TabIndex = 5
        '
        'querySeq
        '
        Me.querySeq.AutoSize = True
        Me.querySeq.Location = New System.Drawing.Point(9, 397)
        Me.querySeq.Name = "querySeq"
        Me.querySeq.Size = New System.Drawing.Size(90, 13)
        Me.querySeq.TabIndex = 6
        Me.querySeq.Text = "Query Sequence:"
        '
        'queryS
        '
        Me.queryS.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.queryS.Location = New System.Drawing.Point(123, 397)
        Me.queryS.Name = "queryS"
        Me.queryS.Size = New System.Drawing.Size(635, 18)
        Me.queryS.TabIndex = 7
        '
        'retrievedSeq
        '
        Me.retrievedSeq.AutoSize = True
        Me.retrievedSeq.Location = New System.Drawing.Point(9, 373)
        Me.retrievedSeq.Name = "retrievedSeq"
        Me.retrievedSeq.Size = New System.Drawing.Size(108, 13)
        Me.retrievedSeq.TabIndex = 8
        Me.retrievedSeq.Text = "Retrieved Sequence:"
        '
        'retrievedS
        '
        Me.retrievedS.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.retrievedS.Location = New System.Drawing.Point(123, 373)
        Me.retrievedS.Name = "retrievedS"
        Me.retrievedS.Size = New System.Drawing.Size(635, 18)
        Me.retrievedS.TabIndex = 9
        '
        'doMSA
        '
        Me.doMSA.Location = New System.Drawing.Point(479, 121)
        Me.doMSA.Name = "doMSA"
        Me.doMSA.Size = New System.Drawing.Size(72, 66)
        Me.doMSA.TabIndex = 10
        Me.doMSA.Text = "BLAST"
        Me.doMSA.UseVisualStyleBackColor = True
        '
        'clearForm
        '
        Me.clearForm.Location = New System.Drawing.Point(634, 121)
        Me.clearForm.Name = "clearForm"
        Me.clearForm.Size = New System.Drawing.Size(72, 66)
        Me.clearForm.TabIndex = 11
        Me.clearForm.Text = "Clear Form"
        Me.clearForm.UseVisualStyleBackColor = True
        '
        'blast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 490)
        Me.Controls.Add(Me.clearForm)
        Me.Controls.Add(Me.doMSA)
        Me.Controls.Add(Me.retrievedS)
        Me.Controls.Add(Me.retrievedSeq)
        Me.Controls.Add(Me.queryS)
        Me.Controls.Add(Me.querySeq)
        Me.Controls.Add(Me.sequenceR)
        Me.Controls.Add(Me.sequenceRet)
        Me.Controls.Add(Me.inputS)
        Me.Controls.Add(Me.inputSeq)
        Me.Controls.Add(Me.assignment)
        Me.Controls.Add(Me.title)
        Me.Name = "blast"
        Me.Text = "BLAST"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents title As System.Windows.Forms.Label
    Friend WithEvents assignment As System.Windows.Forms.Label
    Friend WithEvents inputSeq As System.Windows.Forms.Label
    Friend WithEvents inputS As System.Windows.Forms.TextBox
    Friend WithEvents sequenceRet As System.Windows.Forms.Label
    Friend WithEvents sequenceR As System.Windows.Forms.TextBox
    Friend WithEvents querySeq As System.Windows.Forms.Label
    Friend WithEvents queryS As System.Windows.Forms.TextBox
    Friend WithEvents retrievedSeq As System.Windows.Forms.Label
    Friend WithEvents retrievedS As System.Windows.Forms.TextBox
    Friend WithEvents doMSA As System.Windows.Forms.Button
    Friend WithEvents clearForm As System.Windows.Forms.Button

End Class
