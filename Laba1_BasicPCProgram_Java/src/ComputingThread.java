public class ComputingThread extends Thread {
	public final int id;
	private final int step;
	private final int runDuration;
	private int queuePosition;
	private long startNumber;
	private long sum;
	
	public ComputingThread (int id, long startNumber, int step, int runDuration) {
		this.id = id;
		this.startNumber = startNumber;
		this.step = step;
		this.runDuration = runDuration;
    this.queuePosition = 0;
	}
	
	public int getRunDuration () {
		return runDuration;
	}
	
	@Override
	public void run () {
    int start = (int)startNumber;
		long performedSteps = 0;

		do {
			startNumber += step;
			sum += startNumber;
			performedSteps++;
		} while (!BreakThread.canBreak(queuePosition));

		System.out.println(String.format(" == %1$s ID-%2$d RunDuration: %3$ds Java ===\n step: %4$,d\n startNum: %5$,d\n sum: %6$,d\n steps: %7$,d\n", this, id, runDuration, step, start, sum, performedSteps));
	}

	public int getQueuePosition () {
		return queuePosition;
	}
	
	public void setQueuePosition (int queuePosition) {
		this.queuePosition = queuePosition;
	}
}
