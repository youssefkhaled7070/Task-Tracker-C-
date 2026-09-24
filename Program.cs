using System;

namespace TaskTracker
{
    internal class Program
    {
        static string[] tasks = new string[100];
        static int taskCount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

            Console.WriteLine($"Hello, {name}");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1 - Add Task");
                Console.WriteLine("2 - Mark Task as Completed");
                Console.WriteLine("3 - View Tasks");
                Console.WriteLine("4 - Delete Task");
                Console.WriteLine("5 - Exit");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        AddTask();
                        break;

                    case "2":
                        MarkTaskCompleted();
                        break;

                    case "3":
                        ViewTasks();
                        break;

                    case "4":
                        DeleteTask();
                        break;

                    case "5":
                        ExitApplication();
                        break;

                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }
            }
        }

        private static void AddTask()
        {
            if (taskCount >= tasks.Length)
            {
                Console.WriteLine("Task list is full");
                return;
            }

            Console.WriteLine("Enter task description");
            string taskDescription = Console.ReadLine();

            tasks[taskCount] = taskDescription;
            taskCount++;

            Console.WriteLine("Task added successfully");
        }

        private static void MarkTaskCompleted()
        {
            if (taskCount == 0)
            {
                Console.WriteLine("There are no tasks");
                return;
            }

            ViewTasks();

            Console.WriteLine("Enter task number to mark as completed");

            string taskNumberInput = Console.ReadLine();

            int taskNumber = int.Parse(taskNumberInput);

            int index = taskNumber - 1;

            if (index < 0 || index >= taskCount)
            {
                Console.WriteLine("Invalid task number");
                return;
            }

            tasks[index] = tasks[index] + " (Completed)";

            Console.WriteLine("Task marked as completed");
        }

        private static void ViewTasks()
        {
            if (taskCount == 0)
            {
                Console.WriteLine("There are no tasks");
                return;
            }

            Console.WriteLine("Your tasks:");

            for (int i = 0; i < taskCount; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        private static void DeleteTask()
        {
            if (taskCount == 0)
            {
                Console.WriteLine("There are no tasks to delete");
                return;
            }

            ViewTasks();

            Console.WriteLine("Enter task number to delete:");

            string taskNumberInput = Console.ReadLine();

            int taskNumber = int.Parse(taskNumberInput);

            int index = taskNumber - 1;

            if (index < 0 || index >= taskCount)
            {
                Console.WriteLine("Invalid task number");
                return;
            }

            for (int i = index; i < taskCount - 1; i++)
            {
                tasks[i] = tasks[i + 1];
            }

            tasks[taskCount - 1] = null;

            taskCount--;

            Console.WriteLine("Task deleted successfully");
        }

        private static void ExitApplication()
        {
            Console.WriteLine("Exiting application,Goodbye");

            Environment.Exit(0);
        }
    }
}