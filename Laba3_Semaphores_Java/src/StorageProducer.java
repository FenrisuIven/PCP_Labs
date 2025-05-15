public class StorageProducer implements Runnable {
	private final int itemAmount;
	private final StorageManager manager;
	
	public StorageProducer (StorageManager manager, int itemAmount) {
		this.manager = manager;
		this.itemAmount = itemAmount;
		
		new Thread(this).start();
	}
	
	@Override
	public void run () {
		for (int i = 1; i <= itemAmount; i++) {
			try {
				manager.getAddItemPermit();
				manager.getAccessPermit();
				
				manager.addItem("item " + i + " [ " + this + " ]");
				System.out.println("Added item " + i);

				Thread.sleep(1000);
				manager.dropAccessPermit();
				manager.addNewTakeItemPermit();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
	}
}
