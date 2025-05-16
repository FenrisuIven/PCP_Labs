using Laba3_Semaphores_CSharp.classes;

namespace Laba3_Semaphores_CSharp;

class Program
{
  static void Main(string[] args)
  {
    Program program = new Program();
    program.Start(5, 8, 3);
  }

  private void Start(int storageSize, int amountItems, int amountWorkers)
  {
    StorageManager manager = new StorageManager(storageSize, amountItems);
    
    new StorageConsumer(manager, amountItems * amountWorkers, 0);
    for (int i = 0; i < amountWorkers; i++) {
      new StorageProducer(manager, amountItems, i);
    }
  }
}