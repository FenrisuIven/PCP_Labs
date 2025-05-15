import java.util.ArrayList;
import java.util.concurrent.Semaphore;

public class StorageManager {
	private final Semaphore accessPermit = new Semaphore(1);
	private final Semaphore itemAvailable = new Semaphore(0);
	private final Semaphore spotsForNewItems;
	
	public ArrayList<String> storage = new ArrayList<>();
	
	public StorageManager(int storageSize) {
		spotsForNewItems = new Semaphore(storageSize);
	}
	
	public String takeItem () {
		var item = this.storage.get(0);
		this.storage.remove(0);
		return item;
	}
	
	public void addItem(String item) {
		this.storage.add(item);
	}
	
	public void getAccessPermit () {
		try {
			this.accessPermit.acquire();
		} catch (InterruptedException e) {
			throw new RuntimeException(e);
		}
	}
	public void dropAccessPermit () {
		this.accessPermit.release();
	}
	
	public void getTakeItemPermit () {
		try {
			this.itemAvailable.acquire();
		} catch (InterruptedException e) {
			throw new RuntimeException(e);
		}
	}
	public void addNewTakeItemPermit () {
		this.itemAvailable.release();
	}
	
	public void getAddItemPermit() {
		try {
			this.spotsForNewItems.acquire();
		} catch (InterruptedException e) {
			throw new RuntimeException(e);
		}
	}
	
	public void newAddItemPermit() {
		this.spotsForNewItems.release();
	}
}
