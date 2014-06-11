'Adrian Flannery
'Bioinformatics II
'Assignment 3


Public Class proteinAlignment

    ' the BLOSUM62 substitution matrix; It is a very tedious implementation, but allows the program to be more user friendly
    Public blosum62(,) As String = {{"", "A", "R", "N", "D", "C", "Q", "E", "G", "H", "I", "L", "K", "M", "F", "P", "S", "T", "W", "Y", "V"}, {"A", "4", "-1", "-2", "-2", "0", "-1", "-1", "0", "-2", "-1", "-1", "-1", "-1", "-2", "-1", "1", "0", "-3", "-2", "0"}, {"R", "-1", "5", "0", "-2", "-3", "1", "0", "-2", "0", "-3", "-2", "2", "-1", "-3", "-2", "-1", "-1", "-3", "-2", "-3"}, {"N", "-2", "0", "6", "1", "-3", "0", "0", "0", "1", "-3", "-3", "0", "-2", "-3", "-2", "1", "0", "-4", "-2", "-3"}, {"D", "-2", "-2", "1", "6", "-3", "0", "2", "-1", "-1", "-3", "-4", "-1", "-3", "-3", "-1", "0", "-1", "-4", "-3", "-3"}, {"C", "0", "-3", "-3", "-3", "9", "-3", "-4", "-3", "-3", "-1", "-1", "-3", "-1", "-2", "-3", "-1", "-1", "-2", "-2", "-1"}, {"Q", "-1", "1", "0", "0", "-3", "5", "2", "-2", "0", "-3", "-2", "1", "0", "-3", "-1", "0", "-1", "-2", "-1", "-2"}, {"E", "-1", "0", "0", "2", "-4", "2", "5", "-2", "0", "-3", "-3", "1", "-2", "-3", "-1", "0", "-1", "-3", "-2", "-2"}, {"G", "0", "-2", "0", "-1", "-3", "-2", "-2", "6", "-2", "-4", "-4", "-2", "-3", "-3", "-2", "0", "-2", "-2", "-3", "-3"}, {"H", "-2", "0", "1", "-1", "-3", "0", "0", "-2", "8", "-3", "-3", "-1", "-2", "-1", "-2", "-1", "-2", "-2", "2", "-3"}, {"I", "-1", "-3", "-3", "-3", "-1", "-3", "-3", "-4", "-3", "4", "2", "-3", "1", "0", "-3", "-2", "-1", "-3", "-1", "3"}, {"L", "-1", "-2", "-3", "-4", "-1", "-2", "-3", "-4", "-3", "2", "4", "-2", "2", "0", "-3", "-2", "-1", "-2", "-1", "1"}, {"K", "-1", "2", "0", "-1", "-3", "1", "1", "-2", "-1", "-3", "-2", "5", "-1", "-3", "-1", "0", "-1", "-3", "-2", "-2"}, {"M", "-1", "-1", "-2", "-3", "-1", "0", "-2", "-3", "-2", "1", "2", "-1", "5", "0", "-2", "-1", "-1", "-1", "-1", "1"}, {"F", "-2", "-3", "-3", "-3", "-2", "-3", "-3", "-3", "-1", "0", "0", "-3", "0", "6", "-4", "-2", "-2", "1", "3", "-1"}, {"P", "-1", "-2", "-2", "-1", "-3", "-1", "-1", "-2", "-2", "-3", "-3", "-1", "-2", "-4", "7", "-1", "-1", "-4", "-3", "-2"}, {"S", "1", "-1", "1", "0", "-1", "0", "0", "0", "-1", "-2", "-2", "0", "-1", "-2", "-1", "4", "1", "-3", "-2", "-2"}, {"T", "0", "-1", "0", "-1", "-1", "-1", "-1", "-2", "-2", "-1", "-1", "-1", "-1", "-2", "-1", "1", "5", "-2", "-2", "0"}, {"W", "-3", "-3", "-4", "-4", "-2", "-2", "-3", "-2", "-2", "-3", "-2", "-3", "-1", "1", "-4", "-3", "-2", "11", "2", "-3"}, {"Y", "-2", "-2", "-2", "-3", "-2", "-1", "-2", "-3", "2", "-1", "-1", "-2", "-1", "3", "-3", "-2", "-2", "2", "7", "-1"}, {"V", "0", "-3", "-3", "-3", "-1", "-2", "-2", "-3", "-3", "3", "1", "-2", "1", "-1", "-2", "-2", "0", "-3", "-1", "4"}}

    '********************************************************************************************************
    ' Name:	p			
    ' Inputs	            Outputs	                Calls   Called by	    Files
    ' String aminoA1	    ‘substitution score'   	none	similarity	    none
    ' String aminoA2			                            getAlignment	
    ' Processing:	Compares amino acids and returns the substitution score

    Public Function p(ByVal aminoA1 As String, ByVal aminoA2 As String)
        Dim x As Integer = 0
        Dim y As Integer = 0
        For i As Integer = 1 To 20
            If (blosum62(0, i) = aminoA1) Then
                y = i
            End If
        Next i
        For i As Integer = 0 To 20
            If (blosum62(i, 0) = aminoA2) Then
                x = i
            End If
        Next i

        Return (blosum62(x, y))
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
    ' String sequence2		                            max		
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
    ' Long[][] alignMatrix	String[] sequences	p	    main	    none
    ' String sequence1				
    ' String sequence2				
    ' Processing:	Does the traceback on the matrix and returns the global alignment

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

    ' Name:	Main			
    ' Inputs	            Outputs	            Calls	                                                                Called by	Files
    ' String Sequence 1	    Similarity score	similarity(String sequence1, String sequence 2)	                        none    	none
    ' String Sequence 2	    aligned sequence 1	getAlignment(long[][] alignMatrix, String sequence 1, String sequence 2)		
    '                       aligned sequence 2			
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

    Private Sub clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clear.Click
        sequence_1.Text() = ""
        sequence_2.Text() = ""
        score.Text() = ""
        alignSeq1.Text() = ""
        alignSeq2.Text() = ""

    End Sub
End Class