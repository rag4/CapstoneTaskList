using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone___Task_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaskNode> taskList = new List<TaskNode>();

            while (true)
            {
                Console.WriteLine("Welcome to the Task Manager"
                    + "\n1. List tasks"
                    + "\n2. List task for one team member"
                    + "\n3. Add task"
                    + "\n4. Delete task"
                    + "\n5. Edit task"
                    + "\n6. Mark task complete"
                    + "\n7. Quit\n");

                Console.Write("What would you like to do? \t");
                string input = Console.ReadLine();
                int inputNum = int.Parse(input);
                Console.WriteLine();

                if (inputNum == 1)
                {
                    ListTasks(taskList);                    
                }
                if (inputNum == 2)
                {
                    ListPersonTask(taskList);
                }
                else if (inputNum == 3)
                {
                    AddTask(taskList);
                }
                else if (inputNum == 4)
                {
                    DeleteTask(taskList);
                }
                else if (inputNum == 5)
                {
                    EditTask(taskList);
                }
                else if (inputNum == 6)
                {
                    MarkTask(taskList);
                }
                else if (inputNum == 7)
                {
                    break;
                }
                Console.WriteLine();
            }

        }

        private static void ListTasks(List<TaskNode> taskList)
        {
            if (!taskList.Any())
            {
                Console.WriteLine("There are currently no tasks available..");
                return;
            }
            for (int i = 1; i <= taskList.Count(); i++) {
                Console.WriteLine("Task " + i + ".");
                Console.WriteLine(taskList[i-1].Display());
                Console.WriteLine();
            }        
        }

        private static void AddTask(List<TaskNode> taskList)
        {
            Console.WriteLine("ADD TASK:\n");
            Console.Write("Team Member Name: \t");
            string memberName = Console.ReadLine();
            Console.Write("Task Description: \t");
            string description = Console.ReadLine();
            Console.Write("Due Date: \t\t");
            string dueDate = Console.ReadLine();

            TaskNode toAdd = new TaskNode(memberName, description, dueDate);
            taskList.Add(toAdd);
        }
         
        private static void DeleteTask(List<TaskNode> taskList)
        {
            if (!taskList.Any())
            {
                Console.WriteLine("There are currently no tasks available..");
                return;
            }
            Console.Write("Which task would you like to delete (Enter Task #): \t");
            string input = Console.ReadLine();
            int choose = int.Parse(input);
            if(choose < 1 || choose > taskList.Count)
            {
                Console.WriteLine("That Task Number does not exist.");
            }
            else
            {
                Console.Write("\nAre you sure you want to delete Task " + choose + " (Y/N): ");
                input = Console.ReadLine();
                if (input.ToUpper().Equals("Y")){
                    taskList.RemoveAt(choose - 1);
                    Console.WriteLine("\nTask successfully deleted.");
                }
                if (input.ToUpper().Equals("N"))
                {
                    Console.WriteLine("\nProcess aborted.");
                }
            }
        }

        private static void MarkTask(List<TaskNode> taskList)
        {
            if (!taskList.Any())
            {
                Console.WriteLine("There are currently no tasks available..");
                return;
            }
            Console.Write("Which task would you like to mark complete (Enter Task #): \t");
            string input = Console.ReadLine();
            int choose = int.Parse(input);
            if (choose < 1 || choose > taskList.Count)
            {
                Console.WriteLine("That Task Number does not exist.");
            }
            else
            {
                Console.Write("\nAre you sure you want to change status of Task " + choose + " (Y/N): ");
                input = Console.ReadLine();
                if (input.ToUpper().Equals("Y"))
                {
                    taskList.ElementAt(choose - 1).ChangeToComplete();
                    Console.WriteLine("\nTask status changed to COMPLETED.");
                }
                if (input.ToUpper().Equals("N"))
                {
                    Console.WriteLine("\nProcess aborted.");
                }
            }
        }

        private static void EditTask(List<TaskNode> taskList)
        {
            if (!taskList.Any())
            {
                Console.WriteLine("There are currently no tasks available..");
                return;
            }
            Console.Write("Which task would you like to edit (Enter Task #): \t");
            string input = Console.ReadLine();
            int choose = int.Parse(input);
            if (choose < 1 || choose > taskList.Count)
            {
                Console.WriteLine("That Task Number does not exist.");
            }
            else
            {
                Console.Write("\nAre you sure you want to edit Task " + choose + " (Y/N): ");
                input = Console.ReadLine();
                if (input.ToUpper().Equals("Y"))
                {
                    Console.WriteLine("EDIT TASK:\n");
                    Console.Write("Team Member Name: \t");
                    string memberName = Console.ReadLine();
                    Console.Write("Task Description: \t");
                    string description = Console.ReadLine();
                    Console.Write("Due Date: \t\t");
                    string dueDate = Console.ReadLine();

                    taskList.ElementAt(choose - 1).EditContents(memberName, description, dueDate);
                    Console.WriteLine("\nTask saved.");
                }
                if (input.ToUpper().Equals("N"))
                {
                    Console.WriteLine("\nProcess aborted.");
                }
            }
        }

        private static void ListPersonTask(List<TaskNode> taskList)
        {
            if (!taskList.Any())
            {
                Console.WriteLine("There are currently no tasks available..");
                return;
            }
            Console.Write("Who's tasks would you like to view (Enter name): ");
            string memberName = Console.ReadLine();
            int taskCheck = 0;
            for (int i = 1; i <= taskList.Count(); i++)
            {
                if (taskList.ElementAt(i-1).MemberName.Equals(memberName))
                {
                    Console.WriteLine("\n" + taskList[i-1].Display()); 
                    taskCheck++;
                }                
                if (taskCheck == 0)
                {
                    Console.WriteLine("\nThere are no available tasks for member: " + memberName);
                }
            }
        }

    }
}
