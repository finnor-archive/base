using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DNAAlignmentXY
{
    public class GlobalAligner : SequenceAligner
    {

        public GlobalAligner(String inSeq1, String inSeq2, int inNMScore, int inNMmScore, int inNGapScore, int inEMScore, int inEMmScore, int inEGapScore)
        {
            seq1 = inSeq1;
            seq2 = inSeq2;

            //test legality of sequence
            for (int i = 0; i < seq1.Length; i++)
            {
                if (!(isNatural(seq1[i]) || isExotic(seq1[i])))
                    throw (new Exception("Illegal input in sequence 1"));
            }
            for (int i = 0; i < seq2.Length; i++)
            {
                if (!(isNatural(seq2[i]) || isExotic(seq2[i])))
                    throw (new Exception("Illegal input in sequence 2"));
            }

            nMScore = inNMScore;
            nMMScore = inNMmScore;
            nGapScore = inNGapScore;
            eMScore = inEMScore;
            eMMScore = inEMmScore;
            eGapScore = inEGapScore;
        }

        public override String[] alignSequences()
        {
            alignmentTable = new int[seq1.Length + 1, seq2.Length + 1];
            pathTaken = new int[seq1.Length, seq2.Length];
            
            //build and fill the tables to be used for dynamic programming
            buildTables();

            //build and return the aligned sequences from the tables
            return buildSequences();

        }

        //The global alignment algorithm uses dynamic programming, this routine builds and fills the tables necessary
        protected override void buildTables()
        {
            int nonGapScore;
            int bestPath;
            int seq1Gap;
            int seq2Gap;

            //fills the all gap row and column
            for (int i = 1; i < seq1.Length + 1; i++)
            {
                if (isNatural(seq1[i - 1]))
                    alignmentTable[i, 0] = alignmentTable[i - 1, 0] + nGapScore;
                else if (isExotic(seq1[i - 1]))
                    alignmentTable[i, 0] = alignmentTable[i - 1, 0] + eGapScore;
            }
            for (int j = 1; j < seq2.Length + 1; j++)
            {
                if (isNatural(seq2[j - 1]))
                    alignmentTable[0, j] = alignmentTable[0, j - 1] + nGapScore;
                else if (isExotic(seq2[j - 1]))
                    alignmentTable[0, j] = alignmentTable[0, j - 1] + eGapScore;
            }


            //loops across the table of size seq1.length+1 x seq2.length+1
            for (int i = 1; i <= seq1.Length; i++)
            {
                for (int j = 1; j <= seq2.Length; j++)
                {
                    //if either current base is exotic, then exotic scores used for match and indel scoring
                    if (isExotic(seq1[i - 1]) || isExotic(seq2[j - 1]))
                        nonGapScore = alignmentTable[i - 1, j - 1] + compareNucleotides(seq1[i - 1], seq2[j - 1], eMScore, eMMScore);
                    else
                        nonGapScore = alignmentTable[i - 1, j - 1] + compareNucleotides(seq1[i - 1], seq2[j - 1], nMScore, nMMScore);


                    //determines the score if a gap in either sequence is used

                    //for sequence 1 gap, if the base is exotic, then exotic scores used
                    if (isExotic(seq2[j - 1]))
                        seq1Gap = alignmentTable[i, j - 1] + eGapScore;
                    //else if the base is natural, then exotic scores used
                    else if (isNatural(seq2[j - 1]))
                        seq1Gap = alignmentTable[i, j - 1] + nGapScore;
                    //else exception
                    else
                        throw new Exception("GlobalAligner.buildTables(), Unhandled case - gap 1 score if/else");


                    //for sequence 2 gap, if the base is exotic, then exotic scores used
                    if (isExotic(seq1[i - 1]))
                        seq2Gap = alignmentTable[i - 1, j] + eGapScore;
                    //else if the base is natural, then exotic scores used
                    else if (isNatural(seq1[i - 1]))
                        seq2Gap = alignmentTable[i - 1, j] + nGapScore;
                    //else exception
                    else
                        throw new Exception("GlobalAligner.buildTables(), Unhandled case - gap 2 score if/else");




                    bestPath = findBestPath(seq1Gap, seq2Gap, nonGapScore);
                    pathTaken[i - 1, j - 1] = bestPath;



                    //record the path
                    //1 denotes that a match or indel score was used
                    if (bestPath == 1)
                        alignmentTable[i, j] = nonGapScore;
                    //2 denotes that a gap in sequence 1 was used
                    else if (bestPath == 2)
                        alignmentTable[i, j] = seq1Gap;
                    //3 denotes that a gap in sequence 2 was used
                    else if (bestPath == 3)
                        alignmentTable[i, j] = seq2Gap;
                    //else exception
                    else
                        throw new Exception("GlobalAligner.buildTables, Unhandled Case - bestPath if/else");

                }
            }

            similiarityScore = alignmentTable[seq1.Length, seq2.Length];

        }


        //builds the aligned sequences
        protected override String[] buildSequences()
        {
            int i = seq1.Length-1;
            int j = seq2.Length-1;
            String outputSeq1 = "";
            String outputSeq2 = "";

            //while either sequence isn't aligned
            while ((i>=0) && (j>=0))
            {
                if (pathTaken[i,j] == 1)                            //diagonal path - no gap
                {
                    outputSeq1 = seq1[i] + outputSeq1;
                    outputSeq2 = seq2[j] + outputSeq2;
                    i--;
                    j--;
                }
                else if (pathTaken[i,j] == 2)                       //gap in sequence 1
                {
                    outputSeq1 = "-" + outputSeq1;
                    outputSeq2 = seq2[j] + outputSeq2;
                    j--;
                }
                else                                                //gap in sequence 2
                {
                    outputSeq1 = seq1[i] + outputSeq1;
                    outputSeq2 = "-" + outputSeq2;
                    i--;
                }
            }

            for (; i >= 0;i--)
            {
                outputSeq1 = seq1[i] + outputSeq1;
                outputSeq2 = "-" + outputSeq2;
            }
            for (; j >= 0;j--)
            {
                outputSeq1 = "-" + outputSeq1;
                outputSeq2 = seq2[j] + outputSeq2;
            }
            
            String[] outputSeqs = new String[2];
            outputSeqs[0] = outputSeq1;
            outputSeqs[1] = outputSeq2;

            //return the sequences
            return outputSeqs;
        }
    }
}
