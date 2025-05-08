using System.Diagnostics;
using Laba2_SyncThreads_CSharp.classes;

namespace Laba2_SyncThreads_CSharp;

internal class Program
{
  private static void Main(string[] args)
  {
    var amountOfElements = 899999999;
    var amountOfThreads = 2;

    var array = new RandomArray(amountOfElements, 40);
    var threadedMinSearch = new ThreadedMinSearch(amountOfThreads, amountOfElements, array);

    var timer = new Stopwatch();

    timer.Start();
    var singleThreadSearchRes = array.findMinElemInSection(0, amountOfElements - 1);
    timer.Stop();
    Console.WriteLine(
        $" == Single thread search 1:{amountOfElements:N0} == CSharp\n res: {singleThreadSearchRes.element}[{singleThreadSearchRes.index:N0}], elapsed:{timer.ElapsedMilliseconds}");

    timer.Reset();
    timer.Start();
    var multiThreadSearchRes = threadedMinSearch.findMinElem();
    timer.Stop();
    Console.WriteLine(
        $" == Multi thread search {amountOfThreads}:{amountOfElements:N0} == CSharp\n res: {multiThreadSearchRes.element}[{multiThreadSearchRes.index:N0}], elapsed:{timer.ElapsedMilliseconds}");
  }
}