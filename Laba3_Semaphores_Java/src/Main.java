public class Main {
	public static void main (String[] args) {
		Main main = new Main();
		int storageSize = 5;
		int amountItems = 8;
		
		main.starter(storageSize, amountItems, 2);
	}
	
	private void starter(int storageSize, int amountItems, int amountWorkers) {
		StorageManager manager = new StorageManager(storageSize);
		
		new StorageConsumer(manager, amountItems * amountWorkers);
		for(int i = 0; i < amountWorkers; i++) {
			new StorageProducer(manager, amountItems);
		}
	}
}