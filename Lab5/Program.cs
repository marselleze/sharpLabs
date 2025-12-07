using System.Configuration;
using Lab5Library;

namespace Lab5
{
	/// <summary>
	/// Точка входа в приложение лабораторной работы №5.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Главный метод программы.
		/// </summary>
		private static void Main()
		{
			Console.WriteLine("Лабораторная работа №5");
			Console.WriteLine("Режим работы с JSON-файлом (сериализация и десериализация коллекции объектов).");
			Console.WriteLine();

			var filePath = GetJsonFilePath();
			Console.WriteLine($"Текущий путь к JSON-файлу: {filePath}");
			Console.WriteLine();

			var exitRequested = false;

			while (!exitRequested)
			{
				Console.WriteLine("Выберите режим работы:");
				Console.WriteLine("1 - Сериализовать коллекцию студентов в JSON-файл");
				Console.WriteLine("2 - Десериализовать коллекцию студентов из JSON-файла");
				Console.WriteLine("3 - Изменить путь к JSON-файлу (App.config)");
				Console.WriteLine("0 - Выход");
				Console.Write("Ваш выбор: ");

				var choice = Console.ReadLine();
				Console.WriteLine();

				switch (choice)
				{
					case "1":
						SerializeStudents(filePath);
						break;
					case "2":
						DeserializeStudents(filePath);
						break;
					case "3":
						filePath = ChangeJsonFilePath(filePath);
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
		/// Получает путь к JSON-файлу из App.config. Если параметр не задан, используется значение по умолчанию.
		/// </summary>
		/// <returns>Путь к JSON-файлу.</returns>
		private static string GetJsonFilePath()
		{
			var pathFromConfig = ConfigurationManager.AppSettings["JsonFilePath"];

			if (string.IsNullOrWhiteSpace(pathFromConfig))
			{
				return "students.json";
			}

			return pathFromConfig;
		}

		/// <summary>
		/// Позволяет пользователю изменить путь к JSON-файлу и записывает новое значение в App.config.
		/// </summary>
		/// <param name="currentPath">Текущий путь к файлу.</param>
		/// <returns>Новый путь к файлу.</returns>
		private static string ChangeJsonFilePath(string currentPath)
		{
			Console.WriteLine($"Текущий путь: {currentPath}");
			Console.Write("Введите новый путь к JSON-файлу: ");
			var newPath = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(newPath))
			{
				Console.WriteLine("Путь не изменён (пустой ввод).");
				return currentPath;
			}

			var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			if (configuration.AppSettings.Settings["JsonFilePath"] == null)
			{
				configuration.AppSettings.Settings.Add("JsonFilePath", newPath);
			}
			else
			{
				configuration.AppSettings.Settings["JsonFilePath"].Value = newPath;
			}

			configuration.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");

			Console.WriteLine("Путь успешно сохранён в App.config.");

			return newPath;
		}

		/// <summary>
		/// Создаёт тестовую коллекцию студентов и сохраняет её в JSON-файл.
		/// </summary>
		/// <param name="filePath">Путь к JSON-файлу.</param>
		private static void SerializeStudents(string filePath)
		{
			var students = new List<Student>
			{
				new Student("Иван Иванов", 20, 4.5),
				new Student("Пётр Петров", 21, 4.2),
				new Student("Анна Смирнова", 19, 4.8)
			};

			JsonStorage.SaveToFile(students, filePath);

			Console.WriteLine("Коллекция студентов успешно сохранена в JSON-файл.");
		}

		/// <summary>
		/// Загружает коллекцию студентов из JSON-файла и выводит её на экран.
		/// </summary>
		/// <param name="filePath">Путь к JSON-файлу.</param>
		private static void DeserializeStudents(string filePath)
		{
			try
			{
				var students = JsonStorage.LoadFromFile<Student>(filePath);

				if (!students.Any())
				{
					Console.WriteLine("Файл найден, но коллекция пуста.");
					return;
				}

				Console.WriteLine("Содержимое JSON-файла:");

				foreach (var student in students)
				{
					Console.WriteLine($"Имя: {student.Name}, возраст: {student.Age}, средний балл: {student.AverageGrade}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
			}
		}
	}
}


