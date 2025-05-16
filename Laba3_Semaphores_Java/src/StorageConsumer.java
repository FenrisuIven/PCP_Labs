public class StorageConsumer implements Runnable {
	private final int itemsAmount;
	private final StorageManager manager;
	
	public StorageConsumer (StorageManager manager, int itemsAmount) {
		this.manager = manager;
		this.itemsAmount = itemsAmount;
		
		new Thread(this).start();
	}
	
	@Override
	public void run () {
		for (int i = 0; i < itemsAmount; i++) {
			String item;
			try {
				Thread.sleep(100);
				manager.getTakeItemPermit();
				manager.getAccessPermit();
				
				item = manager.takeItem();
				System.out.println(this + " take : " + item);
				
				manager.dropAccessPermit();
				manager.newAddItemPermit();
			}
			catch (Exception e) {
				e.printStackTrace();
			}
		}
	}
}
