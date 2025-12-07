namespace Lab3Library
{
	/// <summary>
	/// Класс для демонстрации сравнения объектов.
	/// </summary>
	public class Person : IEquatable<Person>
	{
		/// <summary>
		/// Имя человека.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Возраст человека.
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса Person.
		/// </summary>
		/// <param name="name">Имя человека.</param>
		/// <param name="age">Возраст человека.</param>
		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		/// <summary>
		/// Определяет, равен ли указанный объект текущему объекту Person.
		/// </summary>
		/// <param name="obj">Объект для сравнения с текущим объектом.</param>
		/// <returns>true, если указанный объект равен текущему объекту; иначе false.</returns>
		public override bool Equals(object? obj)
		{
			if (obj is Person otherPerson)
			{
				return Equals(otherPerson);
			}

			return false;
		}

		/// <summary>
		/// Определяет, равен ли указанный объект Person текущему объекту Person.
		/// </summary>
		/// <param name="other">Объект Person для сравнения с текущим объектом.</param>
		/// <returns>true, если указанный объект равен текущему объекту; иначе false.</returns>
		public bool Equals(Person? other)
		{
			if (other == null)
			{
				return false;
			}

			return Name == other.Name && Age == other.Age;
		}

		/// <summary>
		/// Служит хэш-функцией по умолчанию.
		/// </summary>
		/// <returns>Хэш-код для текущего объекта.</returns>
		public override int GetHashCode()
		{
			return HashCode.Combine(Name, Age);
		}

		/// <summary>
		/// Оператор равенства для сравнения двух объектов Person.
		/// </summary>
		/// <param name="left">Первый объект для сравнения.</param>
		/// <param name="right">Второй объект для сравнения.</param>
		/// <returns>true, если объекты равны; иначе false.</returns>
		public static bool operator ==(Person? left, Person? right)
		{
			if (ReferenceEquals(left, right))
			{
				return true;
			}

			if (left is null || right is null)
			{
				return false;
			}

			return left.Equals(right);
		}

		/// <summary>
		/// Оператор неравенства для сравнения двух объектов Person.
		/// </summary>
		/// <param name="left">Первый объект для сравнения.</param>
		/// <param name="right">Второй объект для сравнения.</param>
		/// <returns>true, если объекты не равны; иначе false.</returns>
		public static bool operator !=(Person? left, Person? right)
		{
			return !(left == right);
		}
	}

	/// <summary>
	/// Класс для демонстрации сравнения с объектами другого типа.
	/// </summary>
	public class Employee
	{
		/// <summary>
		/// Имя сотрудника.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Возраст сотрудника.
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// Должность сотрудника.
		/// </summary>
		public string Position { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса Employee.
		/// </summary>
		/// <param name="name">Имя сотрудника.</param>
		/// <param name="age">Возраст сотрудника.</param>
		/// <param name="position">Должность сотрудника.</param>
		public Employee(string name, int age, string position)
		{
			Name = name;
			Age = age;
			Position = position;
		}

		/// <summary>
		/// Сравнивает текущий объект Employee с объектом Person.
		/// </summary>
		/// <param name="person">Объект Person для сравнения.</param>
		/// <returns>true, если имя и возраст совпадают; иначе false.</returns>
		public bool CompareWithPerson(Person person)
		{
			if (person == null)
			{
				return false;
			}

			return Name == person.Name && Age == person.Age;
		}
	}
}

