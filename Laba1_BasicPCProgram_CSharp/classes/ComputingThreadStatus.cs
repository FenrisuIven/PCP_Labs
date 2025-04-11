public class ComputingThreadStatus {
	private ComputingThread _thread;
	private bool _canBreak;

public ComputingThread thread {
  get {
    return _thread;
  }
}
  public bool canBreak {
    get {
      return _canBreak;
    }
    set {
      _canBreak = value;
    }
  }
	
	public ComputingThreadStatus (ComputingThread thread) {
		this._thread = thread;
		this._canBreak = false;
	}
}
