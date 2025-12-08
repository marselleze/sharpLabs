using Lab2.Library;

namespace Lab2
{
	/// <summary>
	/// Главный класс консольного приложения Lab2.
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
					case "3":
						Task3();
						break;
					case "4":
						Task4();
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
			Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА 2 ===");
			Console.WriteLine("Типы данных в .NET\n");
			Console.WriteLine("1. Калькулятор индекса массы тела (BMI)");
			Console.WriteLine("2. Обработка массива (генерация, min/max, сортировка)");
			Console.WriteLine("3. Анализ средней длины слова");
			Console.WriteLine("4. Демонстрация типов памяти (struct, ref, out, GC)");
			Console.WriteLine("0. Выход");
			Console.Write("\nВыберите задание: ");
		}

		private static void Task1()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 1: Калькулятор индекса массы тела ===\n");

			Console.Write("Введите массу тела (кг): ");

			if (!double.TryParse(Console.ReadLine(), out var weight))
			{
				Console.WriteLine("Ошибка: неверный формат массы.");
				return;
			}

			Console.Write("Введите рост (м): ");

			if (!double.TryParse(Console.ReadLine(), out var height))
			{
				Console.WriteLine("Ошибка: неверный формат роста.");
				return;
			}

			var bmi = BmiCalculator.CalculateBmi(weight, height);
			var category = BmiCalculator.GetBmiCategory(bmi);

			Console.WriteLine($"\nВаш индекс массы тела: {bmi:F2}");
			Console.WriteLine($"Категория: {category}");
		}

		private static void Task2()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 2: Обработка массива ===\n");

			Console.Write("Введите размер массива: ");

			if (!int.TryParse(Console.ReadLine(), out var size) || size <= 0)
			{
				Console.WriteLine("Ошибка: введите положительное целое число.");
				return;
			}

			var array = ArrayProcessor.GenerateRandomArray(size);
			ArrayProcessor.PrintArray(array, "Исходный массив");

			var min = ArrayProcessor.FindMin(array);
			var max = ArrayProcessor.FindMax(array);

			Console.WriteLine($"\nМинимум: {min}");
			Console.WriteLine($"Максимум: {max}");

			ArrayProcessor.BubbleSort(array);
			ArrayProcessor.PrintArray(array, "\nОтсортированный массив");
		}

		private static void Task3()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 3: Анализ средней длины слова ===\n");

			Console.WriteLine("Введите текст для анализа:");
			var text = Console.ReadLine();

			if (!string.IsNullOrWhiteSpace(text))
			{
				var avgLength = TextAnalyzer.CalculateAverageWordLength(text);
				Console.WriteLine($"\nСредняя длина слова: {avgLength:F2} символов");
			}
			else
			{
				Console.WriteLine("Ошибка: текст не может быть пустым.");
			}
		}

		private static void Task4()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 4: Демонстрация типов памяти ===\n");

			var person = new PersonData("Иван", 25);
			Console.WriteLine($"Исходная структура: {person}");

			MemoryTypeDemo.ModifyValueType(person);
			Console.WriteLine($"После ModifyValueType: {person}");

			MemoryTypeDemo.ModifyValueTypeByRef(ref person);
			Console.WriteLine($"После ModifyValueTypeByRef: {person}");

			MemoryTypeDemo.CreatePerson("Мария", 30, out var newPerson);
			Console.WriteLine($"Созданная структура через out: {newPerson}");

			Console.WriteLine("\n--- Демонстрация сборки мусора ---\n");
			MemoryTypeDemo.DemoGarbageCollection();
		}
	}
}
