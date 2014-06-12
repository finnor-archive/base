import java.util.LinkedList;
import java.util.TreeMap;

class FindAlphabet
{
 public static char[] FindAlphabet (String[] dictionary)
 {
   int maxUnicodeValue = 0;
   
   String currentWord;
   int wordLength;
   int currentValue;
   
   System.out.println("Progress:");
   System.out.println("\n-------------------------------------------------");
   System.out.println("Building Tables and Analyzing Metadata:");
   for (int i=0; i<dictionary.length; i++)
   {
     currentWord = dictionary[i];
     for (int j=0; j<currentWord.length(); j++)
     {
       currentValue = (int) currentWord.charAt(j);
       if (maxUnicodeValue<currentValue)
         maxUnicodeValue=currentValue;
     }
   }
   System.out.println("Largest Unicode Value Present = " + maxUnicodeValue);
   
   int[] letters = new int[maxUnicodeValue+1];
   int currentLetter;
   for (int i=0; i<dictionary.length; i++)
   {
     currentWord = dictionary[i];
     for (int j=0; j<currentWord.length(); j++)
     {
       currentLetter = (int) currentWord.charAt(j);
       letters[currentLetter]++;
     }
   }
   
   int numLetters = 0;
   int topLetterCount = 0;
   int topLetter = 0;
   for (int i=0; i<letters.length; i++)
   {
     if (letters[i]!=0)
       numLetters++;
     if (letters[i]>topLetterCount)
     {
       topLetterCount = letters[i];
       topLetter = i;
     }
       
   }
     
   System.out.println("Number of Letters = " + numLetters);
   System.out.println("Most Occuring Letter(" + topLetterCount + " times) = " + (char) topLetter);
   
   
   
   
   
   
   
   LinkedList<Character>[] hashBefore = new LinkedList[maxUnicodeValue+1];
   LinkedList<Character>[] hashAfter = new LinkedList[maxUnicodeValue+1];
   int[] lettersBefore = new int[maxUnicodeValue+1]; 
   for (int i=0; i<letters.length; i++)
   {
     if (letters[i]==0)
       lettersBefore[i]=-1;
     else
     {
       hashBefore[i] = new LinkedList();
       hashAfter[i] = new LinkedList();
     }
   }
   
   
   
   System.out.println("\n-------------------------------------------------");
   
   
   System.out.println("Analyzing Dicionary");
   
   int shorterWordLength;
   String prefix1, prefix2;
   String word1, word2;
   char letter1, letter2;
   for (int i=0; i<dictionary.length-1; i++)
   {
     word1 = dictionary[i];
     word2 = dictionary[i+1];
     shorterWordLength = word1.length();
     if (shorterWordLength>word2.length())
         shorterWordLength = word2.length();
     for (int j=0; j<shorterWordLength; j++)
     {
       prefix1 = word1.substring(0,j);
       prefix2 = word2.substring(0,j);
       if (prefix1.compareTo(prefix2)==0)
       {
         letter1 = word1.charAt(j);
         letter2 = word2.charAt(j);
         if (letter1!=letter2)
         {
           if (!hashBefore[letter2].contains(letter1))
           {
             hashBefore[letter2].add(letter1);
             hashAfter[letter1].add(letter2);
             lettersBefore[letter2]++;
           }
         }
       }
     }
   }
    
   
   System.out.println("\n-------------------------------------------------");  
   
   
   System.out.println("Reconstructing Alphabet: ");   
   
   Letter[] alphabetOrdering = new Letter[numLetters];
   int k = 0;
   for (int i=0; i<lettersBefore.length; i++)
   {
     if (lettersBefore[i]!=-1)
     {
       alphabetOrdering[k] = new Letter(i, lettersBefore[i]);
       k++;
       System.out.println(lettersBefore[i] + "-" + (char)i);
     }
   }
   
   Sort sortByPosition = new Sort(alphabetOrdering);
   sortByPosition.mergeSort();
   
   Letter thisLetter;
   Letter nextLetter;
   char[] totalOrder = new char[numLetters];
   LinkedList<Character> laterList;
   char laterLetter;
   for(int i=0; i<alphabetOrdering.length; i++)
   {
     thisLetter=alphabetOrdering[i];
     if (i<alphabetOrdering.length-1)
     {
       nextLetter=alphabetOrdering[i+1];
       if (thisLetter.getPosition()==nextLetter.getPosition())
       {
         System.out.println("Not enough information to reconstruct alphabet v1");
         break;
       }   
     }
       
     if (thisLetter.getPosition()!=0)
     {
       System.out.println("Not enough information to reconstruct alphabet v2");
       break;
     }
     else 
     {
       totalOrder[i] = (char) thisLetter.getLetter();
       thisLetter.setPosition(-1);
       laterList = hashAfter[thisLetter.getLetter()];
       while (laterList.size()>0)
       {
         laterLetter = laterList.remove();
         for (int j=i; j<alphabetOrdering.length; j++)
         {
           if (alphabetOrdering[j].getLetter()==laterLetter)
             alphabetOrdering[j].decPosition();
         }
       }
     }
   }
   
   System.out.println("\n-------------------------------------------------"); 
   
   return(totalOrder);
 }
}
   
   
   
   
 