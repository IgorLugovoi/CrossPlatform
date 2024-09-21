namespace Lab
{
    internal class Task
    {
        public static CircularLinkedList<int> arr = new CircularLinkedList<int>();
        public static int n = 7;//n - кількість коробок
        public static int totalStepsCounter = 0;
        public void TaskSolution()
        {
            // Читаємо дані з файлу input.txt
            string[] input = File.ReadAllLines("input.txt");

            // Перший рядок — це кількість коробок
            n = int.Parse(input[0]);

            // Другий рядок — це кульки в коробках
            string[] balls = input[1].Split(' ');

            // Додаємо кульки в круговий список
            foreach (string ball in balls)
            {
                arr.Add(int.Parse(ball));
            }


            // Додаємо кульки в круговий список
            foreach (string ball in balls)
            {
                arr.Add(int.Parse(ball));
            }

            bool balanced = false;
            while (!balanced)
            {
                balanced = true;

                for (int i = 0; i < n; i++)
                {
                    int currentBalls = arr.GetNodeData(i);

                    // Якщо в коробці більше 1 кулі треба змістити кульки
                    if (currentBalls > 1)
                    {
                        balanced = false;  //Треба переносити кульку
                        FindClosestEmptyNode(i);
                    }
                }
            }
            File.WriteAllText("output.txt", $"{totalStepsCounter}");
        }

        private void FindClosestEmptyNode(int currentIndex)
        {
            int nextSteps = FindNextEmptyNode(currentIndex);
            int prevSteps = FindPrevEmptyNode(currentIndex);
            if (nextSteps <= prevSteps)
            {
                Move(currentIndex, nextSteps, true);
            }
            else
            {
                Move(currentIndex, prevSteps, false);
            }
        }
        private static int FindNextEmptyNode(int currentIndex)
        {
            int nextSteps = 0;
            int index = currentIndex;
            do
            {
                index = (index + 1) % n;
                nextSteps++;
            }
            while (arr.GetNodeData(index) != 0 && nextSteps < arr.Count);

            return nextSteps;
        }
        private static int FindPrevEmptyNode(int currentIndex)
        {
            int prevSteps = 0;
            int index = currentIndex;
            do
            {
                index = (index - 1 + n) % n;
                prevSteps++;
            }
            while (arr.GetNodeData(index) != 0 && prevSteps < arr.Count);
            return prevSteps;
        }
        private void Move(int currentIndex, int steps, bool rotation)
        {

            arr.SetNodeData(currentIndex, arr.GetNodeData(currentIndex) - 1);
            if (rotation)
            {
                int newIndex = (currentIndex + steps) % n;
                arr.SetNodeData(newIndex, arr.GetNodeData(newIndex) + 1);
                totalStepsCounter = totalStepsCounter + steps;
            }
            else
            {
                int newIndex = (currentIndex - steps + n) % n;
                arr.SetNodeData(newIndex, arr.GetNodeData(newIndex) + 1);
                totalStepsCounter = totalStepsCounter + steps;
            }
        }
    }
}
