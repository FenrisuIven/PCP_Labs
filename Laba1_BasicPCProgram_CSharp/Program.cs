namespace Laba1_BasicPCProgram_CSharp;

class Program {
  static void Main(string[] args) {
    new Thread(new BreakThread(4).Start).Start();
  }
}