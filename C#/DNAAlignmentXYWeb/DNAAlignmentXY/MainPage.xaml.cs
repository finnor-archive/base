using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;

namespace DNAAlignmentXY
{
    public partial class MainPage : UserControl
    {
        private Sequence outSeq1, outSeq2;

        public MainPage()
        {
            InitializeComponent();
        }


        private void alignBtn_Click(object sender, RoutedEventArgs e)
        {
            String format1 = FormatBox1.SelectionBoxItem.ToString();
            String format2 = FormatBox2.SelectionBoxItem.ToString();
            Sequence seq1 = new Sequence(Sequence1.Text, format1);
            Sequence seq2 = new Sequence(Sequence2.Text, format2);
            int nMScore = Convert.ToInt32(NaturalMatchScore.Text);
            int nMmScore = Convert.ToInt32(NaturalMismatchScore.Text);
            int nGapScore = Convert.ToInt32(NaturalGapScore.Text);
            int eMScore = Convert.ToInt32(ExoticMatchScore.Text);
            int eMmScore = Convert.ToInt32(ExoticMismatchScore.Text);
            int eGapScore = Convert.ToInt32(ExoticGapScore.Text);
            String mode = ModeBox.SelectionBoxItem.ToString();
            SequenceAligner alignment;
            try
            {
                if (mode.Equals("Global(Needleman–Wunsch)"))
                    alignment = new GlobalAligner(seq1.getSequence(), seq2.getSequence(), nMScore, nMmScore, nGapScore, eMScore, eMmScore, eGapScore);
                else if (mode.Equals("Local(Smith-Waterman)"))
                    alignment = new LocalAligner(seq1.getSequence(), seq2.getSequence(), nMScore, nMmScore, nGapScore, eMScore, eMmScore, eGapScore);
                else
                    throw new Exception("Invalid Mode");
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
        private void importSequence1Btn_Click(object sender, RoutedEventArgs e)
        {
            String seqs = "";
            try
            {
                OpenFileDialog openSeqFile = new OpenFileDialog();
                openSeqFile.Filter = "Sequence files (*.fasta,*.fas,*.fa,*.seq,*.fsa)|*.fasta;*.fas;*.fa;*.seq;*.fsa|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openSeqFile.ShowDialog();
                System.IO.Stream fileStream = openSeqFile.File.OpenRead();

                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    // Read the entire file
                    seqs = reader.ReadToEnd();
                }
                fileStream.Close();
                Sequence1.Text = seqs;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        //import a sequence from file, format of file is a raw sequence
        private void importSequence2Btn_Click(object sender, RoutedEventArgs e)
        {
            String seqs = "";
            try
            {
                OpenFileDialog openSeqFile = new OpenFileDialog();
                openSeqFile.Filter = "Sequence files (*.fasta,*.fas,*.fa,*.seq,*.fsa)|*.fasta;*.fas;*.fa;*.seq;*.fsa|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openSeqFile.ShowDialog();
                System.IO.Stream fileStream = openSeqFile.File.OpenRead();

                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    // Read the entire file
                    seqs = reader.ReadToEnd();
                }
                fileStream.Close();
                Sequence2.Text = seqs;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        //export aligned sequences to file, format of file is a raw sequence
        private void exportSequencesBtn_Click(object sender, RoutedEventArgs e)
        {
            String outputSeqs = "Aligned Sequences\r\n\r\n";
            String tempSeq;
            String formatO = FormatBoxO.SelectionBoxItem.ToString();


            if (formatO.Equals("Raw"))
                outputSeqs = outSeq1.getSequence() + "\r\n\r\n" + outSeq2.getSequence();
            else if (formatO.Equals("FASTA"))
            {
                outputSeqs = outSeq1.getDescriptor() + "\r\n";
                tempSeq = outSeq1.getSequence();
                for (int i = 0; i < tempSeq.Length; i += 80)
                {
                    if ((i + 80) >= tempSeq.Length)
                        outputSeqs += tempSeq.Substring(i);
                    else
                        outputSeqs += tempSeq.Substring(i, 80) + "\r\n";
                }
                outputSeqs += "\r\n\r\n";
                outputSeqs += outSeq2.getDescriptor() + "\r\n";
                tempSeq = outSeq2.getSequence();
                for (int i = 0; i < tempSeq.Length; i += 80)
                {
                    if ((i + 80) >= tempSeq.Length)
                        outputSeqs += tempSeq.Substring(i);
                    else
                        outputSeqs += tempSeq.Substring(i, 80) + "\r\n";
                }
                outputSeqs += "\r\n\r\n";
            }
            else
                outputSeqs = "";

            SaveFileDialog saveSeqFile = new SaveFileDialog();
            saveSeqFile.Filter = "Sequence file (*.fa)|*.fa|Text file (*.txt)|*.txt";
            saveSeqFile.ShowDialog();

            try 
            {  
                byte[] bytes = new byte[outputSeqs.Length * sizeof(char)];
                System.Buffer.BlockCopy(outputSeqs.ToCharArray(), 0, bytes, 0, bytes.Length);

                using (Stream fs = (Stream)saveSeqFile.OpenFile())  
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();  

                }  
            }  
            catch (Exception exc)  
            {
                MessageBox.Show(exc.Message); 
            } 
        }
    }
}
