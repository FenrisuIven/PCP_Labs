namespace Laba2_SyncThreads_CSharp.classes;

public class ThreadedMinSearch {
  private readonly object locker = new();
  private int amountOfElements;
  private int amountOfThreads;
  private RandomArray array;

  private ArrayElement min = new(int.MaxValue, -1);
  private int finishedThreadsCount;

  public ThreadedMinSearch(int amountOfThreads, int amountOfElements, RandomArray array) {
    this.amountOfThreads = amountOfThreads;
    this.amountOfElements = amountOfElements;
    this.array = array;
  }

  public void setMinElem(ArrayElement newMin) {
    if (newMin.element < min.element)
      lock (locker) {
        min = newMin;
      }
  }

  private int getFinishedThreadsCount() {
    return finishedThreadsCount;
  }

  public void incThreadCount() {
    lock (locker) {
      finishedThreadsCount++;
      Monitor.Pulse(locker);
    }
  }

  private ArrayElement getMinElem() {
    lock (locker) {
      while (getFinishedThreadsCount() < amountOfThreads) {
        Monitor.Wait(locker);
      }
    }
    return min;
  }

  public ArrayElement findMinElem() {
    var sections = new SearchMinElemInSection[amountOfThreads];

    var elemsInSection = amountOfElements / amountOfThreads;
    for (var sectionId = 0; sectionId < amountOfThreads; sectionId++) {
      var sectionStart = sectionId * elemsInSection;
      var sectionEnd = (sectionId + 1) * elemsInSection - 1;

      sections[sectionId] = new SearchMinElemInSection(sectionStart, sectionEnd, array, this);
    }

    foreach (var section in sections) new Thread(section.Start).Start();

    return getMinElem();
  }
}

