using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DNAAlignmentToolWithXYBases
{
    public partial class MainForm : Form
    {
        private Sequence outSeq1, outSeq2;

        public MainForm()
        {
            InitializeComponent();
        }

        private void alignBtn_Click(object sender, EventArgs e)
        {
            String format1 = (String) FormatBox1.SelectedItem;
            String format2 = (String) FormatBox2.SelectedItem;
            Sequence seq1 = new Sequence(Sequence1.Text, format1);
            Sequence seq2 = new Sequence(Sequence2.Text, format2);
            int nMScore = Convert.ToInt32(NaturalMatchScore.Text);
            int nMmScore = Convert.ToInt32(NaturalMismatchScore.Text);
            int nGapScore = Convert.ToInt32(NaturalGapScore.Text);
            int eMScore = Convert.ToInt32(ExoticMatchScore.Text);
            int eMmScore = Convert.ToInt32(ExoticMismatchScore.Text);
            int eGapScore = Convert.ToInt32(ExoticGapScore.Text);
            try
            {
                SequenceAlignment alignment = new SequenceAlignment(seq1.getSequence(), seq2.getSequence(), nMScore, nMmScore, nGapScore, eMScore, eMmScore, eGapScore);
                String[] outputSeqs = alignment.alignSequences();
                outSeq1 = new Sequence(outputSeqs[0], seq1.getDescriptor(), "Raw");
                outSeq2 = new Sequence(outputSeqs[1], seq2.getDescriptor(), "Raw");
                OutputSequence1.Text = outSeq1.toString();
                OutputSequence2.Text = outSeq2.toString();
                SimilarityScore.Text = (alignment.getScore()).ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }   
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        //import a sequence from file, format of file is a raw sequence
        private void importSequence1Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openSeqFile = new OpenFileDialog();
            openSeqFile.ShowDialog();
            String seqFile = openSeqFile.FileName;
            String[] seqs = File.ReadAllLines(seqFile);
            Sequence1.Text = seqs[0];
        }

        //import a sequence from file, format of file is a raw sequence
        private void ImportSequence2Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openSeqFile = new OpenFileDialog();
            openSeqFile.ShowDialog();
            String seqFile = openSeqFile.FileName;
            String[] seqs = File.ReadAllLines(seqFile);
            Sequence2.Text = seqs[0];
        }

        //export aligned sequences to file, format of file is a raw sequence
        private void ExportSequencesBtn_Click(object sender, EventArgs e)
        {
            String outputSeqs;
            String temp, tempSeq;
            String formatO = (String) FormatBoxO.SelectedItem;
            if (formatO.Equals("Raw"))
                outputSeqs = outSeq1.getSequence() + "\r\n\r\n" + outSeq2.getSequence();
            else if (formatO.Equals("FASTA"))
            {
                outputSeqs = outSeq1.getDescriptor() + "\r\n";
                tempSeq = outSeq1.getSequence();
                for (int i = 0; i < tempSeq.Length; i += 80)
                {
                    if ((i + 80) >= tempSeq.Length)
                        tempSeq.Substring(i);
                    else
                        outputSeqs += tempSeq.Substring(i, 80) + "\r\n";
                }
                outputSeqs += "\r\n\r\n";
                outputSeqs += outSeq2.getDescriptor() + "\r\n";
                tempSeq = outSeq2.getSequence();
                for (int i = 0; i < tempSeq.Length; i += 80)
                {
                    if ((i + 80) >= tempSeq.Length)
                        tempSeq.Substring(i);
                    else
                        outputSeqs += tempSeq.Substring(i, 80) + "\r\n";
                }
                outputSeqs += "\r\n\r\n";
            }
            else
                outputSeqs = "";

            SaveFileDialog saveSeqFile = new SaveFileDialog();
            saveSeqFile.ShowDialog();
            String savePath = saveSeqFile.FileName;
            if (!savePath.Equals(""))
                File.WriteAllText(savePath, outputSeqs);
        }
    }
}
