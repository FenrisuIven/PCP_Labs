public class ComputingThreadStatus {
	private final ComputingThread thread;
	private boolean canBreak;
	
	public ComputingThreadStatus (ComputingThread thread) {
		this.thread = thread;
		canBreak = false;
	}
	
	public ComputingThread getThread () {
		return thread;
	}
	
	
	public boolean isBreak () {
		return canBreak;
	}
	
	public void setBreak (boolean breakStatus) {
		canBreak = breakStatus;
	}
}
