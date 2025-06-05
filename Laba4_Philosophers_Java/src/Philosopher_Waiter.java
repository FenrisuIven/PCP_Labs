
public class Philosopher_Waiter extends Philosopher {
	private final Waiter waiter;
	
	public Philosopher_Waiter (int idx, Table table, Waiter waiter) {
		super(idx, table, false);
		this.waiter = waiter;
		start();
	}
	
	public void run() {
		int count = 0;
		try {
			for (int i = 0; i < table.getAmountForks() * 2; i++) {
				waiter.requestForks(this);
				Thread.sleep(1000);
				
				System.out.println(PhilosopherName() + " got to eat " + (++count) + " times");
				waiter.dropForks(this);
				Thread.sleep(1000);
			}
			System.out.println(PhilosopherName() + " finished eating with count " + count);
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
}

