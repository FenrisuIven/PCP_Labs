namespace Laba3_Semaphores_CSharp.classes;

public class StorageConsumer
{
  private int itemsAmount;
  private StorageManager manager;
  private int idx;

  public StorageConsumer(StorageManager manager, int itemsAmount, int idx)
  {
    this.itemsAmount = itemsAmount;
    this.manager = manager;
    this.idx = idx;

    new Thread(Start).Start();
  }

  public void Start()
  {
    for (int i = 0; i < itemsAmount; i++)
    {
      manager.getTakeItemPermit();
      manager.getAccessPermit();

      string item = manager.takeItem();
      Console.WriteLine($"{this.ToString().Split('.')[^1]}-{idx} take : {item}");
                
      manager.dropAccessPermit();
      manager.newAddItemPermit();
    }
  }
}