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
        public MainForm()
        {
            InitializeComponent();
        }

        private void alignBtn_Click(object sender, EventArgs e)
        {
            String seq1 = Sequence1.Text;
            String seq2 = Sequence2.Text;
            int nMScore = Convert.ToInt32(NaturalMatchScore.Text);
            int nMmScore = Convert.ToInt32(NaturalMismatchScore.Text);
            int nGapScore = Convert.ToInt32(NaturalGapScore.Text);
            int eMScore = Convert.ToInt32(ExoticMatchScore.Text);
            int eMmScore = Convert.ToInt32(ExoticMismatchScore.Text);
            int eGapScore = Convert.ToInt32(ExoticGapScore.Text);
            try
            {
                SequenceAlignment alignment = new SequenceAlignment(seq1, seq2, nMScore, nMmScore, nGapScore, eMScore, eMmScore, eGapScore);
                String[] outputSeqs = alignment.alignSequences();
                OutputSequence1.Text = outputSeqs[0];
                OutputSequence2.Text = outputSeqs[1];
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
            SaveFileDialog saveSeqFile = new SaveFileDialog();
            saveSeqFile.ShowDialog();
            String savePath = saveSeqFile.FileName;
            String outputSeqs = OutputSequence1.Text + "\r\n" + OutputSequence2.Text;
            File.WriteAllText(savePath, outputSeqs);
        }
    }
}
