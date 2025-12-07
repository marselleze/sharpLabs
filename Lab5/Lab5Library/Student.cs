namespace Lab5Library
{
	/// <summary>
	/// Представляет студента для демонстрации JSON-сериализации.
	/// </summary>
	public class Student
	{
		/// <summary>
		/// Имя студента.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Возраст студента.
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// Средний балл студента.
		/// </summary>
		public double AverageGrade { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса Student.
		/// </summary>
		/// <param name="name">Имя студента.</param>
		/// <param name="age">Возраст студента.</param>
		/// <param name="averageGrade">Средний балл студента.</param>
		public Student(string name, int age, double averageGrade)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Имя студента не должно быть пустым.", nameof(name));
			}

			if (age <= 0)
			{
				throw new ArgumentException("Возраст студента должен быть положительным.", nameof(age));
			}

			if (averageGrade < 0)
			{
				throw new ArgumentException("Средний балл не может быть отрицательным.", nameof(averageGrade));
			}

			Name = name;
			Age = age;
			AverageGrade = averageGrade;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Student без параметров.
		/// Необходим для корректной десериализации JSON.
		/// </summary>
		public Student()
		{
			Name = string.Empty;
		}
	}
}


