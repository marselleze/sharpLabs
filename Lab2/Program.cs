using Lab2Library;

namespace Lab2
{
	/// <summary>
	/// Точка входа в приложение лабораторной работы №2.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Главный метод программы.
		/// </summary>
		private static void Main()
		{
			Console.WriteLine("Лабораторная работа №2");
			Console.WriteLine();

			ProcessBmiCalculation();
			Console.WriteLine();

			ProcessArrayOperations();
			Console.WriteLine();

			ProcessTextAnalysis();
			Console.WriteLine();

			ProcessMemoryTypesDemo();
		}

		/// <summary>
		/// Обрабатывает запрос пользователя на расчёт индекса массы тела.
		/// </summary>
		private static void ProcessBmiCalculation()
		{
			Console.WriteLine("Задача 1: Расчёт индекса массы тела (ИМТ)");
			Console.Write("Введите массу тела в килограммах: ");

			var weightInput = Console.ReadLine();

			if (string.IsNullOrEmpty(weightInput) || !double.TryParse(weightInput, out var weight))
			{
				Console.WriteLine("Ошибка: введено некорректное значение массы.");
				return;
			}

			Console.Write("Введите рост в метрах: ");

			var heightInput = Console.ReadLine();

			if (string.IsNullOrEmpty(heightInput) || !double.TryParse(heightInput, out var height))
			{
				Console.WriteLine("Ошибка: введено некорректное значение роста.");
				return;
			}

			try
			{
				var bmi = BmiCalculator.CalculateBmi(weight, height);
				Console.WriteLine($"Индекс массы тела (ИМТ): {bmi:F2}");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}

		/// <summary>
		/// Обрабатывает операции с массивом: генерация, поиск мин/макс, сортировка.
		/// </summary>
		private static void ProcessArrayOperations()
		{
			Console.WriteLine("Задача 2: Работа с массивом");
			Console.Write("Введите размер массива: ");

			var sizeInput = Console.ReadLine();

			if (string.IsNullOrEmpty(sizeInput) || !int.TryParse(sizeInput, out var size))
			{
				Console.WriteLine("Ошибка: введено некорректное значение размера массива.");
				return;
			}

			try
			{
				var array = ArrayProcessor.GenerateRandomArray(size, 0, 100);
				Console.WriteLine($"Сгенерированный массив: {string.Join(", ", array)}");

				var min = ArrayProcessor.FindMinimum(array);
				var max = ArrayProcessor.FindMaximum(array);

				Console.WriteLine($"Минимальное значение: {min}");
				Console.WriteLine($"Максимальное значение: {max}");

				ArrayProcessor.SortArray(array);
				Console.WriteLine($"Отсортированный массив: {string.Join(", ", array)}");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}

		/// <summary>
		/// Обрабатывает анализ текста для вычисления средней длины слова.
		/// </summary>
		private static void ProcessTextAnalysis()
		{
			Console.WriteLine("Задача 3: Анализ текста");
			Console.Write("Введите текстовую строку: ");

			var text = Console.ReadLine();

			if (string.IsNullOrEmpty(text))
			{
				Console.WriteLine("Ошибка: текст не может быть пустым.");
				return;
			}

			try
			{
				var averageLength = TextAnalyzer.CalculateAverageWordLength(text);
				Console.WriteLine($"Средняя длина слова: {averageLength:F2} символов");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
		}

		/// <summary>
		/// Демонстрирует работу с типами памяти, ref и out параметрами.
		/// </summary>
		private static void ProcessMemoryTypesDemo()
		{
			Console.WriteLine("Задача 4: Демонстрация типов памяти, ref и out параметров");
			Console.WriteLine();

			// Демонстрация работы со структурой (value type)
			Console.WriteLine("=== Работа со структурой (value type) ===");
			var personStruct = new PersonStruct("Иван", 25, 70.5);
			Console.WriteLine($"До изменения: Имя={personStruct.Name}, Возраст={personStruct.Age}, Вес={personStruct.Weight}");

			MemoryTypeDemo.ModifyStruct(personStruct);
			Console.WriteLine($"После ModifyStruct (без ref): Имя={personStruct.Name}, Возраст={personStruct.Age}, Вес={personStruct.Weight}");

			MemoryTypeDemo.ModifyStructByRef(ref personStruct);
			Console.WriteLine($"После ModifyStructByRef (с ref): Имя={personStruct.Name}, Возраст={personStruct.Age}, Вес={personStruct.Weight}");
			Console.WriteLine();

			// Демонстрация работы с классом (reference type)
			Console.WriteLine("=== Работа с классом (reference type) ===");
			var personClass = new PersonClass("Петр", 30, 80.0);
			Console.WriteLine($"До изменения: Имя={personClass.Name}, Возраст={personClass.Age}, Вес={personClass.Weight}");

			MemoryTypeDemo.ModifyClass(personClass);
			Console.WriteLine($"После ModifyClass (без ref): Имя={personClass.Name}, Возраст={personClass.Age}, Вес={personClass.Weight}");

			var originalPerson = personClass;
			MemoryTypeDemo.ModifyClassByRef(ref personClass);
			Console.WriteLine($"После ModifyClassByRef (с ref): Имя={personClass.Name}, Возраст={personClass.Age}, Вес={personClass.Weight}");
			Console.WriteLine($"Оригинальный объект: Имя={originalPerson.Name}, Возраст={originalPerson.Age}, Вес={originalPerson.Weight}");
			Console.WriteLine();

			// Демонстрация out параметров
			Console.WriteLine("=== Демонстрация out параметров ===");
			var input = 10;
			MemoryTypeDemo.CalculateWithOut(input, out var result, out var multiplier);
			Console.WriteLine($"Входное значение: {input}");
			Console.WriteLine($"Результат (out): {result}");
			Console.WriteLine($"Множитель (out): {multiplier}");
			Console.WriteLine();

			// Демонстрация принудительной сборки мусора
			Console.WriteLine("=== Принудительная сборка мусора ===");
			Console.WriteLine($"Память до сборки мусора: {GC.GetTotalMemory(false)} байт");
			MemoryTypeDemo.ForceGarbageCollection();
			Console.WriteLine($"Память после сборки мусора: {GC.GetTotalMemory(true)} байт");
		}
	}
}
