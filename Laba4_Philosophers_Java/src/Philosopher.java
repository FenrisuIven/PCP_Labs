
public class Philosopher extends Thread  {
	public final Table table;
	public final int leftForkIdx, rightForkIdx;
	public final int idx;
	public final boolean swapForks;
	
	public Philosopher (int idx, Table table, boolean swapForks) {
		this.idx = idx;
		this.table = table;
		this.swapForks = swapForks;
		
		int amountOfForks = table.getAmountForks();
		leftForkIdx = swapForks ? idx : (idx + 1) %  amountOfForks;
		rightForkIdx = swapForks ? (idx + 1) %  amountOfForks : idx;
		
		System.out.println("Active Philosopher: " + idx + "[" + leftForkIdx + " , " + rightForkIdx + "]");
	}
	
	public String PhilosopherName() {
		return "Philosopher-" + idx;
	}
}

