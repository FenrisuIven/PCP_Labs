namespace Laba4_Philosophers_CSharp.Philosopher;

public class Philosopher_WithoutWaiter: Philosopher {
  public Philosopher_WithoutWaiter (int idx, Table table, bool swapForks): base(idx, table, swapForks) {
    new Thread(Starter).Start();
  }
	
  public void Starter() {
    var leftPrefix = swapForks ? " R-" : " L-";
    var rightPrefix = swapForks ? " L-" : " R-";
    int count = 0;
    
    for (int i = 0; i < table.getAmountForks() * 2; i++) {
      table.takeFork(leftForkIdx);
      table.takeFork(rightForkIdx);
      Console.WriteLine($"{PhilosopherName()} took {leftPrefix}{leftForkIdx} {rightPrefix}{rightForkIdx}");
      Thread.Sleep(1300);
				
      Console.WriteLine($"{PhilosopherName()} got to eat {++count} times");
      table.returnFork(leftForkIdx);
      table.returnFork(rightForkIdx);
				
      Thread.Sleep(1000);
    }
    Console.WriteLine($"{PhilosopherName()} finished eating with count {count}");
  }
}

