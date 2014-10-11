using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNAAlignmentToolWithXYBases
{
    abstract public class SequenceAligner
    {
        protected int similiarityScore;
        protected String seq1, seq2;
        protected int nMScore, nMMScore, nGapScore, eMScore, eMMScore, eGapScore;
        protected int[,] alignmentTable, pathTaken;

        //accessor for score
        public int getScore()
        {
            return similiarityScore;
        }


        //determines whether the base is one of the natural ones: A ,T ,C , G 
        protected bool isNatural(char base0)
        {
            switch(Char.ToLower(base0))
            {
                case ('a'):             //Adenine
                    return true;
                case ('t'):             //Thymine
                    return true;
                case ('c'):             //Cytosine
                    return true;
                case ('g'):             //Guanine
                    return true;
                case ('u'):             //Uracil
                    return true;
                case ('r'):             //Purine (A or G)
                    return true;
                case ('y'):             //Pyrimidine (C, T, or U)
                    return true;
                case ('k'):             //Ketones (G, T, or U)
                    return true;
                case ('m'):             //aMino groups (A or C)
                    return true;
                case ('s'):             //Strong interaction (C or G)
                    return true;
                case ('w'):             //Weak interaction (A or T)
                    return true;
                case ('b'):             //B comes after A (C, G, T, or U)
                    return true;
                case ('d'):             //D comes after C (A, G, T, or U)
                    return true;
                case ('h'):             //H comes after G (A, C, T, or U)
                    return true;
                case ('v'):             //V comes after U  (A, C, or G)
                    return true;
                case ('n'):             //Nucleic acid  (A, C, G, T, or U)
                    return true;
                default:
                    return false;
            }
        }


        //determines whether the base is one of the natural ones: A ,T ,C , G 
        protected static bool isExotic(char base0)
        {
            if (base0 == 'x' || base0 == 'X')
                return true;
            else if (base0 == 'Y' || base0 == 'Y')
                return true;
            else
                return false;
        }

        //compares the current nucleotide and returns the appropriate score
        protected int compareNucleotides(char base1, char base2, int mScore, int mmScore)
        {
            base1 = Char.ToLower(base1);
            base2 = Char.ToLower(base2);
            if (base1.CompareTo(base2) == 0)
                return mScore;
            else
                return mmScore;
        }

        //determines the highest score out of 3 possibilities
        protected int findBestPath(int seq1Gap, int seq2Gap, int noGap)
        {
            if ((noGap >= seq1Gap) && (noGap >= seq2Gap))       //no gap
                return 1;
            else if (seq1Gap >= seq2Gap)                        //gap in sequence 1
                return 2;
            else                                                //gap in sequence 2
                return 3;
        }

        abstract public String[] alignSequences();
        abstract protected void buildTables();
        abstract protected String[] buildSequences();
    }
}
