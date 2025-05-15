public class Main {
	public static void main (String[] args) {
		Main main = new Main();
		int storageSize = 4;
		int amountItems = 12;
		
		main.starter(storageSize, amountItems);
	}
	
	private void starter(int storageSize, int amountItems) {
		StorageManager manager = new StorageManager(storageSize);
		
		new StorageConsumer(manager, amountItems);
		new StorageProducer(manager, amountItems / 2);
		new StorageProducer(manager, amountItems / 2);
	}
}