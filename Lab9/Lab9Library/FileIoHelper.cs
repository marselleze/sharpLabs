using System;
using System.IO;
using System.Text;

namespace Lab9Library
{
	/// <summary>
	/// Предоставляет вспомогательные методы для чтения и записи файлов.
	/// </summary>
	public static class FileIoHelper
	{
		/// <summary>
		/// Записывает текст в файл, создавая или перезаписывая его.
		/// </summary>
		/// <param name="filePath">Путь к файлу.</param>
		/// <param name="content">Содержимое для записи.</param>
		public static void WriteText(string filePath, string content)
		{
			ValidateFilePath(filePath);

			content ??= string.Empty;

			File.WriteAllText(filePath, content, Encoding.UTF8);
		}

		/// <summary>
		/// Считывает текст из файла.
		/// </summary>
		/// <param name="filePath">Путь к файлу.</param>
		/// <returns>Содержимое файла в виде строки.</returns>
		public static string ReadText(string filePath)
		{
			ValidateFilePath(filePath);

			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("Файл не найден.", filePath);
			}

			return File.ReadAllText(filePath, Encoding.UTF8);
		}

		/// <summary>
		/// Записывает массив байт в файл, создавая или перезаписывая его.
		/// </summary>
		/// <param name="filePath">Путь к файлу.</param>
		/// <param name="data">Массив байт для записи.</param>
		public static void WriteBytes(string filePath, byte[] data)
		{
			ValidateFilePath(filePath);

			if (data == null)
			{
				throw new ArgumentNullException(nameof(data), "Массив байт не должен быть null.");
			}

			File.WriteAllBytes(filePath, data);
		}

		/// <summary>
		/// Считывает массив байт из файла.
		/// </summary>
		/// <param name="filePath">Путь к файлу.</param>
		/// <returns>Содержимое файла в виде массива байт.</returns>
		public static byte[] ReadBytes(string filePath)
		{
			ValidateFilePath(filePath);

			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("Файл не найден.", filePath);
			}

			return File.ReadAllBytes(filePath);
		}

		/// <summary>
		/// Дозаписывает текст в конец файла, создавая его при отсутствии.
		/// </summary>
		/// <param name="filePath">Путь к файлу.</param>
		/// <param name="content">Текст для дозаписи.</param>
		public static void AppendText(string filePath, string content)
		{
			ValidateFilePath(filePath);

			content ??= string.Empty;

			File.AppendAllText(filePath, content, Encoding.UTF8);
		}

		private static void ValidateFilePath(string filePath)
		{
			if (string.IsNullOrWhiteSpace(filePath))
			{
				throw new ArgumentException("Путь к файлу не должен быть пустым.", nameof(filePath));
			}
		}
	}
}


