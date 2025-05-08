namespace Laba2_SyncThreads_CSharp.classes;

public class RandomArray {
  public int[] array;

  public RandomArray(int amountOfElements, int maxValue) {
    array = new int[amountOfElements];

    initArray(amountOfElements, maxValue);
  }

  private void initArray(int amountOfElements, int maxValue) {
    var rnd = new Random();
    var targetRandomElem = amountOfElements / 2;

    for (var i = 0; i < amountOfElements; i++)
    {
      array[i] = rnd.Next(maxValue) + 1;
      if (i == targetRandomElem) array[i] *= -1;
    }
  }

  public ArrayElement findMinElemInSection(int sectionStart, int sectionEnd) {
    var min = int.MaxValue;
    var idx = -1;
    for (var i = sectionStart; i <= sectionEnd; i++) {
      if (array[i] < min) {
        min = array[i];
        idx = i;
      }
    }

    return new ArrayElement(min, idx);
  }
}

