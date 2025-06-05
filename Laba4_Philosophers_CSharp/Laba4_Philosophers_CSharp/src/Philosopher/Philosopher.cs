namespace Laba4_Philosophers_CSharp.Philosopher;

public class Philosopher
{
  public Table table;
  public int leftForkIdx, rightForkIdx;
  public int idx;
  public bool swapForks;
	
  public Philosopher (int idx, Table table, bool swapForks) {
    this.idx = idx;
    this.table = table;
    this.swapForks = swapForks;
		
    int amountOfForks = table.getAmountForks();
    leftForkIdx = swapForks ? idx : (idx + 1) %  amountOfForks;
    rightForkIdx = swapForks ? (idx + 1) %  amountOfForks : idx;
		
    Console.WriteLine($"Active Philosopher: {idx} [{leftForkIdx} , {rightForkIdx}]");
  }
	
  public string PhilosopherName() {
    return $"Philosopher-{idx}";
  }
}

