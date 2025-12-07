using Lab9Library;

namespace Lab9
{
	/// <summary>
	/// Точка входа в приложение лабораторной работы №9.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Главный метод программы.
		/// </summary>
		private static void Main()
		{
			Console.WriteLine("Лабораторная работа №9");
			Console.WriteLine("Работа с файлами, блочное копирование и события прогресса.");
			Console.WriteLine();

			var exitRequested = false;

			while (!exitRequested)
			{
				Console.WriteLine("Выберите действие:");
				Console.WriteLine("1 - Блочное копирование файла с прогрессом");
				Console.WriteLine("2 - Записать строку в файл");
				Console.WriteLine("3 - Считать строку из файла");
				Console.WriteLine("4 - Записать массив байт в файл");
				Console.WriteLine("5 - Считать массив байт из файла");
				Console.WriteLine("6 - Дозаписать строку в конец файла");
				Console.WriteLine("0 - Выход");
				Console.Write("Ваш выбор: ");

				var choice = Console.ReadLine();
				Console.WriteLine();

				switch (choice)
				{
					case "1":
						RunCopyWithProgress();
						break;
					case "2":
						WriteTextToFile();
						break;
					case "3":
						ReadTextFromFile();
						break;
					case "4":
						WriteBytesToFile();
						break;
					case "5":
						ReadBytesFromFile();
						break;
					case "6":
						AppendTextToFile();
						break;
					case "0":
						exitRequested = true;
						break;
					default:
						Console.WriteLine("Неизвестный пункт меню.");
						break;
				}

				Console.WriteLine();
			}
		}

		private static void RunCopyWithProgress()
		{
			Console.Write("Введите путь к исходному файлу: ");
			var sourcePath = Console.ReadLine();

			Console.Write("Введите путь к конечному файлу: ");
			var destinationPath = Console.ReadLine();

			Console.Write("Введите размер блока в байтах (например, 4096): ");
			var blockSizeInput = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(sourcePath) || string.IsNullOrWhiteSpace(destinationPath))
			{
				Console.WriteLine("Пути к файлам не должны быть пустыми.");
				return;
			}

			if (!int.TryParse(blockSizeInput, out var blockSize) || blockSize <= 0)
			{
				Console.WriteLine("Размер блока должен быть положительным целым числом.");
				return;
			}

			var copier = new BlockFileCopier();

			copier.CopyStarted += (_, _) =>
			{
				Console.WriteLine("Копирование начато.");
			};

			copier.CopyCompleted += (_, _) =>
			{
				Console.WriteLine("Копирование завершено.");
			};

			copier.CopyProgressChanged += (_, args) =>
			{
				Console.WriteLine($"Прогресс: {args.ProgressPercentage}%");
			};

			try
			{
				copier.Copy(sourcePath, destinationPath, blockSize);
				Console.WriteLine("Исходный и конечный файлы идентичны побайтно.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка при копировании файла:");
				Console.WriteLine(ex.Message);
			}
		}

		private static void WriteTextToFile()
		{
			Console.Write("Введите путь к файлу: ");
			var path = Console.ReadLine();

			Console.Write("Введите текст для записи: ");
			var text = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(path))
			{
				Console.WriteLine("Путь к файлу не должен быть пустым.");
				return;
			}

			FileIoHelper.WriteText(path, text ?? string.Empty);
			Console.WriteLine("Текст успешно записан в файл.");
		}

		private static void ReadTextFromFile()
		{
			Console.Write("Введите путь к файлу: ");
			var path = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(path))
			{
				Console.WriteLine("Путь к файлу не должен быть пустым.");
				return;
			}

			try
			{
				var text = FileIoHelper.ReadText(path);
				Console.WriteLine("Содержимое файла:");
				Console.WriteLine(text);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка при чтении файла:");
				Console.WriteLine(ex.Message);
			}
		}

		private static void WriteBytesToFile()
		{
			Console.Write("Введите путь к файлу: ");
			var path = Console.ReadLine();

			Console.Write("Введите строку, которая будет сохранена как массив байт в UTF-8: ");
			var text = Console.ReadLine() ?? string.Empty;

			if (string.IsNullOrWhiteSpace(path))
			{
				Console.WriteLine("Путь к файлу не должен быть пустым.");
				return;
			}

			var bytes = System.Text.Encoding.UTF8.GetBytes(text);
			FileIoHelper.WriteBytes(path, bytes);
			Console.WriteLine("Массив байт успешно записан в файл.");
		}

		private static void ReadBytesFromFile()
		{
			Console.Write("Введите путь к файлу: ");
			var path = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(path))
			{
				Console.WriteLine("Путь к файлу не должен быть пустым.");
				return;
			}

			try
			{
				var bytes = FileIoHelper.ReadBytes(path);
				Console.WriteLine($"Размер файла в байтах: {bytes.Length}");
				Console.WriteLine("Представление в UTF-8 (если применимо):");
				Console.WriteLine(System.Text.Encoding.UTF8.GetString(bytes));
			}
			catch (Exception ex)
			{
				Console.WriteLine("Ошибка при чтении файла:");
				Console.WriteLine(ex.Message);
			}
		}

		private static void AppendTextToFile()
		{
			Console.Write("Введите путь к файлу: ");
			var path = Console.ReadLine();

			Console.Write("Введите текст для дозаписи: ");
			var text = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(path))
			{
				Console.WriteLine("Путь к файлу не должен быть пустым.");
				return;
			}

			FileIoHelper.AppendText(path, text ?? string.Empty);
			Console.WriteLine("Текст успешно дозаписан в файл.");
		}
	}
}


