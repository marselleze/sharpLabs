using Lab8Library;

namespace Lab8
{
	/// <summary>
	/// Точка входа в приложение лабораторной работы №8.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Главный метод программы. Здесь перехватываются все необработанные исключения.
		/// </summary>
		private static void Main()
		{
			try
			{
				RunApplication();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Произошла критическая ошибка приложения.");
				Console.WriteLine();
				PrintExceptionChain(ex);
			}
		}

		/// <summary>
		/// Запускает основной сценарий приложения, оборачивая возможные ошибки в ApplicationLayerException.
		/// </summary>
		private static void RunApplication()
		{
			try
			{
				Console.WriteLine("Лабораторная работа №8");
				Console.WriteLine("Глобальная обработка исключений и преобразование дат из UTC в локальный часовой пояс.");
				Console.WriteLine();

				var exitRequested = false;

				while (!exitRequested)
				{
					Console.WriteLine("Выберите действие:");
					Console.WriteLine("1 - Преобразовать дату/время из UTC в локальное");
					Console.WriteLine("2 - Преобразовать дату/время из UTC в произвольный часовой пояс");
					Console.WriteLine("0 - Выход");
					Console.Write("Ваш выбор: ");

					var choice = Console.ReadLine();
					Console.WriteLine();

					switch (choice)
					{
						case "1":
							ConvertUtcToLocal();
							break;
						case "2":
							ConvertUtcToCustomTimeZone();
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
			catch (Exception ex)
			{
				throw new ApplicationLayerException("Ошибка при выполнении основного сценария приложения.", ex);
			}
		}

		/// <summary>
		/// Демонстрирует преобразование даты из UTC в локальное время.
		/// </summary>
		private static void ConvertUtcToLocal()
		{
			try
			{
				Console.WriteLine("=== Преобразование даты/времени из UTC в локальное ===");
				var utcDateTime = ReadUtcDateTime();

				var localDateTime = UtcDateConverter.ConvertToLocal(utcDateTime);
				var localZone = TimeZoneInfo.Local;

				Console.WriteLine($"UTC:              {utcDateTime:O}");
				Console.WriteLine($"Локальное время ({localZone.DisplayName}): {localDateTime:O}");
			}
			catch (Exception ex)
			{
				throw new ApplicationLayerException("Ошибка при преобразовании даты из UTC в локальное время.", ex);
			}
		}

		/// <summary>
		/// Демонстрирует преобразование даты из UTC в указанный пользователем часовой пояс.
		/// </summary>
		private static void ConvertUtcToCustomTimeZone()
		{
			try
			{
				Console.WriteLine("=== Преобразование даты/времени из UTC в указанный часовой пояс ===");
				var utcDateTime = ReadUtcDateTime();

				Console.WriteLine("Доступные часовые пояса (фрагмент):");
				foreach (var zone in TimeZoneInfo.GetSystemTimeZones().Take(5))
				{
					Console.WriteLine($"- {zone.Id} ({zone.DisplayName})");
				}

				Console.Write("Введите идентификатор часового пояса (Id): ");
				var timeZoneId = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(timeZoneId))
				{
					Console.WriteLine("Идентификатор не задан. Операция отменена.");
					return;
				}

				var converted = UtcDateConverter.ConvertToTimeZone(utcDateTime, timeZoneId);
				var zoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

				Console.WriteLine($"UTC:             {utcDateTime:O}");
				Console.WriteLine($"{zoneInfo.DisplayName}: {converted:O}");
			}
			catch (TimeZoneNotFoundException ex)
			{
				throw new ApplicationLayerException("Указанный часовой пояс не найден в системе.", ex);
			}
			catch (Exception ex)
			{
				throw new ApplicationLayerException("Ошибка при преобразовании даты в указанный часовой пояс.", ex);
			}
		}

		/// <summary>
		/// Считывает от пользователя дату и время в формате UTC.
		/// </summary>
		/// <returns>Дата и время в формате UTC.</returns>
		private static DateTime ReadUtcDateTime()
		{
			while (true)
			{
				Console.Write("Введите дату и время в формате UTC (дд.MM.yyyy HH:mm): ");
				var input = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("Строка не должна быть пустой.");
					continue;
				}

				if (!DateTime.TryParse(input, out var dateTime))
				{
					Console.WriteLine("Не удалось распознать дату. Попробуйте снова.");
					continue;
				}

				var utcDateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
				return utcDateTime;
			}
		}

		/// <summary>
		/// Печатает все исключения во всей цепочке InnerException.
		/// </summary>
		/// <param name="exception">Исключение верхнего уровня.</param>
		private static void PrintExceptionChain(Exception exception)
		{
			var current = exception;
			var level = 0;

			while (current != null)
			{
				Console.WriteLine($"Уровень {level}: {current.GetType().Name}");
				Console.WriteLine($"Сообщение: {current.Message}");
				Console.WriteLine();

				current = current.InnerException;
				level++;
			}
		}
	}
}


