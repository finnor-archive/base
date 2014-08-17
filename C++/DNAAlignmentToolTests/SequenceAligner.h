/********************************************************
  Adrian Flannery

  SequenceAligner.h

  Header for the abstract class SequenceAligner which is
  inherited by LocalAligner and GlobalAligner.
********************************************************/

#ifndef SEQUENCEALIGNER_H
#define SEQUENCEALIGNER_H

#include <string>
#include <vector>

class SequenceAligner
{
public:
    std::string getSeq1();
    std::string getSeq2();
    int getScore();

    int similarityScore;
    std::string seq1;
    std::string seq2;
    std::string outSeq1;
    std::string outSeq2;
    //dynamic programming table to record alignment scores
    std::vector<std::vector<int> > alignmentTable;
    //helper table to record which direction a score came from
    std::vector<std::vector<int> > pathTaken;

    //scoring for natural and exotic bases
    int nMScore, nMMScore, nGapScore;
    int eMScore, eMMScore, eGapScore;


    bool isNatural(char base0);
    bool isExotic(char base0);
    int compareNucleotides(char base1, char base2, int mScore, int mmScore);
    int findBestPath(int seq1Gap, int seq2Gap, int noGap);

    //abstract methods implemented by subclasses
    virtual void buildTables() = 0;
    virtual void buildSequences() =0;

};

#endif // SEQUENCEALIGNER_H
