
public class Philosopher_WithoutWaiter extends Philosopher {
	public Philosopher_WithoutWaiter (int idx, Table table, boolean swapForks) {
		super(idx, table, swapForks);
		start();
	}
	
	public void run() {
		var leftPrefix = swapForks ? " R-" : " L-";
		var rightPrefix = swapForks ? " L-" : " R-";
		int count = 0;
		try {
			for (int i = 0; i < table.getAmountForks() * 2; i++) {
				table.takeFork(leftForkIdx);
				table.takeFork(rightForkIdx);
				System.out.println(PhilosopherName() + " took " + leftPrefix + leftForkIdx + " " + rightPrefix + rightForkIdx);
				Thread.sleep(1300);
				
				System.out.println(PhilosopherName() + " got to eat " + (++count) + " times");
				table.returnFork(leftForkIdx);
				table.returnFork(rightForkIdx);
				Thread.sleep(1000);
			}
			System.out.println(PhilosopherName() + " finished eating with count " + count);
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
}

