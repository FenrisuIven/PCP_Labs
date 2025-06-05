import java.util.concurrent.Semaphore;

public class Waiter {
	private final Table table;
	
	public Waiter (Table table) {
		this.table = table;
	}
	
	public synchronized void requestForks (Philosopher_Waiter philosopher) {
		try {
			int leftId = philosopher.leftForkIdx;
			int rightId = philosopher.rightForkIdx;
			while (!table.forkAvailable(leftId) || !table.forkAvailable(rightId)) {
				wait();
			}
			table.takeFork(leftId);
			table.takeFork(rightId);
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
	
	public synchronized void dropForks(Philosopher_Waiter philosopher) {
		table.returnFork(philosopher.leftForkIdx);
		table.returnFork(philosopher.rightForkIdx);
		notifyAll();
	}
}

