namespace Laba4_Philosophers_CSharp.Philosopher;

public class Philosopher_Waiter: Philosopher
{
  private Waiter waiter;
  public Object locker = new();
	
  public Philosopher_Waiter (int idx, Table table, Waiter waiter) : base(idx, table, false) {
    this.waiter = waiter;
    new Thread(Starter).Start();
  }
  
  public void Starter() {
    int count = 0;
    
    for (int i = 0; i < 2; i++) {
      waiter.requestForks(this);
      Thread.Sleep(1000);
				
      Console.WriteLine($"{PhilosopherName()} got to eat {++count} times");
      waiter.dropForks(this);
      Thread.Sleep(1000);
    }
    Console.WriteLine($"{PhilosopherName()} finished eating with count {count}");
  }
}

