namespace Laba3_Semaphores_CSharp.classes;

public class StorageManager
{
  private Semaphore accessPermit;
  private Semaphore itemAvailable;
  private Semaphore spotsForNewItems;
  
  public readonly List<string> storage;
  
  public StorageManager(int storageSize, int amountItems)
  {
    accessPermit = new Semaphore(1, 1);
    itemAvailable = new Semaphore(0, storageSize);
    spotsForNewItems = new Semaphore(storageSize, storageSize);

    storage = new List<string>();
  }
    
  public String takeItem () {
    var item = storage.ElementAt(0);
    storage.RemoveAt(0);
    return item;
  }
	
  public void addItem(String item) {
    storage.Add(item);
  }
	
  public void getAccessPermit () {
    accessPermit.WaitOne();

  }
  public void dropAccessPermit () {
    accessPermit.Release();
  }
	
  public void getTakeItemPermit () {
    itemAvailable.WaitOne();
  }
  public void addNewTakeItemPermit () {
    itemAvailable.Release();
  }
	
  public void getAddItemPermit() {
    spotsForNewItems.WaitOne();
  }
	
  public void newAddItemPermit() {
    spotsForNewItems.Release();
  }
}