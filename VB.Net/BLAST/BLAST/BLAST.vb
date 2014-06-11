'Adrian Flannery
'BLAST.vb
'Assignment No. 4
'Bioinformatics II



'----------------------------------------------------------------------------------------------------------------
Public Class blast

    ' the BLOSUM62 substitution matrix
    Public blosum62(,) As String = {{"", "A", "R", "N", "D", "C", "Q", "E", "G", "H", "I", "L", "K", "M", "F", "P", "S", "T", "W", "Y", "V"}, {"A", "4", "-1", "-2", "-2", "0", "-1", "-1", "0", "-2", "-1", "-1", "-1", "-1", "-2", "-1", "1", "0", "-3", "-2", "0"}, {"R", "-1", "5", "0", "-2", "-3", "1", "0", "-2", "0", "-3", "-2", "2", "-1", "-3", "-2", "-1", "-1", "-3", "-2", "-3"}, {"N", "-2", "0", "6", "1", "-3", "0", "0", "0", "1", "-3", "-3", "0", "-2", "-3", "-2", "1", "0", "-4", "-2", "-3"}, {"D", "-2", "-2", "1", "6", "-3", "0", "2", "-1", "-1", "-3", "-4", "-1", "-3", "-3", "-1", "0", "-1", "-4", "-3", "-3"}, {"C", "0", "-3", "-3", "-3", "9", "-3", "-4", "-3", "-3", "-1", "-1", "-3", "-1", "-2", "-3", "-1", "-1", "-2", "-2", "-1"}, {"Q", "-1", "1", "0", "0", "-3", "5", "2", "-2", "0", "-3", "-2", "1", "0", "-3", "-1", "0", "-1", "-2", "-1", "-2"}, {"E", "-1", "0", "0", "2", "-4", "2", "5", "-2", "0", "-3", "-3", "1", "-2", "-3", "-1", "0", "-1", "-3", "-2", "-2"}, {"G", "0", "-2", "0", "-1", "-3", "-2", "-2", "6", "-2", "-4", "-4", "-2", "-3", "-3", "-2", "0", "-2", "-2", "-3", "-3"}, {"H", "-2", "0", "1", "-1", "-3", "0", "0", "-2", "8", "-3", "-3", "-1", "-2", "-1", "-2", "-1", "-2", "-2", "2", "-3"}, {"I", "-1", "-3", "-3", "-3", "-1", "-3", "-3", "-4", "-3", "4", "2", "-3", "1", "0", "-3", "-2", "-1", "-3", "-1", "3"}, {"L", "-1", "-2", "-3", "-4", "-1", "-2", "-3", "-4", "-3", "2", "4", "-2", "2", "0", "-3", "-2", "-1", "-2", "-1", "1"}, {"K", "-1", "2", "0", "-1", "-3", "1", "1", "-2", "-1", "-3", "-2", "5", "-1", "-3", "-1", "0", "-1", "-3", "-2", "-2"}, {"M", "-1", "-1", "-2", "-3", "-1", "0", "-2", "-3", "-2", "1", "2", "-1", "5", "0", "-2", "-1", "-1", "-1", "-1", "1"}, {"F", "-2", "-3", "-3", "-3", "-2", "-3", "-3", "-3", "-1", "0", "0", "-3", "0", "6", "-4", "-2", "-2", "1", "3", "-1"}, {"P", "-1", "-2", "-2", "-1", "-3", "-1", "-1", "-2", "-2", "-3", "-3", "-1", "-2", "-4", "7", "-1", "-1", "-4", "-3", "-2"}, {"S", "1", "-1", "1", "0", "-1", "0", "0", "0", "-1", "-2", "-2", "0", "-1", "-2", "-1", "4", "1", "-3", "-2", "-2"}, {"T", "0", "-1", "0", "-1", "-1", "-1", "-1", "-2", "-2", "-1", "-1", "-1", "-1", "-2", "-1", "1", "5", "-2", "-2", "0"}, {"W", "-3", "-3", "-4", "-4", "-2", "-2", "-3", "-2", "-2", "-3", "-2", "-3", "-1", "1", "-4", "-3", "-2", "11", "2", "-3"}, {"Y", "-2", "-2", "-2", "-3", "-2", "-1", "-2", "-3", "2", "-1", "-1", "-2", "-1", "3", "-3", "-2", "-2", "2", "7", "-1"}, {"V", "0", "-3", "-3", "-3", "-1", "-2", "-2", "-3", "-3", "3", "1", "-2", "1", "-1", "-2", "-2", "0", "-3", "-1", "4"}}

    '---------------------------------------------------------------
    'Name:	            Private buildWords			
    'Inputs	            Outputs	    Calls	        Called by	Files
    'String sequence	Hash() hSW	Hash.insert()	doMSA()	    none
    '		                        p()		
    'Processing:	    Fills a hash table with Words() containers 
    '---------------------------------------------------------------
    Private Function buildWords(ByVal sequence As String) As Hash

        Dim word As String
        Dim hSW As New Hash()
        Dim tempx As String
        Dim tempy As String
        Dim tempz As String

        Dim tempi As String = sequence.Substring(0, 1)
        Dim tempj As String = sequence.Substring(1, 1)
        Dim tempk As String = sequence.Substring(2, 1)

        Dim tempScorex As Integer
        Dim tempScorey As Integer
        Dim tempScorez As Integer
        Dim tempScore As Integer


        For i = 0 To sequence.Length - 3 Step 1      'goes through the sequence one 3-letter word at a time
            word = sequence.Substring(i, 3)          'builds word
            hSW.insert(word, i)                      'exact matchs always are added regardless of threshold
            For x = 1 To 20 Step 1                   'checks for all other 3-letter words that exceed threshold
                tempx = blosum62(x, 0)
                For y = 1 To 20 Step 1
                    tempy = blosum62(y, 0)
                    For z = 1 To 20 Step 1

                        tempz = blosum62(z, 0)

                        tempScorex = p(tempx, tempi)
                        tempScorey = p(tempy, tempj)
                        tempScorez = p(tempz, tempk)
                        tempScore = tempScorex + tempScorey + tempScorez

                        'adds word if threshold is exceeded
                        If (tempScore >= 11) Then
                            hSW.insert((blosum62(x, 0) + blosum62(y, 0) + blosum62(z, 0)), i)
                        End If

                        tempi = tempj
                        tempj = tempk
                        If ((i + 4) < sequence.Length) Then
                            tempk = sequence.Substring(i + 3, 1)
                        End If

                    Next z
                Next y
            Next x
        Next i

        Return hSW
    End Function
    '---------------------------------------------------------------







    '---------------------------------------------------------------
    'Name:	                    Private findMatchs			
    'Inputs	                    Outputs	                        Calls	                    Called by	Files
    'Hash() highScoringWords	Int ‘high score sequence name’	Hash.find()	                doMSA()	    none
    'String querySeq	        String  ‘high score sequence’	Hash.retrieveWord()		
    '	                        String ‘query sequence’	        Words.getLocations()		
    '		                                                    getLocalAlignmentScore()		
    'Processing:	            Loops through each trimer of AAs in each sequence in the database and calls to build alignment if the trimer is in the hash table
    '---------------------------------------------------------------
    Private Sub findMatchs(ByVal highScoringWords As Hash, ByVal querySeq As String)

        Dim dataBase(8) As String
        'HBB	hemoglobin, beta	    Homo sapiens
        dataBase(0) = "MVHLTPEEKSAVTALWGKVNVDEVGGEALGRLLVVYPWTQRFFESFGDLSTPDAVMGNPKVKAHGKKVLGAFSDGLAHLDNLKGTFATLSELHCDKLHVD"
        'HBG1	hemoglobin, gamma A	    Pan troglodytes
        dataBase(1) = "MGHFTEEDKATITSLWGKVNVEDAGGETLGRLLVVYPWTQRFFDSFGNLSSASAIMGNPKVKAHGKKVLTSLGDAIKHLDDLKGTFAQLSELHCDKLHVD"
        'HBQ1	hemoglobin, theta 1	    Bos taurus
        dataBase(2) = "MVLAPADRAAVLALWRKLGTNVGIYTTEALERTFVAFPSSKTYFLHLNLSPGSAQVAAHGQKVADALSLAVNHLDDLPGTLSYLRELHTHKLRVDPVFFK"
        'CFTR,  Homo sapiens
        dataBase(3) = "MQRSPLEKASVVSKLFFSWTRPILRKGYRQRLELSDIYQIPSVDSADNLSEKLEREWDRELASKKNPKLINALRRCFFWRFMFYGIFLYLGEVTKAVQPL"
        'CFTR,  Mus musculus
        dataBase(4) = "MQKSPLEKASFISKLFFSWTTPILRKGYRHHLELSDIYQAPSADSADHLSEKLEREWDREQASKKNPQLIHALRRCFFWRFLFYGILLYLGEVTKAVQPV"
        'CFTR,  Canis lupus familiaris
        dataBase(5) = "MQRSPLEKASVLSKLFFSWTRPILIKGYRQRLELSDIYQVPSTDSADHLSEKLEREWDRELASKKNPKLINALRRCFFWRFAFYGILLYLGEVTKAVQPL"
        'TRYX3	trypsin X3	Homo sapiens
        dataBase(6) = "MKFILLWALLNLTVALAFNPDYTVSSTPPYLVYLKSDYLPCAGVLIHPLWVITAAHCNLPKLRVILGVTIPADSNEKHLQVIGYEKMIHHPHFSVTSIDH"
        'Tryx5	trypsin X5	Rattus norvegicus
        dataBase(7) = "MKTFIIFALLSLAASYPEVVLKGDQDSDEYLPENFNVPYMAYLKSSPEPCVGTLIDPLWVLTAAHCSLPTKIRLGVYRPNIKNEKEQIHGYSLTVVHPNF"
        'LOC609095	similar to trypsin X5	Canis lupus familiaris
        dataBase(8) = "MKPCLIFTLLSTAGVVLARDSKDDDLNLPEDFTIPYMVYLQSSPEPCVGSLIHPEWVLTAAHCSSPVKIRLGVYQPSIRNKKEQIRNYSLIIPAPEFKAQ"


        Dim maxScore As Integer = 0
        Dim score As Integer = 0
        Dim maxSeq As Integer = 0
        Dim currentWord As Words
        Dim locations() As Integer
        Dim counter As Integer = 0




        For i = 0 To 8 Step 1           'loops through each sequence in database
            For j = 0 To dataBase(i).Length() - 3 Step 1      'finds each three-letter word in each sequence
                If highScoringWords.find((dataBase(i).Substring(j, 3))) <> -1 Then   'checks if target is in hash
                    currentWord = highScoringWords.retrieveWord(dataBase(i).Substring(j, 3))   'gets container at the hash position
                    locations = currentWord.getLocations()    'gets locations that the query word appears
                    counter = 0
                    While (locations(counter) <> -1)       'goes through locations and builds local alignment for each
                        score = getLocalAlignmentScore(dataBase(i), j, querySeq, locations(counter))
                        If (score > maxScore) Then            'finds max score and best sequence
                            maxScore = score
                            maxSeq = i
                        End If
                        counter = counter + 1
                    End While
                End If
            Next j
        Next i





        Select Case maxSeq              'displays results
            Case 0
                sequenceR.Text() = "HBB     hemoglobin, beta     Homo sapiens"
            Case 1
                sequenceR.Text() = "HBG1     hemoglobin, gamma A     Pan troglodytes"
            Case 2
                sequenceR.Text() = "HBQ1     hemoglobin, theta 1     Bos taurus"
            Case 3
                sequenceR.Text() = "CFTR,     Homo sapiens"
            Case 4
                sequenceR.Text() = "CFTR,     Mus musculus"
            Case 5
                sequenceR.Text() = "CFTR,     Canis lupus familiaris"
            Case 6
                sequenceR.Text() = "TRYX3     trypsin X3     Homo sapiens"
            Case 7
                sequenceR.Text() = "Tryx5     trypsin X5     Rattus norvegicus"
            Case 8
                sequenceR.Text() = "LOC609095     similar to trypsin X5     Canis lupus familiaris"
        End Select

        retrievedS.Text() = dataBase(maxSeq)

        queryS.Text() = querySeq

    End Sub
    '---------------------------------------------------------------






    '---------------------------------------------------------------
    'Name:	        Private getLocalAlignmentScore			
    'Inputs	        Outputs	        Calls	Called by	Files
    'String tarSeq	Int ‘score’	    p()	    findMatchs	none
    'Int posTar				
    'String querySeq				
    'Int posQue				
    'Processing:	Extends each match to the left and right of the match and returns the alignment score  
    '---------------------------------------------------------------
    Private Function getLocalAlignmentScore(ByVal tarSeq As String, ByVal posTar As Integer, ByVal queSeq As String, ByVal posQue As Integer)


        Dim score As Integer
        score = p(queSeq.Substring(posQue, 1), tarSeq.Substring(posTar, 1))         'builds orignal score
        score = score + p(queSeq.Substring(posQue + 1, 1), tarSeq.Substring(posTar + 1, 1))
        score = score + p(queSeq.Substring(posQue + 2, 1), tarSeq.Substring(posTar + 2, 1))



        Dim currPosTar As Integer = posTar - 1          'gets ready to go left of the location
        Dim currPosQue As Integer = posQue - 1


        If currPosQue > 0 And currPosTar > 0 Then                       'extends the alignment to the left
            While (((currPosTar > 0) And (currPosQue > 0)) And p(queSeq.Substring(currPosQue, 1), tarSeq.Substring(currPosTar, 1)) >= 0)
                score = score + p(queSeq.Substring(currPosQue, 1), tarSeq.Substring(currPosTar, 1))
                currPosTar -= 1
                currPosQue -= 1
            End While
        End If


        currPosTar = posTar + 3                      ' gets ready to go right of the location
        currPosQue = posQue + 3

        'extends alignment to the right
        If currPosTar < tarSeq.Length() - 1 > 0 And currPosQue < queSeq.Length() - 1 Then
            While (((currPosTar < tarSeq.Length() - 1) And (currPosQue < queSeq.Length() - 1)) And p(queSeq.Substring(currPosQue, 1), tarSeq.Substring(currPosTar, 1)) >= 0)
                score = score + p(queSeq.Substring(currPosQue, 1), tarSeq.Substring(currPosTar, 1))
                currPosTar += 1
                currPosQue += 1
            End While
        End If


        Return score
    End Function
    '---------------------------------------------------------------





    '---------------------------------------------------------------
    'Name:	        Private p			
    'Inputs	        Outputs	                    Calls	Called by	            Files
    'String aminoA1	Int ‘substitution score’	none	buildWords	            none
    'String aminoA2			                            getLocalAlignmentScore	
    'Processing:	Compares amino acids and returns substitution score 
    '---------------------------------------------------------------
    Private Function p(ByVal aminoA1 As String, ByVal aminoA2 As String)
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


        'returns similarity score
        Return (blosum62(x, y))
    End Function
    '---------------------------------------------------------------





    '---------------------------------------------------------------
    'Name:	            Private doMSA			
    'Inputs	            Outputs	    Calls	        Called by	Files
    ''query sequence’	none	    buildWords()	none	    none
    '		                        findMatchs()		
    'Processing:	Takes the input and drives the program 
    '---------------------------------------------------------------
    Private Sub doMSA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles doMSA.Click


        sequenceR.Text = ""                 'clears the form
        retrievedS.Text = ""
        queryS.Text = ""

        Dim sequence As String = inputS.Text
        Dim highScoringWords As New Hash()

        highScoringWords = buildWords(sequence)         'builds the hash with high scoring words

        findMatchs(highScoringWords, sequence)          ' finds and displays matchs


    End Sub
    '---------------------------------------------------------------




    '---------------------------------------------------------------
    'Name:	        Private clearForm			
    'Inputs	        Outputs	    Calls	Called by	Files
    'none	        none	    none	none	    none
    'Processing:	Clears the form 
    '---------------------------------------------------------------
    Private Sub clearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearForm.Click
        inputS.Text = ""            'clears the form
        sequenceR.Text = ""
        retrievedS.Text = ""
        queryS.Text = ""
    End Sub
    '---------------------------------------------------------------
End Class
'----------------------------------------------------------------------------------------------------------------






'----------------------------------------------------------------------------------------------------------------
Public Class Hash


    Private wordsList(23039) As Words           'made sufficiently big to avoid many collisions
    Private tableSize As Integer = 23040




    '---------------------------------------------------------------
    'Name:	        Public New			
    'Inputs	        Outputs	    Calls	Called by	Files
    'none	        none	    none		        none
    'Processing:	Constructor for the class 
    '---------------------------------------------------------------
    Public Sub New()
        For i = 0 To 23039 Step 1
            wordsList(i) = New Words("", -1)    'couldn't figure out how null works in visual basic so created tags
        Next i
    End Sub
    '---------------------------------------------------------------




    '---------------------------------------------------------------
    'Name:	        Public hash(String key)			
    'Inputs	        Outputs	    Calls	                        Called by	    Files
    'String key	    none	    Hash(String key, Int tableSize)	Hash.insert()	none
    '			                                                Hash.find()	
    'Processing:	Base case for recursive call to hash function
    '---------------------------------------------------------------
    Public Function hash(ByVal key As String) As Integer
        Return hash(key, tableSize)
    End Function
    '---------------------------------------------------------------




    '---------------------------------------------------------------
    'Name:	        Private Hash(String key, Int tableSize)			
    'Inputs	        Outputs	Calls	    Called by	    Files
    'String key	    Int hashVal	none	Hash(String key)	none
    'Int tableSize				
    'Processing:	Hash function 
    '---------------------------------------------------------------
    Private Function hash(ByVal key As String, ByVal tableSize As Integer) As Integer
        Dim hashVal As Integer = 0
        Dim charVal As Integer


        For i = 0 To key.Length() - 1 Step 1        'hash function
            charVal = Asc(key.Substring(i, 1))
            hashVal = (37 * hashVal + charVal)
        Next i

        hashVal = hashVal Mod tableSize

        If (hashVal < 0) Then
            hashVal += tableSize
        End If

        Return hashVal
    End Function
    '---------------------------------------------------------------





    '---------------------------------------------------------------
    'Name:	        Public insert			
    'Inputs	        Outputs	    Calls	            Called by	    Files
    'String key	    none	    Words.getWord()	    buildWords	    none
    'Int loc		            Words.insert()		
    'Processing:	Inserts new Words() container or adds to the locations of one 
    '---------------------------------------------------------------
    Public Sub insert(ByVal key As String, ByVal loc As Integer)
        Dim homeLocation As Integer = hash(key)
        Dim location As Integer

        If (wordsList(homeLocation).getWord = "") Then        'creates to home location if empty
            wordsList(homeLocation) = New Words(key, loc)
        ElseIf key.Equals(wordsList(homeLocation).getWord) Then  'adds to home location if right word 
            wordsList(homeLocation).insert(loc)
        Else                                    'else looks for proper location
            Dim counter = 1
            location = homeLocation + counter
            While (Not wordsList(location).getWord = "") Or key.Equals(wordsList(homeLocation).getWord())
                counter = counter + 1
                location = homeLocation + (counter * counter) Mod tableSize     'quadratic probe
                If location < 0 Then
                    location = -location
                End If
            End While
            If (wordsList(location).getWord = "") Then         'adds to empty spot, if empty
                wordsList(location) = New Words(key, loc)
            Else                                            'else adds onto existing spot
                wordsList(location).insert(loc)
            End If
        End If

    End Sub
    '---------------------------------------------------------------




    '---------------------------------------------------------------
    'Name:	        Public find			
    'Inputs	        Outputs	        Calls	            Called by	        Files
    'String key	    Int location	Hash.hash(key)	    Words.getWord()	    none
    '			                                        findMatchs()	
    '			                                        Hash.retrieveWord()	
    'Processing:	Finds the hashVal for a word 
    '---------------------------------------------------------------
    Public Function find(ByVal key As String) As Integer
        Dim homeLocation As Integer = hash(key)
        Dim location As Integer = homelocation

        If (wordsList(homeLocation).getWord = "") Then          'returns -1 if location is null
            Return (-1)
        End If

        If key.Equals(wordsList(homeLocation).getWord()) Then       'checks homelocation
            Return (homeLocation)
        Else
            Dim counter = 1
            location = homeLocation + counter
            While Not key.Equals(wordsList(location).getWord())
                If (wordsList(location).getWord = "") Then
                    Return (-1)
                End If
                counter = counter + 1
                location = homeLocation + (counter * counter) Mod tableSize     'checks positions by quadratic probe
                If location < 0 Then
                    location = -location
                End If
            End While
            Return (location)
        End If
    End Function
    '---------------------------------------------------------------




    '---------------------------------------------------------------
    'Name:	        Public length			
    'Inputs	        Outputs	        Calls	Called by	Files
    'none	        Int tableSize	none	none	    none
    'Processing:	Accessor for tableSize 
    '---------------------------------------------------------------
    Public Function length()
        Return tableSize
    End Function
    '---------------------------------------------------------------




    '---------------------------------------------------------------
    'Name:	        Public retrieveWord()			
    'Inputs	        Outputs	            Calls	        Called by	    Files
    'String word	Words() container	Hash.find()	    findMatchs()	none
    'Processing:	Retrieves the appropriate container for input word
    '---------------------------------------------------------------
    Public Function retrieveWord(ByVal word As String) As Words
        Return (wordsList(find(word)))      'returns the words container
    End Function
    '---------------------------------------------------------------

End Class
'----------------------------------------------------------------------------------------------------------------






'----------------------------------------------------------------------------------------------------------------
Public Class Words

    Public word As String = ""
    Public locations(98) As Integer


    '---------------------------------------------------------------
    'Name:	        Public New()			
    'Inputs	        Outputs	    Calls	Called by	Files
    'String Value	none	    none	none
    'Int locat				
    'Processing:	Cosntructor for words container 
    '---------------------------------------------------------------
    Public Sub New(ByVal Value As String, ByVal locat As Integer)
        word = Value
        locations(0) = locat
        locations(1) = -1           '-1 set to signal end of array
    End Sub
    '---------------------------------------------------------------



    '---------------------------------------------------------------
    'Name:	        Public getWord			
    'Inputs	        Outputs	        Calls	Called by	    Files
    'none	        String word	    none	Hash.insert()	none
    '		                                Hash.find()	
    'Processing:	Accessor for the word String 
    '---------------------------------------------------------------
    Public Function getWord() As String
        Return (word)
    End Function
    '---------------------------------------------------------------



    '---------------------------------------------------------------
    'Name:	        Public getLocations			
    'Inputs	        Outputs	            Calls	Called by	    Files
    'none	        Int[] Locations	    none	findMatchs()	none
    'Processing:	Accessor for the integer array locations 
    '---------------------------------------------------------------
    Public Function getLocations() As Integer()
        Return (locations)
    End Function
    '---------------------------------------------------------------


    '---------------------------------------------------------------
    'Name:	        Public insert			
    'Inputs	        Outputs	    Calls	Called by	    Files
    'Int loc	    word	    none	Hash.insert()	none
    'Processing:	Inserts a new location into the locations array 
    '---------------------------------------------------------------
    Public Sub insert(ByVal loc As Integer)
        Dim i As Integer = 1            'adds to the locations

        While (locations(i) <> -1)      'looks for open position
            i = i + 1
        End While

        locations(i + 1) = loc          'replaces end tag
        locations(i + 2) = -1           'creates new end tag

    End Sub
    '---------------------------------------------------------------

End Class
'----------------------------------------------------------------------------------------------------------------

