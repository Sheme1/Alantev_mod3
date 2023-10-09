using System;
using System.Collections.Generic;
using System.Linq;

// Определение делегата для фильтрации
delegate bool FilterDelegate(string item);

class FilterSystem
{
    // Метод для фильтрации списка с использованием делегата
    public List<string> Filter(List<string> list, FilterDelegate filter)
    {
        return list.Where(item => filter(item)).ToList();
    }
}

class Program
{
    // Фильтр по дате
    static bool DateFilter(string item)
    {
        DateTime date;
        return DateTime.TryParse(item, out date);
    }

    // Фильтр по ключевым словам
    static bool KeywordFilter(string item)
    {
        var keywords = new List<string> { "ключевое слово1", "ключевое слово2" };
        return keywords.Any(keyword => item.Contains(keyword));
    }

    static void Main()
    {
        var list = new List<string>
        {
            "2023-10-03",
            "ключевое слово1",
            "Просто строка",
            "ключевое слово2",
            "2023-10-04"
        };

        var filterSystem = new FilterSystem();

        Console.WriteLine("Фильтрация по дате:");
        var dateFilteredList = filterSystem.Filter(list, DateFilter);
        dateFilteredList.ForEach(Console.WriteLine);

        Console.WriteLine("\nФильтрация по ключевым словам:");
        var keywordFilteredList = filterSystem.Filter(list, KeywordFilter);
        keywordFilteredList.ForEach(Console.WriteLine);
    }
}
