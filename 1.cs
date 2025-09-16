using System;

class SimpleCalculator
{
    static double memory = 0;
    static double current = 0;

    static void Main()
    {
        Console.WriteLine("Простой калькулятор");
        Console.WriteLine("Операции: + - * / % #(1/x) ^(x²) ~(корень) M+ M- MR");
        Console.WriteLine("C - сброс, AC - полный сброс, EXIT - выход");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine().ToUpper().Trim();

            if (input == "EXIT") break;
            if (input == "C") { current = 0; Console.WriteLine("0"); continue; }
            if (input == "AC") { current = 0; memory = 0; Console.WriteLine("0"); continue; }
            if (input == "MR") { current = memory; Console.WriteLine(current); continue; }

            if (double.TryParse(input, out double num))
            {
                current = num;
                continue;
            }

            switch (input)
            {
                case "M+":
                    memory += current;
                    Console.WriteLine($"M = {memory}");
                    break;
                case "M-":
                    memory -= current;
                    Console.WriteLine($"M = {memory}");
                    break;
                case "#": // 1/x
                    if (current != 0) { current = 1 / current; Console.WriteLine(current); }
                    else Console.WriteLine("Ошибка: Деление на 0");
                    break;
                case "^": // x²
                    current *= current;
                    Console.WriteLine(current);
                    break;
                case "~": // корень
                    if (current >= 0) { current = Math.Sqrt(current); Console.WriteLine(current); }
                    else Console.WriteLine("Ошибка: Корень из отрицательного");
                    break;
                case "+": case "-": case "*": case "/": case "%":
                    Calculate(input);
                    break;
                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }
        }
    }

    static void Calculate(string operation)
    {
        Console.Write("Введите число: ");
        if (!double.TryParse(Console.ReadLine(), out double num2))
        {
            Console.WriteLine("Ошибка: Не число");
            return;
        }

        switch (operation)
        {
            case "+": current += num2; break;
            case "-": current -= num2; break;
            case "*": current *= num2; break;
            case "/":
                if (num2 != 0) current /= num2;
                else { Console.WriteLine("Ошибка: Деление на 0"); return; }
                break;
            case "%": current %= num2; break;
        }

        Console.WriteLine(current);
    }
}
