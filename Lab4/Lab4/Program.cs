using Lab4.Library;

namespace Lab4
{
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
						Console.WriteLine("Неверный выбор.");
						break;
				}

				if (running)
				{
					Console.WriteLine("\nНажмите любую клавишу...");
					Console.ReadKey();
				}
			}
		}

		private static void DisplayMenu()
		{
			Console.Clear();
			Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА 4 ===");
			Console.WriteLine("Делегаты и события\n");
			Console.WriteLine("1. Сортировка массива через делегат");
			Console.WriteLine("2. Сортировка с событиями (GenericArraySorter)");
			Console.WriteLine("3. Демонстрация событий (OperationNotifier)");
			Console.WriteLine("4. Демонстрация лямбда-выражений");
			Console.WriteLine("0. Выход");
			Console.Write("\nВыберите задание: ");
		}

		private static void Task1()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 1: Сортировка через делегат ===\n");

			var numbers = new[] { 64, 34, 25, 12, 22, 11, 90 };
			Console.WriteLine($"Исходный массив: [{string.Join(", ", numbers)}]");

			ComparisonDelegate<int> comparer = (a, b) => a.CompareTo(b);
			ArraySorter.Sort(numbers, comparer);

			Console.WriteLine($"Отсортированный: [{string.Join(", ", numbers)}]");
		}

		private static void Task2()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 2: Сортировка с событиями ===\n");

			var numbers = new[] { 64, 34, 25, 12, 22, 11, 90, 88, 45, 50 };
			Console.WriteLine($"Исходный: [{string.Join(", ", numbers)}]");

			var sorter = new GenericArraySorter<int>();
			sorter.SortProgress += (sender, e) =>
			{
				Console.WriteLine($"Прогресс: {e.ProgressPercentage}%, Сравнений: {e.ComparisonsCount}");
			};
			sorter.SortCompleted += (sender, e) =>
			{
				Console.WriteLine("\n✓ Сортировка завершена!");
			};

			ComparisonDelegate<int> comparer = (a, b) => a.CompareTo(b);
			sorter.Sort(numbers, comparer);

			Console.WriteLine($"\nОтсортированный: [{string.Join(", ", numbers)}]");
		}

		private static void Task3()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 3: Демонстрация событий ===\n");

			var notifier = new OperationNotifier();
			notifier.OperationStarting += (sender, e) =>
			{
				Console.WriteLine($"[{e.Timestamp:HH:mm:ss}] ▶ Начало: {e.OperationName}");
			};
			notifier.OperationCompleted += (sender, e) =>
			{
				Console.WriteLine($"[{e.Timestamp:HH:mm:ss}] ✓ Завершено: {e.OperationName}");
			};

			notifier.ExecuteOperation("Расчет данных", () =>
			{
				Console.WriteLine("  ... выполняется ...");
				System.Threading.Thread.Sleep(500);
			});
		}

		private static void Task4()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 4: Демонстрация лямбда-выражений ===\n");

			DelegateExamples.DemonstrateAction();
			Console.WriteLine();
			DelegateExamples.DemonstrateFunc();
			Console.WriteLine();
			DelegateExamples.DemonstrateLambda();
		}
	}
}
