namespace Lab8Library
{
	/// <summary>
	/// Представляет ошибку прикладного уровня. Используется для обёртывания внутренних исключений.
	/// </summary>
	public class ApplicationLayerException : Exception
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="ApplicationLayerException"/>.
		/// </summary>
		/// <param name="message">Сообщение об ошибке.</param>
		public ApplicationLayerException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="ApplicationLayerException"/> с вложенным исключением.
		/// </summary>
		/// <param name="message">Сообщение об ошибке.</param>
		/// <param name="innerException">Внутреннее исключение.</param>
		public ApplicationLayerException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}


