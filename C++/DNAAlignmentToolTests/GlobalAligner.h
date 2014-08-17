/********************************************************
  Adrian Flannery

  GlobalAligner.h

  Header for GlobalAligner class which is a subclass of
  SequenceAligner. The GlobalAligner implements global
  alignment of DNA Sequences
********************************************************/


#ifndef GLOBALALIGNER_H
#define GLOBALALIGNER_H


#include <string>
#include "SequenceAligner.h"




    class GlobalAligner : public SequenceAligner
    {
    public:
        GlobalAligner(std::string inSeq1, std::string inSeq2, int inNMScore, int inNMMScore, int inNGapScore, int inEMScore, int inEMMScore, int inEGapScore);
        void alignGlobalSequence();

        void buildTables();
        void buildSequences();
    };

#endif // GLOBALALIGNER_H
