namespace Lab6Library
{
	/// <summary>
	/// Предоставляет тестовые данные для демонстрации LINQ.
	/// </summary>
	public static class StudentRepository
	{
		/// <summary>
		/// Возвращает набор студентов для примеров.
		/// </summary>
		/// <returns>Коллекция студентов.</returns>
		public static IReadOnlyList<StudentRecord> GetSampleStudents()
		{
			return new List<StudentRecord>
			{
				new StudentRecord("Анна Смирнова", "Информатика", 1, 4.8),
				new StudentRecord("Иван Иванов", "Информатика", 2, 4.3),
				new StudentRecord("Пётр Кузнецов", "Математика", 3, 4.9),
				new StudentRecord("Светлана Орлова", "Математика", 2, 4.2),
				new StudentRecord("Мария Алексеева", "Физика", 4, 4.6),
				new StudentRecord("Дмитрий Панов", "Физика", 1, 3.8),
				new StudentRecord("Кирилл Власов", "Информатика", 3, 4.7),
				new StudentRecord("Екатерина Никифорова", "Химия", 2, 3.9),
				new StudentRecord("Олег Фомин", "Химия", 4, 4.1),
				new StudentRecord("Виктория Соколова", "Информатика", 4, 4.95)
			};
		}
	}
}


