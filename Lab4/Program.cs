using Lab4Library;

namespace Lab4
{
	/// <summary>
	/// Точка входа в приложение лабораторной работы №4.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Главный метод программы.
		/// </summary>
		private static void Main()
		{
			Console.WriteLine("Лабораторная работа №4");
			Console.WriteLine();

			DemonstrateSorter();
			Console.WriteLine();

			DemonstrateDelegatesAndEvents();
			Console.WriteLine();

			DemonstrateLambdas();
		}

		/// <summary>
		/// Демонстрирует работу универсального сортировщика с делегатом сравнения и событием завершения сортировки.
		/// </summary>
		private static void DemonstrateSorter()
		{
			Console.WriteLine("=== Демонстрация универсального сортировщика ===");

			var numbers = new[] { 5, 3, 8, 1, 4 };
			var sorter = new GenericArraySorter<int>();
			sorter.SortCompleted += OnSortCompleted;

			Console.WriteLine($"Исходный массив: {string.Join(", ", numbers)}");

			// Сортировка по возрастанию с использованием делегата и лямбда-выражения.
			sorter.Sort(numbers, (x, y) => x > y);
			Console.WriteLine($"После сортировки по возрастанию: {string.Join(", ", numbers)}");

			// Сортировка по убыванию с использованием отдельного метода сравнения.
			sorter.Sort(numbers, CompareDescending);
			Console.WriteLine($"После сортировки по убыванию: {string.Join(", ", numbers)}");
		}

		/// <summary>
		/// Обработчик события завершения сортировки.
		/// </summary>
		/// <param name="sender">Источник события.</param>
		/// <param name="e">Аргументы события.</param>
		private static void OnSortCompleted(object? sender, SortCompletedEventArgs e)
		{
			Console.WriteLine($"Сортировка завершена. Количество сравнений: {e.ComparisonsCount}, количество обменов: {e.SwapsCount}.");
		}

		/// <summary>
		/// Метод сравнения для сортировки по убыванию.
		/// </summary>
		/// <param name="x">Первый элемент.</param>
		/// <param name="y">Второй элемент.</param>
		/// <returns>true, если первый элемент должен идти раньше второго; иначе false.</returns>
		private static bool CompareDescending(int x, int y)
		{
			return x < y;
		}

		/// <summary>
		/// Демонстрирует работу дополнительных делегатов и событий.
		/// </summary>
		private static void DemonstrateDelegatesAndEvents()
		{
			Console.WriteLine("=== Демонстрация делегатов и событий ===");

			var notifier = new OperationNotifier();

			notifier.OperationStarted += () =>
			{
				Console.WriteLine("Событие без аргументов: операция начата.");
			};

			notifier.OperationProgress += (sender, progress) =>
			{
				Console.WriteLine($"Событие с аргументом: прогресс операции {progress}%.");
			};

			notifier.OperationFinished += (sender, message) =>
			{
				Console.WriteLine($"Событие завершения операции: {message}");
			};

			notifier.RunOperation();
		}

		/// <summary>
		/// Демонстрирует использование лямбда-выражений с делегатами.
		/// </summary>
		private static void DemonstrateLambdas()
		{
			Console.WriteLine("=== Демонстрация лямбда-выражений ===");

			// Делегат, вычисляющий квадрат числа.
			NumberOperation square = x => x * x;

			// Делегат, вычисляющий сумму двух чисел.
			BinaryNumberOperation add = (x, y) => x + y;

			var value = 5;
			Console.WriteLine($"Квадрат числа {value} равен {square(value)}");

			var a = 10;
			var b = 15;
			Console.WriteLine($"Сумма чисел {a} и {b} равна {add(a, b)}");
		}
	}
}


