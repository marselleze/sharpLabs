using SharpLabs.Common;

namespace Lab7.Library
{
	/// <summary>
	/// Представляет пользователя с персональными данными.
	/// </summary>
	public class User
	{
		/// <summary>
		/// Получает или задает фамилию пользователя.
		/// </summary>
		public string Surname { get; set; } = string.Empty;

		/// <summary>
		/// Получает или задает имя пользователя.
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Получает или задает отчество пользователя.
		/// </summary>
		public string Patronymic { get; set; } = string.Empty;

		/// <summary>
		/// Получает или задает дату рождения пользователя.
		/// </summary>
		public DateTime DateOfBirth { get; set; }

		/// <summary>
		/// Получает возраст пользователя в годах.
		/// </summary>
		public int Age
		{
			get
			{
				var today = DateTime.Today;
				var age = today.Year - DateOfBirth.Year;

				if (DateOfBirth.Date > today.AddYears(-age))
				{
					age--;
				}

				return age;
			}
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса User.
		/// </summary>
		public User()
		{
			DateOfBirth = DateTime.Today;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса User с указанными параметрами.
		/// </summary>
		/// <param name="surname">Фамилия пользователя.</param>
		/// <param name="name">Имя пользователя.</param>
		/// <param name="patronymic">Отчество пользователя.</param>
		/// <param name="dateOfBirth">Дата рождения пользователя.</param>
		public User(string surname, string name, string patronymic, DateTime dateOfBirth)
		{
			Argument.NotNull(surname, "Фамилия не может быть null.");
			Argument.NotNull(name, "Имя не может быть null.");
			Argument.NotNull(patronymic, "Отчество не может быть null.");

			Surname = surname;
			Name = name;
			Patronymic = patronymic;
			DateOfBirth = dateOfBirth;
		}

		/// <summary>
		/// Возвращает полное имя пользователя.
		/// </summary>
		/// <returns>Строка с полным именем.</returns>
		public string GetFullName()
		{
			return $"{Surname} {Name} {Patronymic}";
		}

		/// <summary>
		/// Возвращает строковое представление пользователя.
		/// </summary>
		public override string ToString()
		{
			return $"Пользователь: {GetFullName()}, дата рождения: {DateOfBirth:dd'.'MM'.'yyyy}, возраст: {Age} лет";
		}
	}
}

