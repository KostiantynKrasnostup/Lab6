using System; 
using System.Threading; 

class Program
{
    // Масив для зберігання 10 випадкових чисел
    static int[] numbers = new int[10]; 
    static Random random = new Random(); 

    static void Main(string[] args)
    {
        // Генерація випадкових чисел у діапазоні від 0 до 25
        InitializeArray(); 

        // Виводимо згенеровані числа на консоль
        DisplayNumbers(); 

        // Створення потоків для обробки чисел
        Thread threadT0 = new Thread(CountNumbersGreaterThanTen); // Потік для підрахунку чисел, більших за 10
        Thread threadT1 = new Thread(CountEvenNumbers); // Потік для підрахунку парних чисел

        // Запуск потоків
        threadT0.Start(); 
        threadT1.Start(); 

        // Чекаємо, поки обидва потоки завершать свою роботу
        threadT0.Join(); 
        threadT1.Join(); 
    }

    // // Метод для ініціалізації масиву випадковими числами
    static void InitializeArray()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(0, 26); // Генерація чисел від 0 до 25
        }
    }

    // Метод для виведення згенерованих чисел на консоль
    static void DisplayNumbers()
    {
        Console.WriteLine("Згенеровані числа: " + string.Join(", ", numbers)); 
    }

    // Метод для підрахунку чисел, більших за 10
    static void CountNumbersGreaterThanTen()
    {
        int count = 0; // Лічильник для чисел, більших за 10
        foreach (int number in numbers) // Проходимо по кожному числу в масиві
        {
            if (number > 10) // Перевіряємо, чи число більше 10
            {
                count++; // Збільшуємо лічильник
            }
        }
        Console.WriteLine($"Кількість чисел, більших за 10: {count}"); // Виводимо результат
    }

    // Метод для підрахунку парних чисел
    static void CountEvenNumbers()
    {
        int count = 0; // Лічильник для парних чисел
        foreach (int number in numbers) // Проходимо по кожному числу в масиві
        {
            if (number % 2 == 0) // Перевіряємо, чи число парне
            {
                count++; // Збільшуємо лічильник
            }
        }
        Console.WriteLine($"Кількість парних чисел: {count}"); // Виводимо результат
    }
}