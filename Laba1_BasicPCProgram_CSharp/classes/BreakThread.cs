public class BreakThread {
	private static List<ComputingThreadStatus> associatedThreads = [];
	
	public BreakThread (int amountThreads) {
    ComputingThread[] threads = new ComputingThread[amountThreads];
    int min = 1;
    int max = 10;
    Random rnd = new Random();

    for (int i = 0; i < amountThreads; i++){
      int step = rnd.Next(max - min + 1) + min;
      int runDuration = rnd.Next(max - min + 1) + min;
      threads[i] = new ComputingThread(i, 1, step, runDuration);
    }

		var threadStatuses = threads.Select(thread => new ComputingThreadStatus(thread)).ToList();
		threadStatuses.Sort((t1, t2) => t1.thread.runDuration.CompareTo(t2.thread.runDuration));
    
		associatedThreads = threadStatuses.Select((threadStatus, idx) => {
      threadStatus.thread.queueNumber = idx;
      return threadStatus;
    }).ToList();
	}
	
	public static bool canBreak (int queueNumber) {
		return associatedThreads[queueNumber].canBreak;
	}
	
	public void Start () {
		List<DateTime> endTimestamps = associatedThreads.Select(threadStatus => {
			return DateTime.Now.Add(TimeSpan.FromSeconds(threadStatus.thread.runDuration));
		}).ToList();

    for (int i = 0; i < endTimestamps.Count; i++){
      new Thread(associatedThreads[i].thread.Start).Start();
    }
		
		int idx = 0;
		while (DateTime.Now < endTimestamps[associatedThreads.Count - 1]) {
			int sleepTime = (int)Math.Floor((endTimestamps[idx] - DateTime.Now).TotalMilliseconds);
			
      try {
				if (sleepTime > 0) {
					Thread.Sleep(sleepTime);
				}
        associatedThreads[idx].canBreak = true;
				idx++;
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}
	}
}
