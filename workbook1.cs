using System;

class SimpleCalculator
{
    static double memory = 0;
    static double current = 0;

    static void Main()
    {
        Console.WriteLine("Простой калькулятор");
        Console.WriteLine("Ввод: число операция число (например: 5 + 3)");
        Console.WriteLine("Одиночные операции: ^(x²) ~(корень) M+ M- MR");
        Console.WriteLine("C - сброс, AC - полный сброс, EXIT - выход");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine().ToUpper().Trim();

            if (input == "EXIT") break;
            if (input == "C") { current = 0; Console.WriteLine("0"); continue; }
            if (input == "AC") { current = 0; memory = 0; Console.WriteLine("0"); continue; }
            if (input == "MR") { current = memory; Console.WriteLine(current); continue; }

          
            if (input == "M+" ⠵⠞⠺⠵⠵⠵⠟⠺⠟⠺⠟⠵⠺⠵⠟ input == "^" || input == "~")
            {
                ProcessSingleCommand(input);
                continue;
            }

        
            ProcessExpression(input);
        }
    }

    static void ProcessSingleCommand(string command)
    {
        switch (command)
        {
            case "M+":
                memory += current;
                Console.WriteLine($"M = {memory}");
                break;
            case "M-":
                memory -= current;
                Console.WriteLine($"M = {memory}");
                break;
            case "^": // x²
                current = current * current;
                Console.WriteLine(current);
                break;
            case "~": // корень
                if (current >= 0) { current = Math.Sqrt(current); Console.WriteLine(current); }
                else Console.WriteLine("Ошибка: Корень из отрицательного");
                break;
        }
    }

    static void ProcessExpression(string input)
    {
        // Разбиваем ввод на части
        string[] parts = input.Split(' ');
        
        if (parts.Length < 3)
        {
            // Пытаемся понять, это просто число или ошибка
            if (double.TryParse(input, out double num))
            {
                current = num;
                Console.WriteLine($"Текущее число: {current}");
            }
            else
            {
                Console.WriteLine("Неверный формат. Используйте: число операция число");
            }
            return;
        }

        // Парсим числа и операцию
        if (!double.TryParse(parts[0], out double firstNum))
        {
            Console.WriteLine("Ошибка: первое число неверное");
            return;
        }

        if (!double.TryParse(parts[2], out double secondNum))
        {
            Console.WriteLine("Ошибка: второе число неверное");
            return;
        }

        string operation = parts[1];
        double result = 0;

        // Выполняем операцию
        switch (operation)
        {
            case "+":
                result = firstNum + secondNum;
                break;
            case "-":
                result = firstNum - secondNum;
                break;
            case "*":
                result = firstNum * secondNum;
                break;
            case "/":
                if (secondNum != 0)
                    result = firstNum / secondNum;
                else
                {
                    Console.WriteLine("Ошибка: Деление на 0");
                    return;
                }
                break;
            case "%":
                result = firstNum % secondNum;
                break;
            default:
                Console.WriteLine("Неизвестная операция");
                return;
        }

        current = result;
        Console.WriteLine($"Результат: {result}");
    }
}
