using SharpLabs.Common;

namespace Lab7.Library
{
	/// <summary>
	/// Представляет сотрудника компании, наследующегося от класса User.
	/// </summary>
	public class Employee : User
	{
		private int _workExperience;
		private string _position = string.Empty;

		/// <summary>
		/// Получает или задает стаж работы в годах. Стаж должен быть неотрицательным.
		/// </summary>
		/// <exception cref="ArgumentException">Выбрасывается при попытке установить отрицательное значение.</exception>
		public int WorkExperience
		{
			get => _workExperience;
			set
			{
				Argument.Require(value >= 0, "Стаж работы не может быть отрицательным.");
				_workExperience = value;
			}
		}

		/// <summary>
		/// Получает или задает должность сотрудника.
		/// </summary>
		public string Position
		{
			get => _position;
			set
			{
				Argument.NotNull(value, "Должность не может быть null.");
				_position = value;
			}
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Employee.
		/// </summary>
		public Employee()
			: base()
		{
			_workExperience = 0;
			_position = string.Empty;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса Employee с указанными параметрами.
		/// </summary>
		/// <param name="surname">Фамилия сотрудника.</param>
		/// <param name="name">Имя сотрудника.</param>
		/// <param name="patronymic">Отчество сотрудника.</param>
		/// <param name="dateOfBirth">Дата рождения сотрудника.</param>
		/// <param name="workExperience">Стаж работы в годах.</param>
		/// <param name="position">Должность сотрудника.</param>
		public Employee(string surname, string name, string patronymic, DateTime dateOfBirth, int workExperience, string position)
			: base(surname, name, patronymic, dateOfBirth)
		{
			Argument.Require(workExperience >= 0, "Стаж работы не может быть отрицательным.");
			Argument.NotNull(position, "Должность не может быть null.");

			_workExperience = workExperience;
			_position = position;
		}

		/// <summary>
		/// Возвращает строковое представление сотрудника.
		/// </summary>
		public override string ToString()
		{
			return $"{base.ToString()}, должность: {Position}, стаж работы: {WorkExperience} лет";
		}
	}
}

