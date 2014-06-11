'Adrian Flannery
'Bioinformatics II
'Assignment 1


Public Class GlobalAlignment

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
        If (xDiagonal >= xLeft And xDiagonal >= xAbove) Then
            Return (xDiagonal)
        ElseIf (xLeft > xAbove) Then
            Return (xLeft)
        Else
            Return (xAbove)
        End If
    End Function
    '********************************************************************************************************

    ' Name:	similarity			
    ' Inputs	            Outputs	                    Calls   Called by	Files
    ' String sequence1	    Long[][] alignmentMatrix	p	    main	    none
    ' String sequence2		max		
    ' Processing:	Computes the values of each cell	

    Public Function similarity(ByVal sequence1 As String, ByVal sequence2 As String)
        Dim matchScore As Integer
        Dim alignmentMatrix(sequence1.Length(), sequence2.Length()) As Long

        'assigns scores to the gap rows
        For i As Integer = 0 To sequence1.Length()
            alignmentMatrix(i, 0) = i * -2
        Next i
        For j As Integer = 0 To sequence2.Length()
            alignmentMatrix(0, j) = j * -2
        Next j

        'assigns scores to the rest of the matrix
        For x As Integer = 1 To sequence1.Length()
            For y As Integer = 1 To sequence2.Length()
                matchScore = p(sequence1.Substring(x - 1, 1), sequence2.Substring(y - 1, 1))
                alignmentMatrix(x, y) = max(alignmentMatrix(x - 1, y) - 2, alignmentMatrix(x, y - 1) - 2, alignmentMatrix(x - 1, y - 1) + matchScore)
            Next y
        Next x

        'returns similarity matrix
        Return (alignmentMatrix)

    End Function
    '********************************************************************************************************

    ' Name:	getAlignment			
    ' Inputs	            Outputs	            Calls	Called by	Files
    ' Long[][] alignMatrix	String sequences	p	    main	    none
    ' String sequence1				
    ' String sequence2				
    ' Processing:	Does the traceback on the matrix and returns the alignment

    Public Function getAlignment(ByVal alignMatrix(,) As Long, ByVal sequence1 As String, ByVal sequence2 As String)
        Dim currentX As Integer = sequence1.Length()
        Dim currentY As Integer = sequence2.Length()
        Dim sequences(1) As String

        'loops from the one corner to the top left corner
        While (alignMatrix(currentX, currentY) <> 0)

            'special cases for gaps at the beginning of the sequence
            If (currentX = 0 And currentY > 0) Then
                sequences(0) = "-" + sequences(0)
                sequences(1) = sequence2.Substring(currentY - 1, 1) + sequences(1)
                currentY -= 1
            ElseIf (currentY = 0 And currentX > 0) Then
                sequences(0) = sequence1.Substring(currentX - 1, 1) + sequences(0)
                sequences(1) = "-" + sequences(1)
                currentX -= 1

                'traces back the rest of the sequences
            Else
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
    ' String Sequence 1	    Similarity score	similarity(String sequence1, String sequence 2)	                        none    	none
    ' String Sequence 2	    aligned sequence 1	getAlignment(long[][] alignMatrix, String sequence 1, String sequence 2)		
    ' aligned sequence 2			
    ' Processing:	Drives the program			

    Private Sub align_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles align.Click
        Dim seq1 As String = sequence_1.Text()
        Dim seq2 As String = sequence_2.Text()
        Dim alignMatrix = similarity(seq1, seq2)
        Dim sequences(1) As String

        'outputs score
        score.Text() = alignMatrix(seq1.Length(), seq2.Length())
        sequences = getAlignment(alignMatrix, seq1, seq2)

        'outputs sequences
        alignSeq1.Text() = sequences(0)
        alignSeq2.Text() = sequences(1)
    End Sub
    '********************************************************************************************************

End Class