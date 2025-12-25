using SharpLabs.Common;

namespace Lab8.Library
{
	/// <summary>
	/// Класс для конвертации дат между UTC и локальным часовым поясом.
	/// </summary>
	public static class DateTimeConverter
	{
		/// <summary>
		/// Конвертирует дату из UTC в локальный часовой пояс пользователя.
		/// </summary>
		/// <param name="utcDateTime">Дата и время в UTC.</param>
		/// <returns>Дата и время в локальном часовом поясе.</returns>
		public static DateTime ConvertFromUtcToLocal(DateTime utcDateTime)
		{
			Argument.Require(utcDateTime.Kind == DateTimeKind.Utc, "Входная дата должна быть в формате UTC.");

			var localTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.Local);
			return localTime;
		}

		/// <summary>
		/// Конвертирует дату из локального часового пояса в UTC.
		/// </summary>
		/// <param name="localDateTime">Дата и время в локальном часовом поясе.</param>
		/// <returns>Дата и время в UTC.</returns>
		public static DateTime ConvertFromLocalToUtc(DateTime localDateTime)
		{
			Argument.Require(localDateTime.Kind == DateTimeKind.Local || localDateTime.Kind == DateTimeKind.Unspecified, 
				"Входная дата должна быть в локальном формате.");

			var utcTime = TimeZoneInfo.ConvertTimeToUtc(localDateTime, TimeZoneInfo.Local);
			return utcTime;
		}

		/// <summary>
		/// Получает информацию о текущем часовом поясе пользователя.
		/// </summary>
		/// <returns>Информация о часовом поясе.</returns>
		public static string GetTimeZoneInfo()
		{
			var timeZone = TimeZoneInfo.Local;
			return $"Часовой пояс: {timeZone.DisplayName} ({timeZone.StandardName}), " +
				   $"смещение от UTC: {timeZone.BaseUtcOffset:hh\\:mm}";
		}

		/// <summary>
		/// Конвертирует дату из UTC в указанный часовой пояс.
		/// </summary>
		/// <param name="utcDateTime">Дата и время в UTC.</param>
		/// <param name="timeZoneId">Идентификатор часового пояса.</param>
		/// <returns>Дата и время в указанном часовом поясе.</returns>
		/// <exception cref="TimeZoneNotFoundException">Выбрасывается, если часовой пояс не найден.</exception>
		public static DateTime ConvertFromUtcToTimeZone(DateTime utcDateTime, string timeZoneId)
		{
			try
			{
				Argument.NotNull(timeZoneId, "Идентификатор часового пояса не может быть null.");
				Argument.Require(utcDateTime.Kind == DateTimeKind.Utc, "Входная дата должна быть в формате UTC.");

				var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
				var convertedTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
				return convertedTime;
			}
			catch (TimeZoneNotFoundException ex)
			{
				throw new TimeZoneNotFoundException($"Часовой пояс '{timeZoneId}' не найден.", ex);
			}
			catch (InvalidTimeZoneException ex)
			{
				throw new InvalidTimeZoneException($"Неверный часовой пояс '{timeZoneId}'.", ex);
			}
		}

		/// <summary>
		/// Форматирует дату с указанием часового пояса.
		/// </summary>
		/// <param name="dateTime">Дата и время.</param>
		/// <param name="isUtc">Указывает, является ли дата UTC.</param>
		/// <returns>Отформатированная строка с датой и временем.</returns>
		public static string FormatDateTime(DateTime dateTime, bool isUtc = false)
		{
			var kind = isUtc ? "UTC" : "Local";
			return $"{dateTime:dd'.'MM'.'yyyy HH:mm:ss} ({kind})";
		}
	}
}

