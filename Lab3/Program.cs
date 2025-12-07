using Lab3Library;

namespace Lab3
{
	/// <summary>
	/// Точка входа в приложение лабораторной работы №3.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Главный метод программы.
		/// </summary>
		private static void Main()
		{
			Console.WriteLine("Лабораторная работа №3");
			Console.WriteLine();

			DemonstrateDynamicArray();
			Console.WriteLine();

			DemonstrateObjectComparison();
			Console.WriteLine();

			DemonstrateCollections();
		}

		/// <summary>
		/// Демонстрирует работу с динамическим массивом DynamicArray.
		/// </summary>
		private static void DemonstrateDynamicArray()
		{
			Console.WriteLine("=== Демонстрация DynamicArray<T> ===");
			Console.WriteLine();

			// Конструктор без параметров
			Console.WriteLine("1. Создание массива конструктором без параметров (ёмкость по умолчанию 8):");
			var array1 = new DynamicArray<int>();
			Console.WriteLine($"   Length: {array1.Length}, Capacity: {array1.Capacity}");
			Console.WriteLine();

			// Конструктор с параметром capacity
			Console.WriteLine("2. Создание массива конструктором с параметром capacity (ёмкость 5):");
			var array2 = new DynamicArray<int>(5);
			Console.WriteLine($"   Length: {array2.Length}, Capacity: {array2.Capacity}");
			Console.WriteLine();

			// Конструктор с IEnumerable
			Console.WriteLine("3. Создание массива конструктором с IEnumerable<int> {1, 2, 3, 4, 5}:");
			var initialCollection = new[] { 1, 2, 3, 4, 5 };
			var array3 = new DynamicArray<int>(initialCollection);
			Console.WriteLine($"   Length: {array3.Length}, Capacity: {array3.Capacity}");
			Console.WriteLine($"   Элементы: {string.Join(", ", array3)}");
			Console.WriteLine();

			// Метод Add
			Console.WriteLine("4. Добавление элементов методом Add:");
			var array4 = new DynamicArray<int>(3);
			Console.WriteLine($"   Начальное состояние: Length={array4.Length}, Capacity={array4.Capacity}");
			
			for (var i = 1; i <= 10; i++)
			{
				array4.Add(i);
				Console.WriteLine($"   После Add({i}): Length={array4.Length}, Capacity={array4.Capacity}");
			}

			Console.WriteLine($"   Элементы: {string.Join(", ", array4)}");
			Console.WriteLine();

			// Метод AddRange
			Console.WriteLine("5. Добавление элементов методом AddRange:");
			var array5 = new DynamicArray<int>();
			array5.Add(1);
			array5.Add(2);
			Console.WriteLine($"   До AddRange: Length={array5.Length}, Capacity={array5.Capacity}");
			Console.WriteLine($"   Элементы: {string.Join(", ", array5)}");

			var rangeToAdd = new[] { 10, 20, 30, 40, 50 };
			array5.AddRange(rangeToAdd);
			Console.WriteLine($"   После AddRange: Length={array5.Length}, Capacity={array5.Capacity}");
			Console.WriteLine($"   Элементы: {string.Join(", ", array5)}");
			Console.WriteLine();

			// Метод Remove
			Console.WriteLine("6. Удаление элементов методом Remove:");
			var array6 = new DynamicArray<int>(new[] { 1, 2, 3, 4, 5 });
			Console.WriteLine($"   До Remove(3): {string.Join(", ", array6)}");
			var removed = array6.Remove(3);
			Console.WriteLine($"   После Remove(3): {string.Join(", ", array6)}");
			Console.WriteLine($"   Результат удаления: {removed}, Length={array6.Length}, Capacity={array6.Capacity}");
			Console.WriteLine();

			// Метод Insert
			Console.WriteLine("7. Вставка элементов методом Insert:");
			var array7 = new DynamicArray<int>(new[] { 1, 2, 4, 5 });
			Console.WriteLine($"   До Insert(2, 3): {string.Join(", ", array7)}");
			var inserted = array7.Insert(2, 3);
			Console.WriteLine($"   После Insert(2, 3): {string.Join(", ", array7)}");
			Console.WriteLine($"   Результат вставки: {inserted}, Length={array7.Length}, Capacity={array7.Capacity}");
			Console.WriteLine();

			// Индексатор
			Console.WriteLine("8. Работа с индексатором:");
			var array8 = new DynamicArray<string>(new[] { "первый", "второй", "третий" });
			Console.WriteLine($"   array8[0] = {array8[0]}");
			Console.WriteLine($"   array8[1] = {array8[1]}");
			array8[2] = "изменённый";
			Console.WriteLine($"   После array8[2] = 'изменённый': {string.Join(", ", array8)}");
			Console.WriteLine();

			// Реализация IEnumerable с yield
			Console.WriteLine("9. Итерация по массиву с использованием foreach (yield):");
			var array9 = new DynamicArray<int>(new[] { 10, 20, 30 });
			Console.Write("   Элементы: ");
			foreach (var item in array9)
			{
				Console.Write($"{item} ");
			}

			Console.WriteLine();
			Console.WriteLine();
		}

		/// <summary>
		/// Демонстрирует сравнение объектов.
		/// </summary>
		private static void DemonstrateObjectComparison()
		{
			Console.WriteLine("=== Демонстрация сравнения объектов ===");
			Console.WriteLine();

			// Сравнение объектов одного типа
			Console.WriteLine("1. Сравнение объектов Person:");
			var person1 = new Person("Иван", 25);
			var person2 = new Person("Иван", 25);
			var person3 = new Person("Петр", 30);

			Console.WriteLine($"   person1: Name={person1.Name}, Age={person1.Age}");
			Console.WriteLine($"   person2: Name={person2.Name}, Age={person2.Age}");
			Console.WriteLine($"   person3: Name={person3.Name}, Age={person3.Age}");
			Console.WriteLine($"   person1.Equals(person2): {person1.Equals(person2)}");
			Console.WriteLine($"   person1 == person2: {person1 == person2}");
			Console.WriteLine($"   person1.Equals(person3): {person1.Equals(person3)}");
			Console.WriteLine($"   person1 == person3: {person1 == person3}");
			Console.WriteLine();

			// Сравнение объектов разных типов
			Console.WriteLine("2. Сравнение объектов Person и Employee:");
			var employee = new Employee("Иван", 25, "Разработчик");
			Console.WriteLine($"   employee: Name={employee.Name}, Age={employee.Age}, Position={employee.Position}");
			Console.WriteLine($"   employee.CompareWithPerson(person1): {employee.CompareWithPerson(person1)}");
			Console.WriteLine($"   employee.CompareWithPerson(person3): {employee.CompareWithPerson(person3)}");
			Console.WriteLine();
		}

		/// <summary>
		/// Демонстрирует работу с различными типами коллекций.
		/// </summary>
		private static void DemonstrateCollections()
		{
			Console.WriteLine("=== Демонстрация работы с коллекциями ===");
			Console.WriteLine();

			CollectionsDemo.DemonstrateList();
			CollectionsDemo.DemonstrateDictionary();
			CollectionsDemo.DemonstrateQueue();
			CollectionsDemo.DemonstrateStack();
		}
	}
}
