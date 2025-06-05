public class Main {
	public static void main (String[] args) {
		int amountOfForks = 10;
		Table table = new Table(amountOfForks);
		Waiter waiter = new Waiter(table);
		
		for (int i = 0; i < amountOfForks; i++) {
			new Philosopher_WithoutWaiter(i, table, i == amountOfForks - 1);
//			new Philosopher_Waiter(i, table, waiter);
		}
	}
}