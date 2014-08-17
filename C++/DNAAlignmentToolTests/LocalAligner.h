/********************************************************
  Adrian Flannery

  LocalAligner.h

  Header for LocalAligner class which is a subclass of
  SequenceAligner. The LocalAligner implements local
  alignment of DNA Sequences
********************************************************/

#ifndef LOCALALIGNER_H
#define LOCALALIGNER_H


#include <string>
#include "SequenceAligner.h"




    class LocalAligner : public SequenceAligner
    {
    public:
        LocalAligner(std::string inSeq1, std::string inSeq2, int inNMScore, int inNMMScore, int inNGapScore, int inEMScore, int inEMMScore, int inEGapScore);
        void alignLocalSequence();

        //Local Alignment requires that the maximum score and its position recorded
        int maxScore;
        int maxScoreX;
        int maxScoreY;


        void buildTables();
        void buildSequences();
    };





#endif // LOCALALIGNER_H
