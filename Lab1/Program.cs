using Lab1Library;

namespace Lab1
{
	/// <summary>
	/// Точка входа в приложение лабораторной работы №1.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Главный метод программы.
		/// </summary>
		private static void Main()
		{
			Console.WriteLine("Лабораторная работа №1");
			Console.WriteLine();

			ProcessNumberSequence();
			Console.WriteLine();

			ProcessSquare();
		}

		/// <summary>
		/// Обрабатывает запрос пользователя на формирование последовательности чисел.
		/// </summary>
		private static void ProcessNumberSequence()
		{
			Console.WriteLine("Задача 1: Формирование строки вида 1, 2, 3, ... N");
			Console.Write("Введите положительное число N: ");

			var input = Console.ReadLine();

			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Ошибка: значение не может быть пустым.");
				return;
			}

			if (!int.TryParse(input, out var n))
			{
				Console.WriteLine("Ошибка: введено не число.");
				return;
			}

			try
			{
				var result = StringFormatter.FormatNumberSequence(n);
				Console.WriteLine($"Результат: {result}");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}

		/// <summary>
		/// Обрабатывает запрос пользователя на вывод квадрата из звёздочек.
		/// </summary>
		private static void ProcessSquare()
		{
			Console.WriteLine("Задача 2: Вывод квадрата из звёздочек с пустым центром");
			Console.Write("Введите положительное нечётное число N: ");

			var input = Console.ReadLine();

			if (string.IsNullOrEmpty(input))
			{
				Console.WriteLine("Ошибка: значение не может быть пустым.");
				return;
			}

			if (!int.TryParse(input, out var n))
			{
				Console.WriteLine("Ошибка: введено не число.");
				return;
			}

			try
			{
				var result = SquarePrinter.CreateSquareWithEmptyCenter(n);
				Console.WriteLine("Результат:");
				Console.WriteLine(result);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}
	}
}

