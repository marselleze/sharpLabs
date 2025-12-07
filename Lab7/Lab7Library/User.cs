namespace Lab7Library
{
	/// <summary>
	/// Представляет пользователя системы.
	/// </summary>
	public class User : PersonBase
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="User"/>.
		/// </summary>
		public User(string lastName, string firstName, string middleName, DateTime birthDate)
			: base(lastName, firstName, middleName, birthDate)
		{
		}

		/// <inheritdoc />
		public override string GetDescription()
		{
			return $"Пользователь: {base.GetDescription()}";
		}

		/// <summary>
		/// Возвращает строковое представление пользователя.
		/// </summary>
		public override string ToString()
		{
			return GetDescription();
		}
	}
}


