namespace Lab3.Library
{
	/// <summary>
	/// Демонстрационный класс для примеров сравнения объектов.
	/// </summary>
	public class SampleClass : IEquatable<SampleClass>
	{
		/// <summary>
		/// Идентификатор объекта.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Имя объекта.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса SampleClass.
		/// </summary>
		public SampleClass(int id, string name)
		{
			Id = id;
			Name = name;
		}

		/// <summary>
		/// Определяет, равен ли данный объект другому объекту того же типа.
		/// </summary>
		public bool Equals(SampleClass? other)
		{
			if (other == null)
			{
				return false;
			}

			return Id == other.Id && Name == other.Name;
		}

		/// <summary>
		/// Определяет, равен ли данный объект другому объекту.
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is SampleClass other)
			{
				return Equals(other);
			}

			return false;
		}

		/// <summary>
		/// Возвращает хеш-код для данного объекта.
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Name);
		}

		/// <summary>
		/// Возвращает строковое представление объекта.
		/// </summary>
		public override string ToString()
		{
			return $"SampleClass [Id={Id}, Name={Name}]";
		}
	}

	/// <summary>
	/// Класс для демонстрации сравнения различных типов объектов.
	/// </summary>
	public static class ObjectComparison
	{
		/// <summary>
		/// Демонстрирует сравнение экземпляров DynamicArray.
		/// </summary>
		public static void DemonstrateDynamicArrayComparison()
		{
			var array1 = new DynamicArray<int> { 1, 2, 3, 4, 5 };
			var array2 = new DynamicArray<int> { 1, 2, 3, 4, 5 };
			var array3 = new DynamicArray<int> { 1, 2, 3 };

			Console.WriteLine("Сравнение DynamicArray:");
			Console.WriteLine($"array1 == array2: {array1.Equals(array2)}");
			Console.WriteLine($"array1 == array3: {array1.Equals(array3)}");
			Console.WriteLine();
		}

		/// <summary>
		/// Демонстрирует сравнение экземпляров пользовательского класса.
		/// </summary>
		public static void DemonstrateSampleClassComparison()
		{
			var obj1 = new SampleClass(1, "Test");
			var obj2 = new SampleClass(1, "Test");
			var obj3 = new SampleClass(2, "Other");

			Console.WriteLine("Сравнение SampleClass:");
			Console.WriteLine($"obj1 == obj2: {obj1.Equals(obj2)}");
			Console.WriteLine($"obj1 == obj3: {obj1.Equals(obj3)}");
			Console.WriteLine();
		}

		/// <summary>
		/// Демонстрирует сравнение объектов разных классов.
		/// </summary>
		public static void DemonstrateDifferentClassesComparison()
		{
			var dynamicArray = new DynamicArray<int> { 1, 2, 3 };
			var sampleClass = new SampleClass(1, "Test");

			Console.WriteLine("Сравнение объектов разных классов:");
			Console.WriteLine($"DynamicArray vs SampleClass: {dynamicArray.Equals(sampleClass)}");
			Console.WriteLine();
		}
	}
}

