namespace Lab7Library
{
	/// <summary>
	/// Интерфейс, определяющий сотрудника, который может сообщать о своей должности.
	/// </summary>
	public interface IEmployeeRole
	{
		/// <summary>
		/// Возвращает роль сотрудника.
		/// </summary>
		/// <returns>Название роли.</returns>
		string DescribeRole();
	}

	/// <summary>
	/// Представляет сотрудника компании.
	/// </summary>
	public class Employee : User, IEmployeeRole
	{
		private int _experienceYears;
		private string _position;

		/// <summary>
		/// Событие, возникающее при изменении должности.
		/// </summary>
		public event EventHandler<string>? PositionChanged;

		/// <summary>
		/// Стаж работы (в годах).
		/// </summary>
		public int ExperienceYears
		{
			get => _experienceYears;
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Стаж работы не может быть отрицательным.", nameof(value));
				}

				_experienceYears = value;
			}
		}

		/// <summary>
		/// Должность сотрудника.
		/// </summary>
		public string Position
		{
			get => _position;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Должность не может быть пустой.", nameof(value));
				}

				if (_position != value.Trim())
				{
					_position = value.Trim();
					OnPositionChanged(_position);
				}
			}
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="Employee"/>.
		/// </summary>
		public Employee(
			string lastName,
			string firstName,
			string middleName,
			DateTime birthDate,
			int experienceYears,
			string position)
			: base(lastName, firstName, middleName, birthDate)
		{
			ExperienceYears = experienceYears;
			_position = string.Empty;
			Position = position;
		}

		/// <summary>
		/// Повышает сотрудника, обновляя должность.
		/// </summary>
		/// <param name="newPosition">Новая должность.</param>
		public void Promote(string newPosition)
		{
			Position = newPosition;
		}

		/// <inheritdoc />
		public override string GetDescription()
		{
			var baseDescription = base.GetDescription();
			return $"{baseDescription}. Стаж: {ExperienceYears} лет. Должность: {Position}.";
		}

		/// <inheritdoc />
		public string DescribeRole()
		{
			return $"Сотрудник {FullName} исполняет роль: {Position}.";
		}

		/// <summary>
		/// Вызывает событие <see cref="PositionChanged"/>.
		/// </summary>
		/// <param name="newPosition">Новая должность.</param>
		protected virtual void OnPositionChanged(string newPosition)
		{
			PositionChanged?.Invoke(this, newPosition);
		}
	}
}


