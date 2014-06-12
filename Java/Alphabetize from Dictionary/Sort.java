class Sort {
  private Letter[] letters;
  private Letter[] auxil;

  private int number;

  public Sort(Letter[] inLetters)
  {
    letters = inLetters;
  }
  
  public void mergeSort() 
  {
    auxil = new Letter[letters.length];
    rMergeSort(0, number - 1);
  }

  private void rMergeSort(int low, int high) {
    // check if low is smaller then high, if not then the array is sorted
    if (low < high) {
      // Get the index of the element which is in the middle
      int middle = low + (high - low) / 2;
      // Sort the left side of the array
      rMergeSort(low, middle);
      // Sort the right side of the array
      rMergeSort(middle + 1, high);
      // Combine them both
      merge(low, middle, high);
    }
  }

  private void merge(int low, int middle, int high) {

    // Copy both parts into the auxil array
    for (int i = low; i <= high; i++) {
      auxil[i] = letters[i];
    }

    int i = low;
    int j = middle + 1;
    int k = low;
    // Copy the smallest values from either the left or the right side back
    // to the original array
    while (i <= middle && j <= high) {
      if (auxil[i].getPosition() <= auxil[j].getPosition()) {
        letters[k] = auxil[i];
        i++;
      } else {
        letters[k] = auxil[j];
        j++;
      }
      k++;
    }
    // Copy the rest of the left side of the array into the target array
    while (i <= middle) 
    {
      letters[k] = auxil[i];
      k++;
      i++;
    }
  }
  
  
  public void insertionSort()
  {
    int j;
     for (int i = 1; i < letters.length; i++)    // Start with 1 (not 0)
    {
       for(j=i-1; (j>=0) && (letters[j].getPosition()<letters[i].getPosition()); j--)   // Smaller values are moving up
       {
         letters[j+1] = letters[j];
       }
       letters[j+1] = letters[i];    // Put the key in its proper location
     }
  } 
} 