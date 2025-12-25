using Lab8.Library;

namespace Lab8
{
	/// <summary>
	/// Главный класс консольного приложения Lab8.
	/// </summary>
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			try
			{
				RunApplication();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		/// <summary>
		/// Запускает основное приложение.
		/// </summary>
		private static void RunApplication()
		{
			var running = true;

			while (running)
			{
				try
				{
					DisplayMenu();
					var choice = Console.ReadLine();

					switch (choice)
					{
						case "1":
							DemonstrateExceptionHandling();
							break;
						case "2":
							DemonstrateNestedExceptions();
							break;
						case "3":
							DemonstrateDateTimeConversion();
							break;
						case "4":
							DemonstrateComplexScenario();
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
				catch (Exception ex)
				{
					throw new ApplicationException("Ошибка при выполнении операции меню.", ex);
				}
			}
		}

		/// <summary>
		/// Обрабатывает все исключения, выводя их на консоль с учетом InnerException.
		/// </summary>
		/// <param name="ex">Исключение для обработки.</param>
		private static void HandleException(Exception ex)
		{
			Console.WriteLine("ОШИБКА ПРОГРАММЫ");

			PrintException(ex, 0);
		}

		/// <summary>
		/// Рекурсивно выводит информацию об исключении и всех внутренних исключениях.
		/// </summary>
		/// <param name="ex">Исключение для вывода.</param>
		/// <param name="level">Уровень вложенности исключения.</param>
		private static void PrintException(Exception ex, int level)
		{
			var indent = new string(' ', level * 2);
			Console.WriteLine($"{indent}Тип исключения: {ex.GetType().Name}");
			Console.WriteLine($"{indent}Сообщение: {ex.Message}");

			if (!string.IsNullOrEmpty(ex.StackTrace))
			{
				Console.WriteLine($"{indent}Стек вызовов:");
				var stackLines = ex.StackTrace.Split('\n');
				foreach (var line in stackLines.Take(5))
				{
					Console.WriteLine($"{indent}  {line.Trim()}");
				}
			}

			if (ex.InnerException != null)
			{
				Console.WriteLine($"{indent}Внутреннее исключение:");
				PrintException(ex.InnerException, level + 1);
			}

			if (level == 0)
			{
				Console.WriteLine("\n========================================");
			}
		}

		/// <summary>
		/// Отображает главное меню.
		/// </summary>
		private static void DisplayMenu()
		{
			Console.Clear();
			Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА 8");
			Console.WriteLine("Обработка исключений и работа с датами\n");
			Console.WriteLine("1. Демонстрация обработки исключений");
			Console.WriteLine("2. Демонстрация вложенных исключений (InnerException)");
			Console.WriteLine("3. Конвертация дат из UTC в локальный часовой пояс");
			Console.WriteLine("4. Комплексный сценарий");
			Console.WriteLine("0. Выход");
			Console.Write("\nВыберите задание: ");
		}

		/// <summary>
		/// Демонстрирует обработку различных типов исключений.
		/// </summary>
		private static void DemonstrateExceptionHandling()
		{
			Console.Clear();
			Console.WriteLine("Задание 1: Демонстрация обработки исключений\n");

			try
			{
				Console.WriteLine("--- Деление на ноль ---");
				var result = DataProcessor.DivideNumbers(10, 0);
				Console.WriteLine($"Результат: {result}");
			}
			catch (DivideByZeroException ex)
			{
				throw new InvalidOperationException("Ошибка при делении чисел.", ex);
			}

			try
			{
				Console.WriteLine("\n--- Парсинг неверной строки ---");
				var number = DataProcessor.ParseInteger("не число");
				Console.WriteLine($"Результат: {number}");
			}
			catch (FormatException ex)
			{
				throw new InvalidOperationException("Ошибка при парсинге числа.", ex);
			}

			try
			{
				Console.WriteLine("\n--- Обращение к несуществующему элементу массива ---");
				var array = new[] { 1, 2, 3 };
				var element = DataProcessor.GetArrayElement(array, 10);
				Console.WriteLine($"Элемент: {element}");
			}
			catch (IndexOutOfRangeException ex)
			{
				throw new InvalidOperationException("Ошибка при обращении к элементу массива.", ex);
			}
		}

		/// <summary>
		/// Демонстрирует работу с вложенными исключениями (InnerException).
		/// </summary>
		private static void DemonstrateNestedExceptions()
		{
			Console.Clear();
			Console.WriteLine("Задание 2: Демонстрация вложенных исключений (InnerException)\n");

			try
			{
				Console.WriteLine("Попытка выполнить операцию с неверным номером:");
				var result = DataProcessor.PerformOperation(99);
				Console.WriteLine(result);
			}
			catch (InvalidOperationException ex)
			{
				throw new ApplicationException("Ошибка выполнения операции в приложении.", ex);
			}

			try
			{
				Console.WriteLine("\nПопытка деления на ноль:");
				var result = DataProcessor.DivideNumbers(100, 0);
				Console.WriteLine($"Результат: {result}");
			}
			catch (DivideByZeroException ex)
			{
				throw new ArithmeticException("Арифметическая ошибка в вычислениях.", ex);
			}

			try
			{
				Console.WriteLine("\nПопытка парсинга очень большого числа:");
				var number = DataProcessor.ParseInteger("999999999999999999999");
				Console.WriteLine($"Результат: {number}");
			}
			catch (OverflowException ex)
			{
				throw new FormatException("Ошибка формата при обработке данных.", ex);
			}
		}

		/// <summary>
		/// Демонстрирует конвертацию дат из UTC в локальный часовой пояс.
		/// </summary>
		private static void DemonstrateDateTimeConversion()
		{
			Console.Clear();
			Console.WriteLine("Задание 3: Конвертация дат из UTC в локальный часовой пояс\n");

			try
			{
				Console.WriteLine(DateTimeConverter.GetTimeZoneInfo());
				Console.WriteLine();

				var utcNow = DateTime.UtcNow;
				Console.WriteLine($"Текущее время UTC: {DateTimeConverter.FormatDateTime(utcNow, true)}");

				var localTime = DateTimeConverter.ConvertFromUtcToLocal(utcNow);
				Console.WriteLine($"Локальное время: {DateTimeConverter.FormatDateTime(localTime, false)}");

				Console.WriteLine("\n--- Конвертация конкретной даты ---");
				var specificUtcDate = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc);
				Console.WriteLine($"UTC дата: {DateTimeConverter.FormatDateTime(specificUtcDate, true)}");

				var convertedLocal = DateTimeConverter.ConvertFromUtcToLocal(specificUtcDate);
				Console.WriteLine($"Локальная дата: {DateTimeConverter.FormatDateTime(convertedLocal, false)}");

				Console.WriteLine("\n--- Обратная конвертация (локальное -> UTC) ---");
				var localDate = new DateTime(2024, 1, 15, 15, 0, 0, DateTimeKind.Local);
				Console.WriteLine($"Локальная дата: {DateTimeConverter.FormatDateTime(localDate, false)}");

				var convertedUtc = DateTimeConverter.ConvertFromLocalToUtc(localDate);
				Console.WriteLine($"UTC дата: {DateTimeConverter.FormatDateTime(convertedUtc, true)}");

				Console.WriteLine("\n--- Конвертация в другой часовой пояс ---");
				var moscowTime = DateTimeConverter.ConvertFromUtcToTimeZone(specificUtcDate, "Russian Standard Time");
				Console.WriteLine($"Московское время: {moscowTime:dd'.'MM'.'yyyy HH:mm:ss}");

				var newYorkTime = DateTimeConverter.ConvertFromUtcToTimeZone(specificUtcDate, "Eastern Standard Time");
				Console.WriteLine($"Время Нью-Йорка: {newYorkTime:dd'.'MM'.'yyyy HH:mm:ss}");
			}
			catch (TimeZoneNotFoundException ex)
			{
				throw new ApplicationException("Ошибка при работе с часовыми поясами.", ex);
			}
			catch (InvalidTimeZoneException ex)
			{
				throw new ApplicationException("Ошибка: неверный часовой пояс.", ex);
			}
			catch (ArgumentException ex)
			{
				throw new ApplicationException("Ошибка при конвертации даты.", ex);
			}
		}

		/// <summary>
		/// Демонстрирует комплексный сценарий с несколькими операциями.
		/// </summary>
		private static void DemonstrateComplexScenario()
		{
			Console.Clear();
			Console.WriteLine("Задание 4: Комплексный сценарий\n");

			try
			{
				Console.WriteLine("--- Сценарий 1: Обработка данных с датами ---");
				var utcDate = DateTime.UtcNow;
				var localDate = DateTimeConverter.ConvertFromUtcToLocal(utcDate);
				Console.WriteLine($"UTC: {DateTimeConverter.FormatDateTime(utcDate, true)}");
				Console.WriteLine($"Local: {DateTimeConverter.FormatDateTime(localDate, false)}");

				Console.WriteLine("\n--- Сценарий 2: Математические операции ---");
				var numbers = new[] { 10.0, 20.0, 30.0 };
				var sum = numbers.Sum();
				var average = DataProcessor.DivideNumbers(sum, numbers.Length);
				Console.WriteLine($"Сумма: {sum}, Среднее: {average}");

				Console.WriteLine("\n--- Сценарий 3: Обработка массива ---");
				for (var i = 0; i < numbers.Length; i++)
				{
					var element = DataProcessor.GetArrayElement(numbers, i);
					Console.WriteLine($"Элемент [{i}]: {element}");
				}

				Console.WriteLine("\n--- Сценарий 4: Парсинг строк ---");
				var validNumber = DataProcessor.ParseInteger("42");
				Console.WriteLine($"Распарсенное число: {validNumber}");
			}
			catch (DivideByZeroException ex)
			{
				throw new ApplicationException("Ошибка в математических операциях.", ex);
			}
			catch (FormatException ex)
			{
				throw new ApplicationException("Ошибка при парсинге данных.", ex);
			}
			catch (IndexOutOfRangeException ex)
			{
				throw new ApplicationException("Ошибка при работе с массивом.", ex);
			}
			catch (ArgumentException ex)
			{
				throw new ApplicationException("Ошибка валидации аргументов.", ex);
			}
		}
	}
}

