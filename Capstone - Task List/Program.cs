using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Capstone___Task_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaskNode> taskList = new List<TaskNode>();             // list of task objects

            while (true)
            {
                Console.WriteLine("Welcome to the Task Manager"         // menu
                    + "\n1. List tasks"
                    + "\n2. List task for one team member"
                    + "\n3. Add task"
                    + "\n4. Delete task"
                    + "\n5. Edit task"
                    + "\n6. Mark task complete"
                    + "\n7. Quit\n");

                Console.Write("What would you like to do? \t");                         // ask user input (number)
                string input = Console.ReadLine();
                bool checkNum = input.Any(char.IsDigit);                                // check if string is numeric
                while (!checkNum)
                {
                    Console.Write("\nIncorrect format. Please enter a number:      ");
                    input = Console.ReadLine();
                    checkNum = input.Any(char.IsDigit);
                }
                int inputNum = int.Parse(input);                
                Console.WriteLine();

                if (inputNum == 1)
                {
                    ListTasks(taskList);                        // list all tasks
                }
                if (inputNum == 2)
                {
                    ListPersonTask(taskList);                   // list one member's task
                }
                else if (inputNum == 3)
                {
                    AddTask(taskList);                          // add task
                }
                else if (inputNum == 4)
                {
                    DeleteTask(taskList);                       // delete task
                }
                else if (inputNum == 5)
                {
                    EditTask(taskList);                         // edit task
                }
                else if (inputNum == 6)
                {
                    MarkTask(taskList);                         // mark task complete
                }
                else if (inputNum == 7)
                {
                    break;                                      // quit
                }
                else if (inputNum < 1 || inputNum > 7)
                {
                    Console.WriteLine("\nThis option does not exist.\n");       // ERROR
                }
                Console.WriteLine();
            }

        }

        // Display all elements in list of task objects
        private static void ListTasks(List<TaskNode> taskList)
        {
            Console.WriteLine("*****LIST*****\n");
            if (!taskList.Any())
            {
                Console.WriteLine("There are currently no tasks available..");
                Console.WriteLine("\n*****LIST*****\n");
                return;
            }
            for (int i = 1; i <= taskList.Count(); i++) {
                Console.WriteLine("Task " + i + ".");
                Console.WriteLine(taskList[i-1].Display());
                Console.WriteLine();
            }
            Console.WriteLine("\n*****LIST*****\n");
        }

        // Create and Add a new task objects to the list
        private static void AddTask(List<TaskNode> taskList)
        {
            Console.WriteLine("*****ADD*****\n");
            Console.Write("Team Member Name: \t");
            string memberName = Console.ReadLine();
            Console.Write("Task Description: \t");
            string description = Console.ReadLine();
            Console.Write("Due Date: \t\t");
            string dueDate = Console.ReadLine();
            bool checkFlag = Regex.IsMatch(dueDate, @"^\d\d\/\d\d\/\d\d\d\d$");
            while (checkFlag == false)
            {
                Console.Write("Incorrect format. Try again (##/##/####): \t");
                dueDate = Console.ReadLine();
                checkFlag = Regex.IsMatch(dueDate, @"^\d\d/\d\d/\d\d\d\d$");
            }

            TaskNode toAdd = new TaskNode(memberName, description, dueDate);
            taskList.Add(toAdd);
            Console.WriteLine("\n*****ADD*****\n");
        }

        // Delete a task by task number
        private static void DeleteTask(List<TaskNode> taskList)
        {
            Console.WriteLine("*****DELETE*****\n");
            if (!taskList.Any())
            {
                Console.WriteLine("There are currently no tasks available..");
                Console.WriteLine("\n*****DELETE*****\n");
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
            Console.WriteLine("\n*****DELETE*****\n");
        }

        // Mark a task complete by task number
        private static void MarkTask(List<TaskNode> taskList)
        {
            Console.WriteLine("*****MARK*****\n");
            if (!taskList.Any())
            {
                Console.WriteLine("There are currently no tasks available..");
                Console.WriteLine("\n*****MARK*****\n");
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
            Console.WriteLine("\n*****MARK*****\n");
        }

        // Edit an existing task by task number
        private static void EditTask(List<TaskNode> taskList)
        {
            Console.WriteLine("*****EDIT*****\n");
            if (!taskList.Any())
            {
                Console.WriteLine("There are currently no tasks available..");
                Console.WriteLine("\n*****EDIT*****\n");
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
                    Console.Write("Team Member Name: \t");
                    string memberName = Console.ReadLine();
                    Console.Write("Task Description: \t");
                    string description = Console.ReadLine();
                    Console.Write("Due Date: \t\t");
                    string dueDate = Console.ReadLine();
                    bool checkFlag = Regex.IsMatch(dueDate, @"^\d\d\/\d\d\/\d\d\d\d$");
                    while (checkFlag == false)
                    {
                        Console.Write("Incorrect format. Try again (##/##/####): \t");
                        dueDate = Console.ReadLine();
                        checkFlag = Regex.IsMatch(dueDate, @"^\d\d/\d\d/\d\d\d\d$");
                    }

                    taskList.ElementAt(choose - 1).EditContents(memberName, description, dueDate);
                    Console.WriteLine("\nTask saved.");
                }
                if (input.ToUpper().Equals("N"))
                {
                    Console.WriteLine("\nProcess aborted.");
                }
            }
            Console.WriteLine("\n*****EDIT*****\n");
        }

        // Display all elements that match the name the user has inputted
        private static void ListPersonTask(List<TaskNode> taskList)
        {
            Console.WriteLine("*****LIST-MEMBER*****\n");
            if (!taskList.Any())
            {
                Console.WriteLine("There are currently no tasks available..");
                Console.WriteLine("\n*****LIST-MEMBER*****\n");
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
            Console.WriteLine("\n*****LIST-MEMBER*****\n");
        }

    }
}
