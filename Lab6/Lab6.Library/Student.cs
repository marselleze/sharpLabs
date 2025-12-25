namespace Lab6.Library
{
	/// <summary>
	/// Представляет студента с информацией о его оценках и группе.
	/// </summary>
	public class Student
	{
		/// <summary>
		/// Получает или задает имя студента.
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Получает или задает фамилию студента.
		/// </summary>
		public string Surname { get; set; } = string.Empty;

		/// <summary>
		/// Получает или задает номер группы.
		/// </summary>
		public string Group { get; set; } = string.Empty;

		/// <summary>
		/// Получает или задает средний балл.
		/// </summary>
		public double AverageGrade { get; set; }

		/// <summary>
		/// Получает или задает возраст студента.
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// Инициализирует новый экземпляр класса Student.
		/// </summary>
		public Student()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Student с указанными параметрами.
		/// </summary>
		/// <param name="name">Имя студента.</param>
		/// <param name="surname">Фамилия студента.</param>
		/// <param name="group">Номер группы.</param>
		/// <param name="averageGrade">Средний балл.</param>
		/// <param name="age">Возраст студента.</param>
		public Student(string name, string surname, string group, double averageGrade, int age)
		{
			Name = name;
			Surname = surname;
			Group = group;
			AverageGrade = averageGrade;
			Age = age;
		}

		/// <summary>
		/// Возвращает строковое представление студента.
		/// </summary>
		public override string ToString()
		{
			return $"{Surname} {Name}, группа {Group}, средний балл: {AverageGrade:F2}, возраст: {Age}";
		}
	}
}

