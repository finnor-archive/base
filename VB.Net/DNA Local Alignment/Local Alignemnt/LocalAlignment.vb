'Adrian Flannery
'Bioinformatics II
'Assignment 2


Public Class LocalAlignment

    '********************************************************************************************************
    ' Name:	p			
    ' Inputs	            Outputs	                Calls   Called by	    Files
    ' String nucleotide1	‘match/mismatch score'	none	similarity	    none
    ' String nucleotide2			                        getAlignment	
    ' Processing:	Compares nucleotides and returns match/mismatch score

    Public Function p(ByVal nucleotide1 As String, ByVal nucleotide2 As String)
        If (nucleotide1 = nucleotide2) Then
            Return (5)
        Else
            Return (2)
        End If
    End Function
    '********************************************************************************************************

    ' Name:	max			
    ' Inputs	    Outputs	        Calls	Called by	Files
    ' int xLeft	    'max score' 	none	similarity	none
    ' int xAbove				
    ' int xDiagonal				
    ' Processing:	Compares the three paths and returns the max score

    Public Function max(ByVal xLeft As Long, ByVal xAbove As Long, ByVal xDiagonal As Long)
        'checks to see if the diagonal is the max
        If (xDiagonal >= xLeft And xDiagonal >= xAbove) Then
            Return (xDiagonal)

            'checks to see if the left is the max
        ElseIf (xLeft > xAbove) Then
            Return (xLeft)

            'else above is the max score
        Else
            Return (xAbove)
        End If
    End Function
    '********************************************************************************************************

    ' Name:	similarity			
    ' Inputs	            Outputs	                    Calls   Called by	Files
    ' String sequence1	    Long[][] alignmentMatrix	p	    main	    none
    ' String sequence2		                            max		
    ' Processing:	Computes the values of each cell	

    Public Function similarity(ByVal sequence1 As String, ByVal sequence2 As String)
        Dim matchScore As Integer
        Dim alignmentMatrix(sequence1.Length(), sequence2.Length()) As Long

        'assigns scores to the gap rows which for local alignment is 0
        For i As Integer = 0 To sequence1.Length()
            alignmentMatrix(i, 0) = 0
        Next i
        For j As Integer = 0 To sequence2.Length()
            alignmentMatrix(0, j) = 0
        Next j

        'assigns scores to the rest of the matrix
        For x As Integer = 1 To sequence1.Length()
            For y As Integer = 1 To sequence2.Length()
                matchScore = p(sequence1.Substring(x - 1, 1), sequence2.Substring(y - 1, 1))
                'checks to see if the score of the cell is > 0
                If max(alignmentMatrix(x - 1, y) - 2, alignmentMatrix(x, y - 1) - 2, alignmentMatrix(x - 1, y - 1) + matchScore) > 0 Then
                    alignmentMatrix(x, y) = max(alignmentMatrix(x - 1, y) - 2, alignmentMatrix(x, y - 1) - 2, alignmentMatrix(x - 1, y - 1) + matchScore)

                    'else if the a score is <= 0 then the cell is made 0
                Else
                    alignmentMatrix(x, y) = 0
                End If
            Next y
        Next x

        'returns similarity matrix
        Return (alignmentMatrix)

    End Function
    '********************************************************************************************************

    ' Name:	getAlignment			
    ' Inputs	            Outputs	            Calls	Called by	Files
    ' Long[][] alignMatrix	String[] sequences	p	    main	    none
    ' String sequence1				
    ' String sequence2		
    ' int maxCellX
    ' int maxCellY
    ' Processing:	Does the traceback on the matrix and returns the local alignment

    Public Function getAlignment(ByVal alignMatrix(,) As Long, ByVal sequence1 As String, ByVal sequence2 As String, ByVal maxCellX As Integer, ByVal maxCellY As Integer)
        Dim currentX As Integer
        Dim currentY As Integer
        Dim sequences(1) As String

        currentX = maxCellX
        currentY = maxCellY

        'loops from the one corner to a cell that contains a 0
        While (alignMatrix(currentX, currentY) <> 0)
            'checks for diagonal path
            If (alignMatrix(currentX, currentY) = (alignMatrix(currentX - 1, currentY - 1) + p(sequence1.Substring(currentX - 1, 1), sequence2.Substring(currentY - 1, 1)))) Then
                sequences(0) = sequence1.Substring(currentX - 1, 1) + sequences(0)
                sequences(1) = sequence2.Substring(currentY - 1, 1) + sequences(1)
                currentX -= 1
                currentY -= 1

                'checks for the path from the left
            ElseIf (alignMatrix(currentX, currentY) = (alignMatrix(currentX - 1, currentY) - 2)) Then
                sequences(0) = sequence1.Substring(currentX - 1, 1) + sequences(0)
                sequences(1) = "-" + sequences(1)
                currentX -= 1

                'checks for the path from above
            ElseIf (alignMatrix(currentX, currentY) = (alignMatrix(currentX, currentY - 1) - 2)) Then
                sequences(0) = "-" + sequences(0)
                sequences(1) = sequence2.Substring(currentY - 1, 1) + sequences(1)
                currentY -= 1
            End If

        End While

        'returns the sequences
        Return (sequences)
    End Function
    '********************************************************************************************************

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    '********************************************************************************************************

    ' Name:	Main			
    ' Inputs	            Outputs	            Calls	                                                                Called by	Files
    ' String seq1	    'Similarity score'	    similarity(String sequence1, String sequence 2)	                        none	    none
    ' String seq2	    'aligned sequence 1'	getAlignment(long[][] alignMatrix, String sequence 1, String sequence 2)		
    '                   'aligned sequence 2'			
    ' Processing:	Drives the program			

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim seq1 As String = sequence_1.Text()
        Dim seq2 As String = sequence_2.Text()
        Dim maxCellX As Integer = 1
        Dim maxCellY As Integer = 1
        Dim maxScore As Long = 0
        Dim alignMatrix = similarity(seq1, seq2)
        Dim sequences(1) As String

        'loops through the matrix to find the largest score
        For x As Integer = 1 To seq1.Length()
            For y As Integer = 1 To seq2.Length()
                If alignMatrix(x, y) > maxScore Then
                    maxScore = alignMatrix(x, y)
                    maxCellX = x
                    maxCellY = y
                End If
            Next y
        Next x

        'outputs score
        score.Text() = alignMatrix(maxCellX, maxCellY)

        sequences = getAlignment(alignMatrix, seq1, seq2, maxCellX, maxCellY)

        'outputs sequences
        aSequence_1.Text() = sequences(0)
        aSequence_2.Text() = sequences(1)
    End Sub
    '********************************************************************************************************

End Class

