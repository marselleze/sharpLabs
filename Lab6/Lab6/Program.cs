using Lab6.Library;

namespace Lab6
{
	/// <summary>
	/// Главный класс консольного приложения Lab6.
	/// </summary>
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			var running = true;

			while (running)
			{
				DisplayMenu();
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						DemonstrateFiltering();
						break;
					case "2":
						DemonstrateAnonymousTypes();
						break;
					case "3":
						DemonstrateGrouping();
						break;
					case "4":
						DemonstrateLinqMethods();
						break;
					case "0":
						running = false;
						Console.WriteLine("До свидания!");
						break;
					default:
						Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
						break;
				}

				if (running)
				{
					Console.WriteLine("\nНажмите любую клавишу для продолжения...");
					Console.ReadKey();
				}
			}
		}

		private static void DisplayMenu()
		{
			Console.Clear();
			Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА 6");
			Console.WriteLine("Работа с LINQ\n");
			Console.WriteLine("1. Фильтрация (FROM и лямбды)");
			Console.WriteLine("2. Анонимные типы (FROM и лямбды)");
			Console.WriteLine("3. Группировка (FROM и лямбды)");
			Console.WriteLine("4. Методы LINQ (ToArray, ToList, Take, Skip, OrderBy, Any, First, FirstOrDefault)");
			Console.WriteLine("0. Выход");
			Console.Write("\nВыберите задание: ");
		}

		private static void DemonstrateFiltering()
		{
			Console.Clear();
			Console.WriteLine("Задание 1: Фильтрация через LINQ\n");

			var students = LinqDemo.GetTestStudents();
			Console.WriteLine("Исходная коллекция студентов:");
			PrintStudents(students);

			Console.WriteLine("\n--- Фильтрация через синтаксис FROM (студенты с оценкой >= 4.5) ---");
			var filteredFrom = LinqDemo.FilterWithFromSyntax(students, 4.5);
			PrintStudents(filteredFrom);

			Console.WriteLine("\n--- Фильтрация через лямбда-выражения (студенты с оценкой >= 4.5) ---");
			var filteredLambda = LinqDemo.FilterWithLambda(students, 4.5);
			PrintStudents(filteredLambda);

			Console.WriteLine("\n--- Дополнительная фильтрация через лямбды (возраст >= 20) ---");
			var filteredByAge = students.Where(s => s.Age >= 20);
			PrintStudents(filteredByAge);
		}

		private static void DemonstrateAnonymousTypes()
		{
			Console.Clear();
			Console.WriteLine("Задание 2: Анонимные типы через LINQ\n");

			var students = LinqDemo.GetTestStudents();
			Console.WriteLine("Исходная коллекция студентов:");
			PrintStudents(students);

			Console.WriteLine("\n--- Анонимные типы через синтаксис FROM ---");
			var anonymousFrom = LinqDemo.AnonymousTypesWithFromSyntax(students);
			PrintAnonymousTypes(anonymousFrom);

			Console.WriteLine("\n--- Анонимные типы через лямбда-выражения ---");
			var anonymousLambda = LinqDemo.AnonymousTypesWithLambda(students);
			PrintAnonymousTypes(anonymousLambda);

			Console.WriteLine("\n--- Дополнительный пример: анонимные типы с вычисляемыми полями ---");
			var extendedAnonymous = students.Select(s => new
			{
				FullName = $"{s.Surname} {s.Name}",
				Group = s.Group,
				Grade = s.AverageGrade,
				Status = s.AverageGrade >= 4.5 ? "Отличник" : "Обычный студент",
				Age = s.Age
			});
			PrintExtendedAnonymousTypes(extendedAnonymous);
		}

		private static void DemonstrateGrouping()
		{
			Console.Clear();
			Console.WriteLine("Задание 3: Группировка через LINQ\n");

			var students = LinqDemo.GetTestStudents();
			Console.WriteLine("Исходная коллекция студентов:");
			PrintStudents(students);

			Console.WriteLine("\n--- Группировка через синтаксис FROM (по группам) ---");
			var groupedFrom = LinqDemo.GroupByWithFromSyntax(students);
			PrintGroupedStudents(groupedFrom);

			Console.WriteLine("\n--- Группировка через лямбда-выражения (по группам) ---");
			var groupedLambda = LinqDemo.GroupByWithLambda(students);
			PrintGroupedStudents(groupedLambda);

			Console.WriteLine("\n--- Группировка с анонимными типами через синтаксис FROM ---");
			var groupedAnonymousFrom = LinqDemo.GroupByWithAnonymousTypesFromSyntax(students);
			PrintGroupedAnonymousTypes(groupedAnonymousFrom);

			Console.WriteLine("\n--- Группировка с анонимными типами через лямбда-выражения ---");
			var groupedAnonymousLambda = LinqDemo.GroupByWithAnonymousTypesLambda(students);
			PrintGroupedAnonymousTypes(groupedAnonymousLambda);

			Console.WriteLine("\n--- Дополнительный пример: группировка по возрасту через лямбды ---");
			var groupedByAge = students.GroupBy(s => s.Age);
			foreach (var group in groupedByAge)
			{
				Console.WriteLine($"\nВозраст: {group.Key} лет ({group.Count()} студентов):");
				foreach (var student in group)
				{
					Console.WriteLine($"  - {student}");
				}
			}
		}

		private static void DemonstrateLinqMethods()
		{
			Console.Clear();
			Console.WriteLine("Задание 4: Методы LINQ\n");

			var students = LinqDemo.GetTestStudents();
			Console.WriteLine("Исходная коллекция студентов:");
			PrintStudents(students);

			Console.WriteLine("\n--- ToArray() - преобразование в массив ---");
			var studentsArray = students.ToArray();
			Console.WriteLine($"Тип: {studentsArray.GetType().Name}, количество элементов: {studentsArray.Length}");
			Console.WriteLine("Первые 3 элемента массива:");
			for (var i = 0; i < Math.Min(3, studentsArray.Length); i++)
			{
				Console.WriteLine($"  [{i}] {studentsArray[i]}");
			}

			Console.WriteLine("\n--- ToList() - преобразование в список ---");
			var studentsList = students.ToList();
			Console.WriteLine($"Тип: {studentsList.GetType().Name}, количество элементов: {studentsList.Count}");
			Console.WriteLine("Первые 3 элемента списка:");
			for (var i = 0; i < Math.Min(3, studentsList.Count); i++)
			{
				Console.WriteLine($"  [{i}] {studentsList[i]}");
			}

			Console.WriteLine("\n--- Take(3) - взять первые 3 элемента ---");
			var taken = students.Take(3);
			PrintStudents(taken);

			Console.WriteLine("\n--- Skip(2) - пропустить первые 2 элемента ---");
			var skipped = students.Skip(2);
			PrintStudents(skipped);

			Console.WriteLine("\n--- Take(3).Skip(1) - комбинация методов ---");
			var combined = students.Take(3).Skip(1);
			PrintStudents(combined);

			Console.WriteLine("\n--- OrderBy() - сортировка по возрастанию среднего балла ---");
			var orderedAsc = students.OrderBy(s => s.AverageGrade);
			PrintStudents(orderedAsc);

			Console.WriteLine("\n--- OrderByDescending() - сортировка по убыванию среднего балла ---");
			var orderedDesc = students.OrderByDescending(s => s.AverageGrade);
			PrintStudents(orderedDesc);

			Console.WriteLine("\n--- OrderBy().ThenBy() - сортировка по группе, затем по оценке ---");
			var orderedMultiple = students.OrderBy(s => s.Group).ThenByDescending(s => s.AverageGrade);
			PrintStudents(orderedMultiple);

			Console.WriteLine("\n--- Any() - проверка наличия элементов с условием ---");
			var hasExcellent = students.Any(s => s.AverageGrade == 5.0);
			Console.WriteLine($"Есть ли студенты с оценкой 5.0? {hasExcellent}");

			var hasLowGrade = students.Any(s => s.AverageGrade < 3.0);
			Console.WriteLine($"Есть ли студенты с оценкой < 3.0? {hasLowGrade}");

			Console.WriteLine("\n--- First() - получение первого элемента ---");
			var first = students.OrderByDescending(s => s.AverageGrade).First();
			Console.WriteLine($"Первый студент (с наивысшей оценкой): {first}");

			Console.WriteLine("\n--- FirstOrDefault() - получение первого элемента или значения по умолчанию ---");
			var firstWithHighGrade = students.FirstOrDefault(s => s.AverageGrade >= 5.0);
			if (firstWithHighGrade != null)
			{
				Console.WriteLine($"Первый студент с оценкой >= 5.0: {firstWithHighGrade}");
			}
			else
			{
				Console.WriteLine("Студентов с оценкой >= 5.0 не найдено.");
			}

			var firstWithLowGrade = students.FirstOrDefault(s => s.AverageGrade < 2.0);
			if (firstWithLowGrade != null)
			{
				Console.WriteLine($"Первый студент с оценкой < 2.0: {firstWithLowGrade}");
			}
			else
			{
				Console.WriteLine("Студентов с оценкой < 2.0 не найдено (возвращен null).");
			}

			Console.WriteLine("\n--- Комплексный пример: фильтрация + сортировка + Take + ToList ---");
			var complexQuery = students
				.Where(s => s.AverageGrade >= 4.0)
				.OrderByDescending(s => s.AverageGrade)
				.Take(5)
				.ToList();
			Console.WriteLine("Топ-5 студентов с оценкой >= 4.0:");
			PrintStudents(complexQuery);
		}

		private static void PrintStudents(IEnumerable<Student> students)
		{
			var index = 1;
			foreach (var student in students)
			{
				Console.WriteLine($"{index}. {student}");
				index++;
			}
		}

		private static void PrintAnonymousTypes(IEnumerable<dynamic> anonymousObjects)
		{
			var index = 1;
			foreach (var item in anonymousObjects)
			{
				Console.WriteLine($"{index}. {item.FullName}, группа: {item.Group}, оценка: {item.Grade:F2}");
				index++;
			}
		}

		private static void PrintExtendedAnonymousTypes(IEnumerable<dynamic> anonymousObjects)
		{
			var index = 1;
			foreach (var item in anonymousObjects)
			{
				Console.WriteLine($"{index}. {item.FullName}, группа: {item.Group}, оценка: {item.Grade:F2}, статус: {item.Status}, возраст: {item.Age}");
				index++;
			}
		}

		private static void PrintGroupedStudents(IEnumerable<IGrouping<string, Student>> groupedStudents)
		{
			foreach (var group in groupedStudents)
			{
				Console.WriteLine($"\nГруппа: {group.Key} ({group.Count()} студентов):");
				foreach (var student in group)
				{
					Console.WriteLine($"  - {student}");
				}
			}
		}

		private static void PrintGroupedAnonymousTypes(IEnumerable<dynamic> groupedAnonymous)
		{
			foreach (var item in groupedAnonymous)
			{
				Console.WriteLine($"\nГруппа: {item.Group}, количество студентов: {item.Count}, средний балл: {item.AverageGrade:F2}");

				if (item.Students != null)
				{
					foreach (var student in item.Students)
					{
						Console.WriteLine($"  - {student}");
					}
				}
			}
		}
	}
}

