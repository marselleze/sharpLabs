using SharpLabs.Common;

namespace Lab6.Library
{
	/// <summary>
	/// Демонстрация работы с LINQ: фильтрация, группировка, анонимные типы.
	/// </summary>
	public static class LinqDemo
	{
		/// <summary>
		/// Создает тестовую коллекцию студентов.
		/// </summary>
		/// <returns>Коллекция студентов для демонстрации.</returns>
		public static List<Student> GetTestStudents()
		{
			return new List<Student>
			{
				new Student("Иван", "Петров", "ИСП-21", 4.5, 20),
				new Student("Мария", "Сидорова", "ИСП-21", 5.0, 19),
				new Student("Алексей", "Иванов", "ИСП-22", 3.8, 21),
				new Student("Елена", "Козлова", "ИСП-22", 4.9, 20),
				new Student("Дмитрий", "Смирнов", "ИСП-21", 4.2, 22),
				new Student("Анна", "Волкова", "ИСП-23", 5.0, 19),
				new Student("Сергей", "Попов", "ИСП-23", 3.5, 21),
				new Student("Ольга", "Лебедева", "ИСП-22", 4.7, 20),
				new Student("Николай", "Новиков", "ИСП-21", 3.9, 23),
				new Student("Татьяна", "Морозова", "ИСП-23", 4.8, 19)
			};
		}

		/// <summary>
		/// Демонстрирует фильтрацию через LINQ с использованием синтаксиса FROM.
		/// </summary>
		/// <param name="students">Коллекция студентов.</param>
		/// <param name="minGrade">Минимальный средний балл.</param>
		/// <returns>Отфильтрованная коллекция студентов.</returns>
		public static IEnumerable<Student> FilterWithFromSyntax(IEnumerable<Student> students, double minGrade)
		{
			Argument.NotNull(students, "Коллекция студентов не может быть null.");

			var result = from student in students
						 where student.AverageGrade >= minGrade
						 select student;

			return result;
		}

		/// <summary>
		/// Демонстрирует фильтрацию через LINQ с использованием лямбда-выражений.
		/// </summary>
		/// <param name="students">Коллекция студентов.</param>
		/// <param name="minGrade">Минимальный средний балл.</param>
		/// <returns>Отфильтрованная коллекция студентов.</returns>
		public static IEnumerable<Student> FilterWithLambda(IEnumerable<Student> students, double minGrade)
		{
			Argument.NotNull(students, "Коллекция студентов не может быть null.");

			return students.Where(s => s.AverageGrade >= minGrade);
		}

		/// <summary>
		/// Демонстрирует использование анонимных типов через синтаксис FROM.
		/// </summary>
		/// <param name="students">Коллекция студентов.</param>
		/// <returns>Коллекция анонимных объектов с информацией о студентах.</returns>
		public static IEnumerable<dynamic> AnonymousTypesWithFromSyntax(IEnumerable<Student> students)
		{
			Argument.NotNull(students, "Коллекция студентов не может быть null.");

			var result = from student in students
						 select (dynamic)new
						 {
							 FullName = $"{student.Surname} {student.Name}",
							 Group = student.Group,
							 Grade = student.AverageGrade
						 };

			return result;
		}

		/// <summary>
		/// Демонстрирует использование анонимных типов через лямбда-выражения.
		/// </summary>
		/// <param name="students">Коллекция студентов.</param>
		/// <returns>Коллекция анонимных объектов с информацией о студентах.</returns>
		public static IEnumerable<dynamic> AnonymousTypesWithLambda(IEnumerable<Student> students)
		{
			Argument.NotNull(students, "Коллекция студентов не может быть null.");

			return students.Select(s => (dynamic)new
			{
				FullName = $"{s.Surname} {s.Name}",
				Group = s.Group,
				Grade = s.AverageGrade
			});
		}

		/// <summary>
		/// Демонстрирует группировку через синтаксис FROM.
		/// </summary>
		/// <param name="students">Коллекция студентов.</param>
		/// <returns>Группированная коллекция студентов по группам.</returns>
		public static IEnumerable<IGrouping<string, Student>> GroupByWithFromSyntax(IEnumerable<Student> students)
		{
			Argument.NotNull(students, "Коллекция студентов не может быть null.");

			var result = from student in students
						 group student by student.Group into grouped
						 select grouped;

			return result;
		}

		/// <summary>
		/// Демонстрирует группировку через лямбда-выражения.
		/// </summary>
		/// <param name="students">Коллекция студентов.</param>
		/// <returns>Группированная коллекция студентов по группам.</returns>
		public static IEnumerable<IGrouping<string, Student>> GroupByWithLambda(IEnumerable<Student> students)
		{
			Argument.NotNull(students, "Коллекция студентов не может быть null.");

			return students.GroupBy(s => s.Group);
		}

		/// <summary>
		/// Демонстрирует группировку с анонимными типами через синтаксис FROM.
		/// </summary>
		/// <param name="students">Коллекция студентов.</param>
		/// <returns>Коллекция анонимных объектов с информацией о группах.</returns>
		public static IEnumerable<dynamic> GroupByWithAnonymousTypesFromSyntax(IEnumerable<Student> students)
		{
			Argument.NotNull(students, "Коллекция студентов не может быть null.");

			var result = from student in students
						 group student by student.Group into grouped
						 select (dynamic)new
						 {
							 Group = grouped.Key,
							 Count = grouped.Count(),
							 AverageGrade = grouped.Average(s => s.AverageGrade),
							 Students = grouped.ToList()
						 };

			return result;
		}

		/// <summary>
		/// Демонстрирует группировку с анонимными типами через лямбда-выражения.
		/// </summary>
		/// <param name="students">Коллекция студентов.</param>
		/// <returns>Коллекция анонимных объектов с информацией о группах.</returns>
		public static IEnumerable<dynamic> GroupByWithAnonymousTypesLambda(IEnumerable<Student> students)
		{
			Argument.NotNull(students, "Коллекция студентов не может быть null.");

			return students
				.GroupBy(s => s.Group)
				.Select(g => (dynamic)new
				{
					Group = g.Key,
					Count = g.Count(),
					AverageGrade = g.Average(s => s.AverageGrade),
					Students = g.ToList()
				});
		}
	}
}

