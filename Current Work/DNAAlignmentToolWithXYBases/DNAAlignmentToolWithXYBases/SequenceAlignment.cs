using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNAAlignmentToolWithXYBases
{
    class SequenceAlignment
    {
        private int similiarityScore;
        private String seq1, seq2;
        private int nMScore, nMmScore, nGapScore, eMScore, eMmScore, eGapScore;
        private int[,] alignmentTable, pathTaken;

        public SequenceAlignment(String inSeq1, String inSeq2, int inNMScore, int inNMmScore, int inNGapScore, int inEMScore, int inEMmScore, int inEGapScore)
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
            nMmScore = inNMmScore;
            nGapScore = inNGapScore;
            eMScore = inEMScore;
            eMmScore = inEMmScore;
            eGapScore = inEGapScore;
        }

        public String[] alignSequences()
        {
            alignmentTable = new int[seq1.Length + 1, seq2.Length + 1];
            pathTaken = new int[seq1.Length, seq2.Length];
            
            //build and fill the tables to be used for dynamic programming
            buildTables();

            //build and return the aligned sequences from the tables
            return buildSequences();

        }

        //accessor for score
        public int getScore()
        {
            return similiarityScore;
        }

        //The global alignment algorithm is uses dynamic programming, this routine builds and fills the tables necessary
        private void buildTables()
        {
            int nonGapScore;
            int bestPath;
            int seq1Gap;
            int seq2Gap;

            //fills the all gap row and column
            for (int i = 1; i<seq1.Length; i++)
            {
                if (isNatural(seq1[i-1]))
                    alignmentTable[i, 0] = alignmentTable[i - 1, 0] - 2;
                else if (isExotic(seq1[i-1]))
                    alignmentTable[i, 0] = alignmentTable[i - 1, 0] - 3;
            }
            for (int j = 1; j<seq2.Length; j++)
            {
                if (isNatural(seq2[j-1]))
                    alignmentTable[0, j] = alignmentTable[0, j-1] - 2;
                else if (isExotic(seq2[j-1]))
                    alignmentTable[0, j] = alignmentTable[0, j-1] - 3;
            }


            //loops across the table of size seq1.length+1 x seq2.length+1
            for (int i = 1; i <= seq1.Length; i++)
            {
                for (int j = 1; j <= seq2.Length; j++)
                {
                    if (isExotic(seq1[i - 1]) || isExotic(seq2[j - 1]))         //if either current base is exotic, then exotic scores used
                    {


                        //determines the score if a gap isn't used
                        nonGapScore = alignmentTable[i - 1, j - 1] + compareNucleotides(seq1[i - 1], seq2[j - 1], eMScore, eMmScore);

                        //determines the score if a gap in either sequence is used
                        seq1Gap = alignmentTable[i, j - 1] + eGapScore;
                        seq2Gap = alignmentTable[i - 1, j] + eGapScore;

                        //determine the highest scoring path from the scores
                        bestPath = findBestPath(seq1Gap, seq2Gap, nonGapScore);
                        pathTaken[i - 1, j - 1] = bestPath;
                    }
                    else                                                        //else both bases are natural, then exotic scores used
                    {
                        //determines the score if a gap isn't used
                        nonGapScore = alignmentTable[i - 1, j - 1] + compareNucleotides(seq1[i - 1], seq2[j - 1], nMScore, nMmScore);

                        //determines the score if a gap in either sequence is used
                        seq1Gap = alignmentTable[i, j - 1] + nGapScore;
                        seq2Gap = alignmentTable[i - 1, j] + nGapScore;

                        //determine the highest scoring path from the scores
                        bestPath = findBestPath(seq1Gap, seq2Gap, nonGapScore);
                        pathTaken[i - 1, j - 1] = bestPath;
                    }

                    //record the score
                    if (bestPath == 1)
                        alignmentTable[i,j] = nonGapScore;
                    else if (bestPath == 2)
                        alignmentTable[i,j] = seq1Gap;
                    else 
                        alignmentTable[i,j] = seq2Gap;
                }
            }

            similiarityScore = alignmentTable[seq1.Length, seq2.Length];

        }

        //determines whether the base is one of the natural ones: A ,T ,C , G 
        private bool isNatural(char base0)
        {
            if (base0=='a' || base0=='A')
                return true;
            else if (base0=='t' || base0=='T')
                return true;
            else if (base0=='c' || base0=='C')
                return true;
            else if (base0=='g' || base0=='G')
                return true;
            else 
                return false;
        }


        //determines whether the base is one of the natural ones: A ,T ,C , G 
        private static bool isExotic(char base0)
        {
            if (base0 == 'x' || base0 == 'X')
                return true;
            else if (base0 == 'Y' || base0 == 'Y')
                return true;
            else
                return false;
        }

        //compares the current nucleotide and returns the appropriate score
        private int compareNucleotides(char base1, char base2, int mScore, int mmScore)
        {
            if (base1.CompareTo(base2) == 0)
                return mScore;
            else
                return mmScore;
        }

        //determines the highest score out of 3 possibilities
        private int findBestPath(int seq1Gap, int seq2Gap, int noGap)
        {
            if ((noGap >= seq1Gap) && (noGap >= seq2Gap))       //no gap
                return 1;
            else if (seq1Gap >= seq2Gap)                        //gap in sequence 1
                return 2;
            else                                                //gap in sequence 2
                return 3;
        }

        //builds the aligned sequences
        private String[] buildSequences()
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
