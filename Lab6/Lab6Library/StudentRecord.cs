namespace Lab6Library
{
	/// <summary>
	/// Представляет запись о студенте для демонстрации LINQ-запросов.
	/// </summary>
	public class StudentRecord
	{
		/// <summary>
		/// Имя студента.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Факультет, на котором учится студент.
		/// </summary>
		public string Faculty { get; }

		/// <summary>
		/// Курс (год обучения).
		/// </summary>
		public int Year { get; }

		/// <summary>
		/// Средний балл студента.
		/// </summary>
		public double AverageScore { get; }

		/// <summary>
		/// Инициализирует новый экземпляр класса StudentRecord.
		/// </summary>
		/// <param name="name">Имя студента.</param>
		/// <param name="faculty">Факультет.</param>
		/// <param name="year">Курс.</param>
		/// <param name="averageScore">Средний балл.</param>
		public StudentRecord(string name, string faculty, int year, double averageScore)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Имя не должно быть пустым.", nameof(name));
			}

			if (string.IsNullOrEmpty(faculty))
			{
				throw new ArgumentException("Факультет не должен быть пустым.", nameof(faculty));
			}

			if (year <= 0)
			{
				throw new ArgumentException("Курс должен быть положительным.", nameof(year));
			}

			if (averageScore < 0)
			{
				throw new ArgumentException("Средний балл не может быть отрицательным.", nameof(averageScore));
			}

			Name = name;
			Faculty = faculty;
			Year = year;
			AverageScore = averageScore;
		}
	}
}


