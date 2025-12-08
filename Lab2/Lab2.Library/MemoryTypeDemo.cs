namespace Lab2.Library
{
	/// <summary>
	/// Структура для демонстрации типов значений.
	/// </summary>
	public struct PersonData
	{
		/// <summary>
		/// Имя персоны.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Возраст персоны.
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр структуры PersonData.
		/// </summary>
		/// <param name="name">Имя.</param>
		/// <param name="age">Возраст.</param>
		public PersonData(string name, int age)
		{
			Name = name;
			Age = age;
		}

		/// <summary>
		/// Возвращает строковое представление структуры.
		/// </summary>
		public override string ToString()
		{
			return $"{Name}, {Age} лет";
		}
	}

	/// <summary>
	/// Класс для демонстрации различий между типами значений и ссылочными типами.
	/// </summary>
	public class MemoryTypeDemo
	{
		/// <summary>
		/// Демонстрирует передачу структуры по значению.
		/// Изменения внутри метода не влияют на исходную структуру.
		/// </summary>
		/// <param name="person">Структура PersonData.</param>
		public static void ModifyValueType(PersonData person)
		{
			person.Age = 100;
			Console.WriteLine($"Внутри метода ModifyValueType: {person}");
		}

		/// <summary>
		/// Демонстрирует передачу структуры по ссылке с использованием ref.
		/// Изменения влияют на исходную структуру.
		/// </summary>
		/// <param name="person">Ссылка на структуру PersonData.</param>
		public static void ModifyValueTypeByRef(ref PersonData person)
		{
			person.Age = 200;
			Console.WriteLine($"Внутри метода ModifyValueTypeByRef: {person}");
		}

		/// <summary>
		/// Демонстрирует использование out параметра для возврата результата.
		/// </summary>
		/// <param name="name">Имя.</param>
		/// <param name="age">Возраст.</param>
		/// <param name="result">Выходной параметр с созданной структурой.</param>
		public static void CreatePerson(string name, int age, out PersonData result)
		{
			result = new PersonData(name, age);
		}

		/// <summary>
		/// Демонстрирует принудительную сборку мусора.
		/// </summary>
		public static void DemoGarbageCollection()
		{
			Console.WriteLine($"Использование памяти до сборки: {GC.GetTotalMemory(false)} байт");

			var largeArray = new int[1000000];
			Console.WriteLine($"Использование памяти после создания массива: {GC.GetTotalMemory(false)} байт");

			largeArray = null;

			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();

			Console.WriteLine($"Использование памяти после сборки мусора: {GC.GetTotalMemory(false)} байт");
		}
	}
}

