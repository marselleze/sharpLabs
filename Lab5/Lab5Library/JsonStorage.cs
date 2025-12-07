using System.Text.Json;

namespace Lab5Library
{
	/// <summary>
	/// Предоставляет методы для автоматической JSON-сериализации и десериализации коллекций объектов.
	/// </summary>
	public static class JsonStorage
	{
		/// <summary>
		/// Сохраняет коллекцию объектов в JSON-файл.
		/// </summary>
		/// <typeparam name="T">Тип объектов коллекции.</typeparam>
		/// <param name="items">Коллекция объектов для сохранения.</param>
		/// <param name="filePath">Путь к JSON-файлу.</param>
		public static void SaveToFile<T>(IEnumerable<T> items, string filePath)
		{
			if (items == null)
			{
				throw new ArgumentNullException(nameof(items), "Коллекция не может быть null.");
			}

			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentException("Путь к файлу не должен быть пустым.", nameof(filePath));
			}

			var options = new JsonSerializerOptions
			{
				WriteIndented = true
			};

			var json = JsonSerializer.Serialize(items, options);

			File.WriteAllText(filePath, json);
		}

		/// <summary>
		/// Загружает коллекцию объектов из JSON-файла.
		/// </summary>
		/// <typeparam name="T">Тип объектов коллекции.</typeparam>
		/// <param name="filePath">Путь к JSON-файлу.</param>
		/// <returns>Коллекция объектов, прочитанных из файла.</returns>
		public static IReadOnlyList<T> LoadFromFile<T>(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentException("Путь к файлу не должен быть пустым.", nameof(filePath));
			}

			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("Указанный JSON-файл не найден.", filePath);
			}

			var json = File.ReadAllText(filePath);

			if (string.IsNullOrWhiteSpace(json))
			{
				return Array.Empty<T>();
			}

			var items = JsonSerializer.Deserialize<List<T>>(json);

			return items ?? Array.Empty<T>();
		}
	}
}


