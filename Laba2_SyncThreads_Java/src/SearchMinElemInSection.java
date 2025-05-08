public class SearchMinElemInSection extends Thread{
	private final int startIndex;
	private final int finishIndex;
	private final RandomArray array;
	private final ThreadedMinSearch targetSearch;
	
	public SearchMinElemInSection(int startIndex, int finishIndex, RandomArray array, ThreadedMinSearch targetSearch) {
		this.startIndex = startIndex;
		this.finishIndex = finishIndex;
		this.array = array;
		this.targetSearch = targetSearch;
	}
	
	public void run() {
		ArrayElement minElemInSection = array.findMinElemInSection(startIndex, finishIndex);
		targetSearch.setMinElem(minElemInSection);
		targetSearch.incThreadCount();
	}
}


