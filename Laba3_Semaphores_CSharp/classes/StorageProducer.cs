namespace Laba3_Semaphores_CSharp.classes;

public class StorageProducer
{
  private int itemsAmount;
  private StorageManager manager;
  private int idx;
	
  public StorageProducer (StorageManager manager, int itemsAmount, int idx) {
    this.manager = manager;
    this.itemsAmount = itemsAmount;
    this.idx = idx;
		
    new Thread(Start).Start();
  }

  public void Start()
  {
    for (int i = 0; i < itemsAmount; i++)
    {
      manager.getAddItemPermit();
      manager.getAccessPermit();

      manager.addItem($"item {i} [ {this.ToString().Split('.')[^1]}-{idx} ]");
      Console.WriteLine($"Added item {i} [ {this.ToString().Split('.')[^1]}-{idx} ]");

      manager.dropAccessPermit();
      manager.addNewTakeItemPermit();
    }
  }
}