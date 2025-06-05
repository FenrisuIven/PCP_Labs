import java.util.concurrent.Semaphore;

public class Table {
	private final Semaphore[] availableForks;
	private final int amountForks;
	
	public Table(int amountForks) {
		availableForks = new Semaphore[amountForks];
		for (int i = 0; i < amountForks; i++) {
			availableForks[i] = new Semaphore(1);
		}
		this.amountForks = amountForks;
	}
	public int getAmountForks() { return amountForks; }
	
	public void takeFork (int idx) {
		try {
			availableForks[idx].acquire();
		} catch (InterruptedException e) {
			throw new RuntimeException(e);
		}
	}
	
	public boolean forkAvailable (int idx) {
		return availableForks[idx].availablePermits() == 1;
	}
	
	public void returnFork (int idx) {
		availableForks[idx].release();
	}
}

