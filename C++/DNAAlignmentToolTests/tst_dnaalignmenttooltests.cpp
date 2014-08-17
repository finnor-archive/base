#include <QtCore/QString>
#include <QtTest/QtTest>
#include "LocalAligner.h"
#include "GlobalAligner.h"
#include "SequenceAligner.h"

class DNAAlignmentToolTests : public QObject
{
    Q_OBJECT
    
public:
    DNAAlignmentToolTests();
    
private Q_SLOTS:
    //SequenceAligner Tests
    void IsNaturalReturnsTrueForValidNaturalBase();
    void IsNaturalReturnsFalseForInvalidNaturalBase();
    void IsExoticReturnsTrueForValidExoticBase();
    void IsExoticReturnsFalseForInvalidExoticBase();
    void CompareNucleotidesReturnsTheCorrectScoreForAMatch();
    void CompareNucleotidesReturnsTheCorrectScoreForAnIndel();
    void FindBestPathReturnsCorrectPathWhenNoGap();
    void FindBestPathReturnsCorrectPathWhenThereIsAGap();

    //LocalAligner Tests
    void AlignLocalSequencePerformsCorrectAlignmentWhenAllNatural();
    void AlignLocalSequencePerformsCorrectAlignmentWhenAllExotic();
    void AlignLocalSequencePerformsCorrectAlignmentWhenMixed();
    void AlignLocalSequencePerformsCorrectAlignmentWhenSubsequenceIsIntheFront();
    void AlignLocalSequencePerformsCorrectAlignmentWhenSubsequenceIsIntheBack();
    void AlignLocalSequencePerformsCorrectAlignmentWhenSubsequenceIsIntheMiddle();


    //GlobalAligner Tests
    void AlignGlobalSequencePerformsCorrectAlignmentWhenAllNatural();
    void AlignGlobalSequencePerformsCorrectAlignmentWhenAllExotic();
    void AlignGlobalSequencePerformsCorrectAlignmentWhenMixed();
    void AlignLocalSequencePerformsCorrectAlignmentWithGapsInFront();
    void AlignLocalSequencePerformsCorrectAlignmentWithGapsInBack();
    void AlignLocalSequencePerformsCorrectAlignmentWithGapsInFrontAndBack();
    void AlignLocalSequencePerformsCorrectAlignmentWithGapsInMiddle();
};

DNAAlignmentToolTests::DNAAlignmentToolTests()
{
}

/*********************************************************************




                                Unit tests





*********************************************************************/


//*************************SequenceAligner Tests**********************
//SequenceAligner is an abstract class so the methods will be tested
//using LocalAligner




/*****************************************
IsNaturalReturnsTrueForValidNaturalBase

Arrange:    Construct LocalAligner
            base0='a'

Act:        result = isNatural(base0)

Assert:     result == true
*****************************************/
void DNAAlignmentToolTests::IsNaturalReturnsTrueForValidNaturalBase()
{
    LocalAligner::LocalAligner testAligner("","",0,0,0,0,0,0);
    char base0 = 'a';

    bool result = testAligner.isNatural(base0);

    QVERIFY2(result==true, "IsNatural Returned False for Valid Natural Base");
}

/*****************************************
IsNaturalReturnsFalseForInvalidNaturalBase

Arrange:    Construct LocalAligner
            base0='x'

Act:        result = isNatural(base0)

Assert:     result == false
*****************************************/
void DNAAlignmentToolTests::IsNaturalReturnsFalseForInvalidNaturalBase()
{
    LocalAligner testAligner("","",0,0,0,0,0,0);
    char base0 = 'x';

    bool result = testAligner.isNatural(base0);

    QVERIFY2(result==false, "IsNatural Returned True for Invalid Natural Base");
}



/*****************************************
IsExoticReturnsTrueForValidExoticBase

Arrange:    Construct LocalAligner
            base0='x'

Act:        result = isExotic(base0)

Assert:     result == true
*****************************************/
void DNAAlignmentToolTests::IsExoticReturnsTrueForValidExoticBase()
{
    LocalAligner::LocalAligner testAligner("","",0,0,0,0,0,0);
    char base0 = 'x';

    bool result = testAligner.isExotic(base0);

    QVERIFY2(result==true, "IsExotic Returned False for Valid Exotic Base");
}

/*****************************************
IsExoticReturnsFalseForInvalidExoticBase

Arrange:    Construct LocalAligner
            base0='a'

Act:        result = isExotic(base0)

Assert:     result == false
*****************************************/
void DNAAlignmentToolTests::IsExoticReturnsFalseForInvalidExoticBase()
{
    LocalAligner testAligner("","",0,0,0,0,0,0);
    char base0 = 'a';

    bool result = testAligner.isExotic(base0);

    QVERIFY2(result==false, "IsExotic Returned True for Invalid Exotic Base");
}


/*****************************************
CompareNucleotidesReturnsTheCorrectScoreForAMatch

Arrange:    Construct LocalAligner
            base1='a'
            base2='a'
            mScore=1


Act:        result = compareNucleotides(base1, base2, mScore, 0)

Assert:     result == 1
*****************************************/
void DNAAlignmentToolTests::CompareNucleotidesReturnsTheCorrectScoreForAMatch()
{
    LocalAligner testAligner("","",0,0,0,0,0,0);
    char base1 = 'a';
    char base2 = 'a';
    int mScore = 1;

    int result = testAligner.compareNucleotides(base1, base2, mScore, 0);


    QVERIFY2(result==1, "CompareNucleotide Returned the Incorect Score for a Match");
}


/*****************************************
CompareNucleotidesReturnsTheCorrectScoreForAnIndel

Arrange:    Construct LocalAligner
            base1='a'
            base2='t'
            mmScore=1


Act:        result = compareNucleotides(base1, base2, 0, mmScore)

Assert:     result == 1
*****************************************/
void DNAAlignmentToolTests::CompareNucleotidesReturnsTheCorrectScoreForAnIndel()
{
    LocalAligner testAligner("","",0,0,0,0,0,0);
    char base1 = 'a';
    char base2 = 't';
    int mmScore = 1;

    int result = testAligner.compareNucleotides(base1, base2, 0, mmScore);


    QVERIFY2(result==1, "CompareNucleotide Returned the Incorect Score for a Match");
}


/*****************************************
FindBestPathReturnsCorrectPathWhenNoGap

Arrange:    Construct LocalAligner
            noGap = 2
            seq1Gap = 1
            seq2Gap = 1


Act:        result = findBestPath(seq1Gap, seq2Gap, noGap)

Assert:     result == 1
*****************************************/
void DNAAlignmentToolTests::FindBestPathReturnsCorrectPathWhenNoGap()
{
    LocalAligner testAligner("","",0,0,0,0,0,0);
    int noGap = 2;
    int seq1Gap = 1;
    int seq2Gap = 1;

    int result = testAligner.findBestPath(seq1Gap, seq2Gap, noGap);


    QVERIFY2(result==1, "FindBestPath Returned the Incorect Path for No Gap");
}


/*****************************************
FindBestPathReturnsCorrectPathWhenThereIsAGap

Arrange:    Construct LocalAligner
            noGap = 1
            seq1Gap = 2
            seq2Gap = 1


Act:        result = findBestPath(seq1Gap, seq2Gap, noGap)

Assert:     result == 1
*****************************************/
void DNAAlignmentToolTests::FindBestPathReturnsCorrectPathWhenThereIsAGap()
{
    LocalAligner testAligner("","",0,0,0,0,0,0);
    int noGap = 1;
    int seq1Gap = 2;
    int seq2Gap = 1;

    int result = testAligner.findBestPath(seq1Gap, seq2Gap, noGap);


    QVERIFY2(result==2, "FindBestPath Returned the Incorect Path for a Gap");
}



















//*************************LocalAligner Tests**********************











/*****************************************
AlignLocalSequencePerformsCorrectAlignmentWhenAllNatural

Arrange:    LocalAligner(AGATTAA, ACAAA, 5, -1, -2, 0, 0, 0)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 15        A G A T T A A
                                5 -15-2-2 5 5
                                A C A - - A A
*****************************************/
void DNAAlignmentToolTests::AlignLocalSequencePerformsCorrectAlignmentWhenAllNatural()
{
    LocalAligner testAligner("AGATTAA", "ACAAA", 5, -1, -2, 0, 0, 0);

    testAligner.alignLocalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();


    QVERIFY2(result==15 && seq1.compare("AGATTAA")==0 && seq2.compare("ACA--AA")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}


/*****************************************
AlignLocalSequencePerformsCorrectAlignmentWhenAllExotic

Arrange:    LocalAligner(XXYYXX, XXXX, 0, 0, 0, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 30        X X Y Y Y Y
                               1010-6-61010
                                X X - - X X
*****************************************/
void DNAAlignmentToolTests::AlignLocalSequencePerformsCorrectAlignmentWhenAllExotic()
{
    LocalAligner testAligner("XXYYXX", "XXXX", 0, 0, 0, 10, -5, -6);

    testAligner.alignLocalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==28 && seq1.compare("XXYYXX")==0 && seq2.compare("XX--XX")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}


/*****************************************
AlignLocalSequencePerformsCorrectAlignmentWhenAllMixed

Arrange:    LocalAligner(AAXAAYYAAXAA, AAAATYYAATAA, 5, -1, -2, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 47        A A X A A - Y Y A A X A A
                                5 5-6 5 5-21010 5 5-5 5 5
                                A A - A A T Y Y A A T A A
*****************************************/
void DNAAlignmentToolTests::AlignLocalSequencePerformsCorrectAlignmentWhenMixed()
{
    LocalAligner testAligner("AAXAAYYAAXAA", "AAAATYYAATAA", 5, -1, -2, 10, -5, -6);

    testAligner.alignLocalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==47 && seq1.compare("AAXAA-YYAAXAA")==0 && seq2.compare("AA-AATYYAATAA")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}




/*****************************************
AlignLocalSequencePerformsCorrectAlignmentWhenSubsequenceIsIntheMiddle

Arrange:    LocalAligner(TTXXTT, AAXXAA, 5, -1, -2, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 20        X X
                               1010
                                X X
*****************************************/
void DNAAlignmentToolTests::AlignLocalSequencePerformsCorrectAlignmentWhenSubsequenceIsIntheMiddle()
{
    LocalAligner testAligner("TTXXTT", "AAXXAA", 5, -1, -2, 10, -5, -6);

    testAligner.alignLocalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==20 && seq1.compare("XX")==0 && seq2.compare("XX")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}




/*****************************************
AlignLocalSequencePerformsCorrectAlignmentWhenSubsequenceIsIntheFront

Arrange:    LocalAligner(XXAA, XXTT, 5, -1, -2, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 20        X X
                               1010
                                X X
*****************************************/
void DNAAlignmentToolTests::AlignLocalSequencePerformsCorrectAlignmentWhenSubsequenceIsIntheFront()
{
    LocalAligner testAligner("XXAA", "XXTT", 5, -1, -2, 10, -5, -6);

    testAligner.alignLocalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==20 && seq1.compare("XX")==0 && seq2.compare("XX")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}




/*****************************************
AlignLocalSequencePerformsCorrectAlignmentWhenSubsequenceIsIntheBack

Arrange:    LocalAligner(AAXX, TTXX, 5, -1, -2, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 20        X X
                               1010
                                X X
*****************************************/
void DNAAlignmentToolTests::AlignLocalSequencePerformsCorrectAlignmentWhenSubsequenceIsIntheBack()
{
    LocalAligner testAligner("AAXX", "TTXX", 5, -1, -2, 10, -5, -6);

    testAligner.alignLocalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==20 && seq1.compare("XX")==0 && seq2.compare("XX")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}




























//*************************GlobalAligner Tests**********************







/*****************************************
AlignGlobalSequencePerformsCorrectAlignmentWhenAllNatural

Arrange:    LocalAligner(AGATTAA, ACAAA, 5, -1, -2, 0, 0, 0)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 15        A G A T T A A
                                5 -15-2-2 5 5
                                A C A - - A A
*****************************************/
void DNAAlignmentToolTests::AlignGlobalSequencePerformsCorrectAlignmentWhenAllNatural()
{
    GlobalAligner testAligner("AGATTAA", "ACAAA", 5, -1, -2, 0, 0, 0);

    testAligner.alignGlobalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();


    QVERIFY2(result==15 && seq1.compare("AGATTAA")==0 && seq2.compare("ACA--AA")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}


/*****************************************
AlignGlobalSequencePerformsCorrectAlignmentWhenAllExotic

Arrange:    GlobalAligner(XXYYXX, XXXX, 0, 0, 0, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 30        X X Y Y Y Y
                               1010-6-61010
                                X X - - X X
*****************************************/
void DNAAlignmentToolTests::AlignGlobalSequencePerformsCorrectAlignmentWhenAllExotic()
{
    GlobalAligner testAligner("XXYYXX", "XXXX", 0, 0, 0, 10, -5, -6);

    testAligner.alignGlobalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==28 && seq1.compare("XXYYXX")==0 && seq2.compare("XX--XX")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}


/*****************************************
AlignGlobalSequencePerformsCorrectAlignmentWhenAllMixed

Arrange:    GlobalAligner(AAXAAYYAAXAA, AAAATYYAATAA, 5, -1, -2, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 47        A A X A A - Y Y A A X A A
                                5 5-6 5 5-21010 5 5-5 5 5
                                A A - A A T Y Y A A T A A
*****************************************/
void DNAAlignmentToolTests::AlignGlobalSequencePerformsCorrectAlignmentWhenMixed()
{
    GlobalAligner testAligner("AAXAAYYAAXAA", "AAAATYYAATAA", 5, -1, -2, 10, -5, -6);

    testAligner.alignGlobalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==47 && seq1.compare("AAXAA-YYAAXAA")==0 && seq2.compare("AA-AATYYAATAA")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}





/*****************************************
AlignGlobalSequencePerformsCorrectAlignmentWithGapsInFront

Arrange:    GlobalAligner(AAXXAA, XXAA, 5, -1, -2, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 26        A A X X A A
                               -2-21010 5 5
                                - - X X A A
*****************************************/
void DNAAlignmentToolTests::AlignLocalSequencePerformsCorrectAlignmentWithGapsInFront()
{
    GlobalAligner testAligner("AAXXAA", "XXAA", 5, -1, -2, 10, -5, -6);

    testAligner.alignGlobalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==26 && seq1.compare("AAXXAA")==0 && seq2.compare("--XXAA")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}



/*****************************************
AlignGlobalSequencePerformsCorrectAlignmentWithGapsInBack

Arrange:    GlobalAligner(AAXXAA, AAXX, 5, -1, -2, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 26        A A X X A A
                                5 51010-2-2
                                A A X X - -
*****************************************/
void DNAAlignmentToolTests::AlignLocalSequencePerformsCorrectAlignmentWithGapsInBack()
{
    GlobalAligner testAligner("AAXXAA", "AAXX", 5, -1, -2, 10, -5, -6);

    testAligner.alignGlobalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==26 && seq1.compare("AAXXAA")==0 && seq2.compare("AAXX--")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}



/*****************************************
AlignGlobalSequencePerformsCorrectAlignmentWithGapsInFrontAndBack

Arrange:    GlobalAligner(AAXXAA, AAXX, 5, -1, -2, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 26        A A X X A A
                               -2-21010-2-2
                                - - X X - -
*****************************************/
void DNAAlignmentToolTests::AlignLocalSequencePerformsCorrectAlignmentWithGapsInFrontAndBack()
{
    GlobalAligner testAligner("AAXXAA", "XX", 5, -1, -2, 10, -5, -6);

    testAligner.alignGlobalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==12 && seq1.compare("AAXXAA")==0 && seq2.compare("--XX--")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}




/*****************************************
AlignGlobalSequencePerformsCorrectAlignmentWithGapsInMiddle

Arrange:    GlobalAligner(AAXXTT, AATT, 5, -1, -2, 10, -5, -6)



Act:        alignLocalSequence()
            result = getScore

Assert:     result == 8         A A X X A A
                                5 5-6-6 5 5
                                A A - - T T
*****************************************/
void DNAAlignmentToolTests::AlignLocalSequencePerformsCorrectAlignmentWithGapsInMiddle()
{
    GlobalAligner testAligner("AAXXTT", "AATT", 5, -1, -2, 10, -5, -6);

    testAligner.alignGlobalSequence();
    int result = testAligner.getScore();
    std::string seq1 = testAligner.getSeq1();
    std::string seq2 = testAligner.getSeq2();

    QVERIFY2(result==8 && seq1.compare("AAXXTT")==0 && seq2.compare("AA--TT")==0, "AlignLocalSequence Set Incorrect Similarity Score");
}



QTEST_APPLESS_MAIN(DNAAlignmentToolTests)

#include "tst_dnaalignmenttooltests.moc"
