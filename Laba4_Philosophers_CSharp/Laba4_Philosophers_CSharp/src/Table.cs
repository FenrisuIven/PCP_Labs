namespace Laba4_Philosophers_CSharp;

public class Table {
  private SemaphoreSlim[] availableForks;
  private int amountForks;
	
  public Table(int amountForks) {
    availableForks = new SemaphoreSlim[amountForks];
    for (int i = 0; i < amountForks; i++) {
      availableForks[i] = new SemaphoreSlim(1, 1);
    }
    this.amountForks = amountForks;
  }
  public int getAmountForks() { return amountForks; }
	
  public void takeFork (int idx) {
    availableForks[idx].Wait();
  }
	
  public bool forkAvailable (int idx) {
    return availableForks[idx].CurrentCount == 1;
  }
	
  public void returnFork (int idx) {
    availableForks[idx].Release();
  }
}

