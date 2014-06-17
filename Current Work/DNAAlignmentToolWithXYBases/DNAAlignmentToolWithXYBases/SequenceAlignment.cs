using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNAAlignmentToolWithXYBases
{

    static class SequenceAlignment
    {
        public static String[] alignSequences(String seq1, String seq2, int mScore, int mmScore, int gapScore)
        {
            int[,] alignmentTable = new int[seq1.Length + 1, seq2.Length + 1];
            int[,] pathTaken = new int[seq1.Length, seq2.Length];
            
            //build and fill the tables to be used for dynamic programming
            buildTables(seq1, seq2, mScore, mmScore, gapScore, alignmentTable, pathTaken);

            //build and return the aligned sequences from the tables
            return buildSequences(seq1, seq2, pathTaken);

        }


        //The global alignment algorithm is uses dynamic programming, this routine builds and fills the tables necessary
        private static void buildTables(String seq1, String seq2, int mScore, int mmScore, int gapScore, int[,] alignmentTable, int[,] pathTaken)
        {
            int nonGapScore;
            int bestPath;
            int seq1Gap;
            int seq2Gap;

            //fills the all gap row and column
            for(int i=0; i<seq1.Length-1; i++)
                alignmentTable[i,0] = i*-2;
            for(int j=0; j<seq2.Length-1; j++)
                alignmentTable[0,j] = j*-2;


            //loops across the table of size seq1.length+1 x seq2.length+1
            for (int i = 1; i <= seq1.Length; i++)
            {
                for (int j = 1; j <= seq2.Length; j++)
                {
                    //determines the score if a gap isn't used
                    nonGapScore = alignmentTable[i-1,j-1] + compareNucleotides(seq1[i - 1], seq2[j - 1], mScore, mmScore);
                    
                    //determines the score if a gap in either sequence is used
                    seq1Gap = alignmentTable[i, j-1] + gapScore;
                    seq2Gap = alignmentTable[i-1,j] + gapScore;

                    //determine the highest scoring path from the scores
                    bestPath = findBestPath(seq1Gap, seq2Gap, nonGapScore);
                    pathTaken[i-1,j-1] = bestPath;

                    //record the score
                    if (bestPath == 1)
                        alignmentTable[i,j] = nonGapScore;
                    else if (bestPath == 2)
                        alignmentTable[i,j] = seq1Gap;
                    else 
                        alignmentTable[i,j] = seq2Gap;
                }
            }
        }

        //compares the current nucleotide and returns the appropriate score
        private static int compareNucleotides(char base1, char base2, int mScore, int mmScore)
        {
            if (base1.CompareTo(base2) == 0)
                return mScore;
            else
                return mmScore;
        }

        //determines the highest score out of 3 possibilities
        private static int findBestPath(int seq1Gap, int seq2Gap, int noGap)
        {
            if ((noGap >= seq1Gap) && (noGap >= seq2Gap))       //no gap
                return 1;
            else if (seq1Gap >= seq2Gap)                        //gap in sequence 1
                return 2;
            else                                                //gap in sequence 2
                return 3;
        }

        //builds the aligned sequences
        private static String[] buildSequences(String seq1, String seq2, int[,] pathTaken)
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
