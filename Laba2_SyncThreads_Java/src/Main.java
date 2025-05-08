public class Main {
	public static void main(String[] args) {
	int amountOfElements = 899999999;
		int amountOfThreads = 10;
		
		RandomArray arrClass = new RandomArray(amountOfElements, 40);
		ThreadedMinSearch threadedMinSearch = new ThreadedMinSearch(amountOfThreads, amountOfElements, arrClass);
		
		long startTime = System.currentTimeMillis();
		ArrayElement singleThreadSearchRes = arrClass.findMinElemInSection(0,amountOfElements - 1);
		long endTime = System.currentTimeMillis();
		System.out.printf(" == Single thread search 1:%,d == Java\n res: %d [%,d], elapsed:%d%n",
			amountOfElements,
			singleThreadSearchRes.element,
			singleThreadSearchRes.index,
			endTime - startTime
		);

		startTime = System.currentTimeMillis();
		ArrayElement multiThreadSearchRes = threadedMinSearch.findMinElem();
		endTime = System.currentTimeMillis();
		System.out.printf(" == Multi thread search %d:%,d == Java\n res: %d [%,d], elapsed:%d%n",
			amountOfThreads,
			amountOfElements,
			multiThreadSearchRes.element,
			multiThreadSearchRes.index,
			endTime - startTime
		);
	}
}