using System.Configuration;
using Lab5.Library;

namespace Lab5
{
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
						Task1();
						break;
					case "2":
						Task2();
						break;
					case "3":
						Task3();
						break;
					case "4":
						Task4();
						break;
					case "0":
						running = false;
						Console.WriteLine("До свидания!");
						break;
					default:
						Console.WriteLine("Неверный выбор.");
						break;
				}

				if (running)
				{
					Console.WriteLine("\nНажмите любую клавишу...");
					Console.ReadKey();
				}
			}
		}

		private static void DisplayMenu()
		{
			Console.Clear();
			Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА 5 ===");
			Console.WriteLine("XML, JSON и сериализация\n");
			Console.WriteLine("1. Сохранить объект Student в JSON");
			Console.WriteLine("2. Сохранить коллекцию студентов в JSON");
			Console.WriteLine("3. Загрузить данные из JSON");
			Console.WriteLine("4. Показать путь из App.config");
			Console.WriteLine("0. Выход");
			Console.Write("\nВыберите задание: ");
		}

		private static void Task1()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 1: Сохранение объекта Student ===\n");

			var student = new Student(1, "Иван", "Иванов", 20, 4.5)
			{
				Courses = new List<string> { "Математика", "Физика", "Программирование" }
			};

			Console.WriteLine("Создан студент:");
			Console.WriteLine(student);

			var filePath = GetConfigFilePath() ?? "student.json";
			JsonStorage.SaveToJson(student, filePath);
		}

		private static void Task2()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 2: Сохранение коллекции студентов ===\n");

			var students = JsonStorage.CreateSampleStudents();

			Console.WriteLine("Создана коллекция:");
			foreach (var student in students)
			{
				Console.WriteLine($"  - {student}");
			}

			var filePath = GetConfigFilePath() ?? "students.json";
			JsonStorage.SaveToJson(students, filePath);
		}

		private static void Task3()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 3: Загрузка данных из JSON ===\n");

			var filePath = GetConfigFilePath() ?? "students.json";

			if (!JsonStorage.FileExists(filePath))
			{
				Console.WriteLine($"Файл {filePath} не найден. Сначала сохраните данные.");
				return;
			}

			try
			{
				var students = JsonStorage.LoadFromJson<List<Student>>(filePath);

				if (students != null)
				{
					Console.WriteLine("\nЗагруженные данные:");
					foreach (var student in students)
					{
						Console.WriteLine($"  - {student}");
					}
				}
			}
			catch
			{
				Console.WriteLine("Ошибка при загрузке.");
			}
		}

		private static void Task4()
		{
			Console.Clear();
			Console.WriteLine("=== Задание 4: Конфигурация из App.config ===\n");

			var filePath = ConfigurationManager.AppSettings["JsonFilePath"];

			if (!string.IsNullOrEmpty(filePath))
			{
				Console.WriteLine($"Путь из App.config: {filePath}");
				Console.WriteLine($"Полный путь: {Path.GetFullPath(filePath)}");
			}
			else
			{
				Console.WriteLine("Параметр JsonFilePath не найден");
			}
		}

		private static string? GetConfigFilePath()
		{
			return ConfigurationManager.AppSettings["JsonFilePath"];
		}
	}
}
