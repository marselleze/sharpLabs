namespace Lab2Library
{
	/// <summary>
	/// Структура для демонстрации типов памяти (value type - хранится в стеке).
	/// </summary>
	public struct PersonStruct
	{
		/// <summary>
		/// Имя человека (string - reference type, хранится в куче).
		/// </summary>
		public string Name;

		/// <summary>
		/// Возраст человека (int - value type, хранится в стеке).
		/// </summary>
		public int Age;

		/// <summary>
		/// Вес человека (double - value type, хранится в стеке).
		/// </summary>
		public double Weight;

		/// <summary>
		/// Инициализирует новый экземпляр структуры PersonStruct.
		/// </summary>
		/// <param name="name">Имя человека.</param>
		/// <param name="age">Возраст человека.</param>
		/// <param name="weight">Вес человека.</param>
		public PersonStruct(string name, int age, double weight)
		{
			Name = name;
			Age = age;
			Weight = weight;
		}
	}

	/// <summary>
	/// Класс для демонстрации типов памяти (reference type - хранится в куче).
	/// </summary>
	public class PersonClass
	{
		/// <summary>
		/// Имя человека (string - reference type, хранится в куче).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Возраст человека (int - value type, хранится в стеке, но как часть объекта класса - в куче).
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// Вес человека (double - value type, хранится в стеке, но как часть объекта класса - в куче).
		/// </summary>
		public double Weight { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса PersonClass.
		/// </summary>
		/// <param name="name">Имя человека.</param>
		/// <param name="age">Возраст человека.</param>
		/// <param name="weight">Вес человека.</param>
		public PersonClass(string name, int age, double weight)
		{
			Name = name;
			Age = age;
			Weight = weight;
		}
	}

	/// <summary>
	/// Предоставляет методы для демонстрации работы с типами памяти, ref и out параметрами.
	/// </summary>
	public static class MemoryTypeDemo
	{
		/// <summary>
		/// Изменяет структуру внутри метода (передача по значению - изменения не сохраняются).
		/// </summary>
		/// <param name="person">Структура для изменения.</param>
		public static void ModifyStruct(PersonStruct person)
		{
			person.Age = 100;
			person.Name = "Изменено";
		}

		/// <summary>
		/// Изменяет структуру внутри метода с использованием ref (передача по ссылке - изменения сохраняются).
		/// </summary>
		/// <param name="person">Структура для изменения.</param>
		public static void ModifyStructByRef(ref PersonStruct person)
		{
			person.Age = 100;
			person.Name = "Изменено";
		}

		/// <summary>
		/// Изменяет класс внутри метода (передача по ссылке - изменения сохраняются).
		/// </summary>
		/// <param name="person">Класс для изменения.</param>
		public static void ModifyClass(PersonClass person)
		{
			if (person != null)
			{
				person.Age = 100;
				person.Name = "Изменено";
			}
		}

		/// <summary>
		/// Изменяет класс внутри метода с использованием ref (передача ссылки по ссылке - можно изменить саму ссылку).
		/// </summary>
		/// <param name="person">Класс для изменения.</param>
		public static void ModifyClassByRef(ref PersonClass person)
		{
			person = new PersonClass("Новый объект", 200, 300.0);
		}

		/// <summary>
		/// Использует out параметр для возврата результата (переменная должна быть инициализирована внутри метода).
		/// </summary>
		/// <param name="input">Входное значение.</param>
		/// <param name="result">Результат вычисления.</param>
		/// <param name="multiplier">Множитель результата.</param>
		public static void CalculateWithOut(int input, out int result, out int multiplier)
		{
			result = input * 2;
			multiplier = 3;
		}

		/// <summary>
		/// Выполняет принудительную сборку мусора.
		/// </summary>
		public static void ForceGarbageCollection()
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
		}
	}
}

