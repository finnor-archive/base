/********************************************************
  Adrian Flannery

  LocalAligner.cpp

  Source for LocalAligner class which is a subclass of
  SequenceAligner. The LocalAligner implements local
  alignment of DNA Sequences
********************************************************/

#include "LocalAligner.h"

using namespace std;

/***************************************************************************************************************
  Name:	LocalAligner

  Inputs	            Outputs                         Calls                               Called by
  string inSeq1                                                                             DNAAlignmentWindow
  string inSeq2
  int inNMScore
  int inNMMScore
  int inNGapScore
  int inEMScore
  int inEMMScore
  int inEGapScore

  Processing:	Constructs object for local alignment
***************************************************************************************************************/
LocalAligner::LocalAligner(string inSeq1, string inSeq2, int inNMScore, int inNMMScore, int inNGapScore, int inEMScore, int inEMMScore, int inEGapScore)
{
    //input sequences to be aligned
    seq1 = inSeq1;
    seq2 = inSeq2;


    //scoring matrix for alignment
    //natural match score
    nMScore = inNMScore;
    //natural mismatch/indel score
    nMMScore = inNMMScore;
    //natural gap score
    nGapScore = inNGapScore;
    //exotic match score
    eMScore = inEMScore;
    //exotic mismatch/indel score
    eMMScore = inEMMScore;
    //exotic gap score
    eGapScore = inEGapScore;

    similarityScore = 0;

    //records the score and position in which the maximal subalignment ends
    maxScore = 0;
    maxScoreX = 1;
    maxScoreY = 1;
}


/***************************************************************************************************************
Name:	alignLocalSequence

Inputs	            Outputs                         Calls                               Called by
                                                    this.buildTables()                  DNAAlignmentWindow
                                                    this.buildSequences()

Processing:	Drives the alignment
***************************************************************************************************************/
void LocalAligner::alignLocalSequence()
{
    //process the sequences
    buildTables();

    //build the aligned sequences
    buildSequences();
}



/************************************************************************************************************************
  Name:	buildTables

  Inputs	            Outputs                         Calls                               Called by
                                                        SequenceAligner.isNatural           this.alignGlobalSequence
                                                        SequenceAligner.isExotic
                                                        SequenceAligner.compareNucleotides
                                                        SequenceAligner.findBestPath

  Processing:	Builds the alignment tables
*************************************************************************************************************************/
void LocalAligner::buildTables()
{
    int nonGapScore;
    int bestPath;
    int seq1Gap;
    int seq2Gap;


    //intialize tables
    alignmentTable.resize(seq1.length()+1);
    for (int i=0; i<seq1.length()+1; i++)
    {
        alignmentTable[i].resize(seq2.length()+1);
    }

    pathTaken.resize(seq1.length());
    for (int i=0; i<seq1.length(); i++)
    {
        pathTaken[i].resize(seq2.length());
    }


    //in local alignment score can not go below 0
    //so the all gaps row and column are set to 0
    for (int i = 1; i<seq1.length(); i++)
        alignmentTable[i][0] = 0;
    for (int j = 1; j<seq2.length(); j++)
        alignmentTable[0][j] = 0;




    //main processing, compares each base to each other and builds a running score
    //and keeps track of which score was used to record the path.
    for (int i = 1; i <= seq1.length(); i++)
    {
        for (int j = 1; j <= seq2.length(); j++)
        {
            //if either current base is exotic, then exotic scores used for match and indel scoring
            if (isExotic(seq1[i - 1]) || isExotic(seq2[j - 1]))
                nonGapScore = alignmentTable[i - 1][j - 1] + compareNucleotides(seq1[i - 1], seq2[j - 1], eMScore, eMMScore);
            else
                nonGapScore = alignmentTable[i - 1][j - 1] + compareNucleotides(seq1[i - 1], seq2[j - 1], nMScore, nMMScore);

            //if score would drop below 0 due to an indel, score is recorded as 0
            if (nonGapScore < 0)
                nonGapScore = 0;


            //determines the score if a gap in either sequence is used

            //for sequence 1 gap, if the base is exotic, then exotic scores used
            if (isExotic(seq2[j - 1]))
                seq1Gap = alignmentTable[i][j-1] + eGapScore;
            //else if the base is natural, then exotic scores used
            else if (isNatural(seq2[j - 1]))
                seq1Gap = alignmentTable[i][j-1] + nGapScore;
            //else exception
            else
                throw "GlobalAligner.buildTables(), Unhandled case 3";


            //for sequence 2 gap, if the base is exotic, then exotic scores used
            if (isExotic(seq1[i - 1]))
                seq2Gap = alignmentTable[i - 1][j] + eGapScore;
            //else if the base is natural, then exotic scores used
            else if (isNatural(seq1[i - 1]))
                seq2Gap = alignmentTable[i - 1][j] + nGapScore;
            //else exception
            else
                throw "GlobalAligner.buildTables(), Unhandled case 2";

            //if score would drop below 0 due to a gap, score is recorded as 0
            if (seq1Gap < 0)
                seq1Gap = 0;
            if (seq2Gap < 0)
                seq2Gap = 0;


            bestPath = findBestPath(seq1Gap, seq2Gap, nonGapScore);
            pathTaken[i - 1][j - 1] = bestPath;



            //record the path
            //1 denotes that a match or indel score was used
            if (bestPath == 1)
                alignmentTable[i][j] = nonGapScore;
            //2 denotes that a gap in sequence 1 was used
            else if (bestPath == 2)
                alignmentTable[i][j] = seq1Gap;
            //3 denotes that a gap in sequence 2 was used
            else if (bestPath == 3)
                alignmentTable[i][j] = seq2Gap;
            //else exception
            else
                throw "GlobalAligner.buildTables, Unhandled Case 4";


            //check if it is best score and record it
            if (alignmentTable[i][j] > maxScore)
            {
                maxScore = alignmentTable[i][j];
                maxScoreX = i;
                maxScoreY = j;
            }
        }
    }
    similarityScore = maxScore;
}



/************************************************************************************************************************
  Name:	buildSequences

  Inputs	            Outputs                         Calls                               Called by
                                                                                            this.alignGlobalSequence




  Processing:	Builds the aligned sequences
*************************************************************************************************************************/
void LocalAligner::buildSequences()
{
    string outputSeq1 = "";
    string outputSeq2 = "";
    int currentX, currentY;


    currentX = maxScoreX;
    currentY = maxScoreY;


    //loops from the max score cell to a cell that contains a 0
    while (alignmentTable[currentX][currentY] > 0)
    {
        //checks for diagonal path
        if (pathTaken[currentX-1][currentY-1] == 1)
        {
            outputSeq1 = seq1[currentX-1] + outputSeq1;
            outputSeq2 = seq2[currentY-1] + outputSeq2;
            currentX--;
            currentY--;
        }
        //else if gap in sequence 1
        else if (pathTaken[currentX-1][currentY-1] == 2)
        {
            outputSeq1 = "-" + outputSeq1;
            outputSeq2 = seq2[currentY-1] + outputSeq2;
            currentY--;
        }
        //else if gap in sequence 2
        else if (pathTaken[currentX-1][currentY-1] == 3)
        {
            outputSeq1 = seq1[currentX-1] + outputSeq1;
            outputSeq2 = "-" + outputSeq2;
            currentX--;
        }
        //else exception
        else
            throw "LocalAligner.buildSequences, Unhandled Case";

    }

    outSeq1 = outputSeq1;
    outSeq2 = outputSeq2;
}
