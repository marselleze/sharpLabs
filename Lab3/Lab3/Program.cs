using Lab3.Library;

namespace Lab3
{
	/// <summary>
	/// Главный класс консольного приложения Lab3.
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
			Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА 3");
			Console.WriteLine("Коллекции, сравнение объектов\n");
			Console.WriteLine("1. Подсчет частоты слов");
			Console.WriteLine("2. Динамический массив (DynamicArray<T>)");
			Console.WriteLine("3. Демонстрация сравнения объектов");
			Console.WriteLine("0. Выход");
			Console.Write("\nВыберите задание: ");
		}

		private static void Task1()
		{
			Console.Clear();
			Console.WriteLine("Задание 1: Подсчет частоты слов\n");

			Console.WriteLine("Введите текст на английском языке:");
			var text = Console.ReadLine();

			if (!string.IsNullOrWhiteSpace(text))
			{
				var frequency = WordFrequencyAnalyzer.CountWordFrequency(text);
				Console.WriteLine();
				WordFrequencyAnalyzer.PrintWordFrequency(frequency);
			}
			else
			{
				Console.WriteLine("Ошибка: текст не может быть пустым.");
			}
		}

		private static void Task2()
		{
			Console.Clear();
			Console.WriteLine("Задание 2: Динамический массив\n");

			var array = new DynamicArray<int>();
			Console.WriteLine($"Создан массив с емкостью: {array.Capacity}");

			Console.WriteLine("\nДобавление элементов 1-10:");

			for (var i = 1; i <= 10; i++)
			{
				array.Add(i);
				Console.WriteLine($"Добавлен {i}, длина: {array.Length}, емкость: {array.Capacity}");
			}

			Console.WriteLine($"\nЭлементы массива:");

			foreach (var item in array)
			{
				Console.Write($"{item} ");
			}

			Console.WriteLine();

			Console.WriteLine("\nДобавление диапазона [100, 101, 102]:");
			array.AddRange(new[] { 100, 101, 102 });
			Console.WriteLine($"Длина: {array.Length}, емкость: {array.Capacity}");

			Console.WriteLine("\nУдаление элемента 5:");
			array.Remove(5);

			Console.WriteLine("Элементы после удаления:");

			foreach (var item in array)
			{
				Console.Write($"{item} ");
			}

			Console.WriteLine();

			Console.WriteLine("\nВставка элемента 999 на позицию 3:");
			array.Insert(3, 999);

			Console.WriteLine("Элементы после вставки:");

			foreach (var item in array)
			{
				Console.Write($"{item} ");
			}

			Console.WriteLine();
		}

		private static void Task3()
		{
			Console.Clear();
			Console.WriteLine("Задание 3: Демонстрация сравнения объектов\n");

			ObjectComparison.DemonstrateDynamicArrayComparison();
			ObjectComparison.DemonstrateSampleClassComparison();
			ObjectComparison.DemonstrateDifferentClassesComparison();
		}
	}
}
