using Lab1;
using Lab2;
using Lab3;
namespace LabsLibrary
{
    public class LabRunner
    {
        public void RunLab1(string inputFilePath, string outputFilePath)
        {
            Task1 task1 = new Task1();
            int result = task1.TaskSolution();

            File.WriteAllText(outputFilePath, result.ToString());

            Console.WriteLine("Data successfully written to the output file.");
        }

        public void RunLab2(string inputFilePath, string outputFilePath)
        {
            Task2 task2 = new Task2();

            int result = task2.Start();

            File.WriteAllText(outputFilePath, result.ToString());

            Console.WriteLine("Data successfully written to the output file.");
        }

        public void RunLab3(string inputFilePath, string outputFilePath)
        {
            Task3 task3 = new Task3();

            int result = task3.ExecuteTask();

            File.WriteAllText(outputFilePath, result.ToString());

            Console.WriteLine("Data successfully written to the output file.");
        }
    }
}