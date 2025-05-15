namespace Laba3_Semaphores_CSharp.classes;

public class StorageProducer
{
  private int itemsAmount;
  private StorageManager manager;
	
  public StorageProducer (StorageManager manager, int itemsAmount) {
    this.manager = manager;
    this.itemsAmount = itemsAmount;
		
    new Thread(Start).Start();
  }

  public void Start()
  {
    for (int i = 0; i < itemsAmount; i++)
    {
      manager.getAddItemPermit();
      manager.getAccessPermit();

      manager.addItem("item " + i);
      Console.WriteLine("Added item " + i);

      Thread.Sleep(1000);
      manager.dropAccessPermit();
      manager.addNewTakeItemPermit();
    }
  }
}