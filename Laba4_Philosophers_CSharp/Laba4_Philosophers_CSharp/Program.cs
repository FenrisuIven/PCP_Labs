using Laba4_Philosophers_CSharp.Philosopher;

namespace Laba4_Philosophers_CSharp;

class Program
{
  static void Main(string[] args)
  {
    int amountOfForks = 5;
    Table table = new Table(amountOfForks);
    Waiter waiter = new Waiter(table);
		
    for (int i = 0; i < amountOfForks; i++) {
      new Philosopher_WithoutWaiter(i, table, i == amountOfForks - 1);
      /*new Philosopher_Waiter(i, table, waiter);*/
    }
  }
}