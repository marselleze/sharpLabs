using Lab1.Library;

namespace Lab1
{
	/// <summary>
	/// Главный класс консольного приложения Lab1.
	/// </summary>
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			var running = true;

			while (running)
			{
				DisplayMenu();
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						Task1();
						break;
					case "2":
						Task2();
						break;
					case "0":
						running = false;
						Console.WriteLine("До свидания!");
						break;
					default:
						Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
						break;
				}

				if (running)
				{
					Console.WriteLine("\nНажмите любую клавишу для продолжения...");
					Console.ReadKey();
				}
			}
		}

		private static void DisplayMenu()
		{
			Console.Clear();
			Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА 1 ===");
			Console.WriteLine("Использование среды разработки\n");
			Console.WriteLine("1. Форматирование числовой последовательности");
			Console.WriteLine("2. Вывод квадрата из звездочек");
			Console.WriteLine("0. Выход");
			Console.Write("\nВыберите задание: ");
		}

		private static void Task1()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 1: Форматирование числовой последовательности ===\n");

			Console.Write("Введите значение N: ");

			if (int.TryParse(Console.ReadLine(), out var n) && n > 0)
			{
				var result = StringFormatter.FormatNumberSequence(n);
				Console.WriteLine($"\nРезультат: {result}");
			}
			else
			{
				Console.WriteLine("Ошибка: введите положительное целое число.");
			}
		}

		private static void Task2()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 2: Вывод квадрата из звездочек ===\n");

			Console.Write("Введите размер квадрата N: ");

			if (int.TryParse(Console.ReadLine(), out var n) && n > 0)
			{
				Console.WriteLine();
				SquarePrinter.PrintSquare(n);
			}
			else
			{
				Console.WriteLine("Ошибка: введите положительное целое число.");
			}
		}
	}
}
