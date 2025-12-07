using Lab6Library;

namespace Lab6
{
	/// <summary>
	/// Точка входа в приложение лабораторной работы №6.
	/// </summary>
	internal class Program
	{
		private static readonly IReadOnlyList<StudentRecord> Students = StudentRepository.GetSampleStudents();

		/// <summary>
		/// Главный метод программы.
		/// </summary>
		private static void Main()
		{
			Console.WriteLine("Лабораторная работа №6");
			Console.WriteLine("Демонстрация LINQ (фильтрация, анонимные типы, группировки).");
			Console.WriteLine();

			var exitRequested = false;

			while (!exitRequested)
			{
				Console.WriteLine("Выберите режим:");
				Console.WriteLine("1 - Фильтрация успеваемости (синтаксис from)");
				Console.WriteLine("2 - Проекция в анонимные типы (лямбды)");
				Console.WriteLine("3 - Группировка по факультетам (лямбды)");
				Console.WriteLine("0 - Выход");
				Console.Write("Ваш выбор: ");

				var choice = Console.ReadLine();
				Console.WriteLine();

				switch (choice)
				{
					case "1":
						DemonstrateQuerySyntaxFiltering();
						break;
					case "2":
						DemonstrateAnonymousProjection();
						break;
					case "3":
						DemonstrateGrouping();
						break;
					case "0":
						exitRequested = true;
						break;
					default:
						Console.WriteLine("Неизвестный пункт меню. Повторите ввод.");
						break;
				}

				Console.WriteLine();
			}
		}

		/// <summary>
		/// Демонстрирует фильтрацию и сортировку с помощью синтаксиса запросов (from ...).
		/// Показывает использование OrderBy, Take, ToList, First.
		/// </summary>
		private static void DemonstrateQuerySyntaxFiltering()
		{
			Console.WriteLine("=== Фильтрация (синтаксис from) ===");
			Console.Write("Введите минимальный средний балл (например, 4.5): ");
			var input = Console.ReadLine();

			if (!double.TryParse(input, out var minScore))
			{
				Console.WriteLine("Некорректный ввод. Использовано значение 4.5.");
				minScore = 4.5;
			}

			const string faculty = "Информатика";

			var query =
				from student in Students
				where student.Faculty == faculty && student.AverageScore >= minScore
				orderby student.AverageScore descending
				select student;

			var topStudents = query
				.Take(3)
				.ToList();

			if (!topStudents.Any())
			{
				Console.WriteLine("Студенты, удовлетворяющие условию, не найдены.");
				return;
			}

			Console.WriteLine($"Топ-студенты факультета \"{faculty}\" с баллом >= {minScore:F2}:");

			foreach (var student in topStudents)
			{
				Console.WriteLine($"- {student.Name}, курс {student.Year}, средний балл {student.AverageScore:F2}");
			}

			var bestStudent = topStudents.First();
			Console.WriteLine();
			Console.WriteLine($"Лучший студент: {bestStudent.Name} ({bestStudent.AverageScore:F2}).");
		}

		/// <summary>
		/// Демонстрирует использование лямбда-выражений и анонимных типов.
		/// Показывает OrderBy, Skip, ToArray, FirstOrDefault.
		/// </summary>
		private static void DemonstrateAnonymousProjection()
		{
			Console.WriteLine("=== Анонимные типы и лямбда-запросы ===");

			var projected = Students
				.Where(student => student.Year >= 2)
				.OrderBy(student => student.Name)
				.Skip(1)
				.Select(student => new
				{
					student.Name,
					student.Faculty,
					student.Year,
					FutureScore = student.AverageScore + 0.1
				})
				.ToArray();

			if (!projected.Any())
			{
				Console.WriteLine("Коллекция пуста.");
				return;
			}

			foreach (var item in projected)
			{
				Console.WriteLine($"Студент {item.Name} ({item.Faculty}, {item.Year} курс) потенциальный балл: {item.FutureScore:F2}");
			}

			var firstProjected = projected.FirstOrDefault();

			if (firstProjected != null)
			{
				Console.WriteLine();
				Console.WriteLine($"Первый элемент после Skip: {firstProjected.Name}.");
			}
		}

		/// <summary>
		/// Демонстрирует группировку студентов по факультетам.
		/// Показывает GroupBy, ToList, Any.
		/// </summary>
		private static void DemonstrateGrouping()
		{
			Console.WriteLine("=== Группировка по факультетам ===");

			var groups = Students
				.GroupBy(student => student.Faculty)
				.OrderBy(group => group.Key)
				.ToList();

			foreach (var group in groups)
			{
				Console.WriteLine($"Факультет: {group.Key}, студентов: {group.Count()}");

				var hasExcellent = group.Any(student => student.AverageScore >= 4.8);

				foreach (var student in group.Take(2))
				{
					Console.WriteLine($"  - {student.Name}, курс {student.Year}, балл {student.AverageScore:F2}");
				}

				Console.WriteLine($"  Наличие отличников (>= 4.8): {(hasExcellent ? "да" : "нет")}");
				Console.WriteLine();
			}
		}
	}
}


