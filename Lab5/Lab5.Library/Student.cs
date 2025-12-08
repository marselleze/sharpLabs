using System.Text.Json.Serialization;

namespace Lab5.Library
{
	/// <summary>
	/// Модель данных студента для демонстрации сериализации.
	/// </summary>
	public class Student
	{
		/// <summary>
		/// Уникальный идентификатор студента.
		/// </summary>
		[JsonPropertyName("id")]
		public int Id { get; set; }

		/// <summary>
		/// Имя студента.
		/// </summary>
		[JsonPropertyName("firstName")]
		public string FirstName { get; set; } = string.Empty;

		/// <summary>
		/// Фамилия студента.
		/// </summary>
		[JsonPropertyName("lastName")]
		public string LastName { get; set; } = string.Empty;

		/// <summary>
		/// Возраст студента.
		/// </summary>
		[JsonPropertyName("age")]
		public int Age { get; set; }

		/// <summary>
		/// Средний балл студента.
		/// </summary>
		[JsonPropertyName("gpa")]
		public double Gpa { get; set; }

		/// <summary>
		/// Дата зачисления.
		/// </summary>
		[JsonPropertyName("enrollmentDate")]
		public DateTime EnrollmentDate { get; set; }

		/// <summary>
		/// Список курсов, которые посещает студент.
		/// </summary>
		[JsonPropertyName("courses")]
		public List<string> Courses { get; set; } = new List<string>();

		/// <summary>
		/// Инициализирует новый экземпляр класса Student.
		/// </summary>
		public Student()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Student с указанными параметрами.
		/// </summary>
		public Student(int id, string firstName, string lastName, int age, double gpa)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			Gpa = gpa;
			EnrollmentDate = DateTime.Now;
			Courses = new List<string>();
		}

		/// <summary>
		/// Возвращает строковое представление студента.
		/// </summary>
		public override string ToString()
		{
			var coursesStr = Courses.Count > 0 ? string.Join(", ", Courses) : "нет курсов";
			return $"Студент #{Id}: {LastName} {FirstName}, {Age} лет, средний балл: {Gpa:F2}, курсы: [{coursesStr}]";
		}
	}
}

