namespace Laba3_Semaphores_CSharp.classes;

public class StorageConsumer
{
  private int itemsAmount;
  private StorageManager manager;

  public StorageConsumer(StorageManager manager, int itemsAmount)
  {
    this.itemsAmount = itemsAmount;
    this.manager = manager;

    new Thread(Start).Start();
  }

  public void Start()
  {
    for (int i = 0; i < itemsAmount; i++)
    {
      Thread.Sleep(100);
      manager.getTakeItemPermit();
      manager.getAccessPermit();

      string item = manager.takeItem();
      Console.WriteLine($"{this} : " + item);
                
      manager.dropAccessPermit();
      manager.newAddItemPermit();
    }
  }
}