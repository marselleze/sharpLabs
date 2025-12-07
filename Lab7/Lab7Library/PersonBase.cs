namespace Lab7Library
{
	/// <summary>
	/// Абстрактная базовая сущность человека.
	/// </summary>
	public abstract class PersonBase : IDescribable
	{
		private DateTime _birthDate;

		/// <summary>
		/// Фамилия.
		/// </summary>
		public string LastName { get; protected set; }

		/// <summary>
		/// Имя.
		/// </summary>
		public string FirstName { get; protected set; }

		/// <summary>
		/// Отчество.
		/// </summary>
		public string MiddleName { get; protected set; }

		/// <summary>
		/// Дата рождения.
		/// </summary>
		public DateTime BirthDate
		{
			get => _birthDate;
			protected set
			{
				if (value > DateTime.Today)
				{
					throw new ArgumentException("Дата рождения не может быть в будущем.", nameof(value));
				}

				_birthDate = value;
			}
		}

		/// <summary>
		/// Возраст.
		/// </summary>
		public int Age
		{
			get
			{
				var today = DateTime.Today;
				var age = today.Year - BirthDate.Year;

				if (BirthDate.Date > today.AddYears(-age))
				{
					age--;
				}

				return age;
			}
		}

		/// <summary>
		/// Полное имя.
		/// </summary>
		public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();

		/// <summary>
		/// Инициализирует новый экземпляр <see cref="PersonBase"/>.
		/// </summary>
		protected PersonBase(string lastName, string firstName, string middleName, DateTime birthDate)
		{
			if (string.IsNullOrWhiteSpace(lastName))
			{
				throw new ArgumentException("Фамилия не может быть пустой.", nameof(lastName));
			}

			if (string.IsNullOrWhiteSpace(firstName))
			{
				throw new ArgumentException("Имя не может быть пустым.", nameof(firstName));
			}

			LastName = lastName.Trim();
			FirstName = firstName.Trim();
			MiddleName = middleName?.Trim() ?? string.Empty;
			BirthDate = birthDate;
		}

		/// <summary>
		/// Возвращает текстовое описание сущности.
		/// </summary>
		/// <returns>Описание.</returns>
		public virtual string GetDescription()
		{
			return $"{FullName}, дата рождения: {BirthDate:dd.MM.yyyy}, возраст: {Age}";
		}
	}
}


