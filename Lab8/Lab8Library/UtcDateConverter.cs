namespace Lab8Library
{
	/// <summary>
	/// Предоставляет методы для преобразования дат из формата UTC в локальный часовой пояс пользователя.
	/// </summary>
	public static class UtcDateConverter
	{
		/// <summary>
		/// Преобразует дату и время в формате UTC в локальное время пользователя.
		/// </summary>
		/// <param name="utcDateTime">Дата и время в формате UTC.</param>
		/// <returns>Дата и время в локальном часовом поясе пользователя.</returns>
		public static DateTime ConvertToLocal(DateTime utcDateTime)
		{
			if (utcDateTime.Kind == DateTimeKind.Unspecified)
			{
				utcDateTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);
			}

			if (utcDateTime.Kind != DateTimeKind.Utc)
			{
				throw new ArgumentException("Ожидается дата в формате UTC.", nameof(utcDateTime));
			}

			var localTimeZone = TimeZoneInfo.Local;
			var localTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, localTimeZone);

			return localTime;
		}

		/// <summary>
		/// Преобразует дату и время в формате UTC в указанный часовой пояс.
		/// </summary>
		/// <param name="utcDateTime">Дата и время в формате UTC.</param>
		/// <param name="timeZoneId">Идентификатор часового пояса.</param>
		/// <returns>Дата и время в указанном часовом поясе.</returns>
		public static DateTime ConvertToTimeZone(DateTime utcDateTime, string timeZoneId)
		{
			if (string.IsNullOrWhiteSpace(timeZoneId))
			{
				throw new ArgumentException("Идентификатор часового пояса не должен быть пустым.", nameof(timeZoneId));
			}

			if (utcDateTime.Kind == DateTimeKind.Unspecified)
			{
				utcDateTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);
			}

			if (utcDateTime.Kind != DateTimeKind.Utc)
			{
				throw new ArgumentException("Ожидается дата в формате UTC.", nameof(utcDateTime));
			}

			var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
			var convertedTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);

			return convertedTime;
		}
	}
}


