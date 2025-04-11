public class ComputingThread {
  private int _id;
  public int id {
    get { return _id; }
  }
	private double step;
	private double startNumber;
	private double sum;
  private int _queueNumber;
  public int queueNumber{
    get { return _queueNumber; }
    set { _queueNumber = value; }
  }
  private int _runDuration;
  public int runDuration {
    get { return _runDuration; }
  }

  public ComputingThread(int id, long startNumber, double step, int runDuration) {
    this._id = id;
		this.startNumber = startNumber;
		this.step = step;
		this._runDuration = runDuration;
    this._queueNumber = 0;
  }

  public void Start() {
    int start = (int)startNumber;

		long performedSteps = 0;
		do {
			startNumber += step;
			sum += startNumber;
			performedSteps++;
		} while (!BreakThread.canBreak(queueNumber));
		
		Console.WriteLine($" == {this} ID-{id} RunDuration: {runDuration}s C# ===\n" 
                    + $" step: {step}\n startNum: {start}\n"
                    + $" sum: {($"{sum:N0}").Replace(",", " ")}\n" 
                    + $" steps: {($"{performedSteps:N0}").Replace(",", " ")}\n");
  }
}