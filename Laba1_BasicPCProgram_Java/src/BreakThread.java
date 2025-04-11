import java.util.Arrays;
import java.util.Comparator;
import java.util.Random;
import java.util.stream.Stream;

public class BreakThread extends Thread {
	private static ComputingThreadStatus[] associatedThreads = new ComputingThreadStatus[0];
	
	public BreakThread (int amountThreads) {
    ComputingThread[] threads = new ComputingThread[amountThreads];
    int min = 1;
    int max = 10;
    Random rnd = new Random();

    for (int i = 0; i < amountThreads; i++){
      int step = rnd.nextInt(max - min + 1) + min;
      int runDuration = rnd.nextInt(max - min + 1) + min;
      threads[i] = new ComputingThread(i, 1, step, runDuration);
    }
		ComputingThreadStatus[] threadStatuses = Arrays.stream(threads)
      .map(ComputingThreadStatus::new)
			.sorted(Comparator.comparingInt(ts -> ts.getThread().getRunDuration()))
			.toArray(ComputingThreadStatus[]::new);
		
		for (int i = 0; i < threadStatuses.length; i++) {
			threadStatuses[i].getThread().setQueuePosition(i);
		}
		
		associatedThreads = threadStatuses;
	}
	
	public synchronized static boolean canBreak (int queuePosition) {
		return associatedThreads[queuePosition].isBreak();
	}
	
	@Override
	public void start () {
    long[] endTimestamps = Stream.of(associatedThreads)
    .mapToLong(threadStatus -> System.currentTimeMillis() + threadStatus.getThread().getRunDuration() * 1000)
    .toArray();

		for (ComputingThreadStatus threadStatus : associatedThreads) {
			threadStatus.getThread().start();
		}

		for (int i = 0; i < associatedThreads.length; ) {
			try {
        long sleepTime = (long)(endTimestamps[i] - System.currentTimeMillis());
				if(sleepTime > 0) Thread.sleep(sleepTime);
				associatedThreads[i].setBreak(true);
        i++;
			} catch (Exception e) {
				e.printStackTrace();
        break;
			}
		}
	}
}
