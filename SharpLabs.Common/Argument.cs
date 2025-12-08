namespace SharpLabs.Common
{
	/// <summary>
	/// Вспомогательный класс для валидации аргументов методов.
	/// </summary>
	public static class Argument
	{
		/// <summary>
		/// Проверяет, что объект не является null.
		/// </summary>
		/// <param name="value">Проверяемое значение.</param>
		/// <param name="message">Сообщение об ошибке.</param>
		/// <exception cref="ArgumentNullException">Выбрасывается, если значение null.</exception>
		public static void NotNull(object value, string message)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value), message);
			}
		}

		/// <summary>
		/// Проверяет условие и выбрасывает исключение, если оно не выполнено.
		/// </summary>
		/// <param name="condition">Проверяемое условие.</param>
		/// <param name="message">Сообщение об ошибке.</param>
		/// <exception cref="ArgumentException">Выбрасывается, если условие не выполнено.</exception>
		public static void Require(bool condition, string message)
		{
			if (!condition)
			{
				throw new ArgumentException(message);
			}
		}
	}
}

