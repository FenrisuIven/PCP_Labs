using Laba4_Philosophers_CSharp.Philosopher;

namespace Laba4_Philosophers_CSharp;

public class Waiter {
  private Table table;
  
  public Waiter (Table table) {
    this.table = table;
  }
	
  public void requestForks (Philosopher_Waiter philosopher) {
    int leftId = philosopher.leftForkIdx;
    int rightId = philosopher.rightForkIdx;
    while (!table.forkAvailable(leftId) || !table.forkAvailable(rightId)) {
      lock (philosopher.locker)
      {
        Monitor.Wait(philosopher.locker);
      }
    }
    table.takeFork(leftId);
    table.takeFork(rightId);
  }
	
  public void dropForks(Philosopher_Waiter philosopher) {
    table.returnFork(philosopher.leftForkIdx);
    table.returnFork(philosopher.rightForkIdx);
    lock (philosopher.locker)
    {
      Monitor.Pulse(philosopher.locker);
    }
  }
}