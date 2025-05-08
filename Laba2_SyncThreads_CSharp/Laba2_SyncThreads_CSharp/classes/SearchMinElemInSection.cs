namespace Laba2_SyncThreads_CSharp.classes;

public class SearchMinElemInSection {
  private RandomArray array;
  private int finishIndex;
  private int startIndex;
  private ThreadedMinSearch targetSearch;

  public SearchMinElemInSection(int startIndex, int finishIndex, RandomArray arrClass, ThreadedMinSearch targetSearch) {
    this.startIndex = startIndex;
    this.finishIndex = finishIndex;
    array = arrClass;
    this.targetSearch = targetSearch;
  }

  public void Start() {
    var minElemInSection = array.findMinElemInSection(startIndex, finishIndex);
    targetSearch.setMinElem(minElemInSection);
    targetSearch.incThreadCount();
  }
}

