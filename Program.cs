namespace foci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task();
            t.GetData("meccs.txt");
            t.Task2();
            t.Task3();
            t.Task4();
        }
    }
}
