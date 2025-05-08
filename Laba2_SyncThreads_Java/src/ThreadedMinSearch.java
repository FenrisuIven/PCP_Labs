public class ThreadedMinSearch {
	private final int amountOfThreads;
	private final int amountOfElements;
	private final RandomArray array;
	
	private ArrayElement min = new ArrayElement(Integer.MAX_VALUE, -1);
	private int finishedThreadsCount = 0;
	
	public ThreadedMinSearch (int amountOfThreads, int amountOfElements, RandomArray array) {
		this.amountOfThreads = amountOfThreads;
		this.amountOfElements = amountOfElements;
		this.array = array;
	}
	
	synchronized public void setMinElem (ArrayElement newMin){
		if (newMin.element < min.element) {
			this.min = newMin;
		}
	}
	
	private int getFinishedThreadsCount () {
		return finishedThreadsCount;
	}
	
	synchronized public void incThreadCount(){
		finishedThreadsCount++;
		notify();
	}
	
	synchronized private ArrayElement getMinElem () {
		while (getFinishedThreadsCount()< amountOfThreads){
			try {
				wait();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
		return min;
	}
	
	public ArrayElement findMinElem (){
		SearchMinElemInSection[] sections = new SearchMinElemInSection[amountOfThreads];
		
		int elemsInSection = amountOfElements / amountOfThreads;
		for(int sectionId = 0; sectionId < amountOfThreads; sectionId++){
			int sectionStart = sectionId * elemsInSection;
			int sectionEnd = (sectionId + 1) * elemsInSection - 1;
			
			sections[sectionId] = new SearchMinElemInSection(sectionStart, sectionEnd, array, this);
		}
		
		for(SearchMinElemInSection section : sections){
			section.start();
		}
		
		return getMinElem();
	}
}
