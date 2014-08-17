/********************************************************
  Adrian Flannery

  SequenceAligner.h

  Source for the abstract class SequenceAligner which is
  inherited by LocalAligner and GlobalAligner.
********************************************************/

#include "SequenceAligner.h"
#include <string>

using namespace std;


/***************************************************************************************************************
  Name:	getScore
  Inputs	            Outputs                         Calls                               Called by
                        int similarityScore                                                 DNAAlignmentWindow

  Processing:	Accessor for similarity score
***************************************************************************************************************/
int SequenceAligner::getScore()
{
    return similarityScore;
}

/***************************************************************************************************************
  Name:	getSeq1
  Inputs	            Outputs                         Calls                               Called by
                        string outSeq1                                                      DNAAlignmentWindow

  Processing:	Accessor for the aligned sequence 1
***************************************************************************************************************/
string SequenceAligner::getSeq1()
{
    return outSeq1;
}


/***************************************************************************************************************
  Name:	getSeq2
  Inputs	            Outputs                         Calls                               Called by
                        string outSeq2                                                      DNAAlignmentWindow

  Processing:	Accessor for the aligned sequence 2
***************************************************************************************************************/
string SequenceAligner::getSeq2()
{
    return outSeq2;
}


/***********************************************************************************************************************
  Name:	isNatural
  Inputs	            Outputs                         Calls                               Called by
  char base0            bool                                                                LocalAligner.buildTables()
                                                                                            GlobalAligner.buildTables()

  Processing:	Determines if the input character is a natural base
************************************************************************************************************************/
bool SequenceAligner::isNatural(char base0)
{
    base0 = tolower(base0);
    switch (base0)
    {
    case ('a') :             //Adenine
        return true;
    case ('t') :             //Thymine
        return true;
    case ('c') :             //Cytosine
        return true;
    case ('g') :             //Guanine
        return true;
    case ('u') :             //Uracil
        return true;
    case ('r') :             //Purine (A or G)
        return true;
    case ('y') :             //Pyrimidine (C, T, or U)
        return true;
    case ('k') :             //Ketones (G, T, or U)
        return true;
    case ('m') :             //aMino groups (A or C)
        return true;
    case ('s') :             //Strong interaction (C or G)
        return true;
    case ('w') :             //Weak interaction (A or T)
        return true;
    case ('b') :             //B comes after A (C, G, T, or U)
        return true;
    case ('d') :             //D comes after C (A, G, T, or U)
        return true;
    case ('h') :             //H comes after G (A, C, T, or U)
        return true;
    case ('v') :             //V comes after U  (A, C, or G)
        return true;
    case ('n') :             //Nucleic acid  (A, C, G, T, or U)
        return true;
    default:
        return false;
    }
}


/***********************************************************************************************************************
  Name:	isExotic
  Inputs	            Outputs                         Calls                               Called by
  char base0            bool                                                                LocalAligner.buildTables()
                                                                                            GlobalAligner.buildTables()

  Processing:	Determines if the input character is an exotic base
************************************************************************************************************************/
bool SequenceAligner::isExotic(char base0)
{
    if (base0 == 'x' || base0 == 'X')
        return true;
    else if (base0 == 'Y' || base0 == 'Y')
        return true;
    else
        return false;
}

/***********************************************************************************************************************
  Name:	compareNucleotides
  Inputs	            Outputs                         Calls                               Called by
  char base1            int                                                                 LocalAligner.buildTables()
  char base2                                                                                GlobalAligner.buildTables()
  int inMScore
  int inMMScore

  Processing:	Compares the bases and returns the correct score
************************************************************************************************************************/
int SequenceAligner::compareNucleotides(char base1, char base2, int inMScore, int inMMScore)
{
    if (base1==base2)
        return inMScore;
    else
        return inMMScore;
}


/***********************************************************************************************************************
  Name:	findBestPath
  Inputs	            Outputs                         Calls                               Called by
  int seq1Gap            int                                                                LocalAligner.buildTables()
  int seq2Gap                                                                               GlobalAligner.buildTables()
  int noGap

  Processing:	Compares each score and returns a value denoting the highes one
************************************************************************************************************************/
int SequenceAligner::findBestPath(int seq1Gap, int seq2Gap, int noGap)
{
    //no gap
    if ((noGap >= seq1Gap) && (noGap >= seq2Gap))
        return 1;
    //else if gap in sequence 1
    else if (seq1Gap >= seq2Gap)
        return 2;
    //else if gap in sequence 2
    else if (seq1Gap < seq2Gap)
        return 3;
    //else exception
    else
        throw "findBestPath, Unhandled Case";
}
