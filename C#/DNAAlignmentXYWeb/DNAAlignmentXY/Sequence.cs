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
    class Sequence
    {
        private String rawSequence = "";
        private String descriptor;
        private String format;

        public Sequence(String sequence, String inFormat)
        {
            String[] sequenceByLines;
            String raw = "Raw";
            format = inFormat;
            if (format.Equals(raw))
            {
                rawSequence = sequence;
                descriptor = "";
            }
            else if ("FASTA".Equals(format))
            {
                sequenceByLines = sequence.Split(new Char[] {'\r', '\n'});
                for (int i = 0; i < sequenceByLines.Length; i++)
                {
                    if (!sequenceByLines[i].Equals(""))                     //ignore empty spaces between \r and \n
                    {
                        if ((sequenceByLines[i])[0] == '>')                 //descriptor line
                            descriptor = sequenceByLines[i];
                        else if ((sequenceByLines[i])[0] == ';')            //skip comment
                            ;
                        else
                            rawSequence += sequenceByLines[i];              //else sequence
                    }
                }
            }
        }

        public Sequence(String sequence, String inDescriptor, String inFormat)
        {
            rawSequence = sequence;
            descriptor = inDescriptor;
            format = inFormat;
        }

        public String getSequence()
        {
            return (rawSequence);
        }

        public String getDescriptor()
        {
            return (descriptor);
        }

        public String getFormat()
        {
            return (format);
        }

        public String toString()
        {
            return (rawSequence);
        }
    }
}
