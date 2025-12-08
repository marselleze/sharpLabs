using System.Text.Json;
using SharpLabs.Common;

namespace Lab5.Library
{
	/// <summary>
	/// Класс для работы с JSON сериализацией и десериализацией.
	/// </summary>
	public static class JsonStorage
	{
		private static readonly JsonSerializerOptions DefaultOptions = new JsonSerializerOptions
		{
			WriteIndented = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		/// <summary>
		/// Сохраняет объект в JSON файл.
		/// </summary>
		/// <typeparam name="T">Тип сохраняемого объекта.</typeparam>
		/// <param name="data">Данные для сохранения.</param>
		/// <param name="filePath">Путь к файлу.</param>
		public static void SaveToJson<T>(T data, string filePath) where T : notnull
		{
			Argument.Require(!string.IsNullOrWhiteSpace(filePath), "Путь к файлу не может быть пустым.");

			try
			{
				var directory = Path.GetDirectoryName(filePath);

				if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
				{
					Directory.CreateDirectory(directory);
				}

				var json = JsonSerializer.Serialize(data, DefaultOptions);
				File.WriteAllText(filePath, json);

				Console.WriteLine($"Данные успешно сохранены в файл: {filePath}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
				throw;
			}
		}

		/// <summary>
		/// Загружает объект из JSON файла.
		/// </summary>
		/// <typeparam name="T">Тип загружаемого объекта.</typeparam>
		/// <param name="filePath">Путь к файлу.</param>
		/// <returns>Десериализованный объект.</returns>
		public static T? LoadFromJson<T>(string filePath)
		{
			Argument.Require(!string.IsNullOrWhiteSpace(filePath), "Путь к файлу не может быть пустым.");
			Argument.Require(File.Exists(filePath), $"Файл не найден: {filePath}");

			try
			{
				var json = File.ReadAllText(filePath);
				var data = JsonSerializer.Deserialize<T>(json, DefaultOptions);

				Console.WriteLine($"Данные успешно загружены из файла: {filePath}");
				return data;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
				throw;
			}
		}

		/// <summary>
		/// Проверяет существование файла.
		/// </summary>
		/// <param name="filePath">Путь к файлу.</param>
		/// <returns>True, если файл существует; иначе False.</returns>
		public static bool FileExists(string filePath)
		{
			return !string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath);
		}

		/// <summary>
		/// Создает пример данных студентов.
		/// </summary>
		/// <returns>Список студентов.</returns>
		public static List<Student> CreateSampleStudents()
		{
			return new List<Student>
			{
				new Student(1, "Иван", "Иванов", 20, 4.5)
				{
					Courses = new List<string> { "Математика", "Физика", "Программирование" }
				},
				new Student(2, "Мария", "Петрова", 19, 4.8)
				{
					Courses = new List<string> { "Химия", "Биология", "Английский язык" }
				},
				new Student(3, "Петр", "Сидоров", 21, 4.2)
				{
					Courses = new List<string> { "История", "Философия", "Литература" }
				}
			};
		}
	}
}

