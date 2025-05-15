using Laba3_Semaphores_CSharp.classes;

namespace Laba3_Semaphores_CSharp;

class Program
{
  static void Main(string[] args)
  {
    Program program = new Program();
    program.Start(3, 10);
  }

  private void Start(int storageSize, int amountItems)
  {
    StorageManager manager = new StorageManager(storageSize, amountItems);
    new StorageConsumer(manager, amountItems * 4);
    new StorageProducer(manager, amountItems);
    new StorageProducer(manager, amountItems);
    new StorageProducer(manager, amountItems);
    new StorageProducer(manager, amountItems);
  }
}