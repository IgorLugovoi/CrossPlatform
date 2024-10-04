namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Task1 task = new Task1();
            task.TaskSolution();
        }
    }
}
