/********************************************************
  Adrian Flannery

  GlobalAligner.cpp

  Source for GlobalAligner class which is a subclass of
  SequenceAligner. The GlobalAligner implements global
  alignment of DNA Sequences
********************************************************/

#include "GlobalAligner.h"

using namespace std;

/***************************************************************************************************************
  Name:	GlobalAligner

  Inputs	            Outputs                         Calls                               Called by
  string inSeq1                                                                             DNAAlignmentWindow
  string inSeq2
  int inNMScore
  int inNMMScore
  int inNGapScore
  int inEMScore
  int inEMMScore
  int inEGapScore

  Processing:	Constructs object for global alignment
***************************************************************************************************************/
GlobalAligner::GlobalAligner(string inSeq1, string inSeq2, int inNMScore, int inNMMScore, int inNGapScore, int inEMScore, int inEMMScore, int inEGapScore)
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
}


/***************************************************************************************************************
  Name:	alignGlobalSequence

  Inputs	            Outputs                         Calls                               Called by
                                                        this.buildTables()                  DNAAlignmentWindow
                                                        this.buildSequences()

  Processing:	Drives the alignment
***************************************************************************************************************/
void GlobalAligner::alignGlobalSequence()
{
    //process the sequences
    buildTables();

    //build the aligned sequenecs
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
void GlobalAligner::buildTables()
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


    //sets up base conditions of having all gaps in sequence 2
    for (int i = 1; i<seq1.length()+1; i++)
    {
        //if it is a natural base the natural gap score is used
        if(isNatural(seq1[i-1]))
            alignmentTable[i][0] = alignmentTable[i-1][0] + nGapScore;
        //else if it an exotic base the exotic gap score is used
        else if(isExotic(seq1[i-1]))
            alignmentTable[i][0] = alignmentTable[i-1][0] + eGapScore;
        //else exception
        else
            throw "GlobalAligner.buildTables, Unhandled Case 0";
    }

    //same as above, but condition is all gaps in sequence 1
    for (int j = 1; j<seq2.length()+1; j++)
    {
        if(isNatural(seq2[j-1]))
            alignmentTable[0][j] = alignmentTable[0][j-1] + nGapScore;
        else if(isExotic(seq2[j-1]))
            alignmentTable[0][j] = alignmentTable[0][j-1] + eGapScore;
        else
            throw "GlobalAligner.buildTables(), Unhandled case 1";
    }




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

        }
    }
    //the similarity score is the final value in global alignment
    similarityScore = alignmentTable[seq1.length()][seq2.length()];
}


/************************************************************************************************************************
  Name:	buildSequences

  Inputs	            Outputs                         Calls                               Called by
                                                                                            this.alignGlobalSequence




  Processing:	Builds the aligned sequences
*************************************************************************************************************************/
void GlobalAligner::buildSequences()
{
    string outputSeq1 = "";
    string outputSeq2 = "";
    int currentX = seq1.length()-1;
    int currentY = seq2.length()-1;


    //loops from the one corner until one of the sequences is completely aligned
    while (currentX>=0 && currentY>=0)
    {
        //checks for diagonal path
        if (pathTaken[currentX][currentY] == 1)
        {
            outputSeq1 = seq1[currentX] + outputSeq1;
            outputSeq2 = seq2[currentY] + outputSeq2;
            currentX--;
            currentY--;
        }
        //else if gap in sequence 1
        else if (pathTaken[currentX][currentY] == 2)
        {
            outputSeq1 = "-" + outputSeq1;
            outputSeq2 = seq2[currentY] + outputSeq2;
            currentY--;
        }
        // else if gap in sequence 2
        else if (pathTaken[currentX][currentY] == 3)
        {
            outputSeq1 = seq1[currentX] + outputSeq1;
            outputSeq2 = "-" + outputSeq2;
            currentX--;
        }
        // else exception
        else
            throw "GlobalAligner.buildSequences, Unhandled Case";
    }

    //if alignment contains gaps at the start of sequence 2, the rest of sequence 1 must be added
    for (; currentX >= 0;currentX--)
    {
        outputSeq1 = seq1[currentX] + outputSeq1;
        outputSeq2 = "-" + outputSeq2;
    }
    //if alignment contains gaps at the start of sequence 1, the rest of sequence 2 must be added
    for (; currentY >= 0;currentY--)
    {
        outputSeq1 = "-" + outputSeq1;
        outputSeq2 = seq2[currentY] + outputSeq2;
    }

    outSeq1 = outputSeq1;
    outSeq2 = outputSeq2;
}
