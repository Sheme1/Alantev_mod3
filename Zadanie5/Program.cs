using System;

// Делегат для метода сортировки
delegate void SortDelegate(int[] arr);

class SortingManager
{
    // Метод сортировки пузырьком
    public void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 1; i < n; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    int temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }

    // Метод быстрой сортировки
    public void QuickSort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    private void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    private int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;    
        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;
        return i + 1;
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Пользователь вводит числа для сортировки через пробел
        Console.WriteLine("Введите числа для сортировки (разделители - пробел):");
        string input = Console.ReadLine();
        string[] inputArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] numbers = new int[inputArray.Length];
        for (int i = 0; i < inputArray.Length; i++)
        {
            // Парсинг введенных чисел
            if (int.TryParse(inputArray[i], out int number))
            {
                numbers[i] = number;
            }
            else
            {
                Console.WriteLine("Некорректный ввод числа.");
                return;
            }
        }

        // Создание объекта SortingManager для управления сортировкой
        SortingManager sortingManager = new SortingManager();

        while (true)
        {
            // Пользователь выбирает метод сортировки
            Console.WriteLine("Выберите метод сортировки:");
            Console.WriteLine("1. Сортировка пузырьком");
            Console.WriteLine("2. Быстрая сортировка");
            Console.WriteLine("3. Выход");

            string choice = Console.ReadLine();

            if (choice == "3")
            {
                break; // Выход из программы
            }

            SortDelegate sortMethod = null;

            switch (choice)
            {
                case "1":
                    sortMethod = sortingManager.BubbleSort; // Установка делегата на метод сортировки пузырьком
                    break;
                case "2":
                    sortMethod = sortingManager.QuickSort; // Установка делегата на метод быстрой сортировки
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите метод сортировки из списка.");
                    break;
            }

            if (sortMethod != null)
            {
                int[] sortedNumbers = new int[numbers.Length];
                Array.Copy(numbers, sortedNumbers, numbers.Length);
                sortMethod(sortedNumbers); // Выполнение выбранной сортировки с использованием делегата

                Console.WriteLine("Отсортированный массив:");
                foreach (int num in sortedNumbers)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
        }
    }
}
