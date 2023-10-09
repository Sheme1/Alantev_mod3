using System;
using System.Collections.Generic;

// Определение делегата для выполнения задачи
delegate void TaskDelegate(string task);

class TaskManager
{
    // Словарь для хранения делегатов, связанных с задачами
    private Dictionary<string, TaskDelegate> taskDelegates = new Dictionary<string, TaskDelegate>();

    // Метод для добавления задачи и связанного с ней делегата
    public void AddTask(string task, TaskDelegate taskDelegate)
    {
        taskDelegates.Add(task, taskDelegate);
    }

    // Метод для выполнения задачи по её имени
    public void ExecuteTask(string task)
    {
        if (taskDelegates.ContainsKey(task))
        {
            TaskDelegate taskDelegate = taskDelegates[task];
            taskDelegate(task);
        }
        else
        {
            Console.WriteLine($"Задача '{task}' не найдена.");
        }
    }
}

class Program
{
    // Метод для отправки уведомления
    static void Notify(string task)
    {
        Console.WriteLine($"Уведомление: {task}");
    }

    // Метод для записи в журнал
    static void Log(string task)
    {
        Console.WriteLine($"Журнал: {task}");
    }

    static void Main()
    {
        
        try
        {
            TaskManager taskManager = new TaskManager();

            // Пользовательский ввод
            Console.Write("Введите название задачи: ");
            string userTask = Console.ReadLine();
            Console.WriteLine("Выберите делегат");
            Console.WriteLine("1.Отправка уведомления");
            Console.WriteLine("2.Запись в журнал");
            int variant = Convert.ToInt32(Console.ReadLine());
            switch (variant)
            {
                case 1:
                taskManager.AddTask(userTask, Notify);
                    break;
                case 2:
                    taskManager.AddTask(userTask, Log);
                    break;
                default:
                    Console.WriteLine("Делегат не найдем");
                    break;
            }
            
            // Выполнение задачи
            taskManager.ExecuteTask(userTask);

            Console.ReadLine();
        }
        catch
        {
            Console.WriteLine("Введите корректный делегат");
            Main();
        }
    }
}
